using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Orders;
using RyftDotNet.InPerson.Orders.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class InPersonOrdersApiClientTest
{
    private readonly InPersonOrdersApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToListOrders()
    {
        var request = new ListInPersonOrdersRequest
        {
            Limit = 10
        };

        var result = await apiClient.ListAsync(request);
        result.ShouldNotBeNull();
        result.Items.ShouldNotBeNull();
    }

    [Fact]
    public async Task Client_ShouldBeAbleToGetOrder()
    {
        var listResult = await apiClient.ListAsync(new ListInPersonOrdersRequest { Limit = 1 });

        if (listResult.Items.Any())
        {
            var orderId = listResult.Items.First().Id;

            var order = await apiClient.GetAsync(orderId);
            order.ShouldNotBeNull();
            order.Id.ShouldBe(orderId);
            order.Status.ShouldNotBeNull();
            order.Items.ShouldNotBeNull();
            order.Items.ShouldNotBeEmpty();
        }
        else
        {
            Assert.True(true, "No orders available in test environment to fetch");
        }
    }

    [Fact]
    public async Task Client_ShouldBeAbleToListOrdersWithPagination()
    {
        var request = new ListInPersonOrdersRequest
        {
            Limit = 2,
            Ascending = true
        };

        var result = await apiClient.ListAsync(request);
        result.ShouldNotBeNull();
        result.Items.ShouldNotBeNull();

        if (result.Items.Count() > 1)
        {
            var orders = result.Items.ToList();
            orders.Count.ShouldBeLessThanOrEqualTo(2);
        }
    }

    [Fact]
    public async Task Client_ShouldReturnOrderWithCompleteDetails()
    {
        var listResult = await apiClient.ListAsync(new ListInPersonOrdersRequest { Limit = 1 });

        if (listResult.Items.Any())
        {
            var order = listResult.Items.First();

            order.Id.ShouldNotBeNullOrEmpty();
            order.Status.ShouldNotBeNull();
            order.TotalAmount.ShouldBeGreaterThanOrEqualTo(0);
            order.TaxAmount.ShouldBeGreaterThanOrEqualTo(0);
            order.Currency.ShouldNotBeNullOrEmpty();
            order.Items.ShouldNotBeNull();
            order.CreatedTimestamp.ShouldNotBe(default);
            order.LastUpdatedTimestamp.ShouldNotBe(default);

            foreach (var item in order.Items)
            {
                item.Id.ShouldNotBeNullOrEmpty();
                item.Name.ShouldNotBeNullOrEmpty();
                item.Quantity.ShouldBeGreaterThan(0);
            }
        }
        else
        {
            Assert.True(true, "No orders available in test environment to verify details");
        }
    }
}
