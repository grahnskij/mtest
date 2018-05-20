using AcmeGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeGames.Interfaces
{
    public interface IDatabase
    {
        User FindUser(string email, string password);
        User GetUserData(string accountId);
        List<Ownership> FindOwnership(string userAccountId);
        Game FindGame(uint gameId);
    }
}
