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
    public class CodeControllerTests
    {
        [Fact]
        public void CodeController_BadModel()
        {
            //Arrange
            var mockService = new Mock<ICodeService>();
            var controller = new CodeController(mockService.Object);
            controller.ModelState.AddModelError("error", "error");

            //Act
            var result = controller.RedeemCode(vm: null);
            
            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void CodeController_BadData()
        {
            //Arrange
            var vm = new CodeRedeemViewModel
            {
                UserAccountId = "1",
                Code = "1"
            };
            var mockService = new Mock<ICodeService>();
            mockService.Setup(serv => serv.RedeemCode(vm))
                .Returns(false);
            var controller = new CodeController(mockService.Object);

            //Act
            var result = controller.RedeemCode(vm: vm);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void CodeController_RedeemCode()
        {
            //Arrange
            var vm = new CodeRedeemViewModel{
                  UserAccountId = "1",
                  Code = "1"
            };
            var mockService = new Mock<ICodeService>();
            mockService.Setup(serv => serv.RedeemCode(vm))
                .Returns(true);
            var controller = new CodeController(mockService.Object);

            //Act
            var result = controller.RedeemCode(vm: vm);

            //Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
