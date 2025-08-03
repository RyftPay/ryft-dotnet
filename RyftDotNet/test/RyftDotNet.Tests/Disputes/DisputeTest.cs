using System;
using System.Collections.Generic;
using System.IO;
using RyftDotNet.Common;
using RyftDotNet.Disputes;
using RyftDotNet.PaymentSessions;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Disputes
{
    public sealed class DisputeTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenMinimumRequiredFieldsReturned()
        {
            string json = File.ReadAllText("assets/disputes/response-full.json");
            JsonUtility.Deserialize<Dispute>(json).ShouldBe(new Dispute(
                "dsp_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                500,
                "GBP",
                DisputeStatus.Open,
                DisputeCategory.Fraudulent,
                new DisputeReason(
                    "13.6",
                    "Merchandise/Services Not Received"
                ),
                DateTimeOffset.FromUnixTimeSeconds(1685059200),
                new List<DisputeRecommendedEvidence> { DisputeRecommendedEvidence.ProofOfDelivery },
                new DisputePaymentSession(
                    "ps_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                    PaymentType.Standard,
                    new DisputePaymentSessionPaymentMethod(
                        new DisputePaymentSessionPaymentMethodCard(CardScheme.Mastercard, "4444")
                    )
                ),
                DateTimeOffset.FromUnixTimeSeconds(1470989538),
                DateTimeOffset.FromUnixTimeSeconds(1470989539),
                new DisputeEvidence(
                    new DisputeEvidenceTextEntries(
                        "Example 123",
                        "Example 456",
                        "Customer ordered 2 distinct items",
                        "Lorem ipsum dolor sit amet"
                    ),
                    new DisputeEvidenceFiles(
                        new DisputeEvidenceFile("fl_01G0EYVFR02KBBVE2YWQ8AKMGJ"),
                        new DisputeEvidenceFile("fl_01G0EYVFR02KBBVE2YWQ8AKMGJ"),
                        new DisputeEvidenceFile("fl_01G0EYVFR02KBBVE2YWQ8AKMGJ"),
                        new DisputeEvidenceFile("fl_01G0EYVFR02KBBVE2YWQ8AKMGJ"),
                        new DisputeEvidenceFile("fl_01G0EYVFR02KBBVE2YWQ8AKMGJ"),
                        new DisputeEvidenceFile("fl_01G0EYVFR02KBBVE2YWQ8AKMGJ"),
                        new DisputeEvidenceFile("fl_01G0EYVFR02KBBVE2YWQ8AKMGJ"),
                        new DisputeEvidenceFile("fl_01G0EYVFR02KBBVE2YWQ8AKMGJ")
                    )
                ),
                new DisputeCustomer(
                    "john.doe@ryftpay.com",
                    "cus_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                    DateTimeOffset.FromUnixTimeSeconds(1470989438)
                ),
                new DisputeSubAccount("ac_3fe8398f-8cdb-43a3-9be2-806c4f84c327")
            ));
        }
    }
}
