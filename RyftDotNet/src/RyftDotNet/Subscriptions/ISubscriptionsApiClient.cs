using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.PaymentSessions;
using RyftDotNet.Subscriptions.Request;

namespace RyftDotNet.Subscriptions
{
    public interface ISubscriptionsApiClient
    {
        Task<Subscription> CreateAsync(
            CreateSubscriptionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Subscription> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Subscription> UpdateAsync(
            string id,
            UpdateSubscriptionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Subscription> PauseAsync(
            string id,
            PauseSubscriptionRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Subscription> ResumeAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Subscription> CancelAsync(
            string id,
            CancelSubscriptionRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<Subscription>> ListAsync(
            ListSubscriptionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<PaymentSession>> ListPaymentSessionsAsync(
            string id,
            ListSubscriptionPaymentSessionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
