using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeGames.ViewModels
{
    public class CodeRedeemViewModel
    {
        [Required]
        public string UserAccountId { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
