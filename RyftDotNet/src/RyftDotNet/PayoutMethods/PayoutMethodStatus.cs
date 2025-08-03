using RyftDotNet.Common;

namespace RyftDotNet.PayoutMethods
{
    public sealed class PayoutMethodStatus : ConstantValue
    {
        public PayoutMethodStatus(string value) : base(value) { }

        public static readonly PayoutMethodStatus Pending = new PayoutMethodStatus("Pending");
        public static readonly PayoutMethodStatus Invalid = new PayoutMethodStatus("Invalid");
        public static readonly PayoutMethodStatus Valid = new PayoutMethodStatus("Valid");
    }
}
