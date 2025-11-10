using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Locations.Request;

namespace RyftDotNet.InPerson.Locations
{
    public interface IInPersonLocationsApiClient
    {
        Task<InPersonLocation> CreateAsync(
            CreateInPersonLocationRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<InPersonLocation>> ListAsync(
            ListInPersonLocationsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<InPersonLocation> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<InPersonLocation> UpdateAsync(
            string id,
            UpdateInPersonLocationRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<InPersonLocationDeleted> DeleteAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}