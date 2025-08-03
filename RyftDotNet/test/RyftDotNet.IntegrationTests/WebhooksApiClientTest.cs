using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Webhooks;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class WebhooksApiClientTest
{
    private readonly WebhooksApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldSuccessfullyInteractWithEndpoints()
    {
        long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var request = new CreateWebhookRequest(
            $"https://{timestamp}.ryftpay.com",
            true,
            [EventType.PaymentSessionCaptured]
        );
        var result = await apiClient.CreateAsync(request);
        result.ShouldSatisfyAllConditions(
            r => r.Secret.Length.ShouldBeGreaterThan(1),
            r => r.Url.ShouldBe(request.Url),
            r => r.EventTypes.ShouldContain(EventType.PaymentSessionCaptured)
        );

        var updated = await apiClient.UpdateAsync(
            result.Id,
            new UpdateWebhookRequest { Active = false }
        );

        updated.Active.ShouldBeFalse();

        var retrieved = await apiClient.GetAsync(result.Id);
        retrieved.Id.ShouldBe(result.Id);

        var listed = await apiClient.ListAsync();
        listed.Items.ShouldContain(item => item.Id == result.Id);

        var deleted = await apiClient.DeleteAsync(result.Id);
        deleted.ShouldBe(new DeletedResource(result.Id));
    }
}
