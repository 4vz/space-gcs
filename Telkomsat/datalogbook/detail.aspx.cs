using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
using System.Configuration;
using System.IO;

namespace Telkomsat.datalogbook
{
    public partial class detail : System.Web.UI.Page
    {
        SqlDataAdapter da, damutasi, da1, dakonfigurasi, dafungsi, dalain, dafkon, daflain;
        DataSet ds = new DataSet();
        DataSet dspekerjaan = new DataSet();
        DataSet dsmutasi = new DataSet();
        DataSet dskonfigurasi = new DataSet();
        DataSet dsfungsi = new DataSet();
        DataSet dslain = new DataSet();
        DataSet dsfkon = new DataSet();
        DataSet dsflain = new DataSet();
        string query, iduser, tanggal, style1, style3, style2, agenda, dataagenda, idlog, style, querymutasi, queryhistory, querylain, querykonfig, queryfungsi, addwork, queryfilekon, queryfilelain;
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        StringBuilder htmlTableMutasi = new StringBuilder();
        StringBuilder htmlTableKonfigurasi = new StringBuilder();
        StringBuilder htmlTableFungsi = new StringBuilder();
        StringBuilder htmlTableLain = new StringBuilder();
        int output1, outputtotal, outputbagi;
        double hasil, tampil;
        string stylecolor, stylebg;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idlog"] != null)
            {
                idlog = Request.QueryString["idlog"].ToString();
            }

            if(Request.QueryString["add"] == null)
            {
                addwork = "M";
            }
            else if (Request.QueryString["add"] == "")
            {
                addwork = "";
            }
            else
            {
                addwork = Request.QueryString["add"].ToString();
            }

            if(Session["iduser"] != null)
            {
                iduser = Session["iduser"].ToString();
            }

            txtaddwork.Text = addwork;

            if (addwork == "M")
                limutasi.Attributes.Add("class", "active");
            else if (addwork == "F")
                listatus.Attributes.Add("class", "active");
            else if (addwork == "K")
                likonfig.Attributes.Add("class", "active");
            else if (addwork == "L")
                lilain.Attributes.Add("class", "active");


            tableticket();
            tablemutasi();
            tablefungsi();
            tablekonfigurasi();
            tablelain();
            mytable();

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            string querycountf = $"select count(*) from table_log_file WHERE id_logbook = '{idlog}' and kategori = 'utama'";
            SqlCommand cmd4 = new SqlCommand(querycountf, sqlCon);
            int output1 = int.Parse(cmd4.ExecuteScalar().ToString());
            sqlCon.Close();

            if (output1 >= 1)
            {
                string queryfile = $"select * from table_log_file WHERE id_logbook = '{idlog}' and kategori='utama' and (ekstension not in ('.jpeg', '.png', '.bmp', '.jfif', '.gif', '.jpg'))";
                DataList3a.Visible = true;
                sqlCon.Open();
                SqlDataAdapter sqlda1 = new SqlDataAdapter(queryfile, sqlCon);
                DataTable dtbl1 = new DataTable();
                sqlda1.Fill(dtbl1);
                sqlCon.Close();
                DataList3a.DataSource = dtbl1;
                DataList3a.DataBind();
            }
            else
            {
                hlampiran.Visible = false;
            }

        }

        void mytable()
        {
            SqlDataAdapter da, da1;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            string myquery, query, color, namaall, ext, namafile;

            myquery = $@"select * from table_log_file WHERE  id_logbook = '{idlog}' and kategori='utama' and (ekstension in ('.jpeg', '.png', '.bmp', '.jfif', '.gif', '.jpg'))";

            SqlCommand cmd = new SqlCommand(myquery, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable1.Append("<ul>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        namaall = ds.Tables[0].Rows[i]["files"].ToString();
                        namafile = namaall.Replace("~", "..");
                        ext = Path.GetExtension(namaall);
                        htmlTable1.Append($"<li class=\"gambar\"><img style=\"display:block\" class=\"myImg\" src=\"{namafile}\" height=\"200\" /></li>");
                    }
                    htmlTable.Append("</ul>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable1.ToString() });
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename="
                + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/fileupload/")
                + e.CommandArgument);
            Response.End();
        }

        void tableticket()
        {
            query = $@"select * from tabel_logbook where id_logbook = '{idlog}'";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            style1 = "font-size:14px; padding-bottom:10px";
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table\">");
           
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

                        jumlahlog = dspekerjaan.Tables[0].Rows.Count;
                        dataagenda = agenda;
                        DateTime start = (DateTime)ds.Tables[0].Rows[i]["waktu_action"];
                        string mulai = start.ToString("dd/MM/yyyy");
                        DateTime end = (DateTime)ds.Tables[0].Rows[i]["due_date"];
                        string akhir = end.ToString("dd/MM/yyyy");

                        txtstart.Text = start.ToString("yyyy/MM/dd");
                        txtend.Text = end.ToString("yyyy/MM/dd");
                        //Response.Write(queryhistory);
                        htmlTable.Append("<td>" + "<label style=\"font-size:18px\">" + ds.Tables[0].Rows[i]["judul_logbook"].ToString() + "</label>");
                        if (ds.Tables[0].Rows[i]["id_user"].ToString() == iduser || Session["previllage"].ToString() == "super")
                        {
                            htmlTable.Append($"<a class=\"btn btn-sm btn-danger pull-right\" onclick=\"confirmdelete('../datalogbook/action.aspx?hapus={ds.Tables[0].Rows[i]["id_logbook"].ToString()}')\" style=\"margin-right:10px\">" + "Hapus" + "</a>");
                            htmlTable.Append($"<a class=\"btn btn-sm btn-info pull-right\" href=\"../datalogbook/edit.aspx?idlog={ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" style=\"margin-right:10px\">" + "Edit" + "</a>");
                        }
                        htmlTable.Append("<br />" + "<label style=\"font-size:16px; color:gray;\">" + ds.Tables[0].Rows[i]["tipe_logbook"].ToString() + "</label>" + "<br/>" +
                            "<table style=\"width:100%\">" +
                            "<tr>" + $"<td style=\"{style1}; width:20%;\">" + "Unit" + "</td>" + $"<td style=\"{style1}; width:5%;\">" + ":" + "</td>" + $"<td style=\"{style1}; width:25%;\">" + ds.Tables[0].Rows[i]["unit"].ToString() + "</td>" +
                            $"<td style=\"{style1}; width:20%;\">" + "Mulai Kegiatan" + "</td>" + $"<td style=\"{style1}; width:5%;\">" + ":" + "</td>" + $"<td style=\"{style1}; width:25%;\">" + mulai + "</td>" + "</tr>" +
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
                            htmlTable.Append($"<td colspan\"3\">" + ds.Tables[0].Rows[i]["status"].ToString() + "</td>");
                        }
                        htmlTable.Append("</tr>" + "<tr rowspan=\"2\"></tr>" +
                            "<tr>" + $"<td style=\"{style1}\">" + "Agenda" + "</td>" + $"<td style=\"{style1}\">" + ":" + "</td>" + $"<td colspan=\"4\" style=\"{style1}; white-space: pre-line;\">" + dataagenda + "</td>" + "</tr>" +
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
                            htmlTable.Append("<td colspan=\"4\" style=\"color:red; font-size14px;\"></td>");
                        }
                        htmlTable.Append("<td></td>" + "<td>" +
                            "<ul><li class=\"dropdown\"> <button type=\"button\" class=\"btn btn-block btn-primary dropdown-toggle\" data-toggle=\"dropdown\"><i class=\"fa fa-plus\"></i>  Tambah Pekerjaan <span class=\"caret\"></span></button>" +
                            "<ul class=\"dropdown-menu\"><li role=\"presentation\" ><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" data-toggle=\"modal\" data-id=\"5\" data-target=\"#modalkonfigurasi\" id=\"btnkonfigurasi\"> Konfigurasi </ a ></ li >" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modalupdate\" id=\"btnmutasi\">Mutasi Asset</a></li>" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modalfungsi\" id=\"btnstatus\">Status Asset</a></li>" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modallainlain\" id=\"btnlain\">Lain-lain</a></li>" +
                            "</ul></li></ul></td>" +
                            "</tr></table>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }

        void tablemutasi()
        {
            querymutasi = $@"select n.id_pekerjaan, h.tanggal, d.nama_jenis_device, p.sn, r.nama_ruangan as ruangan_after, w.nama_wilayah as wilayah_after,
					    k.nama_rak as rak_after, r1.nama_ruangan as ruangan_before, p.id_perangkat,
						k1.nama_rak as rak_before, w1.nama_wilayah as wilayah_before,
						h.rak_before from as_history_lokasi h full join as_perangkat p on
                        p.id_perangkat=h.id_perangkat full join as_ruangan r on r.id_ruangan=h.id_ruangan full join 
                        as_bangunan b on b.id_bangunan=r.id_bangunan  join as_wilayah w on w.id_wilayah=b.id_wilayah
                        full join as_rak k on k.id_rak=h.id_rak full join as_ruangan r1 on r1.id_ruangan=h.id_ruanganbef full join 
                        as_bangunan b1 on b1.id_bangunan=r1.id_bangunan full join as_wilayah w1 on w1.id_wilayah=b1.id_wilayah
                        full join as_rak k1 on k1.id_rak=h.id_rakbef full join as_jenis_device d on d.id_jenis_device = p.id_jenis_device
                        left join table_pekerjaan n on n.id_perangkat=p.id_perangkat
						 where h.id_reference = '{idlog}' and n.jenis_pekerjaan = 'Mutasi'";

            SqlCommand cmd = new SqlCommand(querymutasi, sqlCon);
            damutasi = new SqlDataAdapter(cmd);
            damutasi.Fill(dsmutasi);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            style = "font-size:12px; font-weight:normal";
            htmlTableMutasi.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTableMutasi.Append("<thead>");
            htmlTableMutasi.Append("<tr><th>Tanggal</th><th>Device</th><th>S/N</th><th>Wilayah After</th><th>Ruangan After</th>" +
                "<th>Rak After</th><th>Wilayah Before</th><th>Ruangan Before</th><th>Rak After</th></tr>");
            htmlTableMutasi.Append("</thead>");

            htmlTableMutasi.Append("<tbody>");
            if (!object.Equals(dsmutasi.Tables[0], null))
            {
                if (dsmutasi.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dsmutasi.Tables[0].Rows.Count; i++)
                    {
                        htmlTableMutasi.Append("<tr>");
                        htmlTableMutasi.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + dsmutasi.Tables[0].Rows[i]["tanggal"] + "</label>" + "</td>");
                        htmlTableMutasi.Append("<td>" + $"<label style=\"{style}\">" + dsmutasi.Tables[0].Rows[i]["nama_jenis_device"].ToString() + "</label>" + "</td>");
                        htmlTableMutasi.Append("<td>" + $"<a style=\"cursor:pointer\" href=\"../dataasset/detail.aspx?id={dsmutasi.Tables[0].Rows[i]["id_perangkat"].ToString()}\">" + $"<label class=\"label label-sm label-primary\">" + dsmutasi.Tables[0].Rows[i]["sn"].ToString() + "</label>" + "</a>" + "</td>");
                        htmlTableMutasi.Append("<td>" + $"<label style=\"{style}\">" + dsmutasi.Tables[0].Rows[i]["wilayah_after"].ToString() + "</label>" + "</td>");
                        htmlTableMutasi.Append("<td>" + $"<label style=\"{style}\">" + dsmutasi.Tables[0].Rows[i]["ruangan_after"].ToString() + "</label>" + "</td>");
                        htmlTableMutasi.Append("<td>" + $"<label style=\"{style}\">" + dsmutasi.Tables[0].Rows[i]["rak_after"].ToString() + "</label>" + "</td>");
                        htmlTableMutasi.Append("<td>" + $"<label style=\"{style}\">" + dsmutasi.Tables[0].Rows[i]["wilayah_before"].ToString() + "</label>" + "</td>");
                        htmlTableMutasi.Append("<td>" + $"<label style=\"{style}\">" + dsmutasi.Tables[0].Rows[i]["ruangan_before"].ToString() + "</label>" + "</td>");
                        htmlTableMutasi.Append("<td>" + $"<label style=\"{style}\">" + dsmutasi.Tables[0].Rows[i]["rak_before"].ToString() + "</label>" + "</td>");
                        htmlTableMutasi.Append("</tr>");
                    }
                    htmlTableMutasi.Append("</tbody>");
                    htmlTableMutasi.Append("</table>");
                    PlaceHolderMutasi.Controls.Add(new Literal { Text = htmlTableMutasi.ToString() });
                }
                else
                {
                    lblinfomutasi.Visible = true;
                    lblinfomutasi.Text = "Tidak ada tambahan pekerjaan";
                }
            }
        }

        void tablekonfigurasi()
        {
            querykonfig = $@"select * from table_pekerjaan where jenis_pekerjaan = 'Konfigurasi' and id_logbook = '{idlog}'";

            SqlCommand cmd = new SqlCommand(querykonfig, sqlCon);
            dakonfigurasi = new SqlDataAdapter(cmd);
            dakonfigurasi.Fill(dskonfigurasi);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            style = "font-size:12px; font-weight:normal";
            htmlTableKonfigurasi.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTableKonfigurasi.Append("<thead>");
            htmlTableKonfigurasi.Append("<tr><th>Tanggal</th><th>Status</th><th>Deskripsi</th><th>Startdate</th><th>Enddate</th><th>Lampiran</th><th>Action</th>");
            htmlTableKonfigurasi.Append("</thead>");

            htmlTableKonfigurasi.Append("<tbody>");
            if (!object.Equals(dskonfigurasi.Tables[0], null))
            {
                if (dskonfigurasi.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dskonfigurasi.Tables[0].Rows.Count; i++)
                    {
                        dsfkon.Clear();
                        queryfilekon = $"select * from table_log_file WHERE id_pekerjaan = '{dskonfigurasi.Tables[0].Rows[i]["id_pekerjaan"].ToString()}' and kategori='konfigurasi'";
                        SqlCommand cmd1 = new SqlCommand(queryfilekon, sqlCon);
                        dafkon = new SqlDataAdapter(cmd1);
                        dafkon.Fill(dsfkon);
                        sqlCon.Open();
                        cmd1.ExecuteNonQuery();
                        sqlCon.Close();

                        DateTime start = (DateTime)dskonfigurasi.Tables[0].Rows[i]["startdate"];
                        string mulai = start.ToString("dd/MM/yyyy");
                        DateTime end = (DateTime)dskonfigurasi.Tables[0].Rows[i]["enddate"];
                        string akhir = end.ToString("dd/MM/yyyy");
                        DateTime waktu = (DateTime)dskonfigurasi.Tables[0].Rows[i]["tanggal"];
                        string tgl = waktu.ToString("dd/MM/yyyy");

                        
                        htmlTableKonfigurasi.Append("<tr>");
                        htmlTableKonfigurasi.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + tgl + "</label>" + "</td>");
                        htmlTableKonfigurasi.Append("<td>" + $"<label style=\"{style}\">" + dskonfigurasi.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        htmlTableKonfigurasi.Append("<td>" + $"<label style=\"{style}\">" + dskonfigurasi.Tables[0].Rows[i]["deskripsi"].ToString() + "</label>" + "</td>");
                        htmlTableKonfigurasi.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + mulai + "</label>" + "</td>");
                        htmlTableKonfigurasi.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + akhir + "</label>" + "</td>");
                        if(dsfkon.Tables[0].Rows.Count >= 1)
                        {
                            int count = dsfkon.Tables[0].Rows.Count;
                            string looping = "";
                            string ulawal = "<ul>";
                            string ulakhir = "</ul>";
                            for (int j = 0; j < dsfkon.Tables[0].Rows.Count; j++)
                            {
                                looping += "<li>" + $"<a href=\"../datalogbook/download.aspx?file={dsfkon.Tables[0].Rows[j]["namafiles"].ToString()}\">" + dsfkon.Tables[0].Rows[j]["namafiles"].ToString() + "</a>" + "</li>";
                            }
                            htmlTableKonfigurasi.Append($"<td>" + ulawal + looping + ulakhir + "</td>");
                        }
                        else
                        {
                            htmlTableKonfigurasi.Append("<td>-</td>");
                        }
                        if(dskonfigurasi.Tables[0].Rows[i]["status"].ToString() != "Selesai")
                            htmlTableKonfigurasi.Append("<td>" + $"<a onclick=\"confirmselesai('../datalogbook/action.aspx?idk={dskonfigurasi.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-default\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" + "</td>");
                        else
                            htmlTableKonfigurasi.Append("<td>" + $"<a class=\"label label-primary\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" + "</td>");
                        htmlTableKonfigurasi.Append("</tr>");
                    }
                    htmlTableKonfigurasi.Append("</tbody>");
                    htmlTableKonfigurasi.Append("</table>");
                    PlaceHolderKonfigurasi.Controls.Add(new Literal { Text = htmlTableKonfigurasi.ToString() });
                }
                else
                {
                    lblinfokonfig.Visible = true;
                    lblinfokonfig.Text = "Tidak ada tambahan pekerjaan";
                }
            }
        }

        void tablelain()
        {
            querylain = $@"select * from table_pekerjaan where jenis_pekerjaan = 'Lain-lain' and id_logbook = '{idlog}'";

            SqlCommand cmd = new SqlCommand(querylain, sqlCon);
            dalain = new SqlDataAdapter(cmd);
            dalain.Fill(dslain);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            style = "font-size:12px; font-weight:normal";
            htmlTableLain.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTableLain.Append("<thead>");
            htmlTableLain.Append("<tr><th>Tanggal</th><th>Status</th><th>Deskripsi</th><th>Startdate</th><th>Enddate</th><th>Action</th>");
            htmlTableLain.Append("</thead>");

            htmlTableLain.Append("<tbody>");
            if (!object.Equals(dslain.Tables[0], null))
            {
                if (dslain.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dslain.Tables[0].Rows.Count; i++)
                    {
                        dsflain.Clear();
                        queryfilelain = $"select * from table_log_file WHERE id_pekerjaan = '{dslain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}' and kategori='Lain-lain'";
                        SqlCommand cmd1 = new SqlCommand(queryfilelain, sqlCon);
                        daflain = new SqlDataAdapter(cmd1);
                        daflain.Fill(dsflain);
                        sqlCon.Open();
                        cmd1.ExecuteNonQuery();
                        sqlCon.Close();

                        DateTime start = (DateTime)dslain.Tables[0].Rows[i]["startdate"];
                        string mulai = start.ToString("dd/MM/yyyy");
                        DateTime end = (DateTime)dslain.Tables[0].Rows[i]["enddate"];
                        string akhir = end.ToString("dd/MM/yyyy");
                        DateTime waktu = (DateTime)dslain.Tables[0].Rows[i]["tanggal"];
                        string tgl = waktu.ToString("dd/MM/yyyy");
                        htmlTableLain.Append("<tr>");
                        htmlTableLain.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + tgl + "</label>" + "</td>");
                        htmlTableLain.Append("<td>" + $"<label style=\"{style}\">" + dslain.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        htmlTableLain.Append("<td>" + $"<label style=\"{style}\">" + dslain.Tables[0].Rows[i]["deskripsi"].ToString() + "</label>" + "</td>");
                        htmlTableLain.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + mulai + "</label>" + "</td>");
                        htmlTableLain.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + akhir + "</label>" + "</td>");
                        if (dsflain.Tables[0].Rows.Count >= 1)
                        {
                            int count = dsflain.Tables[0].Rows.Count;
                            string looping = "";
                            string ulawal = "<ul>";
                            string ulakhir = "</ul>";
                            for (int j = 0; j < dsflain.Tables[0].Rows.Count; j++)
                            {
                                looping += "<li>" + $"<a href=\"../datalogbook/download.aspx?file={dsflain.Tables[0].Rows[j]["namafiles"].ToString()}\">" + dsflain.Tables[0].Rows[j]["namafiles"].ToString() + "</a>" + "</li>";
                            }
                            htmlTableLain.Append($"<td>" + ulawal + looping + ulakhir + "</td>");
                        }
                        else
                        {
                            htmlTableLain.Append("<td>-</td>");
                        }
                        if (dslain.Tables[0].Rows[i]["status"].ToString() != "Selesai")
                            htmlTableLain.Append("<td>" + $"<a onclick=\"confirmselesai('../datalogbook/action.aspx?idl={dslain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-default\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" + "</td>");
                        else
                            htmlTableLain.Append("<td>" + $"<a class=\"label label-primary\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" + "</td>");
                        htmlTableLain.Append("</tr>");
                    }
                    htmlTableLain.Append("</tbody>");
                    htmlTableLain.Append("</table>");
                    PlaceHolderLain.Controls.Add(new Literal { Text = htmlTableLain.ToString() });
                }
                else
                {
                    lblinfolain.Visible = true;
                    lblinfolain.Text = "Tidak ada tambahan pekerjaan";
                }

            }
        }

        void tablefungsi()
        {
            queryfungsi = $@"select p.id_perangkat, n.status as statuskerja, d.nama_jenis_device, p.sn, f.*, n.id_pekerjaan from as_history_fungsi f join as_perangkat p on p.id_perangkat = f.id_perangkat join
                    as_jenis_device d on d.id_jenis_device = p.id_jenis_device left join table_pekerjaan n on n.id_perangkat=p.id_perangkat where id_reference = '{idlog}' and n.jenis_pekerjaan ='Fungsi & Status'";

            SqlCommand cmd = new SqlCommand(queryfungsi, sqlCon);
            dafungsi = new SqlDataAdapter(cmd);
            dafungsi.Fill(dsfungsi);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            style = "font-size:12px; font-weight:normal";
            htmlTableFungsi.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTableFungsi.Append("<thead>");
            htmlTableFungsi.Append("<tr><th>Tanggal</th><th>Device</th><th>S/N</th><th>Fungsi</th><th>Status Asset</th><th>#</th>");
            htmlTableFungsi.Append("</thead>");

            htmlTableFungsi.Append("<tbody>");
            if (!object.Equals(dsfungsi.Tables[0], null))
            {
                if (dsfungsi.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dsfungsi.Tables[0].Rows.Count; i++)
                    {
                        htmlTableFungsi.Append("<tr>");
                        htmlTableFungsi.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + dsfungsi.Tables[0].Rows[i]["tanggal"] + "</label>" + "</td>");
                        htmlTableFungsi.Append("<td>" + $"<label style=\"{style}\">" + dsfungsi.Tables[0].Rows[i]["nama_jenis_device"].ToString() + "</label>" + "</td>");
                        htmlTableFungsi.Append("<td>" + $"<a style=\"cursor:pointer\" href=\"../dataasset/detail.aspx?id={dsfungsi.Tables[0].Rows[i]["id_perangkat"].ToString()}\">" + $"<label class=\"label label-sm label-primary\">" + dsfungsi.Tables[0].Rows[i]["sn"].ToString() + "</label>" + "</a>" + "</td>");
                        htmlTableFungsi.Append("<td>" + $"<label style=\"{style}\">" + dsfungsi.Tables[0].Rows[i]["fungsi"].ToString() + "</label>" + "</td>");
                        htmlTableFungsi.Append("<td>" + $"<label style=\"{style}\">" + dsfungsi.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        if (dsfungsi.Tables[0].Rows[i]["statuskerja"].ToString() != "Selesai")
                            htmlTableFungsi.Append("<td>" + $"<a onclick=\"confirmselesai('../datalogbook/action.aspx?idk={dsfungsi.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-default\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" + "</td>");
                        else
                            htmlTableFungsi.Append("<td>" + $"<a class=\"label label-primary\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" + "</td>");
                        htmlTableFungsi.Append("</tr>");
                    }
                    htmlTableFungsi.Append("</tbody>");
                    htmlTableFungsi.Append("</table>");
                    PlaceHolderStatus.Controls.Add(new Literal { Text = htmlTableFungsi.ToString() });
                }
                else
                {
                    lblinfostatus.Visible = true;
                    lblinfostatus.Text = "Tidak ada tambahan pekerjaan";
                }
                
            }
        }

        public class inisial
        {
            public string site { get; set; }
            public string bangunan { get; set; }
            public string ruangan { get; set; }
            public string rak { get; set; }
            public string ruanganid { get; set; }
            public string rakid { get; set; }
            public string idperangkat { get; set; }
            public string idperangkatfung { get; set; }
            public string idwilayah { get; set; }
            public string wilayah { get; set; }
            public string idbangunan { get; set; }
            public string bangunan1 { get; set; }
            public string idruangan { get; set; }
            public string ruangan1 { get; set; }
            public string idrak { get; set; }
            public string rak1 { get; set; }
            public string idequipment { get; set; }
            public string equipment { get; set; }
            public string iddevice { get; set; }
            public string device { get; set; }
            public string devicefung { get; set; }
            public string imgruang { get; set; }
            public string image { get; set; }
            public string fungsi { get; set; }
            public string status { get; set; }
        }

        [WebMethod]
        public static List<inisial> Getwilayah()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from as_wilayah"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                idwilayah = sdr["id_wilayah"].ToString(),
                                wilayah = sdr["nama_wilayah"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> Getbangunan(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * from as_bangunan where id_wilayah = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                idbangunan = sdr["id_bangunan"].ToString(),
                                bangunan1 = sdr["nama_bangunan"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> Getruangan(string sobangunan)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * from as_ruangan where id_bangunan = '{sobangunan}'"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                idruangan = sdr["id_ruangan"].ToString(),
                                ruangan1 = sdr["nama_ruangan"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> Getrak(string soruangan)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * from as_rak where id_ruangan = '{soruangan}'"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                idrak = sdr["id_rak"].ToString(),
                                rak1 = sdr["nama_rak"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> Getsn(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($@"select p.id_perangkat, p.id_ruangan, p.id_rak, w.nama_wilayah, b.nama_bangunan, r.nama_ruangan, k.nama_rak, e.nama_jenis_equipment, m.nama_merk, d.nama_jenis_device, r.image
                    from as_perangkat p join as_jenis_device d on p.id_jenis_device = d.id_jenis_device left
                    join as_ruangan r on p.id_ruangan = r.id_ruangan left
                    join as_rak k on k.id_rak = p.id_rak join as_bangunan b on b.id_bangunan = r.id_bangunan left
                    join as_merk m on p.id_merk = m.id_merk
                    join as_jenis_equipment e on e.id_jenis_equipment = d.id_jenis_equipment join as_wilayah w on w.id_wilayah = b.id_wilayah
                    where p.sn = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                site = sdr["nama_wilayah"].ToString(),
                                ruangan = sdr["nama_ruangan"].ToString(),
                                bangunan = sdr["nama_bangunan"].ToString(),
                                rak = sdr["nama_rak"].ToString(),
                                idperangkat = sdr["id_perangkat"].ToString(),
                                ruanganid = sdr["id_ruangan"].ToString(),
                                rakid = sdr["id_rak"].ToString(),
                                device = sdr["nama_jenis_device"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> Getfungsi(string idf)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($@"select id_perangkat, fungsi, status, d.nama_jenis_device from as_perangkat p left join as_jenis_device d on d.id_jenis_device=p.id_jenis_device where sn = '{idf}'"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                idperangkatfung = sdr["id_perangkat"].ToString(),
                                fungsi = sdr["fungsi"].ToString(),
                                status = sdr["status"].ToString(),
                                devicefung = sdr["nama_jenis_device"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        protected void Fungsi_ServerClick1(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string querykonfig = $@"INSERT INTO table_pekerjaan (id_profile, id_perangkat, id_logbook, jenis_pekerjaan, startdate, enddate, status, tanggal, deskripsi) VALUES
                               ('{iduser}','{txtidpfung.Text}', '{idlog}', 'Fungsi & Status', '{txtsdatefung.Value}', '{txtedatefung.Value}', '{ddlstatusf.Text}', '{datetime1}', '{txtdevice1.Text}')";
            SqlCommand sqlcmd5 = new SqlCommand(querykonfig, sqlCon);
            sqlcmd5.ExecuteNonQuery();
            sqlCon.Close();

            sqlCon.Open();
            string query = $@"INSERT INTO as_history_fungsi (id_profile, id_perangkat, id_reference, fungsi, status, keterangan, tanggal) VALUES
                               ('{iduser}', '{txtidpfung.Text}', '{txtidl.Text}', '{ddlFungsifung.Text}', '{ddlStatusfung.Text}', '{txtKet.Text}', '{datetime1}')";
            SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();

            sqlCon.Open();
            string queryupdate = $@"update as_perangkat set fungsi='{ddlFungsifung.Text}', status='{ddlStatusfung.Text}', tanggal='{datetime1}'
                                    where id_perangkat = '{txtidpfung.Text}'";
            SqlCommand sqlcmd1 = new SqlCommand(queryupdate, sqlCon);
            sqlcmd1.ExecuteNonQuery();
            sqlCon.Close();
            Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=F");
        }
        protected void Konfigurasi_ServerClick2(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string querykonfig = $@"INSERT INTO table_pekerjaan (id_profile, id_logbook, jenis_pekerjaan, deskripsi, startdate, enddate, status, tanggal) VALUES
                               ('{iduser}', '{idlog}', 'Konfigurasi', '{txtKetKonfig.Text}', '{txtsdatekonf.Value}', '{txtedatekonf.Value}', '{ddlstatuskonf.Text}', '{datetime1}'); Select Scope_Identity();";
            SqlCommand sqlcmd5 = new SqlCommand(querykonfig, sqlCon);
            int i = Convert.ToInt32(sqlcmd5.ExecuteScalar());
            sqlCon.Close();
            
            
            if (filekonfig.HasFiles)
            {
                string physicalpath = Server.MapPath("~/fileupload/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);
                
                int filecount = 0;
                foreach (HttpPostedFile file in filekonfig.PostedFiles)
                {
                    filecount += 1;
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = "~/fileupload/" + filename;
                    file.SaveAs(physicalpath + filename);
                    string s = Convert.ToString(i);
                    sqlCon.Open();
                    string queryfile = $@"INSERT INTO table_log_file (id_logbook, id_pekerjaan, files, namafiles, kategori)
                                        VALUES ('{idlog}', '{s}', '{filepath}', '{filename}', 'konfigurasi')";
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=K");
        }

        protected void Lain_ServerClick3(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string querykonfig = $@"INSERT INTO table_pekerjaan (id_profile, id_logbook, jenis_pekerjaan, deskripsi, startdate, enddate, status, tanggal) VALUES
                               ('{iduser}', '{idlog}', 'Lain-lain', '{txtketeranganlain.Text}', '{txtsdatelain.Value}', '{txtedatelain.Value}', '{ddlstatuslain.Text}', '{datetime1}'); Select Scope_Identity();";
            SqlCommand sqlcmd5 = new SqlCommand(querykonfig, sqlCon);
            int i = Convert.ToInt32(sqlcmd5.ExecuteScalar());
            sqlCon.Close();
            
            if (FileLain.HasFiles)
            {
                string physicalpath = Server.MapPath("~/fileupload/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);

                int filecount = 0;
                foreach (HttpPostedFile file in FileLain.PostedFiles)
                {
                    filecount += 1;
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = "~/fileupload/" + filename;
                    file.SaveAs(physicalpath + filename);
                    string s = Convert.ToString(i);
                    sqlCon.Open();
                    string queryfile = $@"INSERT INTO table_log_file (id_logbook, id_pekerjaan, files, namafiles, kategori)
                                        VALUES ('{idlog}', '{s}', '{filepath}', '{filename}', 'Lain-lain')";
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=L");
        }

        protected void Mutasi_ServerClick1(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string query = $@"INSERT INTO as_history_lokasi (id_profile, id_reference, id_perangkat, id_ruangan, id_rak, id_ruanganbef, id_rakbef, tanggal) VALUES
                               ('{iduser}', '{idlog}', '{txtidp.Text}', '{txtruangan.Text}', '{txtrak.Text}', '{txtruanganid.Text}', '{txtrakid.Text}', '{datetime1}')";
            SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();

            sqlCon.Open();
            string query5 = $@"INSERT INTO table_pekerjaan (id_profile, id_perangkat, id_logbook, jenis_pekerjaan, startdate, enddate, status, tanggal, deskripsi) VALUES
                               ('{iduser}', '{txtidp.Text}', '{txtidl.Text}', '{txtjenispekerjaan.Text}', '{txtsdate.Value}', '{txtedate.Value}', '{ddlstatusmut.Text}', '{datetime1}', '{txtdevice.Text}')";
            SqlCommand sqlcmd5 = new SqlCommand(query5, sqlCon);
            sqlcmd5.ExecuteNonQuery();
            sqlCon.Close();

            sqlCon.Open();
            string queryupdate = $@"update as_perangkat set id_ruangan='{txtruangan.Text}', id_rak='{txtrak.Text}', tanggal='{datetime1}'
                                    where id_perangkat = '{txtidp.Text}'";
            SqlCommand sqlcmd1 = new SqlCommand(queryupdate, sqlCon);
            sqlcmd1.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=M");
        }

    }
}