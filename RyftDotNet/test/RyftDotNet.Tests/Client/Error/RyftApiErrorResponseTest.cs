using System.Collections.Generic;
using System.IO;
using RyftDotNet.Client.Error;
using RyftDotNet.Utility;
using Shouldly;
using Xunit;

namespace RyftDotNet.Tests.Client.Error
{
    public sealed class RyftApiErrorResponseTest
    {
        [Fact]
        public void FromJson_ShouldReturnExpectedValue()
        {
            string json = File.ReadAllText("assets/errors/response.json");
            JsonUtility.Deserialize<RyftApiErrorResponse>(json).ShouldBe(new RyftApiErrorResponse(
                "b83f2653-06d7-44a9-a548-5825e8186004",
                "500",
                new List<RyftApiErrorResponseElement>
                {
                    new RyftApiErrorResponseElement(
                        "unexpected_error",
                        "There was an unexpected error during the request"
                    ),
                    new RyftApiErrorResponseElement(
                        "unexpected_error",
                        "Something went wrong downstream"
                    )
                }
            ));
        }
    }
}
