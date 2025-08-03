using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;

namespace RyftDotNet.ApplePay.Sessions
{
    public interface IApplePayWebSessionsApiClient
    {
        Task<ApplePayWebSession> CreateAsync(
            CreateApplePayWebSessionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
