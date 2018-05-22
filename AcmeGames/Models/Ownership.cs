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
	}
}
