using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.Transfers;
using RyftDotNet.Transfers.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Transfers
{
    public sealed class TransfersApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly TransfersApiClient apiClient;

        private readonly Transfer transfer = TestData.Transfer();

        public TransfersApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new TransfersApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            var request = TestData.CreateTransferRequest();
            ryftApiClient
                .RequestAsync<Transfer>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(transfer);
            await apiClient.CreateAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "transfers",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = TestData.CreateTransferRequest();
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Transfer>()
                .ThrowsAsync(exception);
            Func<Task<Transfer>> action = async () => await apiClient.CreateAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = TestData.CreateTransferRequest();
            ryftApiClient
                .RequestAsync<Transfer>()
                .ReturnsAsync(transfer);
            var result = await apiClient.CreateAsync(request);
            result.ShouldBe(transfer);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Transfer>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(transfer);
            await apiClient.GetAsync(transfer.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"transfers/{transfer.Id}",
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
                .RequestAsync<Transfer>()
                .ThrowsAsync(exception);
            Func<Task<Transfer>> action = async () => await apiClient.GetAsync(transfer.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<Transfer>()
                .ReturnsAsync(transfer);
            var result = await apiClient.GetAsync(transfer.Id);
            result.ShouldBe(transfer);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<Transfer>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Transfer>(new List<Transfer>()));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "transfers",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListTransfersRequest { Ascending = false, Limit = 10 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<Transfer>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Transfer>(new List<Transfer>()));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"transfers{request.ToQueryString()}",
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
                .RequestAsync<PaginatedResponse<Transfer>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<Transfer>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<Transfer>(new List<Transfer>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<Transfer>>()
                .ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }
    }
}
