using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class EntryMode : ConstantValue
    {
        public EntryMode(string value) : base(value) { }

        public static EntryMode Online = new EntryMode("Online");
        public static EntryMode Moto = new EntryMode("MOTO");
    }
}
