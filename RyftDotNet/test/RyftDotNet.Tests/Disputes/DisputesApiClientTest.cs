using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.Disputes;
using RyftDotNet.Disputes.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Disputes
{
    public sealed class DisputesApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly DisputesApiClient apiClient;

        private readonly Dispute dispute = TestData.Dispute();

        public DisputesApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new DisputesApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Dispute>()
                .ThrowsAsync(exception);
            Func<Task<Dispute>> action = async () => await apiClient.GetAsync(dispute.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<Dispute>()
                .ReturnsAsync(dispute);
            var result = await apiClient.GetAsync(dispute.Id);
            result.ShouldBe(dispute);
        }

        [Fact]
        public async Task AcceptAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Dispute>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(dispute);
            await apiClient.AcceptAsync(dispute.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"disputes/{dispute.Id}/accept",
                HttpMethod.Post,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task AcceptAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Dispute>()
                .ThrowsAsync(exception);
            Func<Task<Dispute>> action = async () => await apiClient.AcceptAsync(dispute.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task AcceptAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<Dispute>()
                .ReturnsAsync(dispute);
            var result = await apiClient.AcceptAsync(dispute.Id);
            result.ShouldBe(dispute);
        }

        [Fact]
        public async Task AddEvidenceAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new AddEvidenceRequest { Text = new DisputeEvidenceTextRequest { Uncategorised = "Example" } };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Dispute>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(dispute);
            await apiClient.AddEvidenceAsync(dispute.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"disputes/{dispute.Id}/evidence",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task AddEvidenceAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new AddEvidenceRequest { Text = new DisputeEvidenceTextRequest { Uncategorised = "Example" } };
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Dispute>()
                .ThrowsAsync(exception);
            Func<Task<Dispute>> action = async () => await apiClient.AddEvidenceAsync(dispute.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task AddEvidenceAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new AddEvidenceRequest { Text = new DisputeEvidenceTextRequest { Uncategorised = "Example" } };
            ryftApiClient
                .RequestAsync<Dispute>()
                .ReturnsAsync(dispute);
            var result = await apiClient.AddEvidenceAsync(dispute.Id, request);
            result.ShouldBe(dispute);
        }

        [Fact]
        public async Task RemoveEvidenceAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new RemoveEvidenceRequest
            {
                Text = new List<DisputeEvidenceTextIdentifier> { DisputeEvidenceTextIdentifier.ShippingAddress }
            };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Dispute>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(dispute);
            await apiClient.RemoveEvidenceAsync(dispute.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"disputes/{dispute.Id}/evidence",
                HttpMethod.Delete,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task RemoveEvidenceAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new RemoveEvidenceRequest
            {
                Text = new List<DisputeEvidenceTextIdentifier> { DisputeEvidenceTextIdentifier.ShippingAddress }
            };
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Dispute>()
                .ThrowsAsync(exception);
            Func<Task<Dispute>> action = async () => await apiClient.RemoveEvidenceAsync(dispute.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task RemoveEvidenceAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new RemoveEvidenceRequest
            {
                Text = new List<DisputeEvidenceTextIdentifier> { DisputeEvidenceTextIdentifier.ShippingAddress }
            };
            ryftApiClient
                .RequestAsync<Dispute>()
                .ReturnsAsync(dispute);
            var result = await apiClient.RemoveEvidenceAsync(dispute.Id, request);
            result.ShouldBe(dispute);
        }

        [Fact]
        public async Task ChallengeAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Dispute>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(dispute);
            await apiClient.ChallengeAsync(dispute.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"disputes/{dispute.Id}/challenge",
                HttpMethod.Post,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ChallengeAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Dispute>()
                .ThrowsAsync(exception);
            Func<Task<Dispute>> action = async () => await apiClient.ChallengeAsync(dispute.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ChallengeAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<Dispute>()
                .ReturnsAsync(dispute);
            var result = await apiClient.ChallengeAsync(dispute.Id);
            result.ShouldBe(dispute);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<Dispute>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Dispute>(new List<Dispute>()));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "disputes",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListDisputesRequest { Ascending = false, Limit = 10 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<Dispute>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Dispute>(new List<Dispute>()));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"disputes{request.ToQueryString()}",
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
                .RequestAsync<PaginatedResponse<Dispute>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<Dispute>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<Dispute>(new List<Dispute>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<Dispute>>()
                .ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }
    }
}
