using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;

namespace RyftDotNet.ApplePay.Sessions
{
    public sealed class ApplePayWebSessionsApiClient : IApplePayWebSessionsApiClient
    {
        private const string ApiSuffix = "apple-pay/sessions";

        private readonly IRyftApiClient apiClient;

        public ApplePayWebSessionsApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<ApplePayWebSession> CreateAsync(
            CreateApplePayWebSessionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<ApplePayWebSession>(
                path: ApiSuffix,
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
