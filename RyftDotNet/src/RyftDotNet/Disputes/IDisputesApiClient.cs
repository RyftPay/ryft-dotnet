using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Disputes.Request;

namespace RyftDotNet.Disputes
{
    public interface IDisputesApiClient
    {
        Task<Dispute> GetAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Dispute> AcceptAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Dispute> AddEvidenceAsync(
            string id,
            AddEvidenceRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Dispute> RemoveEvidenceAsync(
            string id,
            RemoveEvidenceRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Dispute> ChallengeAsync(
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<Dispute>> ListAsync(
            ListDisputesRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
