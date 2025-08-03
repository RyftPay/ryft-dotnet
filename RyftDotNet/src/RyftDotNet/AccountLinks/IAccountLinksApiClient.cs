using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.AccountLinks.Request;
using RyftDotNet.Client;

namespace RyftDotNet.AccountLinks
{
    public interface IAccountLinksApiClient
    {
        Task<AccountLink> CreateAsync(
            CreateAccountLinkRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
