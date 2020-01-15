using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NS_Stoel_Vinder_Applicatie.ViewModels
{
    public class TravelplanViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Kies uw reisstations")]
        public List<Station> Stations { get; set; }

        [Required(ErrorMessage = "Kies uw startstation")]
        [DataType(DataType.Text)]
        public string Beginstation { get; set; }

        [Required(ErrorMessage = "Kies uw eindstation")]
        [DataType(DataType.Text)]
        public string Eindstation { get; set; }

        public DateTime Time { get; set; }

        public Account AccountTeVerwijderen { get; set; }

        public InlogViewModel inlogID { get; set; }

        public List<Account> acs { get; set; }


        //public Startstation Startstation

        public TravelplanViewModel()
        {

        }


    }
}
