using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Skus.Request;

namespace RyftDotNet.InPerson.Skus
{
    public interface IInPersonSkusApiClient
    {
        Task<PaginatedResponse<InPersonProductSku>> ListAsync(
            ListInPersonSkusRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<InPersonProductSku> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
