namespace RyftDotNet.InPerson.Products
{
    public sealed class InPersonProductStatus : Common.ConstantValue
    {
        public InPersonProductStatus(string value) : base(value) { }

        public static readonly InPersonProductStatus Available = new InPersonProductStatus("Available");
        public static readonly InPersonProductStatus Unavailable = new InPersonProductStatus("Unavailable");
    }
}
