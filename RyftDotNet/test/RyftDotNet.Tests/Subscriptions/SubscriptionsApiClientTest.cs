using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.PaymentSessions;
using RyftDotNet.Subscriptions;
using RyftDotNet.Subscriptions.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Subscriptions
{
    public sealed class SubscriptionsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly SubscriptionsApiClient apiClient;

        private readonly Subscription subscription = TestData.Subscription();

        public SubscriptionsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new SubscriptionsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = TestData.CreateSubscriptionRequest();
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Subscription>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(subscription);
            await apiClient.CreateAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "subscriptions",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = TestData.CreateSubscriptionRequest();
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Subscription>().ThrowsAsync(exception);
            Func<Task<Subscription>> action = async () => await apiClient.CreateAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = TestData.CreateSubscriptionRequest();
            ryftApiClient.RequestAsync<Subscription>().ReturnsAsync(subscription);
            var result = await apiClient.CreateAsync(request);
            result.ShouldBe(subscription);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Subscription>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(subscription);
            await apiClient.GetAsync(subscription.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"subscriptions/{subscription.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Subscription>().ThrowsAsync(exception);
            Func<Task<Subscription>> action = async () => await apiClient.GetAsync(subscription.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Subscription>().ReturnsAsync(subscription);
            var result = await apiClient.GetAsync(subscription.Id);
            result.ShouldBe(subscription);
        }

        [Fact]
        public async Task UpdateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new UpdateSubscriptionRequest { Description = "Some new description" };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Subscription>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(subscription);
            await apiClient.UpdateAsync(subscription.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"subscriptions/{subscription.Id}",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task UpdateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new UpdateSubscriptionRequest { Description = "Some new description" };
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Subscription>().ThrowsAsync(exception);
            Func<Task<Subscription>> action = async () => await apiClient.UpdateAsync(subscription.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new UpdateSubscriptionRequest { Description = "Some new description" };
            ryftApiClient.RequestAsync<Subscription>().ReturnsAsync(subscription);
            var result = await apiClient.UpdateAsync(subscription.Id, request);
            result.ShouldBe(subscription);
        }

        [Fact]
        public async Task PauseAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Subscription>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(subscription);
            await apiClient.PauseAsync(subscription.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"subscriptions/{subscription.Id}/pause",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task PauseAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Subscription>().ThrowsAsync(exception);
            Func<Task<Subscription>> action = async () => await apiClient.PauseAsync(subscription.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task PauseAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Subscription>().ReturnsAsync(subscription);
            var result = await apiClient.PauseAsync(subscription.Id);
            result.ShouldBe(subscription);
        }

        [Fact]
        public async Task ResumeAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Subscription>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(subscription);
            await apiClient.ResumeAsync(subscription.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"subscriptions/{subscription.Id}/resume",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ResumeAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Subscription>().ThrowsAsync(exception);
            Func<Task<Subscription>> action = async () => await apiClient.ResumeAsync(subscription.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ResumeAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Subscription>().ReturnsAsync(subscription);
            var result = await apiClient.ResumeAsync(subscription.Id);
            result.ShouldBe(subscription);
        }

        [Fact]
        public async Task CancelAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Subscription>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(subscription);
            await apiClient.CancelAsync(subscription.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"subscriptions/{subscription.Id}/cancel",
                HttpMethod.Delete,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task CancelAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Subscription>().ThrowsAsync(exception);
            Func<Task<Subscription>> action = async () => await apiClient.CancelAsync(subscription.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CancelAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Subscription>().ReturnsAsync(subscription);
            var result = await apiClient.CancelAsync(subscription.Id);
            result.ShouldBe(subscription);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<Subscription>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Subscription>(new List<Subscription>()));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "subscriptions",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListSubscriptionsRequest
            {
                Ascending = false,
                Limit = 10,
                StartsAfter = subscription.Id
            };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<Subscription>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Subscription>(new List<Subscription>()));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"subscriptions{request.ToQueryString()}",
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
                .RequestAsync<PaginatedResponse<Subscription>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<Subscription>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<Subscription>(new List<Subscription>());
            ryftApiClient.RequestAsync<PaginatedResponse<Subscription>>().ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }

        [Fact]
        public async Task ListPaymentSessionsAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<PaymentSession>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<PaymentSession>(new List<PaymentSession>()));
            await apiClient.ListPaymentSessionsAsync(subscription.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"subscriptions/{subscription.Id}/payment-sessions",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListPaymentSessionsAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListSubscriptionPaymentSessionsRequest
            {
                Ascending = false,
                Limit = 10,
                StartsAfter = subscription.Id
            };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<PaymentSession>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<PaymentSession>(new List<PaymentSession>()));
            await apiClient.ListPaymentSessionsAsync(subscription.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"subscriptions/{subscription.Id}/payment-sessions{request.ToQueryString()}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListPaymentSessionsAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaginatedResponse<PaymentSession>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<PaymentSession>>> action = async () =>
                await apiClient.ListPaymentSessionsAsync(subscription.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListPaymentSessionsAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<PaymentSession>(new List<PaymentSession>());
            ryftApiClient.RequestAsync<PaginatedResponse<PaymentSession>>().ReturnsAsync(response);
            var result = await apiClient.ListPaymentSessionsAsync(subscription.Id);
            result.ShouldBe(response);
        }
    }
}
