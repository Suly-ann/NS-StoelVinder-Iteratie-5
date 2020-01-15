using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StoelVinder.lib.DAL.Contexts
{
    public class DatabaseConnection
    {
        public static string ConnectionString = "Data Source = mssql.fhict.local;Initial Catalog = dbi426932;Persist Security Info = True;User ID = dbi426932;Password = Jennifer07";
        public SqlConnection con;


        public void OpenConnection()
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }


        public void CloseConnection()
        {
            try
            {
                con = new SqlConnection(ConnectionString);
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }


        public void ExecuteQueries(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            cmd.ExecuteNonQuery();
        }

        internal DataSet ExecuteSql(string query, List<KeyValuePair<string, string>> parameters)
        {
            DataSet dataSet = new DataSet();

            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlDataAdapter dataAdapter = new SqlDataAdapter();
                SqlCommand command = connection.CreateCommand();

                foreach(KeyValuePair<string, string> kvp in parameters)
                {
                    SqlParameter parameter = new SqlParameter();
                    parameter.ParameterName = "@" + kvp.Key;
                    parameter.Value = kvp.Value;
                    command.Parameters.Add(parameter);
                }

                command.CommandText = query;
                dataAdapter.SelectCommand = command;

                connection.Open();
                dataAdapter.Fill(dataSet);
                connection.Close();

            }
            catch (Exception e)
            {
                throw e;
            }

            return dataSet;
        }

        public SqlDataReader DataReader(string Query_)
        {
            SqlCommand cmd = new SqlCommand(Query_, con);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}
