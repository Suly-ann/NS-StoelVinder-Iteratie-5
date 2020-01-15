using NS_Stoel_Vinder_Applicatie.ViewModels;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Contexts;
using StoelVinder.lib.DAL.Models;

namespace NS_Stoel_Vinder_Applicatie.Converter
{
    public class AccountViewModelConverter
    {
        public Account viewModeltoAccount(RegistrationViewModel registrationView)
        {
            Account account = new Account()
            {
                Firstname = registrationView.Firstname,
                Insertion = registrationView.Insertion,
                Lastname = registrationView.Lastname,
                Email = registrationView.Email,
                Password = registrationView.Password

            };
           return account;
        }

        public Account accountToViewmodel(InlogViewModel inlogView)
        {
            Account account = new Account()
            {
                Email = inlogView.Email,
                Password = inlogView.Password

            };
            return account;
        }

        public Account LogintoDelete(RegistrationViewModel del)
        {
            Account account = new Account()
            {
                Firstname = del.Firstname,               
                Email = del.Email,
            };
            return account;
        }

       
        public Account accountToResetViewmodel(ResetPasswordViewModel resetView)
        {
            Account account = new Account()
            {
                Email = resetView.Email,
                Password = resetView.Password

            };
            return account;
        }

        public Account accountToDeleteViewmodel(DeleteViewModel delView)
        {
            Account account = new Account()
            {
                Email = delView.Email,
                Password = delView.Password

            };
            return account;
        }

    }
}
