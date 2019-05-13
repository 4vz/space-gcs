using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Telkomsat.knowledge
{
    public partial class tambahpost : System.Web.UI.Page
    {
        int i;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWaktu.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            if (Session["user"] == null)
                Response.Redirect("~/login.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            Byte[] image1, image2, image3, image4;
            Stream s1 = FileUpload1.PostedFile.InputStream;
            Stream s2 = FileUpload2.PostedFile.InputStream;
            Stream s3 = FileUpload3.PostedFile.InputStream;
            Stream s4 = FileUpload4.PostedFile.InputStream;
            BinaryReader br1 = new BinaryReader(s1);
            BinaryReader br2 = new BinaryReader(s2);
            BinaryReader br3 = new BinaryReader(s3);
            BinaryReader br4 = new BinaryReader(s4);
            image1 = br1.ReadBytes((Int32)s1.Length);
            image2 = br2.ReadBytes((Int32)s2.Length);
            image3 = br3.ReadBytes((Int32)s3.Length);
            image4 = br4.ReadBytes((Int32)s4.Length);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand sqlCmd = new SqlCommand("TambahGb", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@Gambar1", image1);
            sqlCmd.Parameters.AddWithValue("@Gambar2", image2);
            sqlCmd.Parameters.AddWithValue("@Gambar3", image3);
            sqlCmd.Parameters.AddWithValue("@Gambar4", image4);
            sqlCmd.ExecuteNonQuery();
            i = Convert.ToInt32(sqlCmd.ExecuteScalar());

            sqlCon.Close();
            sqlCon.Open();
            SqlCommand cmdLog = new SqlCommand("TambahPost", sqlCon);
            cmdLog.CommandType = CommandType.StoredProcedure;
            cmdLog.Parameters.AddWithValue("@ID_gb", i);
            cmdLog.Parameters.AddWithValue("@Waktu", txtWaktu.Text.Trim());
            cmdLog.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
            cmdLog.Parameters.AddWithValue("@Kategori", txtKategori.Text.Trim());
            cmdLog.Parameters.AddWithValue("@Judul", txtJudul.Text.Trim());
            cmdLog.Parameters.AddWithValue("@Post", txtAktivitas.Text.Trim());
            cmdLog.ExecuteNonQuery();
            sqlCon.Close();
            lblUpdate.Text = "Berhasil Menyimpan";
            lblUpdate.ForeColor = System.Drawing.Color.Green;

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

        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/tambah.aspx");
        }
    }
}