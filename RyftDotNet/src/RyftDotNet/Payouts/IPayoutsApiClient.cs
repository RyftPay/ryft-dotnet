using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Payouts.Request;

namespace RyftDotNet.Payouts
{
    public interface IPayoutsApiClient
    {
        Task<Payout> CreateAsync(
            string accountId,
            CreatePayoutRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Payout> GetAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<Payout>> ListAsync(
            string accountId,
            ListPayoutsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
