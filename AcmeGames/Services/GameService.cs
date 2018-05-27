using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeGames.Data;
using AcmeGames.Interfaces;
using AcmeGames.ViewModels;

namespace AcmeGames.Services
{
    public class GameService : IGameService
    {
        private readonly IDatabase _db;

        public GameService(IDatabase db)
        {
            _db = db;
        }

        public List<GamesListViewModel> GetGamesForUser(string accountId)
        {
            var result = new List<GamesListViewModel>();
            var owned = _db.FindOwned(accountId);
            for(var index = 0;index<owned.Count;index++)
            {
                result.Add(new GamesListViewModel
                (
                    owned[index].Registered,
                    owned[index].Game,
                    owned[index].Thumb
                ));
            }
            return result;
        }
        
    }
}
