using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;

namespace RyftDotNet.ApplePay.WebDomains
{
    public interface IApplePayWebDomainsApiClient
    {
        Task<ApplePayWebDomain> CreateAsync(
            CreateApplePayWebDomainRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<ApplePayWebDomain> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<DeletedResource> DeleteAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<ApplePayWebDomain>> ListAsync(
            ListApplePayWebDomainsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
