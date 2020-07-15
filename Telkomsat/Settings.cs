using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Telkomsat
{
    public class Settings
    {
        public static string ConnectionString = "Server=alta.telkom.space;Initial Catalog=GCS;User Id=gcs;Password=telk0mS4t!";
        public static SqlConnection sqlCon = new SqlConnection(Settings.ConnectionString);

        public static DataSet LoadDataSet(string Sql)
        {
            SqlCommand cmd = new SqlCommand(Sql, sqlCon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            return ds;
        }
    }
}