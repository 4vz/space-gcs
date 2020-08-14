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
    public partial class pemindahan : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        SqlDataAdapter da, da1, dat;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        string querydata, query;

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
                    Response.Redirect("dashboard.aspx");
            }

            string querylast = @"select bra_harkat, bra_me, rek_harkat1, rek_harkat2, rek_me1, rek_me2
                                from administrator where id_admin = (select max(id_admin) from administrator)";
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

            datainput();
            /*if (ddlKategori1.Text == "Rek. ME Bendahara 1")
            {
                int a = rek2harkat - pemindahan;
                if (ddlkategori2.Text == "Rek. Harkat Bendahara 1")
                    query = $@"INSERT INTO administrator (keterangan, tanggal, pemasukan, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat + pemindahan}, {rek2harkat}, {a}, {rek2me}, {braharkat}, {brame})";
                else if (ddlkategori2.Text == "Rek. ME Bendahara 1")
                    query = $@"INSERT INTO administrator (keterangan, tanggal, pemasukan, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat + pemindahan}, {a}, {rek2me}, {braharkat}, {brame})";
                else if (ddlkategori2.Text == "Rek. ME Bendahara 2")
                    query = $@"INSERT INTO administrator (keterangan, tanggal, pemasukan, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {a}, {rek2me + pemindahan}, {braharkat}, {brame})";
                else if (ddlkategori2.Text == "Brankas Harkat")
                    query = $@"INSERT INTO administrator (keterangan, tanggal, pemasukan, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {a}, {rek2me}, {braharkat + pemindahan}, {brame})";
                else if (ddlkategori2.Text == "Brankas ME")
                    query = $@"INSERT INTO administrator (keterangan, tanggal, pemasukan, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me)
                                VALUES ('{keterangan.Value}', '{datetime}', '{parse}', {rek1harkat}, {rek2harkat}, {a}, {rek2me}, {braharkat}, {brame + pemindahan})";
            }*/


        }


        protected void Save_ServerClick(object sender, EventArgs e)
        {
            string parse = nominal.Value.Replace(".", "");
            int pemindahan = Convert.ToInt32(parse);

            var datetime = DateTime.Now.ToString("yyyy/MM/dd");

            if (ddlKategori1.Text == "Rek. Harkat Bendahara 1")
            {
                rek1harkat = rek1harkat - pemindahan;
                if (ddlkategori2.Text == "Rek. Harkat Bendahara 2")
                    rek2harkat = rek2harkat + pemindahan;
                else if (ddlkategori2.Text == "Rek. ME Bendahara 1")
                    rek1me = rek1me + pemindahan;
                else if (ddlkategori2.Text == "Rek. ME Bendahara 2")
                    rek2me = rek2me + pemindahan;
                else if (ddlkategori2.Text == "Brankas Harkat")
                    braharkat = braharkat + pemindahan;
                else if (ddlkategori2.Text == "Brankas ME")
                    brame = brame + pemindahan;
            }

            else if (ddlKategori1.Text == "Rek. Harkat Bendahara 2")
            {
                rek2harkat = rek2harkat - pemindahan;
                if (ddlkategori2.Text == "Rek. Harkat Bendahara 1")
                    rek1harkat = rek1harkat + pemindahan;
                else if (ddlkategori2.Text == "Rek. ME Bendahara 1")
                    rek1me = rek1me + pemindahan;
                else if (ddlkategori2.Text == "Rek. ME Bendahara 2")
                    rek2me = rek2me + pemindahan;
                else if (ddlkategori2.Text == "Brankas Harkat")
                    braharkat = braharkat + pemindahan;
                else if (ddlkategori2.Text == "Brankas ME")
                    brame = brame + pemindahan;
            }

            else if (ddlKategori1.Text == "Rek. ME Bendahara 1")
            {
                rek1me = rek1me - pemindahan;
                if (ddlkategori2.Text == "Rek. Harkat Bendahara 1")
                    rek1harkat = rek1harkat + pemindahan;
                else if (ddlkategori2.Text == "Rek. Harkat Bendahara 2")
                    rek2harkat = rek2harkat + pemindahan;
                else if (ddlkategori2.Text == "Rek. ME Bendahara 2")
                    rek2me = rek2me + pemindahan;
                else if (ddlkategori2.Text == "Brankas Harkat")
                    braharkat = braharkat + pemindahan;
                else if (ddlkategori2.Text == "Brankas ME")
                    brame = brame + pemindahan;
            }
            else if (ddlKategori1.Text == "Rek. ME Bendahara 2")
            {
                rek2me = rek2me - pemindahan;
                if (ddlkategori2.Text == "Rek. Harkat Bendahara 1")
                    rek1harkat = rek1harkat + pemindahan;
                else if (ddlkategori2.Text == "Rek. Harkat Bendahara 2")
                    rek2harkat = rek2harkat + pemindahan;
                else if (ddlkategori2.Text == "Rek. ME Bendahara 1")
                    rek1me = rek1me + pemindahan;
                else if (ddlkategori2.Text == "Brankas Harkat")
                    braharkat = braharkat + pemindahan;
                else if (ddlkategori2.Text == "Brankas ME")
                    brame = brame + pemindahan;
            }

            else if (ddlKategori1.Text == "Brankas Harkat")
            {
                braharkat = braharkat - pemindahan;
                if (ddlkategori2.Text == "Rek. Harkat Bendahara 1")
                    rek1harkat = rek1harkat + pemindahan;
                else if (ddlkategori2.Text == "Rek. Harkat Bendahara 2")
                    rek2harkat = rek2harkat + pemindahan;
                else if (ddlkategori2.Text == "Rek. ME Bendahara 1")
                    rek1me = rek1me + pemindahan;
                else if (ddlkategori2.Text == "Rek. ME Bendahara 2")
                    rek2me = rek2me + pemindahan;
                else if (ddlkategori2.Text == "Brankas ME")
                    brame = brame + pemindahan;
            }

            else if (ddlKategori1.Text == "Brankas ME")
            {
                brame = brame - pemindahan;
                if (ddlkategori2.Text == "Rek. Harkat Bendahara 1")
                    rek1harkat = rek1harkat + pemindahan;
                else if (ddlkategori2.Text == "Rek. Harkat Bendahara 2")
                    rek2harkat = rek2harkat + pemindahan;
                else if (ddlkategori2.Text == "Rek. ME Bendahara 1")
                    rek1me = rek1me + pemindahan;
                else if (ddlkategori2.Text == "Rek. ME Bendahara 2")
                    rek2me = rek2me + pemindahan;
                else if (ddlkategori2.Text == "Brankas Harkat")
                    braharkat = braharkat + pemindahan;
            }

            Response.Write(rek1harkat + " " + rek2harkat + " " + rek1me + " " + rek2me + " " + braharkat + " " + brame);
            query = $@"INSERT INTO administrator (keterangan, tanggal, rek_harkat1, rek_harkat2, rek_me1, rek_me2, bra_harkat, bra_me, kategori, input)
                                VALUES ('{keterangan.Value}', '{datetime}', {rek1harkat}, {rek2harkat}, {rek1me}, {rek2me}, {braharkat}, {brame}, 'pemindahan', {pemindahan})";
            con.Open();
            SqlCommand sqlcmd = new SqlCommand(query, con);
            sqlcmd.ExecuteNonQuery();
            con.Close();
            lblstatus.Visible = true;
            lblstatus.Text = "  Berhasil Menyimpan";
            lblstatus.ForeColor = System.Drawing.Color.GreenYellow;
        }

        void datainput()
        {
            var datetime = DateTime.Now.ToString("yyyy/MM/dd");
            querydata = $@"SELECT input, keterangan, status FROM administrator where tanggal = '{datetime}' and kategori = 'pemindahan' ORDER BY id_admin desc";
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