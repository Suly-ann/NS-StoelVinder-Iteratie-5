using NS_Stoel_Vinder_Applicatie.ViewModels;
using NS_Stoel_Vinder_Lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_Stoel_Vinder_Applicatie.Converters
{
    public class RegistrationViewModelConverter
    {
        public RegistrationModel viewModeltoAccount(RegistrationViewModel rvm)
        {
            RegistrationModel account = new RegistrationModel()
            {
                Firstname = rvm.Firstname,
                Insertion = rvm.Insertion,
                Lastname = rvm.Lastname,
                DateOfBirth = rvm.DateOfBirth,
                Email = rvm.Email,
                Password = rvm.Password

            };
            return account;
        }

        public RegistrationViewModel accountToViewmodel(RegistrationModel registration)
        {
            RegistrationViewModel account = new RegistrationViewModel()
            {
                Firstname = registration.Firstname,
                Insertion = registration.Insertion,
                Lastname = registration.Lastname,
                DateOfBirth = registration.DateOfBirth,
                Email = registration.Email,
                Password = registration.Password

            };
            return account;
        }
    }
}
