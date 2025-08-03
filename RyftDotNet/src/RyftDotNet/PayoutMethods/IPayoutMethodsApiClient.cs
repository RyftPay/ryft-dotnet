using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.PayoutMethods.Request;

namespace RyftDotNet.PayoutMethods
{
    public interface IPayoutMethodsApiClient
    {
        Task<PayoutMethod> CreateAsync(
            string accountId,
            CreatePayoutMethodRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PayoutMethod> GetAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PayoutMethod> UpdateAsync(
            string accountId,
            string id,
            UpdatePayoutMethodRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<DeletedResource> DeleteAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<PayoutMethod>> ListAsync(
            string accountId,
            ListPayoutMethodsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
