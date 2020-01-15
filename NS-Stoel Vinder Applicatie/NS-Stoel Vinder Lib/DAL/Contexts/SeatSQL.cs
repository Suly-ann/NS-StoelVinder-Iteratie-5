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

        DatabaseConnection connection = new DatabaseConnection();
       
        public bool SeatPosition(Seat seat)
        {

            try
            {
                connection.OpenConnection();

                SqlCommand cmd = new SqlCommand("INSERT INTO [StoelPositie] (StoelID, Rij) VALUES (@StoelID, @Rij)", connection.con);


                if (!IsReserved(seat))
                {
                    cmd.Parameters.AddWithValue("@StoelID", seat.ID);
                    cmd.Parameters.AddWithValue("@Rij", seat.Row);
    
                    int retAffectedRows = (int)cmd.ExecuteScalar();
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


        //Check if Seat is busy
        public bool IsReserved(Seat seat)
        {

            try
            {
                connection.OpenConnection();
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [StoelPositie] WHERE StoelID = @StoelID AND Rij = @Rij", connection.con);
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

        public List<Seat> GetAllSeat1steKlasse(string Beginstation, string Eindstation, int Spoor/*, int Wagonnummer*/)
        {
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
                connection.OpenConnection();

                using (SqlCommand cmd = new SqlCommand(query, connection.con))
                {
                    cmd.Parameters.AddWithValue("@Beginstation", Beginstation);
                    cmd.Parameters.AddWithValue("@Eindstation", Eindstation);
                    //cmd.Parameters.AddWithValue("@Wagon.Nummer", Wagonnummer);
                    cmd.Parameters.AddWithValue("@Spoor", Spoor);
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

        public List<Seat> GetAllSeat2deKlasse(string Beginstation, string Eindstation, int Spoor)
        {
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
                connection.OpenConnection();

                using (SqlCommand cmd = new SqlCommand(query, connection.con))
                {
                    cmd.Parameters.AddWithValue("@Beginstation", Beginstation);
                    cmd.Parameters.AddWithValue("@Eindstation", Eindstation);
                    cmd.Parameters.AddWithValue("@Spoor", Spoor);
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
