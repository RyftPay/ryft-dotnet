using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Orders.Request;

namespace RyftDotNet.InPerson.Orders
{
    public interface IInPersonOrdersApiClient
    {
        Task<PaginatedResponse<InPersonOrder>> ListAsync(
            ListInPersonOrdersRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<InPersonOrder> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
