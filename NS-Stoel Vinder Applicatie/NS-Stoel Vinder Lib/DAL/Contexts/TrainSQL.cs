using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StoelVinder.lib.DAL.Contexts
{
    public class TrainSQL : ITrainContext
    {

        readonly DatabaseConnection connection = new DatabaseConnection();

        //Alle treinnummer ophalen
        public bool GetAllTrains(Train train)
        {
            try
            {
                connection.OpenConnection();
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SELECT Nummer FROM [Trein]", connection.con);
                cmd.Parameters.AddWithValue("@Nummer", train.Trainnumber);
                sda.SelectCommand = cmd;
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

        //ID, Treinnumer en Bouwjaar ophalen
        public List<Train> GetAll()
        {
            List<Train> Wagonnummers = new List<Train>();

            string query = "SELECT * FROM dbo.Trein WHERE Nummer=@Nummer";
            {
                connection.OpenConnection();

                using (SqlCommand cmd = new SqlCommand(query, connection.con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Wagonnummers.Add(new Train((int)reader["TreinID"],(int)reader["Nummer"], (int)reader["Bouwjaar"]));
                        }
                    }
                }
                connection.CloseConnection();
            }
            return Wagonnummers;
        }

        //Treinnummer ophalen van geselecteerde reisplan
        public bool GetTrainNumbers(Train train)
        {
            try
            {
                connection.OpenConnection();
                DataTable dtbl = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("SELECT Trein.Nummer FROM [Trein]" +
                    "JOIN Reisplan ON Trein.ReisplanID = Reisplan.ReisplanID " +
                    "WHERE Beginstation = @Beginstation AND Eindstation = @Eindstation", connection.con);
                cmd.Parameters.AddWithValue("@Nummer", train.Trainnumber);
                sda.SelectCommand = cmd;
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
    }
}

