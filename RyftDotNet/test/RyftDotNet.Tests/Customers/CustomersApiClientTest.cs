using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Common;
using RyftDotNet.Customers;
using RyftDotNet.Customers.Request;
using RyftDotNet.PaymentMethods;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Customers
{
    public sealed class CustomersApiClientTest
    {
        private readonly Mock<IRyftApiClient> ryftApiClient;
        private readonly CustomersApiClient apiClient;

        private readonly Customer customer = TestData.Customer();

        public CustomersApiClientTest()
        {
            ryftApiClient = new Mock<IRyftApiClient>();
            apiClient = new CustomersApiClient(ryftApiClient.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new CreateCustomerRequest("test@ryftpay.com");
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Customer>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(customer);
            await apiClient.CreateAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                "customers",
                HttpMethod.Post,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task CreateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new CreateCustomerRequest("test@ryftpay.com");
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Customer>().ThrowsAsync(exception);
            Func<Task<Customer>> action = async () => await apiClient.CreateAsync(request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new CreateCustomerRequest("test@ryftpay.com");
            ryftApiClient.RequestAsync<Customer>().ReturnsAsync(customer);
            var result = await apiClient.CreateAsync(request);
            result.ShouldBe(customer);
        }

        [Fact]
        public async Task GetAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Customer>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(customer);
            await apiClient.GetAsync(customer.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"customers/{customer.Id}",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Customer>().ThrowsAsync(exception);
            Func<Task<Customer>> action = async () => await apiClient.GetAsync(customer.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnResource_WhenSuccessful()
        {
            ryftApiClient.RequestAsync<Customer>().ReturnsAsync(customer);
            var result = await apiClient.GetAsync(customer.Id);
            result.ShouldBe(customer);
        }

        [Fact]
        public async Task UpdateAsync_ShouldIssueRequestWithExpectedArguments()
        {
            var request = new UpdateCustomerRequest { HomePhoneNumber = "+447900000000" };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<Customer>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(customer);
            await apiClient.UpdateAsync(customer.Id, request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"customers/{customer.Id}",
                HttpMethodExtensions.Patch,
                HttpStatusCode.OK,
                request
            ));
        }

        [Fact]
        public async Task UpdateAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var request = new UpdateCustomerRequest { HomePhoneNumber = "+447900000000" };
            var exception = new RyftApiException("uh oh");
            ryftApiClient.RequestAsync<Customer>().ThrowsAsync(exception);
            Func<Task<Customer>> action = async () => await apiClient.UpdateAsync(customer.Id, request);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnResource_WhenSuccessful()
        {
            var request = new UpdateCustomerRequest { HomePhoneNumber = "+447900000000" };
            ryftApiClient.RequestAsync<Customer>().ReturnsAsync(customer);
            var result = await apiClient.UpdateAsync(customer.Id, request);
            result.ShouldBe(customer);
        }

        [Fact]
        public async Task DeleteAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient
                .RequestAsync<DeletedResource>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new DeletedResource(customer.Id));
            await apiClient.DeleteAsync(customer.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"customers/{customer.Id}",
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
            Func<Task<DeletedResource>> action = async () => await apiClient.DeleteAsync(customer.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnResource_WhenSuccessful()
        {
            var deleted = new DeletedResource(customer.Id);
            ryftApiClient.RequestAsync<DeletedResource>().ReturnsAsync(deleted);
            var result = await apiClient.DeleteAsync(customer.Id);
            result.ShouldBe(deleted);
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<Customer>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Customer>(
                    new List<Customer> { customer }
                ));
            await apiClient.ListAsync();
            arguments.ShouldBe(new ExpectedRequestArguments(
                "customers",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task ListAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            var request = new ListCustomersRequest
            {
                Ascending = false,
                Limit = 10,
                StartsAfter = customer.Id
            };
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<PaginatedResponse<Customer>>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new PaginatedResponse<Customer>(
                    new List<Customer> { customer }
                ));
            await apiClient.ListAsync(request);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"customers{request.ToQueryString()}",
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
                .RequestAsync<PaginatedResponse<Customer>>()
                .ThrowsAsync(exception);
            Func<Task<PaginatedResponse<Customer>>> action = async () => await apiClient.ListAsync();
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task ListAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new PaginatedResponse<Customer>(new List<Customer> { customer });
            ryftApiClient.RequestAsync<PaginatedResponse<Customer>>().ReturnsAsync(response);
            var result = await apiClient.ListAsync();
            result.ShouldBe(response);
        }

        [Fact]
        public async Task GetCustomerPaymentMethodsAsync_ShouldIssueRequestWithExpectedArguments()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<CustomerPaymentMethods>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new CustomerPaymentMethods { Items = new List<PaymentMethod>() });
            await apiClient.GetCustomerPaymentMethodsAsync(customer.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"customers/{customer.Id}/payment-methods",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetCustomerPaymentMethodsAsync_ShouldIssueRequestWithExpectedArguments_WhenQueryParamsProvided()
        {
            ExpectedRequestArguments? arguments = null;
            ryftApiClient.RequestAsync<CustomerPaymentMethods>()
                .RecordInvokedArguments(args => arguments = args)
                .ReturnsAsync(new CustomerPaymentMethods { Items = new List<PaymentMethod>() });
            await apiClient.GetCustomerPaymentMethodsAsync(customer.Id);
            arguments.ShouldBe(new ExpectedRequestArguments(
                $"customers/{customer.Id}/payment-methods",
                HttpMethod.Get,
                HttpStatusCode.OK,
                null
            ));
        }

        [Fact]
        public async Task GetCustomerPaymentMethodsAsync_ShouldPropagateException_WhenUnderlyingClientThrows()
        {
            var exception = new RyftApiException("uh oh");
            ryftApiClient
                .RequestAsync<CustomerPaymentMethods>()
                .ThrowsAsync(exception);
            Func<Task<CustomerPaymentMethods>> action = async () => await apiClient.GetCustomerPaymentMethodsAsync(customer.Id);
            var thrown = await action.ShouldThrowAsync<RyftApiException>();
            thrown.ShouldBeSameAs(exception);
        }

        [Fact]
        public async Task GetCustomerPaymentMethodsAsync_ShouldReturnResource_WhenSuccessful()
        {
            var response = new CustomerPaymentMethods { Items = new List<PaymentMethod> { TestData.PaymentMethod() } };
            ryftApiClient.RequestAsync<CustomerPaymentMethods>().ReturnsAsync(response);
            var result = await apiClient.GetCustomerPaymentMethodsAsync(customer.Id);
            result.ShouldBe(response);
        }
    }
}
