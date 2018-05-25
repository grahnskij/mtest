using System.ComponentModel.DataAnnotations;

namespace AcmeGames.Models
{
	public class GameKey
	{
        [Required]
        public uint		GameId { get; set; }
        [Required]
        public string	Key { get; set; }
        [Required]
        public bool		IsRedeemed { get; set; }

        public void Redeem()
        {
            IsRedeemed = true;
        }
    }
}
