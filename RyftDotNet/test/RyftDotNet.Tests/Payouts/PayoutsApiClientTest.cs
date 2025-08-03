using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.Payouts;
using RyftDotNet.Payouts.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Payouts
{
    public sealed class PayoutsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly PayoutsApiClient apiClient;

        private const string AccountId = TestData.AccountId;
        private readonly Payout payout = TestData.Payout();

        public PayoutsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new PayoutsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            var request = TestData.CreatePayoutRequest();
            ryftApiClient
                .RequestAsync<Payout>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(payout);
            await apiClient.CreateAsync(AccountId, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/payouts",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = TestData.CreatePayoutRequest();
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Payout>()
                .ThrowsAsync(exception);
            Func<Task<Payout>> action = async () => await apiClient.CreateAsync(AccountId, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = TestData.CreatePayoutRequest();
            ryftApiClient
                .RequestAsync<Payout>()
                .ReturnsAsync(payout);
            var result = await apiClient.CreateAsync(AccountId, request);
            result.ShouldBe(payout);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Payout>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(payout);
            await apiClient.GetAsync(AccountId, payout.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/payouts/{payout.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Payout>()
                .ThrowsAsync(exception);
            Func<Task<Payout>> action = async () => await apiClient.GetAsync(AccountId, payout.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<Payout>()
                .ReturnsAsync(payout);
            var result = await apiClient.GetAsync(AccountId, payout.Id);
            result.ShouldBe(payout);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<Payout>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Payout>(new List<Payout>()));
            await apiClient.ListAsync(AccountId);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/payouts",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListPayoutsRequest { Ascending = false, Limit = 10 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<Payout>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Payout>(new List<Payout>()));
            await apiClient.ListAsync(AccountId, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/payouts{request.ToQueryString()}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaginatedResponse<Payout>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<Payout>>> action = async () => await apiClient.ListAsync(AccountId);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<Payout>(new List<Payout>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<Payout>>()
                .ReturnsAsync(response);
            var result = await apiClient.ListAsync(AccountId);
            result.ShouldBe(response);
        }
    }
}
