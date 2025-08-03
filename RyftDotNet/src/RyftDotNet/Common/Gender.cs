namespace RyftDotNet.Common
{
    public sealed class Gender : ConstantValue
    {
        public Gender(string value) : base(value) { }

        public static readonly Gender Male = new Gender("Male");
        public static readonly Gender Female = new Gender("Female");
    }
}
