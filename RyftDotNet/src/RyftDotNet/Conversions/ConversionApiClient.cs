using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Conversions.Request;

namespace RyftDotNet.Conversions
{
    public sealed class ConversionApiClient : IConversionApiClient
    {
        private const string MoneyMovementApiSuffix = "conversions";

        private readonly IRyftApiClient apiClient;

        public ConversionApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<Conversion> CreateAsync(
            string accountId,
            CreateConversionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Conversion>(
                path: $"{ResourcePath()}",
                HttpMethod.Post,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Conversion> GetAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Conversion>(
                path: $"{ResourcePath()}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<Conversion>> ListAsync(
            ListConversionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<Conversion>>(
                path: $"{ResourcePath()}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<ConversionRate> GetRates(
            GetRateRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<ConversionRate>(
                path: $"{ResourcePath()}/rate{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        private static string ResourcePath() =>
            string.Join("/", MoneyMovementApiSuffix);
    }
}
