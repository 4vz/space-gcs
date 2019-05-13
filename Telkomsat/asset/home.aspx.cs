using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.asset
{
    public partial class home : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS1; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Request.Form.Get("rfmatrix"));
            Request.Form.Get("tahun");
        }

        protected void btnCari_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand("FilterAll", sqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            Session["cari"] = txtCari.Text.Trim();
            Response.Redirect("~/asset/search.aspx");
        }
    }
}