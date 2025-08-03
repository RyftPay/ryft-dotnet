using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.PaymentSessions.PaymentTransactions;
using RyftDotNet.PaymentSessions.Request;

namespace RyftDotNet.PaymentSessions
{
    public interface IPaymentSessionsApiClient
    {
        Task<PaymentSession> CreateAsync(
            CreatePaymentSessionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaymentSession> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaymentSession> UpdateAsync(
            string id,
            UpdatePaymentSessionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaymentSession> AttemptPaymentAsync(
            AttemptPaymentRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaymentSession> ContinuePaymentAsync(
            ContinuePaymentRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaymentTransaction> VoidAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaymentTransaction> CaptureAsync(
            string id,
            CaptureRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaymentTransaction> RefundAsync(
            string id,
            RefundRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaymentTransaction> GetTransactionAsync(
            string id,
            string transactionId,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<PaymentSession>> ListAsync(
            ListPaymentSessionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<PaymentTransaction>> ListTransactionsAsync(
            string id,
            ListPaymentTransactionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
