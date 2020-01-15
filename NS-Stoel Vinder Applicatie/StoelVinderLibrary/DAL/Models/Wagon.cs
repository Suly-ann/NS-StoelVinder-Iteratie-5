using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Models
{
    public enum TrainClass { FirstClass, SecondClass };
    public class Wagon
    {
       
        public int ID { get; set; }
        public int Wagonnumber { get; set; }
        //public int TrainClass { get; set; }
        public bool Toilet { get; set; }
        public List<Row> Rows { get; set; }

        public Wagon()
        {

        }
    }
}
