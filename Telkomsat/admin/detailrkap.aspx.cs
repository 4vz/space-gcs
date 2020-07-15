using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text
;
namespace Telkomsat.admin
{
    public partial class detailrkap : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        string[] myket, myvolume;
        string tanggal, query, iddata, query1;
        double grandtotal;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                iddata = Request.QueryString["id"].ToString();

                query1 = $@"SELECT * from AdminRKAP WHERE ARK_ID = '{iddata}'";
                DataSet ds = Settings.LoadDataSet(query1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!IsPostBack)
                    {
                        lblbg.Text = ds.Tables[0].Rows[0]["ARK_BG"].ToString();
                        lblcc.Text = ds.Tables[0].Rows[0]["ARK_CC"].ToString();
                        lblharga.Text = "Rp. " + ds.Tables[0].Rows[0]["ARK_Harga"].ToString();
                        lblna.Text = ds.Tables[0].Rows[0]["ARK_Aktivitas"].ToString();
                        lblnamaakun.Text = ds.Tables[0].Rows[0]["ARK_NA"].ToString();
                        lblnoa.Text = ds.Tables[0].Rows[0]["ARK_NoA"].ToString();
                        lblsatuan.Text = ds.Tables[0].Rows[0]["ARK_Satuan"].ToString();
                        lblsu.Text = ds.Tables[0].Rows[0]["ARK_SU"].ToString();
                        lbltahun.Text = ds.Tables[0].Rows[0]["ARK_Tahunan"].ToString();
                        lblgt.Text = "Rp. " + ds.Tables[0].Rows[0]["ARK_GT"].ToString();
                    }

                }
                bulan();
            }
        }

        void bulan()
        {
            string bulan, volume, total;
            query = $"Select * from AdminRKAPBulanan where ARKB_ARK = '{iddata}' ORDER BY ARKB_AB";

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Bulan</th><th>Volume</th><th>Total</th></tr>");
            htmlTable.Append("</thead>");
            htmlTable.Append("<tbody>");

            DataSet ds = Settings.LoadDataSet(query);
            if(ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //DateTime date1 = (DateTime)ds.Tables[0].Rows[i]["tanggal"];
                    //tanggal = date1.ToString("yyyy/MM/dd");
                    volume = ds.Tables[0].Rows[i]["ARKB_Volume"].ToString();
                    total = ds.Tables[0].Rows[i]["ARKB_Total"].ToString();
                    bulan = ds.Tables[0].Rows[i]["ARKB_Bulan"].ToString();

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + bulan + "</label>" + "</td>");
                    htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + volume + "</label>" + "</td>");
                    htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + total + "</label>" + "</td>");
                    htmlTable.Append("</tr>");
                }
                htmlTable.Append("</tbody>");
                htmlTable.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });

            }
        }
    }
}