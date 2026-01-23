using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.Common;
using RyftDotNet.PaymentSessions;
using RyftDotNet.PaymentSessions.PaymentTransactions;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions.PaymentTransactions
{
    public sealed class PaymentTransactionTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenAllFieldsReturned()
        {
            string json = File.ReadAllText("assets/payment-transactions/response-full.json");
            JsonUtility.Deserialize<PaymentTransaction>(json).ShouldBe(new PaymentTransaction(
                "txn_01FCTS1XMKH9FF43CAFA4CXT3P_01FCTS1XMKH9FF43CAFA4CXT3P",
                "ps_01FCTS1XMKH9FF43CAFA4CXT3P",
                250,
                "GBP",
                PaymentTransactionType.Capture,
                PaymentTransactionStatus.Succeeded,
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                50,
                50,
                50,
                "Requested by the customer",
                CaptureType.Final,
                new PaymentSessionPaymentMethod(
                    PaymentMethodType.Card,
                    tokenizedDetails: new PaymentMethodTokenizedDetails("pmt_01G0EYVFR02KBBVE2YWQ8AKMGJ", true),
                    card: new PaymentSessionCard(CardScheme.Mastercard, "4444"),
                    wallet: new PaymentSessionWallet(WalletType.ApplePay),
                    billingAddress: new Address(
                        "Nathan",
                        "Drake",
                        "123 Test Street",
                        "456 Lane",
                        "Manchester",
                        "GB",
                        "SP4 7DE",
                        "NY"
                    ),
                    checks: new PaymentMethodChecks("Y", "M")
                ),
                new SplitPaymentDetail(
                    new List<SplitPaymentItem>
                    {
                        new SplitPaymentItem(
                            "sp_01FCTS1XMKH9FF43CAFA4CXT3P",
                            "ac_b83f2653-06d7-44a9-a548-5825e8186004",
                            50,
                            "2 x The Selfish Gene",
                            new SplitPaymentItemFee(50),
                            new Dictionary<string, string>
                            {
                                ["productId"] = "123", ["productDescription"] = "The Selfish Gene"
                            }
                        )
                    }
                )
            ));
        }
    }
}
