using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Models
{
    public class Wagon
    {
        public int ID { get; set; }
        public int Wagonnumber { get; set; }
        public int TrainClass { get; set; }
        public bool Toilet { get; set; }
        public List<Seat> Seats { get; set; }

        public Wagon(int id, int wagonnummer, int trainclass, bool toilet)
        {
            ID = id;
            Wagonnumber = wagonnummer;
            TrainClass = trainclass;
            Toilet = toilet;
            List<Seat> seats = new List<Seat>();
        }

        public Wagon(int wagonnummer, int trainclass, bool toilet)
        {
            Wagonnumber = wagonnummer;
            TrainClass = trainclass;
            Toilet = toilet;
        }

        public Wagon()
        {

        }
    }
}
