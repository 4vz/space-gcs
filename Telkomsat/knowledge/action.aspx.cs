using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Telkomsat.knowledge
{
    public partial class action : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string hapuspost = Request.QueryString["hapuspost"];

            if (hapuspost != null)
            {
                string query = $"DELETE Posting WHERE ID_Post = '{hapuspost}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"semua.aspx");
            }

            
        }
    }
}