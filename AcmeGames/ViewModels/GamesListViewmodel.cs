using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeGames.ViewModels
{
    public class GamesListViewModel
    {
        [Required]
        public string Game { get; set; }
        [Required]
        public string Registered { get; set; }
        [Required]
        public string Thumb { get; set; }

        public GamesListViewModel(string reg, string game, string thumb)
        {
            Registered = reg;
            Game = game;
            Thumb = thumb;
        }
    }
}
