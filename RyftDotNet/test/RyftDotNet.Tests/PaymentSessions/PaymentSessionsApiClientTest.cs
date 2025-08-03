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
using RyftDotNet.PaymentSessions.PaymentTransactions;
using RyftDotNet.PaymentSessions.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class PaymentSessionsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly PaymentSessionsApiClient apiClient;

        private readonly PaymentSession paymentSession = TestData.PaymentSession();
        private readonly PaymentTransaction paymentTransaction = TestData.PaymentTransaction();

        public PaymentSessionsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new PaymentSessionsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            var request = new CreatePaymentSessionRequest(250, "GBP");
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paymentSession);
            await apiClient.CreateAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "payment-sessions",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new CreatePaymentSessionRequest(500, "EUR");
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .ThrowsAsync(exception);
            Func<Task<PaymentSession>> action = async () => await apiClient.CreateAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new CreatePaymentSessionRequest(1000, "EUR");
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .ReturnsAsync(paymentSession);
            var result = await apiClient.CreateAsync(request);
            result.ShouldBe(paymentSession);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paymentSession);
            await apiClient.GetAsync(paymentSession.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-sessions/{paymentSession.Id}",
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
                .RequestAsync<PaymentSession>()
                .ThrowsAsync(exception);
            Func<Task<PaymentSession>> action = async () => await apiClient.GetAsync(paymentSession.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .ReturnsAsync(paymentSession);
            var result = await apiClient.GetAsync(paymentSession.Id);
            result.ShouldBe(paymentSession);
        }

        [Fact]
        public async Task UpdateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new UpdatePaymentSessionRequest { Amount = 1250 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paymentSession);
            await apiClient.UpdateAsync(paymentSession.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-sessions/{paymentSession.Id}",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task UpdateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new UpdatePaymentSessionRequest { Amount = 500 };
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .ThrowsAsync(exception);
            Func<Task<PaymentSession>> action = async () => await apiClient.UpdateAsync(paymentSession.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new UpdatePaymentSessionRequest { Amount = 750 };
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .ReturnsAsync(paymentSession);
            var result = await apiClient.UpdateAsync(paymentSession.Id, request);
            result.ShouldBe(paymentSession);
        }

        [Fact]
        public async Task AttemptPaymentAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new AttemptPaymentRequest(TestData.ClientSecret) { CardDetails = TestData.CardDetailsRequest() };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paymentSession);
            await apiClient.AttemptPaymentAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "payment-sessions/attempt-payment",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task AttemptPaymentAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new AttemptPaymentRequest(TestData.ClientSecret) { CardDetails = TestData.CardDetailsRequest() };
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .ThrowsAsync(exception);
            Func<Task<PaymentSession>> action = async () => await apiClient.AttemptPaymentAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task AttemptPaymentAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new AttemptPaymentRequest(TestData.ClientSecret) { CardDetails = TestData.CardDetailsRequest() };
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .ReturnsAsync(paymentSession);
            var result = await apiClient.AttemptPaymentAsync(request);
            result.ShouldBe(paymentSession);
        }

        [Fact]
        public async Task ContinuePaymentAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new ContinuePaymentRequest(
                TestData.ClientSecret,
                new ContinuePaymentThreeDsRequest { Fingerprint = TestData.ThreeDsFingerprint }
            );
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paymentSession);
            await apiClient.ContinuePaymentAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "payment-sessions/continue-payment",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task ContinuePaymentAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new ContinuePaymentRequest(
                TestData.ClientSecret,
                new ContinuePaymentThreeDsRequest { Fingerprint = TestData.ThreeDsFingerprint }
            );
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .ThrowsAsync(exception);
            Func<Task<PaymentSession>> action = async () => await apiClient.ContinuePaymentAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ContinuePaymentAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new ContinuePaymentRequest(
                TestData.ClientSecret,
                new ContinuePaymentThreeDsRequest { Fingerprint = TestData.ThreeDsFingerprint }
            );
            ryftApiClient
                .RequestAsync<PaymentSession>()
                .ReturnsAsync(paymentSession);
            var result = await apiClient.ContinuePaymentAsync(request);
            result.ShouldBe(paymentSession);
        }

        [Fact]
        public async Task VoidAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paymentTransaction);
            await apiClient.VoidAsync(paymentSession.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-sessions/{paymentSession.Id}/voids",
                HttpMethod.Post,
                HttpStatusCode.Accepted,
                null
            ));
        }

        [Fact]
        public async Task VoidAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .ThrowsAsync(exception);
            Func<Task<PaymentTransaction>> action = async () => await apiClient.VoidAsync(paymentSession.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task VoidAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .ReturnsAsync(paymentTransaction);
            var result = await apiClient.VoidAsync(paymentSession.Id);
            result.ShouldBe(paymentTransaction);
        }

        [Fact]
        public async Task CaptureAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new CaptureRequest { Amount = 50, CaptureType = CaptureType.NotFinal };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paymentTransaction);
            await apiClient.CaptureAsync(paymentSession.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-sessions/{paymentSession.Id}/captures",
                HttpMethod.Post,
                HttpStatusCode.Accepted,
                request
            ));
        }

        [Fact]
        public async Task CaptureAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new CaptureRequest { Amount = 50, CaptureType = CaptureType.NotFinal };
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .ThrowsAsync(exception);
            Func<Task<PaymentTransaction>> action = async () => await apiClient.CaptureAsync(paymentSession.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CaptureAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new CaptureRequest { Amount = 50, CaptureType = CaptureType.NotFinal };
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .ReturnsAsync(paymentTransaction);
            var result = await apiClient.CaptureAsync(paymentSession.Id, request);
            result.ShouldBe(paymentTransaction);
        }

        [Fact]
        public async Task RefundAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new RefundRequest { Amount = 50 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paymentTransaction);
            await apiClient.RefundAsync(paymentSession.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-sessions/{paymentSession.Id}/refunds",
                HttpMethod.Post,
                HttpStatusCode.Accepted,
                request
            ));
        }

        [Fact]
        public async Task RefundAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new RefundRequest { Amount = 50 };
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .ThrowsAsync(exception);
            Func<Task<PaymentTransaction>> action = async () => await apiClient.RefundAsync(paymentSession.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task RefundAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new RefundRequest { Amount = 50 };
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .ReturnsAsync(paymentTransaction);
            var result = await apiClient.RefundAsync(paymentSession.Id, request);
            result.ShouldBe(paymentTransaction);
        }

        [Fact]
        public async Task GetTransactionAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paymentTransaction);
            await apiClient.GetTransactionAsync(
                paymentSession.Id,
                paymentTransaction.Id
            );
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-sessions/{paymentSession.Id}/transactions/{paymentTransaction.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetTransactionAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .ThrowsAsync(exception);
            Func<Task<PaymentTransaction>> action = async () => await apiClient.GetTransactionAsync(
                paymentSession.Id,
                paymentTransaction.Id
            );
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetTransactionAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<PaymentTransaction>()
                .ReturnsAsync(paymentTransaction);
            var result = await apiClient.GetTransactionAsync(
                paymentSession.Id,
                paymentTransaction.Id
            );
            result.ShouldBe(paymentTransaction);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<PaymentSession>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<PaymentSession>(new List<PaymentSession>()));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "payment-sessions",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListPaymentSessionsRequest
            {
                Ascending = false,
                Limit = 10
            };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<PaymentSession>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<PaymentSession>(new List<PaymentSession>()));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-sessions{request.ToQueryString()}",
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
                .RequestAsync<PaginatedResponse<PaymentSession>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<PaymentSession>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<PaymentSession>(new List<PaymentSession>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<PaymentSession>>()
                .ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }

        [Fact]
        public async Task ListTransactionsAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<PaymentTransaction>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<PaymentTransaction>(new List<PaymentTransaction>()));
            await apiClient.ListTransactionsAsync(paymentSession.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-sessions/{paymentSession.Id}/transactions",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListTransactionsAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListPaymentTransactionsRequest
            {
                Ascending = false,
                Limit = 10
            };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<PaymentTransaction>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<PaymentTransaction>(new List<PaymentTransaction>()));
            await apiClient.ListTransactionsAsync(paymentSession.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-sessions/{paymentSession.Id}/transactions{request.ToQueryString()}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListTransactionsAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaginatedResponse<PaymentTransaction>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<PaymentTransaction>>> action = async () =>
                await apiClient.ListTransactionsAsync(paymentSession.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListTransactionsAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<PaymentTransaction>(new List<PaymentTransaction>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<PaymentTransaction>>()
                .ReturnsAsync(response);
            var result = await apiClient.ListTransactionsAsync(paymentSession.Id);
            result.ShouldBe(response);
        }
    }
}
