using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat.admin
{
    public partial class listjustifikasi : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable2 = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string kategori, style3, warna1, warna2, warna3, warna4, jenis, query;
        protected void Page_Load(object sender, EventArgs e)
        {
            string ja = "", jp = "", petugas = "", status = "";
            jenis = Request.QueryString["jenis"];

            /*if(jenis != null)
            {
                if(jenis == "diajukan")
                {
                    query = $"SELECT * from AdminJustifikasi where AJ_Status = 'diajukan' order by AJ_ID desc";
                }
            }
            else
            {
                query = $"SELECT * from AdminJustifikasi order by AJ_ID desc";
            }*/
            
            if (Request.QueryString["ja"] == null && Request.QueryString["status"] == null)
            {
                query = $"SELECT * from AdminJustifikasi where AJ_Status is not null order by AJ_ID desc";
            }
            else
            {
                if (Request.QueryString["ja"] != null)
                {
                    ja = "AJ_JA='" + Request.QueryString["ja"] + "'";
                    if (Request.QueryString["ja"] == "-")
                        ja = "AJ_JA=AJ_JA";
                }
                else
                {
                    ja = "AJ_JA=AJ_JA";
                }

                if (Request.QueryString["jp"] != null)
                {
                    jp = $"AJ_JUPD='" + Request.QueryString["jp"] + "' and"; ;
                    if (Request.QueryString["jp"].ToString() == "-")
                        jp = "";
                }

                if (Request.QueryString["petugas"] != null)
                {
                    petugas = $"AJ_Profile='" + Request.QueryString["petugas"] + "' and"; ;
                    if (Request.QueryString["petugas"].ToString() == "-")
                        petugas = "";
                }

                if (Request.QueryString["status"] != null)
                {
                    status = $"AJ_Status='" + Request.QueryString["status"] + "' and"; ;
                    if (Request.QueryString["status"].ToString() == "-")
                        status = "";
                }

                query = $"SELECT * from AdminJustifikasi where {jp} {petugas} {status} {ja} order by AJ_ID desc";

                if (!IsPostBack)
                {
                    sojp.Value = Request.QueryString["jp"].ToString();
                    txtnamaakun.Text = Request.QueryString["ja"].ToString();
                    txtpetugas.Text = Request.QueryString["petugas"].ToString();
                    ddlstatus.SelectedValue = Request.QueryString["status"].ToString();
                }
            }


            string previllage;
            string user = Session["iduser"].ToString();
            string query2 = $"Select * from AdminProfile where AP_Nama = '{user}'";
            DataSet ds = Settings.LoadDataSet(query2);

            if (ds.Tables[0].Rows.Count > 0)
            {
                previllage = ds.Tables[0].Rows[0]["AP_Previllage"].ToString();
                if(previllage == "User" || previllage == "User Organik" || previllage == "SA")
                {
                    btntambah.Visible = true;
                }
            }
                referens();
            //riwayat();
        }

        protected void Filter_Click(object sender, EventArgs e)
        {
            string namaakun = "-", jp = "-", kl = "-", status = "-", petugas = "-";

            if (sojp.Value != "")
                jp = sojp.Value;

            if (ddlstatus.SelectedValue != "")
                status = ddlstatus.SelectedValue;

            if (txtnamaakun.Text != "")
               namaakun = txtnamaakun.Text;

            if (txtpetugas.Text != "")
                petugas = txtpetugas.Text;

            Response.Redirect($"listjustifikasi.aspx?petugas={petugas}&ja={namaakun}&jp={jp}&status={status}");
        }

        void riwayat()
        {
            string query = $"SELECT * from AdminApprove where AA_AJ = '{txtidaj.Text}'";
            DataSet ds = Settings.LoadDataSet(query);
            htmlTable2.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable2.Append("<thead>");
            htmlTable2.Append("<tr><th>#</th><th>Tanggal</th><th>Approval</th><th>Status</th><th>Keterangan</th></tr>");
            htmlTable2.Append("</thead>");

            htmlTable2.Append("<tbody>");

            if (ds.Tables[0].Rows.Count > 0)
            {
                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["AA_Tanggal"]);
                    string tanggal = dt.ToString("dd MMM yyyy");
                    string approve = ds.Tables[0].Rows[0]["AA_Aksi"].ToString();
                    string person = ds.Tables[0].Rows[0]["AA_Person"].ToString();
                    string keterangan = ds.Tables[0].Rows[0]["AA_Alasan"].ToString();
                    htmlTable2.Append("<tr>");
                    htmlTable2.Append("<td>" + (i + 1) + "</td>");
                    htmlTable2.Append("<td>" + $"<label style=\"{style3}\">" + tanggal + "</label>" + "</td>");
                    htmlTable2.Append("<td>" + $"<label style=\"{style3}\">" + person + "</label>" + "</td>");
                    htmlTable2.Append("<td>" + $"<label style=\"{style3}\">" + approve + "</label>" + "</td>");
                    htmlTable2.Append("<td>" + $"<label style=\"{style3}\">" + keterangan + "</label>" + "</td>");
                    htmlTable2.Append("</tr>");
                }
                htmlTable.Append("</tbody>");
                htmlTable.Append("</table>");
                PlaceHolder2.Controls.Add(new Literal { Text = htmlTable2.ToString() });
            }
        }

        void referens()
        {
            string IDdata, jupd, ja, kegiatan, status, statusapp;
            style3 = "font-weight:normal";
            DataSet ds = Settings.LoadDataSet(query);

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>#</th><th>Nomor Justifikasi</th><th>Jenis Anggaran</th><th>Nama Kegiatan</th><th>Status Justifikasi</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
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
                        else if (status == "ok")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "lightskyblue";
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
                        else if (status.ToLower() == "revision")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "yellow";
                            warna3 = "black";
                            statusapp = "menunggu diperbaiki";
                        }
                        else if (status.ToLower() == "dikembalikan")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "sandybrown";
                            warna3 = "black";
                            statusapp = "dikembalikan ke GM";
                        }
                        else if (status.ToLower() == "pending")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "darkcyan";
                            warna3 = "black";
                            statusapp = "ditunda";
                        }
                        else
                        {
                            warna1 = "black";
                            warna2 = "black";
                            warna3 = "black";
                            warna4 = "black";
                            statusapp = "menunggu diajukan";
                        }

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + (i + 1) + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + jupd + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ja + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + kegiatan + "</label>" + "</td>");
                        htmlTable.Append("<td>" +
                            $"<span style=\"margin-right:5px; color:{warna1}\"><i class=\"fa fa-circle\"></i></span>" + $"<span style=\"margin-right:5px; color:{warna2}\"><i class=\"fa fa-circle\"></i></span>" +
                            $"<span style=\"margin-right:5px; color:{warna3}\"><i class=\"fa fa-circle\"></i></span>" + 
                            $"<label style=\"font-size:13px; {style3}; display:block\">" + statusapp + "</label>" +"</td>");
                        /*htmlTable.Append("<td>" + $"<button type=\"button\" id=\"btnadmin\" style=\"margin-right:10px\" value=\"{IDdata}\" class=\"btn btn-sm btn-primary datariwayat\" data-toggle=\"modal\" data-target=\"#modalriwayat\">" + 
                            "<span><i class=\"fa fa-book\"></i></span>" + "</button>" + "</td>");*/
                        htmlTable.Append("<td>" + $"<a href=\"detailjustifikasi.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</button>" + "</td>");
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