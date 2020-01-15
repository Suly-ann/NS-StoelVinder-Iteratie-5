using NS_Stoel_Vinder_Applicatie.ViewModels;
using NS_Stoel_Vinder_Lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Stoel_Vinder_Applicatie.Converters
{
    public class ResetPasswordViewModelConverter
    {
        public ResetPasswordModel viewModeltoAccount(ResetPasswordViewModel reset)
        {
            ResetPasswordModel account = new ResetPasswordModel()
            {
                
                Email = reset.Email,
                Password = reset.Password

            };
            return account;
        }

        public ResetPasswordViewModel accountToViewmodel(ResetPasswordModel reset)
        {
            ResetPasswordViewModel account = new ResetPasswordViewModel()
            {
                Email = reset.Email,
                Password = reset.Password

            };
            return account;
        }
    }
}
