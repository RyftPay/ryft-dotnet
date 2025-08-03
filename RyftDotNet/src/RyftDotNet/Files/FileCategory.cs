using RyftDotNet.Common;

namespace RyftDotNet.Files
{
    public sealed class FileCategory : ConstantValue
    {
        public FileCategory(string value) : base(value) { }

        public static readonly FileCategory Evidence = new FileCategory("Evidence");
        public static readonly FileCategory VerificationDocument = new FileCategory("VerificationDocument");
        public static readonly FileCategory Report = new FileCategory("Report");
    }
}
