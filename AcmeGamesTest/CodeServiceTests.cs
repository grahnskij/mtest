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
    public class CodeServiceTests
    {
        [Fact]
        public void CodeService_NoKey()
        {
            //Arrange
            var mockService = new Mock<IDatabase>();
            var service = new CodeService(mockService.Object);
            var vm = new CodeRedeemViewModel
            {
                Code = "",
                UserAccountId = ""
            };
            mockService.Setup(serv => serv.FindGameKey(""))
                .Returns((GameKey)null);
            //Act
            var result = service.RedeemCode(vm: vm);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void CodeService_ExistingOwnership()
        {
            //Arrange
            var mockService = new Mock<IDatabase>();
            var service = new CodeService(mockService.Object);
            var vm = new CodeRedeemViewModel
            {
                Code = "",
                UserAccountId = ""
            };
            mockService.Setup(serv => serv.FindGameKey(""))
                .Returns((GameKey)null);

            mockService.Setup(serv => serv.FindOwnership(""))
                .Returns((new List<Ownership>()));
            //Act
            var result = service.RedeemCode(vm: vm);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void CodeService_success()
        {
            //Arrange
            var mockService = new Mock<IDatabase>();
            var service = new CodeService(mockService.Object);
            var vm = new CodeRedeemViewModel
            {
                Code = "",
                UserAccountId = ""
            };

            mockService.Setup(serv => serv.FindGameKey(""))
                .Returns((new GameKey { GameId = 1 , IsRedeemed = false}));

            mockService.Setup(serv => serv.FindOwnership(""))
                 .Returns((new List<Ownership>()));

            //Act
            var result = service.RedeemCode(vm: vm);
            //Assert
            Assert.True(result);
        }
    }
}
