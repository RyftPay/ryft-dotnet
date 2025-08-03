using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.Events;
using RyftDotNet.Events.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Events
{
    public sealed class EventsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly EventsApiClient apiClient;

        private readonly Event @event = TestData.Event();

        public EventsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new EventsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<Event>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(@event);
            await apiClient.GetAsync(@event.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"events/{@event.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Event>().ThrowsAsync(exception);
            Func<Task<Event>> action = async () => await apiClient.GetAsync(@event.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Event>().ReturnsAsync(@event);
            var result = await apiClient.GetAsync(@event.Id);
            result.ShouldBe(@event);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<Event>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Event>(new List<Event>()));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "events",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListEventsRequest
            {
                Ascending = false,
                Limit = 10
            };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<Event>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Event>(new List<Event>()));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"events{request.ToQueryString()}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<PaginatedResponse<Event>>().ThrowsAsync(exception);
            Func<Task<PaginatedResponse<Event>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<Event>(new List<Event>());
            ryftApiClient.RequestAsync<PaginatedResponse<Event>>().ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }
    }
}
