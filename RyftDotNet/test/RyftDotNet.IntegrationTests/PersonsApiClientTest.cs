using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Common.Request;
using RyftDotNet.Persons;
using RyftDotNet.Persons.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class PersonsApiClientTest
{
    private readonly PersonsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    private static readonly string ExistingAccountId = TestUtility.ExistingNonHostedAccountId;

    [Fact]
    public async Task Client_ShouldSuccessfullyInteractWithEndpoints()
    {
        var persons = await apiClient.ListAsync(ExistingAccountId);
        foreach (var person in persons.Items)
        {
            await apiClient.DeleteAsync(ExistingAccountId, person.Id);
        }
        var result = await apiClient.CreateAsync(
            ExistingAccountId,
            new CreatePersonRequest(
                "Fred",
                "Jones",
                $"{TestUtility.ResourcePrefix()}@ryftpay.com",
                new DateOfEvent(1990, 1, 25),
                Gender.Male,
                ["GB", "IE"],
                new AccountAddressRequest(
                    "123 Test Street",
                    "Manchester",
                    "GB",
                    "ABC 123"
                ),
                "+447900000000",
                [PersonBusinessRole.UltimateBeneficialOwner, PersonBusinessRole.Director]
            )
        );
        result.ShouldSatisfyAllConditions(
            r => r.FirstName.ShouldBe("Fred"),
            r => r.LastName.ShouldBe("Jones")
        );

        var retrieved = await apiClient.GetAsync(ExistingAccountId, result.Id);
        retrieved.Id.ShouldBe(result.Id);

        var updated = await apiClient.UpdateAsync(
            ExistingAccountId,
            result.Id,
            new UpdatePersonRequest
            {
                PhoneNumber = "+447900000002"
            }
        );
        updated.PhoneNumber.ShouldBe("+447900000002");

        var deleted = await apiClient.DeleteAsync(ExistingAccountId, result.Id);
        deleted.ShouldBe(new DeletedResource(result.Id));
    }
}
