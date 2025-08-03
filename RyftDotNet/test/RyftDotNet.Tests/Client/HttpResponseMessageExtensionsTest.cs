using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RyftDotNet.Client;
using RyftDotNet.Client.Error;
using RyftDotNet.Customers;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Client
{
    public sealed class HttpResponseMessageExtensionsTest
    {
        [Fact]
        public async Task ParseResponse_ShouldThrowError_WhenStatusCodeIsNonOk_BlankBody()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            Func<Task<Customer>> action = async () => await responseMessage.ParseResponse<Customer>(HttpStatusCode.OK);
            await action.ShouldThrowAsync<RyftApiException>();
        }

        [Fact]
        public async Task ParseResponse_ShouldThrowError_WhenStatusCodeIsNonOk_BodyReturned()
        {
            var apiError = new RyftApiErrorResponse(
                Guid.NewGuid().ToString(),
                "500",
                new List<RyftApiErrorResponseElement>()
            );
            var responseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(
                    JsonUtility.Serialize(apiError),
                    Encoding.UTF8
                )
            };
            Func<Task<Customer>> action = async () => await responseMessage.ParseResponse<Customer>(HttpStatusCode.OK);
            await action.ShouldThrowAsync<RyftApiException>();
        }

        [Fact]
        public async Task ParseResponse_ShouldThrowError_WhenStatusCodeIsOk_ButBodyMissing()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            Func<Task<Customer>> action = async () => await responseMessage.ParseResponse<Customer>(HttpStatusCode.OK);
            await action.ShouldThrowAsync<RyftApiException>();
        }

        [Fact]
        public async Task ParseResponse_ShouldReturnExpectedResult_WhenStatusCodeIsOk_BodyIncluded()
        {
            var apiResource = TestData.Customer();
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(
                    JsonUtility.Serialize(apiResource),
                    Encoding.UTF8
                )
            };
            var result = await responseMessage.ParseResponse<Customer>(HttpStatusCode.OK);
            result.ShouldBe(apiResource);
        }
    }
}
