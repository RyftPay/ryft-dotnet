using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Accounts;
using RyftDotNet.Accounts.Request;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Accounts
{
    public sealed class AccountsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly AccountsApiClient apiClient;

        private readonly Account account = TestData.Account();

        public AccountsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new AccountsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            var request = new CreateAccountRequest { OnboardingFlow = OnboardingFlow.NonHosted };
            ryftApiClient
                .RequestAsync<Account>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(account);
            await apiClient.CreateAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "accounts",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new CreateAccountRequest { OnboardingFlow = OnboardingFlow.NonHosted };
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Account>()
                .ThrowsAsync(exception);
            Func<Task<Account>> action = async () => await apiClient.CreateAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new CreateAccountRequest { OnboardingFlow = OnboardingFlow.NonHosted };
            ryftApiClient
                .RequestAsync<Account>()
                .ReturnsAsync(account);
            var result = await apiClient.CreateAsync(request);
            result.ShouldBe(account);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Account>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(account);
            await apiClient.GetAsync(account.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{account.Id}",
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
                .RequestAsync<Account>()
                .ThrowsAsync(exception);
            Func<Task<Account>> action = async () => await apiClient.GetAsync(account.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<Account>()
                .ReturnsAsync(account);
            var result = await apiClient.GetAsync(account.Id);
            result.ShouldBe(account);
        }

        [Fact]
        public async Task UpdateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            var request = new UpdateAccountRequest
            {
                Metadata = new Dictionary<string, string> { ["example"] = Guid.NewGuid().ToString() }
            };
            ryftApiClient
                .RequestAsync<Account>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(account);
            await apiClient.UpdateAsync(account.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{account.Id}",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task UpdateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new UpdateAccountRequest
            {
                Metadata = new Dictionary<string, string> { ["example"] = Guid.NewGuid().ToString() }
            };
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Account>()
                .ThrowsAsync(exception);
            Func<Task<Account>> action = async () => await apiClient.UpdateAsync(account.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new UpdateAccountRequest
            {
                Metadata = new Dictionary<string, string> { ["example"] = Guid.NewGuid().ToString() }
            };
            ryftApiClient
                .RequestAsync<Account>()
                .ReturnsAsync(account);
            var result = await apiClient.UpdateAsync(account.Id, request);
            result.ShouldBe(account);
        }

        [Fact]
        public async Task VerifyAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Account>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(account);
            await apiClient.VerifyAsync(account.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{account.Id}/verify",
                HttpMethod.Post,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task VerifyAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Account>()
                .ThrowsAsync(exception);
            Func<Task<Account>> action = async () => await apiClient.VerifyAsync(account.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task VerifyAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<Account>()
                .ReturnsAsync(account);
            var result = await apiClient.VerifyAsync(account.Id);
            result.ShouldBe(account);
        }

        [Fact]
        public async Task CreateAuthLinkAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            var link = new AccountAuthLink(
                DateTimeOffset.UtcNow,
                DateTimeOffset.UtcNow.AddDays(2),
                "https://localhost/my-site"
            );
            var request = new CreateAccountAuthorizeLinkRequest(
                "test@ryftpay.com",
                "https://ryftpay.com"
            );
            ryftApiClient
                .RequestAsync<AccountAuthLink>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(link);
            await apiClient.CreateAuthLinkAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "accounts/authorize",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAuthLinkAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new CreateAccountAuthorizeLinkRequest(
                "test@ryftpay.com",
                "https://ryftpay.com"
            );
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<AccountAuthLink>()
                .ThrowsAsync(exception);
            Func<Task<AccountAuthLink>> action = async () => await apiClient.CreateAuthLinkAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAuthLinkAsync_ShouldReturnResource_WhenSuccessful()
        {
            var link = new AccountAuthLink(
                DateTimeOffset.UtcNow,
                DateTimeOffset.UtcNow.AddDays(2),
                "https://localhost/my-site"
            );
            var request = new CreateAccountAuthorizeLinkRequest(
                "test@ryftpay.com",
                "https://ryftpay.com"
            );
            ryftApiClient
                .RequestAsync<AccountAuthLink>()
                .ReturnsAsync(link);
            var result = await apiClient.CreateAuthLinkAsync(request);
            result.ShouldBe(link);
        }
    }
}
