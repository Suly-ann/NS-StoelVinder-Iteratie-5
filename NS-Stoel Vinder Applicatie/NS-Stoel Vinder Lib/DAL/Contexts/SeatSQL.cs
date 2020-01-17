using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StoelVinder.lib.DAL.Contexts
{
    public class SeatSQL : ISeatContext
    {
        readonly DatabaseConnection connection = new DatabaseConnection();

        //Check if Seat is busy
        public bool IsReserved(Seat seat)
        {
            try
            {
                connection.OpenConnection();
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SELECT IsReserved FROM [StoelPositie] WHERE StoelID = @StoelID AND Rij = @Rij", connection.con);
                cmd.Parameters.AddWithValue("@StoelID", seat.ID);
                cmd.Parameters.AddWithValue("@Rij", seat.Row);
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

        public List<Seat> GetAllSeat1steKlasse(Travelplan travelplan/*, int Wagonnummer*/)
        {
            connection.OpenConnection();
            List<Seat> Seats = new List<Seat>();

            string query = "SELECT StoelID, Rij, IsReserved " +
                "FROM dbo.StoelPositie JOIN Wagon " +
                "ON StoelPositie.WagonID = Wagon.WagonID JOIN Trein " +
                "ON Wagon.TreinID = Trein.TreinID JOIN Reisplan " +
                "ON Trein.ReisplanID = Reisplan.ReisplanID " +
                "WHERE Klasse = '1' " +
                "AND Beginstation = @Beginstation " +
                "AND Eindstation = @Eindstation " +
                //"AND Wagon.Nummer = @Wagon.Nummer " +
                "AND Spoor = @Spoor";
            {
               
                using (SqlCommand cmd = new SqlCommand(query, connection.con))
                {
                    cmd.Parameters.AddWithValue("@Beginstation", travelplan.Startstation);
                    cmd.Parameters.AddWithValue("@Eindstation", travelplan.Endstation);
                    //cmd.Parameters.AddWithValue("@Wagon.Nummer", Wagonnummer);
                    cmd.Parameters.AddWithValue("@Spoor", travelplan.Railstation);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Seats.Add(new Seat((int)reader["StoelID"], reader["Rij"].ToString(), (bool)reader["IsReserved"]));
                        }
                    }
                }
                connection.CloseConnection();
            }
            return Seats;
        }

        public List<Seat> GetAllSeat2deKlasse(Travelplan travelplan)
        {
            connection.OpenConnection();
            List<Seat> Seats = new List<Seat>();

            string query = "SELECT StoelID, Rij, IsReserved " +
                "FROM dbo.StoelPositie JOIN Wagon " +
                "ON StoelPositie.WagonID = Wagon.WagonID JOIN Trein " +
                "ON Wagon.TreinID = Trein.TreinID JOIN Reisplan " +
                "ON Trein.ReisplanID = Reisplan.ReisplanID " +
                "WHERE Klasse = '2' " +
                "AND Beginstation = @Beginstation " +
                "AND Eindstation = @Eindstation " +
                "AND Spoor = @Spoor";
            {
               using (SqlCommand cmd = new SqlCommand(query, connection.con))
                {
                    cmd.Parameters.AddWithValue("@Beginstation", travelplan.Startstation);
                    cmd.Parameters.AddWithValue("@Eindstation", travelplan.Endstation);
                    cmd.Parameters.AddWithValue("@Spoor", travelplan.Railstation);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Seats.Add(new Seat((int)reader["StoelID"], reader["Rij"].ToString(), (bool)reader["IsReserved"]));
                        }
                    }
                }
                connection.CloseConnection();
            }
            return Seats;
        }

    }
}
