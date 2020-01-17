using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace NS_Stoel_Vinder_Applicatie.ViewModels
{
    public class TimesViewModel
    {
        public int TravelplanID { get; set; }

        [Required(ErrorMessage = "Kies een reistijd")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public int Railstation { get; set; }
        public int Trainnr { get; set; }
        public List<Travelplan> Trt { get; set; }

    }
}
