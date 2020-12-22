using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.maintenancehk.semester
{
    public partial class data : System.Web.UI.Page
    {
        StringBuilder htmltable = new StringBuilder();
        SqlConnection sqlcon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string tanggal, waktu, tanggal1, ruangan, semester, tahun;
        DateTime wib, startdate, enddate;
        double hasil, tampil, total, diisi;
        protected void Page_Load(object sender, EventArgs e)
        {
            semester = Request.QueryString["semester"].ToString();
            tahun = Request.QueryString["tahun"].ToString();
            tanggal = Request.QueryString["tanggal"];
            if(Request.QueryString["unit"] == null || Request.QueryString["unit"] == "")
            {
                tablepersen();
            }
            else
            {
                ruangan = Request.QueryString["unit"].ToString();
                tableunit();
            }

            

            //Response.Write(startdate + "    " + enddate);

        }

        void tablepersen()
        {
            DateTime now = DateTime.Now;
            startdate = new DateTime(DateTime.Now.Year, 1, 1);
            enddate = new DateTime(DateTime.Now.Year, 7, 1);
            if (DateTime.Now.Month >= 7)
            {
                startdate = new DateTime(DateTime.Now.Year, 7, 1);
                enddate = new DateTime(DateTime.Now.Year + 1, 1, 1);
            }
            string style, class1, ruang, querytotal, queryisi;
            SqlDataAdapter daheader, dapersen, dabar;
            DataSet dsheader = new DataSet();
            DataSet dspersen = new DataSet();
            DataSet dsbar = new DataSet();
            string queryheader = "select unit from maintenancehk_perangkat where jenis= 'SEMESTER' group by unit order by unit";
            sqlcon.Open();
            SqlCommand cmdheader = new SqlCommand(queryheader, sqlcon);
            daheader = new SqlDataAdapter(cmdheader);
            daheader.Fill(dsheader);
            cmdheader.ExecuteNonQuery();
            sqlcon.Close();
            style = "font-weight:bold";
            wib = DateTime.UtcNow + new TimeSpan(7, 0, 0);
            tanggal1 = wib.ToString("yyyy/MM/dd");
            if (dsheader.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsheader.Tables[0].Rows.Count; ++i)
                {
                    dsbar.Clear();
                    ruang = dsheader.Tables[0].Rows[i]["unit"].ToString();
                    querytotal = $@"SELECT COUNT(*) as total FROM maintenancehk_parameter r join maintenancehk_perangkat t 
                                    on r.id_perangkat=t.id_perangkat where t.unit = '{ruang}'  and t.jenis='SEMESTER' GROUP BY t.unit";
                    sqlcon.Open();
                    SqlCommand cmdruang = new SqlCommand(querytotal, sqlcon);
                    dapersen = new SqlDataAdapter(cmdruang);
                    dapersen.Fill(dspersen);
                    cmdruang.ExecuteNonQuery();
                    sqlcon.Close();

                    queryisi = $@"SELECT COUNT(*) as isi FROM maintenancehk_data d join maintenancehk_parameter r on d.id_parameter=
                                r.id_parameter join maintenancehk_perangkat t on r.id_perangkat=t.id_perangkat where 
                                '{startdate.ToString("yyyy/MM/dd")} 00:00:00' <= d.tanggal and d.tanggal < '{enddate.ToString("yyyy/MM/dd")} 23:59:59' and d.data != '' and 
                                t.unit = '{ruang}' and d.data not like '%' + 'un' + '%' and t.jenis='SEMESTER' GROUP BY t.unit";
                    sqlcon.Open();
                    SqlCommand cmdisi = new SqlCommand(queryisi, sqlcon);
                    dabar = new SqlDataAdapter(cmdisi);
                    dabar.Fill(dsbar);
                    cmdisi.ExecuteNonQuery();
                    sqlcon.Close();
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
                    if ((i % 5) == 0)
                    {
                        if (i > 1)
                            htmltable.Append("</div>");
                        htmltable.Append("<div class=\"col-md-12\">");
                    }
                    htmltable.Append("<div class=\"progress-group\">");
                    htmltable.Append($"<a class=\"link\" href=\"data.aspx?unit={ruang}&semester={semester}&tahun={tahun}\" style=\"font-size:12px;\">" + ruang + "</a>");
                    htmltable.Append($"<span class=\"progress-number\">" + tampil + "%</span>");
                    htmltable.Append("<div class=\"progress sm\">");
                    htmltable.Append($"<div class=\"progress-bar {class1}\" style=\"width:{tampil}% \"></div>");
                    htmltable.Append($"</div></div>");
                }
                PlaceHolder1.Controls.Add(new Literal { Text = htmltable.ToString() });
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

        void tableunit()
        {
            DateTime now = DateTime.Now;
            startdate = new DateTime(DateTime.Now.Year, 1, 1);
            enddate = new DateTime(DateTime.Now.Year, 7, 1);
            if (DateTime.Now.Month >= 7)
            {
                startdate = new DateTime(DateTime.Now.Year, 7, 1);
                enddate = new DateTime(DateTime.Now.Year + 1, 1, 1);
            }
            string style, class1, device, alias, querytotal, queryisi;
            SqlDataAdapter daheader, dapersen, dabar;
            DataSet dsheader = new DataSet();
            DataSet dspersen = new DataSet();
            DataSet dsbar = new DataSet();
            string queryheader = $@"select device, alias from maintenancehk_perangkat where jenis= 'SEMESTER' and unit='{ruangan}' 
                                    group by alias, device ";
            sqlcon.Open();
            SqlCommand cmdheader = new SqlCommand(queryheader, sqlcon);
            daheader = new SqlDataAdapter(cmdheader);
            daheader.Fill(dsheader);
            cmdheader.ExecuteNonQuery();
            sqlcon.Close();
            style = "font-weight:bold";
            wib = DateTime.UtcNow + new TimeSpan(7, 0, 0);
            tanggal1 = wib.ToString("yyyy/MM/dd");
            if (dsheader.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsheader.Tables[0].Rows.Count; ++i)
                {
                    dsbar.Clear();
                    device = dsheader.Tables[0].Rows[i]["device"].ToString();
                    alias = dsheader.Tables[0].Rows[i]["alias"].ToString();
                    querytotal = $@"SELECT COUNT(*) as total FROM maintenancehk_parameter r join maintenancehk_perangkat t 
                                    on r.id_perangkat=t.id_perangkat where t.device = '{device}' and t.unit = '{ruangan}' and t.alias ='{alias}' and t.jenis='SEMESTER' GROUP BY t.device, t.alias";
                    sqlcon.Open();
                    SqlCommand cmdruang = new SqlCommand(querytotal, sqlcon);
                    dapersen = new SqlDataAdapter(cmdruang);
                    dapersen.Fill(dspersen);
                    cmdruang.ExecuteNonQuery();
                    sqlcon.Close();

                    queryisi = $@"SELECT COUNT(*) as isi FROM maintenancehk_data d join maintenancehk_parameter r on d.id_parameter=
                                r.id_parameter join maintenancehk_perangkat t on r.id_perangkat=t.id_perangkat where 
                                '{startdate.ToString("yyyy/MM/dd")} 00:00:00' <= d.tanggal and d.tanggal < '{enddate.ToString("yyyy/MM/dd")} 23:59:59' and d.data != '' and 
                                t.device = '{device}' and t.alias ='{alias}' and t.unit = '{ruangan}' and d.data not like '%' + 'un' + '%' and t.jenis='SEMESTER' GROUP BY t.device, t.alias";
                    sqlcon.Open();
                    SqlCommand cmdisi = new SqlCommand(queryisi, sqlcon);
                    dabar = new SqlDataAdapter(cmdisi);
                    dabar.Fill(dsbar);
                    cmdisi.ExecuteNonQuery();
                    sqlcon.Close();
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
                    if ((i % 5) == 0)
                    {
                        if (i > 1)
                            htmltable.Append("</div>");
                        htmltable.Append("<div class=\"col-md-12\">");
                    }
                    htmltable.Append("<div class=\"progress-group\">");
                    if(tampil == 0)
                        htmltable.Append($"<a class=\"link\" href=\"viewdata.aspx?room={ruangan}&device={device}&alias={alias}&semester={semester}&tahun={tahun}&data=kosong\" style=\"font-size:12px;\">" + device + "  (" + alias + ")" + "</a>");
                    else
                        htmltable.Append($"<a class=\"link\" href=\"viewdata.aspx?room={ruangan}&device={device}&alias={alias}&semester={semester}&tahun={tahun}\" style=\"font-size:12px;\">" + device + "  (" + alias + ")" + "</a>");
                    htmltable.Append($"<span class=\"progress-number\">" + tampil + "%</span>");
                    htmltable.Append("<div class=\"progress sm\">");
                    htmltable.Append($"<div class=\"progress-bar {class1}\" style=\"width:{tampil}% \"></div>");
                    htmltable.Append($"</div></div>");
                }
                PlaceHolder2.Controls.Add(new Literal { Text = htmltable.ToString() });
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

    }
}