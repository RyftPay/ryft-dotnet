using RyftDotNet.Balances;
using RyftDotNet.Client;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class BalancesApiClientTest
{
    private readonly BalancesApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldSuccessfullyInteractWithEndpoints()
    {
        var listed = await apiClient.ListAsync();
        listed.Items.ShouldNotBeEmpty();
    }
}
