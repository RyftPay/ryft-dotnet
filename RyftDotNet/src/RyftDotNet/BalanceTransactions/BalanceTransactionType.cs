using RyftDotNet.Common;

namespace RyftDotNet.BalanceTransactions
{
    public sealed class BalanceTransactionType : ConstantValue
    {
        public BalanceTransactionType(string value) : base(value) { }

        public static readonly BalanceTransactionType TransactionApproval =
            new BalanceTransactionType("TransactionApproval");

        public static readonly BalanceTransactionType TransactionCapture =
            new BalanceTransactionType("TransactionCapture");

        public static readonly BalanceTransactionType TransactionRefund =
            new BalanceTransactionType("TransactionRefund");

        public static readonly BalanceTransactionType TransactionChargeback =
            new BalanceTransactionType("TransactionChargeback");

        public static readonly BalanceTransactionType TransactionChargebackReversal =
            new BalanceTransactionType("TransactionChargebackReversal");

        public static readonly BalanceTransactionType PlatformFee =
            new BalanceTransactionType("PlatformFee");

        public static readonly BalanceTransactionType PlatformFeeRefund =
            new BalanceTransactionType("PlatformFeeRefund");

        public static readonly BalanceTransactionType SplitPayment =
            new BalanceTransactionType("SplitPayment");

        public static readonly BalanceTransactionType SplitPaymentRefund =
            new BalanceTransactionType("SplitPaymentRefund");

        public static readonly BalanceTransactionType TransferIn =
            new BalanceTransactionType("TransferIn");

        public static readonly BalanceTransactionType TransferOut =
            new BalanceTransactionType("TransferOut");

        public static readonly BalanceTransactionType Payout =
            new BalanceTransactionType("Payout");

        public static readonly BalanceTransactionType PayoutReversal =
            new BalanceTransactionType("PayoutReversal");

        public static readonly BalanceTransactionType PlatformChargeback =
            new BalanceTransactionType("PlatformChargeback");

        public static readonly BalanceTransactionType PlatformChargebackReversal =
            new BalanceTransactionType("PlatformChargebackReversal");

        public static readonly BalanceTransactionType Adjustment =
            new BalanceTransactionType("Adjustment");
    }
}
