using System;
using System.ComponentModel.DataAnnotations;
using AcmeGames.ViewModels;

namespace AcmeGames.Models
{
	public class User
	{
        [Required]
        public string	UserAccountId { get; set; }
        [Required]
        public string	FirstName { get; set; }
        [Required]
        public string	LastName { get; set; }
	    public string   FullName => $"{FirstName} {LastName}";
        public DateTime	DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        public string	EmailAddress { get; set; }
        [Required]
        public string	Password { get; set; }
        [Required]
        public bool		IsAdmin { get; set; }

        public User()
        {

        }

        public void Update(UpdateUserDataViewModel vm) 
        {
            FirstName = vm.Firstname;
            LastName = vm.Lastname;
            EmailAddress = vm.Email;
            if(!String.IsNullOrWhiteSpace(vm.NewPassword))
            {
                Password = vm.NewPassword;
            }
        }
	}
}
