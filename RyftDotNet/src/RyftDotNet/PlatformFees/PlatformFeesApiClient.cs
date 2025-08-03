using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.PlatformFees.Request;

namespace RyftDotNet.PlatformFees
{
    public sealed class PlatformFeesApiClient : IPlatformFeesApiClient
    {
        private const string ApiSuffix = "platform-fees";

        private readonly IRyftApiClient apiClient;

        public PlatformFeesApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<PlatformFee> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PlatformFee>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<PlatformFee>> ListAsync(
            ListPlatformFeesRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<PlatformFee>>(
                path: $"{ApiSuffix}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<PlatformFeeRefund>> ListRefundsAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<PlatformFeeRefund>>(
                path: $"{ApiSuffix}/{id}/refunds",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
