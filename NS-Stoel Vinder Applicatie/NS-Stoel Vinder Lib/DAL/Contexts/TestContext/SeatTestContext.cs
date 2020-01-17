using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext
{
    public class SeatTestContext : ISeatContext
    {
        readonly Seat seat = new Seat(4, "A", false);

        public List<Seat> GetAllSeat1steKlasse(Travelplan travelplan)
        {
            throw new NotImplementedException();
            //    Travelplan station = travelplan;
            //    List<Travelplan> Stations = new List<Travelplan>();
            //    if (station.Startstation == reisplan.Startstation && station.Endstation == reisplan.Endstation)
            //    {
            //        Stations.Add(station);
            //    }
            //    return Stations;
        }

        public List<Seat> GetAllSeat2deKlasse(Travelplan travelplan)
        {

            throw new NotImplementedException();
            //    Travelplan station = travelplan;
            //    List<Travelplan> Stations = new List<Travelplan>();
            //    if (station.Startstation == reisplan.Startstation && station.Endstation == reisplan.Endstation)
            //    {
            //        Stations.Add(station);
            //    }
            //    return Stations;
        }

        public bool IsReserved(Seat seats)
        {
            if (seat.ID == seats.ID && seat.Row == seats.Row && seat.IsReserved == seats.IsReserved)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
