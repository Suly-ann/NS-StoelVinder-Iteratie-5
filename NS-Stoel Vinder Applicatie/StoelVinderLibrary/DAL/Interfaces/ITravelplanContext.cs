using StoelVinder.lib.DAL.Models;
using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface ITravelplanContext 
    {
        List<Station> GetStationsOnly();
        List<Travelplan> GetTravelplans(string Beginstation, string Eindstation);
      

    }

}
