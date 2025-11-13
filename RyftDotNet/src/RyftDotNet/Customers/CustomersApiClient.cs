using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Customers.Request;
using RyftDotNet.PaymentMethods;
using RyftDotNet.Utility;

namespace RyftDotNet.Customers
{
    public sealed class CustomersApiClient : ICustomersApiClient
    {
        private const string ApiSuffix = "customers";

        private readonly IRyftApiClient apiClient;

        public CustomersApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<Customer> CreateAsync(
            CreateCustomerRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Customer>(
                path: ApiSuffix,
                HttpMethod.Post,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Customer> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Customer>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Customer> UpdateAsync(
            string id,
            UpdateCustomerRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Customer>(
                path: $"{ApiSuffix}/{id}",
                HttpMethodExtensions.Patch,
                request,
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

        public Task<PaginatedResponse<Customer>> ListAsync(
            ListCustomersRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<PaginatedResponse<Customer>>(
                path: $"{ApiSuffix}{request?.ToQueryString()}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<CustomerPaymentMethods> ListCustomerPaymentMethodsAsync(
            string customerId,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
        => apiClient.RequestAsync<CustomerPaymentMethods>(
                path: $"{ApiSuffix}/{customerId}/payment-methods",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
