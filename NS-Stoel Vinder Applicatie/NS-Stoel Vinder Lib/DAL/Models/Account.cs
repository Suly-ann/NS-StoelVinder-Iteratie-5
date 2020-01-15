using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

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

        public Account(int iD, string firstname, string insertion, string lastname, string email, string password)
        {
            ID = iD;
            Firstname = firstname;
            Insertion = insertion;
            Lastname = lastname;
            Email = email;
            Password = password;
        }

        public Account()
        {

        }

    }
}
