using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext
{
    public class TravelplanTestContext: ITravelplanContext
    {
        readonly Travelplan travelplan = new Travelplan(1,  "Beginstation", "Eindstation", DateTime.Today, 11, 5462);

        public List<Station> GetStationsOnly()
        {
            Station station = new Station();
            List<Station> Stations = new List<Station>
            {
                station
            };
            return Stations;
        }

        public List<Travelplan> GetTravelplans(Travelplan reisplan)
        {
            Travelplan station = travelplan;
            List<Travelplan> Stations = new List<Travelplan>();
            if(station.Startstation == reisplan.Startstation && station.Endstation == reisplan.Endstation)
            {
                Stations.Add(station);               
            }
            return Stations;
        }
    }
}
