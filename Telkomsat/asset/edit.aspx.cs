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
    public partial class edit : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection  = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWaktu.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            
            if (!IsPostBack)
            {
                hfContactID.Value = Session["hf"].ToString();
                lblKelompok.Text = Session["kelompok"].ToString();
                lblNama.Text = Session["nama"].ToString();
                lblMerk.Text = Session["merk"].ToString();
                lblModel.Text = Session["model"].ToString();
                lblSN.Text = Session["sn"].ToString();
                lblPN.Text = Session["pn"].ToString();
                lblTahun.Text = Session["tahun"].ToString();
                ddlSite.Text = Session["site"].ToString();
                ddlGudang.Text = Session["gudang"].ToString();
                ddlRak.Text = Session["rak"].ToString();
                lblTelkom2.Text = Session["telkom2"].ToString();
                lblTelkom3S.Text = Session["telkom3s"].ToString();
                lblMpsat.Text = Session["mpsat"].ToString();
                ddlFungsi.Text = Session["fungsi"].ToString();
                ddlStatus.Text = Session["status"].ToString();
                txtKeterangan.Text = Session["keterangan"].ToString();
                if (lblModel.Text == "")
                {
                    lblModel.Text = "-";
                }
                if (lblSN.Text == "")
                {
                    lblSN.Text = "-";
                }
                if (lblPN.Text == "")
                {
                    lblPN.Text = "-";
                }
            }

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string Waktu = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
            if (txtPIC.Text == "")
            {
                lblSukses.Text = "Tanda * Wajib Diisi";
                lblSukses.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("AsUpdateData", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ID", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
                sqlCmd.Parameters.AddWithValue("@Site", ddlSite.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Gudang", ddlGudang.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Rak", ddlRak.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Fungsi", ddlFungsi.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Status", ddlStatus.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Keterangan", txtKeterangan.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@Waktu", lblWaktu.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@PIC", txtPIC.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                sqlCon.Open();
                SqlCommand cmd = new SqlCommand("AsAddHistory", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_Asset", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
                cmd.Parameters.AddWithValue("@tanggal1", Waktu);
                cmd.Parameters.AddWithValue("Site1", Session["site"].ToString());
                cmd.Parameters.AddWithValue("Gudang1", Session["gudang"].ToString());
                cmd.Parameters.AddWithValue("Rak1", Session["rak"].ToString());
                cmd.Parameters.AddWithValue("Fungsi1", Session["fungsi"].ToString());
                cmd.Parameters.AddWithValue("Status1", Session["status"].ToString());
                cmd.Parameters.AddWithValue("Keterangan1", Session["keterangan"].ToString());
                cmd.ExecuteNonQuery();
                sqlCon.Close();

                if(ddlStatus.Text == "BAIK")
                {
                    sqlCon.Open();
                    SqlCommand cmd1 = new SqlCommand("AsAddStatus", sqlCon);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@ID_Asset", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
                    cmd1.Parameters.AddWithValue("@Status2", ddlStatus.Text);
                    cmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }

                lblSukses.Text = "Update Sukses";
                lblSukses.ForeColor = System.Drawing.Color.LawnGreen;
                ddlFungsi.Enabled = false;
                ddlGudang.Enabled = false;
                ddlRak.Enabled = false;
                ddlSite.Enabled = false;
                ddlStatus.Enabled = false;
                txtKeterangan.Enabled = false;
                txtPIC.Enabled = false;
                btnUpdate.Enabled = false;
                Session["Update"] = "Update Berhasil";
                //Response.Redirect("~/details.aspx");
            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("AsDeleteByID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", Convert.ToInt32(hfContactID.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            lblSukses.Text = "Berhasil Delete";
            lblSukses.ForeColor = System.Drawing.Color.DarkGreen;

            lblKelompok.Text = "";
            lblNama.Text = "";
            lblMerk.Text = "";
            lblModel.Text = "";
            lblSN.Text = "";
            lblPN.Text = "";
            lblTahun.Text = "";
            ddlSite.Text = "";
            ddlGudang.Text = "";
            ddlRak.Text = "";
            lblTelkom2.Text = "";
            lblTelkom3S.Text = "";
            lblMpsat.Text = "";
            ddlFungsi.Text = "";
            ddlStatus.Text = "";
            txtKeterangan.Text = "";

            ddlFungsi.Visible = false;
            ddlGudang.Visible = false;
            ddlRak.Visible = false;
            ddlSite.Visible = false;
            ddlStatus.Visible = false;
            txtKeterangan.Visible = false;

            btnUpdate.Enabled = false;
        }
    }
}