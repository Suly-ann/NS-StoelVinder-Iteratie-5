using System;
using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Models
{
    public class Travelplan
    {
        public int ID { get; set; }        
        public string Startstation { get; set; }      
        public string Endstation { get; set; } 
        public DateTime Time { get; set; }
        public int Railstation { get; set; }
        public int Trainnr { get; set; }
        public List<Account> Accounts { get; set; }

        public Travelplan(int iD, string startstation, string endstation, DateTime time, int railstation, int trainnr)
        {           
            ID = iD;
            Startstation = startstation;
            Endstation = endstation;
            Time = time;
            Railstation = railstation;
            Trainnr = trainnr;
            List<Account> accounts = new List<Account>();
        }

        public Travelplan(string startstations, string endstations)
        {
            Startstation = startstations;
            Endstation = endstations;
        }

        public Travelplan(string startstations, string endstations, int railstation)
        {
            Startstation = startstations;
            Endstation = endstations;
            Railstation = railstation;
        }
        public Travelplan(DateTime time, int railstation, int trainnr)
        {
            Time = time;
            Railstation = railstation;
            Trainnr = trainnr;
        }

        public Travelplan()
        {

        }
       
    }
}
