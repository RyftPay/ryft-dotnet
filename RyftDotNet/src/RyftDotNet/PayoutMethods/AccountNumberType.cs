using RyftDotNet.Common;

namespace RyftDotNet.PayoutMethods
{
    public sealed class AccountNumberType : ConstantValue
    {
        public AccountNumberType(string value) : base(value) { }

        public static readonly AccountNumberType Iban = new AccountNumberType("Iban");

        public static readonly AccountNumberType UnitedKingdom = new AccountNumberType("UnitedKingdom");

        public static readonly AccountNumberType UnitedStates = new AccountNumberType("UnitedStates");
    }
}
