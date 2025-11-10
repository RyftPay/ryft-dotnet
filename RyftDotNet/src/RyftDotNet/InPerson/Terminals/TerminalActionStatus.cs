namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalActionStatus : Common.ConstantValue
    {
        public TerminalActionStatus(string value) : base(value) { }

        public static readonly TerminalActionStatus InProgress = new TerminalActionStatus("InProgress");
        public static readonly TerminalActionStatus Cancelled = new TerminalActionStatus("Cancelled");
        public static readonly TerminalActionStatus Failed = new TerminalActionStatus("Failed");
        public static readonly TerminalActionStatus Succeeded = new TerminalActionStatus("Succeeded");
    }
}