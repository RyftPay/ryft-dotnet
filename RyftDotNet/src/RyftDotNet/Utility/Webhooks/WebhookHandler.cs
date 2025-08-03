using System;
using RyftDotNet.Client.Error;
using RyftDotNet.Events;

namespace RyftDotNet.Utility.Webhooks
{
    public sealed class WebhookHandler : IWebhookHandler
    {
        private readonly IWebhookSignatureVerifier signatureVerifier;

        public WebhookHandler()
        {
            this.signatureVerifier = new WebhookSignatureVerifier();
        }

        public WebhookHandler(IWebhookSignatureVerifier signatureVerifier)
        {
            this.signatureVerifier = signatureVerifier;
        }

        public bool IsSignatureValid(string secret, string signature, string payload)
            => signatureVerifier.IsValid(secret, signature, payload);

        public Event ConstructEvent(string requestBody)
        {
            try
            {
                var output = JsonUtility.Deserialize<Event>(requestBody);
                if (output == null)
                {
                    throw new RyftDotNetException("The supplied request body could not be converted to an Event");
                }
                return output;
            }
            catch (Exception e)
            {
                throw new RyftDotNetException("Unable to convert request body to an Event", e);
            }
        }
    }
}
