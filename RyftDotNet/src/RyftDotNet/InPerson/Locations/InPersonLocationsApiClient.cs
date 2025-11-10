using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Locations.Request;
using RyftDotNet.Utility;

namespace RyftDotNet.InPerson.Locations
{
    public sealed class InPersonLocationsApiClient : IInPersonLocationsApiClient
    {
        private const string ApiSuffix = "in-person/locations";

        private readonly IRyftApiClient apiClient;

        public InPersonLocationsApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<InPersonLocation> CreateAsync(
            CreateInPersonLocationRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<InPersonLocation>(
                path: ApiSuffix,
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<InPersonLocation>> ListAsync(
            ListInPersonLocationsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<InPersonLocation>>(
                path: $"{ApiSuffix}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<InPersonLocation> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<InPersonLocation>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<InPersonLocation> UpdateAsync(
            string id,
            UpdateInPersonLocationRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<InPersonLocation>(
                path: $"{ApiSuffix}/{id}",
                HttpMethodExtensions.Patch,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<InPersonLocationDeleted> DeleteAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<InPersonLocationDeleted>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Delete,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}