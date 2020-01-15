using System.Data.SqlClient;
using System;
using System.Data;
using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;

namespace StoelVinder.lib.DAL.Contexts
{
    public class TicketSQL : ITicketContext
    {

        DatabaseConnection connection = new DatabaseConnection();
        public SqlConnection con;

        public void DisplayTicket(string firstname, string insertion, string lastname, string startstation, string endstation, DateTime time, int trainclass)
        {
            try
            {
                connection.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT Voornaam, Tussenvoegsel, Achternaam, Beginstation, Eindstation, Tijd, Klasse, StoelPositie From Account JOIN AccountReisplan ON AccountReisplan.AccountID = Account.AccountID JOIN Reisplan ON AccountReisplan.ReisplanID = Reisplan.ReisplanID JOIN Trein on Reisplan.ReisplanID = Trein.ReisplanID ORDER BY Voornaam", connection.con);

                SqlDataAdapter sqlDa = new SqlDataAdapter();
                sqlDa.SelectCommand = sqlCom;
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.CloseConnection();
            }
        }

        public Account GetByName(string name)
        {
            connection.OpenConnection();

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM dbo.Account Where Voornaam = @Voornaam", connection.con);
            {
                sqlCommand.Parameters.AddWithValue("@Voornaam", name);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                {
                    if (reader.HasRows)
                    {
                        Account ac = new Account();
                        while (reader.Read())
                        {
                            ac.Firstname = reader["Voornaam"].ToString();
                            ac.Insertion = reader["Tussenvoegsel"].ToString();
                            ac.Lastname = reader["Achternaam"].ToString();
                        }
                        return ac;
                    }
                    else
                    {
                        return new Account();
                    }
                }
            }

        }

    }
}
