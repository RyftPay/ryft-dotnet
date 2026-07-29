using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.Conversions;
using RyftDotNet.Conversions.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Conversions
{
    public sealed class ConversionApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly ConversionApiClient apiClient;

        private readonly Conversion conversion = TestData.Conversion();
        private readonly ConversionRate conversionRate = TestData.ConversionRate();

        public ConversionApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new ConversionApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new CreateConversionRequest(
                new ConversionSideRequest("GBP") { Amount = 1000 },
                new ConversionSideRequest("USD"),
                termAgreement: true
            );
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Conversion>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(conversion);
            await apiClient.CreateAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "conversions",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new CreateConversionRequest(
                new ConversionSideRequest("GBP") { Amount = 1000 },
                new ConversionSideRequest("USD"),
                termAgreement: true
            );
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Conversion>().ThrowsAsync(exception);
            Func<Task<Conversion>> action = async () => await apiClient.CreateAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new CreateConversionRequest(
                new ConversionSideRequest("GBP") { Amount = 1000 },
                new ConversionSideRequest("USD"),
                termAgreement: true
            );
            ryftApiClient.RequestAsync<Conversion>().ReturnsAsync(conversion);
            var result = await apiClient.CreateAsync(request);
            result.ShouldBe(conversion);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Conversion>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(conversion);
            await apiClient.GetAsync(conversion.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"conversions/{conversion.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Conversion>().ThrowsAsync(exception);
            Func<Task<Conversion>> action = async () => await apiClient.GetAsync(conversion.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Conversion>().ReturnsAsync(conversion);
            var result = await apiClient.GetAsync(conversion.Id);
            result.ShouldBe(conversion);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<Conversion>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Conversion>(new List<Conversion> { conversion }));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "conversions",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListConversionsRequest { Ascending = false, Limit = 10 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<Conversion>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Conversion>(new List<Conversion> { conversion }));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"conversions{request.ToQueryString()}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<PaginatedResponse<Conversion>>().ThrowsAsync(exception);
            Func<Task<PaginatedResponse<Conversion>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<Conversion>(new List<Conversion> { conversion });
            ryftApiClient.RequestAsync<PaginatedResponse<Conversion>>().ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }

        [Fact]
        public async Task GetRatesAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<ConversionRate>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(conversionRate);
            await apiClient.GetRatesAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "conversions/rate",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetRatesAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new GetRateRequest { BuyCurrency = "USD", SellCurrency = "GBP", Amount = 1000 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<ConversionRate>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(conversionRate);
            await apiClient.GetRatesAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"conversions/rate{request.ToQueryString()}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetRatesAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<ConversionRate>().ThrowsAsync(exception);
            Func<Task<ConversionRate>> action = async () => await apiClient.GetRatesAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetRatesAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<ConversionRate>().ReturnsAsync(conversionRate);
            var result = await apiClient.GetRatesAsync();
            result.ShouldBe(conversionRate);
        }
    }
}
