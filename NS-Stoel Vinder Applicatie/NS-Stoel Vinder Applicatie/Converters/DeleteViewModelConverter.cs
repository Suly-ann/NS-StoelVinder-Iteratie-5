using NS_Stoel_Vinder_Applicatie.ViewModels;
using NS_Stoel_Vinder_Lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Stoel_Vinder_Applicatie.Converters
{
    public class DeleteViewModelConverter
    {
        public Delete viewModeltoAccount(DeleteViewModel dvm)
        {
            Delete del = new Delete()
            {

                Email = dvm.Email,
                Password = dvm.Password

            };
            return del;
        }

        public DeleteViewModel accountToViewmodel(Delete del)
        {
            DeleteViewModel dvm = new DeleteViewModel()
            {
                Email = del.Email,
                Password = del.Password

            };
            return dvm;
        }
    }
}
