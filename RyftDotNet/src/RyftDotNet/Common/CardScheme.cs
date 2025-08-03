namespace RyftDotNet.Common
{
    public sealed class CardScheme : ConstantValue
    {
        public CardScheme(string value) : base(value) { }

        public static CardScheme Visa => new CardScheme("Visa");
        public static CardScheme Mastercard => new CardScheme("Mastercard");
        public static CardScheme Amex => new CardScheme("Amex");
    }
}
