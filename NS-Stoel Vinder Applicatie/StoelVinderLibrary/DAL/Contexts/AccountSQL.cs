using StoelVinder.lib.DAL.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace StoelVinder.lib.DAL.Contexts
{
    public class AccountSQL : IAccountContext
    {

        public SqlConnection con;


        //Login Query
        public bool Login(string email, string password)
        {
            DatabaseConnection connection = new DatabaseConnection();
            try
            {
                connection.OpenConnection();
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM dbo.[Account]  WHERE Emailadres=@Emailadres", connection.con);

                sda.Fill(dtbl);
                if (!CheckIfEmailExist(email))
                {
                    return true;
                }

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




        //Registration Query
        public bool Registration(string firstname, string insertion, string lastname, string email, string password)
        {
            DatabaseConnection connection = new DatabaseConnection();

            try
            {
                connection.OpenConnection();

                SqlCommand cmd = new SqlCommand("INSERT INTO [Account] (Voornaam, Tussenvoegsel, Achternaam, Emailadres, Wachtwoord) VALUES (@Voornaam, @Tussenvoegsel, @Achternaam, @Emailadres, @Wachtwoord)", connection.con);


                if (!CheckIfEmailExist(email))
                {
                    cmd.Parameters.AddWithValue("@Voornaam", firstname);
                    cmd.Parameters.AddWithValue("@Tussenvoegsel", insertion);
                    cmd.Parameters.AddWithValue("@Achternaam", lastname);
                    cmd.Parameters.AddWithValue("@Emailadres", email);
                    cmd.Parameters.AddWithValue("@Wachtwoord", password);
                    int retAffectedRows = cmd.ExecuteNonQuery();
                    if (retAffectedRows == -1)

                    {
                        return false;
                    }
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


        //Check if Email already exist
        public bool CheckIfEmailExist(string email)
        {
            DatabaseConnection connection = new DatabaseConnection();

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

        //Check Email and Password for Login
        public bool CheckEmailAndPassword(string email, string password)
        {
            DatabaseConnection connection = new DatabaseConnection();

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

        //Registration Query
        //public bool DeleteAccount(string firstname, string email)
        //{
        //    DatabaseConnection connection = new DatabaseConnection();

        //    try
        //    {
        //        connection.OpenConnection();

        //        SqlCommand cmd = new SqlCommand("DELETE * FROM [Account] WHERE Voornaam=@Voornaam AND Emailadres=@Emailadres)", connection.con);

        //        if (CheckIfEmailExist(email))
        //        {
        //            cmd.Parameters.AddWithValue("@Voornaam", firstname);
        //            cmd.Parameters.AddWithValue("@Emailadres", email);
        //            int retAffectedRows = cmd.ExecuteNonQuery();
        //            if (retAffectedRows == -1)

        //            {
        //                return false;
        //            }
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return false;

        //    }

        //    finally
        //    {
        //        connection.CloseConnection();

        //    }
        //    return true;
        //}

        public bool Delete(string email, string password)
        {
            DatabaseConnection connection = new DatabaseConnection();

            try
            {
                connection.OpenConnection();

                string query = "DELETE FROM dbo.Account WHERE Emailadres = @Emailadres AND Wachtwoord = @Wachtwoord";
                using (SqlCommand cmd = new SqlCommand(query, connection.con))
                //CheckIfLogin
                if(Login(email, password))
                {
                    cmd.Parameters.AddWithValue("@Emailadres", email);
                        cmd.Parameters.AddWithValue("@Wachwoord", password);
                        cmd.ExecuteNonQuery();
                }

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }


        public bool ResetPassword(string email, string password)
        {
            DatabaseConnection connection = new DatabaseConnection();

            connection.OpenConnection();
            try
            {
                SqlCommand cmd = new SqlCommand("Update dbo.[Account] SET Wachtwoord = @Wachtwoord WHERE Emailadres = @Emailadres", connection.con);
                if (CheckIfEmailExist(email))
                {
                    cmd.Parameters.AddWithValue("@Wachtwoord", password);
                    cmd.Parameters.AddWithValue("@Emailadres", email);
                    int retAffectedRows = cmd.ExecuteNonQuery();
                    if (retAffectedRows == -1)

                    {
                        return false;
                    }
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




