using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Accounts.Request;
using RyftDotNet.Client;
using RyftDotNet.Utility;

namespace RyftDotNet.Accounts
{
    public sealed class AccountsApiClient : IAccountsApiClient
    {
        private const string ApiSuffix = "accounts";

        private readonly IRyftApiClient apiClient;

        public AccountsApiClient(IRyftApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public Task<Account> CreateAsync(
            CreateAccountRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Account>(
                path: ApiSuffix,
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Account> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Account>(
                path: $"{ApiSuffix}/{id}",
                HttpMethod.Get,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );

        public Task<Account> UpdateAsync(
            string id,
            UpdateAccountRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Account>(
                path: $"{ApiSuffix}/{id}",
                HttpMethodExtensions.Patch,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );


        public Task<Account> VerifyAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<Account>(
                path: $"{ApiSuffix}/{id}/verify",
                HttpMethod.Post,
                requestBody: null,
                requestSettings,
                cancellationToken: cancellationToken
            );


        public Task<AccountAuthLink> CreateAuthLinkAsync(
            CreateAccountAuthorizeLinkRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default)
            => apiClient.RequestAsync<AccountAuthLink>(
                path: $"{ApiSuffix}/authorize",
                HttpMethod.Post,
                requestBody: request,
                requestSettings,
                cancellationToken: cancellationToken
            );
    }
}
