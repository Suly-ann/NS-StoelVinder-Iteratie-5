using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;

namespace StoelVinder.lib.DAL.Contexts
{
    public class TravelplanSQL : ITravelplanContext
    {
        readonly DatabaseConnection connection = new DatabaseConnection();

        public List<Station> GetStationsOnly()
        {
            List<Station> stations = new List<Station>();

            string query = "SELECT * FROM dbo.TreinStation";
            {
                connection.OpenConnection();

                using (SqlCommand cmd = new SqlCommand(query, connection.con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            stations.Add(new Station(reader["Naam"].ToString()));
                        }
                    }
                }

                connection.CloseConnection();
            }

            return stations;
        }

        public List<Travelplan> GetTravelplans(Travelplan travelplan)
        {
            List<Travelplan> travelplans = new List<Travelplan>();
            string query = "SELECT * FROM dbo.Reisplan where Beginstation=@begin And Eindstation=@eind Order By Tijd ASC";
            List<KeyValuePair<string, string>> parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("begin", travelplan.Startstation));
            parameters.Add(new KeyValuePair<string, string>("eind", travelplan.Endstation));

            DataSet dataSet = connection.ExecuteSql(query, parameters);

            try
            {
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    Travelplan reisplan = DataTableToTravelplan(dataSet, i);
                    travelplans.Add(reisplan);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return travelplans;
        }

        private Travelplan DataTableToTravelplan(DataSet dataSet, int i)
        {
            return new Travelplan()
            {
                ID = Convert.ToInt32(dataSet.Tables[0].Rows[i][0]),
                Startstation = dataSet.Tables[0].Rows[i][1].ToString(),
                Endstation = dataSet.Tables[0].Rows[i][2].ToString(),
                Time = Convert.ToDateTime(dataSet.Tables[0].Rows[i][3]),
                Railstation = Convert.ToInt32(dataSet.Tables[0].Rows[i][4]),
                Trainnr = Convert.ToInt32(dataSet.Tables[0].Rows[i][5])
            };
        }
    }
}