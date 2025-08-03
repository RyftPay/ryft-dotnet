using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.BalanceTransactions.Request;
using RyftDotNet.Client;
using RyftDotNet.Common;

namespace RyftDotNet.BalanceTransactions
{
    public interface IBalanceTransactionsApiClient
    {
        Task<PaginatedResponse<BalanceTransaction>> ListAsync(
            ListBalanceTransactionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
