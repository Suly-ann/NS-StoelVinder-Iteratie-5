using System;

namespace StoelVinder.lib.DAL.Models
{
    public class Ticket

    {

        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Insertion { get; set; }
        public string Lastname { get; set; }
        public double Price { get; set; }
        public string Startstation { get; set; }
        public string Endstation { get; set; }
        public DateTime Time { get; set; }
        public int TrainClass { get; set; }
        public int Row { get; set; }
        public int Seatnumber { get; set; }
       

        //public double calculatePrice(double price)
        //{
        //    return 0;
        //}

        public Ticket()
        {

        }
    }
}
