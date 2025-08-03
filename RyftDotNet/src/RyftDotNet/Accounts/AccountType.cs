using RyftDotNet.Common;

namespace RyftDotNet.Accounts
{
    public sealed class AccountType : ConstantValue
    {
        public AccountType(string value) : base(value) { }

        public static readonly AccountType Standard = new AccountType("Standard");
        public static readonly AccountType Sub = new AccountType("Sub");
    }
}
