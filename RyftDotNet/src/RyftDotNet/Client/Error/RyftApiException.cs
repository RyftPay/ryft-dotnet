using System;
using System.Linq;
using System.Net;

namespace RyftDotNet.Client.Error
{
    [Serializable]
    public sealed class RyftApiException : RyftDotNetException
    {
        public RyftApiErrorResponse? ApiError { get; set; }
        public HttpStatusCode? HttpStatusCode { get; set; }

        public RyftApiException(string message) : base(message) { }

        public RyftApiException(string message, Exception innerException)
            : base(message, innerException) { }

        public RyftApiException(RyftApiErrorResponse? apiError, HttpStatusCode httpStatusCode)
            : base(message: BuildMessage(apiError, httpStatusCode))
        {
            ApiError = apiError;
            HttpStatusCode = httpStatusCode;
        }

        private static string BuildMessage(RyftApiErrorResponse? apiError, HttpStatusCode httpStatusCode)
        {
            var baseMessage = $"Received an unsuccessful status code ({httpStatusCode}) from the API";
            var errorDetail = apiError?.Errors?.Select(e => $"{e.Code}: {e.Message}").ToList();
            return errorDetail != null && errorDetail.Count > 0
                ? $"{baseMessage} - {string.Join("; ", errorDetail)}"
                : baseMessage;
        }
    }
}
