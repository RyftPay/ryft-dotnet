using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Products.Request;

namespace RyftDotNet.InPerson.Products
{
    public interface IInPersonProductsApiClient
    {
        Task<PaginatedResponse<InPersonProduct>> ListAsync(
            ListInPersonProductsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<InPersonProduct> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
