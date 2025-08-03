using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Files.Request;

namespace RyftDotNet.Files
{
    public sealed class FilesApiClient : IFilesApiClient
    {
        private const string ApiSuffix = "files";

        private readonly IRyftApiClient apiClient;

        public FilesApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<File> CreateAsync(
            CreateFileRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.PostMultipartFormDataAsync<File>(
                ApiSuffix,
                request.ToMultipartFormDataContent(),
                requestSettings,
                HttpStatusCode.OK,
                cancellationToken
            );

        public Task<File> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<File>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<File>> ListAsync(
            ListFilesRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<File>>(
                path: $"{ApiSuffix}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
