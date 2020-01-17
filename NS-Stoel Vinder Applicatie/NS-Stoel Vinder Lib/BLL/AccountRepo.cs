using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;

namespace StoelVinder.lib.BLL
{
    public class AccountRepo
    {

        private readonly IAccountContext context;

        public AccountRepo(IAccountContext context)
        {
            this.context = context;
        }

        public bool Registration(Account account)
        {
            return context.Registration(account);
        }

        public bool CheckIfEmailExist(Account account)
        {
            return context.CheckIfEmailExist(account);
        }

        public bool LogintoTravelplan(Account account)
        {
            return context.Login(account);
        }

        public bool CheckEmailAndPassword(Account account)
        {
            return context.CheckEmailAndPassword(account);
        }

        public bool DeleteAccount(Account account)
        {
            return context.DeleteAccount(account);
        }

        public bool ResetPassword(Account account)
        {
            return context.ResetPassword(account);
        }

    }
}
