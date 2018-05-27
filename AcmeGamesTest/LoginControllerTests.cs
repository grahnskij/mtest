using AcmeGames.Controllers;
using AcmeGames.Interfaces;
using AcmeGames.Services;
using AcmeGames.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace AcmeGamesTest
{
    public class LoginControllerTests
    {
        [Fact]
        public void LoginController_BadModel()
        {
            //Arrange
            var mockService = new Mock<ILoginService>();
            var controller = new LoginController(mockService.Object);
            controller.ModelState.AddModelError("error", "error");

            //Act
            var result = controller.Authenticate(aAuthRequest: null);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void LoginController_BadPassword()
        {
            //Arrange
            var mockService = new Mock<ILoginService>();
            var controller = new LoginController(mockService.Object);
            var vm = new AuthRequestViewModel
            {
                EmailAddress = "",
                Password = ""
            };

            mockService.Setup(serv => serv.Login(vm))
                .Returns((LoginDataViewModel)null);

            //Act
            var result = controller.Authenticate(aAuthRequest: vm);

            //Assert
            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public void LoginController_IsAuthorized()
        {
            //Arrange
            var mockService = new Mock<ILoginService>();
            var controller = new LoginController(mockService.Object);
            var vm = new AuthRequestViewModel
            {
                EmailAddress = "",
                Password = ""
            };

            var response = new LoginDataViewModel("aaaaaa", "aaaaaaaaaaa");

            mockService.Setup(serv => serv.Login(vm))
                .Returns(response);

            //Act
            var result = controller.Authenticate(aAuthRequest: vm);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
