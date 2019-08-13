using System;
using WebAPISample.Controllers;
using Xunit;

namespace WebAPITest
{
    public class GreetingControllerFixture
    {
        private GreetingController _greeting = new GreetingController();
        [Fact]
        public void Test_For_Hi()
        {
            var response = _greeting.Get("hi").Value;
            Assert.Equal("hello", response);
        }

        [Fact]
        public void Test_For_Hello()
        {
            var response = _greeting.Get("hello").Value;
            Assert.Equal("hi", response);
        }

        [Fact]
        public void Test_For_Garbage()
        {
            var response = _greeting.Get("garbageValue").Value;
            Assert.Equal("Invalid", response);
        }
    }
}
