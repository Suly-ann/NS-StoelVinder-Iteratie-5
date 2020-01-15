using NS_Stoel_Vinder_Applicatie.ViewModels;
using NS_Stoel_Vinder_Lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NS_Stoel_Vinder_Applicatie.Converters
{
    public class InlogViewModelConverter
    {
        public InlogModel viewModeltoAccount(InlogViewModel inlog)
        {
            InlogModel account = new InlogModel()
            {

                Email = inlog.Email,
                Password = inlog.Password

            };
            return account;
        }

        public InlogViewModel accountToViewmodel(InlogModel inlog)
        {
            InlogViewModel account = new InlogViewModel()
            {
                Email = inlog.Email,
                Password = inlog.Password

            };
            return account;
        }
    }
}
