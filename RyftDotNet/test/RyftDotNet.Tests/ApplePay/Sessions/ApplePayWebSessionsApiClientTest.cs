using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.ApplePay.Sessions;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.ApplePay.Sessions
{
    public sealed class ApplePayWebSessionsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly ApplePayWebSessionsApiClient apiClient;

        private readonly ApplePayWebSession applePayWebSession = TestData.ApplePayWebSession();

        public ApplePayWebSessionsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new ApplePayWebSessionsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new CreateApplePayWebSessionRequest("Ryft", "ryftpay.com");
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<ApplePayWebSession>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(applePayWebSession);
            await apiClient.CreateAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "apple-pay/sessions",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new CreateApplePayWebSessionRequest("Ryft", "ryftpay.com");
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<ApplePayWebSession>().ThrowsAsync(exception);
            Func<Task<ApplePayWebSession>> action = async () => await apiClient.CreateAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new CreateApplePayWebSessionRequest("Ryft", "ryftpay.com");
            ryftApiClient.RequestAsync<ApplePayWebSession>().ReturnsAsync(applePayWebSession);
            var result = await apiClient.CreateAsync(request);
            result.ShouldBe(applePayWebSession);
        }
    }
}
