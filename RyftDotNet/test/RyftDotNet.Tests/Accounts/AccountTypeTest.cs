using RyftDotNet.Accounts;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Accounts
{
    public sealed class AccountTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(AccountType actual, AccountType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<AccountType, AccountType> ExpectedValues() =>
            new TheoryData<AccountType, AccountType>
            {
                { AccountType.Standard, new AccountType("Standard") },
                { AccountType.Sub, new AccountType("Sub") }
            };
    }
}
