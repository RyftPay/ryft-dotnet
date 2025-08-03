using RyftDotNet.Common;

namespace RyftDotNet.Files
{
    public sealed class FileType : ConstantValue
    {
        public FileType(string value) : base(value) { }

        public static readonly FileType Csv = new FileType("Csv");
        public static readonly FileType Jpg = new FileType("Jpg");
        public static readonly FileType Png = new FileType("Png");
        public static readonly FileType Pdf = new FileType("Pdf");
    }
}
