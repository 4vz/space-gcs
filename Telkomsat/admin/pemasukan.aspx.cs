using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Telkomsat.admin
{
    public partial class pemasukan : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        SqlDataAdapter da, da1, dat;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        string queryinsert, querydata, filename, filepath;
        int rek1harkat, rek2harkat, rek1me, rek2me, braharkat, brame;
        protected void Page_Load(object sender, EventArgs e)
        {
            string query, user;

            user = Session["iduser"].ToString();
            query = $"Select * from AdminProfile where AP_Nama = '{user}'";
            DataSet ds2 = Settings.LoadDataSet(query);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0]["AP_Previllage"].ToString() != "Admin Bendahara")
                    Response.Redirect("listpemasukan.aspx");
            }

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

            if(ds.Tables[0].Rows.Count > 0)
            {
                braharkat = Convert.ToInt32(ds.Tables[0].Rows[0]["bra_harkat"].ToString());
                brame = Convert.ToInt32(ds.Tables[0].Rows[0]["bra_me"].ToString());
                rek1harkat = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_harkat1"].ToString());
                rek2harkat = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_harkat2"].ToString());
                rek1me = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_me1"].ToString());
                rek2me = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_me2"].ToString());
            }
            else
            {
                braharkat = 0;
                brame = 0;
                rek1harkat = 0;
                rek2harkat = 0;
                rek1me = 0;
                rek2me = 0;
            }
            

            string parse = nominal.Value.Replace(".", "");
            int input = Convert.ToInt32(parse);

            if (ddlKategori.Text == "Rek. Harkat Bendahara 1")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat + input}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. Harkat 1', 'pemasukan'); Select Scope_Identity();";  
            }
            else if (ddlKategori.Text == "Rek. Harkat Bendahara 2")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat + input}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. Harkat 2', 'pemasukan'); Select Scope_Identity();";
            }
            else if (ddlKategori.Text == "Rek. ME Bendahara 1")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me + input}, {rek2me}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. ME 1', 'pemasukan'); Select Scope_Identity();";
            }
            else if (ddlKategori.Text == "Rek. ME Bendahara 2")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me + input}, {braharkat}, {brame}, '{filename}', '{filepath}', 'Rek. ME 2', 'pemasukan'); Select Scope_Identity();";
            }
            else if (ddlKategori.Text == "Brankas Harkat")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat + input}, {brame}, '{filename}', '{filepath}', 'Brankas Harkat', 'pemasukan'); Select Scope_Identity();";
            }
            else if (ddlKategori.Text == "Brankas ME")
            {
                queryinsert = $@"INSERT INTO administrator (keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, evidence, evidencepath, simpanan, kategori)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame + input}, '{filename}', '{filepath}', 'Brankas ME', 'pemasukan'); Select Scope_Identity();";
            }

            con.Open();
            SqlCommand sqlCmd = new SqlCommand(queryinsert, con);
            int i = Convert.ToInt32(sqlCmd.ExecuteScalar());
            con.Close();

            if (FileUpload1.HasFiles)
            {
                string physicalpath = Server.MapPath("~/evidence/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);

                int filecount = 0;
                foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                {
                    filecount += 1;
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = "~/evidence/" + filename;
                    string extension = Path.GetExtension(file.FileName);
                    file.SaveAs(physicalpath + filename);
                    string s = Convert.ToString(i);
                    con.Open();
                    string queryfile = $@"INSERT INTO AdminEvidence (AE_AD, AE_NamaFile, AE_File, AE_Ekstension)
                                        VALUES ('{s}', '{filename}', '{filepath}', '{extension}')";
                    SqlCommand sqlCmd5 = new SqlCommand(queryfile, con);

                    sqlCmd5.ExecuteNonQuery();
                    con.Close();
                }
            }

            datainput();

            lblstatus.Visible = true;
            lblstatus.Text = "  Berhasil Menyimpan";
            lblstatus.ForeColor = System.Drawing.Color.GreenYellow;
        }

        void datainput()
        {
            var datetime = DateTime.Now.ToString("yyyy/MM/dd");
            querydata = $@"SELECT input, simpanan, status FROM administrator where tanggal = '{datetime}' and kategori = 'pemasukan' ORDER BY id_admin desc";
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