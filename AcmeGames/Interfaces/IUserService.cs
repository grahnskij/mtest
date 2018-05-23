using AcmeGames.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeGames.Interfaces
{
    public interface IUserService
    {
        UserDataViewModel GetUserData(string accountId);
        void UpdateUserData(UpdateUserDataViewModel vm);
    }
}
