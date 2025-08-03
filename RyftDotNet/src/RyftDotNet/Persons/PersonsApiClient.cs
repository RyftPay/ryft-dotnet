using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Persons.Request;
using RyftDotNet.Utility;

namespace RyftDotNet.Persons
{
    public sealed class PersonsApiClient : IPersonsApiClient
    {
        private const string ParentApiSuffix = "accounts";
        private const string ApiSuffix = "persons";

        private readonly IRyftApiClient apiClient;

        public PersonsApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<Person> CreateAsync(
            string accountId,
            CreatePersonRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Person>(
                path: $"{ResourcePath(accountId)}",
                HttpMethod.Post,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Person> GetAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Person>(
                path: $"{ResourcePath(accountId)}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Person> UpdateAsync(
            string accountId,
            string id,
            UpdatePersonRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Person>(
                path: $"{ResourcePath(accountId)}/{id}",
                HttpMethodExtensions.Patch,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<DeletedResource> DeleteAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<DeletedResource>(
                path: $"{ResourcePath(accountId)}/{id}",
                HttpMethod.Delete,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<Person>> ListAsync(
            string accountId,
            ListPersonsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<Person>>(
                path: $"{ResourcePath(accountId)}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        private static string ResourcePath(string accountId) =>
            string.Join("/", ParentApiSuffix, accountId, ApiSuffix);
    }
}
