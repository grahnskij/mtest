using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeGames.ViewModels
{
    public class UpdateUserDataViewModel
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Birth { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string NewPasswordConfirm { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string UserAccountId { get; set; }
    }
}
