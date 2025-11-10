namespace RyftDotNet.InPerson.Terminals
{
    public sealed class TerminalActionType : Common.ConstantValue
    {
        public TerminalActionType(string value) : base(value) { }

        public static readonly TerminalActionType Transaction = new TerminalActionType("Transaction");
    }
}