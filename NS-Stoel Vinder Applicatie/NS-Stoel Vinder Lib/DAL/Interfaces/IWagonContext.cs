using StoelVinder.lib.DAL.Models;
using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface IWagonContext
    {
        List<int> GetWagonNumber();
        List<int> GetWagonNumber1steKlasse(string Beginstation, string Eindstation, int Spoor);
        List<int> GetWagonNummer2deKlasse(string Beginstation, string Eindstation, int Spoor);
    }
}
