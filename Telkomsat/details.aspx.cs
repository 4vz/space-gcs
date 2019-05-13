using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lblEquipment.Text = Request.QueryString["equ"].ToString();
            //lblEquipment.Text = Session["equ"].ToString();
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
            Response.Redirect("~/edit.aspx");
        }
    }
}