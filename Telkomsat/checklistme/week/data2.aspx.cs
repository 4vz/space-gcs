using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using ClosedXML.Excel;
using System.IO;
using System.Configuration;

namespace Telkomsat.checklistme.week
{
    public partial class data2 : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable2 = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", style1 = "a", query, weekk = "", mingguan, nilai = "", tahunan = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string Parameter = "a", query2 = "A", tanggalku = "s", value = "1", myroom2 = "A", myroom = "", ruangan, tipe, satuan, room = "m", start, end, inisial, siang = "", malam = "", tanggal1;
        string[] words = { "a", "a" };
        string[] akhir;
        double hasil, tampil, total, diisi, weeknumber, weeknum;
        int j = 0, endtahun, endbulan;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["minggu"] != null)
            {
                weekk = Request.QueryString["minggu"];
                tahunan = Request.QueryString["tahun"];
            }

            if (Request.QueryString["room"] != null)
                room = Request.QueryString["room"];

            tanggalku = tanggal1;

            query = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe, d.nilai, d.tanggal from checkme_parameterwmy r left join
                    checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat left join checkme_datawmy d on d.id_parameter = r.id_parameter
                    and d.tahun = '{tahunan}' and week = '{weekk}' where r.kategori='week' and p.ruangan='{room}' order by r.id_perangkat";

            tablepersen();
            tableticket();

            /*if (Request.QueryString["ruangan"] != null)
            {
                myroom = Request.QueryString["ruangan"].ToString();
                if (myroom == "ruangan")
                    myroom = "ruangan";
                else
                    myroom = "'" + myroom + "'";

                if (myroom == "ruangan")
                    ddlruang.Text = "-Semua Ruangan-";
                else
                    ddlruang.Text = Request.QueryString["ruangan"].ToString();

                query = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe, d.nilai, d.tanggal from checkme_parameterwmy r left join
                    checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat left join checkme_datawmy d on d.id_parameter = r.id_parameter
                    and d.tanggal = '{tanggalku}' where r.kategori='week' and p.ruangan={myroom} order by r.id_perangkat";
            }
            else
            {
                query = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe, d.nilai, d.tanggal from checkme_parameterwmy r left join
                    checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat left join checkme_datawmy d on d.id_parameter = r.id_parameter
                    and d.tanggal = '{tanggalku}' where r.kategori='week' order by r.id_perangkat";
            } 
            tableticket();*/
        }

        protected void Filter_ServerClick(object sender, EventArgs e)
        {
            /*room = ddlruang.SelectedValue;
            query = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe, d.nilai, d.tanggal from checkme_parameterwmy r left join
                    checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat left join checkme_datawmy d on d.id_parameter = r.id_parameter
                    and d.tanggal = '{tanggalku}' where r.kategori='week' and p.ruangan='{room}' order by r.id_perangkat";
            tableticket();*/
        }

        protected void ExportExcel(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe, d.nilai, d.tanggal from checkme_parameterwmy r left join
                    checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat left join checkme_datawmy d on d.id_parameter = r.id_parameter
                    and d.tahun = '{tahunan}' and week = '{weekk}' where r.kategori='week' and p.ruangan='{room}' order by r.id_perangkat";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sqlcmd.Connection = con;
                    sda.SelectCommand = sqlcmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Asset");

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", $"attachment;filename=datamaintenance_{room}.xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                }

            }
        }


        void tablepersen()
        {
            DateTime now = DateTime.Now;
            DateTime startdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime enddate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            string style, class1, ruang, alias, querytotal, queryisi;
            SqlDataAdapter daheader, dapersen, dabar;
            DataSet dsheader = new DataSet();
            DataSet dspersen = new DataSet();
            DataSet dsbar = new DataSet();
            DateTime wib;
            double hari = Convert.ToInt32(DateTime.Now.DayOfYear.ToString());
            double minggu = (double)Math.Ceiling(hari / 7);

            DateTime dta = new DateTime(2020, 1, 1);
            while (dta.DayOfWeek != DayOfWeek.Monday)
            {
                dta = dta.AddDays(1);
            }

            weeknumber = Convert.ToInt32(DateTime.Now.DayOfYear) - Convert.ToInt32(dta.ToString("dd"));                                                                     //Mingguan
            weeknum = (double)Math.Ceiling(weeknumber / 7);
            mingguan = weeknum.ToString();

            string queryheader = $@"select ruangan from checkme_perangkatwmy t join checkme_parameterwmy r on t.id_perangkat=r.id_perangkat
                                    where r.kategori='week' group by ruangan";
            sqlCon.Open();
            SqlCommand cmdheader = new SqlCommand(queryheader, sqlCon);
            daheader = new SqlDataAdapter(cmdheader);
            daheader.Fill(dsheader);
            cmdheader.ExecuteNonQuery();
            sqlCon.Close();
            style = "font-weight:bold";
            wib = DateTime.UtcNow + new TimeSpan(7, 0, 0);
            tanggal1 = wib.ToString("yyyy/MM/dd");
            if (dsheader.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsheader.Tables[0].Rows.Count; ++i)
                {
                    dsbar.Clear();
                    ruang = dsheader.Tables[0].Rows[i]["ruangan"].ToString();
                    querytotal = $@"select COUNT(*) as total from checkme_parameterwmy r join checkme_perangkatwmy t on r.id_perangkat=t.id_perangkat where ruangan = '{ruang}' and r.kategori='week'";
                    sqlCon.Open();
                    SqlCommand cmdruang = new SqlCommand(querytotal, sqlCon);
                    dapersen = new SqlDataAdapter(cmdruang);
                    dapersen.Fill(dspersen);
                    cmdruang.ExecuteNonQuery();
                    sqlCon.Close();

                    queryisi = $@"select COUNT(*) as isi from checkme_datawmy d join checkme_parameterwmy r on d.id_parameter=r.id_parameter
                                    join checkme_perangkatwmy t on r.id_perangkat=t.id_perangkat where ruangan = '{ruang}' and d.nilai != '' and week='{weekk}' and tahun='{tahunan}'";
                    sqlCon.Open();
                    SqlCommand cmdisi = new SqlCommand(queryisi, sqlCon);
                    dabar = new SqlDataAdapter(cmdisi);
                    dabar.Fill(dsbar);
                    cmdisi.ExecuteNonQuery();
                    sqlCon.Close();
                    if (dsbar.Tables[0].Rows.Count > 0)
                    {
                        diisi = Convert.ToDouble(dsbar.Tables[0].Rows[0]["isi"].ToString());
                    }
                    else
                    {
                        diisi = 0;
                    }

                    total = Convert.ToDouble(dspersen.Tables[0].Rows[i]["total"].ToString());

                    hasil = ((double)diisi / total) * 100;

                    if (hasil == 100)
                    {
                        class1 = "progress-bar-green";
                    }
                    else
                    {
                        class1 = "progress-bar-red";
                    }
                    tampil = Math.Round(hasil);
                    if ((i % 2) == 0)
                    {
                        if (i > 1)
                            htmlTable2.Append("</div>");
                        htmlTable2.Append("<div class=\"col-md-6\">");
                    }
                    htmlTable2.Append("<div class=\"progress-group\">");
                    htmlTable2.Append($"<a class=\"link\" href=\"data2.aspx?room={ruang}&minggu={weekk}&tahun={tahunan}\" style=\"font-size:12px;\">" + ruang + "</a>");
                    htmlTable2.Append($"<span class=\"progress-number\">" + tampil + "%</span>");
                    htmlTable2.Append("<div class=\"progress sm\">");
                    htmlTable2.Append($"<div class=\"progress-bar {class1}\" style=\"width:{tampil}% \"></div>");
                    htmlTable2.Append($"</div></div>");
                    //Response.Write(queryisi);
                }

                PlaceHolder1.Controls.Add(new Literal { Text = htmlTable2.ToString() });
            }
            /*Label[] arr = new Label[] { lblheader1, lblheader2, lblheader3, lblheader4, lblheader5, lblheader6, lblheader7, lblheader8, lblheader9, lblheader10,
            lblheader11, lblheader12, lblheader13, lblheader14, lblheader15, lblheader16, lblheader17, lblheader18, lblheader19, lblheader20,
            lblheader21, lblheader22, lblheader23};
            for (int i = 0; i < dsheader.Tables[0].Rows.Count; ++i)
            {
                arr[i].Text = dsheader.Tables[0].Rows[i]["ruangan"].ToString();
                arr[i].Font.Bold = true;
            }*/
        }


        void tableticket()
        {

            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Ruangan</th><th>Perangkat</th><th>Serial Number</th><th>Parameter</th><th>Nilai</th><th>Satuan</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");

            int count = ds.Tables[0].Rows.Count;
            string[] looping = new string[count];
            akhir = new string[count];
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblkosong.Visible = false;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        
                        IDdata = ds.Tables[0].Rows[i]["id_parameter"].ToString();
                        Perangkat = ds.Tables[0].Rows[i]["Perangkat"].ToString();
                        SN = ds.Tables[0].Rows[i]["sn"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["Parameter"].ToString();
                        ruangan = ds.Tables[0].Rows[i]["ruangan"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["satuan"].ToString();

                        style3 = "font-weight:normal";
                        nilai = ds.Tables[0].Rows[i]["nilai"].ToString();

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ruangan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Perangkat + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-weight:bold\">" + nilai + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable.Append("</tr>");
                        value = Request.Form["idticket"];
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");

                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
                else
                {
                    //lblkosong.Visible = true;
                    //lblkosong.Text = "Data tidak tersedia";
                }
            }

        }
    }
}