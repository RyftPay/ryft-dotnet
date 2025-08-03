using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.PlatformFees.Request;

namespace RyftDotNet.PlatformFees
{
    public interface IPlatformFeesApiClient
    {
        Task<PlatformFee> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<PlatformFee>> ListAsync(
            ListPlatformFeesRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<PlatformFeeRefund>> ListRefundsAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
