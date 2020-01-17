using System.Data.SqlClient;
using System;
using System.Data;
using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;

namespace StoelVinder.lib.DAL.Contexts
{
    public class TicketSQL : ITicketContext
    {
        readonly DatabaseConnection connection = new DatabaseConnection();

        public void DisplayTicket(Ticket ticket)
        {
            try
            {
                connection.OpenConnection();
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SELECT Voornaam, Tussenvoegsel, Achternaam, Beginstation, Eindstation, Tijd, Klasse, StoelID, Rij " +
                                                "From Account " +
                                                "JOIN AccountReisplan ON AccountReisplan.AccountID = Account.AccountID " +
                                                "JOIN Reisplan ON AccountReisplan.ReisplanID = Reisplan.ReisplanID " +
                                                "JOIN Trein on Reisplan.ReisplanID = Trein.ReisplanID " +
                                                "JOIN Wagon on Trein.TreinID = Wagon.TreinID " +
                                                "JOIN StoelPositie on Wagon.WagonID = StoelPositie.WagonID " +
                                                "ORDER BY Voornaam", connection.con);

                cmd.Parameters.AddWithValue("@Voornaam", ticket.Firstname);
                cmd.Parameters.AddWithValue("@Tussenvoegsel", ticket.Insertion);
                cmd.Parameters.AddWithValue("@Achternaam", ticket.Lastname);
                cmd.Parameters.AddWithValue("@Beginstation", ticket.Startstation);
                cmd.Parameters.AddWithValue("@Eindstation", ticket.Endstation);
                cmd.Parameters.AddWithValue("@Tijd", ticket.Time);
                cmd.Parameters.AddWithValue("@Klasse", ticket.TrainClass);
                cmd.Parameters.AddWithValue("@StoelID", ticket.SeatID);
                cmd.Parameters.AddWithValue("@Rij", ticket.Row);
                sda.SelectCommand = cmd;
                sda.Fill(dtbl);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            finally
            {
                connection.CloseConnection();
            }
        }

    }
}
