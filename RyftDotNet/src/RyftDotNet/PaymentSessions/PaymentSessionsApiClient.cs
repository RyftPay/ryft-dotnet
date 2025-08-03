using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.PaymentSessions.PaymentTransactions;
using RyftDotNet.PaymentSessions.Request;
using RyftDotNet.Utility;

namespace RyftDotNet.PaymentSessions
{
    public sealed class PaymentSessionsApiClient : IPaymentSessionsApiClient
    {
        private const string ApiSuffix = "payment-sessions";

        private readonly IRyftApiClient apiClient;

        public PaymentSessionsApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<PaymentSession> CreateAsync(
            CreatePaymentSessionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaymentSession>(
                path: ApiSuffix,
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaymentSession> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaymentSession>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaymentSession> UpdateAsync(
            string id,
            UpdatePaymentSessionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaymentSession>(
                path: $"{ApiSuffix}/{id}",
                HttpMethodExtensions.Patch,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaymentSession> AttemptPaymentAsync(
            AttemptPaymentRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaymentSession>(
                path: $"{ApiSuffix}/attempt-payment",
                HttpMethod.Post,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaymentSession> ContinuePaymentAsync(
            ContinuePaymentRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaymentSession>(
                path: $"{ApiSuffix}/continue-payment",
                HttpMethod.Post,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaymentTransaction> VoidAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaymentTransaction>(
                path: $"{ApiSuffix}/{id}/voids",
                HttpMethod.Post,
                requestBody: null,
                requestSettings,
                HttpStatusCode.Accepted,
                cancellationToken: cancellationToken
            );

        public Task<PaymentTransaction> CaptureAsync(
            string id,
            CaptureRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaymentTransaction>(
                path: $"{ApiSuffix}/{id}/captures",
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                HttpStatusCode.Accepted,
                cancellationToken
            );

        public Task<PaymentTransaction> RefundAsync(
            string id,
            RefundRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaymentTransaction>(
                path: $"{ApiSuffix}/{id}/refunds",
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                HttpStatusCode.Accepted,
                cancellationToken
            );

        public Task<PaymentTransaction> GetTransactionAsync(
            string id,
            string transactionId,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaymentTransaction>(
                path: $"{ApiSuffix}/{id}/transactions/{transactionId}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<PaymentSession>> ListAsync(
            ListPaymentSessionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<PaymentSession>>(
                path: $"{ApiSuffix}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaginatedResponse<PaymentTransaction>> ListTransactionsAsync(
            string id,
            ListPaymentTransactionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<PaymentTransaction>>(
                path: $"{ApiSuffix}/{id}/transactions{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
