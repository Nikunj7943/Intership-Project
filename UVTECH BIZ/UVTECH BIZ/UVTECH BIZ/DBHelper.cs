using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace UVTECH_BIZ
{
    public static class DbHelper
    {
        public static string ConnStr => ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString;
        public static DataTable ExecuteSelectQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public static DataTable ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public static int ExecuteNonQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
