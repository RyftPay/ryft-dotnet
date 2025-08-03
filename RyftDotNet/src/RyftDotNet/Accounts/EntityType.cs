using RyftDotNet.Common;

namespace RyftDotNet.Accounts
{
    public sealed class EntityType : ConstantValue
    {
        public EntityType(string value) : base(value) { }

        public static readonly EntityType Business = new EntityType("Business");
        public static readonly EntityType Individual = new EntityType("Individual");
    }
}
