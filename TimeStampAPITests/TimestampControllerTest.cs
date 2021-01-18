using System;
using Xunit;

using TimeStampAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TimeStampAPITests
{
    public class TimestampControllerTest
    {
        TimestampController controllerUnderTest;

        [Fact]
        public void GetWithValidDateStrReturnsValidUnixTime()
        {
            controllerUnderTest = new TimestampController();

            var expectedResult = "1451001600000";
            var result = controllerUnderTest.Get("2015-12-25");

            Assert.Equal(expectedResult, result.Value.Unix);
        }

        [Fact]
        public void GetWithValidDateStrReturnsValidDateString()
        {
            controllerUnderTest = new TimestampController();

            var expectedResult = "Fri, 25 Dec 2015 00:00:00 GMT";
            var result = controllerUnderTest.Get("2015-12-25");

            Assert.Equal(expectedResult, result.Value.Utc);
        }

        [Fact]
        public void GetWithValidUnixStrReturnsValidUnixTime()
        {
            controllerUnderTest = new TimestampController();

            var expectedResult = "1451001600000";
            var result = controllerUnderTest.Get("1451001600000");

            Assert.Equal(expectedResult, result.Value.Unix);
        }

        [Fact]
        public void GetWithValidUnixStrReturnsValidDateString()
        {
            controllerUnderTest = new TimestampController();

            var expectedResult = "Fri, 25 Dec 2015 00:00:00 GMT";
            var result = controllerUnderTest.Get("1451001600000");

            Assert.Equal(expectedResult, result.Value.Utc);
        }

        [Fact]
        public void GetWithInvalidDateReturnsBadRequestAndError()
        {
            controllerUnderTest = new TimestampController();

            var expectedResult = new { error = "Invalid Date" };
            var result = controllerUnderTest.Get("I like cookies");

            Assert.IsType<BadRequestObjectResult>(result.Result);

            var objectResult = (BadRequestObjectResult)result.Result;

            Assert.Equal(expectedResult.ToString(), objectResult.Value.ToString());
        }
    }
}
