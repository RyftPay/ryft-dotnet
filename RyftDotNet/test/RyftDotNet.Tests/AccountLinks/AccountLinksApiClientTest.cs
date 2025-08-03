using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.AccountLinks;
using RyftDotNet.AccountLinks.Request;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.AccountLinks
{
    public sealed class AccountLinksApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly AccountLinksApiClient apiClient;

        private readonly AccountLink accountLink = TestData.AccountLink();

        public AccountLinksApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new AccountLinksApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            var request = new CreateAccountLinkRequest(TestData.AccountId, "https://ryftpay.com");
            ryftApiClient
                .RequestAsync<AccountLink>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(accountLink);
            await apiClient.CreateAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "account-links",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new CreateAccountLinkRequest(TestData.AccountId, "https://ryftpay.com");
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<AccountLink>().ThrowsAsync(exception);
            Func<Task<AccountLink>> action = async () => await apiClient.CreateAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new CreateAccountLinkRequest(TestData.AccountId, "https://ryftpay.com");
            ryftApiClient.RequestAsync<AccountLink>().ReturnsAsync(accountLink);
            var result = await apiClient.CreateAsync(request);
            result.ShouldBe(accountLink);
        }
    }
}
