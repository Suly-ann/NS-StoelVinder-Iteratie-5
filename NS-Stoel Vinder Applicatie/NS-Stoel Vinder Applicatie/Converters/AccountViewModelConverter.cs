using NS_Stoel_Vinder_Applicatie.ViewModels;
using StoelVinder.lib.DAL.Models;

namespace NS_Stoel_Vinder_Applicatie.Converter
{
    public class AccountViewModelConverter
    {
        public Account ViewModeltoAccount(AccountViewModel accountViewModel)
        {
            Account account = new Account()
            {
                Firstname = accountViewModel.Firstname,
                Insertion = accountViewModel.Insertion,
                Lastname = accountViewModel.Lastname,
                Email = accountViewModel.Email,
                Password = accountViewModel.Password,
                ConfirmPassword = accountViewModel.ConfirmPassword

            };
           return account;
        }

        public AccountViewModel AccounttoViewModel(Account account)
        {
            AccountViewModel accountViewModel = new AccountViewModel()
            {
                Firstname = account.Firstname,
                Insertion = account.Insertion,
                Lastname = account.Lastname,
                Email = account.Email,
                Password = account.Password,
                ConfirmPassword = account.ConfirmPassword

            };
            return accountViewModel;
        }

        public Account AccountToViewmodel(InlogViewModel inlogView)
        {
            Account account = new Account()
            {
                Email = inlogView.Email,
                Password = inlogView.Password

            };
            return account;
        }
                      
        public Account AccountToResetViewmodel(ResetPasswordViewModel resetView)
        {
            Account account = new Account()
            {
                Email = resetView.Email,
                Password = resetView.Password

            };
            return account;
        }

        public Account AccountToDeleteViewmodel(DeleteViewModel delView)
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
