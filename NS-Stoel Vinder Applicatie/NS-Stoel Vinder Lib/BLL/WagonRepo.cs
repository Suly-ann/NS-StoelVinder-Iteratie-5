using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System.Collections.Generic;

namespace StoelVinder.lib.BLL
{
    public class WagonRepo
    {
        private readonly IWagonContext context;


        public WagonRepo(IWagonContext context)
        {
            this.context = context;
        }

        public List<int> GetWagonNumber()
        {
            return context.GetWagonNumber();
        }

        public List<int> GetWagonNumber1steKlasse(Travelplan travelplan)
        {
            return context.GetWagonNumber1steKlasse(travelplan);
        }

        public List<int> GetWagonNumber2deKlasse(Travelplan travelplan)
        {
            return context.GetWagonNummer2deKlasse(travelplan);
        }
    }
}

