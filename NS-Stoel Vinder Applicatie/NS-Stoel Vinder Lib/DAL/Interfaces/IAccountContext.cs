﻿using System;

namespace StoelVinder.lib.DAL.Interfaces
{
    public interface IAccountContext
    {
        //bool Login(Account login);

        bool Login(string email, string password);
        
        bool Registration(string firstname, string insertion, string lastname, DateTime dateofbirth, string email, string password);

        bool CheckIfEmailExist(string email);

        bool CheckEmailAndPassword(string email, string password);

        //bool DeleteAccount(string firstname, string email);

        bool DeleteAccount(string email, string password);

        bool ResetPassword(string email, string password);

      

    }
}