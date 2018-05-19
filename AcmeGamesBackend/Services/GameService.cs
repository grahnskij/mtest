using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcmeGames.Data;
using AcmeGames.Interfaces;

namespace AcmeGames.Services
{
    public class GameService : IGameService
    {
        private readonly IDatabase _db;

        public GameService(IDatabase db)
        {
            _db = db;
        }

        
    }
}
