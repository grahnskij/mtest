using AcmeGames.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeGames.Interfaces
{
    public interface ILoginService
    {
        LoginDataViewModel Login(string email, string password);
    }
}
