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
    public partial class details : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Redirect("~/error.aspx");
            }

            hfContactID.Value = Session["hf"].ToString();
            lblKelompok.Text = Session["kelompok"].ToString();
            lblNama.Text = Session["nama"].ToString();
            lblMerk.Text = Session["merk"].ToString();
            lblModel.Text = Session["model"].ToString();
            lblSN.Text = Session["sn"].ToString();
            lblPN.Text = Session["pn"].ToString();
            lblTahun.Text = Session["tahun"].ToString();
            lblSite.Text = Session["site"].ToString();
            lblGudang.Text = Session["gudang"].ToString();
            lblRak.Text = Session["rak"].ToString();
            lblTelkom2.Text = Session["telkom2"].ToString();
            lblTelkom3S.Text = Session["telkom3s"].ToString();
            lblMpsat.Text = Session["mpsat"].ToString();
            lblFungsi.Text = Session["fungsi"].ToString();
            lblStatus.Text = Session["status"].ToString();
            lblKeterangan.Text = Session["keterangan"].ToString();
            lblWaktu.Text = Session["Waktu"].ToString();
            lblPIC.Text = Session["PIC"].ToString();
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
            if (lblFungsi.Text == "")
            {
                lblFungsi.Text = "-";
            }
            if (lblStatus.Text == "")
            {
                lblStatus.Text = "-";
            }
            if (lblKeterangan.Text == "")
            {
                lblKeterangan.Text = "-";
            }

            
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/asset/edit.aspx");
        }
        protected void btnMore_Click(object sender, EventArgs e)
        {

            hfContactID.Value = Session["hf"].ToString();
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("LoViewID", sqlCon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", hfContactID.Value);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            gvContact.DataSource = dtbl;
            gvContact.DataBind();
            sqlCon.Close();
            if (gvContact.Rows.Count == 0)
            {
                lblMore.Text = "Tidak ada histori untuk perangkat ini";
                linkLog.Visible = false;
            }
            else
            {
                lblMore.Visible = false;
                linkLog.Visible = true;
            }

            
        }
        protected void linkSN_Click(object sender, EventArgs e)
        {
            Session["SN"] = lblSN.Text;
            Response.Redirect("~/logbook1/snasset.aspx");
        }
    }
}