﻿using System;
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

namespace Telkomsat.admin
{
    public partial class approvement : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string kategori, style3, warna1, warna2, warna3, warna4, query, previllage;
        string filename, filepath, extension, queryinsert;
        int rek1harkat, rek2harkat, rek1me, rek2me, braharkat, brame;
        double ventotal;
        protected void Page_Load(object sender, EventArgs e)
        {
            string user, query2;
            user = Session["iduser"].ToString();

            query2 = $"Select * from AdminProfile where AP_Nama = '{user}'";
            DataSet ds2 = Settings.LoadDataSet(query2);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                previllage = ds2.Tables[0].Rows[0]["AP_Previllage"].ToString();
            }

            if (Request.QueryString["jenis"] == "diajukan")
            {
                query = $@"SELECT j.*, e.nama from AdminJustifikasi j join AdminProfile p on p.AP_ID=j.AJ_PT join Profile e
                            on e.id_profile = p.AP_Nama where AJ_Status is null or AJ_Status = ''";

                if (previllage != "User")
                {
                    if(previllage != "SA")
                        Response.Redirect("dashboard.aspx");
                }
                    

            }
            else if (Request.QueryString["jenis"] == "gm")
            {
                query = $"SELECT * from AdminJustifikasi WHERE AJ_Status = 'diajukan'";

                if (previllage != "GM")
                {
                    if (previllage != "SA")
                        Response.Redirect("dashboard.aspx");
                }
            }
            else if (Request.QueryString["jenis"] == "admin")
            {
                query = $"SELECT * from AdminJustifikasi WHERE AJ_Status = 'gm'";

                if (previllage != "Admin Bendahara")
                {
                    if (previllage != "SA")
                        Response.Redirect("dashboard.aspx");
                }
            }
            else
            {
                Response.Redirect("dashboard.aspx");
            }
            referens();
        }

        protected void Approve_Admin(object sender, EventArgs e)
        {

            if (FileUpload1.HasFiles)
            {
                string physicalpath = Server.MapPath("~/fileupload/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);

                int filecount = 0;
                foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                {
                    filecount += 1;
                    filename = Path.GetFileName(file.FileName);
                    filepath = "~/fileupload/" + filename;
                    file.SaveAs(physicalpath + filename);
                    extension = Path.GetExtension(file.FileName);
                }
                //lblstatus.Text = filecount + " files upload";
            }

            sqlCon.Open();
            string queryfile = $@"INSERT INTO AdminEvidence (AE_AJ, AE_File, AE_NamaFile, AE_Ekstension, AE_Tipe)
                                        VALUES ('{txtidl.Text}', '{filepath}', '{filename}', '{extension}', 'admin')";
            //Response.Write(queryfile); ;
            SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

            sqlCmd1.ExecuteNonQuery();
            sqlCon.Close();

            sqlCon.Open();
            string query = $@"UPDATE AdminJustifikasi SET AJ_Status = 'admin', AJ_TglEv = '{txttanggal.Text}' WHERE AJ_ID='{txtidl.Text}'";
            //Response.Write(queryfile); ;
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);

            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();

            var datetime = DateTime.Now.ToString("yyyy/MM/dd");
            string querylast = "select * from administrator where id_admin = (select max(id_admin) from administrator)";
            DataSet ds7 = Settings.LoadDataSet(querylast);
            braharkat = Convert.ToInt32(ds7.Tables[0].Rows[0]["bra_harkat"].ToString());
            brame = Convert.ToInt32(ds7.Tables[0].Rows[0]["bra_me"].ToString());
            rek1harkat = Convert.ToInt32(ds7.Tables[0].Rows[0]["rek_harkat1"].ToString());
            rek2harkat = Convert.ToInt32(ds7.Tables[0].Rows[0]["rek_harkat2"].ToString());
            rek1me = Convert.ToInt32(ds7.Tables[0].Rows[0]["rek_me1"].ToString());
            rek2me = Convert.ToInt32(ds7.Tables[0].Rows[0]["rek_me2"].ToString());

            if(txttipe.Text == "vendor")
            {
                string queryven, queryid, sekarang;
                double totalvendor;

                queryid = $@"SELECT * from AdminVendorNom WHERE AVN_ID = (SELECT MAX(AVN_ID) from AdminVendorNom) and AVN_AV='{txtvendor.Text}'";

                sekarang = DateTime.Now.ToString("yyyy/MM/dd");

                DataSet dsid = Settings.LoadDataSet(queryid);

                if(dsid.Tables[0].Rows.Count == 0)
                {
                    ventotal = 0;
                }
                else
                {
                    ventotal = (double)dsid.Tables[0].Rows[0]["AVN_Total"];
                }


                totalvendor = ventotal + Convert.ToDouble(txttotal.Text);

                queryven = $@"INSERT INTO AdminVendorNom (AVN_AV, AVN_Nominal, AVN_Total, AVN_Tanggal, AVN_NK)
                            VALUES ('{txtvendor.Text}', '{txttotal.Text}', '{totalvendor}', '{txttanggal.Text}', '{txtketerangan.Text}')";

                sqlCon.Open();
                SqlCommand sqlCmdven = new SqlCommand(queryven, sqlCon);
                sqlCmdven.ExecuteNonQuery();
                sqlCon.Close();
                
            }
            else if(txttipe.Text == "internal")
            {
                string parse = txttotal.Text;
                int input = Convert.ToInt32(parse);

                if (FileUpload1.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                    {
                        filecount += 1;
                        filename = Path.GetFileName(file.FileName);
                        filepath = "~/evidence/" + filename;
                        file.SaveAs(physicalpath + filename);
                    }
                    //lblstatus.Text = filecount + " files upload";

                }

                if (ddlKategori.Text == "Rek. Harkat Bendahara 1")
                {
                    queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat + input}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. Harkat 1', 'pemasukan')";
                }
                else if (ddlKategori.Text == "Rek. Harkat Bendahara 2")
                {
                    queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat}, {rek2harkat + input}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. Harkat 2', 'pemasukan')";
                }
                else if (ddlKategori.Text == "Rek. ME Bendahara 1")
                {
                    queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me + input}, {rek2me}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. ME 1', 'pemasukan')";
                }
                else if (ddlKategori.Text == "Rek. ME Bendahara 2")
                {
                    queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me + input}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. ME 2', 'pemasukan')";
                }
                else if (ddlKategori.Text == "Brankas Harkat")
                {
                    queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat + input}, {brame}, '{filename}', '{filepath}', 'Brankas Harkat', 'pemasukan')";
                }
                else if (ddlKategori.Text == "Brankas ME")
                {
                    queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame + input}, '{filename}', '{filepath}', 'Brankas ME', 'pemasukan')";
                }

                sqlCon.Open();
                SqlCommand sqlCmd7 = new SqlCommand(queryinsert, sqlCon);
                sqlCmd7.ExecuteNonQuery();
                sqlCon.Close();
            }
            else if(txttipe.Text == "dua")
            {
                keduanya();
            }
            else if(txttipe.Text == "null")
            {
                Response.Redirect("~/error.aspx");
            }


            Response.Redirect("approvement.aspx?jenis=admin");
        }

        void keduanya()
        {
            string queryven, queryid, sekarang;
            double totalvendor;

            queryid = $@"SELECT * from AdminVendorNom WHERE AVN_ID = (SELECT MAX(AVN_ID) from AdminVendorNom) and AVN_AV='{txtvendor.Text}'";

            sekarang = DateTime.Now.ToString("yyyy/MM/dd");

            DataSet dsid = Settings.LoadDataSet(queryid);

            if (dsid.Tables[0].Rows.Count == 0)
            {
                ventotal = 0;
            }
            else
            {
                ventotal = (double)dsid.Tables[0].Rows[0]["AVN_Total"];
            }


            totalvendor = ventotal + Convert.ToDouble(txtnominalven.Text);

            queryven = $@"INSERT INTO AdminVendorNom (AVN_AV, AVN_Nominal, AVN_Total, AVN_Tanggal, AVN_NK)
                            VALUES ('{txtvendor.Text}', '{txtnominalven.Text}', '{totalvendor}', '{txttanggal.Text}', '{txtketerangan.Text}')";

            sqlCon.Open();
            SqlCommand sqlCmdven = new SqlCommand(queryven, sqlCon);
            sqlCmdven.ExecuteNonQuery();
            sqlCon.Close();

            string parse = txtnominalint.Text;
            int input = Convert.ToInt32(parse);

            if (FileUpload1.HasFiles)
            {
                string physicalpath = Server.MapPath("~/evidence/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);

                int filecount = 0;
                foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                {
                    filecount += 1;
                    filename = Path.GetFileName(file.FileName);
                    filepath = "~/evidence/" + filename;
                    file.SaveAs(physicalpath + filename);
                }
                //lblstatus.Text = filecount + " files upload";

            }

            if (ddlKategori.Text == "Rek. Harkat Bendahara 1")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat + input}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. Harkat 1', 'pemasukan')";
            }
            else if (ddlKategori.Text == "Rek. Harkat Bendahara 2")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat}, {rek2harkat + input}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. Harkat 2', 'pemasukan')";
            }
            else if (ddlKategori.Text == "Rek. ME Bendahara 1")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me + input}, {rek2me}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. ME 1', 'pemasukan')";
            }
            else if (ddlKategori.Text == "Rek. ME Bendahara 2")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me + input}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. ME 2', 'pemasukan')";
            }
            else if (ddlKategori.Text == "Brankas Harkat")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat + input}, {brame}, '{filename}', '{filepath}', 'Brankas Harkat', 'pemasukan')";
            }
            else if (ddlKategori.Text == "Brankas ME")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{txtketerangan.Text}', '{txttanggal.Text}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame + input}, '{filename}', '{filepath}', 'Brankas ME', 'pemasukan')";
            }

            sqlCon.Open();
            SqlCommand sqlCmd7 = new SqlCommand(queryinsert, sqlCon);
            sqlCmd7.ExecuteNonQuery();
            sqlCon.Close();
        }

        void referens()
        {
            string IDdata, jupd, ja, kegiatan, status;
            DataSet ds = Settings.LoadDataSet(query);
            style3 = "font-weight:normal";

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Nomor Justifikasi</th><th>Jenis Anggaran</th><th>Nama Kegiatan</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["AJ_ID"].ToString();
                        jupd = ds.Tables[0].Rows[i]["AJ_NJ"].ToString();
                        ja = ds.Tables[0].Rows[i]["AJ_JA"].ToString();
                        kegiatan = ds.Tables[0].Rows[i]["AJ_NK"].ToString();
                        status = ds.Tables[0].Rows[i]["AJ_NK"].ToString();

                        if (status == "diajukan")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "black";
                            warna3 = "black";
                            warna4 = "black";
                        }
                        else if (status == "manager")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "deepskyblue";
                            warna3 = "black";
                            warna4 = "black";
                        }
                        else if (status == "gm")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "deepskyblue";
                            warna3 = "deepskyblue";
                            warna4 = "black";
                        }
                        else if (status == "admin")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "deepskyblue";
                            warna3 = "deepskyblue";
                            warna4 = "deepskyblue";
                        }
                        else
                        {
                            warna1 = "black";
                            warna2 = "black";
                            warna3 = "black";
                            warna4 = "black";
                        }
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + jupd + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ja + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + kegiatan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<button type=\"button\"  style=\"margin-right:10px\" value=\"{IDdata}\" class=\"btn btn-sm btn-default datamain\" data-toggle=\"modal\" data-target=\"#modalmaintenance\" id=\"edit\">" + "Detail" + "</button>");
                        if(previllage == "User")
                            htmlTable.Append($"<a onclick=\"confirmselesai('action.aspx?idapp={IDdata}&jenis={Request.QueryString["jenis"].ToString()}')\" class=\"btn btn-sm btn-primary\" id=\"btndelete\">" + "Ajukan" + "</a>");
                        else if(previllage == "Admin Bendahara")
                            htmlTable.Append($"<button type=\"button\" id=\"btnadmin\" style=\"margin-right:10px\" value=\"{IDdata}\" class=\"btn btn-sm btn-primary datatotal\" data-toggle=\"modal\" data-target=\"#modalupdate\">" + "Approve" + "</button>");
                        else
                            htmlTable.Append($"<a onclick=\"confirmselesai('action.aspx?idapp={IDdata}&jenis={Request.QueryString["jenis"].ToString()}')\" class=\"btn btn-sm btn-primary\" id=\"btndelete\">" + "Approve" + "</a>");

                        htmlTable.Append("</td></tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
                else
                {
                    lblgm.Visible = true;
                    lblgm.Text = "Tidak ada data approvement/pengajuan";
                }
            }
        }

        public class inisial
        {
            public string comply { get; set; }
            public string detail { get; set; }
            public string ja { get; set; }
            public string jupd { get; set; }
            public string ket { get; set; }
            public string nilai { get; set; }
            public string nk { get; set; }
            public string nrkap { get; set; }
            public string nv { get; set; }
            public string pk { get; set; }
            public string tglpt { get; set; }
            public string jabatan { get; set; }
            public string subdit { get; set; }
            public string tgl { get; set; }
            public string naa { get; set; }
            public string tglds { get; set; }
            public string total { get; set; }
            public string keterangan { get; set; }
            public string gt { get; set; }
        }

        [WebMethod]
        public static List<inisial> GetDetail(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT j.*, r1.AR_Reference [jabatan], r2.AR_Reference [subdit], e.nama, k.ARK_Aktivitas, k.ARK_NoA, v.AV_Perusahaan, AP_Nama
                                FROM AdminJustifikasi j full join AdminProfile p on j.AJ_PT = p.AP_ID full join AdminReference r1
                                on r1.AR_ID = p.AP_Jabatan full join AdminReference r2 on r2.AR_ID = p.AP_Subdit full join AdminRKAP k
                                on k.ARK_ID = j.AJ_AR full join AdminVendor v on v.AV_ID = j.AJ_AV full join Profile e on e.id_profile = p.AP_Nama WHERE AJ_ID = '{videoid}'"))
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
                                comply = sdr["AJ_Comply"].ToString(),
                                detail = sdr["AJ_Detail"].ToString(),
                                ja = sdr["AJ_JA"].ToString(),
                                jupd = sdr["AJ_JUPD"].ToString(),
                                ket = sdr["AJ_Ket"].ToString(),
                                nilai = sdr["AJ_Nilai"].ToString(),
                                nk = sdr["AJ_NK"].ToString(),
                                nrkap = sdr["AJ_AR"].ToString(),
                                pk = sdr["ARK_Aktivitas"].ToString(),
                                tglpt = sdr["nama"].ToString(),
                                jabatan = sdr["jabatan"].ToString(),
                                subdit = sdr["subdit"].ToString(),
                                nv = sdr["AV_Perusahaan"].ToString(),
                                naa = sdr["ARK_NoA"].ToString(),
                                tgl = sdr["AJ_Tgl"].ToString(),
                                tglds = sdr["AJ_TglDS"].ToString(),

                            });
                        }
                        con.Close();
                        return mydata;
                    }
                }
            }
        }

        [WebMethod]
        public static List<inisial> GetTotal(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT * From AdminJustifikasi WHERE AJ_ID = '{videoid}'"))
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
                                keterangan = sdr["AJ_NK"].ToString(),
                                total = sdr["AJ_Nilai"].ToString(),
                            });
                        }
                        con.Close();
                        return mydata;
                    }
                }
            }
        }
    }
}