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
    }
}
