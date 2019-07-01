using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.password
{
    public partial class edit : System.Web.UI.Page
    {
        string id;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = Button3.UniqueID;

            if (!IsPostBack)
            {
                id = Session["id"].ToString();
                txtnama.Text = Session["nama"].ToString();
                txtlokasi.Text = Session["lokasi"].ToString();
                txthost.Text = Session["hostname"].ToString();
                txtuser.Text = Session["username"].ToString();
                txtpass.Text = Session["password"].ToString();
                ddlJenis.Text = Session["jenis"].ToString();
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
            Response.Redirect("~/password/semuasoftware.aspx");
        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            id = Session["id"].ToString();
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand sqlCmd = new SqlCommand("PassUpdate", con);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@nama", txtnama.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@jenis", ddlJenis.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@lokasi", txtlokasi.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@hostname", txthost.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@username", txtuser.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@password", txtpass.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@id", id);
            sqlCmd.ExecuteNonQuery();
            con.Close();
            lblUpdate.Visible = true;
            lblUpdate.ForeColor = System.Drawing.Color.Green;
            lblUpdate.Text = "Berhasil Update";
            clear();
        }

        void clear()
        {
            txtnama.Text = "";
            ddlJenis.Text = "";
            txtlokasi.Text = "";
            txtpass.Text = "";
            txtuser.Text = "";
            txthost.Text = "";
        }
    }
}