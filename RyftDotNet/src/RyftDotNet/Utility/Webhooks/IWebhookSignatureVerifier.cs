namespace RyftDotNet.Utility.Webhooks
{
    public interface IWebhookSignatureVerifier
    {
        bool IsValid(string secret, string signature, string payload);
    }
}
