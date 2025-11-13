using RyftDotNet.Common;

namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalReceiptPrintingStatus : ConstantValue
    {
        public static readonly TerminalReceiptPrintingStatus Succeeded = new TerminalReceiptPrintingStatus(nameof(Succeeded));
        public static readonly TerminalReceiptPrintingStatus Failed = new TerminalReceiptPrintingStatus(nameof(Failed));

        public TerminalReceiptPrintingStatus(string value) : base(value)
        {
        }
    }
}
