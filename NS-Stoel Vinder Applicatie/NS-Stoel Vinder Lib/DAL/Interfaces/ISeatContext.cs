using StoelVinder.lib.DAL.Models;
using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface ISeatContext
    {
        bool IsReserved(Seat seat);
        List<Seat> GetAllSeat1steKlasse(Travelplan travelplan/*, int Wagonnummer*/);
        List<Seat> GetAllSeat2deKlasse(Travelplan travelplan);

    }
}
