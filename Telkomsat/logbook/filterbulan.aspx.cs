using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.knowledge
{
    public partial class filterbulan : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=LOGBOOK1; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                fillGridView();
                sqlCon.Close();
            }
            fillGridView();
        }

        void fillGridView()
        {
            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            string parse = link.Remove(0, 29);
            string tahun = link.Remove(0, 32);
            string bulan = parse.Remove(parse.Length - 5);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand cmd = new SqlCommand("BulanSort", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bulan", bulan);
            cmd.Parameters.AddWithValue("@tahun", tahun);

            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            gvLog.DataSource = dt;
            gvLog.DataBind();
            sqlCon.Close();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvLog.PageIndex = e.NewPageIndex;
            gvLog.DataBind();
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

        protected void gvLog_PreRender(object sender, EventArgs e)
        {
            lblPage.Text = "Menampilkan halaman " + (gvLog.PageIndex + 1).ToString() + " dari " + gvLog.PageCount.ToString();
        }

        protected void gvLog_RowData(object sender, GridViewRowEventArgs e)
        {
            for (int rowindex = gvLog.Rows.Count - 2; rowindex >= 0; rowindex--)
            {
                GridViewRow rows = gvLog.Rows[rowindex];
                GridViewRow previousrows = gvLog.Rows[rowindex + 1];
                if (rows.Cells[0].Text == previousrows.Cells[0].Text)
                {
                    rows.Cells[0].RowSpan = previousrows.Cells[0].RowSpan < 2 ? 2 :
                        previousrows.Cells[0].RowSpan + 1;
                    previousrows.Cells[0].Visible = false;
                }
            }


        }
    }
}