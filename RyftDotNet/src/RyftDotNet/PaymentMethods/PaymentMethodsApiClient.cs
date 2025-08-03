using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.PaymentMethods.Request;
using RyftDotNet.Utility;

namespace RyftDotNet.PaymentMethods
{
    public sealed class PaymentMethodsApiClient : IPaymentMethodsApiClient
    {
        private const string ApiSuffix = "payment-methods";

        private readonly IRyftApiClient apiClient;

        public PaymentMethodsApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<PaymentMethod> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaymentMethod>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<PaymentMethod> UpdateAsync(
            string id,
            UpdatePaymentMethodRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaymentMethod>(
                path: $"{ApiSuffix}/{id}",
                HttpMethodExtensions.Patch,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<DeletedResource> DeleteAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<DeletedResource>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Delete,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
