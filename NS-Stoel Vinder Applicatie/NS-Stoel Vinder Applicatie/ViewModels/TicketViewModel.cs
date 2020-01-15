using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Stoel_Vinder_Applicatie.ViewModels
{
    public class TicketViewModel
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
            public int Seatnumber { get; set; }

    }
}
