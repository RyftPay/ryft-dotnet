using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.AccountLinks.Request;
using RyftDotNet.Client;

namespace RyftDotNet.AccountLinks
{
    public sealed class AccountLinksApiClient : IAccountLinksApiClient
    {
        private const string ApiSuffix = "account-links";

        private readonly IRyftApiClient apiClient;

        public AccountLinksApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<AccountLink> CreateAsync(
            CreateAccountLinkRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<AccountLink>(
                path: ApiSuffix,
                HttpMethod.Post,
                request,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
