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

            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
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

            var minggu = DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd");
            sqlCon.Open();
            SqlDataAdapter sqlCmd1 = new SqlDataAdapter("dashAsset", sqlCon);
            sqlCmd1.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd1.SelectCommand.Parameters.AddWithValue("@mulai1", minggu);
            sqlCmd1.SelectCommand.Parameters.AddWithValue("@akhir1", tanggal);
            DataTable dtbl3 = new DataTable();
            sqlCmd1.Fill(dtbl3);
            dtAsset.DataSource = dtbl3;
            dtAsset.DataBind();
            //DataList2.DataSource = dtbl1;
            //DataList2.DataBind();
            sqlCon.Close();

            if (dtAsset.Items.Count == 0)
            {
                lblAsset.Visible = true;
                lblAsset.Text = "Tidak ada pembaruan data";
            }

            if (dtLogbook.Items.Count == 0)
            {
                lblLogbook.Visible = true;
                lblLogbook.Text = "Tidak ada penambahan logbook";
            }

            lblProfile1.Text = Session["username"].ToString();
        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}