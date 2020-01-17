using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Models
{
    public class Train
    {
        public int ID { get; set; }
        public int Trainnumber { get; set; }
        public int Constructionyear { get; set; }
        public List<Wagon> Wagons { get; set; }

        public Train(int iD, int trainnumber, int constructionyear)
        {
            ID = iD;
            Trainnumber = trainnumber;
            Constructionyear = constructionyear;
            List<Wagon> wagons = new List<Wagon>();
        }

        public Train()
        {

        }

    }

}
