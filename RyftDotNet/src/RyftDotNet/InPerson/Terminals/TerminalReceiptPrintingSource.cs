namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalReceiptPrintingSource : Common.ConstantValue
    {
        public TerminalReceiptPrintingSource(string value) : base(value) { }

        public static readonly TerminalReceiptPrintingSource Terminal = new TerminalReceiptPrintingSource("Terminal");
        public static readonly TerminalReceiptPrintingSource PointOfSale = new TerminalReceiptPrintingSource("PointOfSale");
    }
}
