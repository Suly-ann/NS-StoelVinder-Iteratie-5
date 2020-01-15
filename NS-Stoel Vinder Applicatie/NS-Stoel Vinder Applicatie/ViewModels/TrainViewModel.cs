using StoelVinder.lib.DAL.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NS_Stoel_Vinder_Applicatie.ViewModels
{
    public class TrainViewModel
    {
        public int TrainClass { get; set; }
        public bool Toilet { get; set; }

        [Required(ErrorMessage = "Kies een wagon")]
        public List<int> Wagonnumber { get; set; }
        public List<Seat> Seats { get; set; }
        public Train Train { get; set; }
        public int Trainnumber { get; set; }
    }
}

