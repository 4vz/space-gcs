using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.logbook1
{
    public partial class iddatabase : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            hfContactID.Value = Session["SN"].ToString();
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("AsViewBySN", sqlCon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@SN", hfContactID.Value.ToString());
            DataSet dtbl = new DataSet();
            sqlda.Fill(dtbl);

            foreach(DataRow dr in dtbl.Tables[0].Rows)
            {
                lblID.Text = dtbl.Tables[0].Rows[0]["ID_Asset"].ToString();
            }
            /*lblID.Text = dtbl.Rows[0]["ID_Asset"].ToString();
            lblKelompok.Text = dtbl.Rows[0]["Kelompok"].ToString();
            lblNama.Text = dtbl.Rows[0]["Nama"].ToString();
            lblMerk.Text = dtbl.Rows[0]["Merk"].ToString();
            lblModel.Text = dtbl.Rows[0]["Model"].ToString();
            lblSN.Text = dtbl.Rows[0]["S/N"].ToString();
            lblPN.Text = dtbl.Rows[0]["P/N"].ToString();
            lblSite.Text = dtbl.Rows[0]["Site"].ToString();
            lblGudang.Text = dtbl.Rows[0]["Gudang"].ToString();
            lblRak.Text = dtbl.Rows[0]["Rak"].ToString();
            lblTelkom2.Text = dtbl.Rows[0]["Telkom2"].ToString();
            lblTelkom3S.Text = dtbl.Rows[0]["Telkom3s"].ToString();
            lblMpsat.Text = dtbl.Rows[0]["MPsat"].ToString();
            lblFungsi.Text = dtbl.Rows[0]["fungsi"].ToString();
            lblStatus.Text = dtbl.Rows[0]["status"].ToString();
            lblKeterangan.Text = dtbl.Rows[0]["keterangan"].ToString();**/
            

        }

        protected void btnKembali_Click(object sender, EventArgs e)
        {
            string prev = Request.UrlReferrer.ToString();
            Response.Redirect(prev);
        }
    }
}