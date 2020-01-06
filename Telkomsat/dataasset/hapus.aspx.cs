using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.dataasset
{
    public partial class hapus : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string wilayah = Request.QueryString["idwilayah"];
            string bangunan = Request.QueryString["idbangunan"];
            string ruangan = Request.QueryString["idruangan"];
            string rak = Request.QueryString["idrak"];

            if (wilayah != null)
            {
                string query = $"DELETE FROM as_wilayah WHERE id_wilayah = '{wilayah}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("../dataasset/site.aspx");
            }
            if (bangunan != null)
            {
                string query = $"DELETE FROM as_bangunan WHERE id_bangunan = '{bangunan}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("../dataasset/bangunan.aspx");
            }
            if (ruangan != null)
            {
                string query = $"DELETE FROM as_ruangan WHERE id_ruangan = '{ruangan}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("../dataasset/ruangan.aspx");
            }
            if (rak != null)
            {
                string query = $"DELETE FROM as_rak WHERE id_rak = '{rak}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("../dataasset/rack.aspx");
            }
        }
    }
}