using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeGames.Models;
using AcmeGames.Data;
using AcmeGames.Interfaces;
using AcmeGames.ViewModels;

namespace AcmeGames.Services
{
    public class LoginService : ILoginService
    {
        private readonly IDatabase _db;

        public LoginService(IDatabase db)
        {
            _db = db;
        }

        public LoginDataViewModel Login(string email, string password)
        {
            var user = _db.FindUser(email, password);
            return new LoginDataViewModel(user);
        }
    }
}
