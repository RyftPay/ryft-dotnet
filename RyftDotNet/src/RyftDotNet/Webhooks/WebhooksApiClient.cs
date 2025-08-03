using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Utility;

namespace RyftDotNet.Webhooks
{
    public sealed class WebhooksApiClient : IWebhooksApiClient
    {
        private const string ApiSuffix = "webhooks";

        private readonly IRyftApiClient apiClient;

        public WebhooksApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<WebhookCreated> CreateAsync(
            CreateWebhookRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<WebhookCreated>(
                path: ApiSuffix,
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Webhook> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Webhook>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Webhook> UpdateAsync(
            string id,
            UpdateWebhookRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Webhook>(
                path: $"{ApiSuffix}/{id}",
                HttpMethodExtensions.Patch,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<DeletedResource> DeleteAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<DeletedResource>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Delete,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<Webhook>> ListAsync(
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<Webhook>>(
                path: ApiSuffix,
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
