using NS_Stoel_Vinder_Lib.DAL;
using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System;

namespace NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext
{
    public class AccountTestContext : IAccountContext
    {
        readonly Account account = new Account(1, "Coen", "van de", "Berg", DateTime.Today, "Emailadres", "Persoon123", "Persoon123");
        
        public bool CheckEmailAndPassword(Account emailandpassword)
        {
            if (account.Email == emailandpassword.Email && account.Password == emailandpassword.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfEmailExist(Account emailexist)
        {

            if (account.Email == emailexist.Email)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAccount(Account deleteaccount)
        {
            if (account.Email == deleteaccount.Email && account.Password == deleteaccount.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Login(Account loginaccount)
        {
              if(account.Email == loginaccount.Email && account.Password == loginaccount.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Registration(Account registrationaccount)
        {           
            if (account.Firstname == registrationaccount.Firstname &&
                account.Insertion == registrationaccount.Insertion &&
                account.Lastname == registrationaccount.Lastname &&
                account.DateOfBirth == registrationaccount.DateOfBirth &&
                account.Email == registrationaccount.Email && 
                account.Password == registrationaccount.Password &&
                account.ConfirmPassword == registrationaccount.ConfirmPassword)

            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool ResetPassword(Account resetaccount)
        {
            if (account.Email == resetaccount.Email && account.Password == resetaccount.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
