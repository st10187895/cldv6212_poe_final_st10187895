﻿using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace cldv6212_poe_final_st10187895.Models
{
    public class ProductInfo
    {
        public static string con_string = "REDACTED";
        public static SqlConnection con = new SqlConnection(con_string);

        public string productID { get; set; }
        public string productName { get; set; }
        public string productPrice { get; set; }
        public string imagePath { get; set; }

        public int Add_ProductInfo(ProductInfo c)
        {
            try
            {
                string sql = "INSERT INTO ProductInfo(productID, productName, productPrice, imagePath) VALUES(@productID, @productName, @productPrice, @imagePath)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@productID", c.productID);
                cmd.Parameters.AddWithValue("@productID", c.productID);
                cmd.Parameters.AddWithValue("@productID", c.productID);
                cmd.Parameters.AddWithValue("@productID", c.productID);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
