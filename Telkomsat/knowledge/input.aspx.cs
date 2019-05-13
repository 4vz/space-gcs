using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Telkomsat.Logbook
{
    public partial class input : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWaktu.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtJudul.Text == "" || txtNama.Text == "")
            {
                lblUpdate.Text = "Tanda * Wajib Diisi";
                lblUpdate.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Byte[] image;
                Stream s = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(s);
                image = br.ReadBytes((Int32)s.Length);

                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("CreateData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
                sqlCmd.Parameters.AddWithValue("@Waktu", txtWaktu.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Judul", txtJudul.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Kategori", txtKategori.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Aktivitas", txtAktivitas.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@gambar", image);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                string contactID = hfContactID.Value;
                lblUpdate.Text = "Berhasil Menyimpan";
                lblUpdate.ForeColor = System.Drawing.Color.Green;
            }


        }
    }
}