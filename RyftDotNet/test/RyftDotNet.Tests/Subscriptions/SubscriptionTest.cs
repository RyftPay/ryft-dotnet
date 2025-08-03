using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.Common;
using RyftDotNet.PaymentSessions;
using RyftDotNet.Subscriptions;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Subscriptions
{
    public sealed class SubscriptionTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenAllFieldsInResponse()
        {
            string json = File.ReadAllText("assets/subscriptions/response-full.json");
            JsonUtility.Deserialize<Subscription>(json).ShouldBe(new Subscription(
                "sub_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                SubscriptionStatus.Active,
                new SubscriptionCustomer("cus_01G0EYVFR02KBBVE2YWQ8AKMGJ"),
                new SubscriptionPaymentSessions(
                    new SubscriptionPaymentSession(
                        "ps_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                        "ps_01FCTS1XMKH9FF43CAFA4CXT3P_secret_b83f2653-06d7-44a9-a548-5825e8186004",
                        new PaymentSessionRequiredAction(
                            type: PaymentSessionRequiredActionType.Challenge,
                            challenge: new RequiredActionChallenge(
                                "https://acs.sandbox.ryftpay.com/browser/challenge",
                                "eyJ0aHJlZURTU2VydmVyVHJhbnNJRCI6IjA0NDk0MWE3LTMxM2UtNGMxMi1iOTY2LTE1MzNmODBhMzllOSIsImFjc1RyYW5zSUQiOiJhZTI1NzAwNi05ZWRhLTRkZWEtODZlNC0wYjYxYjgwNDcxZTAiLCJtZXNzYWdlVmVyc2lvbiI6IjIuMi4wIiwibWVzc2FnZVR5cGUiOiJDUmVxIiwiY2hhbGxlbmdlV2luZG93U2l6ZSI6IjAxIn0"
                            )
                        )
                    ),
                    new SubscriptionPaymentSession(
                        "ps_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                        "ps_01FCTS1XMKH9FF43CAFA4CXT3P_secret_b83f2653-06d7-44a9-a548-5825e8186004",
                        new PaymentSessionRequiredAction(
                            type: PaymentSessionRequiredActionType.Challenge,
                            challenge: new RequiredActionChallenge(
                                "https://acs.sandbox.ryftpay.com/browser/challenge",
                                "eyJ0aHJlZURTU2VydmVyVHJhbnNJRCI6IjA0NDk0MWE3LTMxM2UtNGMxMi1iOTY2LTE1MzNmODBhMzllOSIsImFjc1RyYW5zSUQiOiJhZTI1NzAwNi05ZWRhLTRkZWEtODZlNC0wYjYxYjgwNDcxZTAiLCJtZXNzYWdlVmVyc2lvbiI6IjIuMi4wIiwibWVzc2FnZVR5cGUiOiJDUmVxIiwiY2hhbGxlbmdlV2luZG93U2l6ZSI6IjAxIn0"
                            )
                        )
                    )
                ),
                new SubscriptionPrice(
                    5000,
                    "GBP",
                    new SubscriptionInterval(
                        IntervalUnit.Months,
                        1,
                        12
                    )
                ),
                new SubscriptionBillingDetail(
                    12,
                    4,
                    DateTimeOffset.FromUnixTimeSeconds(1480989538),
                    DateTimeOffset.FromUnixTimeSeconds(1480989538),
                    DateTimeOffset.FromUnixTimeSeconds(1480989538),
                    DateTimeOffset.FromUnixTimeSeconds(1480989538),
                    new SubscriptionBillingFailureDetail(2, "insufficient_funds")
                ),
                new SubscriptionBalance(5000),
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                "Bob's monthly gym membership",
                new SubscriptionPaymentMethod("pmt_01G0EYVFR02KBBVE2YWQ8AKMGJ"),
                new SubscriptionPausePaymentDetail(
                    DateTimeOffset.FromUnixTimeSeconds(1470989538),
                    "Offering service for free to customer",
                    DateTimeOffset.FromUnixTimeSeconds(1470989538)
                ),
                new SubscriptionCancelDetail(
                    DateTimeOffset.FromUnixTimeSeconds(1480989538),
                    "Customer no longer wants to use the service"
                ),
                new ShippingDetails(
                    new Address(
                        "Fox",
                        "Mulder",
                        "Stonehenge",
                        null,
                        "Salisbury",
                        "GB",
                        "SP4 7DE",
                        null
                    ),
                    "+447900000000"
                ),
                new Dictionary<string, string> { ["myCustomerId"] = "1" },
                new SubscriptionPaymentSettings(
                    new SubscriptionStatementDescriptor("Ryft Ltd", "London")
                )
            ));
        }
    }
}
