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

        public List<int> GetWagonNumber1steKlasse(string Beginstation, string Eindstation, int Spoor)
        {
            return context.GetWagonNumber1steKlasse(Beginstation, Eindstation, Spoor);
        }

        public List<int> GetWagonNumber2deKlasse(string Beginstation, string Eindstation, int Spoor)
        {
            return context.GetWagonNummer2deKlasse(Beginstation, Eindstation, Spoor);
        }
    }
}

