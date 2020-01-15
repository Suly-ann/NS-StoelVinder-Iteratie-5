using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Stoel_Vinder_Applicatie.ViewModels
{
    public class ClassesViewModel
    {

        public int TrainClass { get; set; }
        public List<Wagon> Wagons { get; set; }

        public List<string> TrainClasses => Enum.GetValues(typeof(StoelVinder.lib.DAL.Models.TrainClass))
                        .Cast<TrainClass>()
                        .Select(v => v.ToString())
                        .ToList();

    }
}
