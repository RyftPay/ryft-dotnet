using System;
using System.Security.Cryptography;
using System.Text;

namespace RyftDotNet.Utility.Webhooks
{
    public sealed class WebhookSignatureVerifier : IWebhookSignatureVerifier
    {
        public bool IsValid(string secret, string signature, string payload)
            => HmacSha256(secret, payload) == signature;

        private static string HmacSha256(string secret, string payload)
        {
            byte[] secretBytes = Encoding.ASCII.GetBytes(secret);
            byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);
            using var cryptographer = new HMACSHA256(secretBytes);
            byte[] hash = cryptographer.ComputeHash(payloadBytes);
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
        }
    }
}
