using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Transfers.Request;

namespace RyftDotNet.Transfers
{
    public interface ITransfersApiClient
    {
        Task<Transfer> CreateAsync(
            CreateTransferRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Transfer> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<Transfer>> ListAsync(
            ListTransfersRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
