using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace StoelVinder.lib.DAL.Contexts
{
    public class AccountSQL : IAccountContext
    {
        readonly DatabaseConnection connection = new DatabaseConnection();

        public bool Login(Account account)
        {
            try
            {
                connection.OpenConnection(); 
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Account] WHERE Emailadres = @Emailadres", connection.con);
                cmd.Parameters.AddWithValue("@Emailadres", account.Email);
                sda.SelectCommand = cmd;
                sda.Fill(dtbl);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
            finally
            {
                connection.CloseConnection();
            }
            return false;
        }


        public bool Registration(Account account)
        {
            try
            {
                connection.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO [Account] (Voornaam, Tussenvoegsel, Achternaam, Geboortedatum, Emailadres, Wachtwoord) VALUES (@Voornaam, @Tussenvoegsel, @Achternaam, @Geboortedatum, @Emailadres, @Wachtwoord)", connection.con);
                cmd.Parameters.AddWithValue("@Voornaam", account.Firstname);
                if (account.Insertion != null)
                {
                    cmd.Parameters.AddWithValue("@Tussenvoegsel", account.Insertion);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Tussenvoegsel", "");
                }
                cmd.Parameters.AddWithValue("@Achternaam", account.Lastname);
                cmd.Parameters.AddWithValue("@Geboortedatum", account.DateOfBirth);
                cmd.Parameters.AddWithValue("@Emailadres", account.Email);
                cmd.Parameters.AddWithValue("@Wachtwoord", account.Password);
                int retAffectedRows = cmd.ExecuteNonQuery();

                if (retAffectedRows == -1)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                connection.CloseConnection();
            }
            return true;
        }


        public bool CheckIfEmailExist(Account account)
        {
            try
            {
                connection.OpenConnection();
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Account] WHERE Emailadres = @Emailadres", connection.con);
                cmd.Parameters.AddWithValue("@Emailadres", account.Email);
                sda.SelectCommand = cmd;
                sda.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                connection.CloseConnection();
            }
            return false;
        }

        public bool CheckEmailAndPassword(Account account)
        {
            try
            {
                connection.OpenConnection();
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Account] WHERE Emailadres = @Emailadres AND Wachtwoord=@Wachtwoord", connection.con);
                cmd.Parameters.AddWithValue("@Emailadres", account.Email);
                cmd.Parameters.AddWithValue("@Wachtwoord", account.Password);
                sda.SelectCommand = cmd;
                sda.Fill(dtbl);

                if (dtbl.Rows.Count > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
               connection.CloseConnection();
            }
            return false;
        }

        public bool DeleteAccount(Account account)
        {
            try
            {
                connection.OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Account WHERE Emailadres = @Emailadres AND Wachtwoord = @Wachtwoord", connection.con);
                cmd.Parameters.AddWithValue("@Emailadres", account.Email);
                cmd.Parameters.AddWithValue("@Wachtwoord", account.Password);
                cmd.ExecuteNonQuery();
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                connection.CloseConnection();
            }

        }
        
        public bool ResetPassword(Account account)
        {
            try
            {
                connection.OpenConnection();
                SqlCommand cmd = new SqlCommand("Update dbo.[Account] SET Wachtwoord = @Wachtwoord WHERE Emailadres = @Emailadres", connection.con);
                cmd.Parameters.AddWithValue("@Wachtwoord", account.Password);
                cmd.Parameters.AddWithValue("@Emailadres", account.Email);
                int retAffectedRows = cmd.ExecuteNonQuery();

                if (retAffectedRows == -1)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
                connection.CloseConnection();
            }
            return false;

        }

    }
}




