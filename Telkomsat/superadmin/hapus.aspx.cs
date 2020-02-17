using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Telkomsat.superadmin
{
    public partial class hapus : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string tanggalsh = Request.QueryString["tanggalsh"];
            string jadwalsh = Request.QueryString["jadwalsh"];

            if (tanggalsh != null && jadwalsh != null)
            {
                string query = $"DELETE shiftme WHERE tanggal_shift = '{tanggalsh}' AND jadwal = '{jadwalsh}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("../superadmin/shiftme.aspx");
                //Response.Write(tanggalsh + "  " + jadwalsh);
            }
        }
    }
}