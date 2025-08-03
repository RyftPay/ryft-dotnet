using RyftDotNet.Accounts;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Accounts
{
    public sealed class AccountCapabilityStatusTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(AccountCapabilityStatus actual, AccountCapabilityStatus expected)
            => actual.ShouldBe(expected);

        public static TheoryData<AccountCapabilityStatus, AccountCapabilityStatus> ExpectedValues() =>
            new TheoryData<AccountCapabilityStatus, AccountCapabilityStatus>
            {
                { AccountCapabilityStatus.NotRequested, new AccountCapabilityStatus("NotRequested") },
                { AccountCapabilityStatus.Pending, new AccountCapabilityStatus("Pending") },
                { AccountCapabilityStatus.Disabled, new AccountCapabilityStatus("Disabled") },
                { AccountCapabilityStatus.Enabled, new AccountCapabilityStatus("Enabled") }
            };
    }
}
