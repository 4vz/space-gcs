using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.checklistme
{
    public partial class dashboard : System.Web.UI.Page
    {
        StringBuilder htmltable = new StringBuilder();
        SqlConnection sqlcon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string tanggal, waktu, tanggal1, tanggal2;
        double hasil, tampil, total, diisi;
        DateTime wib;
        TimeSpan wibTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            tanggal = Request.QueryString["tanggal"];
            waktu = Request.QueryString["waktu"];
            tablepersen();
            approval();
        }

        void approval()
        {
            string petugas, thistime, query;
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            query = $@"select d.tanggal, p.nama, d.pic from checkme_data d inner join Profile p on d.id_profile = p.id_profile
					where d.tanggal='{tanggal}' and waktu = '{waktu}' group by tanggal, nama, pic order by d.tanggal desc";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlcon.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbltanggal.Text = ds.Tables[0].Rows[0]["tanggal"].ToString();
                lblpetugas.Text = ds.Tables[0].Rows[0]["nama"].ToString();
                if (ds.Tables[0].Rows[0]["pic"].ToString() == null || ds.Tables[0].Rows[0]["pic"].ToString() == "")
                    lblapproval.Text = "Belum di approve";
                else
                    lblapproval.Text = ds.Tables[0].Rows[0]["pic"].ToString();
            }
        }


        void tablepersen()
        {
            TimeSpan satu = new TimeSpan(5, 0, 0); //10 o'clock
            TimeSpan dua = new TimeSpan(13, 0, 0); //12 o'clock
            TimeSpan tiga = new TimeSpan(19, 0, 0); //12 o'clock
            TimeSpan empat = new TimeSpan(24, 0, 0);
            
            if (!IsPostBack)
            {
                wib = DateTime.UtcNow + new TimeSpan(7, 0, 0);
                wibTime = wib.TimeOfDay;
                tanggal1 = wib.ToString("yyyy/MM/dd");
            }

            string style, class1, ruang, querytotal, queryisi;
            SqlDataAdapter daheader, dapersen, dabar;
            DataSet dsheader = new DataSet();
            DataSet dspersen = new DataSet();
            DataSet dsbar = new DataSet();
            string queryheader = "select ruangan from checkme_perangkat p group by ruangan order by ruangan";
            sqlcon.Open();
            SqlCommand cmdheader = new SqlCommand(queryheader, sqlcon);
            daheader = new SqlDataAdapter(cmdheader);
            daheader.Fill(dsheader);
            cmdheader.ExecuteNonQuery();
            sqlcon.Close();
            style = "font-weight:bold";
            
            if (dsheader.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsheader.Tables[0].Rows.Count; ++i)
                {
                    dsbar.Clear();
                    ruang = dsheader.Tables[0].Rows[i]["ruangan"].ToString();
                    querytotal = $@"select count(*) as total from checkme_parameter r join checkme_perangkat p on p.id_perangkat=r.id_perangkat 
                                where ruangan = '{ruang}' group by p.ruangan order by ruangan";
                    sqlcon.Open();
                    SqlCommand cmdruang = new SqlCommand(querytotal, sqlcon);
                    dapersen = new SqlDataAdapter(cmdruang);
                    dapersen.Fill(dspersen);
                    cmdruang.ExecuteNonQuery();
                    sqlcon.Close();

                    queryisi = $@"select count(*) as isi from checkme_data d join checkme_parameter r on d.id_parameter=r.id_parameter
                                join checkme_perangkat p on p.id_perangkat=r.id_perangkat where d.tanggal='{tanggal}' and d.nilai != '' and d.waktu='{waktu}'
                                and ruangan = '{ruang}' group by p.ruangan order by ruangan";
                    sqlcon.Open();
                    SqlCommand cmdisi = new SqlCommand(queryisi, sqlcon);
                    dabar = new SqlDataAdapter(cmdisi);
                    dabar.Fill(dsbar);
                    cmdisi.ExecuteNonQuery();
                    sqlcon.Close();
                    if(dsbar.Tables[0].Rows.Count > 0)
                    {
                        diisi = Convert.ToDouble(dsbar.Tables[0].Rows[0]["isi"].ToString());
                    }
                    else
                    {
                        diisi = 0;
                    }
                        
                    total = Convert.ToDouble(dspersen.Tables[0].Rows[i]["total"].ToString());

                    hasil = ((double)diisi / total) * 100;

                    if (hasil== 100)
                    {
                        class1 = "progress-bar-green";
                    }
                    else
                    {
                        class1 = "progress-bar-red";
                    }
                    tampil = Math.Round(hasil);
                    if ((i % 8) == 0)
                    {
                        if(i>1)
                            htmltable.Append("</div>");
                        htmltable.Append("<div class=\"col-md-4\">");
                    }
                    
                    
                    htmltable.Append("<div class=\"progress-group\">");
                    if (tanggal == tanggal1)
                    {
                        if(waktu == "pagi")
                        {
                            if((wibTime >= satu) && (wibTime < dua))
                                htmltable.Append($"<a class=\"link\" href=\"../checklistme/harian.aspx?room={ruang}\" style=\"font-size:12px;\">" + ruang + "</a>");
                            else
                                htmltable.Append($"<a class=\"link\" href=\"../checklistme/view2.aspx?waktu={waktu}&tanggal={tanggal}&ruangan={ruang}\" style=\"font-size:12px;\">" + ruang + "</a>");
                        }
                        else if(waktu == "siang")
                        { 
                            if ((wibTime >= dua) && (wibTime < tiga))
                                htmltable.Append($"<a class=\"link\" href=\"../checklistme/harian.aspx?room={ruang}\" style=\"font-size:12px;\">" + ruang + "</a>");
                            else
                                htmltable.Append($"<a class=\"link\" href=\"../checklistme/view2.aspx?waktu={waktu}&tanggal={tanggal}&ruangan={ruang}\" style=\"font-size:12px;\">" + ruang + "</a>");
                        }
                        else if (waktu == "malam")
                        {
                            if ((wibTime >= tiga) && (wibTime < satu))
                                htmltable.Append($"<a class=\"link\" href=\"../checklistme/harian.aspx?room={ruang}\" style=\"font-size:12px;\">" + ruang + "</a>");
                            else
                                htmltable.Append($"<a class=\"link\" href=\"../checklistme/view2.aspx?waktu={waktu}&tanggal={tanggal}&ruangan={ruang}\" style=\"font-size:12px;\">" + ruang + "</a>");
                        }
                    }
                    else
                    {
                        htmltable.Append($"<a class=\"link\" href=\"../checklistme/view2.aspx?waktu={waktu}&tanggal={tanggal}&ruangan={ruang}\" style=\"font-size:12px;\">" + ruang + "</a>");
                    }
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