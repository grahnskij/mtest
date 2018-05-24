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
            return new UserDataViewModel(user);
        }

        public bool UpdateUserData(UpdateUserDataViewModel vm)
        {
            var passConfirm = _db.CheckPassword(vm.UserAccountId, vm.OldPassword);

            if(passConfirm)
            {
                _db.UpdateUserData(vm);
                return true;
            }else
            {
                return false;
            } 
        }
    }
}
