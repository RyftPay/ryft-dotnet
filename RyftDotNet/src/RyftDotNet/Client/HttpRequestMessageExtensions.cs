using System.Net.Http;

namespace RyftDotNet.Client
{
    internal static class HttpRequestMessageExtensions
    {
        internal static void AddHeader(
            this HttpRequestMessage requestMessage,
            string name,
            string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }
            requestMessage.Headers.TryAddWithoutValidation(name, value);
        }
    }
}
