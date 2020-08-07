using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;

namespace Telkomsat.admin
{
    public partial class pengeluaran : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        SqlDataAdapter da, da1, dat;
        DataSet ds = new DataSet();
        string queryinsert, status, querydata, query, querydetail;
        int rek1harkat, rek2harkat, rek1me, rek2me, braharkat, brame, input;
        string parse, now;
        int a, b, c;
        string[] myket, mynominal, mylast;
        string filename = "", filepath = "";
        double ventotal;
        protected void Page_Load(object sender, EventArgs e)
        {
            datainput();
        }

        protected void Save_ServerClick(object sender, EventArgs e)
        {
            if (nominal.Value != "")
            {
                parse = nominal.Value.Replace(".", "");

                input = Convert.ToInt32(parse);

            }
            var datetime = DateTime.Now.ToString("yyyy/MM/dd");

            string queryven, queryid, sekarang;
            double totalvendor;

            queryid = $@"SELECT * from AdminVendorNom WHERE AVN_ID = (SELECT MAX(AVN_ID) from AdminVendorNom where AVN_AV='{txtvendor.Text}') and AVN_AV='{txtvendor.Text}'";

            sekarang = DateTime.Now.ToString("yyyy/MM/dd");

            DataSet dsid = Settings.LoadDataSet(queryid);

            if (dsid.Tables[0].Rows.Count == 0)
            {
                ventotal = 0;
            }
            else
            {
                ventotal = Convert.ToDouble(dsid.Tables[0].Rows[0]["AVN_Total"]);
            }


            totalvendor = ventotal + Convert.ToDouble(input);

            queryven = $@"INSERT INTO AdminVendorNom (AVN_AV, AVN_Nominal, AVN_Total, AVN_Tanggal, AVN_NK)
                            VALUES ('{txtvendor.Text}', '{input}', '{totalvendor}', '{datetime}', '{keterangan.Value}')";

            con.Open();
            SqlCommand sqlCmdven = new SqlCommand(queryven, con);
            sqlCmdven.ExecuteNonQuery();
            con.Close();

            
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

            

            if (ddljenis.Text == "Panjar")
            {
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
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat - input}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. Harkat 1', 'pengeluaran') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Rek. Harkat Bendahara 2")
            {
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat - input}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. Harkat 2', 'pengeluaran') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Rek. ME Bendahara 1")
            {
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me - input}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. ME 1', 'pengeluaran') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Rek. ME Bendahara 2")
            {
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me - input}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. ME 2', 'pengeluaran') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Brankas Harkat")
            {
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat - input}, {brame}, '{status}', '{filename}', '{filepath}', 'Brankas Harkat', 'pengeluaran'); Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Brankas ME")
            {
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame - input}, '{status}', '{filename}', '{filepath}', 'Brankas ME', 'pengeluaran'); Select Scope_Identity()";
            }

            con.Open();
            SqlCommand sqlCmd = new SqlCommand(queryinsert, con);
            int i = Convert.ToInt32(sqlCmd.ExecuteScalar());
            con.Close();

            if (ddljenis.Text == "Panjar")
            {

                query = $@"INSERT INTO adminuser (id_profile, id_admin)
                                VALUES ('{txtpetugas.Text}', {i})";
                con.Open();
                SqlCommand cmd1 = new SqlCommand(query, con);
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            
            /*if (ddldetail.SelectedValue == "Manual")
            {
                int dataku = tableku.Rows.Count;
                string mydata;
                //Response.Write("bibi  " + Request.Form["mypanjar"] + "data : " + Request.Form["mydatapanjar"] + "File : " + fileinput.Value);
                //HttpPostedFile postedFile = Request.Files["fileinput"];
                //Response.Write("file " + postedFile.FileName);
                string keterangan = Request.Form["mypanjar"];
                string nominal = Request.Form["mydatapanjar"].Replace(".", "");
                mylast = new string[Request.Files.Count];
                myket = new string[Request.Files.Count];
                mynominal = new string[Request.Files.Count];
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
                for (int k = 0; k < Request.Files.Count; k++)
                {
                    HttpPostedFile file = Request.Files[k];

                    if (file != null && file.ContentLength > 0)
                    {
                        string filePath = Server.MapPath("~/evidence/") + Path.GetFileName(file.FileName);
                        //file.SaveAs(filePath);
                        mylast[k] = "('" + i + "','" + datetime + "','" + myket[k] + "', '" + mynominal[k] + "', '" + Path.GetFileName(file.FileName) + "', '" + filepath + "','" + "not approve" + "')";
                    }
                    else
                    {
                        mylast[k] = "('" + i + "','" + datetime + "','" + myket[k] + "', '" + mynominal[k] + "', '" + "', '" + "not approve" + "')";
                    }
                }
                mydata = string.Join(",", mylast);
                //Response.Write(mydata);
                string queryku = $"INSERT INTO admindetail (id_admin, d_tanggal, d_keterangan, d_nominal, d_file, d_filepath, d_approve) VALUES {mydata}";
                con.Open();
                SqlCommand sqlCmd7 = new SqlCommand(queryku, con);
                sqlCmd7.ExecuteNonQuery();
                con.Close();
                Response.Redirect("../admin/pengeluaran.aspx");
            }*/
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