using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.Files;
using RyftDotNet.Files.Request;
using Shouldly;
using Xunit;
using File = RyftDotNet.Files.File;

namespace RyftDotNet.Tests.Files
{
    public sealed class FilesApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly FilesApiClient apiClient;

        private readonly File file = TestData.File();

        public FilesApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new FilesApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            MultipartFormDataRequestArguments? arguments = null;
            var request = TestData.CreateFileRequest();
            ryftApiClient
                .PostMultipartFormDataAsync<File>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(file);
            await apiClient.CreateAsync(request);
            arguments.ShouldNotBeNull();
            arguments.ShouldSatisfyAllConditions(
                a => a.Path.ShouldBe("files"),
                a => a.HttpStatusCode.ShouldBe(HttpStatusCode.OK)
            );
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = TestData.CreateFileRequest();
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .PostMultipartFormDataAsync<File>()
                .ThrowsAsync(exception);
            Func<Task<File>> action = async () => await apiClient.CreateAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = TestData.CreateFileRequest();
            ryftApiClient
                .PostMultipartFormDataAsync<File>()
                .ReturnsAsync(file);
            var result = await apiClient.CreateAsync(request);
            result.ShouldBe(file);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<File>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(file);
            await apiClient.GetAsync(file.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"files/{file.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<File>()
                .ThrowsAsync(exception);
            Func<Task<File>> action = async () => await apiClient.GetAsync(file.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<File>()
                .ReturnsAsync(file);
            var result = await apiClient.GetAsync(file.Id);
            result.ShouldBe(file);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<File>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<File>(new List<File>()));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "files",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListFilesRequest { Ascending = false, Limit = 10 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<File>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<File>(new List<File>()));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"files{request.ToQueryString()}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<PaginatedResponse<File>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<File>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<File>(new List<File> { TestData.File() });
            ryftApiClient
                .RequestAsync<PaginatedResponse<File>>()
                .ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }
    }
}
