using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Skus.Request;

namespace RyftDotNet.InPerson.Skus
{
    public sealed class InPersonSkusApiClient : IInPersonSkusApiClient
    {
        private const string ApiSuffix = "in-person/skus";

        private readonly IRyftApiClient apiClient;

        public InPersonSkusApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<PaginatedResponse<InPersonProductSku>> ListAsync(
            ListInPersonSkusRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<InPersonProductSku>>(
                path: $"{ApiSuffix}{request.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<InPersonProductSku> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<InPersonProductSku>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
