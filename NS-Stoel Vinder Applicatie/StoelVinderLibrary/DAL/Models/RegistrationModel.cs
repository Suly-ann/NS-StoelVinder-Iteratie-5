using System;
using System.Collections.Generic;
using System.Text;

namespace NS_Stoel_Vinder_Lib.DAL.Models
{
    public class RegistrationModel
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Insertion { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}

