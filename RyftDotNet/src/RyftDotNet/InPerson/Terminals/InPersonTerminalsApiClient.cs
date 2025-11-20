using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Terminals.Request;
using RyftDotNet.Utility;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class InPersonTerminalsApiClient : IInPersonTerminalsApiClient
    {
        private const string ApiSuffix = "in-person/terminals";

        private readonly IRyftApiClient apiClient;

        public InPersonTerminalsApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<Terminal> CreateAsync(
            CreateTerminalRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Terminal>(
                path: ApiSuffix,
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<Terminal>> ListAsync(
            ListTerminalsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<Terminal>>(
                path: $"{ApiSuffix}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Terminal> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Terminal>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Terminal> UpdateAsync(
            string id,
            UpdateTerminalRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Terminal>(
                path: $"{ApiSuffix}/{id}",
                HttpMethodExtensions.Patch,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<TerminalDeleted> DeleteAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<TerminalDeleted>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Delete,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Terminal> InitiatePaymentAsync(
            string id,
            TerminalPaymentRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Terminal>(
                path: $"{ApiSuffix}/{id}/payment",
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Terminal> InitiateRefundAsync(
            string id,
            TerminalRefundRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Terminal>(
                path: $"{ApiSuffix}/{id}/refund",
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Terminal> CancelActionAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Terminal>(
                path: $"{ApiSuffix}/{id}/cancel-action",
                HttpMethod.Post,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Terminal> ConfirmReceiptAsync(
            string id,
            TerminalConfirmReceiptRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Terminal>(
                path: $"{ApiSuffix}/{id}/confirm-receipt",
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
