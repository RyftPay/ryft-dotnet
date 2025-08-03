using RyftDotNet.Client;
using RyftDotNet.Transfers;
using RyftDotNet.Transfers.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class TransfersApiClientTest
{
    private readonly TransfersApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    private static readonly string ExistingAccountId = TestUtility.ExistingNonHostedAccountId;

    [Fact]
    public async Task Client_ShouldSuccessfullyInteractWithEndpoints()
    {
        var result = await apiClient.CreateAsync(
            new CreateTransferRequest(5, "GBP") { Destination = new TransferLocationRequest(ExistingAccountId) }
        );
        result.ShouldSatisfyAllConditions(
            r => r.Amount.ShouldBe(5),
            r => r.Currency.ShouldBe("GBP"),
            r => r.Destination.ShouldBe(new TransferLocation(ExistingAccountId))
        );

        var retrieved = await apiClient.GetAsync(result.Id);
        retrieved.Id.ShouldBe(result.Id);

        var listed = await apiClient.ListAsync(
            new ListTransfersRequest { Limit = 10 }
        );
        listed.ShouldSatisfyAllConditions(
            l => l.Items.ShouldContain(retrieved)
        );
    }
}
