using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NS_Stoel_Vinder_Applicatie.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Vul uw e-mailadres in")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vul een geldige e-mailadres in")]
        [StringLength(50)]
        [Display(Name = "E-mailadres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vul uw wachtwoord in")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$", ErrorMessage = "Eerste letter moet hoofdletter zijn. Wachtwoord kan een cijfer en een symbool hebben")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Wachtwoord moet minimaal 6 character hebben")]
        [Display(Name = "Nieuwe Wachtwoord")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vul nogmaals wachtwoord in")]

        [DataType(DataType.Password)]
        [Display(Name = "Nieuwe Wachtwoord bevestigen")]
        [Compare("Password", ErrorMessage = "Wachtwoord komt niet overeen")]
        public string ConfirmPassword { get; set; }
    }

}
