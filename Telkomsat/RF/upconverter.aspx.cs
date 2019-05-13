using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.RF
{
    public partial class upconverter : System.Web.UI.Page
    {
        SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=DATAGCS1; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
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
                sqlCon2.Close();
                sqlCon2.Open();
                SqlCommand countcmd = new SqlCommand("CountAll", sqlCon2);
                countcmd.CommandType = CommandType.StoredProcedure;
                countcmd.Parameters.AddWithValue("@CountAll", "UPCONVERTER");
                int valuecount = (int)countcmd.ExecuteScalar();
                lblCount.Text = "Terdapat " + valuecount.ToString() + " hasil ditemukan";
            }
        }




        void fillGridView1()
        {
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ViewAll", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            SqlCommand sqlcmd = new SqlCommand("FilterAll", sqlCon2);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@FilterAll", "UPCONVERTER");
            gvContact.DataSource = sqlcmd.ExecuteReader();
            gvContact.DataBind();

        }

        protected void Ink_OnClick1(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ViewByID", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            Session["hf"] = hfContactID.Value;
            //Response.Redirect("~/details.aspx?equ=" + dtbl.Rows[0]["Equipment"].ToString() + "merk=" + dtbl.Rows[0]["Merk"].ToString());
            Response.Write(dtbl.Rows[0]["nama"].ToString());
            
        }
        /* protected void lbReadmore_OnClick(object sender, EventArgs e)
         {
             gvContact.Columns[3].Visible = true;
         }*/
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
    }
}