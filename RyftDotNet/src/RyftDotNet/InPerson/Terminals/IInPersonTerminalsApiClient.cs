using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.InPerson.Terminals.Request;

namespace RyftDotNet.InPerson.Terminals
{
    public interface IInPersonTerminalsApiClient
    {
        Task<Terminal> CreateAsync(
            CreateTerminalRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<Terminal>> ListAsync(
            ListTerminalsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Terminal> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Terminal> UpdateAsync(
            string id,
            UpdateTerminalRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<TerminalDeleted> DeleteAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Terminal> InitiatePaymentAsync(
            string id,
            TerminalPaymentRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Terminal> InitiateRefundAsync(
            string id,
            TerminalRefundRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Terminal> CancelActionAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Terminal> ConfirmReceiptAsync(
            string id,
            TerminalConfirmReceiptRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}