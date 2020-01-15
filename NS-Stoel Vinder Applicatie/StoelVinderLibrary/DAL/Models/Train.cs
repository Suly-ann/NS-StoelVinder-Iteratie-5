using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Models
{
    public class Train
    {
        public int ID { get; set; }
        public int Trainnumber { get; set; }
        public int Constructionyear { get; set; }
        public List<Wagon> Wagons { get; set; }

        public Train()
        {

        }

    }

}
