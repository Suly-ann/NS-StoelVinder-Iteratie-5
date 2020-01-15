using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Models
{
    public class Seat
    {
        public int ID { get; set; }
        public string Row { get; set; }
        public bool IsGereserveerd { get; set; } 

        public Seat(int id, string rij, bool isGereserveerd)
        {
            this.ID = id;
            this.Row = rij;
            this.IsGereserveerd = isGereserveerd;
        }

        public Seat()
        {

        }
    }
}
