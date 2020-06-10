using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.maintenancehk.tigabulan
{
    public partial class dashboard : System.Web.UI.Page
    {
        StringBuilder htmltable = new StringBuilder();
        StringBuilder mytable = new StringBuilder();
        SqlConnection sqlcon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string tanggal, waktu, tanggal1, ruangan, triwulan, start, end, queryaft, lokasibbu, perangkatbbu, snbbu;
        DateTime wib;
        double hasil, tampil, total, diisi, dataaft;
        protected void Page_Load(object sender, EventArgs e)
        {
            tanggal = Request.QueryString["tanggal"];

            tablepersen();
            tablebaseband();
        }

        void tablepersen()
        {
            DateTime now = DateTime.Now;
            DateTime first = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime second = new DateTime(DateTime.Now.Year, 3, 30);
            DateTime third = new DateTime(DateTime.Now.Year, 4, 1);
            DateTime fourth = new DateTime(DateTime.Now.Year, 6, 30);
            DateTime fifth = new DateTime(DateTime.Now.Year, 7, 1);
            DateTime sixth = new DateTime(DateTime.Now.Year, 9, 30);
            DateTime seventh = new DateTime(DateTime.Now.Year, 10, 1);
            DateTime eighth = new DateTime(DateTime.Now.Year, 12, 30);

            if (now > first && now <= second)
            {
                triwulan = "triwulan 1";
                start = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 3, 30).ToString("yyyy/MM/dd");
            }
            else if (now > third && now <= fourth)
            {
                triwulan = "triwulan 2";
                start = new DateTime(DateTime.Now.Year, 4, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 6, 30).ToString("yyyy/MM/dd");
            }
            else if (now > fifth && now <= sixth)
            {
                triwulan = "triwulan 3";
                start = new DateTime(DateTime.Now.Year, 7, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 9, 30).ToString("yyyy/MM/dd");
            }
            else if (now > seventh && now <= eighth)
            {
                triwulan = "triwulan 4";
                start = new DateTime(DateTime.Now.Year, 10, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 12, 30).ToString("yyyy/MM/dd");
            }
            string style, class1, satelit, alias, querytotal, queryisi, lokasi, equipment;
            SqlDataAdapter daheader, dapersen, dabar, daaft;
            DataSet dsheader = new DataSet();
            DataSet dspersen = new DataSet();
            DataSet dsbar = new DataSet();
            DataSet dsaft = new DataSet();
            string queryheader = $@"select lokasi, satelit, equipment from mainhk_3m_perangkat group by lokasi, satelit, equipment";
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
                    equipment = dsheader.Tables[0].Rows[i]["equipment"].ToString();
                    lokasi = dsheader.Tables[0].Rows[i]["lokasi"].ToString();
                    satelit = dsheader.Tables[0].Rows[i]["satelit"].ToString();
                    querytotal = $@"SELECT count(*) as total from mainhk_3m_parameter r join mainhk_3m_perangkat t on
									t.id_perangkat=r.id_perangkat group by satelit, equipment";
                    sqlcon.Open();
                    SqlCommand cmdruang = new SqlCommand(querytotal, sqlcon);
                    dapersen = new SqlDataAdapter(cmdruang);
                    dapersen.Fill(dspersen);
                    cmdruang.ExecuteNonQuery();
                    sqlcon.Close();

                    queryisi = $@"SELECT count(*) as isi from mainhk_3m_data d join mainhk_3m_parameter r on
                                    r.id_parameter=d.id_parameter join mainhk_3m_perangkat t on
									t.id_perangkat=r.id_perangkat where '{start} 00:00:00' <= d.tanggal and 
                                    d.tanggal < '{end} 23:59:59' and d.data_bef != '' and equipment='{equipment}' and lokasi='{lokasi}' and satelit='{satelit}' group by equipment";
                    sqlcon.Open();
                    SqlCommand cmdisi = new SqlCommand(queryisi, sqlcon);
                    dabar = new SqlDataAdapter(cmdisi);
                    dabar.Fill(dsbar);
                    cmdisi.ExecuteNonQuery();
                    sqlcon.Close();

                    queryaft = $@"SELECT count(*) as isi from mainhk_3m_data d join mainhk_3m_parameter r on
                                    r.id_parameter=d.id_parameter join mainhk_3m_perangkat t on
									t.id_perangkat=r.id_perangkat where '{start} 00:00:00' <= d.tanggal and 
                                    d.tanggal < '{end} 23:59:59' and d.data_bef != '' and equipment='{equipment}' and lokasi='{lokasi}' and satelit='{satelit}' group by equipment";
                    sqlcon.Open();
                    SqlCommand cmdaft = new SqlCommand(queryaft, sqlcon);
                    daaft = new SqlDataAdapter(cmdisi);
                    daaft.Fill(dsaft);
                    cmdaft.ExecuteNonQuery();
                    sqlcon.Close();

                    if (dsaft.Tables[0].Rows.Count > 0)
                    {
                        dataaft = Convert.ToDouble(dsaft.Tables[0].Rows[0]["isi"].ToString());
                    }
                    else
                    {
                        dataaft = 0;
                    }

                    if (dsbar.Tables[0].Rows.Count > 0)
                    {
                        diisi = Convert.ToDouble(dsbar.Tables[0].Rows[0]["isi"].ToString()) + dataaft;
                    }
                    else
                    {
                        diisi = 0;
                    }

                    total = Convert.ToDouble(dspersen.Tables[0].Rows[i]["total"].ToString()) * 2;

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
                        htmltable.Append($"<a class=\"link\" href=\"isidata.aspx?satelit={satelit}&lokasi={lokasi}&equipment={equipment}\" style=\"font-size:12px;\">" + lokasi + " -> " + satelit + " -> " + equipment + "</a>");
                    else
                        htmltable.Append($"<a class=\"link\" href=\"isidata.aspx?satelit={satelit}&lokasi={lokasi}&equipment={equipment}\" style=\"font-size:12px;\">" + lokasi + " -> " + satelit + " -> " + equipment + "</a>");
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

        void tablebaseband()
        {
            DateTime now = DateTime.Now;
            DateTime first = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime second = new DateTime(DateTime.Now.Year, 3, 30);
            DateTime third = new DateTime(DateTime.Now.Year, 4, 1);
            DateTime fourth = new DateTime(DateTime.Now.Year, 6, 30);
            DateTime fifth = new DateTime(DateTime.Now.Year, 7, 1);
            DateTime sixth = new DateTime(DateTime.Now.Year, 9, 30);
            DateTime seventh = new DateTime(DateTime.Now.Year, 10, 1);
            DateTime eighth = new DateTime(DateTime.Now.Year, 12, 30);

            if (now > first && now <= second)
            {
                triwulan = "triwulan 1";
                start = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 3, 30).ToString("yyyy/MM/dd");
            }
            else if (now > third && now <= fourth)
            {
                triwulan = "triwulan 2";
                start = new DateTime(DateTime.Now.Year, 4, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 6, 30).ToString("yyyy/MM/dd");
            }
            else if (now > fifth && now <= sixth)
            {
                triwulan = "triwulan 3";
                start = new DateTime(DateTime.Now.Year, 7, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 9, 30).ToString("yyyy/MM/dd");
            }
            else if (now > seventh && now <= eighth)
            {
                triwulan = "triwulan 4";
                start = new DateTime(DateTime.Now.Year, 10, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 12, 30).ToString("yyyy/MM/dd");
            }
            string style, class1, satelit, alias, querytotal, queryisi, lokasi, equipment;
            SqlDataAdapter daheader, dapersen, dabar, daaft;
            DataSet dsheader = new DataSet();
            DataSet dspersen = new DataSet();
            DataSet dsbar = new DataSet();
            DataSet dsaft = new DataSet();
            string queryheader = $@"select lokasi, perangkat, sn from mainhk_bbu_parameter group by lokasi, perangkat, sn";
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
                    snbbu = dsheader.Tables[0].Rows[i]["sn"].ToString();
                    lokasibbu = dsheader.Tables[0].Rows[i]["lokasi"].ToString();
                    perangkatbbu = dsheader.Tables[0].Rows[i]["perangkat"].ToString();
                    querytotal = $@"SELECT count(*) as total from mainhk_3m_parameter r join mainhk_3m_perangkat t on
									t.id_perangkat=r.id_perangkat group by satelit, equipment";
                    sqlcon.Open();
                    SqlCommand cmdruang = new SqlCommand(querytotal, sqlcon);
                    dapersen = new SqlDataAdapter(cmdruang);
                    dapersen.Fill(dspersen);
                    cmdruang.ExecuteNonQuery();
                    sqlcon.Close();

                    queryisi = $@"SELECT count(*) as isi from mainhk_3m_data d join mainhk_3m_parameter r on
                                    r.id_parameter=d.id_parameter join mainhk_3m_perangkat t on
									t.id_perangkat=r.id_perangkat where '{start} 00:00:00' <= d.tanggal and 
                                    d.tanggal < '{end} 23:59:59' and d.data_bef != '' and equipment='{lokasibbu}' group by equipment";
                    sqlcon.Open();
                    SqlCommand cmdisi = new SqlCommand(queryisi, sqlcon);
                    dabar = new SqlDataAdapter(cmdisi);
                    dabar.Fill(dsbar);
                    cmdisi.ExecuteNonQuery();
                    sqlcon.Close();

                    queryaft = $@"SELECT count(*) as isi from mainhk_3m_data d join mainhk_3m_parameter r on
                                    r.id_parameter=d.id_parameter join mainhk_3m_perangkat t on
									t.id_perangkat=r.id_perangkat where '{start} 00:00:00' <= d.tanggal and 
                                    d.tanggal < '{end} 23:59:59' and d.data_bef != '' and equipment='{lokasibbu}' group by equipment";
                    sqlcon.Open();
                    SqlCommand cmdaft = new SqlCommand(queryaft, sqlcon);
                    daaft = new SqlDataAdapter(cmdisi);
                    daaft.Fill(dsaft);
                    cmdaft.ExecuteNonQuery();
                    sqlcon.Close();

                    if (dsaft.Tables[0].Rows.Count > 0)
                    {
                        dataaft = Convert.ToDouble(dsaft.Tables[0].Rows[0]["isi"].ToString());
                    }
                    else
                    {
                        dataaft = 0;
                    }

                    if (dsbar.Tables[0].Rows.Count > 0)
                    {
                        diisi = Convert.ToDouble(dsbar.Tables[0].Rows[0]["isi"].ToString()) + dataaft;
                    }
                    else
                    {
                        diisi = 0;
                    }

                    total = Convert.ToDouble(dspersen.Tables[0].Rows[i]["total"].ToString()) * 2;

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
                            mytable.Append("</div>");
                        mytable.Append("<div class=\"col-md-12\">");
                    }
                    mytable.Append("<div class=\"progress-group\">");
                    mytable.Append($"<a class=\"link\" href=\"dashboardbbu.aspx?sn={snbbu}\" style=\"font-size:12px;\">" + lokasibbu + " -> " + perangkatbbu + " -> SN : " + snbbu + "</a>");
                    mytable.Append($"<span class=\"progress-number\">" + tampil + "%</span>");
                    mytable.Append("<div class=\"progress sm\">");
                    mytable.Append($"<div class=\"progress-bar {class1}\" style=\"width:{tampil}% \"></div>");
                    mytable.Append($"</div></div>");
                }
                PlaceHolder2.Controls.Add(new Literal { Text = mytable.ToString() });
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