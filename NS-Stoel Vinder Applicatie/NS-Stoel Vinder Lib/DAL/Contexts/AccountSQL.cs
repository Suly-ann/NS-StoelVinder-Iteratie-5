using StoelVinder.lib.DAL.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace StoelVinder.lib.DAL.Contexts
{
    public class AccountSQL : IAccountContext
    {
        DatabaseConnection connection = new DatabaseConnection();
        public SqlConnection con;


        public bool Login(string email, string password)
        {
            try
            {
                connection.OpenConnection();
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM dbo.[Account] WHERE Emailadres=@Emailadres", connection.con);
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


        public bool Registration(string firstname, string insertion, string lastname, DateTime dateofbirth, string email, string password)
        {
            try
            {
                connection.OpenConnection();

                SqlCommand cmd = new SqlCommand("INSERT INTO [Account] (Voornaam, Tussenvoegsel, Achternaam, Geboortedatum, Emailadres, Wachtwoord) VALUES (@Voornaam, @Tussenvoegsel, @Achternaam, @Geboortedatum, @Emailadres, @Wachtwoord)", connection.con);
                cmd.Parameters.AddWithValue("@Voornaam", firstname);
                if (insertion != null)
                {
                    cmd.Parameters.AddWithValue("@Tussenvoegsel", insertion);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Tussenvoegsel", "");
                }
                cmd.Parameters.AddWithValue("@Achternaam", lastname);
                cmd.Parameters.AddWithValue("@Geboortedatum", dateofbirth);
                cmd.Parameters.AddWithValue("@Emailadres", email);
                cmd.Parameters.AddWithValue("@Wachtwoord", password);
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


        public bool CheckIfEmailExist(string email)
        {
            try
            {
                connection.OpenConnection();
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Account] WHERE Emailadres = @Emailadres", connection.con);

                cmd.Parameters.AddWithValue("@Emailadres", email);
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

        public bool CheckEmailAndPassword(string email, string password)
        {

            try
            {
                connection.OpenConnection();
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [Account] WHERE Emailadres = @Emailadres AND Wachtwoord=@Wachtwoord", connection.con);

                cmd.Parameters.AddWithValue("@Emailadres", email);
                cmd.Parameters.AddWithValue("@Wachtwoord", password);
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


        public bool DeleteAccount(string email, string password)
        {
            try
            {
                connection.OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Account WHERE Emailadres = @Emailadres AND Wachtwoord = @Wachtwoord", connection.con);

                cmd.Parameters.AddWithValue("@Emailadres", email);
                cmd.Parameters.AddWithValue("@Wachtwoord", password);
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


        public bool ResetPassword(string email, string password)
        {
            try
            {

                connection.OpenConnection();
                SqlCommand cmd = new SqlCommand("Update dbo.[Account] SET Wachtwoord = @Wachtwoord WHERE Emailadres = @Emailadres", connection.con);

                cmd.Parameters.AddWithValue("@Wachtwoord", password);
                cmd.Parameters.AddWithValue("@Emailadres", email);
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




