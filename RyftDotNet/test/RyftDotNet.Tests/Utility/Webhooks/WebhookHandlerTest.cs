using System;
using System.IO;
using Moq;
using Moq.Language.Flow;
using RyftDotNet.Client.Error;
using RyftDotNet.Events;
using RyftDotNet.Utility.Webhooks;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Utility.Webhooks
{
    public sealed class WebhookHandlerTest
    {
        private readonly Mock<IWebhookSignatureVerifier> signatureVerifier = new Mock<IWebhookSignatureVerifier>();
        private readonly WebhookHandler webhookHandler;

        public WebhookHandlerTest()
        {
            webhookHandler = new WebhookHandler(signatureVerifier.Object);
        }

        [Theory, InlineData(false), InlineData(true)]
        public void HasValidSignature_ShouldProxyResultFromSignatureVerifier(bool result)
        {
            const string secret = "secret";
            const string signature = "signature";
            const string payload = "{}";
            VerifierIsValid(secret, signature, payload).Returns(result);
            webhookHandler.IsSignatureValid(secret, signature, payload).ShouldBe(result);
        }

        [Fact]
        public void ConstructEvent_ShouldThrowException_WhenRequestBodyCannotBeConvertedToEventModel()
        {
            const string requestBody = "{}";
            Func<Event> action = () => webhookHandler.ConstructEvent(requestBody);
            var exception = action.ShouldThrow<RyftDotNetException>();
            exception.Message.ShouldContain("Unable to convert request body to an Event");
        }

        [Fact]
        public void ConstructEvent_ShouldReturnValue_WhenRequestBodyCanBeConvertedToEventModel()
        {
            string requestBody = File.ReadAllText("assets/events/customer-created-event.json");
            var result = webhookHandler.ConstructEvent(requestBody);
            result.ShouldBeOfType<Event>();
        }

        private ISetup<IWebhookSignatureVerifier, bool> VerifierIsValid(
            string secret,
            string signature,
            string payload) =>
            signatureVerifier.Setup(v => v.IsValid(secret, signature, payload));
    }
}
