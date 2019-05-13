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
    public partial class editad : System.Web.UI.Page
    {
        string IDpass;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IDpass = Session["hf"].ToString();
                txtHost.Text = Session["Host"].ToString();
                txtDescription.Text = Session["Description"].ToString();
                txtSupplier.Text = Session["Supplier"].ToString();
                txtIP.Text = Session["IP"].ToString();
                txtComment.Text = Session["Comment"].ToString();
                txtInstall.Text = Session["Installation"].ToString();
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
            SqlCommand sqlCmd = new SqlCommand("AdUpdate", con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID1", IDpass);
            sqlCmd.Parameters.AddWithValue("@Host", txtHost.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Supplier", txtSupplier.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IP1", txtIP.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Comment", txtComment.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Installation", txtInstall.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            con.Close();
            lblUpdate.Visible = true;
            lblUpdate.ForeColor = System.Drawing.Color.LawnGreen;
            lblUpdate.Text = "Update Berhasil";
            clear();
        }

        void clear()
        {
            txtInstall.Text = "";
            txtDescription.Text = "";
            txtHost.Text = "";
            txtIP.Text = "";
            txtSupplier.Text = "";
            txtComment.Text = "";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            IDpass = Session["hf"].ToString();
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand sqlCmd = new SqlCommand("AdDelete", con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", IDpass);
            sqlCmd.ExecuteNonQuery();
            con.Close();
            lblUpdate.Visible = true;
            lblUpdate.ForeColor = System.Drawing.Color.IndianRed;
            lblUpdate.Text = "Delete Berhasil";
            clear();
            txtDescription.Visible = false;
            txtHost.Visible = false;
            txtIP.Visible = false;
            txtInstall.Visible = false;
            txtSupplier.Visible = false;
            txtComment.Visible = false;
        }
    }
}