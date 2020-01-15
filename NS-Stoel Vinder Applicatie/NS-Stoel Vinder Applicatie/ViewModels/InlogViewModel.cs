using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NS_Stoel_Vinder_Applicatie.ViewModels
{
    public class InlogViewModel
    {

        [Required(ErrorMessage = "Vul uw e-mailadres in")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mailadres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vul uw wachtwoord in")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }
    }
}
