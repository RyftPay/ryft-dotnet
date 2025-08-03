using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.PayoutMethods;
using RyftDotNet.PayoutMethods.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PayoutMethods
{
    public sealed class PayoutMethodsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly PayoutMethodsApiClient apiClient;

        private const string AccountId = TestData.AccountId;
        private readonly PayoutMethod payoutMethod = TestData.PayoutMethod();

        public PayoutMethodsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new PayoutMethodsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            var request = TestData.CreatePayoutMethodRequest();
            ryftApiClient
                .RequestAsync<PayoutMethod>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(payoutMethod);
            await apiClient.CreateAsync(AccountId, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/payout-methods",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = TestData.CreatePayoutMethodRequest();
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PayoutMethod>()
                .ThrowsAsync(exception);
            Func<Task<PayoutMethod>> action = async () => await apiClient.CreateAsync(AccountId, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = TestData.CreatePayoutMethodRequest();
            ryftApiClient
                .RequestAsync<PayoutMethod>()
                .ReturnsAsync(payoutMethod);
            var result = await apiClient.CreateAsync(AccountId, request);
            result.ShouldBe(payoutMethod);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PayoutMethod>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(payoutMethod);
            await apiClient.GetAsync(AccountId, payoutMethod.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/payout-methods/{payoutMethod.Id}",
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
                .RequestAsync<PayoutMethod>()
                .ThrowsAsync(exception);
            Func<Task<PayoutMethod>> action = async () => await apiClient.GetAsync(AccountId, payoutMethod.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<PayoutMethod>()
                .ReturnsAsync(payoutMethod);
            var result = await apiClient.GetAsync(AccountId, payoutMethod.Id);
            result.ShouldBe(payoutMethod);
        }

        [Fact]
        public async Task UpdateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new UpdatePayoutMethodRequest { DisplayName = "My new name" };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PayoutMethod>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(payoutMethod);
            await apiClient.UpdateAsync(AccountId, payoutMethod.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/payout-methods/{payoutMethod.Id}",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task UpdateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new UpdatePayoutMethodRequest { DisplayName = "My new name" };
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PayoutMethod>()
                .ThrowsAsync(exception);
            Func<Task<PayoutMethod>> action = async () => await apiClient.UpdateAsync(AccountId, payoutMethod.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new UpdatePayoutMethodRequest { DisplayName = "My new name" };
            ryftApiClient
                .RequestAsync<PayoutMethod>()
                .ReturnsAsync(payoutMethod);
            var result = await apiClient.UpdateAsync(AccountId, payoutMethod.Id, request);
            result.ShouldBe(payoutMethod);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<PayoutMethod>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<PayoutMethod>(new List<PayoutMethod>()));
            await apiClient.ListAsync(AccountId);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/payout-methods",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListPayoutMethodsRequest { Ascending = false, Limit = 10 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<PayoutMethod>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<PayoutMethod>(new List<PayoutMethod>()));
            await apiClient.ListAsync(AccountId, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/payout-methods{request.ToQueryString()}",
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
                .RequestAsync<PaginatedResponse<PayoutMethod>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<PayoutMethod>>> action = async () => await apiClient.ListAsync(AccountId);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<PayoutMethod>(new List<PayoutMethod>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<PayoutMethod>>()
                .ReturnsAsync(response);
            var result = await apiClient.ListAsync(AccountId);
            result.ShouldBe(response);
        }

        [Fact]
        public async Task DeleteAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<DeletedResource>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new DeletedResource(payoutMethod.Id));
            await apiClient.DeleteAsync(AccountId, payoutMethod.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/payout-methods/{payoutMethod.Id}",
                HttpMethod.Delete,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task DeleteAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<DeletedResource>().ThrowsAsync(exception);
            Func<Task<DeletedResource>> action = async () => await apiClient.DeleteAsync(AccountId, payoutMethod.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnResource_WhenSuccessful()
        {
            var deleted = new DeletedResource(payoutMethod.Id);
            ryftApiClient.RequestAsync<DeletedResource>().ReturnsAsync(deleted);
            var result = await apiClient.DeleteAsync(AccountId, payoutMethod.Id);
            result.ShouldBe(deleted);
        }
    }
}
