using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.logbook1
{
    public partial class searchby : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCari_Click(object sender, EventArgs e)
        {
            string mystring = txtEvent.Text;
            string[] split = mystring.Split(new char[] { ' ', '\t' });
            string kata1 = split[0];
            string kata2, kata3, kata4, kata5;
            //lblPage.Text = split[3];
            if (split.Length < 2)
                kata2 = "";
            else
                kata2 = split[1];

            if (split.Length < 3)
                kata3 = "";
            else
                kata3 = split[2];

            if (split.Length < 4)
                kata4 = "";
            else
                kata4 = split[3];

            if (split.Length < 5)
                kata5 = "";
            else
                kata5 = split[4];

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            //string queryequipment = "SELECT * FROM Invest WHERE EQUIPMENT LIKE '%' + @Equipment + '%'";
            SqlCommand sqlcmd = new SqlCommand("LoSearchBy", sqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            if (txtsdate.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@mulai", txtsdate.Text);
            }
            if (txtedate.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@akhir", txtedate.Text);
            }
            if (ddlUnit.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@unit", ddlUnit.SelectedValue);
            }
            if (ddlKategori.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@kategori", ddlKategori.SelectedValue);
            }
            if (ddlStatus.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@status", ddlStatus.SelectedValue);
            }
            if (txtOG.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@OG", txtOG.Text);
            }
            if (txtOS.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@OS", txtOS.Text);
            }
            if (txtSN.Text.Trim() != "")
            {
                sqlcmd.Parameters.AddWithValue("@SN", txtSN.Text);
            }

            sqlcmd.Parameters.AddWithValue("@kata1", kata1);
            sqlcmd.Parameters.AddWithValue("@kata2", kata2);
            sqlcmd.Parameters.AddWithValue("@kata3", kata3);
            sqlcmd.Parameters.AddWithValue("@kata4", kata4);
            sqlcmd.Parameters.AddWithValue("@kata5", kata5);

            using (SqlDataAdapter da = new SqlDataAdapter(sqlcmd))
            {
                da.SelectCommand = sqlcmd;
                using (DataTable ds = new DataTable())
                {
                    //SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                    da.Fill(ds);
                    gvLog.DataSource = ds;
                    gvLog.DataBind();

                    //gvContact.DataSource = sqlcmd.ExecuteReader();
                    //gvContact.DataBind();
                    sqlCon.Close();
                }

            }
        }

        protected void gvLog_RowData(object sender, GridViewRowEventArgs e)
        {
            for (int rowindex = gvLog.Rows.Count - 2; rowindex >= 0; rowindex--)
            {
                GridViewRow rows = gvLog.Rows[rowindex];
                GridViewRow previousrows = gvLog.Rows[rowindex + 1];

                if (rows.Cells[1].Text == previousrows.Cells[1].Text)
                {
                    rows.Cells[1].RowSpan = previousrows.Cells[1].RowSpan < 2 ? 2 :
                        previousrows.Cells[1].RowSpan + 1;
                    previousrows.Cells[1].Visible = false;
                }
            }

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
            SqlDataAdapter sqlda = new SqlDataAdapter("LoViewIDLogbook", sqlCon);
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
            Session["unit"] = dtbl.Rows[0]["unit"].ToString();
            Session["kategori"] = dtbl.Rows[0]["kategori"].ToString();
            Session["status"] = dtbl.Rows[0]["status"].ToString();
            Session["OS"] = dtbl.Rows[0]["PIC_OS"].ToString();
            Session["OG"] = dtbl.Rows[0]["PIC_OG"].ToString();
            Session["info"] = dtbl.Rows[0]["info"].ToString();
            Session["SN"] = dtbl.Rows[0]["S/N"].ToString();
            Session["SN"] = dtbl.Rows[0]["S/N"].ToString();
            Session["SN1"] = dtbl.Rows[0]["SN"].ToString();
            Session["estimasi"] = dtbl.Rows[0]["estimasi"].ToString();
            //Response.Redirect("~/details.aspx?" + dtbl.Rows[0]["Merk"].ToString());
            Response.Redirect("~/logbook1/details.aspx",false);

        }
    }
}