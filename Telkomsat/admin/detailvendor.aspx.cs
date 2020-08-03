using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;

namespace Telkomsat.admin
{
    public partial class detailvendor : System.Web.UI.Page
    {
        string[] myket, myvolume;
        string tanggal, query, iddata, query1, style3, querynom;
        double grandtotal;
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                iddata = Request.QueryString["id"].ToString();

                query1 = $@"SELECT * from AdminVendor WHERE AV_ID = '{iddata}'";
                DataSet ds = Settings.LoadDataSet(query1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!IsPostBack)
                    {
                        lblemail.Text = ds.Tables[0].Rows[0]["AV_EmailPerusahaan"].ToString();
                        lblemailpic.Text = ds.Tables[0].Rows[0]["AV_Email"].ToString();
                        lbljp.Text = ds.Tables[0].Rows[0]["AV_JP"].ToString();
                        lblnambank.Text = ds.Tables[0].Rows[0]["AV_NBPerusahaan"].ToString();
                        lblnbpic.Text = ds.Tables[0].Rows[0]["AV_NBPIC"].ToString();
                        lblnorek.Text = ds.Tables[0].Rows[0]["AV_NRPerusahaan"].ToString();
                        lblnote.Text = ds.Tables[0].Rows[0]["AV_NTPerusahaan"].ToString();
                        lblnp.Text = ds.Tables[0].Rows[0]["AV_Perusahaan"].ToString();
                        lblnrpic.Text = ds.Tables[0].Rows[0]["AV_NRPIC"].ToString();
                        lblotpic.Text = ds.Tables[0].Rows[0]["AV_TLP"].ToString();
                        lblnpwp.Text = ds.Tables[0].Rows[0]["AV_NPWP"].ToString();

                        lblpic.Text = ds.Tables[0].Rows[0]["AV_PIC"].ToString();
                    }

                }
            }

            nominal();
        }

        void nominal()
        {
            string keterangan, jumlah, total, tanggal, IDdata;

            querynom = $"select * from AdminvendorNom where AVN_AV='{iddata}' order by AVN_ID desc";

            DataSet ds = Settings.LoadDataSet(querynom);

            htmlTable.Append("<table id=\"example2\" class=\"table table-bordered table-striped\">");
            htmlTable.Append("<tdead>");
            htmlTable.Append("<tr><td>Tanggal</td><td>Keterangan</td><td>Nominal</td><td>Total</td></tr>");
            htmlTable.Append("</tdead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["AVN_ID"].ToString();
                        keterangan = ds.Tables[0].Rows[i]["AVN_NK"].ToString();
                        jumlah = Convert.ToInt32(ds.Tables[0].Rows[i]["AVN_Nominal"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        total = Convert.ToInt32(ds.Tables[0].Rows[i]["AVN_Total"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        DateTime tgl = Convert.ToDateTime(ds.Tables[0].Rows[i]["AVN_Tanggal"]);
                        tanggal = tgl.ToString("dd-MM-yyyy");

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + keterangan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + "Rp. " + jumlah + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + "Rp. " + total + "</label>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}