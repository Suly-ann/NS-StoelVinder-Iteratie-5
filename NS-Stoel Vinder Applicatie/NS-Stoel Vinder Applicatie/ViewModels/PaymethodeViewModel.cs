using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NS_Stoel_Vinder_Applicatie.ViewModels
{
    public class PaymethodeViewModel

    {

        [Required(ErrorMessage = "Kies een wagon")]
        public List<int> Paymethode { get; set; }

    }
}
