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
    public partial class kategori1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            string parse = link.Remove(0, 24);
            if (parse == "bukuManual")
                bukuManual.Attributes.Add("style", "display:block;");
            else if (parse == "SOP")
                SOP.Attributes.Add("style", "display:block;");
            else if (parse == "Pelatihan")
                Pelatihan.Attributes.Add("style", "display:block;");
            else if (parse == "pembaruan")
                pembaruan.Attributes.Add("style", "display:block;");

            if (!IsPostBack)
            {
                //bukuManual.Attributes.Add("style", "display:block;");
            }

            con.Open();
            SqlCommand countcmd = new SqlCommand("FileCount2", con);
            countcmd.CommandType = CommandType.StoredProcedure;
            countcmd.Parameters.AddWithValue("@kategori1", "Buku Manual");
            countcmd.Parameters.AddWithValue("@kategori2", "Cibinong");
            int valuecount = (int)countcmd.ExecuteScalar();
            lblBukuCBI.Text = valuecount.ToString();
            con.Close();
            con.Open();

            SqlCommand countcmd1 = new SqlCommand("FileCount2", con);
            countcmd1.CommandType = CommandType.StoredProcedure;
            countcmd1.Parameters.AddWithValue("@kategori1", "Buku Manual");
            countcmd1.Parameters.AddWithValue("@kategori2", "Banjarmasin");
            int valuecount1 = (int)countcmd1.ExecuteScalar();
            lblBukuBJM.Text = valuecount1.ToString();
            con.Close();

            con.Open();
            SqlCommand countcmd2 = new SqlCommand("FileCount2", con);
            countcmd2.CommandType = CommandType.StoredProcedure;
            countcmd2.Parameters.AddWithValue("@kategori1", "Buku Manual");
            countcmd2.Parameters.AddWithValue("@kategori2", "Medan");
            int valuecount2 = (int)countcmd2.ExecuteScalar();
            lblBukuMDN.Text = valuecount2.ToString();
            con.Close();
            con.Open();


            SqlCommand countSOP = new SqlCommand("FileCount2", con);
            countSOP.CommandType = CommandType.StoredProcedure;
            countSOP.Parameters.AddWithValue("@kategori1", "SOP");
            countSOP.Parameters.AddWithValue("@kategori2", "Telkom 2");
            int valueSOP = (int)countSOP.ExecuteScalar();
            lblSOPT2.Text = valueSOP.ToString();
            con.Close();
            con.Open();

            SqlCommand countSOP1 = new SqlCommand("FileCount2", con);
            countSOP1.CommandType = CommandType.StoredProcedure;
            countSOP1.Parameters.AddWithValue("@kategori1", "SOP");
            countSOP1.Parameters.AddWithValue("@kategori2", "Telkom 3S");
            int valueSOP1 = (int)countSOP1.ExecuteScalar();
            lblSOPT3S.Text = valueSOP1.ToString();
            con.Close();
            con.Open();

            SqlCommand countSOP2 = new SqlCommand("FileCount2", con);
            countSOP2.CommandType = CommandType.StoredProcedure;
            countSOP2.Parameters.AddWithValue("@kategori1", "SOP");
            countSOP2.Parameters.AddWithValue("@kategori2", "MPSat");
            int valueSOP2 = (int)countSOP2.ExecuteScalar();
            lblSOPMP.Text = valueSOP2.ToString();
            con.Close();
            con.Open();

            SqlCommand countSOP3 = new SqlCommand("FileCount2", con);
            countSOP3.CommandType = CommandType.StoredProcedure;
            countSOP3.Parameters.AddWithValue("@kategori1", "SOP");
            countSOP3.Parameters.AddWithValue("@kategori2", "Other");
            int valueSOP3 = (int)countSOP3.ExecuteScalar();
            lblSOPOther.Text = valueSOP3.ToString();
            con.Close();
            con.Open();

            SqlCommand countPel1 = new SqlCommand("FileCount2", con);
            countPel1.CommandType = CommandType.StoredProcedure;
            countPel1.Parameters.AddWithValue("@kategori1", "Pelatihan");
            countPel1.Parameters.AddWithValue("@kategori2", "Satelit");
            int valuepel1 = (int)countPel1.ExecuteScalar();
            lblPelSat.Text = valuepel1.ToString();
            con.Close();
            con.Open();

            SqlCommand countPel2 = new SqlCommand("FileCount2", con);
            countPel2.CommandType = CommandType.StoredProcedure;
            countPel2.Parameters.AddWithValue("@kategori1", "Pelatihan");
            countPel2.Parameters.AddWithValue("@kategori2", "Ground");
            int valuepel2 = (int)countPel2.ExecuteScalar();
            lblPelGro.Text = valuepel2.ToString();
            con.Close();
            con.Open();

            SqlCommand countPem1 = new SqlCommand("FileCount2", con);
            countPem1.CommandType = CommandType.StoredProcedure;
            countPem1.Parameters.AddWithValue("@kategori1", "Pembaruan Konfigurasi");
            countPem1.Parameters.AddWithValue("@kategori2", "Operasional");
            int valuepem1 = (int)countPem1.ExecuteScalar();
            lblPemOp.Text = valuepem1.ToString();
            con.Close();
            con.Open();

            SqlCommand countPem2 = new SqlCommand("FileCount2", con);
            countPem2.CommandType = CommandType.StoredProcedure;
            countPem2.Parameters.AddWithValue("@kategori1", "Pembaruan Konfigurasi");
            countPem2.Parameters.AddWithValue("@kategori2", "Network");
            int valuepem2 = (int)countPem2.ExecuteScalar();
            lblPemNe.Text = valuepem2.ToString();
            con.Close();
            con.Open();

            SqlCommand countPem3 = new SqlCommand("FileCount2", con);
            countPem3.CommandType = CommandType.StoredProcedure;
            countPem3.Parameters.AddWithValue("@kategori1", "Pembaruan Konfigurasi");
            countPem3.Parameters.AddWithValue("@kategori2", "Communication & Monitor");
            int valuepem3 = (int)countPem3.ExecuteScalar();
            lblPemCom.Text = valuepem3.ToString();
            con.Close();
            con.Open();
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