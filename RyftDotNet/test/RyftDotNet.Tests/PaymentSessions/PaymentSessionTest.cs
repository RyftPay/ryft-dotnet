using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.Common;
using RyftDotNet.PaymentSessions;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class PaymentSessionTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenMinimumRequiredFieldsReturned()
        {
            string json = File.ReadAllText("assets/payment-sessions/response-min.json");
            JsonUtility.Deserialize<PaymentSession>(json).ShouldBe(new PaymentSession(
                "ps_01K07XVW98SFWWBB75JEMW3Q2V",
                11811,
                "GBP",
                PaymentType.Standard,
                PaymentSessionStatus.PendingPayment,
                new StatementDescriptor("Ryft Ltd", "Manchester"),
                refundedAmount: 0,
                DateTimeOffset.FromUnixTimeSeconds(1752612860),
                DateTimeOffset.FromUnixTimeSeconds(1752612860)
            ));
        }

        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenParsingPendingAction3dsIdentifyResponse()
        {
            string json = File.ReadAllText("assets/payment-sessions/response-3ds-identify.json");
            JsonUtility.Deserialize<PaymentSession>(json).ShouldBe(new PaymentSession(
                "ps_01K0ES5ZFBJMCZR1D1X7HH0R4W",
                5670,
                "GBP",
                PaymentType.Standard,
                PaymentSessionStatus.PendingAction,
                new StatementDescriptor("Ryft Ltd", "Manchester"),
                refundedAmount: 0,
                DateTimeOffset.FromUnixTimeSeconds(1752842829),
                DateTimeOffset.FromUnixTimeSeconds(1752843051),
                EntryMode.Online,
                customerEmail: "test@ryftpay.com",
                paymentMethod: new PaymentSessionPaymentMethod(
                    PaymentMethodType.Card,
                    card: new PaymentSessionCard(CardScheme.Visa, "0004")
                ),
                requiredAction: new PaymentSessionRequiredAction(
                    type: PaymentSessionRequiredActionType.Identify,
                    identify: new RequiredActionIdentify(
                        threeDsMethodUrl: "https://acs.sandbox.ryftpay.com/3dsmethod",
                        threeDsMethodData:
                        "eyJ0aHJlZURTU2VydmVyVHJhbnNJRCI6IjMzMjg3NzNmLTQzYjQtNDk2Ni1iNjM0LTRkNTZhMDEzNzI4NSIsInRocmVlRFNNZXRob2ROb3RpZmljYXRpb25VUkwiOiJodHRwczovL3NhbmRib3gtaG9va3MucnlmdHBheS5jb20vdjEvdGhyZWVkcy9tZXRob2Qtbm90aWZpY2F0aW9uP3NpZz1ZOXpRU1hId3BJVENqM3ljMUpWN3BKWWF3SzltRGxsblBjamZXYm1ENmY4WG5LbWF6aFI2MEtHRUJlZXVUa3BiMFVrN0pkQ09DQUJaZHglMjUyZjFkd2J6T01KaE96d1puNkxmczdNeU14eW0lMjUyZlpwemxYZFF6WGJOVzlnSHJjZ1c2aHo4In0",
                        scheme: "Visa",
                        paymentMethodId: "pmt_01K0ESCRAF42SV2HM5Z7X56TGR"
                    )),
                authorizationType: AuthorizationType.FinalAuth,
                captureFlow: CaptureFlow.Manual,
                metadata: new Dictionary<string, string>
                {
                    ["orderId"] = "80c1d117-4fdc-4e8a-b965-17e2d53c42ad",
                    ["id"] = "a value with spaces"
                }
            ));
        }

        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenParsingPendingAction3dsChallengeResponse()
        {
            string json = File.ReadAllText("assets/payment-sessions/response-3ds-challenge.json");
            JsonUtility.Deserialize<PaymentSession>(json).ShouldBe(new PaymentSession(
                "ps_01K0ESEN9EXZJYCKRXRGRWYSFK",
                5670,
                "GBP",
                PaymentType.Standard,
                PaymentSessionStatus.PendingAction,
                new StatementDescriptor("Ryft Ltd", "Manchester"),
                refundedAmount: 0,
                DateTimeOffset.FromUnixTimeSeconds(1752843113),
                DateTimeOffset.FromUnixTimeSeconds(1752843161),
                EntryMode.Online,
                customerEmail: "test@ryftpay.com",
                paymentMethod: new PaymentSessionPaymentMethod(
                    PaymentMethodType.Card,
                    card: new PaymentSessionCard(CardScheme.Visa, "0002")
                ),
                requiredAction: new PaymentSessionRequiredAction(
                    type: PaymentSessionRequiredActionType.Challenge,
                    challenge: new RequiredActionChallenge(
                        acsUrl: "https://acs.sandbox.ryftpay.com/browser/challenge",
                        cReq: "eyJ0aHJlZURTU2VydmVyVHJhbnNJRCI6IjA0NDk0MWE3LTMxM2UtNGMxMi1iOTY2LTE1MzNmODBhMzllOSIsImFjc1RyYW5zSUQiOiJhZTI1NzAwNi05ZWRhLTRkZWEtODZlNC0wYjYxYjgwNDcxZTAiLCJtZXNzYWdlVmVyc2lvbiI6IjIuMi4wIiwibWVzc2FnZVR5cGUiOiJDUmVxIiwiY2hhbGxlbmdlV2luZG93U2l6ZSI6IjAxIn0"
                    )
                ),
                authorizationType: AuthorizationType.FinalAuth,
                captureFlow: CaptureFlow.Manual,
                metadata: new Dictionary<string, string>
                {
                    ["orderId"] = "791ca405-68ab-442a-ab08-1dfabff35af6",
                    ["id"] = "a value with spaces"
                }
            ));
        }
    }
}
