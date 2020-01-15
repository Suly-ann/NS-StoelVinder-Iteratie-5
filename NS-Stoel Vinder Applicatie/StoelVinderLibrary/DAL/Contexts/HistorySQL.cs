using System.Data.SqlClient;
using System;
using System.Data;
using StoelVinder.lib.DAL.Interfaces;

namespace StoelVinder.lib.DAL.Contexts
{
    public class HistorySQL : IHistoryContext
    {
        public SqlConnection con;
        public void DisplayHistory(string firstname, string insertion, string lastname, string startstation, string endstation, DateTime time, int trainclass)
        {
            DatabaseConnection connection = new DatabaseConnection();
            
            try
            {
                connection.OpenConnection();
                SqlCommand sqlCom = new SqlCommand("SELECT * FROM ReserveringTicket WHERE AccountID = @AccountID", connection.con);

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
    }
}
