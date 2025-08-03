using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Disputes.Request;
using RyftDotNet.Utility;

namespace RyftDotNet.Disputes
{
    public sealed class DisputesApiClient : IDisputesApiClient
    {
        private const string ApiSuffix = "disputes";

        private readonly IRyftApiClient apiClient;

        public DisputesApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<Dispute> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Dispute>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Dispute> AcceptAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Dispute>(
                path: $"{ApiSuffix}/{id}/accept",
                HttpMethod.Post,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Dispute> AddEvidenceAsync(
            string id,
            AddEvidenceRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Dispute>(
                path: $"{ApiSuffix}/{id}/evidence",
                HttpMethodExtensions.Patch,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Dispute> RemoveEvidenceAsync(
            string id,
            RemoveEvidenceRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Dispute>(
                path: $"{ApiSuffix}/{id}/evidence",
                HttpMethod.Delete,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Dispute> ChallengeAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Dispute>(
                path: $"{ApiSuffix}/{id}/challenge",
                HttpMethod.Post,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<Dispute>> ListAsync(
            ListDisputesRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<Dispute>>(
                path: $"{ApiSuffix}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
