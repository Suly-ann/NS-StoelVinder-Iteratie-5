using System;

namespace StoelVinder.lib.DAL.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Insertion { get; set; }
        public string Lastname { get; set; }
        public double Price { get; set; } = 15;
        public string Startstation { get; set; }
        public string Endstation { get; set; }
        public DateTime Time { get; set; }
        public int TrainClass { get; set; }
        public string Row { get; set; }
        public int SeatID { get; set; }

        public Ticket(int iD, string firstname, string insertion, string lastname, double price, string startstation, string endstation, DateTime time, int trainClass, string row, int seatid)
        {
            ID = iD;
            Firstname = firstname;
            Insertion = insertion;
            Lastname = lastname;
            Price = price;
            Startstation = startstation;
            Endstation = endstation;
            Time = time;
            TrainClass = trainClass;
            Row = row;
            SeatID = seatid;
        }

        public Ticket()
        {

        }
    }
}
