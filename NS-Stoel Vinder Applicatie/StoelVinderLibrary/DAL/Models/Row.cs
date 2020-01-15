using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Models
{
    public class Row
    {
        public int ID { get; set; }
        public string RowLetter { get; set; }
        public List<Seat> Seats { get; set; }
    }
}
