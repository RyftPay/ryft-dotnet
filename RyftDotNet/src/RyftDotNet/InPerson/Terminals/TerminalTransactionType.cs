namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalTransactionType : Common.ConstantValue
    {
        public TerminalTransactionType(string value) : base(value) { }

        public static readonly TerminalTransactionType Payment = new TerminalTransactionType("Payment");
        public static readonly TerminalTransactionType Refund = new TerminalTransactionType("Refund");
    }
}
