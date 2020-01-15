using StoelVinder.lib.DAL.Interfaces;
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

        public List<int> GetWagonNumber1steKlasse()
        {
            return context.GetWagonNumber1steKlasse();
        }

        public List<int> GetWagonNumber2deKlasse()
        {
            return context.GetWagonNummer2deKlasse();
        }
    }
}
