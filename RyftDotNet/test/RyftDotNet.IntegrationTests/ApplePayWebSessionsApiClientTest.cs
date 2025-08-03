using RyftDotNet.ApplePay.Sessions;
using RyftDotNet.Client;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class ApplePayWebSessionsApiClientTest
{
    private readonly ApplePayWebSessionsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToCreateResource()
    {
        var result = await apiClient.CreateAsync(
            new CreateApplePayWebSessionRequest("Ryft", "dash.ryftpay.com")
        );
        result.SessionObject.Length.ShouldBeGreaterThan(1);
    }
}
