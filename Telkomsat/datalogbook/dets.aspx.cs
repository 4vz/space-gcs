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
    public partial class dets : System.Web.UI.Page
    {
        SqlDataAdapter da, damutasi, da1, dakonfigurasi, dafungsi, dalain, damain, dafkon, daflain, dafmain;
        DataSet ds = new DataSet();
        DataSet dspekerjaan = new DataSet();
        DataSet dsmutasi = new DataSet();
        DataSet dskonfigurasi = new DataSet();
        DataSet dsfungsi = new DataSet();
        DataSet dslain = new DataSet();
        DataSet dsmain = new DataSet();
        DataSet dsfkon = new DataSet();
        DataSet dsflain = new DataSet();
        DataSet dsfmain = new DataSet();
        string query, iduser, tanggal, style1, style3, style2, agenda, dataagenda, idlog, style, querymutasi, queryhistory, querylain, querykonfig, queryfungsi, addwork, queryfilekon, queryfilelain;
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        StringBuilder htmlTableMutasi = new StringBuilder();
        StringBuilder htmlTableKonfigurasi = new StringBuilder();
        StringBuilder htmlTableFungsi = new StringBuilder();
        StringBuilder htmlTableLain = new StringBuilder();
        StringBuilder htmlTableMain = new StringBuilder();
        int output1, outputtotal, outputbagi;
        double hasil, tampil;
        string stylecolor, stylebg, user;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.QueryString["idlog"] != null)
            {
                idlog = Request.QueryString["idlog"].ToString();
            }

            if (Request.QueryString["add"] == null)
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

            if (Session["iduser"] != null)
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
            else if (addwork == "N")
                limain.Attributes.Add("class", "active");


            tableticket();
            tablemutasi();
            tablefungsi();
            tablekonfigurasi();
            tablelain();
            tablemain();
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

            myquery = $@"select * from table_log_file WHERE  id_logbook = '{idlog}' and kategori='utama' and (ekstension in ('.jpeg', '.png', '.bmp', '.jfif', '.gif', '.jpg', '.PNG'))";

            SqlCommand cmd = new SqlCommand(myquery, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable1.AppendLine("<ul>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        namaall = ds.Tables[0].Rows[i]["files"].ToString();
                        namafile = namaall.Replace("~", "..");
                        ext = Path.GetExtension(namaall);
                        htmlTable1.Append($"<li class=\"gambar\"><img style=\"display:block\" class=\"myImg\" src=\"{namafile}\" height=\"200\" /><br />" +
                            $"<label style=\"text-align:center; width:100%; white-space:pre-line; font-size:11px\" >{ds.Tables[0].Rows[i]["caption"].ToString()}</label></li>");
                    }
                    htmlTable.AppendLine("</ul>");
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
            query = $@"select t.*, p.nama from tabel_logbook t join Profile p on p.id_profile=t.id_user where id_logbook = '{idlog}'";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            style1 = "font-size:14px; padding-bottom:10px";
            htmlTable.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table\">");

            htmlTable.AppendLine("<tbody>");
            user = ds.Tables[0].Rows[0]["id_user"].ToString();
            Page.Title = ds.Tables[0].Rows[0]["judul_logbook"].ToString();
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
                        htmlTable.AppendLine("<td>" + "<label style=\"font-size:18px\">" + ds.Tables[0].Rows[i]["judul_logbook"].ToString() + "</label>");
                        if (ds.Tables[0].Rows[i]["id_user"].ToString() == iduser || Session["previllage"].ToString() == "super")
                        {
                            htmlTable.Append($"<a class=\"btn btn-sm btn-danger pull-right\" onclick=\"confirmhapus('../datalogbook/action.aspx?hapus={ds.Tables[0].Rows[i]["id_logbook"].ToString()}')\" style=\"margin-right:10px\">" + "Hapus" + "</a>");
                            htmlTable.Append($"<a class=\"btn btn-sm btn-info pull-right\" href=\"../datalogbook/edit.aspx?idlog={ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" style=\"margin-right:10px\">" + "Edit" + "</a>");
                        }
                        htmlTable.AppendLine("<br />" + "<label style=\"font-size:16px; color:gray;\">" + ds.Tables[0].Rows[i]["tipe_logbook"].ToString() + "</label>" + "<br/>" +
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
                        htmlTable.AppendLine("</tr>" + "<tr>" + $"<td style=\"{style1}\">" + "Dibuat Oleh" + "</td>" + $"<td style=\"{style1}\">" + ":" + "</td>" + $"<td colspan=\"4\" style=\"{style1}\">" + ds.Tables[0].Rows[i]["nama"].ToString() + "</td>" + "</tr>" +
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
                            htmlTable.AppendLine("<td colspan=\"4\" style=\"color:red; font-size14px;\"></td>");
                        }
                        if (ds.Tables[0].Rows[i]["id_user"].ToString() == iduser || Session["previllage"].ToString() == "super")
                        {
                            htmlTable.AppendLine("<td></td>" + "<td>" +
                            "<ul><li class=\"dropdown\"> <button type=\"button\" class=\"btn btn-block btn-primary dropdown-toggle\" data-toggle=\"dropdown\"><i class=\"fa fa-plus\"></i>  Tambah Pekerjaan <span class=\"caret\"></span></button>" +
                            "<ul class=\"dropdown-menu\"><li role=\"presentation\" ><a role=\"menuitem\" tabindex=\"-1\" class=\"btkonfig\" href=\"#\" data-toggle=\"modal\" data-id=\"5\" data-target=\"#modalkonfigurasi\" id=\"btnkonfigurasi\"> Konfigurasi </ a ></ li >" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modalupdate\" id=\"btnmutasi\">Mutasi Asset</a></li>" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modalfungsi\" id=\"btnstatus\">Status Asset</a></li>" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" class=\"btmain\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modalmaintenance\" id=\"btnmain\">Maintenance</a></li>" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" class=\"btlain\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modallainlain\" id=\"btnlain\">Lain-lain</a></li>" +
                            "</ul></li></ul></td>" +
                            "</tr></table>" + "</td>");
                        }

                        htmlTable.AppendLine("</tr>");
                    }
                    htmlTable.AppendLine("</tbody>");
                    htmlTable.AppendLine("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }

        void tablemutasi()
        {
            querymutasi = $@"select n.id_pekerjaan, n.status, h.tanggal, d.nama_jenis_device, p.sn, r.nama_ruangan as ruangan_after, w.nama_wilayah as wilayah_after,
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
            htmlTableMutasi.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTableMutasi.AppendLine("<thead>");
            htmlTableMutasi.AppendLine("<tr><th>Tanggal</th><th>Status</th><th>Device</th><th>S/N</th><th>Sebelum Mutasi</th><th>Setelah Mutasi</th>");
            if (user == iduser || Session["previllage"].ToString() == "super")
                htmlTableMutasi.AppendLine("<th>Action</th>");
            htmlTableMutasi.AppendLine("</tr></thead>");

            htmlTableMutasi.AppendLine("<tbody>");
            if (!object.Equals(dsmutasi.Tables[0], null))
            {
                if (dsmutasi.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dsmutasi.Tables[0].Rows.Count; i++)
                    {
                        htmlTableMutasi.AppendLine("<tr>");
                        htmlTableMutasi.AppendLine("<td>" + "<label style=\"font-size:13px; color:#a9a9a9; font-color width:70px;\">" + dsmutasi.Tables[0].Rows[i]["tanggal"] + "</label>" + "</td>");
                        if (dsmutasi.Tables[0].Rows[i]["status"].ToString() == "Selesai")
                            htmlTableMutasi.AppendLine("<td>" + $"<label style=\"{style}\" class=\"label label-success\">" + dsmutasi.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        else
                            htmlTableMutasi.AppendLine("<td>" + $"<label style=\"{style}\" class=\"label label-warning\">" + dsmutasi.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        htmlTableMutasi.AppendLine("<td>" + $"<label style=\"{style}\">" + dsmutasi.Tables[0].Rows[i]["nama_jenis_device"].ToString() + "</label>" + "</td>");
                        htmlTableMutasi.AppendLine("<td>" + $"<a style=\"cursor:pointer\" href=\"../dataasset/detail.aspx?id={dsmutasi.Tables[0].Rows[i]["id_perangkat"].ToString()}\">" + $"<label class=\"label label-sm label-primary\">" + dsmutasi.Tables[0].Rows[i]["sn"].ToString() + "</label>" + "</a>" + "</td>");
                        htmlTableMutasi.AppendLine("<td>" + "<table style=\"width:100%\">" +
                            "<tr>" +
                            "<td>" + "Wilayah" + "</td>" + "<td>" + ":" + "</td>" + "<td>" + dsmutasi.Tables[0].Rows[i]["wilayah_before"].ToString() + "</td>" +
                            "</tr>" + "<tr>" +
                            "<td>" + "Ruangan" + "</td>" + "<td>" + ":" + "</td>" + "<td>" + dsmutasi.Tables[0].Rows[i]["ruangan_before"].ToString() + "</td>" +
                            "</tr>" + "<tr>" +
                            "<td>" + "Rak" + "</td>" + "<td>" + ":" + "</td>" + "<td>" + dsmutasi.Tables[0].Rows[i]["rak_before"].ToString() + "</td>" +
                            "</tr>" + "<tr>" + "</table>" + "</td>");
                        htmlTableMutasi.AppendLine("<td>" + "<table style=\"width:100%\">" +
                            "<tr>" +
                            "<td>" + "Wilayah" + "</td>" + "<td>" + ":" + "</td>" + "<td>" + dsmutasi.Tables[0].Rows[i]["wilayah_after"].ToString() + "</td>" +
                            "</tr>" + "<tr>" +
                            "<td>" + "Ruangan" + "</td>" + "<td>" + ":" + "</td>" + "<td>" + dsmutasi.Tables[0].Rows[i]["ruangan_after"].ToString() + "</td>" +
                            "</tr>" + "<tr>" +
                            "<td>" + "Rak" + "</td>" + "<td>" + ":" + "</td>" + "<td>" + dsmutasi.Tables[0].Rows[i]["rak_after"].ToString() + "</td>" +
                            "</tr>" + "<tr>" + "</table>" + "</td>");
                        if (user == iduser || Session["previllage"].ToString() == "super")
                        {
                            if (dsmutasi.Tables[0].Rows[i]["status"].ToString() != "Selesai")
                                htmlTableMutasi.AppendLine("<td>" + $"<a onclick=\"confirmselesai('../datalogbook/action.aspx?idm={dsmutasi.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-default\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" + "</td>");
                        }

                        htmlTableMutasi.AppendLine("</tr>");
                    }
                    htmlTableMutasi.AppendLine("</tbody>");
                    htmlTableMutasi.AppendLine("</table>");
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
            htmlTableKonfigurasi.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTableKonfigurasi.AppendLine("<thead>");
            htmlTableKonfigurasi.AppendLine("<tr><th>Tanggal</th><th>Status</th><th>Deskripsi</th><th>Startdate</th><th>Enddate</th><th>Lampiran</th>");
            if (user == iduser || Session["previllage"].ToString() == "super")
                htmlTableKonfigurasi.AppendLine("<th>Action</th>");
            htmlTableKonfigurasi.AppendLine("</tr></thead>");

            htmlTableKonfigurasi.AppendLine("<tbody>");
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


                        htmlTableKonfigurasi.AppendLine("<tr>");
                        htmlTableKonfigurasi.AppendLine("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + tgl + "</label>" + "</td>");
                        if (dskonfigurasi.Tables[0].Rows[i]["status"].ToString() == "Selesai")
                            htmlTableKonfigurasi.AppendLine("<td>" + $"<label style=\"{style}\" class=\"label label-success\">" + dskonfigurasi.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        else
                            htmlTableKonfigurasi.AppendLine("<td>" + $"<label style=\"{style}\" class=\"label label-warning\">" + dskonfigurasi.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        htmlTableKonfigurasi.AppendLine("<td>" + $"<label style=\"{style}; white-space: pre-line;\">" + dskonfigurasi.Tables[0].Rows[i]["deskripsi"].ToString() + "</label>" + "</td>");
                        htmlTableKonfigurasi.AppendLine("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + mulai + "</label>" + "</td>");
                        htmlTableKonfigurasi.AppendLine("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + akhir + "</label>" + "</td>");
                        if (dsfkon.Tables[0].Rows.Count >= 1)
                        {
                            int count = dsfkon.Tables[0].Rows.Count;
                            string looping = "";
                            string loopingdelete = "";
                            string ulawal = "<ul>";
                            string ulakhir = "</ul>";
                            for (int j = 0; j < dsfkon.Tables[0].Rows.Count; j++)
                            {
                                looping += "<li>" + $"<a href=\"../datalogbook/download.aspx?file={dsfkon.Tables[0].Rows[j]["namafiles"].ToString()}\">" + dsfkon.Tables[0].Rows[j]["namafiles"].ToString() + "</a>";
                                if (user == iduser || Session["previllage"].ToString() == "super")
                                {
                                    looping += $"<a onclick=\"confirmhapus('../datalogbook/action.aspx?idfilekonfig={dsfkon.Tables[0].Rows[j]["id_file"].ToString()}&idlog={idlog}')\" class=\"pull-right tooltips\" style=\"margin-right:10px\">" + "(x)" +
                                       "<span class=\"tooltiptexts\">" + "Hapus lampiran" + "</span>" + "</a>" + "</li>";
                                }
                                else
                                    looping += "</li>";
                            }
                            htmlTableKonfigurasi.Append($"<td>" + ulawal + looping + ulakhir + "</td>");
                        }
                        else
                        {
                            htmlTableKonfigurasi.AppendLine("<td>-</td>");
                        }
                        if (user == iduser || Session["previllage"].ToString() == "super")
                        {
                            if (dskonfigurasi.Tables[0].Rows[i]["status"].ToString() != "Selesai")
                                htmlTableKonfigurasi.AppendLine("<td>" + $"<a onclick=\"confirmselesai('../datalogbook/action.aspx?idk={dskonfigurasi.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-default\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" +
                                    $"<button type=\"button\"  style=\"margin-right:10px\" value=\"{dskonfigurasi.Tables[0].Rows[i]["id_pekerjaan"].ToString()}\" class=\"btn btn-sm btn-warning datakonfig\" data-toggle=\"modal\" data-target=\"#modalkonfigurasi\" id=\"edit\">" + "Edit" + "</button>" +
                                    $"<a onclick=\"confirmhapus('../datalogbook/action.aspx?del={dskonfigurasi.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">" + "HAPUS" + "</a>" + "</td>");
                            else
                                htmlTableKonfigurasi.AppendLine("<td>" + $"<button type=\"button\"  style=\"margin-right:10px\" value=\"{dskonfigurasi.Tables[0].Rows[i]["id_pekerjaan"].ToString()}\" class=\"btn btn-sm btn-warning datakonfig\" data-toggle=\"modal\" data-target=\"#modalkonfigurasi\" id=\"edit\">" + "Edit" + "</button>" +
                                    $"<a onclick=\"confirmhapus('../datalogbook/action.aspx?del={dskonfigurasi.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}&tipe=K')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">" + "HAPUS" + "</a>" + "</td>");
                        }

                        htmlTableKonfigurasi.AppendLine("</tr>");
                    }
                    htmlTableKonfigurasi.AppendLine("</tbody>");
                    htmlTableKonfigurasi.AppendLine("</table>");
                    PlaceHolderKonfigurasi.Controls.Add(new Literal { Text = htmlTableKonfigurasi.ToString() });
                }
                else
                {
                    lblinfokonfig.Visible = true;
                    lblinfokonfig.Text = "Tidak ada tambahan pekerjaan";
                }
            }
        }

        void tablemain()
        {
            querylain = $@"select * from table_pekerjaan where jenis_pekerjaan = 'Maintenance' and id_logbook = '{idlog}'";
            string statuskerja;
            SqlCommand cmd = new SqlCommand(querylain, sqlCon);
            damain = new SqlDataAdapter(cmd);
            damain.Fill(dsmain);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            style = "font-size:12px; font-weight:normal";
            htmlTableMain.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTableMain.AppendLine("<thead>");
            htmlTableMain.AppendLine("<tr><th>Tanggal</th><th>Status</th><th>Deskripsi</th><th>Startdate</th><th>Enddate</th><th>Lampiran</th>");
            if (user == iduser || Session["previllage"].ToString() == "super")
                htmlTableMain.AppendLine("<th>Action</th>");
            htmlTableMain.AppendLine("</tr></thead>");

            htmlTableMain.AppendLine("<tbody>");
            if (!object.Equals(dsmain.Tables[0], null))
            {
                if (dsmain.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dsmain.Tables[0].Rows.Count; i++)
                    {
                        dsfmain.Clear();
                        queryfilelain = $"select * from table_log_file WHERE id_pekerjaan = '{dsmain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}' and kategori='Maintenance'";
                        SqlCommand cmd1 = new SqlCommand(queryfilelain, sqlCon);
                        dafmain = new SqlDataAdapter(cmd1);
                        dafmain.Fill(dsfmain);
                        sqlCon.Open();
                        cmd1.ExecuteNonQuery();
                        sqlCon.Close();
                        statuskerja = dsmain.Tables[0].Rows[i]["status"].ToString();
                        DateTime start = (DateTime)dsmain.Tables[0].Rows[i]["startdate"];
                        string mulai = start.ToString("dd/MM/yyyy");
                        DateTime end = (DateTime)dsmain.Tables[0].Rows[i]["enddate"];
                        string akhir = end.ToString("dd/MM/yyyy");
                        DateTime waktu = (DateTime)dsmain.Tables[0].Rows[i]["tanggal"];
                        string tgl = waktu.ToString("dd/MM/yyyy");
                        htmlTableMain.AppendLine("<tr>");
                        htmlTableMain.AppendLine("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + tgl + "</label>" + "</td>");
                        if (dsmain.Tables[0].Rows[i]["status"].ToString() == "Selesai")
                            htmlTableMain.AppendLine("<td>" + $"<label style=\"{style}\" class=\"label label-success\">" + dsmain.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        else
                            htmlTableMain.AppendLine("<td>" + $"<label style=\"{style}\" class=\"label label-warning\">" + dsmain.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        htmlTableMain.AppendLine("<td>" + $"<label style=\"{style}; white-space: pre-line;\">" + dsmain.Tables[0].Rows[i]["deskripsi"].ToString() + "</label>" + "</td>");
                        htmlTableMain.AppendLine("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + mulai + "</label>" + "</td>");
                        htmlTableMain.AppendLine("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + akhir + "</label>" + "</td>");
                        if (dsfmain.Tables[0].Rows.Count >= 1)
                        {
                            int count = dsfmain.Tables[0].Rows.Count;
                            string looping = "";
                            string ulawal = "<ul>";
                            string ulakhir = "</ul>";
                            for (int j = 0; j < dsfmain.Tables[0].Rows.Count; j++)
                            {
                                looping += "<li>" + $"<a href=\"../datalogbook/download.aspx?file={dsfmain.Tables[0].Rows[j]["namafiles"].ToString()}\">" + dsfmain.Tables[0].Rows[j]["namafiles"].ToString() + "</a>";
                                if (user == iduser || Session["previllage"].ToString() == "super")
                                {
                                    looping += $"<a onclick=\"confirmhapus('../datalogbook/action.aspx?idfilemain={dsfmain.Tables[0].Rows[j]["id_file"].ToString()}&idlog={idlog}')\" class=\"pull-right tooltips\" style=\"margin-right:10px\">" + "(x)" +
                                       "<span class=\"tooltiptexts\">" + "Hapus lampiran" + "</span>" + "</a>" + "</li>";
                                }
                                else
                                    looping += "</li>";
                            }
                            htmlTableMain.Append($"<td>" + ulawal + looping + ulakhir + "</td>");
                        }
                        else
                        {
                            htmlTableMain.AppendLine("<td>-</td>");
                        }
                        if (user == iduser || Session["previllage"].ToString() == "super")
                        {
                            if (dsmain.Tables[0].Rows[i]["status"].ToString() != "Selesai")
                                htmlTableMain.AppendLine("<td>" + $"<a onclick=\"confirmselesai('../datalogbook/action.aspx?idn={dsmain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-default\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" +
                                    $"<button type=\"button\"  style=\"margin-right:10px\" value=\"{dsmain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}\" class=\"btn btn-sm btn-warning datamain\" data-toggle=\"modal\" data-target=\"#modalmaintenance\" id=\"edit\">" + "Edit" + "</button>" +
                                    $"<a onclick=\"confirmhapus('../datalogbook/action.aspx?del={dsmain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">" + "HAPUS" + "</a>" + "</td>");
                            else
                                htmlTableMain.AppendLine("<td>" + $"<button type=\"button\"  style=\"margin-right:10px\" value=\"{dsmain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}\" class=\"btn btn-sm btn-warning datamain\" data-toggle=\"modal\" data-target=\"#modalmaintenance\" id=\"edit\">" + "Edit" + "</button>" +
                                    $"<a onclick=\"confirmhapus('../datalogbook/action.aspx?del={dsmain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}&tipe=N')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">" + "HAPUS" + "</a>" + "</td>");
                        }

                        htmlTableMain.AppendLine("</tr>");
                    }
                    htmlTableMain.AppendLine("</tbody>");
                    htmlTableMain.AppendLine("</table>");
                    PlaceHolderMain.Controls.Add(new Literal { Text = htmlTableMain.ToString() });
                }
                else
                {
                    lblmain.Visible = true;
                    lblmain.Text = "Tidak ada tambahan pekerjaan maintenance";
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
            htmlTableLain.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTableLain.AppendLine("<thead>");
            htmlTableLain.AppendLine("<tr><th>Tanggal</th><th>Status</th><th>Deskripsi</th><th>Startdate</th><th>Enddate</th><th>Lampiran</th>");
            if (user == iduser || Session["previllage"].ToString() == "super")
                htmlTableLain.AppendLine("<th>Action</th>");
            htmlTableLain.AppendLine("</tr></thead>");

            htmlTableLain.AppendLine("<tbody>");
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
                        htmlTableLain.AppendLine("<tr>");
                        htmlTableLain.AppendLine("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + tgl + "</label>" + "</td>");
                        if (dslain.Tables[0].Rows[i]["status"].ToString() == "Selesai")
                            htmlTableLain.AppendLine("<td>" + $"<label style=\"{style}\" class=\"label label-success\">" + dslain.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        else
                            htmlTableLain.AppendLine("<td>" + $"<label style=\"{style}\" class=\"label label-warning\">" + dslain.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        htmlTableLain.AppendLine("<td>" + $"<label style=\"{style}; white-space: pre-line;\">" + dslain.Tables[0].Rows[i]["deskripsi"].ToString() + "</label>" + "</td>");
                        htmlTableLain.AppendLine("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + mulai + "</label>" + "</td>");
                        htmlTableLain.AppendLine("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + akhir + "</label>" + "</td>");
                        if (dsflain.Tables[0].Rows.Count >= 1)
                        {
                            int count = dsflain.Tables[0].Rows.Count;
                            string looping = "";
                            string ulawal = "<ul>";
                            string ulakhir = "</ul>";
                            for (int j = 0; j < dsflain.Tables[0].Rows.Count; j++)
                            {
                                looping += "<li>" + $"<a href=\"../datalogbook/download.aspx?file={dsflain.Tables[0].Rows[j]["namafiles"].ToString()}\">" + dsflain.Tables[0].Rows[j]["namafiles"].ToString() + "</a>";
                                if (user == iduser || Session["previllage"].ToString() == "super")
                                {
                                    looping += $"<a onclick=\"confirmhapus('../datalogbook/action.aspx?idfilelain={dsflain.Tables[0].Rows[j]["id_file"].ToString()}&idlog={idlog}')\" class=\"pull-right tooltips\" style=\"margin-right:10px\">" + "(x)" +
                                       "<span class=\"tooltiptexts\">" + "Hapus lampiran" + "</span>" + "</a>" + "</li>";
                                }
                                else
                                    looping += "</li>";
                            }
                            htmlTableLain.Append($"<td>" + ulawal + looping + ulakhir + "</td>");
                        }
                        else
                        {
                            htmlTableLain.AppendLine("<td>-</td>");
                        }
                        if (user == iduser || Session["previllage"].ToString() == "super")
                        {
                            if (dslain.Tables[0].Rows[i]["status"].ToString() != "Selesai")
                                htmlTableLain.AppendLine("<td>" + $"<a onclick=\"confirmselesai('../datalogbook/action.aspx?idl={dslain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-default\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" +
                                    $"<button type=\"button\"  style=\"margin-right:10px\" value=\"{dslain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}\" class=\"btn btn-sm btn-warning datalain\" data-toggle=\"modal\" data-target=\"#modallainlain\" id=\"edit\">" + "Edit" + "</button>" +
                                    $"<a onclick=\"confirmhapus('../datalogbook/action.aspx?del={dslain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">" + "HAPUS" + "</a>" + "</td>");
                            else
                                htmlTableLain.AppendLine("<td>" + $"<button type=\"button\"  style=\"margin-right:10px\" value=\"{dslain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}\" class=\"btn btn-sm btn-warning datalain\" data-toggle=\"modal\" data-target=\"#modallainlain\" id=\"edit\">" + "Edit" + "</button>" +
                                    $"<a onclick=\"confirmhapus('../datalogbook/action.aspx?del={dslain.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}&tipe=L')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">" + "HAPUS" + "</a>" + "</td>");
                        }

                        htmlTableLain.AppendLine("</tr>");
                    }
                    htmlTableLain.AppendLine("</tbody>");
                    htmlTableLain.AppendLine("</table>");
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
            htmlTableFungsi.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTableFungsi.AppendLine("<thead>");
            htmlTableFungsi.AppendLine("<tr><th>Tanggal</th><th>Device</th><th>S/N</th><th>Fungsi</th><th>Status Asset</th><th>#</th>");
            htmlTableFungsi.AppendLine("</thead>");

            htmlTableFungsi.AppendLine("<tbody>");
            if (!object.Equals(dsfungsi.Tables[0], null))
            {
                if (dsfungsi.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < dsfungsi.Tables[0].Rows.Count; i++)
                    {
                        htmlTableFungsi.AppendLine("<tr>");
                        htmlTableFungsi.AppendLine("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + dsfungsi.Tables[0].Rows[i]["tanggal"] + "</label>" + "</td>");
                        htmlTableFungsi.AppendLine("<td>" + $"<label style=\"{style}\">" + dsfungsi.Tables[0].Rows[i]["nama_jenis_device"].ToString() + "</label>" + "</td>");
                        htmlTableFungsi.AppendLine("<td>" + $"<a style=\"cursor:pointer\" href=\"../dataasset/detail.aspx?id={dsfungsi.Tables[0].Rows[i]["id_perangkat"].ToString()}\">" + $"<label class=\"label label-sm label-primary\">" + dsfungsi.Tables[0].Rows[i]["sn"].ToString() + "</label>" + "</a>" + "</td>");
                        htmlTableFungsi.AppendLine("<td>" + $"<label style=\"{style}\">" + dsfungsi.Tables[0].Rows[i]["fungsi"].ToString() + "</label>" + "</td>");
                        htmlTableFungsi.AppendLine("<td>" + $"<label style=\"{style}\">" + dsfungsi.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        if (dsfungsi.Tables[0].Rows[i]["statuskerja"].ToString() != "Selesai")
                            htmlTableFungsi.AppendLine("<td>" + $"<a onclick=\"confirmselesai('../datalogbook/action.aspx?idk={dsfungsi.Tables[0].Rows[i]["id_pekerjaan"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-default\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" + "</td>");
                        else
                            htmlTableFungsi.AppendLine("<td>" + $"<a class=\"label label-primary\" style=\"margin-right:10px\">" + "SELESAI" + "</a>" + "</td>");
                        htmlTableFungsi.AppendLine("</tr>");
                    }
                    htmlTableFungsi.AppendLine("</tbody>");
                    htmlTableFungsi.AppendLine("</table>");
                    PlaceHolderStatus.Controls.Add(new Literal { Text = htmlTableFungsi.ToString() });
                }
                else
                {
                    lblinfostatus.Visible = true;
                    lblinfostatus.Text = "Tidak ada tambahan pekerjaan";
                }

            }
        }

        public class dataedit
        {
            public string idlain { get; set; }
            public string awallain { get; set; }
            public string akhirlain { get; set; }
            public string statuslain { get; set; }
            public string keteranganlain { get; set; }

            public string idmain { get; set; }
            public string awalmain { get; set; }
            public string akhirmain { get; set; }
            public string statusmain { get; set; }
            public string keteranganmain { get; set; }

            public string idkonfig { get; set; }
            public string awalkonfig { get; set; }
            public string akhirkonfig { get; set; }
            public string statuskonfig { get; set; }
            public string keterangankonfig { get; set; }
        }

        [WebMethod]
        public static List<dataedit> GetLain(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM table_pekerjaan where id_pekerjaan = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<dataedit> dadevices = new List<dataedit>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            DateTime start = (DateTime)sdr["startdate"];
                            DateTime end = (DateTime)sdr["enddate"];
                            dadevices.Add(new dataedit
                            {

                                idlain = sdr["id_pekerjaan"].ToString(),
                                awallain = start.ToString("yyyy/MM/dd"),
                                akhirlain = end.ToString("yyyy/MM/dd"),
                                statuslain = sdr["status"].ToString(),
                                keteranganlain = sdr["deskripsi"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return dadevices;
                }
            }
        }

        [WebMethod]
        public static List<dataedit> Getmain(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM table_pekerjaan where id_pekerjaan = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<dataedit> dadevices = new List<dataedit>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            DateTime start = (DateTime)sdr["startdate"];
                            DateTime end = (DateTime)sdr["enddate"];
                            dadevices.Add(new dataedit
                            {

                                idmain = sdr["id_pekerjaan"].ToString(),
                                awalmain = start.ToString("yyyy/MM/dd"),
                                akhirmain = end.ToString("yyyy/MM/dd"),
                                statusmain = sdr["status"].ToString(),
                                keteranganmain = sdr["deskripsi"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return dadevices;
                }
            }
        }

        [WebMethod]
        public static List<dataedit> Getkonfig(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM table_pekerjaan where id_pekerjaan = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<dataedit> dadevices = new List<dataedit>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            DateTime start = (DateTime)sdr["startdate"];
                            DateTime end = (DateTime)sdr["enddate"];
                            dadevices.Add(new dataedit
                            {

                                idkonfig = sdr["id_pekerjaan"].ToString(),
                                awalkonfig = start.ToString("yyyy/MM/dd"),
                                akhirkonfig = end.ToString("yyyy/MM/dd"),
                                statuskonfig = sdr["status"].ToString(),
                                keterangankonfig = sdr["deskripsi"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return dadevices;
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

        protected void Konfigurasi_ServerClick2_Edit(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string query = $@"UPDATE table_pekerjaan SET deskripsi='{txtKetKonfig.Text}', startdate='{txtsdatekonf.Value}', 
                            enddate='{txtedatekonf.Value}', status='{ddlstatuskonf.Text}' WHERE id_pekerjaan='{txtidkonfig.Text}' ";
            SqlCommand sqlcmd5 = new SqlCommand(query, sqlCon);
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
                                        VALUES ('{idlog}', '{txtidkonfig.Text}', '{filepath}', '{filename}', 'konfigurasi')";
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

        protected void Lain_ServerClick3_Edit(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string query = $@"UPDATE table_pekerjaan SET deskripsi='{txtketeranganlain.Text}', startdate='{txtsdatelain.Value}', 
                            enddate='{txtedatelain.Value}', status='{ddlstatuslain.Text}' WHERE id_pekerjaan='{txtidlain.Text}' ";
            SqlCommand sqlcmd5 = new SqlCommand(query, sqlCon);
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
                                        VALUES ('{idlog}', '{txtidlain.Text}', '{filepath}', '{filename}', 'Lain-lain')";
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=L");
        }

        protected void Maintenance_ServerClick2(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string querykonfig = $@"INSERT INTO table_pekerjaan (id_profile, id_logbook, jenis_pekerjaan, deskripsi, startdate, enddate, status, tanggal) VALUES
                               ('{iduser}', '{txtidl.Text}', 'Maintenance', '{txtketmain.Text}', '{txtsdatemain.Value}', '{txtedatemain.Value}', '{ddlstatusmain.Text}', '{datetime1}'); Select Scope_Identity();";
            SqlCommand sqlcmd5 = new SqlCommand(querykonfig, sqlCon);
            int i = Convert.ToInt32(sqlcmd5.ExecuteScalar());
            sqlCon.Close();
            if (fileuploadmain.HasFiles)
            {
                string physicalpath = Server.MapPath("~/fileupload/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);

                int filecount = 0;
                foreach (HttpPostedFile file in fileuploadmain.PostedFiles)
                {
                    filecount += 1;
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = "~/fileupload/" + filename;
                    file.SaveAs(physicalpath + filename);
                    string s = Convert.ToString(i);
                    sqlCon.Open();
                    string queryfile = $@"INSERT INTO table_log_file (id_logbook, id_pekerjaan, files, namafiles, kategori)
                                        VALUES ('{txtidl.Text}', '{s}', '{filepath}', '{filename}', 'Maintenance')";
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "enablebtn()", true);
            Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=N");

        }

        protected void Maintenance_ServerClick2_Edit(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string query = $@"UPDATE table_pekerjaan SET deskripsi='{txtketmain.Text}', startdate='{txtsdatemain.Value}', 
                            enddate='{txtedatemain.Value}', status='{ddlstatusmain.Text}' WHERE id_pekerjaan='{txtidmain.Text}' ";
            SqlCommand sqlcmd5 = new SqlCommand(query, sqlCon);
            int i = Convert.ToInt32(sqlcmd5.ExecuteScalar());
            sqlCon.Close();

            if (fileuploadmain.HasFiles)
            {
                string physicalpath = Server.MapPath("~/fileupload/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);

                int filecount = 0;
                foreach (HttpPostedFile file in fileuploadmain.PostedFiles)
                {
                    filecount += 1;
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = "~/fileupload/" + filename;
                    file.SaveAs(physicalpath + filename);
                    string s = Convert.ToString(i);
                    sqlCon.Open();
                    string queryfile = $@"INSERT INTO table_log_file (id_logbook, id_pekerjaan, files, namafiles, kategori)
                                        VALUES ('{idlog}', '{txtidmain.Text}', '{filepath}', '{filename}', 'Maintenance')";
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=N");
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