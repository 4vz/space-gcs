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
    public partial class detailrkap2 : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string[] myket, myvolume;
        string tanggal, query, iddata, query1, style3, warna1, warna2, warna3, warna4;
        double grandtotal;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryco;
            if (Request.QueryString["id"] != null)
            {
                iddata = Request.QueryString["id"].ToString();

                query1 = $@"SELECT * from AdminRKAP WHERE ARK_ID = '{iddata}'";
                DataSet ds = Settings.LoadDataSet(query1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!IsPostBack)
                    {
                        //double dharga = Convert.ToDouble(ds.Tables[0].Rows[0]["ARK_Harga"]);
                        string jan = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_Januari"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();
                        string feb = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_Februari"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();
                        string mar = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_Maret"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();
                        string apr = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_April"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();
                        string mei = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_Mei"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();
                        string jun = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_Juni"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();
                        string jul = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_Juli"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();
                        string agu = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_Agustus"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();
                        string sep = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_September"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();
                        string okt = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_Oktober"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();
                        string nov = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_November"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();
                        string des = Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_Desember"]).ToString("N0", CultureInfo.GetCultureInfo("de")).ToString();

                        /*double djan = dharga * Convert.ToDouble(jan);
                        double dfeb = dharga * Convert.ToDouble(feb);
                        double dmar = dharga * Convert.ToDouble(mar);
                        double dapr = dharga * Convert.ToDouble(apr);
                        double dmei = dharga * Convert.ToDouble(mei);
                        double djun = dharga * Convert.ToDouble(jun);
                        double djul = dharga * Convert.ToDouble(jul);
                        double dagu = dharga * Convert.ToDouble(agu);
                        double dsep = dharga * Convert.ToDouble(sep);
                        double dokt = dharga * Convert.ToDouble(okt);
                        double dnov = dharga * Convert.ToDouble(nov);
                        double ddes = dharga * Convert.ToDouble(des);*/

                        lblbg.Text = ds.Tables[0].Rows[0]["ARK_SU"].ToString();
                        lblcc.Text = ds.Tables[0].Rows[0]["ARK_CC"].ToString();
                        lblkategori.Text = ds.Tables[0].Rows[0]["ARK_Kategori"].ToString();
                        lblna.Text = ds.Tables[0].Rows[0]["ARK_Aktivitas"].ToString();
                        lblnamaakun.Text = ds.Tables[0].Rows[0]["ARK_NA"].ToString();
                        lblnoa.Text = ds.Tables[0].Rows[0]["ARK_NoA"].ToString();
                        lblsatuan.Text = ds.Tables[0].Rows[0]["ARK_Satuan"].ToString();
                        lblsu.Text = ds.Tables[0].Rows[0]["ARK_BG"].ToString();
                        lblgt.Text = "Rp. " + Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_GT"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        lbltahunan.Text = "Rp. " + Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_Tahunan"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        lblsisagt.Text = "Rp. " + Convert.ToInt64(ds.Tables[0].Rows[0]["ARK_GTS"]).ToString("N0", CultureInfo.GetCultureInfo("de"));

                        voljan.Text = jan;
                        volfeb.Text = feb;
                        volmar.Text = mar;
                        volapr.Text = apr;
                        volmei.Text = mei;
                        voljuni.Text = jun;
                        voljuli.Text = jul;
                        volagu.Text = agu;
                        volsep.Text = sep;
                        volokt.Text = okt;
                        volnov.Text = nov;
                        voldes.Text = des;
/*
                        totjan.Text = djan.ToString();
                        totfeb.Text = dfeb.ToString();
                        totmar.Text = dmar.ToString();
                        totapr.Text = dapr.ToString();
                        totmei.Text = dmei.ToString();
                        totjuni.Text = djun.ToString();
                        totjuli.Text = djul.ToString();
                        totagu.Text = dagu.ToString();
                        totsep.Text = dsep.ToString();
                        totokt.Text = dokt.ToString();
                        totnov.Text = dnov.ToString();
                        totdes.Text = ddes.ToString();*/
                    }

                }
                referens();

                queryco = $"select ARK_CarryOver from AdminRKAP where ARK_ID='{iddata}'";

                DataSet ds2 = Settings.LoadDataSet(queryco);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    if (ds2.Tables[0].Rows[0]["ARK_CarryOver"].ToString() == null || ds2.Tables[0].Rows[0]["ARK_CarryOver"].ToString() == "")
                    {

                    }
                    else
                    {
                        lblcarry.Text = ds2.Tables[0].Rows[0]["ARK_CarryOver"].ToString();
                        lblcarry.Font.Bold = true;
                    }
                }
            }
        }

        void referens()
        {
            string query, IDdata, jupd, ja, kegiatan, status, statusapp, nilai;
            query = $"SELECT * from AdminJustifikasi where AJ_AR = '{iddata}' or AJ_AR2 = '{iddata}'";
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
                        nilai = Convert.ToInt64(ds.Tables[0].Rows[i]["AJ_Nilai"]).ToString("N0", CultureInfo.GetCultureInfo("de"));

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
    }
}