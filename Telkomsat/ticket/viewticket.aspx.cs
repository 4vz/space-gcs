using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.ticket
{
    public partial class viewticket : System.Web.UI.Page
    {
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string query, queryupdate;
        int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            string parse = link.Remove(0, 27);

            

            if(Session["jenis1"].ToString() == "tcc")
                spam.Style["display"] = "none";

            //Response.Write(parse);
            ID = Convert.ToInt32(parse);
            //string query = $"SELECT * FROM ticket_user WHERE id_ticket = {parse}";
            //Response.Write(ID);

            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ticketbyid", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@id", parse);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            datalist1.DataSource = dtbl;
            datalist1.DataBind();

            if(dtbl.Rows[0]["status"].ToString() == "accept")
            {
                btnaccept.Visible = false;
                btnreject.Visible = false;
                btncomplete.Visible = true;
                btnincomplete.Visible = true;
            }

            foreach (DataListItem dli in datalist1.Items)
            {
                Label lblprioritas = (Label)dli.FindControl("KATEGORILabel");
                Label lblstatus = (Label)dli.FindControl("lblStatus");

                if (dtbl.Rows[0]["prioritas"].ToString() == "Medium")
                {
                    lblprioritas.CssClass = " btn1 btn-sm btn-success";
                }
                else if (dtbl.Rows[0]["prioritas"].ToString() == "Low")
                {
                    lblprioritas.CssClass = " btn1 btn-sm btn-default";
                }
                else if (dtbl.Rows[0]["prioritas"].ToString() == "High")
                {
                    lblprioritas.CssClass = " btn1 btn-sm btn-danger";
                }

                if (dtbl.Rows[0]["status"].ToString() == "sent")
                {
                    lblstatus.CssClass = " btn1 btn-sm btn-default";
                }
                else if (dtbl.Rows[0]["status"].ToString() == "accept")
                {
                    lblstatus.CssClass = " btn1 btn-sm btn-primary";
                }
                else if (dtbl.Rows[0]["status"].ToString() == "reject")
                {
                    lblstatus.CssClass = " btn1 btn-sm btn-danger";
                }
            }



            
        }

        protected void Rejected_ServerClick(object sender, EventArgs e)
        {
            sqlCon2.Open();
            queryupdate = $"UPDATE ticket_user SET status = 'reject' WHERE id_ticket = {ID}";
            SqlCommand cmd = new SqlCommand(queryupdate, sqlCon2);
            cmd.ExecuteNonQuery();
            sqlCon2.Close();
            lblstatus.Visible = true;
            lblstatus.Text = " Ticket rejected";
            lblstatus.ForeColor = System.Drawing.Color.IndianRed;

        }
        protected void Accepted_ServerClick(object sender, EventArgs e)
        {
            sqlCon2.Open();
            queryupdate = $"UPDATE ticket_user SET status = 'accept' WHERE id_ticket = {ID}";
            SqlCommand cmd = new SqlCommand(queryupdate, sqlCon2);
            cmd.ExecuteNonQuery();
            sqlCon2.Close();
            lblstatus.Visible = true;
            lblstatus.Text = " Ticket Accepted";
            lblstatus.ForeColor = System.Drawing.Color.LawnGreen;

        }
    }
}