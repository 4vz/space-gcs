using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.asset
{
    public partial class tambah : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnSave.UniqueID;
            txtPIC.Text = Session["username"].ToString();
            if (!IsPostBack)
            {

            }
            lblWaktu.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtKelompok.Text == "" || txtNama.Text == "" || txtNama.Text == "" || txtPIC.Text == "")
            {
                lblUpdate.Text = "Tanda * Wajib Diisi";
                lblUpdate.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("AsAddAsset", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
                sqlCmd.Parameters.AddWithValue("@Kelompok", txtKelompok.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Merk", txtMerk.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Model", txtModel.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@SN", txtSN.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@PN", txtPN.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@TAHUN", txtTahun.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Fungsi", ddlFungsi.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Keterangan", txtKeterangan.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Status", ddlStatus.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Site", ddlSite.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Gudang", ddlGudang.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Rak", ddlRak.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Telkom2", ddlTelkom2.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Telkom3S", ddlTelkom3S.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@MPSat", ddlMPSat.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Waktu", lblWaktu.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@PIC", txtPIC.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
                string contactID = hfContactID.Value;
                lblUpdate.Text = "Berhasil Menyimpan";
                lblUpdate.ForeColor = System.Drawing.Color.Green;
                if (contactID == "")
                    lblSuccessMessage.Text = "Berhasil Menyimpan";
                clear();
            }


        }
        void clear()
        {
            txtNama.Text = txtMerk.Text = txtModel.Text = txtPIC.Text = txtPN.Text = txtSN.Text = txtTahun.Text = txtKeterangan.Text = "";
            ddlFungsi.Text = ddlGudang.Text = ddlMPSat.Text = ddlRak.Text = ddlSite.Text = ddlStatus.Text = ddlTelkom2.Text = ddlTelkom3S.Text = "";
        }
    }
}