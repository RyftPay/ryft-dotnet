using RyftDotNet.PayoutMethods;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PayoutMethods
{
    public sealed class AccountNumberTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(AccountNumberType actual, AccountNumberType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<AccountNumberType, AccountNumberType> ExpectedValues() =>
            new TheoryData<AccountNumberType, AccountNumberType>
            {
                { AccountNumberType.Iban, new AccountNumberType("Iban") },
                { AccountNumberType.UnitedKingdom, new AccountNumberType("UnitedKingdom") },
                { AccountNumberType.UnitedStates, new AccountNumberType("UnitedStates") }
            };
    }
}
