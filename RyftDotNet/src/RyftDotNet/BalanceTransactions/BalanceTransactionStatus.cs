using RyftDotNet.Common;

namespace RyftDotNet.BalanceTransactions
{
    public sealed class BalanceTransactionStatus : ConstantValue
    {
        public BalanceTransactionStatus(string value) : base(value) { }

        public static readonly BalanceTransactionStatus Pending = new BalanceTransactionStatus("Pending");
        public static readonly BalanceTransactionStatus Cleared = new BalanceTransactionStatus("Cleared");
        public static readonly BalanceTransactionStatus Available = new BalanceTransactionStatus("Available");
    }
}
