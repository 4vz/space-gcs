using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Telkomsat.logbook
{
    public partial class isilogbook : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=LOGBOOK1; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            txtTanggal.Enabled = false;
            txtTanggal.Text = DateTime.Now.ToString("yyyy/MM/dd");
            fillgridview();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            sqlCon.Open();
            SqlCommand cmdLog = new SqlCommand("CreateLogbook", sqlCon);
            cmdLog.CommandType = CommandType.StoredProcedure;
            cmdLog.Parameters.AddWithValue("@tanggal", txtTanggal.Text.Trim());
            cmdLog.Parameters.AddWithValue("@event", txtEvent.Text.Trim());
            cmdLog.Parameters.AddWithValue("@mulai", txtAwal.Text.Trim());
            cmdLog.Parameters.AddWithValue("@selesai", txtSelesai.Text.Trim());
            cmdLog.Parameters.AddWithValue("@info", txtInfo.Text.Trim());
            cmdLog.ExecuteNonQuery();
            sqlCon.Close();
            fillgridview();
            lblUpdate.Text = "Berhasil Menyimpan";
            lblUpdate.ForeColor = System.Drawing.Color.Green;
            clear();
        }

        void fillgridview()
        {
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("DataTerakhir", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@waktu", txtTanggal.Text.Trim());
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            gvLog.DataSource = dt;
            gvLog.DataBind();
            sqlCon.Close();
        }

        protected void btnGanti_Click(object sender, EventArgs e)
        {
            txtTanggal.Enabled = true;
        }
        
        void clear()
        {
            txtAwal.Text = "";
            txtSelesai.Text = "";
            txtEvent.Text = "";
            txtInfo.Text = "";
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
            Session["tanggal"] = dtbl.Rows[0]["tanggal"].ToString();
            Session["event"] = dtbl.Rows[0]["event"].ToString();
            Session["mulai"] = dtbl.Rows[0]["mulai"].ToString();
            Session["selesai"] = dtbl.Rows[0]["selesai"].ToString();
            Session["info"] = dtbl.Rows[0]["info"].ToString();

            //Response.Redirect("~/details.aspx?" + dtbl.Rows[0]["Merk"].ToString());
            Response.Redirect("~/logbook/edit.aspx");

        }
    }
}