using Shouldly;
using System;
using Xunit;

namespace Tcoc.UnitTests
{
    public class ResultTests
    {
        [Fact]
        public void CreateSuccess_WithValue5_ReturnsSuccessInt5()
        {
            Success<int> sut = Result.CreateSuccess(5);

            sut.Value.ShouldBe(5);
        }

        [Fact] 
        public void CreateError_MessageGetsSet()
        {
            Error<int> error = Result.CreateError<int>("Oh oh...");

            error.Message.ShouldBe("Oh oh...");
        }

    }
}
