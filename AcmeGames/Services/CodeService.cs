using AcmeGames.Interfaces;
using AcmeGames.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeGames.Services
{
    public class CodeService : ICodeService
    {
        private readonly IDatabase _db;

        public CodeService(IDatabase db)
        {
            _db = db;
        }

        public bool RedeemCode(CodeRedeemViewModel vm)
        {
            var key = _db.FindGameKey(vm.Code);
            if (key == null)
            {
                return false;
            }

            var ownership = _db.FindOwnership(vm.UserAccountId).FirstOrDefault(owned => owned.GameId == key.GameId);
            if (ownership != null)
            {
                return false;
            }

            key.Redeem();
            _db.NewOwnership(key.GameId, DateTime.Today.ToString("yyyy-MM-dd"), Models.OwnershipState.Owned, vm.UserAccountId);
            return true;
        }
    }
}
