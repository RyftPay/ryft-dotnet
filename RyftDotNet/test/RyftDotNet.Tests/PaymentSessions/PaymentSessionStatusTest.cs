using RyftDotNet.PaymentSessions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class PaymentSessionStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PaymentSessionStatus actual, PaymentSessionStatus expected)
            => actual.ShouldBe(expected);

        [Theory, MemberData(nameof(ExpectedStringEqualityChecks))]
        public void EqualsOperatorViaString_ShouldReturnExpectedValue(
            PaymentSessionStatus status,
            string toCompare,
            bool expected) => (status == toCompare).ShouldBe(expected);

        public static TheoryData<PaymentSessionStatus, PaymentSessionStatus> ExpectedValues() =>
            new TheoryData<PaymentSessionStatus, PaymentSessionStatus>
            {
                { PaymentSessionStatus.PendingPayment, new PaymentSessionStatus("PendingPayment") },
                { PaymentSessionStatus.PendingAction, new PaymentSessionStatus("PendingAction") },
                { PaymentSessionStatus.Processing, new PaymentSessionStatus("Processing")},
                { PaymentSessionStatus.Approved, new PaymentSessionStatus("Approved")},
                { PaymentSessionStatus.Captured, new PaymentSessionStatus("Captured")},
                { PaymentSessionStatus.Voided, new PaymentSessionStatus("Voided")}
            };

        public static TheoryData<PaymentSessionStatus, string, bool> ExpectedStringEqualityChecks() =>
            new TheoryData<PaymentSessionStatus, string, bool>
            {
                { PaymentSessionStatus.Approved, "PendingPayment", false },
                { PaymentSessionStatus.Approved, "Approved", true },
                { PaymentSessionStatus.Captured, "Approved", false },
                { PaymentSessionStatus.Captured, "Captured", true }
            };
    }
}
