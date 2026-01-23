using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class CardProductType : ConstantValue
    {
        public CardProductType(string value) : base(value) { }

        public static readonly CardProductType Consumer = new CardProductType("Consumer");
        public static readonly CardProductType Corporate = new CardProductType("Corporate");
    }
}
