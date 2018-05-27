using AcmeGames.Controllers;
using AcmeGames.Interfaces;
using AcmeGames.Models;
using AcmeGames.Services;
using AcmeGames.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AcmeGamesTest
{
    public class UserControllerTest
    {
        [Fact]
        public void UserController_GetUserData_BadId()
        {
            //Arrange
            var mockService = new Mock<IUserService>();
            var controller = new UserController(mockService.Object);

            //Act
            var result = controller.GetUserData(id: "");

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void UserController_GetUserData_Success()
        {
            //Arrange
            var mockService = new Mock<IUserService>();
            var controller = new UserController(mockService.Object);
            var user = new User();
            var response = new UserDataViewModel(user);
            mockService.Setup(serv => serv.GetUserData(""))
                .Returns(response);

            //Act
            var result = controller.GetUserData(id: "test");

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void UserController_UpdateUserData_BadModel()
        {
            //Arrange
            var mockService = new Mock<IUserService>();
            var controller = new UserController(mockService.Object);
            controller.ModelState.AddModelError("error", "error");

            //Act
            var result = controller.UpdateUserData(vm: null);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void UserController_UpdateUserData_BadData()
        {
            //Arrange
            var mockService = new Mock<IUserService>();
            var controller = new UserController(mockService.Object);
            var vm = new UpdateUserDataViewModel
            {
                Firstname = "",
                Lastname = "",
                Email = "a@a.se",
                OldPassword = "",
                UserAccountId = ""
            };

            mockService.Setup(serv => serv.UpdateUserData(vm))
                .Returns(false);

            //Act
            var result = controller.UpdateUserData(vm);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void UserController_UpdateUserData_Success()
        {
            //Arrange
            var mockService = new Mock<IUserService>();
            var controller = new UserController(mockService.Object);
            var vm = new UpdateUserDataViewModel
            {
                Firstname = "",
                Lastname = "",
                Email = "a@a.se",
                OldPassword = "",
                UserAccountId = ""
            };

            mockService.Setup(serv => serv.UpdateUserData(vm))
                .Returns(true);

            //Act
            var result = controller.UpdateUserData(vm);

            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
