using RyftDotNet.PaymentSessions.PaymentTransactions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions.PaymentTransactions
{
    public sealed class PaymentTransactionTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PaymentTransactionType actual, PaymentTransactionType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PaymentTransactionType, PaymentTransactionType> ExpectedValues() =>
            new TheoryData<PaymentTransactionType, PaymentTransactionType>
            {
                { PaymentTransactionType.Authorization, new PaymentTransactionType("Authorization") },
                { PaymentTransactionType.Void, new PaymentTransactionType("Void") },
                { PaymentTransactionType.Capture, new PaymentTransactionType("Capture")},
                { PaymentTransactionType.Refund, new PaymentTransactionType("Refund")},
                { PaymentTransactionType.Chargeback, new PaymentTransactionType("Chargeback")},
                { PaymentTransactionType.ChargebackReversal, new PaymentTransactionType("ChargebackReversal")}
            };
    }
}
