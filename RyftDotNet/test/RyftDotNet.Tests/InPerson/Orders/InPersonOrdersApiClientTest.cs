using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Orders;
using RyftDotNet.InPerson.Orders.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.InPerson.Orders
{
    public sealed class InPersonOrdersApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly InPersonOrdersApiClient apiClient;

        private readonly InPersonOrder order = TestData.InPersonOrder();

        public InPersonOrdersApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new InPersonOrdersApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new ListInPersonOrdersRequest { Limit = 10, Ascending = true };
            ExpectedRequestArguments? arguments = null;
            var paginatedResponse = new PaginatedResponse<InPersonOrder>(new List<InPersonOrder>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<InPersonOrder>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paginatedResponse);
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "in-person/orders?ascending=true&limit=10",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithoutQueryString_WhenRequestIsNull()
        {
            ExpectedRequestArguments? arguments = null;
            var paginatedResponse = new PaginatedResponse<InPersonOrder>(new List<InPersonOrder>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<InPersonOrder>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paginatedResponse);
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "in-person/orders",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<PaginatedResponse<InPersonOrder>>().ThrowsAsync(exception);
            Func<Task<PaginatedResponse<InPersonOrder>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var paginatedResponse = new PaginatedResponse<InPersonOrder>(new List<InPersonOrder>());
            ryftApiClient.RequestAsync<PaginatedResponse<InPersonOrder>>().ReturnsAsync(paginatedResponse);
            var result = await apiClient.ListAsync();
            result.ShouldBe(paginatedResponse);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<InPersonOrder>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(order);
            await apiClient.GetAsync(order.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/orders/{order.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<InPersonOrder>().ThrowsAsync(exception);
            Func<Task<InPersonOrder>> action = async () => await apiClient.GetAsync(order.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<InPersonOrder>().ReturnsAsync(order);
            var result = await apiClient.GetAsync(order.Id);
            result.ShouldBe(order);
        }
    }
}