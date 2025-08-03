using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.Common;
using RyftDotNet.Utility;
using RyftDotNet.Webhooks;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Webhooks
{
    public sealed class WebhookTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenDeserializingCreatedResponse()
        {
            string json = File.ReadAllText("assets/webhooks/created-response.json");
            JsonUtility.Deserialize<WebhookCreated>(json).ShouldBe(new WebhookCreated(
                "whs_0f6b1b5a-aef0-4011-978b-19fd4a4d46ea",
                "wh_31fba123-0fef-41d6-92ad-fd7089f49f8a",
                true,
                "https://ryftpay.com",
                new List<EventType> { EventType.PaymentSessionCaptured, EventType.PaymentSessionRefunded },
                DateTimeOffset.FromUnixTimeSeconds(1470989538)
            ));
        }

        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenDeserializingRegularResponse()
        {
            string json = File.ReadAllText("assets/webhooks/response.json");
            JsonUtility.Deserialize<Webhook>(json).ShouldBe(new Webhook(
                "wh_31fba123-0fef-41d6-92ad-fd7089f49f8a",
                true,
                "https://ryftpay.com",
                new List<EventType> { EventType.PaymentSessionCaptured, EventType.PaymentSessionRefunded },
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                DateTimeOffset.FromUnixTimeSeconds(1470989539)
            ));
        }
    }
}
