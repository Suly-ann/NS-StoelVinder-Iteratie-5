using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface IWagonContext
    {
        List<int> GetWagonNumber();
        List<int> GetWagonNumber1steKlasse();
        List<int> GetWagonNummer2deKlasse();
    }
}
