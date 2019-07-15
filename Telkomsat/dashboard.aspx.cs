using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Threading;

namespace Telkomsat
{
    public partial class dashboard : System.Web.UI.Page
    {
        string user;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            user = Session["username"].ToString();
            if (!IsPostBack)
            {
                sqlCon.Open();
                SqlDataAdapter sqlCmd = new SqlDataAdapter("ProViewByUser", sqlCon);
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd.SelectCommand.Parameters.AddWithValue("@user", user);
                DataTable dtbl1 = new DataTable();
                sqlCmd.Fill(dtbl1);
                dtContact.DataSource = dtbl1;
                dtContact.DataBind();
                //DataList2.DataSource = dtbl1;
                //DataList2.DataBind();
                sqlCon.Close();
            }

            string tanggal = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")).ToString("yyyy/MM/dd");
            var kemarin = DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd");
            sqlCon.Open();
            SqlDataAdapter sqlCmd2 = new SqlDataAdapter("dashLogbook", sqlCon);
            sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd2.SelectCommand.Parameters.AddWithValue("@mulai", kemarin);
            sqlCmd2.SelectCommand.Parameters.AddWithValue("@akhir", tanggal);
            DataTable dtbl = new DataTable();
            sqlCmd2.Fill(dtbl);
            dtLogbook.DataSource = dtbl;
            dtLogbook.DataBind();
            //DataList2.DataSource = dtbl1;
            //DataList2.DataBind();
            sqlCon.Close();

            lblProfile1.Text = Session["username"].ToString();
        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}