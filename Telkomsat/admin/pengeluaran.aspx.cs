using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Telkomsat.admin
{
    public partial class pengeluaran : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        SqlDataAdapter da, da1, dat;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        string queryinsert, status, querydata, query, querydetail;
        int rek1harkat, rek2harkat, rek1me, rek2me, braharkat, brame, input;
        string parse, now;
        string filename = "", filepath = "", filename1 ="", filepath1="", filename2="", filepath2="", filename3="", filepath3="", filename4="", filepath4="", filename5="", filepath5="", filename6="", filepath6="", filename7="", filepath7="";
        int nominal1 = 0, nominal2 = 0, nominal3 = 0, nominal4 = 0, nominal5 = 0, nominal6 = 0, nominal7 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            datainput();
        }

        protected void Save_ServerClick(object sender, EventArgs e)
        {
            var datetime = DateTime.Now.ToString("yyyy/MM/dd");
            string querylast = "select * from administrator where id_admin = (select max(id_admin) from administrator)";
            SqlCommand sqlCmd1 = new SqlCommand(querylast, con);
            da1 = new SqlDataAdapter(sqlCmd1);
            da1.Fill(ds);
            con.Open();
            sqlCmd1.ExecuteNonQuery();
            con.Close();
            braharkat = Convert.ToInt32(ds.Tables[0].Rows[0]["bra_harkat"].ToString());
            brame = Convert.ToInt32(ds.Tables[0].Rows[0]["bra_me"].ToString());
            rek1harkat = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_harkat1"].ToString());
            rek2harkat = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_harkat2"].ToString());
            rek1me = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_me1"].ToString());
            rek2me = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_me2"].ToString());
            
            if(nominal.Value != "")
            {
                parse = nominal.Value.Replace(".", "");
                input = Convert.ToInt32(parse);
            }
            

            if (ddljenis.Text == "Panjar") { 
                status = "incomplete";
                filename = "";
                filepath = "";
            }
                
            else if (ddljenis.Text == "Cash")
            {
                status = "done";
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
            }

            

            if (ddlKategori.Text == "Rek. Harkat Bendahara 1")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat - input}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. Harkat 1', 'pengeluaran') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Rek. Harkat Bendahara 2")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat - input}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. Harkat 2', 'pengeluaran') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Rek. ME Bendahara 1")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me - input}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. ME 1', 'pengeluaran') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Rek. ME Bendahara 2")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me - input}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. ME 2', 'pengeluaran') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Brankas Harkat")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat - input}, {brame}, '{status}', '{filename}', '{filepath}', 'Brankas Harkat', 'pengeluaran'); Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Brankas ME")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame - input}, '{status}', '{filename}', '{filepath}', 'Brankas ME', 'pengeluaran'); Select Scope_Identity()";
            }
            
            con.Open();
            SqlCommand sqlCmd = new SqlCommand(queryinsert, con);
            int i = Convert.ToInt32(sqlCmd.ExecuteScalar());
            con.Close();

            if (ddljenis.Text == "Panjar")
            {

                query = $@"INSERT INTO adminuser (id_profile, id_admin)
                                VALUES ('{ddluser.SelectedValue}', {i})";
                con.Open();
                SqlCommand cmd1 = new SqlCommand(query, con);
                cmd1.ExecuteNonQuery();
                con.Close();
            }

            if (ddldetail.SelectedValue == "Manual")
            {
                if (FileUpload2.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload2.PostedFiles)
                    {
                        filecount += 1;
                        filename1 = Path.GetFileName(file.FileName);
                        filepath1 = "~/evidence/" + filename1;
                        file.SaveAs(physicalpath + filename1);
                    }
                }
                if (FileUpload3.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload3.PostedFiles)
                    {
                        filecount += 1;
                        filename2 = Path.GetFileName(file.FileName);
                        filepath2 = "~/evidence/" + filename2;
                        file.SaveAs(physicalpath + filename2);
                    }
                }
                if (FileUpload4.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload4.PostedFiles)
                    {
                        filecount += 1;
                        filename3 = Path.GetFileName(file.FileName);
                        filepath3 = "~/evidence/" + filename3;
                        file.SaveAs(physicalpath + filename3);
                    }
                }
                if (FileUpload5.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload5.PostedFiles)
                    {
                        filecount += 1;
                        filename4 = Path.GetFileName(file.FileName);
                        filepath4 = "~/evidence/" + filename4;
                        file.SaveAs(physicalpath + filename4);
                    }
                }
                if (FileUpload6.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload6.PostedFiles)
                    {
                        filecount += 1;
                        filename5 = Path.GetFileName(file.FileName);
                        filepath5 = "~/evidence/" + filename5;
                        file.SaveAs(physicalpath + filename5);
                    }
                }
                if (FileUpload7.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload7.PostedFiles)
                    {
                        filecount += 1;
                        filename6 = Path.GetFileName(file.FileName);
                        filepath6 = "~/evidence/" + filename6;
                        file.SaveAs(physicalpath + filename6);
                    }
                }
                
                if(txtnominal1.Text !="")
                    nominal1 = Convert.ToInt32(txtnominal1.Text.Replace(".", ""));
                if (txtnominal2.Text != "")
                    nominal2 = Convert.ToInt32(txtnominal2.Text.Replace(".", ""));
                if (txtnominal3.Text != "")
                    nominal3 = Convert.ToInt32(txtnominal3.Text.Replace(".", ""));
                if (txtnominal4.Text != "")
                    nominal4 = Convert.ToInt32(txtnominal4.Text.Replace(".", ""));
                if (txtnominal5.Text != "")
                    nominal5 = Convert.ToInt32(txtnominal5.Text.Replace(".", ""));
                if (txtnominal6.Text != "")
                    nominal6 = Convert.ToInt32(txtnominal6.Text.Replace(".", ""));
                if (txtnominal7.Text != "")
                    nominal7 = Convert.ToInt32(txtnominal7.Text.Replace(".", ""));

                querydetail = $@"INSERT INTO admindetail ('{datetime}', id_admin, d_keterangan, d_nominal, d_file , d_filepath) VALUES
                                ('{datetime}', {i}, '{txtketerangan1.Text}', {nominal1}, '{filename1}', '{filepath1}'),
                                ('{datetime}', {i}, '{txtketerangan2.Text}', {nominal2}, '{filename2}', '{filepath2}'),
                                ('{datetime}', {i}, '{txtketerangan3.Text}', {nominal3}, '{filename3}', '{filepath3}'),
                                ('{datetime}', {i}, '{txtketerangan4.Text}', {nominal4}, '{filename4}', '{filepath4}'),
                                ('{datetime}', {i}, '{txtketerangan5.Text}', {nominal5}, '{filename5}', '{filepath5}'),
                                ('{datetime}', {i}, '{txtketerangan6.Text}', {nominal6}, '{filename6}', '{filepath6}'),
                                ('{datetime}', {i}, '{txtketerangan7.Text}', {nominal7}, '{filename7}', '{filepath7}')";

                con.Open();
                SqlCommand cmd3 = new SqlCommand(querydetail, con);
                cmd3.ExecuteNonQuery();
                con.Close();
            }

            datainput();
            lblstatus.Visible = true;
            lblstatus.Text = "  Berhasil Menyimpan";
            lblstatus.ForeColor = System.Drawing.Color.GreenYellow;
        }

        void datainput()
        {
            var datetime = DateTime.Now.ToString("yyyy/MM/dd");
            querydata = $@"SELECT input, simpanan, status FROM administrator where tanggal = '{datetime}' and kategori = 'pengeluaran' ORDER BY id_admin desc";
            con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(querydata, con);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            con.Close();
            datalist1.DataSource = dtbl;
            datalist1.DataBind();
        }
    }
}