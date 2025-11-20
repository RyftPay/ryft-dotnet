using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Products;
using RyftDotNet.InPerson.Products.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.InPerson.Products
{
    public sealed class InPersonProductsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly InPersonProductsApiClient apiClient;

        private readonly InPersonProduct product = TestData.InPersonProduct();

        public InPersonProductsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new InPersonProductsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new ListInPersonProductsRequest { Limit = 10, Ascending = true };
            ExpectedRequestArguments? arguments = null;
            var paginatedResponse = new PaginatedResponse<InPersonProduct>(new List<InPersonProduct>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<InPersonProduct>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paginatedResponse);
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "in-person/products?ascending=true&limit=10",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithoutQueryString_WhenRequestIsNull()
        {
            ExpectedRequestArguments? arguments = null;
            var paginatedResponse = new PaginatedResponse<InPersonProduct>(new List<InPersonProduct>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<InPersonProduct>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paginatedResponse);
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "in-person/products",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<PaginatedResponse<InPersonProduct>>().ThrowsAsync(exception);
            Func<Task<PaginatedResponse<InPersonProduct>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var paginatedResponse = new PaginatedResponse<InPersonProduct>(new List<InPersonProduct>());
            ryftApiClient.RequestAsync<PaginatedResponse<InPersonProduct>>().ReturnsAsync(paginatedResponse);
            var result = await apiClient.ListAsync();
            result.ShouldBe(paginatedResponse);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<InPersonProduct>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(product);
            await apiClient.GetAsync(product.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/products/{product.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<InPersonProduct>().ThrowsAsync(exception);
            Func<Task<InPersonProduct>> action = async () => await apiClient.GetAsync(product.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<InPersonProduct>().ReturnsAsync(product);
            var result = await apiClient.GetAsync(product.Id);
            result.ShouldBe(product);
        }
    }
}
