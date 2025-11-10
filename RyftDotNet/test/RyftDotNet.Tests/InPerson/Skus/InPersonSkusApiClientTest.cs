using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Skus;
using RyftDotNet.InPerson.Skus.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.InPerson.Skus
{
    public sealed class InPersonSkusApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly InPersonSkusApiClient apiClient;

        private readonly InPersonProductSku sku = TestData.InPersonProductSku();

        public InPersonSkusApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new InPersonSkusApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new ListInPersonSkusRequest("GB") { Limit = 10, ProductId = "ippd_01HXYZ123456789ABCDEFGH" };
            ExpectedRequestArguments? arguments = null;
            var paginatedResponse = new PaginatedResponse<InPersonProductSku>(new List<InPersonProductSku>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<InPersonProductSku>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paginatedResponse);
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "in-person/skus?country=GB&productId=ippd_01HXYZ123456789ABCDEFGH&limit=10",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithOnlyCountry_WhenOptionalParametersNotSet()
        {
            var request = new ListInPersonSkusRequest("US");
            ExpectedRequestArguments? arguments = null;
            var paginatedResponse = new PaginatedResponse<InPersonProductSku>(new List<InPersonProductSku>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<InPersonProductSku>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paginatedResponse);
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "in-person/skus?country=US",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new ListInPersonSkusRequest("GB");
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<PaginatedResponse<InPersonProductSku>>().ThrowsAsync(exception);
            Func<Task<PaginatedResponse<InPersonProductSku>>> action = async () => await apiClient.ListAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new ListInPersonSkusRequest("GB");
            var paginatedResponse = new PaginatedResponse<InPersonProductSku>(new List<InPersonProductSku>());
            ryftApiClient.RequestAsync<PaginatedResponse<InPersonProductSku>>().ReturnsAsync(paginatedResponse);
            var result = await apiClient.ListAsync(request);
            result.ShouldBe(paginatedResponse);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<InPersonProductSku>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(sku);
            await apiClient.GetAsync(sku.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/skus/{sku.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<InPersonProductSku>().ThrowsAsync(exception);
            Func<Task<InPersonProductSku>> action = async () => await apiClient.GetAsync(sku.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<InPersonProductSku>().ReturnsAsync(sku);
            var result = await apiClient.GetAsync(sku.Id);
            result.ShouldBe(sku);
        }
    }
}