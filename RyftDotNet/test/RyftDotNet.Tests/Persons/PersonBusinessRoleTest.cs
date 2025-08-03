using RyftDotNet.Persons;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Persons
{
    public sealed class PersonBusinessRoleTest
    {
        [Theory, MemberData(nameof(ExpectedValues))]
        public void StaticValues_ShouldReturnExpectedValue(PersonBusinessRole actual, PersonBusinessRole expected)
            => actual.ShouldBe(expected);

        public static TheoryData<PersonBusinessRole, PersonBusinessRole> ExpectedValues() =>
            new TheoryData<PersonBusinessRole, PersonBusinessRole>
            {
                { PersonBusinessRole.BusinessContact, new PersonBusinessRole("BusinessContact") },
                { PersonBusinessRole.Director, new PersonBusinessRole("Director") },
                { PersonBusinessRole.UltimateBeneficialOwner, new PersonBusinessRole("UltimateBeneficialOwner") }
            };
    }
}
