using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Stoel_Vinder_Applicatie.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Vul uw e-mailadres in")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mailadres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vul uw nieuwe wachtwoord in")]
        [DataType(DataType.Password)]
        [Display(Name = " Nieuwe wachtwoord")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vul nogmaals nieuwe wachtwoord in")]

        [DataType(DataType.Password)]
        [Display(Name = "Nieuwe wachtwoord bevestigen")]
        [Compare("Password", ErrorMessage = "Wachtwoord komt niet overeen")]
        public string ConfirmPassword { get; set; }
    }
}
