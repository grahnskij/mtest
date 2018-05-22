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
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string FullName => $"{Firstname} {Lastname}";
        [Required]
        public string Birth { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string UserAccountId { get; set; }

        public LoginDataViewModel(User user)
        {
            Firstname = user.FirstName;
            Lastname = user.LastName;
            Birth = user.DateOfBirth.ToString("yyyy-MM-dd");
            UserAccountId = user.UserAccountId;
            Email = user.EmailAddress;
            Role = user.IsAdmin ? "Admin" : "User";
        }
    }
}
