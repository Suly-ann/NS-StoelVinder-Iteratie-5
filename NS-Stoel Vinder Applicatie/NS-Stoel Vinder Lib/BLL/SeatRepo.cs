using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
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

        public bool IsReserved(Seat seat)
        {
            return context.IsReserved(seat);
        }

        public List<Seat> GetAllSeat1steKlasse(Travelplan travelplan/*, int Wagonnummer*/)
        {
            return context.GetAllSeat1steKlasse(travelplan/*, Wagonnummer*/);
        }

        public List<Seat> GetAllSeat2deKlasse(Travelplan travelplan)
        {
            return context.GetAllSeat2deKlasse(travelplan);
        }
    }
}
