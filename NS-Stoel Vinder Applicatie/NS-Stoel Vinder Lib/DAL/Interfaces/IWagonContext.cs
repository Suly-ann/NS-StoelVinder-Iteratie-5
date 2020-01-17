using StoelVinder.lib.DAL.Models;
using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface IWagonContext
    {
        List<int> GetWagonNumber();
        List<int> GetWagonNumber1steKlasse(Travelplan travelplan);
        List<int> GetWagonNummer2deKlasse(Travelplan travelplan);
    }
}
