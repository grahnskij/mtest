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

        public List<GamesListViewmodel> GetGamesForUser(string accountId)
        {
            var result = new List<GamesListViewmodel>();
            var owned = _db.FindOwnership(accountId);
            for(var index = 0;index<owned.Count;index++)
            {
                var game = _db.FindGame(owned[index].GameId);
                result.Add(new GamesListViewmodel
                {
                    Registered = owned[index].RegisteredDate,
                    Game = game.Name,
                    Thumb = game.Thumbnail
                });
            }
            return result;
        }
        
    }
}
