using ASP_.NET_CORE_AdamFreeman.Controllers;
using ASP_.NET_CORE_AdamFreeman.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class HomeControllerTests
    {
        class FakeRepository : IRepository
        {
            public IEnumerable<GuestResponse> Responses { get; set; } 
            public void AddResponse(GuestResponse response)
            {

            }
        }
        [Theory]
        [InlineData("a@gmail.com", "b@gmail.com", "c@gmail.com", "d@gmail.com", "e@gmail.com")]
        [InlineData("ali@gmail.com", "bli@gmail.com", "cli@gmail.com", "dli@gmail.com", "eli@gmail.com")]
        public void IndexActionModellsComplete(string e1, string e2, string e3, string e4, string e5)
        {
            // Arrange
            var controller = new HomeController();
            controller.Repository = new FakeRepository()
            {
                Responses = new GuestResponse[]
                {
                    new GuestResponse{Name = "Ali",Email = e1,Phone = "112233", WillAttend = true},
                    new GuestResponse{Name = "Bli",Email = e2,Phone = "112244", WillAttend = true},
                    new GuestResponse{Name = "Cli",Email = e3,Phone = "112255", WillAttend = true},
                    new GuestResponse{Name = "Dli",Email = e4,Phone = "112266", WillAttend = true},
                    new GuestResponse{Name = "Eli",Email = e5,Phone = "112277", WillAttend = true}
                }
            };
            // Act
            var model = (controller.ListResponses() as ViewResult)?.ViewData.Model
                as IEnumerable<GuestResponse>;
            // Assert
            Assert.Equal(controller.Repository.Responses, model,
            Comparer.Get<GuestResponse>((rl, r2) => rl.Name == r2.Name
            && rl.Email == r2.Email));
        }
        [Theory]
        [ClassData(typeof(GuestResponseTestData))]
        public void IndexActionModellsComplete2(GuestResponse[] parm)
        {
            // Arrange
            var controller = new HomeController();
            controller.Repository = new FakeRepository()
            {
                Responses = parm
            };
            // Act
            var model = (controller.ListResponses() as ViewResult)?.ViewData.Model
                as IEnumerable<GuestResponse>;
            // Assert
            Assert.Equal(controller.Repository.Responses, model,
            Comparer.Get<GuestResponse>((rl, r2) => rl.Name == r2.Name
            && rl.Email == r2.Email));
        }
        class PropertyOnceFakeRepository : IRepository
        {
            public int Counter = 0;
            public IEnumerable<GuestResponse> Responses
            {
                get
                {
                    Counter++;
                    return new GuestResponse[] { new GuestResponse { Name = "A", Email = "E", Phone = "1", WillAttend = true } };
                }
            }

            public void AddResponse(GuestResponse response)
            {
            }
        }
        [Fact]
        public void TestCounter()
        {
            //Arrange
            var Repo = new PropertyOnceFakeRepository();
            var controller = new HomeController() { Repository = Repo };
            //Act
            var result = controller.ListResponses();
            //Assert
            Assert.Equal(1, Repo.Counter);
        }
        [Fact]
        public void IndexActionModellsComplete3()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Responses).Returns(new GuestResponse[] { new GuestResponse { Name = "f", Email = "g", Phone = "u", WillAttend = true } });
            var controller = new HomeController();
            controller.Repository = mock.Object;
            // Act
            var model = (controller.ListResponses() as ViewResult)?.ViewData.Model
                as IEnumerable<GuestResponse>;
            // Assert
            Assert.Equal(controller.Repository.Responses, model,
            Comparer.Get<GuestResponse>((rl, r2) => rl.Name == r2.Name
            && rl.Email == r2.Email));
        }
        [Fact]
        public void TestCounter2()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Responses).Returns(new GuestResponse[] { new GuestResponse { Name = "" } });
            var controller = new HomeController();
            controller.Repository = mock.Object;
            //Act
            var result = controller.ListResponses();
            //Assert
            mock.VerifyGet(m => m.Responses, Times.Once);
        }
        [Fact]
        public void Testik()
        {
            Assert.Equal(2, 4);
        }
    }
}
