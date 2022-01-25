using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using TestApplication.Controllers;
using Xunit;

namespace TestApplication.Test.Controller
{
    public class HomeControllerTest
    {
        [Fact]
        public void ErrorShouldReturnView()
        {
            //Arange
            var mock = new Mock<ILogger<HomeController>>();
            ILogger<HomeController> logger = mock.Object;

            var homeController = new HomeController(logger, null);

            //Act
            var result = homeController.Error();

            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);

        }
    }
}
