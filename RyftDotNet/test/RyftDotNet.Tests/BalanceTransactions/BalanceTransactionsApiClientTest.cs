using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.BalanceTransactions;
using RyftDotNet.BalanceTransactions.Request;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.BalanceTransactions
{
    public sealed class BalanceTransactionsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly BalanceTransactionsApiClient apiClient;

        public BalanceTransactionsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new BalanceTransactionsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<BalanceTransaction>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<BalanceTransaction>(new List<BalanceTransaction>()));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "balance-transactions",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListBalanceTransactionsRequest { Limit = 5 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<BalanceTransaction>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<BalanceTransaction>(new List<BalanceTransaction>()));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"balance-transactions{request.ToQueryString()}",
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
                .RequestAsync<PaginatedResponse<BalanceTransaction>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<BalanceTransaction>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<BalanceTransaction>(new List<BalanceTransaction>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<BalanceTransaction>>()
                .ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }
    }
}
