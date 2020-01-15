using StoelVinder.lib.DAL.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StoelVinder.lib.DAL.Contexts
{
    public class WagonSQL : IWagonContext
    {
        public SqlConnection con;

        public List<int> GetWagonNumber()
        {
            DatabaseConnection connection = new DatabaseConnection();
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


        public List<int> GetWagonNumber1steKlasse()
        {
            DatabaseConnection connection = new DatabaseConnection();
            List<int> Wagonnummers = new List<int>();

            string query = "SELECT Nummer FROM dbo.Wagon WHERE Klasse='1'";
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

        public List<int> GetWagonNummer2deKlasse()
        {
            DatabaseConnection connection = new DatabaseConnection();
            List<int> Wagonnummers = new List<int>();

            string query = "SELECT Nummer FROM dbo.Wagon WHERE Klasse='2'";
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

        //public bool FirstClass(int firstclass)
        //{
        //    DatabaseConnection connection = new DatabaseConnection();            

        //    string query = "SELECT Klasse FROM dbo.Wagon WHERE Klasse='1'";
        //    {
        //        connection.OpenConnection();

        //        using (SqlCommand cmd = new SqlCommand(query, connection.con))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                while (reader.Read())
        //                {
        //                    Firstclass.Add((int)reader["Klasse"]);
        //                }
        //            }
        //        }

        //        connection.CloseConnection();
        //    }

        //    return FirstClass;
        //}
    }
}
