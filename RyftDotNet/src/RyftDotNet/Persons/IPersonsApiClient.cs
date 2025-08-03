using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Persons.Request;

namespace RyftDotNet.Persons
{
    public interface IPersonsApiClient
    {
        Task<Person> CreateAsync(
            string accountId,
            CreatePersonRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Person> GetAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Person> UpdateAsync(
            string accountId,
            string id,
            UpdatePersonRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<DeletedResource> DeleteAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<Person>> ListAsync(
            string accountId,
            ListPersonsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
