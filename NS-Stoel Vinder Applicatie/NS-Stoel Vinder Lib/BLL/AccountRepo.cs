using NS_Stoel_Vinder_Lib.DAL.Models;
using StoelVinder.lib.DAL.Interfaces;

namespace StoelVinder.lib.BLL
{
    public class AccountRepo
    {

        private readonly IAccountContext context;

        public AccountRepo(IAccountContext context)
        {
            this.context = context;
        }


        //public bool Login(Account login)
        //{
        //    return context.Login(login);
        //}

        //public bool Login(InlogViewModel login)
        //{
        //    return context.Login(login.Email, login.Password);
        //}

        public bool Registration(RegistrationModel registration)
        {
            return context.Registration(registration.Firstname, registration.Insertion, registration.Lastname, registration.DateOfBirth, registration.Email, registration.Password);
        }

        public bool CheckIfEmailExist(string email)
        {
            return context.CheckIfEmailExist(email);
        }

        public bool LogintoTravelplan(InlogModel login)
        {
            return context.Login(login.Email, login.Password);
        }

        public bool CheckEmailAndPassword(string email, string password)
        {
            return context.CheckEmailAndPassword(email, password);
        }

        public bool DeleteAccount(Delete delete)
        {
            return context.DeleteAccount(delete.Email, delete.Password);
        }

        public bool ResetPassword(ResetPasswordModel reset)
        {
            return context.ResetPassword(reset.Email, reset.Password);
        }

    }
}
