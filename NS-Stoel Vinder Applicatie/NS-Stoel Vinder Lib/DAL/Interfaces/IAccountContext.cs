using StoelVinder.lib.DAL.Models;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface IAccountContext
    {
        bool Login(Account account);
        
        bool Registration(Account account);

        bool CheckIfEmailExist(Account account);

        bool CheckEmailAndPassword(Account account);

        bool DeleteAccount(Account account);

        bool ResetPassword(Account account);      

    }
}
