using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.asset
{
    public partial class search : System.Web.UI.Page
    {
        string cari;
        int a = 0;
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                inputsearch.Value = Session["cari"].ToString();
                fillGridView1();
                gvContact.Columns[0].Visible = false;
                gvContact.Columns[3].Visible = false;
                gvContact.Columns[5].Visible = false;
                gvContact.Columns[8].Visible = false;
                gvContact.Columns[9].Visible = false;
                gvContact.Columns[10].Visible = false;
                gvContact.Columns[11].Visible = false;
                fillGridView2();



            }

            fillGridView1();
            fillGridView2();
            gvContact.Columns[0].Visible = false;
            gvContact.Columns[3].Visible = false;
            gvContact.Columns[5].Visible = false;
            gvContact.Columns[8].Visible = false;
            gvContact.Columns[9].Visible = false;
            gvContact.Columns[10].Visible = false;
            gvContact.Columns[11].Visible = false;

        }

        void fillGridView1()
        {

            sqlCon2.Open();

            
            /*if (a==0)
                cari = Session["cari"] as string;           
            else if(a==5)
                cari = inputsearch.Value;*/
            if (inputsearch.Value == "telkom2" || inputsearch.Value == "telkom 2")
            {
                SqlCommand sqlcmd = new SqlCommand("Telkom2", sqlCon2);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Sort", urutkan.Value);
                using (SqlDataAdapter da = new SqlDataAdapter(sqlcmd))
                {
                    da.SelectCommand = sqlcmd;
                    using (DataTable ds = new DataTable())
                    {
                        //SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                        da.Fill(ds);
                        gvContact.DataSource = ds;
                        gvContact.DataBind();

                        //gvContact.DataSource = sqlcmd.ExecuteReader();
                        //gvContact.DataBind();
                        sqlCon2.Close();
                    }

                }
            }
            else if (inputsearch.Value == "telkom3s" || inputsearch.Value == "telkom 3s")
            {
                SqlCommand sqlcmd = new SqlCommand("Telkom3S", sqlCon2);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Sort", urutkan.Value);
                using (SqlDataAdapter da = new SqlDataAdapter(sqlcmd))
                {
                    da.SelectCommand = sqlcmd;
                    using (DataTable ds = new DataTable())
                    {
                        //SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                        da.Fill(ds);
                        gvContact.DataSource = ds;
                        gvContact.DataBind();

                        //gvContact.DataSource = sqlcmd.ExecuteReader();
                        //gvContact.DataBind();
                        sqlCon2.Close();
                    }

                }
            }
            else if (inputsearch.Value == "telkom4" || inputsearch.Value == "telkom 4" || inputsearch.Value == "mpsat" || inputsearch.Value == "mp sat")
            {
                SqlCommand sqlcmd = new SqlCommand("MPSAT", sqlCon2);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Sort", urutkan.Value);
                using (SqlDataAdapter da = new SqlDataAdapter(sqlcmd))
                {
                    da.SelectCommand = sqlcmd;
                    using (DataTable ds = new DataTable())
                    {
                        //SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                        da.Fill(ds);
                        gvContact.DataSource = ds;
                        gvContact.DataBind();

                        //gvContact.DataSource = sqlcmd.ExecuteReader();
                        //gvContact.DataBind();
                        sqlCon2.Close();
                    }

                }
            }
            else
            {
                SqlCommand sqlcmd = new SqlCommand("AsFilterAllSort", sqlCon2);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@FilterAll", inputsearch.Value);
                sqlcmd.Parameters.AddWithValue("@Sort", urutkan.Value);
                using (SqlDataAdapter da = new SqlDataAdapter(sqlcmd))
                {
                    da.SelectCommand = sqlcmd;
                    using (DataTable ds = new DataTable())
                    {
                        //SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                        da.Fill(ds);
                        gvContact.DataSource = ds;
                        gvContact.DataBind();

                        //gvContact.DataSource = sqlcmd.ExecuteReader();
                        //gvContact.DataBind();
                        sqlCon2.Close();
                    }

                }
            }
        }


        void fillGridView2()
        {
            
            sqlCon2.Open();

            /*if (inputsearch.Value == "")
            {
                    inputsearch.Value= Session["cari"] as string;

            }

            else
            {
                inputsearch.Value= inputsearch.Value;
            }*/





            if (inputsearch.Value== "telkom2" || inputsearch.Value== "telkom 2")
            {
                string querytk2 = "SELECT Count(*) FROM Asset1 WHERE TELKOM2 = 'V'";
                SqlCommand countcmd = new SqlCommand(querytk2, sqlCon2);
                int valuecount = (int)countcmd.ExecuteScalar();
                sqlCon2.Close();
                lblCount.Text = "Terdapat " + valuecount.ToString() + " hasil untuk " + '"' + inputsearch.Value + '"';
            }
            else if (inputsearch.Value== "telkom3s" || inputsearch.Value== "telkom 3s")
            {
                string querytk2 = "SELECT Count(*) FROM Asset1 WHERE TELKOM3S = 'V'";
                SqlCommand countcmd = new SqlCommand(querytk2, sqlCon2);
                int valuecount = (int)countcmd.ExecuteScalar();
                sqlCon2.Close();
                lblCount.Text = "Terdapat " + valuecount.ToString() + " hasil untuk " + '"' + inputsearch.Value + '"';
            }
            else if (inputsearch.Value== "telkom4" || inputsearch.Value== "telkom 4" || inputsearch.Value== "mpsat" || inputsearch.Value== "mp sat")
            {
                string querytk2 = "SELECT Count(*) FROM Asset1 WHERE MPSAT = 'V'";
                SqlCommand countcmd = new SqlCommand(querytk2, sqlCon2);
                int valuecount = (int)countcmd.ExecuteScalar();
                sqlCon2.Close();
                lblCount.Text = "Terdapat " + valuecount.ToString() + " hasil untuk " + '"' + inputsearch.Value + '"';
            }

            else
            {
                SqlCommand countcmd = new SqlCommand("AsCountSearch", sqlCon2);
                countcmd.CommandType = CommandType.StoredProcedure;
                countcmd.Parameters.AddWithValue("@CountAll", inputsearch.Value);
                int valuecount = (int)countcmd.ExecuteScalar();
                sqlCon2.Close();
                lblCount.Text = "Terdapat " + valuecount.ToString() + " hasil untuk " + '"' + inputsearch.Value + '"';
                //lblHasil.Text = "hasil";
                if (gvContact.Rows.Count == 0)
                {
                    //lblHead.Text = "Hasil Pencarian Tidak Ditemukan";
                    lblCount.Visible = false;
                    btnExpand.Visible = false;
                    urutkan.Visible = false;
                    lblPage.Visible = false;
                }
                else
                {
                    //lblHead.Text = "Database Hasil Pencarian";
                    lblCount.Visible = true;
                    btnExpand.Visible = true;
                    urutkan.Visible = true;
                    lblPage.Visible = true;
                }
            }
        }

        

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvContact.PageIndex = e.NewPageIndex;
            gvContact.DataBind();
        }

        protected void gvContact_PreRender(object sender, EventArgs e)
        {
            lblPage.Text = "Menampilkan halaman " + (gvContact.PageIndex + 1).ToString() + " dari " + gvContact.PageCount.ToString();
        }

        protected void Ink_OnClick1(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("AsViewByID", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            Session["hf"] = hfContactID.Value;
            //Response.Redirect("~/details.aspx?equ=" + dtbl.Rows[0]["Equipment"].ToString() + "merk=" + dtbl.Rows[0]["Merk"].ToString());
            Session["kelompok"] = dtbl.Rows[0]["Kelompok"].ToString();
            Session["nama"] = dtbl.Rows[0]["Nama"].ToString();
            Session["merk"] = dtbl.Rows[0]["Merk"].ToString();
            Session["model"] = dtbl.Rows[0]["Model"].ToString();
            Session["sn"] = dtbl.Rows[0]["S/N"].ToString();
            Session["pn"] = dtbl.Rows[0]["P/N"].ToString();
            Session["Site"] = dtbl.Rows[0]["Site"].ToString();
            Session["tahun"] = dtbl.Rows[0]["Tahun"].ToString();
            Session["gudang"] = dtbl.Rows[0]["Gudang"].ToString();
            Session["rak"] = dtbl.Rows[0]["Rak"].ToString();
            Session["telkom2"] = dtbl.Rows[0]["Telkom2"].ToString();
            Session["telkom3S"] = dtbl.Rows[0]["Telkom3S"].ToString();
            Session["mpsat"] = dtbl.Rows[0]["Mpsat"].ToString();
            Session["fungsi"] = dtbl.Rows[0]["Fungsi"].ToString();
            Session["status"] = dtbl.Rows[0]["Status"].ToString();
            Session["keterangan"] = dtbl.Rows[0]["Keterangan"].ToString();
            Session["Waktu"] = dtbl.Rows[0]["Waktu"].ToString();
            Session["PIC"] = dtbl.Rows[0]["PIC"].ToString();
            //Response.Redirect("~/details.aspx?" + dtbl.Rows[0]["Merk"].ToString());
            Response.Redirect("~/asset/details.aspx");
        }

        protected void Expand_OnClick(object sender, EventArgs e)
        {
            if (btnExpand.Text == "Expand")
            {
                gvContact.Columns[0].Visible = true;
                gvContact.Columns[3].Visible = true;
                gvContact.Columns[5].Visible = true;
                gvContact.Columns[8].Visible = true;
                gvContact.Columns[9].Visible = true;
                gvContact.Columns[10].Visible = true;
                gvContact.Columns[11].Visible = true;
                btnExpand.Text = "Reduce";
                fillGridView1();
            }
            else
            {
                gvContact.Columns[0].Visible = false;
                gvContact.Columns[3].Visible = false;
                gvContact.Columns[5].Visible = false;
                gvContact.Columns[8].Visible = false;
                gvContact.Columns[9].Visible = false;
                gvContact.Columns[10].Visible = false;
                gvContact.Columns[11].Visible = false;
                btnExpand.Text = "Expand";
            }

        }
        protected void btnurut_click(object sender, EventArgs e)
        {
            fillGridView1();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}