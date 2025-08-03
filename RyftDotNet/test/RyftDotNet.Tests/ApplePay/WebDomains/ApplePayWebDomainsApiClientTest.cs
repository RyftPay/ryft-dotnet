using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.ApplePay.WebDomains;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.ApplePay.WebDomains
{
    public sealed class ApplePayWebDomainsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly ApplePayWebDomainsApiClient apiClient;

        private readonly ApplePayWebDomain applePayWebDomain = TestData.ApplePayWebDomain();

        public ApplePayWebDomainsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new ApplePayWebDomainsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new CreateApplePayWebDomainRequest("ryftpay.com");
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<ApplePayWebDomain>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(applePayWebDomain);
            await apiClient.CreateAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "apple-pay/web-domains",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new CreateApplePayWebDomainRequest("ryftpay.com");
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<ApplePayWebDomain>().ThrowsAsync(exception);
            Func<Task<ApplePayWebDomain>> action = async () => await apiClient.CreateAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new CreateApplePayWebDomainRequest("ryftpay.com");
            ryftApiClient.RequestAsync<ApplePayWebDomain>().ReturnsAsync(applePayWebDomain);
            var result = await apiClient.CreateAsync(request);
            result.ShouldBe(applePayWebDomain);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<ApplePayWebDomain>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(applePayWebDomain);
            await apiClient.GetAsync(applePayWebDomain.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"apple-pay/web-domains/{applePayWebDomain.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<ApplePayWebDomain>().ThrowsAsync(exception);
            Func<Task<ApplePayWebDomain>> action = async () => await apiClient.GetAsync(applePayWebDomain.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<ApplePayWebDomain>().ReturnsAsync(applePayWebDomain);
            var result = await apiClient.GetAsync(applePayWebDomain.Id);
            result.ShouldBe(applePayWebDomain);
        }

        [Fact]
        public async Task DeleteAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<DeletedResource>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new DeletedResource(applePayWebDomain.Id));
            await apiClient.DeleteAsync(applePayWebDomain.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"apple-pay/web-domains/{applePayWebDomain.Id}",
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
            Func<Task<DeletedResource>> action = async () => await apiClient.DeleteAsync(applePayWebDomain.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnResource_WhenSuccessful()
        {
            var deleted = new DeletedResource(applePayWebDomain.Id);
            ryftApiClient.RequestAsync<DeletedResource>().ReturnsAsync(deleted);
            var result = await apiClient.DeleteAsync(applePayWebDomain.Id);
            result.ShouldBe(deleted);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<ApplePayWebDomain>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<ApplePayWebDomain>(
                    new List<ApplePayWebDomain> { applePayWebDomain }
                ));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "apple-pay/web-domains",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListApplePayWebDomainsRequest
            {
                Ascending = false,
                Limit = 10,
                StartsAfter = applePayWebDomain.Id
            };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<ApplePayWebDomain>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<ApplePayWebDomain>(
                    new List<ApplePayWebDomain> { applePayWebDomain }
                ));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"apple-pay/web-domains{request.ToQueryString()}",
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
                .RequestAsync<PaginatedResponse<ApplePayWebDomain>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<ApplePayWebDomain>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<ApplePayWebDomain>(new List<ApplePayWebDomain> { applePayWebDomain });
            ryftApiClient.RequestAsync<PaginatedResponse<ApplePayWebDomain>>().ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }
    }
}
