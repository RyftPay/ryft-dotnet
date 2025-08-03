using RyftDotNet.PaymentSessions.PaymentTransactions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions.PaymentTransactions
{
    public sealed class PaymentTransactionStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PaymentTransactionStatus actual, PaymentTransactionStatus expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PaymentTransactionStatus, PaymentTransactionStatus> ExpectedValues() =>
            new TheoryData<PaymentTransactionStatus, PaymentTransactionStatus>
            {
                { PaymentTransactionStatus.Pending, new PaymentTransactionStatus("Pending") },
                { PaymentTransactionStatus.Failed, new PaymentTransactionStatus("Failed") },
                { PaymentTransactionStatus.Succeeded, new PaymentTransactionStatus("Succeeded")}
            };
    }
}
