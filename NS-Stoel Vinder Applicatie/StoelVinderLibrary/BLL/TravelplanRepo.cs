using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System.Collections.Generic;

namespace StoelVinder.lib.BLL
{
    public class TravelplanRepo
    {
        private readonly ITravelplanContext context;
        public TravelplanRepo(ITravelplanContext context)
        {
            this.context = context;
        }

        public List<Station> GetStationsOnly()
        {
            return context.GetStationsOnly();
        }

        public List<Travelplan> GetTravelplans(string Beginstation, string Eindstation)
        {
            return context.GetTravelplans(Beginstation, Eindstation);
        }

        //internal object GetTravelplans(string Beginstation, string Eindstation)
        //{
        //    return context.GetTravelplans(Beginstation, Eindstation);
        //}
       
    }
}
