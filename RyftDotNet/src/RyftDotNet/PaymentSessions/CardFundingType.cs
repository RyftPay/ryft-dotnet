using RyftDotNet.Common;

namespace RyftDotNet.PaymentSessions
{
    public sealed class CardFundingType : ConstantValue
    {
        public CardFundingType(string value) : base(value) { }

        public static readonly CardFundingType Credit = new CardFundingType("Credit");
        public static readonly CardFundingType Debit = new CardFundingType("Debit");
        public static readonly CardFundingType Prepaid = new CardFundingType("Prepaid");
        public static readonly CardFundingType DeferredDebit = new CardFundingType("DeferredDebit");
        public static readonly CardFundingType Charge = new CardFundingType("Charge");
    }
}
