using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using RyftDotNet.Client.Error;
using RyftDotNet.Utility;

namespace RyftDotNet.Client
{
    internal static class HttpResponseMessageExtensions
    {
        internal static async Task<T> ParseResponse<T>(
            this HttpResponseMessage responseMessage,
            HttpStatusCode expectedStatusCode) where T : class
        {
            string responseBodyRaw = await responseMessage.BodyAsString();
            bool bodyIsBlank = string.IsNullOrWhiteSpace(responseBodyRaw);
            if (responseMessage.StatusCode != expectedStatusCode)
            {
                var errorResponse = bodyIsBlank
                    ? null
                    : JsonUtility.Deserialize<RyftApiErrorResponse>(responseBodyRaw);
                throw new RyftApiException(errorResponse, responseMessage.StatusCode);
            }
            var responseBody = bodyIsBlank
                ? null
                : JsonUtility.Deserialize<T>(responseBodyRaw);
            return responseBody ?? throw new RyftApiException(apiError: null, responseMessage.StatusCode);
        }

        private static Task<string> BodyAsString(this HttpResponseMessage responseMessage)
            => responseMessage.Content == null
                ? Task.FromResult(string.Empty)
                : responseMessage.Content.ReadAsStringAsync();
    }
}
