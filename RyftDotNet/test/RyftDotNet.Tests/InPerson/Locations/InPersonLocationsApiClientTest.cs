using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Locations;
using RyftDotNet.InPerson.Locations.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.InPerson.Locations
{
    public sealed class InPersonLocationsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly InPersonLocationsApiClient apiClient;

        private readonly InPersonLocation location = TestData.InPersonLocation();
        private readonly CreateInPersonLocationRequest createRequest = TestData.CreateInPersonLocationRequest();

        public InPersonLocationsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new InPersonLocationsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<InPersonLocation>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(location);
            await apiClient.CreateAsync(createRequest);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "in-person/locations",
                HttpMethod.Post,
                HttpStatusCode.OK,
                createRequest
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<InPersonLocation>().ThrowsAsync(exception);
            Func<Task<InPersonLocation>> action = async () => await apiClient.CreateAsync(createRequest);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<InPersonLocation>().ReturnsAsync(location);
            var result = await apiClient.CreateAsync(createRequest);
            result.ShouldBe(location);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new ListInPersonLocationsRequest { Limit = 10, Ascending = true };
            ExpectedRequestArguments? arguments = null;
            var paginatedResponse = new PaginatedResponse<InPersonLocation>(new List<InPersonLocation>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<InPersonLocation>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paginatedResponse);
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "in-person/locations?ascending=true&limit=10",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var paginatedResponse = new PaginatedResponse<InPersonLocation>(new List<InPersonLocation>());
            ryftApiClient.RequestAsync<PaginatedResponse<InPersonLocation>>().ReturnsAsync(paginatedResponse);
            var result = await apiClient.ListAsync();
            result.ShouldBe(paginatedResponse);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<InPersonLocation>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(location);
            await apiClient.GetAsync(location.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/locations/{location.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<InPersonLocation>().ReturnsAsync(location);
            var result = await apiClient.GetAsync(location.Id);
            result.ShouldBe(location);
        }

        [Fact]
        public async Task UpdateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var updateRequest = new UpdateInPersonLocationRequest { Name = "Updated Name" };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<InPersonLocation>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(location);
            await apiClient.UpdateAsync(location.Id, updateRequest);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/locations/{location.Id}",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                updateRequest
            ));
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var updateRequest = new UpdateInPersonLocationRequest { Name = "Updated Name" };
            ryftApiClient.RequestAsync<InPersonLocation>().ReturnsAsync(location);
            var result = await apiClient.UpdateAsync(location.Id, updateRequest);
            result.ShouldBe(location);
        }

        [Fact]
        public async Task DeleteAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            var deleted = new InPersonLocationDeleted(location.Id);
            ryftApiClient
                .RequestAsync<InPersonLocationDeleted>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(deleted);
            await apiClient.DeleteAsync(location.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/locations/{location.Id}",
                HttpMethod.Delete,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnResource_WhenSuccessful()
        {
            var deleted = new InPersonLocationDeleted(location.Id);
            ryftApiClient.RequestAsync<InPersonLocationDeleted>().ReturnsAsync(deleted);
            var result = await apiClient.DeleteAsync(location.Id);
            result.ShouldBe(deleted);
        }
    }
}
