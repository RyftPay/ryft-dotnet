using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Language.Flow;
using RyftDotNet.Client;

namespace RyftDotNet.Tests
{
    internal static class MoqExtensions
    {
        internal static ISetup<IRyftApiClient, Task<T>> RequestAsync<T>(
            this Mock<IRyftApiClient> ryftApiClient) where T : class
            => ryftApiClient.Setup(c => c.RequestAsync<T>(
                It.IsAny<string>(),
                It.IsAny<HttpMethod>(),
                It.IsAny<object?>(),
                It.IsAny<ClientRequestSettings?>(),
                It.IsAny<HttpStatusCode>(),
                default
            ));

        internal static ISetup<IRyftApiClient, Task<T>> PostMultipartFormDataAsync<T>(
            this Mock<IRyftApiClient> ryftApiClient) where T : class
            => ryftApiClient.Setup(c => c.PostMultipartFormDataAsync<T>(
                It.IsAny<string>(),
                It.IsAny<MultipartFormDataContent>(),
                It.IsAny<ClientRequestSettings?>(),
                It.IsAny<HttpStatusCode>(),
                default
            ));

        internal static ISetup<IRyftApiClient, Task<T>> RecordInvokedArguments<T>(
            this ISetup<IRyftApiClient, Task<T>> setup,
            Action<ExpectedRequestArguments> innerCallback)
        {
            setup.Callback<string, HttpMethod, object?, ClientRequestSettings?, HttpStatusCode, CancellationToken>(
                (url, method, body, settings, statusCode, ct) =>
                {
                    innerCallback(new ExpectedRequestArguments(url, method, statusCode, body));
                });
            return setup;
        }

        internal static ISetup<IRyftApiClient, Task<T>> RecordInvokedArguments<T>(
            this ISetup<IRyftApiClient, Task<T>> setup,
            Action<MultipartFormDataRequestArguments> innerCallback)
        {
            setup.Callback<string, MultipartFormDataContent, ClientRequestSettings?, HttpStatusCode, CancellationToken>(
                (url, formData, settings, statusCode, ct) =>
                {
                    innerCallback(new MultipartFormDataRequestArguments(url, formData, statusCode));
                });
            return setup;
        }
    }
}
