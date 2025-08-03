using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Balances.Request;
using RyftDotNet.Client;

namespace RyftDotNet.Balances
{
    public interface IBalancesApiClient
    {
        Task<Balances> ListAsync(
            ListBalancesRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
