using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Transfers.Request;

namespace RyftDotNet.Transfers
{
    public sealed class TransfersApiClient : ITransfersApiClient
    {
        private const string ApiSuffix = "transfers";

        private readonly IRyftApiClient apiClient;

        public TransfersApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<Transfer> CreateAsync(
            CreateTransferRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Transfer>(
                path: ApiSuffix,
                HttpMethod.Post,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Transfer> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Transfer>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<Transfer>> ListAsync(
            ListTransfersRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<Transfer>>(
                path: $"{ApiSuffix}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
