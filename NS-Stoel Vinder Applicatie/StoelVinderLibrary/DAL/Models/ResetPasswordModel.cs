using System;
using System.Collections.Generic;
using System.Text;

namespace NS_Stoel_Vinder_Lib.DAL.Models
{
    public class ResetPasswordModel
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
