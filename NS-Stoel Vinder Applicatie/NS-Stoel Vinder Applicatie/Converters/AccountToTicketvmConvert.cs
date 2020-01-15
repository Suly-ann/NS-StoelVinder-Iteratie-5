using NS_Stoel_Vinder_Applicatie.ViewModels;
using StoelVinder.lib.DAL.Models;
using System.Threading.Tasks;

namespace NS_Stoel_Vinder_Applicatie.Converters
{
    public class AccountToTicketvmConvert
    {
        public Account ConvertToModel(TicketViewModel tivm)
        {
            Account acc = new Account();
            {
                acc.ID = tivm.ID;
                acc.Firstname = tivm.Firstname;
                acc.Insertion = tivm.Insertion;
                acc.Lastname = tivm.Lastname;
               
            }
            return acc;
        }

        public TicketViewModel ConvertToViewModel(Account acc)
        {
            TicketViewModel tivm = new TicketViewModel();
            {
                tivm.ID = acc.ID;
                tivm.Firstname = acc.Firstname;
                tivm.Insertion = acc.Insertion;
                tivm.Lastname = acc.Lastname;
            }
            return tivm;
        }

    }
}
