using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Customers.Request;
using RyftDotNet.PaymentMethods;

namespace RyftDotNet.Customers
{
    public interface ICustomersApiClient
    {
        Task<Customer> CreateAsync(
            CreateCustomerRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Customer> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Customer> UpdateAsync(
            string id,
            UpdateCustomerRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<DeletedResource> DeleteAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<Customer>> ListAsync(
            ListCustomersRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<CustomerPaymentMethods> ListCustomerPaymentMethodsAsync(
            string customerId,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
