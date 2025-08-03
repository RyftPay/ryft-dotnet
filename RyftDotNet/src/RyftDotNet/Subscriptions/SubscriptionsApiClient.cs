using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.PaymentSessions;
using RyftDotNet.Subscriptions.Request;
using RyftDotNet.Utility;

namespace RyftDotNet.Subscriptions
{
    public sealed class SubscriptionsApiClient : ISubscriptionsApiClient
    {
        private const string ApiSuffix = "subscriptions";

        private readonly IRyftApiClient apiClient;

        public SubscriptionsApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<Subscription> CreateAsync(
            CreateSubscriptionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Subscription>(
                path: ApiSuffix,
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Subscription> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Subscription>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Subscription> UpdateAsync(
            string id,
            UpdateSubscriptionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Subscription>(
                path: $"{ApiSuffix}/{id}",
                HttpMethodExtensions.Patch,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Subscription> PauseAsync(
            string id,
            PauseSubscriptionRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Subscription>(
                path: $"{ApiSuffix}/{id}/pause",
                HttpMethodExtensions.Patch,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Subscription> ResumeAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Subscription>(
                path: $"{ApiSuffix}/{id}/resume",
                HttpMethodExtensions.Patch,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Subscription> CancelAsync(
            string id,
            CancelSubscriptionRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Subscription>(
                path: $"{ApiSuffix}/{id}/cancel",
                HttpMethod.Delete,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<Subscription>> ListAsync(
            ListSubscriptionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<Subscription>>(
                path: $"{ApiSuffix}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<PaymentSession>> ListPaymentSessionsAsync(
            string id,
            ListSubscriptionPaymentSessionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<PaymentSession>>(
                path: $"{ApiSuffix}/{id}/payment-sessions{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

    }
}
