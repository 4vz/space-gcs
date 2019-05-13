using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace Telkomsat.logbook
{
    public partial class edit : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=LOGBOOK1; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string formattanggal = Session["tanggal"].ToString();
                //DateTime newFormat = DateTime.ParseExact("09/12/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
                string tanggalnew = Convert.ToDateTime(formattanggal).ToString("yyyy/MM/dd");
                hfContactID.Value = Session["hf"].ToString();
                txtTanggal.Text = tanggalnew;
                txtAwal.Text = Session["mulai"].ToString();
                txtSelesai.Text = Session["selesai"].ToString();
                txtEvent.Text = Session["event"].ToString();
                txtInfo.Text = Session["info"].ToString();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("UpdateData", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
            sqlCmd.Parameters.AddWithValue("@tanggal", txtTanggal.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@event", txtEvent.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@mulai", txtAwal.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@selesai", txtSelesai.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@info", txtInfo.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            lblUpdate.Text = "Update Berhasil";
            lblUpdate.ForeColor = System.Drawing.Color.LawnGreen;

            sqlCon.Open();
            SqlCommand cmd = new SqlCommand("EditData", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDdata", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            gvLog.DataSource = dt;
            gvLog.DataBind();
            sqlCon.Close();
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