using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.PaymentMethods;
using RyftDotNet.PaymentMethods.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentMethods
{
    public sealed class PaymentMethodsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly PaymentMethodsApiClient apiClient;

        private readonly PaymentMethod paymentMethod = TestData.PaymentMethod();

        public PaymentMethodsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new PaymentMethodsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaymentMethod>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paymentMethod);
            await apiClient.GetAsync(paymentMethod.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-methods/{paymentMethod.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<PaymentMethod>().ThrowsAsync(exception);
            Func<Task<PaymentMethod>> action = async () => await apiClient.GetAsync(paymentMethod.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<PaymentMethod>().ReturnsAsync(paymentMethod);
            var result = await apiClient.GetAsync(paymentMethod.Id);
            result.ShouldBe(paymentMethod);
        }

        [Fact]
        public async Task UpdateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new UpdatePaymentMethodRequest { BillingAddress = TestData.AddressRequest() };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaymentMethod>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paymentMethod);
            await apiClient.UpdateAsync(paymentMethod.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-methods/{paymentMethod.Id}",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task UpdateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new UpdatePaymentMethodRequest { BillingAddress = TestData.AddressRequest() };
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<PaymentMethod>().ThrowsAsync(exception);
            Func<Task<PaymentMethod>> action = async () => await apiClient.UpdateAsync(paymentMethod.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new UpdatePaymentMethodRequest { BillingAddress = TestData.AddressRequest() };
            ryftApiClient.RequestAsync<PaymentMethod>().ReturnsAsync(paymentMethod);
            var result = await apiClient.UpdateAsync(paymentMethod.Id, request);
            result.ShouldBe(paymentMethod);
        }

        [Fact]
        public async Task DeleteAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<DeletedResource>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new DeletedResource(paymentMethod.Id));
            await apiClient.DeleteAsync(paymentMethod.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"payment-methods/{paymentMethod.Id}",
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
            Func<Task<DeletedResource>> action = async () => await apiClient.DeleteAsync(paymentMethod.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnResource_WhenSuccessful()
        {
            var deleted = new DeletedResource(paymentMethod.Id);
            ryftApiClient.RequestAsync<DeletedResource>().ReturnsAsync(deleted);
            var result = await apiClient.DeleteAsync(paymentMethod.Id);
            result.ShouldBe(deleted);
        }
    }
}
