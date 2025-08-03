using RyftDotNet.Client;
using RyftDotNet.PlatformFees;
using RyftDotNet.PlatformFees.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class PlatformFeesApiClientTest
{
    private readonly PlatformFeesApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToFetchResource()
    {
        var result = await apiClient.GetAsync(TestUtility.ExistingPlatformFeeId);
        result.ShouldSatisfyAllConditions(
            r => r.Id.ShouldBe(TestUtility.ExistingPlatformFeeId)
        );
    }

    [Fact]
    public async Task Client_ShouldBeAbleToListResources()
    {
        var result = await apiClient.ListAsync(
            new ListPlatformFeesRequest { Limit = 1 }
        );
        result.ShouldSatisfyAllConditions(
            r => r.Items.ShouldHaveSingleItem()
        );
    }
}
