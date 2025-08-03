using RyftDotNet.Common;

namespace RyftDotNet.PayoutMethods
{
    public sealed class PayoutMethodType : ConstantValue
    {
        public PayoutMethodType(string value) : base(value) { }

        public static readonly PayoutMethodType BankAccount = new PayoutMethodType("BankAccount");
    }
}
