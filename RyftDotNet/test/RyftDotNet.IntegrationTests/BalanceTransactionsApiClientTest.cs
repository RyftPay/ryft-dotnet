using RyftDotNet.BalanceTransactions;
using RyftDotNet.Client;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class BalanceTransactionsApiClientTest
{
    private readonly BalanceTransactionsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldSuccessfullyInteractWithEndpoints()
    {
        var listed = await apiClient.ListAsync();
        listed.Items.ShouldNotBeEmpty();
    }
}
