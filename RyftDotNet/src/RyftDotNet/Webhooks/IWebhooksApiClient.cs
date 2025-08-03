using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;

namespace RyftDotNet.Webhooks
{
    public interface IWebhooksApiClient
    {
        Task<WebhookCreated> CreateAsync(
            CreateWebhookRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Webhook> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Webhook> UpdateAsync(
            string id,
            UpdateWebhookRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<DeletedResource> DeleteAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<Webhook>> ListAsync(
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
