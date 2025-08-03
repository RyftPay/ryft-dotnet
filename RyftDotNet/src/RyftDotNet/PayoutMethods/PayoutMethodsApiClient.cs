using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.PayoutMethods.Request;
using RyftDotNet.Utility;

namespace RyftDotNet.PayoutMethods
{
    public sealed class PayoutMethodsApiClient : IPayoutMethodsApiClient
    {
        private const string ParentApiSuffix = "accounts";
        private const string ApiSuffix = "payout-methods";

        private readonly IRyftApiClient apiClient;

        public PayoutMethodsApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<PayoutMethod> CreateAsync(
            string accountId,
            CreatePayoutMethodRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PayoutMethod>(
                path: $"{ResourcePath(accountId)}",
                HttpMethod.Post,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PayoutMethod> GetAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PayoutMethod>(
                path: $"{ResourcePath(accountId)}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PayoutMethod> UpdateAsync(
            string accountId,
            string id,
            UpdatePayoutMethodRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PayoutMethod>(
                path: $"{ResourcePath(accountId)}/{id}",
                HttpMethodExtensions.Patch,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<DeletedResource> DeleteAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<DeletedResource>(
                path: $"{ResourcePath(accountId)}/{id}",
                HttpMethod.Delete,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<PayoutMethod>> ListAsync(
            string accountId,
            ListPayoutMethodsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<PayoutMethod>>(
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
