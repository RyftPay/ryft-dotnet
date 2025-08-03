using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using RyftDotNet.Utility;

namespace RyftDotNet.Files.Request
{
    public sealed class CreateFileRequest
    {
        public Stream File { get; }
        public string FileName { get; }
        public string ContentType { get; }
        public FileCategory Category { get; }
        public IDictionary<string, string>? Metadata { get; set; }

        private const string MultiPartFileKey = "file";
        private const string MultiPartCategoryKey = "category";
        private const string MultiPartMetadataKey = "metadata";

        public CreateFileRequest(
            Stream file,
            string fileName,
            string contentType,
            FileCategory category)
        {
            File = file;
            FileName = fileName;
            ContentType = contentType;
            Category = category;
        }

        internal MultipartFormDataContent ToMultipartFormDataContent()
        {
            var formData = new MultipartFormDataContent();
            var fileContent = new StreamContent(File);
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(ContentType);
            formData.Add(fileContent, name: MultiPartFileKey, FileName);
            formData.Add(new StringContent(Category.Value), MultiPartCategoryKey);
            if (Metadata != null)
            {
                foreach (var metadata in Metadata)
                {
                    formData.Add(
                        content: new StringContent(metadata.Value),
                        name: $"{MultiPartMetadataKey}[{metadata.Key}]"
                    );

                }
            }
            return formData;
        }

        public static CreateFileRequest Create(
            FileStream stream,
            FileCategory category,
            IDictionary<string, string>? metadata = null)
            => new CreateFileRequest(
                stream,
                Path.GetFileName(stream.Name),
                FileUtility.GetContentType(
                    Path.GetExtension(stream.Name)
                ),
                category
            )
            { Metadata = metadata };
    }
}
