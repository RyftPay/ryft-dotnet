using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.Utility;
using RyftDotNet.Webhooks;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Webhooks
{
    public sealed class WebhooksApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly WebhooksApiClient apiClient;

        private readonly WebhookCreated webhookCreated = TestData.WebhookCreated();
        private readonly Webhook webhook = TestData.Webhook();

        public WebhooksApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new WebhooksApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new CreateWebhookRequest(
                "https://ryftpay.com",
                true,
                new List<EventType> { EventType.PaymentSessionApproved }
            );
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<WebhookCreated>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(webhookCreated);
            await apiClient.CreateAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "webhooks",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new CreateWebhookRequest(
                "https://ryftpay.com",
                true,
                new List<EventType> { EventType.PaymentSessionApproved }
            );
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<WebhookCreated>().ThrowsAsync(exception);
            Func<Task<WebhookCreated>> action = async () => await apiClient.CreateAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new CreateWebhookRequest(
                "https://ryftpay.com",
                true,
                new List<EventType> { EventType.PaymentSessionApproved }
            );
            ryftApiClient.RequestAsync<WebhookCreated>().ReturnsAsync(webhookCreated);
            var result = await apiClient.CreateAsync(request);
            result.ShouldBe(webhookCreated);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Webhook>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(webhook);
            await apiClient.GetAsync(webhook.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"webhooks/{webhook.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Webhook>().ThrowsAsync(exception);
            Func<Task<Webhook>> action = async () => await apiClient.GetAsync(webhook.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Webhook>().ReturnsAsync(webhook);
            var result = await apiClient.GetAsync(webhook.Id);
            result.ShouldBe(webhook);
        }

        [Fact]
        public async Task UpdateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new UpdateWebhookRequest { Active = false };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Webhook>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(webhook);
            await apiClient.UpdateAsync(webhook.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"webhooks/{webhook.Id}",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task UpdateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new UpdateWebhookRequest { Active = false };
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Webhook>().ThrowsAsync(exception);
            Func<Task<Webhook>> action = async () => await apiClient.UpdateAsync(webhook.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new UpdateWebhookRequest { Active = false };
            ryftApiClient.RequestAsync<Webhook>().ReturnsAsync(webhook);
            var result = await apiClient.UpdateAsync(webhook.Id, request);
            result.ShouldBe(webhook);
        }

        [Fact]
        public async Task DeleteAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<DeletedResource>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new DeletedResource(webhook.Id));
            await apiClient.DeleteAsync(webhook.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"webhooks/{webhook.Id}",
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
            Func<Task<DeletedResource>> action = async () => await apiClient.DeleteAsync(webhook.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnResource_WhenSuccessful()
        {
            var deleted = new DeletedResource(webhook.Id);
            ryftApiClient.RequestAsync<DeletedResource>().ReturnsAsync(deleted);
            var result = await apiClient.DeleteAsync(webhook.Id);
            result.ShouldBe(deleted);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<Webhook>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Webhook>(
                    new List<Webhook> { webhook }
                ));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "webhooks",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<PaginatedResponse<Webhook>>().ThrowsAsync(exception);
            Func<Task<PaginatedResponse<Webhook>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<Webhook>(new List<Webhook>());
            ryftApiClient.RequestAsync<PaginatedResponse<Webhook>>().ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }
    }
}
