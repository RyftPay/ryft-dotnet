using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Balances.Request;
using RyftDotNet.Client;

namespace RyftDotNet.Balances
{
    public sealed class BalancesApiClient : IBalancesApiClient
    {
        private const string ApiSuffix = "balances";

        private readonly IRyftApiClient apiClient;

        public BalancesApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<Balances> ListAsync(
            ListBalancesRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Balances>(
                path: $"{ApiSuffix}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
