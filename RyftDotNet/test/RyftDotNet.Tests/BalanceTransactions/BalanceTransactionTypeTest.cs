using RyftDotNet.BalanceTransactions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.BalanceTransactions
{
    public sealed class BalanceTransactionTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(BalanceTransactionType actual, BalanceTransactionType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<BalanceTransactionType, BalanceTransactionType> ExpectedValues() =>
            new TheoryData<BalanceTransactionType, BalanceTransactionType>
            {
                { BalanceTransactionType.TransactionApproval, new BalanceTransactionType("TransactionApproval") },
                { BalanceTransactionType.TransactionCapture, new BalanceTransactionType("TransactionCapture") },
                { BalanceTransactionType.TransactionRefund, new BalanceTransactionType("TransactionRefund")},
                { BalanceTransactionType.TransactionChargeback, new BalanceTransactionType("TransactionChargeback")},
                { BalanceTransactionType.TransactionChargebackReversal, new BalanceTransactionType("TransactionChargebackReversal")},
                { BalanceTransactionType.PlatformFee, new BalanceTransactionType("PlatformFee")},
                { BalanceTransactionType.PlatformFeeRefund, new BalanceTransactionType("PlatformFeeRefund")},
                { BalanceTransactionType.SplitPayment, new BalanceTransactionType("SplitPayment")},
                { BalanceTransactionType.SplitPaymentRefund, new BalanceTransactionType("SplitPaymentRefund")},
                { BalanceTransactionType.TransferIn, new BalanceTransactionType("TransferIn")},
                { BalanceTransactionType.TransferOut, new BalanceTransactionType("TransferOut")},
                { BalanceTransactionType.Payout, new BalanceTransactionType("Payout")},
                { BalanceTransactionType.PayoutReversal, new BalanceTransactionType("PayoutReversal")},
                { BalanceTransactionType.PlatformChargeback, new BalanceTransactionType("PlatformChargeback")},
                { BalanceTransactionType.PlatformChargebackReversal, new BalanceTransactionType("PlatformChargebackReversal")},
                { BalanceTransactionType.Adjustment, new BalanceTransactionType("Adjustment")}
            };
    }
}
