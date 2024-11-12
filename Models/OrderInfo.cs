using System.Data.SqlClient;

namespace cldv6212_poe_final_st10187895.Models
{
    public class OrderInfo
    {
        public static string con_string = "REDACTED";
        public static SqlConnection con = new SqlConnection(con_string);

        public int orderID { get; set; }
        public string orderStatus = "Processed";
        public int Add_OrderInfo(OrderInfo c)
        {
            try
            {
                string sql = "INSERT INTO OrderInfo(orderID, orderStatus) VALUES(@orderID, @orderStatus)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@orderID", c.orderID);
                cmd.Parameters.AddWithValue("@orderStatus", c.orderStatus);
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
