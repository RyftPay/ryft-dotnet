using System.Net.Mime;
using RyftDotNet.Client.Error;

namespace RyftDotNet.Utility
{
    internal static class FileUtility
    {
        internal static string GetContentType(string fileExtension) => fileExtension switch
        {
            ".csv" => "text/csv",
            ".png" => "image/png",
            ".jpg" => MediaTypeNames.Image.Jpeg,
            ".jpeg" => MediaTypeNames.Image.Jpeg,
            ".pdf" => MediaTypeNames.Application.Pdf,
            _ => throw new RyftArgumentException($"Unsupported file extension: {fileExtension}")
        };
    }
}
