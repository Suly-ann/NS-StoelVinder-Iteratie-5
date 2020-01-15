using StoelVinder.lib.DAL.Models;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface ISeatContext
    {
        bool SeatPosition(Seat seat);

        bool IsReserved(Seat seat);
    }
}
