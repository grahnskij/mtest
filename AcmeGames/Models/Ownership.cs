using System.ComponentModel.DataAnnotations;

namespace AcmeGames.Models
{
	public class Ownership
	{
        [Required]
        public uint				GameId { get; set; }
        [Required]
        public uint				OwnershipId { get; set; }
        [Required]
        public string			RegisteredDate { get; set; }
        [Required]
        public OwnershipState	State { get; set; }
        [Required]
        public string			UserAccountId { get; set; }

        public Ownership(uint gameId, uint id, string date, OwnershipState state, string accountId)
        {
            GameId = gameId;
            OwnershipId = id;
            RegisteredDate = date;
            State = state;
            UserAccountId = accountId;
        }
	}
}
