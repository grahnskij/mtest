using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AcmeGames.Models;

namespace AcmeGames.ViewModels
{
    public class LoginDataViewModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public string UserAccountId { get; set; }

        public LoginDataViewModel(string token, string userId)
        {
            Token = token;
            UserAccountId = userId;
        }
    }
}
