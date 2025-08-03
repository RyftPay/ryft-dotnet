using RyftDotNet.Accounts;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Accounts
{
    public sealed class EntityTypeTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(EntityType actual, EntityType expected)
            => actual.ShouldBe(expected);

        public static TheoryData<EntityType, EntityType> ExpectedValues() =>
            new TheoryData<EntityType, EntityType>
            {
                { EntityType.Business, new EntityType("Business") },
                { EntityType.Individual, new EntityType("Individual") }
            };
    }
}
