using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface ISeatContext
    {
        bool SeatPosition(Seat seat);
        bool IsReserved(Seat seat);
        List<Seat> GetAllSeat1steKlasse(string Beginstation, string Eindstation, int Spoor);
        List<Seat> GetAllSeat2deKlasse(string Beginstation, string Eindstation, int Spoor);

    }
}
