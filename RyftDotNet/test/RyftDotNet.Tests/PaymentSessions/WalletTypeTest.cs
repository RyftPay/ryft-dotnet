using RyftDotNet.PaymentSessions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class WalletTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(WalletType actual, WalletType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<WalletType, WalletType> ExpectedValues() =>
            new TheoryData<WalletType, WalletType>
            {
                { WalletType.ApplePay, new WalletType("ApplePay") },
                { WalletType.GooglePay, new WalletType("GooglePay") }
            };
    }
}
