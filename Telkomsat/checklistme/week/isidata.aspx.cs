using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace Telkomsat.checklistme.week
{
    public partial class isidata : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable2 = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", querytanggal = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string Parameter = "a", query2 = "A", idddl = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, query1, user, inisial, tanggal1, tahun, mingguan, bulanan, tahunan;
        string[] words = { "a", "a" };
        string[] akhir;
        double hasil, tampil, total, diisi, weeknumber, weeknum;
        int j = 0, k, jenischeck, angkabulan;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {
                if (Session["mastersheltermeweek"] != null)
                {
                    DropDownList1.Text = Session["mastersheltermeweek"].ToString();
                }
            }*/

            if (Request.QueryString["room"] != null)
            {
                room = Request.QueryString["room"];
                lblroom.Text = room;
            }
            if (Session["iduser"] != null)
            {
                user = Session["iduser"].ToString();
            }

            DateTime dta = new DateTime(2020, 1, 1);
            while (dta.DayOfWeek != DayOfWeek.Monday)
            {
                dta = dta.AddDays(1);
            }

            weeknumber = Convert.ToInt32(DateTime.Now.DayOfYear) - Convert.ToInt32(dta.ToString("dd"));                                                                     //Mingguan
            weeknum = (double)Math.Ceiling(weeknumber / 7);
            mingguan = weeknum.ToString();

            string[] bulan = { " ", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "Nopember", "Desember" };                 //Bulanan
            angkabulan = DateTime.Now.Month;
            bulanan = bulan[angkabulan];

            tahunan = DateTime.Now.Year.ToString();                                                                                                                     //tahunan

            var mulai = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            var selesai = DateTime.Today.AddDays(+(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            string week1 = mulai.ToString("yyyy/MM/dd");
            string week2 = selesai.ToString("yyyy/MM/dd");
            query2 = $@"select count(*) from checkme_datawmy d left join checkme_parameterwmy r 
						on d.id_parameter=r.id_parameter left join
                        checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat where kategori = 'week'
						and d.tanggal >= '{week1}' and d.tanggal <= '{week2}'";
            sqlCon.Open();
            SqlCommand cmd5 = new SqlCommand(query2, sqlCon);
            string output = cmd5.ExecuteScalar().ToString();
            jenischeck = Convert.ToInt32(output);
            sqlCon.Close();
            if (jenischeck >= 1)
            {
                lbledit.Visible = true;
                lbledit.Text = $"Data checklist sudah terisi untuk minggu ini klik untuk ";
                LinkButton1.Visible = true;
            }
            else
            {
                tableticket();
            }
            tablepersen();
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
                                    join checkme_perangkatwmy t on r.id_perangkat=t.id_perangkat where ruangan = '{ruang}' and d.nilai != '' and week='{mingguan}'and month='{bulanan}' and tahun='{tahunan}'";
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
                    htmlTable2.Append($"<a class=\"link\" href=\"isidata.aspx?room={ruang}\" style=\"font-size:12px;\">" + ruang + "</a>");
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


        protected void Pilih_Click(object sender, EventArgs e)
        {
            //Session["mastersheltermeweek"] = DropDownList1.Text;
            //Response.Redirect($"~/checklistme/week/isidata.aspx?room={DropDownList1.SelectedValue}", false);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"edit.aspx?room={room}");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string data = string.Join(",", akhir);
            query1 = $"insert into checkme_datawmy (tanggal, id_profile, id_parameter, jenis, nilai, week, month, tahun) values {data}";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            Session["inisialweek"] = null;

            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);
            Response.Redirect("isidata.aspx");
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
            Session["inisialweek"] = "buka";

        }

        void tableticket()
        {
            if (Session["inisialweek"] != null)
                query = $@"select r.id_parameter, p.Perangkat, r.satuan, p.sn, p.ruangan, r.parameter, r.tipe, d.nilai from checkme_parameterwmy r left join
                            checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat left join checkme_datawmy d on d.id_parameter = r.id_parameter
                            where ruangan = '{room}' AND d.tanggal = (SELECT MAX(tanggal) from checkme_datawmy d LEFT join checkme_parameterwmy r 
                            on r.id_parameter=d.id_parameter left join checkme_perangkatwmy p on p.ID_Perangkat = r.ID_Perangkat
                            where p.ruangan = '{room}' and d.nilai is not null and d.jenis = 'week') and d.jenis = 'week' order by r.id_perangkat";
            else
                query = $@"select r.id_parameter, p.Perangkat, r.satuan, p.sn, p.ruangan, r.parameter, r.tipe from checkme_parameterwmy r left join
                        checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat where ruangan = '{room}' and kategori = 'week' order by r.id_perangkat";


            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Perangkat</th><th>Serial Number</th><th>Parameter</th><th style=\"min-width:100px\">Nilai</th><th>Satuan</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");

            int count = ds.Tables[0].Rows.Count;
            string[] looping = new string[count];
            akhir = new string[count];
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

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

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;

                        if (Session["inisialweek"] != null)
                            nilai = ds.Tables[0].Rows[i]["nilai"].ToString();
                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Perangkat + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        if (tipe == "N")
                            htmlTable.Append("<td>" + $"<input type =\"text\" value=\"{nilai}\" runat=\"server\" class=\"form-control\" name=\"idticket\" id={idtxt}>" + "</td>");
                        else if (tipe == "BN")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"BIR\" > BIR </option><option value =\"NO BIR\"> NO BIR </option></select > " + " </td>");
                        else if (tipe == "OC")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"OPEN\" > OPEN </option><option value =\"CLOSE\"> CLOSE </option></select > " + " </td>");
                        else if (tipe == "FL")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"FULL\" > FULL </option><option value =\"LOW\"> LOW </option></select > " + " </td>");
                        else if (tipe == "AN")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"ALREADY\" > ALREADY </option><option value =\"NOT YET\"> NOT YET </option></select > " + " </td>");

                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable.Append("</tr>");
                        value = Request.Form["idticket"];
                        //Response.Write(value);

                        looping[i] = IDdata;

                        //Response.Write( "bisa" + words[1]);
                        int j = i - 1;
                        //Response.Write(seats);
                        //looping = "('" + IDdata + "'," + seats + "),";
                        loop = IDdata + "," + loop;

                    }
                    if (value != null)
                    {
                        string[] lines = Regex.Split(value, ",");

                        foreach (string line in lines)
                        {
                            //Response.Write(line);
                            akhir[j] = "('" + tanggal + "','" + user + "','" + looping[j] + "','" + "week" + "','" + line + "','" + mingguan + "','" + bulanan + "','" + tahunan + "')";
                            j++;
                        }
                    }
                    //Response.Write(string.Join("\n", akhir));
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");

                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}