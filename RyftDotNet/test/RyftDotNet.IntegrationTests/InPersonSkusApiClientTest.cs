using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Skus;
using RyftDotNet.InPerson.Skus.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class InPersonSkusApiClientTest
{
    private readonly InPersonSkusApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToListSkus()
    {
        var request = new ListInPersonSkusRequest("GB")
        {
            Limit = 10
        };

        var result = await apiClient.ListAsync(request);
        result.ShouldNotBeNull();
        result.Items.ShouldNotBeNull();
    }

    [Fact]
    public async Task Client_ShouldBeAbleToGetSku()
    {
        var listResult = await apiClient.ListAsync(new ListInPersonSkusRequest("GB") { Limit = 1 });

        if (listResult.Items.Any())
        {
            var skuId = listResult.Items.First().Id;

            var sku = await apiClient.GetAsync(skuId);
            sku.ShouldNotBeNull();
            sku.Id.ShouldBe(skuId);
            sku.Name.ShouldNotBeNullOrEmpty();
            sku.Country.ShouldNotBeNullOrEmpty();
            sku.Status.ShouldNotBeNull();
        }
        else
        {
            Assert.True(true, "No SKUs available in test environment for GB to fetch");
        }
    }

    [Fact]
    public async Task Client_ShouldBeAbleToListSkusWithProductFilter()
    {
        var listResult = await apiClient.ListAsync(new ListInPersonSkusRequest("GB") { Limit = 10 });

        if (listResult.Items.Any())
        {
            var productId = listResult.Items.First().ProductId;

            var request = new ListInPersonSkusRequest("GB")
            {
                ProductId = productId,
                Limit = 10
            };

            var result = await apiClient.ListAsync(request);
            result.ShouldNotBeNull();
            result.Items.ShouldNotBeNull();

            if (result.Items.Any())
            {
                foreach (var sku in result.Items)
                {
                    sku.ProductId.ShouldBe(productId);
                }
            }
        }
        else
        {
            Assert.True(true, "No SKUs available in test environment to filter by product");
        }
    }

    [Fact]
    public async Task Client_ShouldBeAbleToListSkusWithPagination()
    {
        var request = new ListInPersonSkusRequest("GB")
        {
            Limit = 2
        };

        var result = await apiClient.ListAsync(request);
        result.ShouldNotBeNull();
        result.Items.ShouldNotBeNull();

        if (result.Items.Count() > 1)
        {
            var skus = result.Items.ToList();
            skus.Count.ShouldBeLessThanOrEqualTo(2);
        }
    }
}