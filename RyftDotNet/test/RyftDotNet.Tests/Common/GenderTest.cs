using RyftDotNet.Common;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Common
{
    public sealed class GenderTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(Gender actual, Gender expected)
            => actual.ShouldBe(expected);

        public static TheoryData<Gender, Gender> ExpectedValues() =>
            new TheoryData<Gender, Gender>
            {
                { Gender.Male, new Gender("Male") },
                { Gender.Female, new Gender("Female") }
            };
    }
}
