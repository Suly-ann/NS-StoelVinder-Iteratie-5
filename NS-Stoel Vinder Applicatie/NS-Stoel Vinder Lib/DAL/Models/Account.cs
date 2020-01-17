using System;
using System.Collections.Generic;

namespace StoelVinder.lib.DAL.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Insertion { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<Travelplan> Travelplan { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Account(int iD, string firstname, string insertion, string lastname, DateTime dateOfBirth, string email, string password, string confirmPassword)
        {
            ID = iD;
            Firstname = firstname;
            Insertion = insertion;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            List<Travelplan> travelplans = new List<Travelplan>();
            List<Ticket> tickets = new List<Ticket>();
        }

        public Account(int iD, string firstname, string insertion, string lastname, string email, string password, string confirmPassword)
        {
            ID = iD;
            Firstname = firstname;
            Insertion = insertion;
            Lastname = lastname;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public Account(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public Account(string email)
        {
            Email = email;
        }

        public Account()
        {

        }

    }
}
