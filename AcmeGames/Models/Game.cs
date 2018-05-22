using System.ComponentModel.DataAnnotations;

namespace AcmeGames.Models
{
	public class Game
	{
		public uint?	AgeRestriction { get; set; }
        [Required]
        public uint		GameId { get; set; }
        [Required]
        public string	Name { get; set; }
        [Required]
        public string	Thumbnail { get; set; }
	}
}
