using ASP_.NET_CORE_AdamFreeman.Models;
using Xunit;

namespace Tests
{
    public class ResponseTest
    {
        [Fact]
        public void ChangeName()
        {
            //Arrange
            var obj = new GuestResponse
            {
                Name = "Antonio",
                Email = "a@gmail.com",
                Phone = "3740149",
                WillAttend = true
            };
            //Act
            obj.Name = "Ali";
            //Assert
            Assert.Equal("Ali", obj.Name);
        }

    }
}
