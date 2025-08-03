using System.Net;
using System.Net.Http;

namespace RyftDotNet.Tests
{
    public sealed class MultipartFormDataRequestArguments
    {
        public string Path { get; }
        public MultipartFormDataContent Content { get; }
        public HttpStatusCode HttpStatusCode { get; }

        public MultipartFormDataRequestArguments(
            string path,
            MultipartFormDataContent content,
            HttpStatusCode httpStatusCode)
        {
            Path = path;
            Content = content;
            HttpStatusCode = httpStatusCode;
        }
    }
}
