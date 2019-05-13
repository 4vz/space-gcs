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
    public partial class filter : System.Web.UI.Page
    {
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            string parse = link.Remove(0, 22);
            char[] array = parse.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                char let = array[i];
                if (let == '-')
                {
                    array[i] = ' ';
                }
            }
            string result = new string(array);
            if (!IsPostBack)
            {
                fillGridView1();
                gvContact.Columns[0].Visible = false;
                gvContact.Columns[3].Visible = false;
                gvContact.Columns[5].Visible = false;
                gvContact.Columns[8].Visible = false;
                gvContact.Columns[9].Visible = false;
                gvContact.Columns[10].Visible = false;
                gvContact.Columns[11].Visible = false;
                

            }
            sqlCon2.Open();
            if (result == "TELKOM 2")
            {
                string querytk2 = "SELECT Count(*) FROM Asset1 WHERE TELKOM2 = 'V'";
                SqlCommand countcmd = new SqlCommand(querytk2, sqlCon2);
                int value = (int)countcmd.ExecuteScalar();
                lblCount.Text = "Terdapat " + value.ToString() + " hasil ditemukan untuk "
                + '"' + result + '"';
            }
            else if (result == "TELKOM 3S")
            {
                string querytk2 = "SELECT Count(*) FROM Asset1 WHERE TELKOM3S = 'V'";
                SqlCommand countcmd = new SqlCommand(querytk2, sqlCon2);
                int value = (int)countcmd.ExecuteScalar();
                lblCount.Text = "Terdapat " + value.ToString() + " hasil ditemukan untuk "
                + '"' + result + '"';
            }
            else if (result == "MPSAT")
            {
                string querytk2 = "SELECT Count(*) FROM Asset1 WHERE MPSAT = 'V'";
                SqlCommand countcmd = new SqlCommand(querytk2, sqlCon2);
                int value = (int)countcmd.ExecuteScalar();
                lblCount.Text = "Terdapat " + value.ToString() + " hasil ditemukan untuk "
                + '"' + result + '"';
            }
            else
            {
                SqlCommand countcmd = new SqlCommand("AsCountAll", sqlCon2);
                countcmd.CommandType = CommandType.StoredProcedure;
                countcmd.Parameters.AddWithValue("@CountAll", result);
                int valuecount = (int)countcmd.ExecuteScalar();
                lblCount.Text = "Terdapat " + valuecount.ToString() + " hasil ditemukan untuk "
                    + '"' + result + '"';
            }
            fillGridView1();
        }

        void fillGridView1()
        {
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            string parse = link.Remove(0, 22);
            char[] array = parse.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                char let = array[i];
                if (let == '-')
                {
                    array[i] = ' ';
                }
            }

            string result = new string(array);
            if (result == "TELKOM 2")
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

            else if (result == "MPSAT")
            {
                string query = "SELECT * FROM Asset1 WHERE KELOMPOK = 'UPCONVERTER'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon2);
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

            else if (result == "TELKOM 3S")
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
            else
            {
                SqlCommand sqlcmd = new SqlCommand("AsFilterAllSort", sqlCon2);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@FilterAll", result);
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

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvContact.PageIndex = e.NewPageIndex;
            gvContact.DataBind();
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
            Session["site"] = dtbl.Rows[0]["Site"].ToString();
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
                fillGridView1();
                btnExpand.Text = "Reduce";
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

        protected void gvContact_PreRender(object sender, EventArgs e)
        {
            lblPage.Text = "Menampilkan halaman " + (gvContact.PageIndex + 1).ToString() + " dari " + gvContact.PageCount.ToString();
        }

        protected void btnurut_click(object sender, EventArgs e)
        {

        }
    }
}