using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Telkomsat
{
    public partial class allnewdata : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=DATAGCS1; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGridView();
                gvContact.Columns[0].Visible = false;
                gvContact.Columns[3].Visible = false;
                gvContact.Columns[5].Visible = false;
                gvContact.Columns[8].Visible = false;
                gvContact.Columns[9].Visible = false;
                gvContact.Columns[10].Visible = false;
                gvContact.Columns[11].Visible = false;
                sqlCon.Close();
            }
            sqlCon.Open();
            SqlCommand countcmd = new SqlCommand("CountSemua", sqlCon);
            countcmd.CommandType = CommandType.StoredProcedure;
            //countcmd.Parameters.AddWithValue("@CountAll", "DOWNCONVERTER");
            int valuecount = (int)countcmd.ExecuteScalar();
            lblCount.Text = "Terdapat " + valuecount.ToString() + " hasil ditemukan";
            fillGridView();
        }

        void fillGridView()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand cmd = new SqlCommand("ViewAllSort", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Sort", urutkan.Value);
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            gvContact.DataSource = dt;
            gvContact.DataBind();
            sqlCon.Close();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvContact.PageIndex = e.NewPageIndex;
            gvContact.DataBind();
        }

        protected void Ink_OnClick1(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ViewByID", sqlCon);
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
            Response.Redirect("~/details.aspx");

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
                fillGridView();
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