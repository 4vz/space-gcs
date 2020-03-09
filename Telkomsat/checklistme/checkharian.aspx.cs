using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;

namespace Telkomsat.checklistme
{
    public partial class checkharian : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string IDdata = "kitaa", total = "", petugas, tanggal = "", query, query1;
        string start = "01/01/2019", end = "01/12/2048";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        int rek1harkat, rek2harkat, rek1me, rek2me, harkat, me;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                query = @"select d.tanggal, p.nama from checkme_data d inner join Profile p on d.id_profile = p.id_profile
                        group by tanggal, nama order by d.tanggal desc";
                query1 = @"select r.tanggal, p1.nama as pagi, p2.nama as siang, p3.nama as malam from checkme_rekap r left join Profile p1 on p1.id_profile=r.pagi left join
                            Profile p2 on p2.id_profile = r.siang left join Profile p3 on p3.id_profile = r.malam order by r.tanggal desc";
                tabledata();
            }
        }

        void tableticket()
        {
            /*SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>Petugas</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DateTime date1 = (DateTime)ds.Tables[0].Rows[i]["tanggal"];
                        tanggal = date1.ToString("yyyy/MM/dd");
                        petugas = ds.Tables[0].Rows[i]["nama"].ToString();

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + petugas + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a  style=\"cursor:pointer\" href=\"/checklistme/dataharian.aspx?tanggal={tanggal}\">" + $"<label>" + "view" + "</label>" + "</a>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    //DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                }
            }*/
        }

        void tabledata()
        {
            SqlDataAdapter dapagi, dasiang, damalam;
            DataSet dspagi = new DataSet();
            DataSet dssiang = new DataSet();
            DataSet dsmalam = new DataSet();
            string querypagi, querysiang, querymalam;

            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            double hasil1, tampil1, hasil2, tampil2, hasil3, tampil3;
            htmlTable1.Append("<table id=\"example3\" width=\"100%\" class=\"table table-bordered\">");
            htmlTable1.Append("<thead style=\"background-color:#40cfd8\">");
            htmlTable1.Append("<tr><th style=\"vertical-align : middle;text-align:center\" rowspan=\"2\">Tanggal</th><th colspan=\"3\" style=\"text-align:center\">Petugas</th><th style=\"vertical-align : middle;text-align:center\" rowspan=\"2\">Action</th>");
            htmlTable1.Append("<tr><th style=\"background-color:#40cfd8;text-align:center\">Pagi</th><th style=\"background-color:#40cfd8;text-align:center\">Siang</th><th style=\"background-color:#40cfd8;text-align:center\">Malam</th></tr>");
            htmlTable1.Append("</thead>");

            htmlTable1.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DateTime date1 = (DateTime)ds.Tables[0].Rows[i]["tanggal"];
                        tanggal = date1.ToString("yyyy/MM/dd");

                        querypagi = $@"select count(*) as pagi from (select tanggal, ruangan, nama, waktu from checkme_data d left join checkme_parameter r on r.id_parameter=d.id_parameter left join checkme_perangkat p 
                                    on p.id_perangkat=r.id_perangkat left join Profile l on l.id_profile=d.id_profile where d.tanggal = '{tanggal}' and d.waktu = 'pagi' 
									group by d.tanggal, ruangan, nama, waktu) q1";
                        querysiang = $@"select count(*) as siang from (select tanggal, ruangan, nama, waktu from checkme_data d left join checkme_parameter r on r.id_parameter=d.id_parameter left join checkme_perangkat p 
                                    on p.id_perangkat=r.id_perangkat left join Profile l on l.id_profile=d.id_profile where d.tanggal = '{tanggal}' and d.waktu = 'siang' 
									group by d.tanggal, ruangan, nama, waktu) q1";
                        querymalam = $@"select count(*) as malam from (select tanggal, ruangan, nama, waktu from checkme_data d left join checkme_parameter r on r.id_parameter=d.id_parameter left join checkme_perangkat p 
                                    on p.id_perangkat=r.id_perangkat left join Profile l on l.id_profile=d.id_profile where d.tanggal = '{tanggal}' and d.waktu = 'malam' 
									group by d.tanggal, ruangan, nama, waktu) q1";

                        SqlCommand cmdpagi = new SqlCommand(querypagi, sqlCon);
                        dapagi = new SqlDataAdapter(cmdpagi);
                        dapagi.Fill(dspagi);
                        sqlCon.Open();
                        cmdpagi.ExecuteNonQuery();
                        sqlCon.Close();

                        SqlCommand cmdsiang = new SqlCommand(querysiang, sqlCon);
                        dasiang = new SqlDataAdapter(cmdsiang);
                        dasiang.Fill(dssiang);
                        sqlCon.Open();
                        cmdsiang.ExecuteNonQuery();
                        sqlCon.Close();

                        SqlCommand cmdmalam = new SqlCommand(querymalam, sqlCon);
                        damalam = new SqlDataAdapter(cmdmalam);
                        damalam.Fill(dsmalam);
                        sqlCon.Open();
                        cmdmalam.ExecuteNonQuery();
                        sqlCon.Close();

                        hasil1 = ((double)Convert.ToInt32(dspagi.Tables[0].Rows[i]["pagi"].ToString()) / 23) * 100;
                        tampil1 = Math.Round(hasil1);

                        hasil2 = ((double)Convert.ToInt32(dssiang.Tables[0].Rows[i]["siang"].ToString()) / 23) * 100;
                        tampil2 = Math.Round(hasil2);

                        hasil3 = ((double)Convert.ToInt32(dsmalam.Tables[0].Rows[i]["malam"].ToString()) / 23) * 100;
                        tampil3 = Math.Round(hasil3);

                        htmlTable1.Append("<tr>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px; color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\">" + ds.Tables[0].Rows[i]["pagi"].ToString() + "</label>" + "<span style=\"float:right; padding-right:5px\">" +
                            tampil1 + "%" + "</span>" + "</td>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\">" + ds.Tables[0].Rows[i]["siang"].ToString() + "</label>" + "<span style=\"float:right; padding-right:5px\">" +
                            tampil2 + "%" + "</span>"  + "</td>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\">" + ds.Tables[0].Rows[i]["malam"].ToString() + "</label>" + "<span style=\"float:right; padding-right:5px\">" +
                            tampil3 + "%" + "</span>" + "</td>");
                        htmlTable1.Append("<td>" + $"<a  style=\"cursor:pointer\" href=\"/checklistme/dataharian.aspx?tanggal={tanggal}\">" + $"<label>" + "view" + "</label>" + "</a>" + "</td>");
                        htmlTable1.Append("</tr>");
                    }
                    htmlTable1.Append("</tbody>");
                    htmlTable1.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable1.ToString() });

                }
            }
        }


        protected void Filter_ServerClick(object sender, EventArgs e)
        {
            if (txtsdate.Value != "")
                start = txtsdate.Value;
            if (dateend.Value != "")
                end = dateend.Value;
            query = $@"select d.tanggal, p.nama from checkme_data d left join Profile p on d.id_profile = p.id_profile
                            where (tanggal BETWEEN (convert(datetime, '{start}',103)) AND (convert(datetime, '{end}',103))) and p.nama like '%' + '{ddlKategori.SelectedValue}' 
                            group by tanggal, nama order by d.tanggal desc";

            query1 = $@"select r.tanggal, p1.nama as pagi, p2.nama as siang, p3.nama as malam from checkme_rekap r left join Profile p1 on p1.id_profile=r.pagi left join
                            Profile p2 on p2.id_profile = r.siang left join Profile p3 on p3.id_profile = r.malam
                            where (r.tanggal BETWEEN (convert(datetime, '{start}',103)) AND (convert(datetime, '{end}',103))) 
							and (p1.nama like '%' + '{ddlKategori.SelectedValue}' + '%' or p2.nama like '%' + '{ddlKategori.SelectedValue}' + '%' or p3.nama like '%' + '{ddlKategori.SelectedValue}' + '%')
                            order by r.tanggal desc";
            tabledata();
        }

    }
}