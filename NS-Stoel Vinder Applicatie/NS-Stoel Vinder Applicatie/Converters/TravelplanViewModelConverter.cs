using NS_Stoel_Vinder_Applicatie.ViewModels;
using StoelVinder.lib.DAL.Models;

namespace NS_Stoel_Vinder_Applicatie.Converter
{
    public class TravelplanViewModelConverter
    {
        public  Travelplan ConvertToModel(TimesViewModel tvm)
        {
            Travelplan tp = new Travelplan();
            {
                tp.Time = tvm.Time;
                tp.Railstation = tvm.Railstation;
                tp.Trainnr = tvm.Trainnr;
            }
            return tp;
        }

        public TimesViewModel ConvertToViewModel(Travelplan tp)
        {
            TimesViewModel tvm = new TimesViewModel();
            {
                tvm.Time = tp.Time;
                tvm.Railstation = tp.Railstation;
                tvm.Trainnr = tp.Trainnr;
            }
            return tvm;
        }

    }
}
