using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.datalogbook
{
    public partial class searchby : System.Web.UI.Page
    {
        SqlDataAdapter da, da1;
        DataSet ds = new DataSet();
        DataSet dspekerjaan = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", bangunan = "st", style1 = "a", query, divisi = "", style2 = "a", style3, prioritas = "a", statusticket = "a", tanggal, queydel, jenisview = "";
        string ruangan1;
        string bwilayah, bruangan, brak, queryhistory, queryfungsi, querylain, agenda, dataagenda, addwork, stylecolor, stylebg;
        string qr = "a", divisireply = "A";
        int output1, outputtotal, outputbagi;
        double hasil, tampil;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void submit_click(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand("logbooksearchby", sqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            if (ddlunit.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@divisi", ddlunit.Text);
            }
            if (ddlkategori.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@kategori", ddlkategori.Text);
            }
            if (ddlstatus.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@status", ddlstatus.Text);
            }
            if (txtpicint.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@internal", txtpicint.Text);
            }
            if (txtpicext.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@external", txtpicext.Text);
            }

            if (txtmulai.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@mulai", txtmulai.Text);
            }
            if (txtsampai.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@selesai", txtsampai.Text);
            }
            else
            {
                sqlcmd.Parameters.AddWithValue("@selesai", txtmulai.Text);
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.SelectCommand = sqlcmd;
            da.Fill(ds);
            sqlCon.Close();

            style3 = "font-weight:normal; font-size:14px;";
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Logbook</th><th>Action</th>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int jumlahlog;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dspekerjaan.Clear();
                        queryhistory = $"select jenis_pekerjaan from table_pekerjaan where id_logbook = '{ds.Tables[0].Rows[i]["id_logbook"].ToString()}' group by jenis_pekerjaan";
                        SqlCommand cmd1 = new SqlCommand(queryhistory, sqlCon);
                        da1 = new SqlDataAdapter(cmd1);
                        da1.Fill(dspekerjaan);
                        sqlCon.Open();
                        cmd1.ExecuteNonQuery();
                        sqlCon.Close();
                        agenda = ds.Tables[0].Rows[i]["agenda"].ToString();

                        sqlCon.Open();
                        string querycountf = $"select count(*) from table_log_file WHERE id_logbook = '{ds.Tables[0].Rows[i]["id_logbook"].ToString()}'";
                        SqlCommand cmd4 = new SqlCommand(querycountf, sqlCon);
                        output1 = int.Parse(cmd4.ExecuteScalar().ToString());
                        sqlCon.Close();

                        sqlCon.Open();
                        string querycounttotal = $"select count(*) from table_pekerjaan where id_logbook = '{ds.Tables[0].Rows[i]["id_logbook"].ToString()}'";
                        SqlCommand cmd5 = new SqlCommand(querycounttotal, sqlCon);
                        outputtotal = int.Parse(cmd5.ExecuteScalar().ToString());
                        sqlCon.Close();

                        sqlCon.Open();
                        string querycountbagi = $"select count(*) from table_pekerjaan where id_logbook = '{ds.Tables[0].Rows[i]["id_logbook"].ToString()}' and status != 'On Progress'";
                        SqlCommand cmd6 = new SqlCommand(querycountbagi, sqlCon);
                        outputbagi = int.Parse(cmd6.ExecuteScalar().ToString());
                        sqlCon.Close();

                        hasil = ((double)outputbagi / outputtotal) * 100;
                        tampil = Math.Round(hasil);
                        jumlahlog = dspekerjaan.Tables[0].Rows.Count;

                        if (tampil == 100)
                        {
                            stylecolor = "progress-bar-success";
                            stylebg = "bg-green";
                        }
                        else
                        {
                            stylecolor = "progress-bar-danger";
                            stylebg = "bg-red";
                        }
                        if (agenda.Length >= 40)
                        {
                            dataagenda = agenda.Substring(0, 40) + ".....";
                        }
                        else
                        {
                            dataagenda = agenda;
                        }

                        DateTime dateku = (DateTime)ds.Tables[0].Rows[i]["tanggal"];
                        string mydate = dateku.ToString("dd/MM/yyyy");

                        DateTime start = (DateTime)ds.Tables[0].Rows[i]["waktu_action"];
                        string mulai = start.ToString("dd/MM/yyyy");
                        DateTime end = (DateTime)ds.Tables[0].Rows[i]["due_date"];
                        string akhir = end.ToString("dd/MM/yyyy");
                        //Response.Write(queryhistory);
                        htmlTable.Append("<td>" + "<label style=\"font-size:18px\">" + ds.Tables[0].Rows[i]["judul_logbook"].ToString() + "</label>" + "<label style=\"font-size:12px\" class=\"pull-right\">" + mydate + "</label>" + "<br />" +
                            "<label style=\"font-size:16px; color:gray;\">" + ds.Tables[0].Rows[i]["tipe_logbook"].ToString() + "</label>" + "  ");
                        if (output1 >= 1)
                        {
                            htmlTable.Append("<i class=\"fa fa-paperclip\" style=\"color:lightgreen\"></i>" + "<br/>");
                        }
                        else
                        {
                            htmlTable.Append("<br/>");
                        }
                        htmlTable.Append("<table style=\"width:100%\">" +
                            "<tr>" + $"<td style=\"{style1}; width:15%;\">" + "Unit" + "</td>" + $"<td style=\"{style1}; width:5%;\">" + ":" + "</td>" + $"<td style=\"{style1}; width:25%;\">" + ds.Tables[0].Rows[i]["unit"].ToString() + "</td>" +
                            $"<td style=\"{style1}; width:15%;\">" + "Mulai Kegiatan" + "</td>" + $"<td style=\"{style1}; width:5%;\">" + ":" + "</td>" + $"<td style=\"{style1}; width:25%;\">" + mulai + "</td>" + "<td></td>" + "</tr>" +
                            "<tr>" + $"<td style=\"{style1}\">" + "PIC Internal" + "</td>" + $"<td style=\"{style1}\">" + ":" + "</td>" + $"<td style=\"{style1}\">" + ds.Tables[0].Rows[i]["pic_internal"].ToString() + "</td>" +
                            $"<td style=\"{style1}\">" + "Tanggal Akhir Kegiatan" + "</td>" + $"<td style=\"{style1}\">" + ":" + "</td>" + $"<td style=\"{style1}\">" + akhir + "</td>" + "</tr>" +
                            "<tr>" + $"<td style=\"{style1}\">" + "PIC External" + "</td>" + $"<td style=\"{style1}\">" + ":" + "</td>" + $"<td style=\"{style1}\">" + ds.Tables[0].Rows[i]["pic_eksternal"].ToString() + "</td>" +
                            $"<td style=\"{style1}\">" + "Progress" + "</td>" + $"<td style=\"{style1}\">" + ":" + "</td>");
                        if (outputtotal != 0)
                        {
                            htmlTable.Append($"<td colspan\"3\" style=\"{style1}\">" +
                            "<div class=\"progress progress-xs\">" +
                              $"<div class=\"progress-bar {stylecolor}\" style=\"width: {tampil}%\"></div>" +
                            "</div></td>" + "<td style=\"padding-left:15px\">" + $"<span class=\"badge {stylebg}\">{tampil}%</span>" +
                            "</td>");
                        }
                        else
                        {
                            if (ds.Tables[0].Rows[i]["status"].ToString() == "Selesai")
                            {
                                stylebg = "bg-green";
                                stylecolor = "progress-bar-success";
                                tampil = 100;
                            }
                            else
                            {
                                stylebg = "bg-red";
                                stylecolor = "progress-bar-danger";
                                tampil = 0;
                            }
                            htmlTable.Append($"<td colspan\"3\" style=\"{style1}\">" +
                            "<div class=\"progress progress-xs\">" +
                              $"<div class=\"progress-bar {stylecolor}\" style=\"width: {tampil}%\"></div>" +
                            "</div></td>" + "<td style=\"padding-left:15px\">" + $"<span class=\"badge {stylebg}\">{tampil}%</span>" +
                            "</td>");
                        }
                        htmlTable.Append("</tr>" +
                            "<tr>" + $"<td style=\"{style1}\">" + "Agenda" + "</td>" + $"<td style=\"{style1}\">" + ":" + "</td>" + $"<td colspan=\"4\" style=\"{style1}\">" + dataagenda + "</td>" + "</tr>" +
                            "<tr>");
                        if (jumlahlog > 0)
                        {
                            int count = dspekerjaan.Tables[0].Rows.Count;
                            string[] looping = new string[count];
                            //string isi = "";
                            for (int j = 0; j < dspekerjaan.Tables[0].Rows.Count; j++)
                            {
                                looping[j] = dspekerjaan.Tables[0].Rows[j]["jenis_pekerjaan"].ToString();
                            }
                            htmlTable.Append($"<td colspan=\"4\"><label class=\"label label-sm label-danger\" style=\"pointer-events:none; width:70px;\">Terdapat subpekerjaan {string.Join(", ", looping)}</label></td>");
                            addwork = string.Join(",", looping).Substring(0, 1);
                            //looping = null;
                        }
                        else
                        {
                            addwork = "";
                            htmlTable.Append("<td colspan=\"2\" style=\"color:red; font-size14px;\"></td>");
                        }
                        htmlTable.Append("</tr></table>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + $"<a href=\"../datalogbook/detail.aspx?idlog={ds.Tables[0].Rows[i]["id_logbook"].ToString()}&add={addwork}\" style=\"margin-right:10px\">" + "View" + "</a>" + "</td>");

                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}