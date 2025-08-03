using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.PlatformFees;
using RyftDotNet.PlatformFees.Request;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PlatformFees
{
    public sealed class PlatformFeesApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly PlatformFeesApiClient apiClient;

        private readonly PlatformFee platformFee = TestData.PlatformFee();
        private readonly PlatformFeeRefund platformFeeRefund = TestData.PlatformFeeRefund();

        public PlatformFeesApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new PlatformFeesApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PlatformFee>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(platformFee);
            await apiClient.GetAsync(platformFee.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"platform-fees/{platformFee.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<PlatformFee>().ThrowsAsync(exception);
            Func<Task<PlatformFee>> action = async () => await apiClient.GetAsync(platformFee.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<PlatformFee>().ReturnsAsync(platformFee);
            var result = await apiClient.GetAsync(platformFee.Id);
            result.ShouldBe(platformFee);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<PlatformFee>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<PlatformFee>(new List<PlatformFee> { platformFee }));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "platform-fees",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListPlatformFeesRequest { Ascending = false, Limit = 10 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<PlatformFee>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<PlatformFee>(new List<PlatformFee> { platformFee }));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"platform-fees{request.ToQueryString()}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<PaginatedResponse<PlatformFee>>().ThrowsAsync(exception);
            Func<Task<PaginatedResponse<PlatformFee>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<PlatformFee>(new List<PlatformFee>());
            ryftApiClient.RequestAsync<PaginatedResponse<PlatformFee>>().ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }

        [Fact]
        public async Task ListRefundsAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<PlatformFeeRefund>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<PlatformFeeRefund>(
                    new List<PlatformFeeRefund> { platformFeeRefund }
                ));
            await apiClient.ListRefundsAsync(platformFee.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"platform-fees/{platformFee.Id}/refunds",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListRefundsAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<PaginatedResponse<PlatformFeeRefund>>().ThrowsAsync(exception);
            Func<Task<PaginatedResponse<PlatformFeeRefund>>> action = async () =>
                await apiClient.ListRefundsAsync(platformFee.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListRefundsAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<PlatformFeeRefund>(
                new List<PlatformFeeRefund> { platformFeeRefund }
            );
            ryftApiClient.RequestAsync<PaginatedResponse<PlatformFeeRefund>>().ReturnsAsync(response);
            var result = await apiClient.ListRefundsAsync(platformFee.Id);
            result.ShouldBe(response);
        }
    }
}
