using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.maintenancehk.bulanan
{
    public partial class dashboard : System.Web.UI.Page
    {
        StringBuilder htmltable = new StringBuilder();
        SqlConnection sqlcon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string tanggal, waktu, tanggal1, ruangan;
        DateTime wib;
        double hasil, tampil, total, diisi;
        protected void Page_Load(object sender, EventArgs e)
        {
            tanggal = Request.QueryString["tanggal"];

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
            string queryheader = $@"SELECT ruangan from checkhk_bulan_perangkat where lokasi = 'CIBINONG' group by ruangan";
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
                    ruang = dsheader.Tables[0].Rows[i]["ruangan"].ToString();
                    querytotal = $@"SELECT count(*) as total from checkhk_bulan_perangkat where lokasi = 'CIBINONG' group by ruangan";
                    sqlcon.Open();
                    SqlCommand cmdruang = new SqlCommand(querytotal, sqlcon);
                    dapersen = new SqlDataAdapter(cmdruang);
                    dapersen.Fill(dspersen);
                    cmdruang.ExecuteNonQuery();
                    sqlcon.Close();

                    queryisi = $@"SELECT count(*) as isi from checkhk_bulan_data d join checkhk_bulan_perangkat t on 
                                t.id_main=d.id_main where '{startdate.ToString("yyyy/MM/dd")} 00:00:00' <= d.tanggal and d.tanggal < '{enddate.ToString("yyyy/MM/dd")} 23:59:59'
                                and lokasi = 'CIBINONG' and ruangan='{ruang}' and data != 'Unclean' and d.data != '' group by ruangan";
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
                    if (tanggal == tanggal1)
                        htmltable.Append($"<a class=\"link\" href=\"isidata.aspx?room={ruang}\" style=\"font-size:12px;\">" + ruang + "</a>");
                    else
                        htmltable.Append($"<a class=\"link\" href=\"isidata.aspx?room={ruang}\" style=\"font-size:12px;\">" + ruang + "</a>");
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
    }
}