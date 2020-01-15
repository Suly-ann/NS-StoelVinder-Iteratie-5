namespace StoelVinder.lib.DAL.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Insertion { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public PaymethodeType Paymethode { get; set; }

        //public enum PaymethodeType
        //{
        //    IDeal,
        //    AfterPay,
        //    VISA,
        //    Bankcontact,
        //    Paypal,
        //    MasterCard,
        //}

        public Account(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public Account(string firstname, string insertion, string lastname, string email, string password)
        {
            this.Firstname = firstname;
            this.Insertion = insertion;
            this.Lastname = lastname;
            this.Email = email;
            this.Password = password;
        }

        public Account()
        {

        }

    }
}
