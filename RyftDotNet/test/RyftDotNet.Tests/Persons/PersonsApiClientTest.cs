using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.Persons;
using RyftDotNet.Persons.Request;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Persons
{
    public sealed class PersonsApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly PersonsApiClient apiClient;

        private const string AccountId = TestData.AccountId;
        private readonly Person person = TestData.Person();

        public PersonsApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new PersonsApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            var request = TestData.CreatePersonRequest();
            ryftApiClient
                .RequestAsync<Person>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(person);
            await apiClient.CreateAsync(AccountId, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/persons",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = TestData.CreatePersonRequest();
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Person>()
                .ThrowsAsync(exception);
            Func<Task<Person>> action = async () => await apiClient.CreateAsync(AccountId, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = TestData.CreatePersonRequest();
            ryftApiClient
                .RequestAsync<Person>()
                .ReturnsAsync(person);
            var result = await apiClient.CreateAsync(AccountId, request);
            result.ShouldBe(person);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Person>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(person);
            await apiClient.GetAsync(AccountId, person.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/persons/{person.Id}",
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
                .RequestAsync<Person>()
                .ThrowsAsync(exception);
            Func<Task<Person>> action = async () => await apiClient.GetAsync(AccountId, person.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient
                .RequestAsync<Person>()
                .ReturnsAsync(person);
            var result = await apiClient.GetAsync(AccountId, person.Id);
            result.ShouldBe(person);
        }

        [Fact]
        public async Task UpdateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new UpdatePersonRequest { PhoneNumber = "+447900000001" };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Person>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(person);
            await apiClient.UpdateAsync(AccountId, person.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/persons/{person.Id}",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task UpdateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new UpdatePersonRequest { PhoneNumber = "+447900000001" };
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<Person>()
                .ThrowsAsync(exception);
            Func<Task<Person>> action = async () => await apiClient.UpdateAsync(AccountId, person.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new UpdatePersonRequest { PhoneNumber = "+447900000001" };
            ryftApiClient
                .RequestAsync<Person>()
                .ReturnsAsync(person);
            var result = await apiClient.UpdateAsync(AccountId, person.Id, request);
            result.ShouldBe(person);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<Person>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Person>(new List<Person>()));
            await apiClient.ListAsync(AccountId);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/persons",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListPersonsRequest { Ascending = false, Limit = 10 };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<PaginatedResponse<Person>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Person>(new List<Person>()));
            await apiClient.ListAsync(AccountId, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/persons{request.ToQueryString()}",
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
                .RequestAsync<PaginatedResponse<Person>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<Person>>> action = async () => await apiClient.ListAsync(AccountId);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<Person>(new List<Person>());
            ryftApiClient
                .RequestAsync<PaginatedResponse<Person>>()
                .ReturnsAsync(response);
            var result = await apiClient.ListAsync(AccountId);
            result.ShouldBe(response);
        }

        [Fact]
        public async Task DeleteAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<DeletedResource>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new DeletedResource(person.Id));
            await apiClient.DeleteAsync(AccountId, person.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"accounts/{AccountId}/persons/{person.Id}",
                HttpMethod.Delete,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task DeleteAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<DeletedResource>().ThrowsAsync(exception);
            Func<Task<DeletedResource>> action = async () => await apiClient.DeleteAsync(AccountId, person.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnResource_WhenSuccessful()
        {
            var deleted = new DeletedResource(person.Id);
            ryftApiClient.RequestAsync<DeletedResource>().ReturnsAsync(deleted);
            var result = await apiClient.DeleteAsync(AccountId, person.Id);
            result.ShouldBe(deleted);
        }
    }
}
