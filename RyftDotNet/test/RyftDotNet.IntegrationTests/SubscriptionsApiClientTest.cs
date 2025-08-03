using RyftDotNet.Client;
using RyftDotNet.Subscriptions;
using RyftDotNet.Subscriptions.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class SubscriptionsApiClientTest
{
    private readonly SubscriptionsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldSuccessfullyInteractWithEndpoints()
    {
        const string description = "Bob's monthly membership";
        var request = new CreateSubscriptionRequest(
            new CreateSubscriptionCustomerRequest(TestUtility.ExistingCustomerId),
            new CreateSubscriptionPriceRequest(
                5000,
                "GBP",
                new SubscriptionIntervalRequest(
                    IntervalUnit.Days,
                    1
                )
                { Times = 2 }
            )
        )
        { Description = description };
        var subscription = await apiClient.CreateAsync(request);
        subscription.ShouldSatisfyAllConditions(
            s => s.Description.ShouldBe(description),
            s => s.Customer.ShouldBe(new SubscriptionCustomer(TestUtility.ExistingCustomerId))
        );
        const string updatedDescription = "Bob's updated monthly membership";
        var updated = await apiClient.UpdateAsync(
            subscription.Id,
            new UpdateSubscriptionRequest
            {
                Description = updatedDescription,
                Metadata = new Dictionary<string, string> { ["customField"] = "1234" }
            }
        );
        updated.ShouldSatisfyAllConditions(
            u => u.Description.ShouldBe(updatedDescription)
        );
        var subscriptions = await apiClient.ListAsync(
            new ListSubscriptionsRequest { Limit = 1 }
        );
        subscriptions.Items.ShouldNotBeEmpty();
    }
}
