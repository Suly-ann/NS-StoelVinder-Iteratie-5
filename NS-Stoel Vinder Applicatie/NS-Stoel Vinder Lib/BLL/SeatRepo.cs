using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;

namespace StoelVinder.lib.BLL
{
    public class SeatRepo
    {
        private readonly ISeatContext context;

        public SeatRepo(ISeatContext context)
        {
            this.context = context;
        }

        public bool SeatPosition(Seat seat)
        {
            return context.SeatPosition(seat);
        }

        public bool IsReserved(Seat seat)
        {
            return context.IsReserved(seat);
        }

        public List<Seat> GetAllSeat1steKlasse(string Beginstation, string Eindstation, int Spoor)
        {
            return context.GetAllSeat1steKlasse(Beginstation, Eindstation, Spoor);
        }

        public List<Seat> GetAllSeat2deKlasse(string Beginstation, string Eindstation, int Spoor)
        {
            return context.GetAllSeat2deKlasse(Beginstation, Eindstation, Spoor);
        }
    }
}
