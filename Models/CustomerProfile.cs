﻿using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace cldv6212_poe_final_st10187895.Models
{
    public class CustomerProfile
    {
        public static string con_string = "Server=tcp:st10187895.database.windows.net,1433;Initial Catalog=CLDV6212POEPART3;Persist Security Info=False;User ID=st10187895;Password=MMcCord23$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        public static SqlConnection con = new SqlConnection(con_string);

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }

        public int Add_CustomerInfo(CustomerProfile c)
        {
            try
            {
                string sql = "INSERT INTO CustomerProfile(firstName, lastName, email, phoneNumber) VALUES(@firstName, @lastName, @email, @phoneNumber)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@firstName", c.firstName);
                cmd.Parameters.AddWithValue("@lastName", c.lastName);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@phoneNum", c.phoneNumber);
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
