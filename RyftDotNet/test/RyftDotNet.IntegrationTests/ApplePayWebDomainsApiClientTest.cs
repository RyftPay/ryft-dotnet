using RyftDotNet.ApplePay.WebDomains;
using RyftDotNet.Client;
using RyftDotNet.Common;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class ApplePayWebDomainsApiClientTest
{
    private readonly ApplePayWebDomainsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldSuccessfullyInteractWithEndpoints()
    {
        const string domainName = "sandbox-dash.ryftpay.com";
        var existingResources = await apiClient.ListAsync();
        var existingDomain = existingResources.Items.FirstOrDefault(r => r.DomainName == domainName);
        if (existingDomain != null)
        {
            await apiClient.DeleteAsync(existingDomain.Id);
        }
        var result = await apiClient.CreateAsync(
            new CreateApplePayWebDomainRequest("sandbox-dash.ryftpay.com")
        );
        result.ShouldSatisfyAllConditions(
            r => r.DomainName.ShouldBe("sandbox-dash.ryftpay.com")
        );

        var retrieved = await apiClient.GetAsync(result.Id);
        retrieved.Id.ShouldBe(result.Id);

        var listed = await apiClient.ListAsync();
        listed.Items.ShouldContain(item => item.Id == result.Id);

        var deleted = await apiClient.DeleteAsync(result.Id);
        deleted.ShouldBe(new DeletedResource(result.Id));
    }
}
