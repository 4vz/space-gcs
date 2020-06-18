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
using System.Text.RegularExpressions;

namespace Telkomsat.datalogbook
{
    public partial class add : System.Web.UI.Page
    {
        SqlDataAdapter da, da1;
        DataSet ds = new DataSet();
        DataSet dspekerjaan = new DataSet();
        string query, iduser, tanggal, style1, style3, style2, agenda, dataagenda;
        string bwilayah, bruangan, brak, queryhistory, queryfungsi, querylain, addwork, stylecolor, stylebg;
        StringBuilder htmlTable = new StringBuilder();
        string[] myket, nmstart, nmend, nmket, nmstatus;
        int output1, outputtotal, outputbagi, a = 0;
        double hasil, tampil;

        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Form.Enctype = "multipart/form-data";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["iduser"] != null)
            {
                iduser = Session["iduser"].ToString();
            }
            if (!IsPostBack)
            {
                tableticket();
            }

        }

        protected void Fungsi_ServerClick1(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string querykonfig = $@"INSERT INTO table_pekerjaan (id_profile, id_perangkat, id_logbook, jenis_pekerjaan, startdate, enddate, status, tanggal, deskripsi) VALUES
                               ('{iduser}', '{txtidpfung.Text}', '{txtidl.Text}', 'Fungsi & Status', '{txtsdatefung.Value}', '{txtedatefung.Value}', '{ddlstatusf.Text}', '{datetime1}', '{txtdevice1.Text}')";
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
            Response.Redirect($"detail.aspx?idlog={txtidl.Text}&add=F");

        }

        protected void Maintenance_ServerClick2(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string querykonfig = $@"INSERT INTO table_pekerjaan (id_profile, id_logbook, jenis_pekerjaan, deskripsi, startdate, enddate, status, tanggal) VALUES
                               ('{iduser}', '{txtidl.Text}', 'Maintenance', '{txtketmain.Text}', '{txtsdatemain.Value}', '{txtedatemain.Value}', '{txtAktivitas.Text}', '{datetime1}'); Select Scope_Identity();";
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
            Response.Redirect($"detail.aspx?idlog={txtidl.Text}&add=N");
        }


        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
          
            string eket = Request.Form["nmketerangan"];
            string estatus = Request.Form["nmstatus"];
            string estart = Request.Form["nmstartdate"];
            string eend = Request.Form["nmenddate"];
            string ct;
            //nmstart = new string[Request.Form["nmenddate"].Count()];
            if (Request.Form["nmenddate"] == null)
                ct = "0";
            else
                ct = Request.Form["nmenddate"].ToString();


            Response.Write("total = " + Request.Form["nmketerangan"].ToString());
            //Response.Redirect("data.aspx");
            /*mynominal = new string[Request.Files.Count];
            a = b = c = 0;
            if (nominal != null)
            {
                string[] lines = Regex.Split(keterangan, ",");

                foreach (string line in lines)
                {
                    myket[a] = line;
                    a++;
                }
            }

            if (keterangan != null)
            {
                string[] lines = Regex.Split(nominal, ",");

                foreach (string line in lines)
                {
                    mynominal[b] = line;
                    b++;
                }
            }
            myket = new string[Request.Files.Count];
            tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            query = $@"insert into tabel_logbook(id_user, tanggal, judul_logbook, waktu_action, due_date, tipe_logbook, unit, status, pic_internal, pic_eksternal, agenda) values
                      ('{iduser}', '{tanggal}', '{txtjudul.Text}', '{txtstartdate.Text}', '{txtduedate.Text}', '{ddlkategori.Text}', '{ddlunit.Text}', '{ddlstatus.Text}', '{txtint.Text}', '{txtext.Text}', '{txtAktivitas.Text}'); Select Scope_Identity();";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            sqlCon.Close();

            string caption = Request.Form["caption"];
            if (caption != null)
            {
                string[] lines = Regex.Split(caption, ",");

                foreach (string line in lines)
                {
                    myket[a] = line;
                    a++;
                }
            }
            HttpFileCollection filecolln = Request.Files;
            for (int j = 0; j < filecolln.Count; j++)
            {
                HttpPostedFile file = filecolln[j];
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = "~/fileupload/" + filename;
                    string extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("~/fileupload/") + Path.GetFileName(file.FileName));
                    string s = Convert.ToString(i);
                    if (myket[j] == "")
                        myket[j] = filename;
                    sqlCon.Open();
                    string queryfile = $@"INSERT INTO table_log_file (id_logbook, files, namafiles, kategori, ekstension, caption)
                                        VALUES ('{s}', '{filepath}', '{filename}', 'utama', '{extension}', '{myket[j]}')";
                    //Response.Write(queryfile); ;
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }

            string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
            string querylog = $@"Insert into log (id_profile, tanggal, tipe, judul) values
                                ('{iduser}', '{tanggalku}', 'tlog', '{txtjudul.Text}')";
            sqlCon.Open();
            SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
            cmdlog.ExecuteNonQuery();
            sqlCon.Close();
            divsuccess.Visible = true;
            tableticket();*/
        }

        protected void Mutasi_ServerClick1(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string query = $@"INSERT INTO as_history_lokasi (id_profile, id_perangkat, id_reference, id_ruangan, id_rak, id_ruanganbef, id_rakbef, tanggal) VALUES
                               ('{iduser}', '{txtidp.Text}', '{txtidl.Text}', '{txtruangan.Text}', '{txtrak.Text}', '{txtruanganid.Text}', '{txtrakid.Text}', '{datetime1}')";
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

            string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
            string querylog = $@"Insert into log (id_profile, tanggal, tipe, judul, keterangan) values
                                ('{iduser}', '{tanggalku}', 'mut', 'mutasi', '{txtdevice.Text}')";
            sqlCon.Open();
            SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
            cmdlog.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect($"detail.aspx?idlog={txtidl.Text}&add=M");
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

        void tableticket()
        {
            var datenow = DateTime.Now.ToString("yyyy/MM/dd");
            query = $@"select * from tabel_logbook where tanggal = '{datenow}' order by id_logbook desc";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            style1 = "font-size:12px";
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

                        string amulai = start.ToString("yyyy/MM/dd");
                        string aakhir = start.ToString("yyyy/MM/dd");
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
                            htmlTable.Append($"<td colspan\"3\">" + "Tidak ada subpekerjaan" + "</td>");
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
                        htmlTable.Append("<td></td><td></td><td></td><td></td>" + "<td>" +
                            "<ul><li class=\"dropdown\"> <button type=\"button\" class=\"btn btn-block btn-primary dropdown-toggle\" data-toggle=\"dropdown\"><i class=\"fa fa-plus\"></i>  Tambah Pekerjaan <span class=\"caret\"></span></button>" +
                            $"<ul class=\"dropdown-menu\">" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modalkonfigurasi\" id=\"btnkonfigurasi\"> Konfigurasi </ a ></ li >" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modalupdate\" id=\"btnmutasi\">Mutasi Asset</a></li>" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modalfungsi\" id=\"btnstatus\">Status Asset</a></li>" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modalmaintenance\" id=\"btnlain\">Maintenance</a></li>" +
                            $"<li role=\"presentation\"><a role=\"menuitem\" tabindex=\"-1\" href=\"#\" data-toggle=\"modal\" data-id=\"{ds.Tables[0].Rows[i]["id_logbook"].ToString()}\" data-target=\"#modallainlain\" id=\"btnlain\">Lain-lain</a></li>" +
                            "</ul></li></ul></td>" +
                            "</tr></table>" + "</td>");
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