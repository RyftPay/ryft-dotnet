using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.PaymentMethods.Request;

namespace RyftDotNet.PaymentMethods
{
    public interface IPaymentMethodsApiClient
    {
        Task<PaymentMethod> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaymentMethod> UpdateAsync(
            string id,
            UpdatePaymentMethodRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<DeletedResource> DeleteAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
