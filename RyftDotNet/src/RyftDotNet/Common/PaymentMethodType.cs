namespace RyftDotNet.Common
{
    public sealed class PaymentMethodType : ConstantValue
    {
        public PaymentMethodType(string value) : base(value) { }

        public static readonly PaymentMethodType Card = new PaymentMethodType("Card");
    }
}
