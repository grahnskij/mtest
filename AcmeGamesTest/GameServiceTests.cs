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
    public class GameServiceTests
    {
        [Fact]
        public void GameService_NoResult()
        {
            //Arrange
            var mockService = new Mock<IDatabase>();
            var service = new GameService(mockService.Object);
  
            mockService.Setup(serv => serv.FindOwned("1"))
                .Returns((new List<GameListItem>()));
            //Act
            var result = service.GetGamesForUser(accountId: "1");
            //Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GameService_PopulatedResult()
        {
            //Arrange
            var mockService = new Mock<IDatabase>();
            var service = new GameService(mockService.Object);
            var response = new List<GameListItem>();
            response.Add(new GameListItem
            {
                Registered = "reg",
                Game = "game",
                Thumb = "tumme"
            });

            mockService.Setup(serv => serv.FindOwned("1"))
                .Returns(response);
            //Act
            var result = service.GetGamesForUser(accountId: "1");
            //Assert
            Assert.Collection(result, item => Assert.Contains("reg", item.Registered));
            Assert.Collection(result, item => Assert.Contains("game", item.Game));
            Assert.Collection(result, item => Assert.Contains("tumme", item.Thumb));
            Assert.Single(result);
        }
    }
}
