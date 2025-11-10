using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Terminals;
using RyftDotNet.InPerson.Terminals.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.InPerson.Terminals
{
    public sealed class InPersonTerminalsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly InPersonTerminalsApiClient apiClient;

        private readonly Terminal terminal = TestData.Terminal();
        private readonly CreateTerminalRequest createRequest = TestData.CreateTerminalRequest();
        private readonly TerminalPaymentRequest paymentRequest = TestData.TerminalPaymentRequest();
        private readonly TerminalRefundRequest refundRequest = TestData.TerminalRefundRequest();

        public InPersonTerminalsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new InPersonTerminalsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Terminal>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(terminal);
            await apiClient.CreateAsync(createRequest);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "in-person/terminals",
                HttpMethod.Post,
                HttpStatusCode.OK,
                createRequest
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Terminal>().ThrowsAsync(exception);
            Func<Task<Terminal>> action = async () => await apiClient.CreateAsync(createRequest);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Terminal>().ReturnsAsync(terminal);
            var result = await apiClient.CreateAsync(createRequest);
            result.ShouldBe(terminal);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new ListTerminalsRequest { Limit = 10, Ascending = true };
            ExpectedRequestArguments? arguments = null;
            var paginatedResponse = new PaginatedResponse<Terminal>(new List<Terminal>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<Terminal>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(paginatedResponse);
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "in-person/terminals?ascending=true&limit=10",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var paginatedResponse = new PaginatedResponse<Terminal>(new List<Terminal>());
            ryftApiClient.RequestAsync<PaginatedResponse<Terminal>>().ReturnsAsync(paginatedResponse);
            var result = await apiClient.ListAsync();
            result.ShouldBe(paginatedResponse);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Terminal>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(terminal);
            await apiClient.GetAsync(terminal.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/terminals/{terminal.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Terminal>().ReturnsAsync(terminal);
            var result = await apiClient.GetAsync(terminal.Id);
            result.ShouldBe(terminal);
        }

        [Fact]
        public async Task UpdateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var updateRequest = new UpdateTerminalRequest { Name = "Updated Terminal" };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Terminal>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(terminal);
            await apiClient.UpdateAsync(terminal.Id, updateRequest);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/terminals/{terminal.Id}",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                updateRequest
            ));
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var updateRequest = new UpdateTerminalRequest { Name = "Updated Terminal" };
            ryftApiClient.RequestAsync<Terminal>().ReturnsAsync(terminal);
            var result = await apiClient.UpdateAsync(terminal.Id, updateRequest);
            result.ShouldBe(terminal);
        }

        [Fact]
        public async Task DeleteAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            var deleted = new TerminalDeleted(terminal.Id);
            ryftApiClient
                .RequestAsync<TerminalDeleted>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(deleted);
            await apiClient.DeleteAsync(terminal.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/terminals/{terminal.Id}",
                HttpMethod.Delete,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnResource_WhenSuccessful()
        {
            var deleted = new TerminalDeleted(terminal.Id);
            ryftApiClient.RequestAsync<TerminalDeleted>().ReturnsAsync(deleted);
            var result = await apiClient.DeleteAsync(terminal.Id);
            result.ShouldBe(deleted);
        }

        [Fact]
        public async Task InitiatePaymentAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Terminal>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(terminal);
            await apiClient.InitiatePaymentAsync(terminal.Id, paymentRequest);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/terminals/{terminal.Id}/payment",
                HttpMethod.Post,
                HttpStatusCode.OK,
                paymentRequest
            ));
        }

        [Fact]
        public async Task InitiatePaymentAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Terminal>().ThrowsAsync(exception);
            Func<Task<Terminal>> action = async () => await apiClient.InitiatePaymentAsync(terminal.Id, paymentRequest);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task InitiatePaymentAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Terminal>().ReturnsAsync(terminal);
            var result = await apiClient.InitiatePaymentAsync(terminal.Id, paymentRequest);
            result.ShouldBe(terminal);
        }

        [Fact]
        public async Task InitiateRefundAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Terminal>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(terminal);
            await apiClient.InitiateRefundAsync(terminal.Id, refundRequest);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/terminals/{terminal.Id}/refund",
                HttpMethod.Post,
                HttpStatusCode.OK,
                refundRequest
            ));
        }

        [Fact]
        public async Task InitiateRefundAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Terminal>().ThrowsAsync(exception);
            Func<Task<Terminal>> action = async () => await apiClient.InitiateRefundAsync(terminal.Id, refundRequest);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task InitiateRefundAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Terminal>().ReturnsAsync(terminal);
            var result = await apiClient.InitiateRefundAsync(terminal.Id, refundRequest);
            result.ShouldBe(terminal);
        }

        [Fact]
        public async Task CancelActionAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Terminal>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(terminal);
            await apiClient.CancelActionAsync(terminal.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/terminals/{terminal.Id}/cancel-action",
                HttpMethod.Post,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task CancelActionAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Terminal>().ThrowsAsync(exception);
            Func<Task<Terminal>> action = async () => await apiClient.CancelActionAsync(terminal.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CancelActionAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Terminal>().ReturnsAsync(terminal);
            var result = await apiClient.CancelActionAsync(terminal.Id);
            result.ShouldBe(terminal);
        }

        [Fact]
        public async Task ConfirmReceiptAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var confirmRequest = new TerminalConfirmReceiptRequest { CustomerCopy = true, MerchantCopy = false };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Terminal>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(terminal);
            await apiClient.ConfirmReceiptAsync(terminal.Id, confirmRequest);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"in-person/terminals/{terminal.Id}/confirm-receipt",
                HttpMethod.Post,
                HttpStatusCode.OK,
                confirmRequest
            ));
        }

        [Fact]
        public async Task ConfirmReceiptAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            var confirmRequest = new TerminalConfirmReceiptRequest { CustomerCopy = true };
            ryftApiClient.RequestAsync<Terminal>().ThrowsAsync(exception);
            Func<Task<Terminal>> action = async () => await apiClient.ConfirmReceiptAsync(terminal.Id, confirmRequest);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ConfirmReceiptAsync_ShouldReturnResource_WhenSuccessful()
        {
            var confirmRequest = new TerminalConfirmReceiptRequest { CustomerCopy = true };
            ryftApiClient.RequestAsync<Terminal>().ReturnsAsync(terminal);
            var result = await apiClient.ConfirmReceiptAsync(terminal.Id, confirmRequest);
            result.ShouldBe(terminal);
        }
    }
}
