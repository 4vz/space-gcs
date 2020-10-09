using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.admin
{
    public partial class editpengeluaran : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        SqlDataAdapter da, da1, dat;
        DataSet ds = new DataSet();
        string queryinsert, status, querydata, query, querydetail, dataid;
        int rek1harkat, rek2harkat, rek1me, rek2me, braharkat, brame, input;
        string parse, now;
        int a, b, c;
        string[] myket, mynominal, mylast;
        string filename = "", filepath = "";
        double ventotal;
        protected void Page_Load(object sender, EventArgs e)
        {
            string query, user, myquery;

            if (Request.QueryString["id"] != null)
                dataid = Request.QueryString["id"];

            user = Session["iduser"].ToString();

            query = $"Select * from AdminProfile where AP_Nama = '{user}'";
            DataSet ds2 = Settings.LoadDataSet(query);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (!ds2.Tables[0].Rows[0]["AP_Previllage"].ToString().ToLower().IsIn((new string[] { "admin bendahara", "user", "sa" })))
                    Response.Redirect("listpengeluaran.aspx");
            }

            myquery = $@"SELECT p.AP_ID, j.AJ_ID, j.AJ_Ket, j.AJ_NK, v.AV_Perusahaan, v.AV_ID, r.* FROM administrator r full join AdminVendor v on v.AV_ID=r.id_av
                        full join AdminJustifikasi j on j.AJ_ID=r.id_aj join AdminProfile p on
                        p.AP_ID=r.id_profile join Profile e on e.id_profile=p.AP_Nama where id_admin = {dataid}";

            DataSet ds4 = Settings.LoadDataSet(myquery);

            if (!IsPostBack)
            {
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    if (ds4.Tables[0].Rows[0]["AJ_ID"].ToString() == null || ds4.Tables[0].Rows[0]["AJ_ID"].ToString() == "")
                    {
                        DropDownList2.Text = "Lain-lain";
                    }
                    else
                    {
                        userjustifikasi.Style.Add("display", "block");
                        DropDownList2.Text = "Justifikasi";
                    }

                    if (ds4.Tables[0].Rows[0]["AV_Perusahaan"].ToString() == null || ds4.Tables[0].Rows[0]["AV_Perusahaan"].ToString() == "")
                    {
                        DropDownList1.Text = "Lain-lain";
                    }
                    else
                    {
                        uservendor.Style.Add("display", "block");
                        DropDownList1.Text = "Vendor";
                    }

                    ddlKategori.SelectedValue = ds4.Tables[0].Rows[0]["simpanan"].ToString();
                    txtpetugas.Text = ds4.Tables[0].Rows[0]["AP_ID"].ToString();
                    txtvendor.Text = ds4.Tables[0].Rows[0]["AV_ID"].ToString();
                    txtjustifikasi.Text = ds4.Tables[0].Rows[0]["AJ_ID"].ToString();
                    keterangan.Value = ds4.Tables[0].Rows[0]["keterangan"].ToString();
                    nominal.Value = ds4.Tables[0].Rows[0]["input"].ToString();
                }

            }


            datainput();
        }

        protected void Draft_ServerClick(object sender, EventArgs e)
        {
            string idprofile;
            idprofile = txtpetugas.Text;
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
            if (ds.Tables[0].Rows.Count > 0)
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


            status = "done";

            filename = "";
            filepath = "";

            queryinsert = $@"update administrator set tanggal = '{datetime}', input='{parse}', rek_harkat1='{rek1harkat}', rek_harkat2='{rek2harkat}', rek_me1='{rek1me}', keterangan='{keterangan.Value}',
                            rek_me2='{rek2me}', simpanan='{ddlKategori.SelectedValue}', id_aj='{txtjustifikasi.Text}', id_profile='{idprofile}', id_av='{txtvendor.Text}' where id_admin='{dataid}'";

            
            con.Open();
            SqlCommand sqlCmd = new SqlCommand(queryinsert, con);
            int i = Convert.ToInt32(sqlCmd.ExecuteScalar());
            con.Close();


            divsuccess.Visible = true;
            Response.Redirect("listpengeluaran.aspx?tipe=draft");
        }



        protected void Save_ServerClick(object sender, EventArgs e)
        {
            string idprofile;
            idprofile = txtpetugas.Text;
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
            if (ds.Tables[0].Rows.Count > 0)
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



            /*if (ddljenis.Text == "Panjar")
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
            }*/

            status = "done";
            /*if (FileUpload1.HasFiles)
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
            }*/
            filename = "";
            filepath = "";

            if (ddlKategori.Text == "Rek. Harkat Bendahara 1")
            {
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori, id_aj, approve, id_profile)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. Harkat 1', 'pengeluaran', '{txtjustifikasi.Text}', 'diajukan', '{idprofile}') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Rek. Harkat Bendahara 2")
            {
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori, id_aj, approve, id_profile)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. Harkat 2', 'pengeluaran', '{txtjustifikasi.Text}', 'diajukan', '{idprofile}') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Rek. ME Bendahara 1")
            {
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori, id_aj, approve, id_profile)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. ME 1', 'pengeluaran', '{txtjustifikasi.Text}', 'diajukan', '{idprofile}') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Rek. ME Bendahara 2")
            {
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori, id_aj, approve, id_profile)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Rek. ME 2', 'pengeluaran', '{txtjustifikasi.Text}', 'diajukan', '{idprofile}') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Brankas Harkat")
            {
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori, id_aj, approve, id_profile)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Brankas Harkat', 'pengeluaran', '{txtjustifikasi.Text}', 'diajukan', '{idprofile}') Select Scope_Identity()";
            }
            else if (ddlKategori.Text == "Brankas ME")
            {
                queryinsert = $@"INSERT INTO administrator (id_av, keterangan, tanggal, input, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, status, evidence, evidencepath,  simpanan, kategori, id_aj, approve, id_profile)
                                VALUES ('{txtvendor.Text}', '{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, '{status}', '{filename}', '{filepath}', 'Brankas ME', 'pengeluaran', '{txtjustifikasi.Text}', 'diajukan', '{idprofile}') Select Scope_Identity()";
            }

            con.Open();
            SqlCommand sqlCmd = new SqlCommand(queryinsert, con);
            int i = Convert.ToInt32(sqlCmd.ExecuteScalar());
            con.Close();



            /*if (ddljenis.Text == "Panjar")
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
            divsuccess.Visible = true;
            Response.Redirect("listpengeluaran.aspx?tipe=draft");
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