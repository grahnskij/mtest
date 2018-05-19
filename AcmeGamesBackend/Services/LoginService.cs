using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeGames.Models;
using AcmeGames.Data;
using AcmeGames.Interfaces;

namespace AcmeGames.Services
{
    public class LoginService : ILoginService
    {
        private readonly IDatabase _db;

        public LoginService(IDatabase db)
        {
            _db = db;
        }

        public User Login(string email, string password)
        {
            return _db.FindUser(email, password);
        }
    }
}
