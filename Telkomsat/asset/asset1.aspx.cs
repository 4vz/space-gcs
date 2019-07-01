using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Telkomsat.asset
{
    public partial class asset1 : System.Web.UI.Page
    {
        string user;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");


            user = Session["username"].ToString();
            if (!IsPostBack)
            {
                sqlCon.Open();
                SqlDataAdapter sqlCmd = new SqlDataAdapter("ProViewByUser", sqlCon);
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd.SelectCommand.Parameters.AddWithValue("@user", user);
                DataTable dtbl1 = new DataTable();
                sqlCmd.Fill(dtbl1);
                dtContact1.DataSource = dtbl1;
                dtContact1.DataBind();
                //DataList2.DataSource = dtbl1;
                //DataList2.DataBind();
                sqlCon.Close();

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
            sqlCon.Open();
            SqlDataAdapter sqlCmd2 = new SqlDataAdapter("ProViewByUser", sqlCon);
            sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd2.SelectCommand.Parameters.AddWithValue("@user", user);
            DataTable dtbl = new DataTable();
            sqlCmd2.Fill(dtbl);
            dtContact1.DataSource = dtbl;
            DataList1.DataSource = dtbl;
            DataList1.DataBind();
            sqlCon.Close();
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");


            lblProfile.Text = Session["username"].ToString();
            lblProfile1.Text = Session["username"].ToString();

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

        void fillGridView2()
        {
            
            sqlCon.Open();

            /*if (inputsearch.Value == "")
            {
                    inputsearch.Value= Session["cari"] as string;

            }

            else
            {
                inputsearch.Value= inputsearch.Value;
            }*/





            if (inputsearch.Value == "telkom2" || inputsearch.Value == "telkom 2")
            {
                string querytk2 = "SELECT Count(*) FROM Asset1 WHERE TELKOM2 = 'V'";
                SqlCommand countcmd = new SqlCommand(querytk2, sqlCon);
                int valuecount = (int)countcmd.ExecuteScalar();
                lblCount.Text = "Terdapat " + valuecount.ToString() + " hasil untuk " + '"' + inputsearch.Value + '"';
                sqlCon.Close();
            }
            else if (inputsearch.Value == "telkom3s" || inputsearch.Value == "telkom 3s")
            {
                string querytk2 = "SELECT Count(*) FROM Asset1 WHERE TELKOM3S = 'V'";
                SqlCommand countcmd = new SqlCommand(querytk2, sqlCon);
                int valuecount = (int)countcmd.ExecuteScalar();
                lblCount.Text = "Terdapat " + valuecount.ToString() + " hasil untuk " + '"' + inputsearch.Value + '"';
                sqlCon.Close();
            }
            else if (inputsearch.Value == "telkom4" || inputsearch.Value == "telkom 4" || inputsearch.Value == "mpsat" || inputsearch.Value == "mp sat")
            {
                string querytk2 = "SELECT Count(*) FROM Asset1 WHERE MPSAT = 'V'";
                SqlCommand countcmd = new SqlCommand(querytk2, sqlCon);
                int valuecount = (int)countcmd.ExecuteScalar();
                lblCount.Text = "Terdapat " + valuecount.ToString() + " hasil untuk " + '"' + inputsearch.Value + '"';
                sqlCon.Close();
            }

            else
            {
                SqlCommand countcmd = new SqlCommand("AsCountSearch", sqlCon);
                countcmd.CommandType = CommandType.StoredProcedure;
                countcmd.Parameters.AddWithValue("@CountAll", inputsearch.Value);
                
                int valuecount = (int)countcmd.ExecuteScalar();
                sqlCon.Close();
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

                }
            }
        }

        void fillGridView1()
        {

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            /*if (inputsearch.Value == "")
            {

                    inputsearch.Value= Session["cari"] as string;
            }
            else if (inputsearch.Value != null)
            {
                inputsearch.Value= inputsearch.Value;
            }
            /*if (a==0)
                inputsearch.Value= Session["cari"] as string;           
            else if(a==5)
                inputsearch.Value= inputsearch.Value;*/
            if (inputsearch.Value == "telkom2" || inputsearch.Value == "telkom 2")
            {
                SqlCommand sqlcmd = new SqlCommand("Telkom2", sqlCon);
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
                        sqlCon.Close();
                    }

                }
            }
            else if (inputsearch.Value == "telkom3s" || inputsearch.Value == "telkom 3s")
            {
                SqlCommand sqlcmd = new SqlCommand("Telkom3S", sqlCon);
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
                        sqlCon.Close();
                    }

                }
            }
            else if (inputsearch.Value == "telkom4" || inputsearch.Value == "telkom 4" || inputsearch.Value == "mpsat" || inputsearch.Value == "mp sat")
            {
                SqlCommand sqlcmd = new SqlCommand("MPSAT", sqlCon);
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
                        sqlCon.Close();
                    }

                }
            }
            else
            {
                SqlCommand sqlcmd = new SqlCommand("AsFilterAllSort", sqlCon);
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
                        sqlCon.Close();
                    }

                }
                Response.Write(inputsearch.Value);
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
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("AsViewByID", sqlCon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon.Close();
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