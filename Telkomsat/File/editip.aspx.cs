using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.File
{
    public partial class editip : System.Web.UI.Page
    {
        string IDpass;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IDpass = Session["hf"].ToString();
                txtComponent.Text = Session["Component"].ToString();
                txtLocation.Text = Session["Location"].ToString();
                txtHost.Text = Session["Host"].ToString();
                txtIP.Text = Session["IP"].ToString();
            }
            
        }

        protected void btnPosting_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/semua.aspx");
        }

        protected void btnFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/dashboard.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["cari"] = txtMaster.Value;
            Response.Redirect("~/File/ippass.aspx");

        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/tambahip.aspx");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            IDpass = Session["hf"].ToString();
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand sqlCmd = new SqlCommand("IPUpdate", con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", IDpass);
            sqlCmd.Parameters.AddWithValue("@Component", txtComponent.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Location", txtLocation.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Host", txtHost.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IP", txtIP.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            con.Close();
            lblUpdate.Visible = true;
            lblUpdate.ForeColor= System.Drawing.Color.LawnGreen;
            lblUpdate.Text = "Update Berhasil";
            clear();
        }

        void clear()
        {
            txtComponent.Text = "";
            txtLocation.Text = "";
            txtHost.Text = "";
            txtIP.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            IDpass = Session["hf"].ToString();
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand sqlCmd = new SqlCommand("IPDelete", con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", IDpass);
            sqlCmd.ExecuteNonQuery();
            con.Close();
            lblUpdate.Visible = true;
            lblUpdate.ForeColor = System.Drawing.Color.IndianRed;
            lblUpdate.Text = "Delete Berhasil";
            clear();
            txtComponent.Visible = false;
            txtHost.Visible = false;
            txtIP.Visible = false;
            txtLocation.Visible = false;
        }
    }
}