using System;

namespace StoelVinder.lib.DAL.Models
{
    public class Travelplan
    {
        private int IDs;
        private DateTime Times;
        private string Startstations;
        private string Endstations;
        private int Railstations;
        private int Trainnrs;

        public int ID { get; set; }        
        public string Startstation { get; set; }      
        public string Endstation { get; set; } 
        public DateTime Time { get; set; }
        public int Railstation { get; set; }
        public int Trainnr { get; set; }


        public Travelplan(int id, DateTime time, int railstation, int trainnr)
        {
            this.ID = id;
            this.Time = time;
            this.Railstation = railstation;
            this.Trainnr = trainnr;
        }

        public Travelplan(string startstation, string endstation)
        {
            this.Startstation = startstation;
            this.Endstation = endstation;
           
        }

        public Travelplan()
        {

        }

        public Travelplan(int ids, DateTime times, string startstations, string endstations, int railstations, int trainnrs)
        {
            this.IDs = ids;
            this.Times = times;
            this.Startstations = startstations;
            this.Endstations = endstations;
            this.Railstations = railstations;
            this.Trainnrs = trainnrs;
        }
       
    }
}
