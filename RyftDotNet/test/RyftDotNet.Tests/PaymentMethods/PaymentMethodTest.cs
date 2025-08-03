using System;
using System.IO;
using RyftDotNet.Common;
using RyftDotNet.PaymentMethods;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentMethods
{
    public sealed class PaymentMethodTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenMinimumRequiredFieldsReturned()
        {
            string json = File.ReadAllText("assets/payment-methods/response-min.json");
            JsonUtility.Deserialize<PaymentMethod>(json).ShouldBe(new PaymentMethod(
                "pmt_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                PaymentMethodType.Card,
                new PaymentMethodCard(
                    CardScheme.Mastercard,
                    "4444",
                    "10",
                    "2030"
                ),
                null,
                null,
                null,
                DateTimeOffset.FromUnixTimeSeconds(1470989538)
            ));
        }

        [Fact]
        public void FromJson_ShouldReturnExpectedValue_WhenAllFieldsReturned()
        {
            string json = File.ReadAllText("assets/payment-methods/response-full.json");
            JsonUtility.Deserialize<PaymentMethod>(json).ShouldBe(new PaymentMethod(
                "pmt_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                PaymentMethodType.Card,
                new PaymentMethodCard(
                    CardScheme.Mastercard,
                    "4444",
                    "10",
                    "2030"
                ),
                new Address(
                    "Nathan",
                    "Drake",
                    "Stonehenge",
                    "Salisbury",
                    "Salisbury",
                    "GB",
                    "SP4 7DE",
                    "Salisbury Plain"
                ),
                new PaymentMethodChecks("Y", "M"),
                "cus_01G0EYVFR02KBBVE2YWQ8AKMGJ",
                DateTimeOffset.FromUnixTimeSeconds(1470989538)
            ));
        }
    }
}
