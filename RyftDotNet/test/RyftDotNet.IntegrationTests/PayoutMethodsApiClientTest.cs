using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.PayoutMethods;
using RyftDotNet.PayoutMethods.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class PayoutMethodsApiClientTest
{
    private readonly PayoutMethodsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    private static readonly string ExistingAccountId = TestUtility.ExistingNonHostedAccountId;

    [Fact]
    public async Task Client_ShouldSuccessfullyInteractWithEndpoints()
    {
        var existing = await apiClient.ListAsync(ExistingAccountId);
        foreach (var payoutMethod in existing.Items)
        {
            await apiClient.DeleteAsync(ExistingAccountId, payoutMethod.Id);
        }
        var result = await apiClient.CreateAsync(
            ExistingAccountId,
            new CreatePayoutMethodRequest(
                PayoutMethodType.BankAccount,
                "GB",
                "GBP",
                new BankAccountRequest(
                    AccountNumberType.UnitedKingdom,
                    "00000111"
                )
                { BankIdType = BankIdType.SortCode, BankId = "000001" }
            )
            { DisplayName = "My GBP account" }
        );
        result.ShouldSatisfyAllConditions(
            r => r.CountryCode.ShouldBe("GB"),
            r => r.Currency.ShouldBe("GBP"),
            r => r.DisplayName.ShouldBe("My GBP account")
        );

        var retrieved = await apiClient.GetAsync(ExistingAccountId, result.Id);
        retrieved.Id.ShouldBe(result.Id);

        var listed = await apiClient.ListAsync(
            ExistingAccountId,
            new ListPayoutMethodsRequest { Limit = 1 }
        );
        listed.ShouldSatisfyAllConditions(
            l => l.Items.ShouldContain(retrieved)
        );

        var updated = await apiClient.UpdateAsync(
            ExistingAccountId,
            result.Id,
            new UpdatePayoutMethodRequest
            {
                DisplayName = "My updated GBP account"
            }
        );
        updated.DisplayName.ShouldBe("My updated GBP account");

        var deleted = await apiClient.DeleteAsync(ExistingAccountId, result.Id);
        deleted.ShouldBe(new DeletedResource(result.Id));
    }
}
