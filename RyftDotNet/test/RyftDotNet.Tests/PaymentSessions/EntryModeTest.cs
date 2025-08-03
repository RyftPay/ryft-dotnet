using RyftDotNet.PaymentSessions;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.PaymentSessions
{
    public sealed class EntryModeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(EntryMode actual, EntryMode expected)
            => actual.ShouldBe(expected);

        public static TheoryData<EntryMode, EntryMode> ExpectedValues() =>
            new TheoryData<EntryMode, EntryMode>
            {
                { EntryMode.Online, new EntryMode("Online") },
                { EntryMode.Moto, new EntryMode("MOTO") }
            };
    }
}
