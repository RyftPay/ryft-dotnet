using RyftDotNet.Utility.Webhooks;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Utility.Webhooks
{
    public sealed class WebhookSignatureVerifierTest
    {
        [Fact]
        public void IsValid_ShouldReturnFalse_WhenSignatureIsInvalid()
        {
            var verifier = new WebhookSignatureVerifier();
            const string payload = "{\"amount\": 500, \"currency\": \"GBP\"}";
            const string secretKey = "abcdef4455";
            const string signature = "12443c521a6900579d09b1b29cf17b679f7745eb32a8018e46f44bb27103f864";
            verifier.IsValid(secretKey, signature, payload).ShouldBeFalse();
        }

        [Fact]
        public void IsValid_ShouldReturnTrue_WhenSignatureIsValid()
        {
            var verifier = new WebhookSignatureVerifier();
            const string payload = "{\"amount\": 500, \"currency\": \"GBP\"}";
            const string secretKey = "abcdef4455";
            const string signature = "12443c521a6900579d09b1b29cf17b679f7745eb32a8018e46f44bb27103f865";
            verifier.IsValid(secretKey, signature, payload).ShouldBeTrue();
        }
    }
}
