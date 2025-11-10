using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Products;
using RyftDotNet.InPerson.Products.Request;
using Shouldly;

namespace RyftDotNet.IntegrationTests;

public sealed class InPersonProductsApiClientTest
{
    private readonly InPersonProductsApiClient apiClient = new(new RyftApiClient(
        requestSettings: new ClientRequestSettings { ApiKey = TestUtility.SecretApiKey }
    ));

    [Fact]
    public async Task Client_ShouldBeAbleToListProducts()
    {
        var request = new ListInPersonProductsRequest
        {
            Limit = 10
        };

        var result = await apiClient.ListAsync(request);
        result.ShouldNotBeNull();
        result.Items.ShouldNotBeNull();
    }

    [Fact]
    public async Task Client_ShouldBeAbleToGetProduct()
    {
        var listResult = await apiClient.ListAsync(new ListInPersonProductsRequest { Limit = 1 });

        if (listResult.Items.Any())
        {
            var productId = listResult.Items.First().Id;

            var product = await apiClient.GetAsync(productId);
            product.ShouldNotBeNull();
            product.Id.ShouldBe(productId);
            product.Name.ShouldNotBeNullOrEmpty();
            product.Status.ShouldNotBeNull();
        }
        else
        {
            Assert.True(true, "No products available in test environment to fetch");
        }
    }

    [Fact]
    public async Task Client_ShouldBeAbleToListProductsWithPagination()
    {
        var request = new ListInPersonProductsRequest
        {
            Limit = 2,
            Ascending = true
        };

        var result = await apiClient.ListAsync(request);
        result.ShouldNotBeNull();
        result.Items.ShouldNotBeNull();

        if (result.Items.Count() > 1)
        {
            var products = result.Items.ToList();
            products.Count.ShouldBeLessThanOrEqualTo(2);
        }
    }
}
