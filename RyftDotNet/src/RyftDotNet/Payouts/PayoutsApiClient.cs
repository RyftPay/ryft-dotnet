using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Payouts.Request;

namespace RyftDotNet.Payouts
{
    public sealed class PayoutsApiClient : IPayoutsApiClient
    {
        private const string ParentApiSuffix = "accounts";
        private const string ApiSuffix = "payouts";

        private readonly IRyftApiClient apiClient;

        public PayoutsApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<Payout> CreateAsync(
            string accountId,
            CreatePayoutRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Payout>(
                path: $"{ResourcePath(accountId)}",
                HttpMethod.Post,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Payout> GetAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Payout>(
                path: $"{ResourcePath(accountId)}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<Payout>> ListAsync(
            string accountId,
            ListPayoutsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<Payout>>(
                path: $"{ResourcePath(accountId)}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        private static string ResourcePath(string accountId) =>
            string.Join("/", ParentApiSuffix, accountId, ApiSuffix);
    }
}
