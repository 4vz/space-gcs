﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;
using System.IO;

namespace Telkomsat.admin
{
    public partial class listpengeluaran : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string IDdata = "kitaa", total = "", keterangan, tanggal = "", nominal, query3, approve, brame, style, input = "", kategori = "", style5 = "", kategori1 = "", query;
        string start = "01/01/2019", filename, filepath, end = "01/12/2048";


        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        int rek1harkat, rek2harkat, rek1me, rek2me, harkat, me;
        protected void Page_Load(object sender, EventArgs e)
        {
            string query2, user;

            user = Session["iduser"].ToString();
            query2 = $"Select * from AdminProfile where AP_Nama = '{user}'";
            DataSet ds2 = Settings.LoadDataSet(query2);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0]["AP_Previllage"].ToString().IsIn((new string[] { "Admin Bendahara", "User", "SA" })))
                    btntmbh.Visible = true;

                if (ds2.Tables[0].Rows[0]["AP_Previllage"].ToString() != "User")
                    lidraft.Visible = false;
            }
            if (!IsPostBack)
            {
                query = @"select p.nama, a.* from administrator a join AdminProfile e on a.id_profile=e.AP_ID join Profile p on p.id_profile=e.AP_Nama
                            where kategori = 'pengeluaran' and approve='admin' order by id_admin desc";
                query3 = @"select * from administrator where kategori = 'pengeluaran' and (approve='diajukan' or approve='gm' or approve ='revision' or approve ='draft') order by id_admin desc";
                tableticket();
                tabledraft();
            }

            if (Request.QueryString["tipe"] == "draft")
            {
                txtliactive.Text = "draft";
                lidraft.Attributes.Add("class", "active");
            }
            else
            {
                txtliactive.Text = "pengeluaran";
                lipengeluaran.Attributes.Add("class", "active");
            }

        }

        protected void Edit_File(object sender, EventArgs e)
        {
            string queryfile;
            if (FileUpload1.HasFiles)
            {
                string physicalpath = Server.MapPath("~/evidence/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);

                int filecount = 0;
                foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                {
                    filecount += 1;
                    filename = Path.GetFileName(file.FileName);
                    filepath = "~/evidence/" + filename;
                    file.SaveAs(physicalpath + filename);
                }
                //lblstatus.Text = filecount + " files upload";
            }

            queryfile = $@"UPDATE administrator set evidence='{filename}', evidencepath='{filepath}' where id_admin = '{txtidl.Text}'";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(queryfile, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect("listpengeluaran.aspx");
        }

        void tableticket()
        {
            string simpanan, evidence, status8;

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>Nama</th><th>Keterangan</th><th>Nominal</th><th>Status</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_admin"].ToString();
                        DateTime datee = (DateTime)ds.Tables[0].Rows[i]["tanggal"];
                        tanggal = datee.ToString("dd/MM/yyyy");
                        simpanan = ds.Tables[0].Rows[i]["nama"].ToString();
                        evidence = ds.Tables[0].Rows[i]["evidencepath"].ToString().Replace("~", "..");
                        keterangan = ds.Tables[0].Rows[i]["keterangan"].ToString();
                        nominal = Convert.ToInt32(ds.Tables[0].Rows[i]["input"]).ToString("N0", CultureInfo.GetCultureInfo("de"));

                        string query8 = $"select sum(AT_total) [total] from AdminPertanggungan where AT_AD = '{IDdata}'";
                        DataSet ds8 = Settings.LoadDataSet(query8);

                        if(ds.Tables[0].Rows[i]["input"].ToString() == ds8.Tables[0].Rows[0]["total"].ToString())
                        {
                            status8 = "close";
                        }
                        else
                        {
                            status8 = "waiting";
                        }
                        /*if (ds.Tables[0].Rows[i]["gm"].ToString() == "unread")
                            style5 = "font-weight:bold;";
                        else
                            style5 = "font-weight:normal;";*/

                        if (status8 == "close")
                            style = "label label-info";
                        else if (status8 == "waiting")
                            style = "label label-warning";

                        htmlTable.Append($"<tr style=\"{style5}\">");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:10px; {style5} color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + simpanan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + keterangan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + "Rp. " + nominal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px;\" class=\"{style}\">" + status8 + "</label>" + "</td>");
                        /*if (evidence == "" || evidence == null)
                        {
                            htmlTable.Append("<td>" + $"<label style=\"{style5}\">" + ds.Tables[0].Rows[i]["evidence"].ToString() + "</label>" + "</td>");
                        }
                        else
                        {
                            if (evidence.Substring(evidence.LastIndexOf('.') + 1).ToLower().IsIn(new string[] { "jpg", "jpeg", "png", "bmp", "jfif", "gif" }))
                            {
                                htmlTable.Append("<td>" + $"<label style=\"{style5}\">" + $"<img style=\"display:block\" class=\"myImg\" src=\"{evidence}\" height=\"200\" />" + "</label>" + "</td>");
                            }
                            else
                            {
                                htmlTable.Append("<td>" + $"<label style=\"{style5}\">" + ds.Tables[0].Rows[i]["evidence"].ToString() + "</label>" + "</td>");
                            }
                        }*/

                        htmlTable.Append("<td>" + $"<a href=\"detail.aspx?id={IDdata}&tipe=3Xc5T79kLm1Oo\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</a>");
/*                        if (evidence == "" || evidence == null)
                            htmlTable.Append($"<button type=\"button\" value=\"{IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-warning datatotal\" data-toggle=\"modal\" data-target=\"#modalupdate\" id=\"edit\">" + "<span class=\"fa fa-paperclip\"></span>" + "</button>");
*/                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                }
            }
        }

        void tabledraft()
        {
            string simpanan, evidence, tanggal, keterangan, nominal, IDdata, approve;

            DataSet ds1 = Settings.LoadDataSet(query3);

            htmlTable1.Append("<table id=\"example3\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable1.Append("<thead>");
            htmlTable1.Append("<tr><th>Tanggal</th><th>Kategori</th><th>Keterangan</th><th>Nominal</th><th>Status</th><th>Action</th></tr>");
            htmlTable1.Append("</thead>");

            htmlTable1.Append("<tbody>");
            if (!object.Equals(ds1.Tables[0], null))
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds1.Tables[0].Rows[i]["id_admin"].ToString();
                        DateTime datee = (DateTime)ds1.Tables[0].Rows[i]["tanggal"];
                        tanggal = datee.ToString("dd/MM/yyyy");
                        simpanan = ds1.Tables[0].Rows[i]["simpanan"].ToString();
                        evidence = ds1.Tables[0].Rows[i]["evidencepath"].ToString().Replace("~", "..");
                        keterangan = ds1.Tables[0].Rows[i]["keterangan"].ToString();
                        approve = ds1.Tables[0].Rows[i]["approve"].ToString();
                        nominal = Convert.ToInt32(ds1.Tables[0].Rows[i]["input"]).ToString("N0", CultureInfo.GetCultureInfo("de"));

                        if (ds1.Tables[0].Rows[i]["gm"].ToString() == "unread")
                            style5 = "font-weight:bold;";
                        else
                            style5 = "font-weight:normal;";

                        if (approve == "diajukan")
                            style = "label label-info";
                        else if (approve == "gm")
                            style = "label label-success";
                        else if (approve == "revision")
                            style = "label label-warning";

                        htmlTable1.Append($"<tr style=\"{style5}\">");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:10px; {style5} color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + simpanan + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + keterangan + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + "Rp. " + nominal + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:12px;\" class=\"{style}\">" + approve + "</label>" + "</td>");
                        /*if (evidence == "" || evidence == null)
                        {
                            htmlTable1.Append("<td>" + $"<label style=\"{style5}\">" + ds1.Tables[0].Rows[i]["evidence"].ToString() + "</label>" + "</td>");
                        }
                        else
                        {
                            if (evidence.Substring(evidence.LastIndexOf('.') + 1).ToLower().IsIn(new string[] { "jpg", "jpeg", "png", "bmp", "jfif", "gif" }))
                            {
                                htmlTable1.Append("<td>" + $"<label style=\"{style5}\">" + $"<img style=\"display:block\" class=\"myImg\" src=\"{evidence}\" height=\"200\" />" + "</label>" + "</td>");
                            }
                            else
                            {
                                htmlTable1.Append("<td>" + $"<label style=\"{style5}\">" + ds1.Tables[0].Rows[i]["evidence"].ToString() + "</label>" + "</td>");
                            }
                        }*/

                        htmlTable1.Append("<td>" + $"<a href=\"detail.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</a>");
/*                        if (evidence == "" || evidence == null)
                            htmlTable1.Append($"<button type=\"button\" value=\"{IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-warning datatotal\" data-toggle=\"modal\" data-target=\"#modalupdate\" id=\"edit\">" + "<span class=\"fa fa-paperclip\"></span>" + "</button>");
*/                        if(approve == "draft") 
                        {
                            htmlTable1.Append($"<a onclick=\"confirmselesai('action.aspx?idapp={IDdata}&tipe=pengeluaran')\" class=\"btn btn-sm btn-success\" id=\"btndelete\">" + "Ajukan" + "</a>");
                            htmlTable1.Append($"<a href=\"editpengeluaran.aspx?id={IDdata}\" class=\"pull-right\" id=\"btnedit\">" + "Edit" + "</a>");

                        }

                        htmlTable1.Append("</td></tr>");
                    }
                    htmlTable1.Append("</tbody>");
                    htmlTable1.Append("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable1.ToString() });

                }
            }
        }

    }
}