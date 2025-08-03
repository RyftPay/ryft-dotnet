using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RyftDotNet.Client
{
    public interface IRyftApiClient
    {
        Task<T> RequestAsync<T>(
            string path,
            HttpMethod httpMethod,
            object? requestBody = null,
            ClientRequestSettings? requestSettings = null,
            HttpStatusCode expectedStatus = HttpStatusCode.OK,
            CancellationToken cancellationToken = default) where T : class;

        Task<T> PostMultipartFormDataAsync<T>(
            string path,
            MultipartFormDataContent formData,
            ClientRequestSettings? requestSettings = null,
            HttpStatusCode expectedStatus = HttpStatusCode.OK,
            CancellationToken cancellationToken = default) where T : class;
    }
}
