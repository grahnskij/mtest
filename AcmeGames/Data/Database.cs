using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AcmeGames.Models;
using Newtonsoft.Json;
using System.Linq;
using AcmeGames.Interfaces;

namespace AcmeGames.Data
{
	public class Database : IDatabase
	{
        private static readonly Random          locRandom       = new Random();

		private static IEnumerable<Game>		locGames		= new List<Game>();
		private static IEnumerable<GameKey>		locKeys			= new List<GameKey>();
		private static IEnumerable<Ownership>	locOwnership	= new List<Ownership>();
		private static IEnumerable<User>		locUsers		= new List<User>();

	    public Database()
		{
			locGames		= JsonConvert.DeserializeObject<IEnumerable<Game>>(File.ReadAllText(@"Data\games.json"));
			locKeys			= JsonConvert.DeserializeObject<IEnumerable<GameKey>>(File.ReadAllText(@"Data\keys.json"));
			locUsers		= JsonConvert.DeserializeObject<IEnumerable<User>>(File.ReadAllText(@"Data\users.json"));
			locOwnership	= JsonConvert.DeserializeObject<IEnumerable<Ownership>>(File.ReadAllText(@"Data\ownership.json"));
		}

	    // NOTE: This accessor function must be used to access the data.
	    private Task<IEnumerable<T>>PrivGetData<T>(IEnumerable<T>  aDataSource)
	    {
	        //var delay = locRandom.Next(150, 1000);
            //Thread.Sleep(TimeSpan.FromMilliseconds(delay));

	        return Task.FromResult(aDataSource);
	    }

        public User FindUser(string email, string password)
        {   
            return PrivGetData(locUsers).Result.SingleOrDefault(user => user.EmailAddress == email && user.Password == password);
        }

        public User GetUserData(string accountId)
        {
            return PrivGetData(locUsers).Result.SingleOrDefault(user => user.UserAccountId == accountId);
        }

        public List<Ownership> FindOwnership(string userAccountId)
        {
            return PrivGetData(locOwnership).Result
                .Where(ownership => ownership.UserAccountId == userAccountId)
                .ToList();
        }

        public Game FindGame(uint gameId)
        {
            return PrivGetData(locGames).Result
                .FirstOrDefault(game => game.GameId == gameId);
        }



      
	}
}
