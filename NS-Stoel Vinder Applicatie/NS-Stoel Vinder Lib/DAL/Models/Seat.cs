using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Models
{
    public class Seat
    {
        public int ID { get; set; }
        public string Row { get; set; }
        public bool IsReserved { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Seat(int id, string row, bool isReserved)
        {
            ID = id;
            Row = row;
            IsReserved = isReserved;
            List<Ticket> tickets = new List<Ticket>();
        }

        public Seat(int id)
        {
            ID = id;
        }

        public Seat()
        {

        }
    }
}
