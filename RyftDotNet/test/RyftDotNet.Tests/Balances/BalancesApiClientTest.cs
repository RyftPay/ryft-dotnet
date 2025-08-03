using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Balances;
using RyftDotNet.Balances.Request;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Balances
{
    public sealed class BalancesApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly BalancesApiClient apiClient;

        public BalancesApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new BalancesApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<RyftDotNet.Balances.Balances>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new RyftDotNet.Balances.Balances(new List<Balance>()));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "balances",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListBalancesRequest { Currency = new[] { "GBP", "EUR" } };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<RyftDotNet.Balances.Balances>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new RyftDotNet.Balances.Balances(new List<Balance>()));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"balances{request.ToQueryString()}",
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
                .RequestAsync<RyftDotNet.Balances.Balances>()
                .ThrowsAsync(exception);
            Func<Task<RyftDotNet.Balances.Balances>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new RyftDotNet.Balances.Balances(new List<Balance>());
            ryftApiClient
                .RequestAsync<RyftDotNet.Balances.Balances>()
                .ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }
    }
}
