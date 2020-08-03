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
    public partial class detailrkap : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string[] myket, myvolume;
        string tanggal, query, iddata, query1, style3, warna1, warna2, warna3, warna4;
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
                        lblharga.Text = "Rp. " + Convert.ToInt32(ds.Tables[0].Rows[0]["ARK_Harga"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        lblna.Text = ds.Tables[0].Rows[0]["ARK_Aktivitas"].ToString();
                        lblnamaakun.Text = ds.Tables[0].Rows[0]["ARK_NA"].ToString();
                        lblnoa.Text = ds.Tables[0].Rows[0]["ARK_NoA"].ToString();
                        lblsatuan.Text = ds.Tables[0].Rows[0]["ARK_Satuan"].ToString();
                        lblsu.Text = ds.Tables[0].Rows[0]["ARK_SU"].ToString();
                        lbltahun.Text = ds.Tables[0].Rows[0]["ARK_Tahunan"].ToString();
                        lblgt.Text = "Rp. " + Convert.ToInt32(ds.Tables[0].Rows[0]["ARK_GT"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        lblsisagt.Text = "Rp. " + Convert.ToInt32(ds.Tables[0].Rows[0]["ARK_GTS"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                    }

                }
                bulan();
                referens();
            }
        }

        void referens()
        {
            string query, IDdata, jupd, ja, kegiatan, status, statusapp, nilai;
            query = $"SELECT * from AdminJustifikasi where AJ_AR = '{iddata}'";
            style3 = "font-weight:normal";
            DataSet ds = Settings.LoadDataSet(query);

            htmlTable1.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable1.Append("<thead>");
            htmlTable1.Append("<tr><th>#</th><th>Nomor Justifikasi</th><th>Jenis Anggaran</th><th>Nama Kegiatan</th><th>Nilai</th><th>Status Justifikasi</th><th>Action</th></tr>");
            htmlTable1.Append("</thead>");

            htmlTable1.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["AJ_ID"].ToString();
                        jupd = ds.Tables[0].Rows[i]["AJ_NJ"].ToString();
                        ja = ds.Tables[0].Rows[i]["AJ_JA"].ToString();
                        kegiatan = ds.Tables[0].Rows[i]["AJ_NK"].ToString();
                        status = ds.Tables[0].Rows[i]["AJ_Status"].ToString();
                        nilai = Convert.ToInt32(ds.Tables[0].Rows[i]["AJ_Nilai"]).ToString("N0", CultureInfo.GetCultureInfo("de"));

                        if (status == "diajukan")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "black";
                            warna3 = "black";
                            warna4 = "black";
                            statusapp = "menunggu approve GM";
                        }

                        else if (status == "gm")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "deepskyblue";
                            warna3 = "black";
                            statusapp = "menunggu approve Bendahara";
                        }
                        else if (status == "admin")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "deepskyblue";
                            warna3 = "deepskyblue";
                            statusapp = "selesai";
                        }
                        else if (status == "reject")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "red";
                            warna3 = "black";
                            statusapp = "ditolak";
                        }
                        else
                        {
                            warna1 = "black";
                            warna2 = "black";
                            warna3 = "black";
                            warna4 = "black";
                            statusapp = "menunggu diajukan";
                        }

                        htmlTable1.Append("<tr>");
                        htmlTable1.Append("<td>" + (i + 1) + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + jupd + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + ja + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + kegiatan + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + "Rp. " + nilai + "</label>" + "</td>");
                        htmlTable1.Append("<td>" +
                            $"<span style=\"margin-right:5px; color:{warna1}\"><i class=\"fa fa-circle\"></i></span>" + $"<span style=\"margin-right:5px; color:{warna2}\"><i class=\"fa fa-circle\"></i></span>" +
                            $"<span style=\"margin-right:5px; color:{warna3}\"><i class=\"fa fa-circle\"></i></span>" +
                            $"<label style=\"font-size:13px; {style3}; display:block\">" + statusapp + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<a href=\"detailjustifikasi.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</button>" + "</td>");
                        htmlTable1.Append("</tr>");
                    }
                    htmlTable1.Append("</tbody>");
                    htmlTable1.Append("</table>");
                    PlaceHolder2.Controls.Add(new Literal { Text = htmlTable1.ToString() });
                }
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
                    total = Convert.ToInt32(ds.Tables[0].Rows[i]["ARKB_Total"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                    bulan = ds.Tables[0].Rows[i]["ARKB_Bulan"].ToString();

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + bulan + "</label>" + "</td>");
                    htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + volume + "</label>" + "</td>");
                    htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + "Rp. " + total + "</label>" + "</td>");
                    htmlTable.Append("</tr>");
                }
                htmlTable.Append("</tbody>");
                htmlTable.Append("</table>");
                PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });

            }
        }
    }
}