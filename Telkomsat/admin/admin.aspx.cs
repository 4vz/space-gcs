using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.admin
{
    public partial class admin : System.Web.UI.Page
    {
        string user;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                user = Session["username"].ToString();

            }

            else
            {
                Response.Redirect("~/login.aspx", true);
                //Response.Write(Session["usertest"]);
            }
            

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
            
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");


            //lblProfile.Text = Session["username"].ToString();
            //lblProfile1.Text = Session["username"].ToString();
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}