using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Accounts.Request;
using RyftDotNet.Client;

namespace RyftDotNet.Accounts
{
    public interface IAccountsApiClient
    {
        Task<Account> CreateAsync(
            CreateAccountRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Account> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Account> UpdateAsync(
            string id,
            UpdateAccountRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Account> VerifyAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<AccountAuthLink> CreateAuthLinkAsync(
            CreateAccountAuthorizeLinkRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
