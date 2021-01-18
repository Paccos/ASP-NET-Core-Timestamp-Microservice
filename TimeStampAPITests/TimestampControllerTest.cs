using System;
using Xunit;

using TimeStampAPI.Controllers;
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
        }
    }
}
