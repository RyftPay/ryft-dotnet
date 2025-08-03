using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class WalletType : ConstantValue
    {
        public WalletType(string value) : base(value) { }

        public static readonly WalletType ApplePay = new WalletType("ApplePay");
        public static readonly WalletType GooglePay = new WalletType("GooglePay");
    }
}
