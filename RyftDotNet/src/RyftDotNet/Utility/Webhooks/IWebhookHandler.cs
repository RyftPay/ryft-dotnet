using RyftDotNet.Events;

namespace RyftDotNet.Utility
{
    public interface IWebhookHandler
    {
        bool IsSignatureValid(string secret, string signature, string payload);

        Event ConstructEvent(string requestBody);
    }
}
