using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.checkbjm
{
    public partial class dashboardbjm : System.Web.UI.Page
    {
        StringBuilder htmltable = new StringBuilder();
        SqlConnection sqlcon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string tanggal, waktu, tanggal1;
        DateTime wib;
        double hasil, tampil, total, diisi;
        protected void Page_Load(object sender, EventArgs e)
        {
            tanggal = Request.QueryString["tanggal"];
            tablepersen();

        }

        void tablepersen()
        {
            string style, class1, ruang, querytotal, queryisi;
            SqlDataAdapter daheader, dapersen, dabar;
            DataSet dsheader = new DataSet();
            DataSet dspersen = new DataSet();
            DataSet dsbar = new DataSet();
            string queryheader = "select shelter from checkhk_perangkat p where id_perangkat like '%' + 'bjm' + '%' group by shelter order by shelter";
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
                    ruang = dsheader.Tables[0].Rows[i]["shelter"].ToString();
                    querytotal = $@"select count(*) as total from checkhk_parameter r join checkhk_perangkat p on p.id_perangkat=r.id_perangkat 
                                where shelter = '{ruang}' group by p.shelter order by shelter";
                    sqlcon.Open();
                    SqlCommand cmdruang = new SqlCommand(querytotal, sqlcon);
                    dapersen = new SqlDataAdapter(cmdruang);
                    dapersen.Fill(dspersen);
                    cmdruang.ExecuteNonQuery();
                    sqlcon.Close();

                    queryisi = $@"select count(*) as isi from checkhk_data d join checkhk_parameter r on d.id_parameter=r.id_parameter
                                join checkhk_perangkat p on p.id_perangkat=r.id_perangkat where 
								'{tanggal} 00:00:00' <= d.tanggal and d.tanggal < '{tanggal} 23:59:59' and d.data != ''
                                and shelter = '{ruang}' group by p.shelter order by shelter";
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
                            htmltable.AppendLine("</div>");
                        htmltable.AppendLine("<div class=\"col-md-12\">");
                    }
                    htmltable.AppendLine("<div class=\"progress-group\">");
                    if (tanggal == tanggal1)
                        htmltable.AppendLine($"<a class=\"link\" href=\"../checkbjm/harian.aspx?room={ruang}&tanggal={tanggal}\" style=\"font-size:14px;\">" + ruang + "</a>");
                    else
                        htmltable.AppendLine($"<a class=\"link\" href=\"../checkhk/view.aspx?ruangan={ruang}&tanggal={tanggal}\" style=\"font-size:14px;\">" + ruang + "</a>");
                    htmltable.AppendLine($"<span class=\"progress-number\">" + tampil + "%</span>");
                    htmltable.AppendLine("<div class=\"progress sm\">");
                    htmltable.AppendLine($"<div class=\"progress-bar {class1}\" style=\"width:{tampil}% \"></div>");
                    htmltable.AppendLine($"</div></div>");
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