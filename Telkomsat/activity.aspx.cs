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

namespace Telkomsat
{
    public partial class activity : System.Web.UI.Page
    {
        string tanggalbef, myquery;
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTableBulan = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            lblProfile1.Text = Session["nama1"].ToString();
            int abulan, atahun;
            string dbulan = "";
            

            if (Request.QueryString["bulan"] == null || Request.QueryString["tahun"] == null)
            {
                abulan = Convert.ToInt32(DateTime.Now.Month);
                atahun = Convert.ToInt32(DateTime.Now.Year);
                dbulan = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            }
            else
            {
                abulan = Convert.ToInt32(Request.QueryString["bulan"]);
                atahun = Convert.ToInt32(Request.QueryString["tahun"]);
                dbulan = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(abulan);
            }

            spmonth.InnerText = dbulan + " " + atahun;

            myquery = $@"select l.*, nama from log l left join Profile p on p.id_profile=l.id_profile where month(l.tanggal) = {abulan} and year(l.tanggal) = {atahun}
                           order by l.tanggal desc, l.id_log desc, l.tipe";

            tablechhk();
            tablebulan();
        }
        void tablechhk()
        {
            string query, tanggal, petugas, judul, tipe, pic, nama, keterangan, bulan, tahun, tanggalnow, mth;
            SqlDataAdapter da;
            DataSet ds = new DataSet();
                
            bulan = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
            tahun = DateTime.Now.Year.ToString();
            
            query = $@"select l.*, nama from log l left join Profile p on p.id_profile=l.id_profile order by l.tanggal desc, l.id_log desc, l.tipe";

            SqlCommand cmd = new SqlCommand(myquery, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DateTime date1 = (DateTime)ds.Tables[0].Rows[i]["tanggal"];
                        tanggal = date1.ToString("yyyy/MM/dd");
                        tanggalnow = date1.ToString("dd");
                        mth = date1.ToString("MMMM");
                        judul = ds.Tables[0].Rows[i]["judul"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        pic = ds.Tables[0].Rows[i]["pic"].ToString();
                        nama = ds.Tables[0].Rows[i]["nama"].ToString();
                        keterangan = ds.Tables[0].Rows[i]["keterangan"].ToString();
                        if(tanggal != tanggalbef)
                        {
                            htmlTable.AppendLine("</ul>");
                            htmlTable.AppendLine("<div style=\"border-style:groove; border-left:2px; border-right:2px; text-align:center\">" + tanggalnow + " " + mth  + "</div>");
                            tanggalbef = tanggal;
                            htmlTable.AppendLine("<ul style=\"list-style-type: none;\">");
                        }

                        if(tipe == "appme")
                        {                            
                            htmlTable.AppendLine("<li>" + "<span style=\"color:red; font-size:16px; margin-right:10px\">" + "<i class=\"fa fa-check-circle-o\"></i>" + "</span>" +
                                "checklist harian me waktu " + "<a>" + keterangan + "</a>" + " tanggal " + "<a>" + tanggal + "</a>" + " telah di approve oleh " + "<a>" + pic + "</a>" + "</li>" );
                        }

                        if (tipe == "app")
                        {
                            htmlTable.AppendLine("<li>" + "<span style=\"color:blue; font-size:16px; margin-right:10px\">" + "<i class=\"fa fa-check-circle-o\"></i>" + "</span>" +
                                "checklist harian harkat tanggal " + "<a>" + tanggal + "</a>" + " telah di approve oleh " + "<a>" + pic + "</a>" + "</li>");
                        }

                        if (tipe == "mainhk")
                        {
                            htmlTable.AppendLine("<li>" + "<span style=\"color:dodgerblue; font-size:16px; margin-right:10px\">" + "<i class=\"fa fa-gear\"></i>" + "</span>" +
                                "<a>" + nama + "</a>" + " menambahkan " + judul + "</a>" + "</li>");
                        }

                        if (tipe == "mainme")
                        {
                            htmlTable.AppendLine("<li>" + "<span style=\"color:red; font-size:16px; margin-right:10px\">" + "<i class=\"fa fa-gear\"></i>" + "</span>" +
                                "<a>" + nama + "</a>" + " menambahkan " + judul + "</a>" + "</li>");
                        }

                        if (tipe == "tchme")
                        {
                            htmlTable.AppendLine("<li>" + "<span style=\"color:orangered; font-size:16px; margin-right:10px\">" + "<i class=\"fa fa-file-text-o\"></i>" + "</span>" +
                                "<a>" + nama + "</a>" + " melakukan " + judul + " " + "<a>" + tanggal + "</a>" + " waktu " + "<a>" + keterangan + "</a>" + "</li>");                        
                        }

                        if (tipe == "tch")
                        {
                            htmlTable.AppendLine("<li>" + "<span style=\"color:dodgerblue; font-size:16px; margin-right:10px\">" + "<i class=\"fa fa-file-text-o\"></i>" + "</span>" +
                                "<a>" + nama + "</a>" + " melakukan " + judul + " " + "<a>" + tanggal + "</a>" + "</li>");
                        }

                        if (tipe == "tlog")
                        {
                            htmlTable.AppendLine("<li>" + "<span style=\"color:black; font-size:16px; margin-right:10px\">" + "<i class=\"fa fa-book\"></i>" + "</span>" +
                                "<a>" + nama + "</a>" + " menambahkan logbook " + "<a>" + judul + "</a>" + "</li>");
                        }

                        if (tipe == "tass")
                        {
                            htmlTable.AppendLine("<li>" + "<span style=\"color:red; font-size:16px; margin-right:10px\">" + "<i class=\"fa fa-database\"></i>" + "</span>" +
                                "<a>" + nama + "</a>" + " menambahkan asset " + "<a>" + judul + "</a>" + " dengan s/n " + keterangan + "</li>");
                        }

                        if (tanggal != tanggalbef)
                        {

                        }
                        else
                        {
                            tanggalbef = tanggal;
                        }
                    }
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                }
            }
        }

        void tablebulan()
        {
            string tanggal, query, stbulan, btanggal = "";
            int itbulan;

            query = $@"select year(tanggal) AS tahun, month(tanggal) AS bulan from log group by year(tanggal), month(tanggal) order by year(tanggal) desc, month(tanggal) desc";

            DataSet ds = Settings.LoadDataSet(query);
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        tanggal = ds.Tables[0].Rows[i]["tahun"].ToString();
                        itbulan = Convert.ToInt32(ds.Tables[0].Rows[i]["bulan"]);

                        stbulan = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(itbulan);

                        if(tanggal != btanggal)
                        {
                            btanggal = tanggal;
                            htmlTableBulan.AppendLine("</ul>");
                            htmlTableBulan.AppendLine("</li>");
                            htmlTableBulan.AppendLine("</ul>");
                            htmlTableBulan.AppendLine("<ul class=\"sidebar-menu\" data-widget=\"tree\">");
                            htmlTableBulan.AppendLine("<li class=\"treeview\"><a href=\"#\">");
                            htmlTableBulan.AppendLine($"{tanggal}");
                            htmlTableBulan.AppendLine("<span class=\"pull-right-container\">");
                            htmlTableBulan.AppendLine("<i class=\"fa fa-angle-left pull-right\"></i>");
                            htmlTableBulan.AppendLine("</span></a>");
                            htmlTableBulan.AppendLine("<ul class=\"treeview-menu\">");
                        }
                        htmlTableBulan.AppendLine($"<li><a href=activity.aspx?bulan={itbulan}&tahun={tanggal}>" + stbulan + "</a></li>");
                    }
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTableBulan.ToString() });
                }
            }
        }
    }
}