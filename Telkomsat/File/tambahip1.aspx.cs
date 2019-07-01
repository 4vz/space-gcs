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
    public partial class tambahip1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = Button3.UniqueID;
            if (!IsPostBack)
            {

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

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand sqlCmd = new SqlCommand("AdTambah", con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Host", txtHost.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Supplier", txtSupplier.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@IP1", txtIP.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Comment", txtComment.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Installation", txtInstall.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            con.Close();
            lblUpdate.Visible = true;
            lblUpdate.ForeColor = System.Drawing.Color.Green;
            lblUpdate.Text = "Berhasil Tambah";
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
    }
}