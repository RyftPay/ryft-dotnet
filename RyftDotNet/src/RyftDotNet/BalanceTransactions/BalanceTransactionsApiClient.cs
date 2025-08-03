using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.BalanceTransactions.Request;
using RyftDotNet.Client;
using RyftDotNet.Common;

namespace RyftDotNet.BalanceTransactions
{
    public sealed class BalanceTransactionsApiClient : IBalanceTransactionsApiClient
    {
        private const string ApiSuffix = "balance-transactions";

        private readonly IRyftApiClient apiClient;

        public BalanceTransactionsApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<PaginatedResponse<BalanceTransaction>> ListAsync(
            ListBalanceTransactionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<BalanceTransaction>>(
                path: $"{ApiSuffix}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
