using System.Threading;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Common;
using RyftDotNet.Conversions.Request;

namespace RyftDotNet.Conversions
{
    public interface IConversionApiClient
    {
        Task<Conversion> CreateAsync(
            string accountId,
            CreateConversionRequest request,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<Conversion> GetAsync(
            string accountId,
            string id,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<PaginatedResponse<Conversion>> ListAsync(
            ListConversionsRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);

        Task<ConversionRate> GetRates(
            GetRateRequest? request = null,
            ClientRequestSettings? requestSettings = null,
            CancellationToken cancellationToken = default);
    }
}
