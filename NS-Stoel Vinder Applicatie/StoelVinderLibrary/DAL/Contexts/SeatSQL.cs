using StoelVinder.lib.DAL.Interfaces;
using StoelVinder.lib.DAL.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace StoelVinder.lib.DAL.Contexts
{
    public class SeatSQL : ISeatContext
    {
        //Reserve Seat
        public bool SeatPosition(Seat seat)
        {
            DatabaseConnection connection = new DatabaseConnection();

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
            DatabaseConnection connection = new DatabaseConnection();

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

    //    public Seat GetById(int id)
    //    {
    //        DatabaseConnection connection = new DatabaseConnection();
    //        {
    //            connection.OpenConnection();

    //            using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM StoelPositie(@StoelID)", connection.con))
    //            {
    //                sqlCommand.CommandType = CommandType.Text;
    //                sqlCommand.Parameters.AddWithValue("@productid", id);
    //                using (SqlDataReader reader = sqlCommand.ExecuteReader())
    //                {


    //                    if (reader.HasRows)
    //                    {
    //                        Seat prod = new Seat(id);
    //                        while (reader.Read())
    //                        {
    //                            prod.ProductName = reader["ProductName"].ToString();
    //                            if (!reader.IsDBNull(reader.GetOrdinal("ProductCalories")))
    //                            {
    //                                prod.ProductCalories = (int)reader["ProductCalories"];
    //                            }
    //                            else { prod.ProductCalories = 0; }
    //                            prod.ProductDescription = reader["ProductDescription"].ToString();
    //                            prod.ProductPrice = (decimal)reader["ProductPrice"];
    //                            prod.ProductImage = (byte[])reader["ProductImg"];
    //                        }
    //                        return prod;
    //                    }
    //                    else
    //                    {
    //                        return new Seat(-1);
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    public List<Seat> GetAll()
    //    {
    //        List<Seat> products = new List<Seat>();
    //        DataSet sqlDataSet = new DataSet();
    //        {
    //            DatabaseConnection connection = new DatabaseConnection();

    //            {
    //                connection.OpenConnection();
    //                using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Active Products]", connection.com))
    //                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
    //                {
    //                    sqlDataAdapter.SelectCommand = sqlCommand;
    //                    sqlDataAdapter.Fill(sqlDataSet);
    //                }
    //            }

    //            foreach (DataRow dr in sqlDataSet.Tables[0].Rows)
    //            {
    //                if (products.Where(p => p.ProductId == (long)dr["ProductId"]).ToList().Count == 0)
    //                {
    //                    Product product = new Product()
    //                    {
    //                        ProductId = (long)dr["ProductId"],
    //                        ProductName = dr["ProductName"].ToString(),
    //                        ProductDescription = dr["ProductDescription"].ToString(),
    //                        ProductPrice = (decimal)dr["ProductPrice"],
    //                        ProductImage = (byte[])dr["ProductImg"],
    //                        ProductCategories = new List<string>()
    //                    };
    //                    product.ProductCategories.Add(dr["ProductCategoryName"].ToString());
    //                    if (!dr.IsNull("ProductCalories"))
    //                    {
    //                        product.ProductCalories = (int)dr["ProductCalories"];
    //                    }
    //                    else { product.ProductCalories = 0; }

    //                    products.Add(product);
    //                }
    //                else
    //                {
    //                    products.FirstOrDefault(id => id.ProductId == (long)dr["ProductId"]).ProductCategories.Add(dr["ProductCategoryName"].ToString());
    //                }
    //            }
    //            return products;
    //        }
    //    }
    }
}
