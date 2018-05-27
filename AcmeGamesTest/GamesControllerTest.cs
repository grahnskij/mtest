using AcmeGames.Controllers;
using AcmeGames.Interfaces;
using AcmeGames.Services;
using AcmeGames.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace AcmeGamesTest
{
    public class GamesControllerTest
    {
        [Fact]
        public void GamesController_BadId()
        {
            //Arrange
            var mockService = new Mock<IGameService>();
            var controller = new GamesController(mockService.Object);

            //Act
            var result = controller.GetUserGamesList(id: "");

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void GamesController_Success()
        {
            //Arrange
            var mockService = new Mock<IGameService>();
            var controller = new GamesController(mockService.Object);
            var response = new List<GamesListViewModel>();
            mockService.Setup(serv => serv.GetGamesForUser(""))
                .Returns(response);

            //Act
            var result = controller.GetUserGamesList(id: "test");

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
