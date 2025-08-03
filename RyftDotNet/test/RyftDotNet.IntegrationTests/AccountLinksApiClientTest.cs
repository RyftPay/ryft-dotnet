using RyftDotNet.AccountLinks;
using RyftDotNet.AccountLinks.Request;
using RyftDotNet.Client;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class AccountLinksApiClientTest
{
    private readonly AccountLinksApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToCreateResource()
    {
        var request = new CreateAccountLinkRequest(
            TestUtility.ExistingHostedAccountId,
            "https://ryftpay.com"
        );
        var result = await apiClient.CreateAsync(request);
        result.Url.ShouldContain("ryft");
    }
}
