using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using StoelVinder.lib.DAL.Models;

namespace NS_Stoel_Vinder_Applicatie.ViewModels
{
    public class HistoryViewModel
    {
            public int ID { get; set; }
            public string Firstname { get; set; }
            public string Insertion { get; set; }
            public string Lastname { get; set; }
            public double Price { get; set; }      
            public string Startstation { get; set; }
            public string Endstation { get; set; }
            public DateTime Time { get; set; }
            public int TrainClass { get; set; }
            public int Row { get; set; }
            public Seat SeatID { get; set; }
        
    }
}
