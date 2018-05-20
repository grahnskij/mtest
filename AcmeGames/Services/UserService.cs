using AcmeGames.Interfaces;
using AcmeGames.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeGames.Services
{
    public class UserService : IUserService
    {
        private readonly IDatabase _db;

        public UserService(IDatabase db)
        {
            _db = db;
        }

        public UserDataViewModel GetUserData(string accountId)
        {
            var user = _db.GetUserData(accountId);
            return new UserDataViewModel
            {
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Birth = user.DateOfBirth.ToString("yyyy-MM-dd"),
                Email = user.EmailAddress,
                Role = user.IsAdmin ? "Admin" : "User",
                Password = user.Password
            };
        }
    }
}
