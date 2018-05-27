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
    public class UserServiceTests
    {
        [Fact]
        public void UserService_GetUserData_PopulatedResult()
        {
            //Arrange
            var mockService = new Mock<IDatabase>();
            var service = new UserService(mockService.Object);
            var dateString = "2018-01-01";
            var response = new User
            {
                UserAccountId = "1",
                FirstName = "",
                LastName = "",
                EmailAddress = "a@a.se",
                Password = "",
                IsAdmin = false,
                DateOfBirth = Convert.ToDateTime(dateString)
            };


            mockService.Setup(serv => serv.GetUserData("1"))
                .Returns(response);
            //Act
            var result = service.GetUserData(accountId: "1");
            //Assert
            Assert.IsType<UserDataViewModel>(result);
            Assert.Equal(result.Password, response.Password);
            Assert.Equal(result.Firstname, response.FirstName);
            Assert.Equal(result.Lastname, response.LastName);
            Assert.Equal(result.Email, response.EmailAddress);
            Assert.Equal(result.Birth, response.DateOfBirth.ToString("yyyy-MM-dd"));
        }

        [Fact]
        public void UserService_GetUserData_EmptyResult()
        {
            //Arrange
            var mockService = new Mock<IDatabase>();
            var service = new UserService(mockService.Object);

            mockService.Setup(serv => serv.GetUserData("1"))
                .Returns((User)null);
            //Act
            var result = service.GetUserData(accountId: "1");
            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void UserService_UpdateUserData_PasswordFail()
        {
            //Arrange
            var mockService = new Mock<IDatabase>();
            var service = new UserService(mockService.Object);
            var vm = new UpdateUserDataViewModel
            {
                UserAccountId = "1",
                Firstname = "",
                Lastname = "",
                Email = "a@a.se",
                OldPassword = "",
            };
            mockService.Setup(serv => serv.CheckPassword("", ""))
                .Returns(false);

            //Act
            var result = service.UpdateUserData(vm: vm);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void UserService_UpdateUserData_PasswordSuccess()
        {
            //Arrange
            var mockService = new Mock<IDatabase>();
            var service = new UserService(mockService.Object);

            var vm = new UpdateUserDataViewModel
            {
                UserAccountId = "1",
                Firstname = "",
                Lastname = "",
                Email = "a@a.se",
                OldPassword = "pw",
            };

            mockService.Setup(serv => serv.CheckPassword(vm.UserAccountId, vm.OldPassword))
                .Returns(true);

            mockService.Setup(serv => serv.UpdateUserData(vm));
               
            //Act
            var result = service.UpdateUserData(vm: vm);
            //Assert
            Assert.True(result);
        }
    }
}
