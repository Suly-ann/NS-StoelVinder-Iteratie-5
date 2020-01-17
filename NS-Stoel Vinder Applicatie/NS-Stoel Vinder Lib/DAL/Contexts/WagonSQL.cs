using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StoelVinder.lib.DAL.Contexts
{
    public class WagonSQL : IWagonContext
    {
        readonly DatabaseConnection connection = new DatabaseConnection();

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

        public List<int> GetWagonNumber1steKlasse(Travelplan travelplan)
        {
            List<int> Wagonnummers = new List<int>();

            string query = "SELECT Wagon.Nummer FROM Reisplan JOIN Trein ON Reisplan.ReisplanID = Trein.ReisplanID JOIN Wagon ON Trein.TreinID = Wagon.TreinID WHERE Klasse = '1' AND Beginstation=@Beginstation AND Eindstation=@Eindstation AND Spoor=@Spoor";
            {
                connection.OpenConnection();

                using (SqlCommand cmd = new SqlCommand(query, connection.con))
                {
                    cmd.Parameters.AddWithValue("@Beginstation", travelplan.Startstation);
                    cmd.Parameters.AddWithValue("@Eindstation", travelplan.Endstation);
                    cmd.Parameters.AddWithValue("@Spoor", travelplan.Railstation);
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

        public List<int> GetWagonNummer2deKlasse(Travelplan travelplan)
        {
            List<int> Wagonnummers = new List<int>();

            string query = "SELECT Wagon.Nummer FROM Reisplan JOIN Trein ON Reisplan.ReisplanID = Trein.ReisplanID JOIN Wagon ON Trein.TreinID = Wagon.TreinID WHERE Klasse = '2' AND Beginstation=@Beginstation AND Eindstation=@Eindstation AND spoor=@Spoor";
            {
                connection.OpenConnection();

                using (SqlCommand cmd = new SqlCommand(query, connection.con))
                {
                    cmd.Parameters.AddWithValue("@Beginstation", travelplan.Startstation);
                    cmd.Parameters.AddWithValue("@Eindstation", travelplan.Endstation);
                    cmd.Parameters.AddWithValue("@Spoor", travelplan.Railstation);
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
