using System;
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
            : base(message: $"Received an unsuccessful status code ({httpStatusCode}) from the API")
        {
            ApiError = apiError;
            HttpStatusCode = httpStatusCode;
        }
    }
}
