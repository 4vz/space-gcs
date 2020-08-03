using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        SqlDataAdapter da;
        DataSet ds;
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            query = @"select top 6 id_admin, status, bra_harkat, bra_me, rek_harkat1, rek_harkat2, rek_me1, rek_me2, kategori, input, tanggal, total
                                from administrator order by id_admin desc";
            ds = new DataSet();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            Response.Write(ds);
        }
    }
}