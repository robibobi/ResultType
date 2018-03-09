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

        [Fact]
        public void From_WhenValueNull_ReturnsError()
        {
            Result<object> sut = Result.From(default(object));

            sut.ShouldBeOfType<Error<object>>();
        }

        [Fact]
        public void From_WhenValueNotNull_ReturnsSuccess()
        {
            Result<int> sut = Result.From(5);

            sut.ShouldBeOfType<Success<int>>();
        }

        [Fact]
        public void From_WhenValueNullAndCustomMessage_ReturnsErrorWithCustomMessage()
        {
            Result<object> sut = Result.From(default(object), "i knew it...");

            sut.ShouldBeOfType<Error<object>>();
            (sut as Error<object>).Message.ShouldBe("i knew it...");
        }

    }
}
