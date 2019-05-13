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
    public partial class dashboard : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

            con.Open();
            SqlCommand countcmd = new SqlCommand("FileCount1", con);
            countcmd.CommandType = CommandType.StoredProcedure;
            countcmd.Parameters.AddWithValue("@kategori1", "Buku Manual");
            int valuecount = (int)countcmd.ExecuteScalar();
            lblBuku.Text = valuecount.ToString();

            con.Close();
            con.Open();
            SqlCommand countSOP = new SqlCommand("FileCount1", con);
            countSOP.CommandType = CommandType.StoredProcedure;
            countSOP.Parameters.AddWithValue("@kategori1", "SOP");
            int valuesop = (int)countSOP.ExecuteScalar();
            lblSOP.Text = valuesop.ToString();

            con.Close();
            con.Open();
            SqlCommand countpel = new SqlCommand("FileCount1", con);
            countpel.CommandType = CommandType.StoredProcedure;
            countpel.Parameters.AddWithValue("@kategori1", "Pelatihan");
            int valuepel = (int)countpel.ExecuteScalar();
            lblPelatihan.Text = valuepel.ToString();

            con.Close();
            con.Open();
            SqlCommand countpem = new SqlCommand("FileCount1", con);
            countpem.CommandType = CommandType.StoredProcedure;
            countpem.Parameters.AddWithValue("@kategori1", "Pembaruan Konfigurasi");
            int valuepem = (int)countpem.ExecuteScalar();
            lblPembaruan.Text = valuepem.ToString();

            con.Close();
            con.Open();
            SqlCommand countpass = new SqlCommand("SELECT Count(*) FROM IPPass", con);
            int valuepass = (int)countpass.ExecuteScalar();
            lblPass.Text = valuepass.ToString();
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
            Session["carifile"] = txtMaster.Value;
            Response.Redirect("~/File/semuafile.aspx");
        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/tambah.aspx");
        }
    }
}