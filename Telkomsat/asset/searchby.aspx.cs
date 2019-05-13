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
    public partial class searchby : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnExpand.Visible = false;
                lblCount.Visible = false;
                urutkan.Visible = false;
                lblPage.Visible = false;
                gvContact.Columns[0].Visible = false;
                gvContact.Columns[3].Visible = false;
                gvContact.Columns[5].Visible = false;
                gvContact.Columns[8].Visible = false;
                gvContact.Columns[9].Visible = false;
                gvContact.Columns[10].Visible = false;
                gvContact.Columns[11].Visible = false;

            }



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


        protected void btnSearchby_Click(object sender, EventArgs e)
        {
            btnExpand.Visible = true;
            lblCount.Visible = true;
            urutkan.Visible = true;
            lblPage.Visible = true;
            filldata();

            if (gvContact.Rows.Count == 0)
            {
                lblnull.Visible = true;
                lblnull.Text = "Hasil Pencarian Tidak Ditemukan";
                btnExpand.Visible = false;
                lblCount.Visible = false;
                urutkan.Visible = false;
                lblPage.Visible = false;
            }
            else
                lblnull.Visible = false;
            sqlCon.Close();
            sqlCon.Open();
            SqlCommand countcmd = new SqlCommand("AsCountID", sqlCon);
            countcmd.CommandType = CommandType.StoredProcedure;
            if (txtNama.Text.Trim() != "")
            {
                countcmd.Parameters.AddWithValue("@CountNama", txtNama.Text.Trim());
            }
            if (txtMerk.Text.Trim() != "")
            {
                countcmd.Parameters.AddWithValue("@CountMerk", txtMerk.Text.Trim());
            }
            if (txtSN.Text.Trim() != "")
            {
                countcmd.Parameters.AddWithValue("@CountSN", txtSN.Text.Trim());
            }
            if (txtLokasi.Text.Trim() != "")
            {
                countcmd.Parameters.AddWithValue("@CountSite", txtLokasi.Text.Trim());
            }
            if (txtGudang.Text.Trim() != "")
            {
                countcmd.Parameters.AddWithValue("@CountGudang", txtGudang.Text.Trim());
            }
            if (txtTahun.Text.Trim() != "")
            {
                countcmd.Parameters.AddWithValue("@CountTahun", txtTahun.Text.Trim());
            }
            if (txtFungsi.Text.Trim() != "")
            {
                countcmd.Parameters.AddWithValue("@CountFungsi", txtFungsi.Text.Trim());
            }
            if (txtStatus.Text.Trim() != "")
            {
                countcmd.Parameters.AddWithValue("@CountStatus", txtStatus.Text.Trim());
            }

            int valuecount = (int)countcmd.ExecuteScalar();
            lblCount.Text = "Terdapat " + valuecount.ToString() + " hasil ditemukan";
        }

        void filldata()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            //string queryequipment = "SELECT * FROM Invest WHERE EQUIPMENT LIKE '%' + @Equipment + '%'";
            SqlCommand sqlcmd = new SqlCommand("AsFilterIDSort", sqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            if (txtNama.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@NAMA", txtNama.Text.Trim());
            }
            if (txtMerk.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@MERK", txtMerk.Text.Trim());
            }
            if (txtLokasi.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@SITE", txtLokasi.Text.Trim());
            }
            if (txtSN.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@SN", txtSN.Text.Trim());
            }
            if (txtTahun.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@TAHUN", txtTahun.Text.Trim());
            }
            if (txtGudang.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@GUDANG", txtGudang.Text.Trim());
            }
            if (txtFungsi.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@FUNGSI", txtFungsi.Text.Trim());
            }
            if (txtStatus.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@STATUS", txtStatus.Text.Trim());
            }
            sqlcmd.Parameters.AddWithValue("@SORT", urutkan.Value);
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

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            filldata();
            gvContact.PageIndex = e.NewPageIndex;
            gvContact.DataBind();
        }

        protected void gvContact_PreRender(object sender, EventArgs e)
        {
            lblPage.Text = "Menampilkan halaman " + (gvContact.PageIndex + 1).ToString() + " dari " + gvContact.PageCount.ToString();
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
                filldata();

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
            filldata();
        }
    }
}