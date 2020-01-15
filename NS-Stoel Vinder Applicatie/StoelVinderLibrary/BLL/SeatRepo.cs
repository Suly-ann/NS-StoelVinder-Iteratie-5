using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;

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

       
    }
}
