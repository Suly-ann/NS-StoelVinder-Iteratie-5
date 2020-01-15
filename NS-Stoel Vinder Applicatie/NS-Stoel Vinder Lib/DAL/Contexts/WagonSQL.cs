using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StoelVinder.lib.DAL.Contexts
{
    public class WagonSQL : IWagonContext
    {

        DatabaseConnection connection = new DatabaseConnection();
        public SqlConnection con;

        public List<int> GetWagonNumber()
        {
            List<int> Wagonnummers = new List<int>();

            string query = "SELECT * FROM dbo.Wagon WHERE Nummer=@Nummer";
            {
                connection.OpenConnection();

                using (SqlCommand cmd = new SqlCommand(query, connection.con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Wagonnummers.Add((int)reader["Nummer"]);
                        }
                    }
                }

                connection.CloseConnection();
            }

            return Wagonnummers;
        }

        //public List<Wagon> GetAllWagon()
        //{
        //    List<Wagon> Wagons = new List<Wagon>();

        //    string query = "SELECT  Trein.TreinID TreinID, Wagon.WagonID WagonID, Wagon.Nummer WagonNummer, StoelID, Rij, IsReserved, Klasse " +
        //        "From Trein " +
        //        "Join Wagon on Trein.TreinID = Wagon.TreinID " +
        //        "join StoelPositie on StoelPositie.WagonID = Wagon.WagonID";
        //    {
        //        connection.OpenConnection();

        //        using (SqlCommand cmd = new SqlCommand(query, connection.con))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Wagon TempWagon = new Wagon();
        //                    while ((int)reader["WagonID"] == TempWagon.ID)
        //                    {
        //                        TempWagon.ID = (int)reader["WagonID"];
        //                        TempWagon.Rows.Add( reader["Rij"].ToString());
        //                        TempWagon.Seats.Add(new Seat((int)reader["StoelID"],reader["Rij"].ToString(),(bool)reader["IsReserved"]));
        //                        TempWagon.Wagonnumber = (int)reader["WagonNummer"];
        //                        TempWagon.TrainClass = (int)reader["Klasse"];
        //                    }
        //                    Wagons.Add(TempWagon);
        //                }
        //            }
        //        }

        //        connection.CloseConnection();
        //    }

        //    return Wagons;
        //}

        public List<int> GetWagonNumber1steKlasse(string Beginstation, string Eindstation, int Spoor)
        {
            List<int> Wagonnummers = new List<int>();

            string query = "SELECT Wagon.Nummer FROM Reisplan JOIN Trein ON Reisplan.ReisplanID = Trein.ReisplanID JOIN Wagon ON Trein.TreinID = Wagon.TreinID WHERE Klasse = '1' AND Beginstation=@Beginstation AND Eindstation=@Eindstation AND Spoor=@Spoor";
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
                            Wagonnummers.Add((int)reader["Nummer"]);
                        }
                    }
                }

                connection.CloseConnection();
            }

            return Wagonnummers;
        }

        public List<int> GetWagonNummer2deKlasse(string Beginstation, string Eindstation, int Spoor)
        {
            List<int> Wagonnummers = new List<int>();

            string query = "SELECT Wagon.Nummer FROM Reisplan JOIN Trein ON Reisplan.ReisplanID = Trein.ReisplanID JOIN Wagon ON Trein.TreinID = Wagon.TreinID WHERE Klasse = '2' AND Beginstation=@Beginstation AND Eindstation=@Eindstation AND spoor=@Spoor";
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
                            Wagonnummers.Add((int)reader["Nummer"]);
                        }
                    }
                }

                connection.CloseConnection();
            }

            return Wagonnummers;
        }
    }
}
