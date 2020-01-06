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
            if(Session["username"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("~/error.aspx");
            }
            txtPIC.Text = Session["username"].ToString();
            if (!IsPostBack)
            {

            }
            string com = "SELECT NAMA FROM Asset1 WHERE NAMA IS NOT NULL group by NAMA";
            SqlDataAdapter adpt = new SqlDataAdapter(com, sqlCon);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            ddlperangkat.DataSource = dt;
            ddlperangkat.DataBind();
            ddlperangkat.DataTextField = "NAMA";
            ddlperangkat.DataValueField = "NAMA";
            ddlperangkat.DataBind();

            lblWaktu.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("~/error.aspx");
            }

            if (txtKelompok.Text == "" || txtPIC.Text == "" || txtNama.Text == "" || txtMerk.Text == "")
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
                if(txtKelompok.Text == "RF EQUIPMENT")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtNama.Text.Trim());
                else if (txtKelompok.Text == "BASEBAND")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamabb.Text.Trim());
                else if (txtKelompok.Text == "SERVER & NETWORK ELEMENT")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamasn.Text.Trim());
                else if (txtKelompok.Text == "MEASURING INSTRUMENT")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamaMI.Text.Trim());
                else if (txtKelompok.Text == "ANTENNA")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamaantena.Text.Trim());
                else if (txtKelompok.Text == "WORKSTATION")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamaWo.Text.Trim());
                else if (txtKelompok.Text == "LICENSE")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamaLi.Text.Trim());
                else if (txtKelompok.Text == "ACCESORIES")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamaAcc.Text.Trim());
                else if (txtKelompok.Text == "ELECTRICAL")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamaEl.Text.Trim());
                else if (txtKelompok.Text == "GENSET")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamaGe.Text.Trim());
                else if (txtKelompok.Text == "AIR CONDITIONING")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamaAC.Text.Trim());
                else if (txtKelompok.Text == "UPS")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamaUPS.Text.Trim());
                else if (txtKelompok.Text == "FIRE ALARM PROTECTION")
                    sqlCmd.Parameters.AddWithValue("@Nama", txtnamaFi.Text.Trim());

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