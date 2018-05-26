using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeGames.Models
{
    public class GameListItem
    {
        [Required]
        public string Game { get; set; }
        [Required]
        public string Registered { get; set; }
        [Required]
        public string Thumb { get; set; }
    }
}
