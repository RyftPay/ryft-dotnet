using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client.Error;
using RyftDotNet.Utility;

namespace RyftDotNet.Client
{
    public sealed class RyftApiClient : IRyftApiClient
    {
        private const string ContentType = "application/json";
        private const string AuthorizationHeader = "Authorization";
        private const string AccountHeader = "Account";
        private const int DefaultTimeoutInSeconds = 25;

        private static readonly Lazy<HttpClient> DefaultHttpClient
            = new Lazy<HttpClient>(CreateDefaultHttpClient);

        private readonly HttpClient httpClient;
        private readonly ClientRequestSettings? clientRequestSettings;

        public RyftApiClient(
            HttpClient? httpClient = null,
            ClientRequestSettings? requestSettings = null)
        {
            this.httpClient = httpClient ?? DefaultHttpClient.Value;
            this.clientRequestSettings = requestSettings;
        }

        public RyftApiClient(
            IHttpClientFactory httpClientFactory,
            ClientRequestSettings? requestSettings = null)
        {
            this.httpClient = httpClientFactory.CreateClient();
            this.clientRequestSettings = requestSettings;
        }

        public Task<T> RequestAsync<T>(
            string path,
            HttpMethod httpMethod,
            object? requestBody = null,
            ClientRequestSettings? requestSettings = null,
            HttpStatusCode expectedStatus = HttpStatusCode.OK,
            CancellationToken cancellationToken = default) where T : class
        {
            var content = requestBody == null
                ? null
                : new StringContent(
                    JsonUtility.Serialize(requestBody),
                    Encoding.UTF8,
                    ContentType
                );
            return ExecuteRequestAsync<T>(
                path,
                httpMethod,
                content,
                requestSettings,
                expectedStatus,
                cancellationToken
            );
        }

        public Task<T> PostMultipartFormDataAsync<T>(
            string path,
            MultipartFormDataContent formData,
            ClientRequestSettings? requestSettings = null,
            HttpStatusCode expectedStatus = HttpStatusCode.OK,
            CancellationToken cancellationToken = default) where T : class
            => ExecuteRequestAsync<T>(
                path,
                HttpMethod.Post,
                formData,
                requestSettings,
                expectedStatus,
                cancellationToken
            );

        private async Task<T> ExecuteRequestAsync<T>(
            string path,
            HttpMethod httpMethod,
            HttpContent? content,
            ClientRequestSettings? requestSettings = null,
            HttpStatusCode expectedStatus = HttpStatusCode.OK,
            CancellationToken cancellationToken = default) where T : class
        {
            (string? requestUri, string? secretApiKey, string? accountId) =
                DetermineRequestParams(path, requestSettings);
            HttpResponseMessage response;
            try
            {
                using var requestMessage = new HttpRequestMessage(httpMethod, requestUri);
                requestMessage.Headers.UserAgent.ParseAdd($"{Constants.UserAgentPrefix}{Constants.Version}");
                requestMessage.AddHeader(AuthorizationHeader, secretApiKey);
                requestMessage.AddHeader(AccountHeader, accountId);
                requestMessage.Content = content;
                response = await httpClient.SendAsync(requestMessage, cancellationToken);
            }
            catch (Exception e)
            {
                throw new RyftApiException(e.Message, e);
            }
            return await response.ParseResponse<T>(expectedStatus);
        }

        private (string requestUri, string secretApiKey, string? accountId) DetermineRequestParams(
            string path,
            ClientRequestSettings? requestSettings)
        {
            string? secretApiKey = requestSettings?.ApiKey ?? clientRequestSettings?.ApiKey;
            string? accountId = requestSettings?.AccountId ?? clientRequestSettings?.AccountId;
            if (string.IsNullOrWhiteSpace(secretApiKey))
            {
                throw new RyftArgumentException("Your API key is missing or invalid");
            }

            if (!accountId?.IsValidAccountId() ?? false)
            {
                throw new RyftArgumentException(
                    $"The supplied account ID of '{accountId}' is invalid. " +
                    "Note that Ryft account identifiers should be structured as follows:" +
                    " - prefix: ac" +
                    " - suffix: GUID" +
                    "For example: ac_3fe8398f-8cdb-43a3-9be2-806c4f84c327"
                );
            }
            var baseUri = Utilities.DetermineBaseUri(
                clientRequestSettings,
                requestSettings,
                secretApiKey!
            );
            string version = Utilities.DetermineApiVersion(
                clientRequestSettings,
                requestSettings
            );
            string requestUri = $"{baseUri}{version}/{path}";
            return (requestUri, secretApiKey!, accountId);
        }

        private static HttpClient CreateDefaultHttpClient()
            => new HttpClient { Timeout = TimeSpan.FromSeconds(DefaultTimeoutInSeconds) };
    }
}
