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
    public partial class login : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS1; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            string parse = link.Remove(0, 11);
            if (parse == "?out")
                Session.Abandon();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            string query = "SELECT COUNT(*) FROM Login WHERE user_name='" + inEmail.Value + "' AND password ='" + inPass.Value + " '";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            string output = cmd.ExecuteScalar().ToString();

            if (output == "1")
            {
                Session["user"] = inEmail.Value;
                Response.Redirect("~/dashboard.aspx");
            }
            else
            {
                lblGagal.Visible = true;
                Response.Write(output);
            }
        }
    }
}