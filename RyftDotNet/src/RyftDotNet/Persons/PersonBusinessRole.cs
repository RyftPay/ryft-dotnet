using RyftDotNet.Common;

namespace RyftDotNet.Persons
{
    public sealed class PersonBusinessRole : ConstantValue
    {
        public PersonBusinessRole(string value) : base(value) { }

        public static readonly PersonBusinessRole BusinessContact = new PersonBusinessRole("BusinessContact");
        public static readonly PersonBusinessRole Director = new PersonBusinessRole("Director");
        public static readonly PersonBusinessRole UltimateBeneficialOwner =
            new PersonBusinessRole("UltimateBeneficialOwner");
    }
}
