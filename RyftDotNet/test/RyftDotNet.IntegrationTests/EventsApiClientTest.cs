using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Events;
using RyftDotNet.Events.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class EventsApiClientTest
{
    private readonly EventsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    private static readonly string EventId = TestUtility.ExistingEventId;

    [Fact]
    public async Task Client_ShouldBeAbleToGetExistingResource()
    {
        var result = await apiClient.GetAsync(EventId);
        result.ShouldSatisfyAllConditions(
            f => f.Id.ShouldBe(EventId),
            f => f.EventType.ShouldBe(EventType.SubscriptionUpdated),
            f => f.CreatedTimestamp.ShouldBe(DateTimeOffset.FromUnixTimeSeconds(1754065133L))
        );
    }

    [Fact]
    public async Task Client_ShouldBeAbleToListResources()
    {
        var result = await apiClient.ListAsync(
            new ListEventsRequest { Limit = 10 }
        );
        result.ShouldSatisfyAllConditions(
            r => r.Items.Count().ShouldBeGreaterThan(2)
        );
    }
}
