using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Telkomsat
{
    public partial class editfoto : System.Web.UI.Page
    {
        string user;
        Nullable<int> i = null;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            user = Session["username"].ToString();
            if (!IsPostBack)
            {
                sqlCon.Open();
                SqlDataAdapter sqlCmd2 = new SqlDataAdapter("ProViewByUser", sqlCon);
                sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd2.SelectCommand.Parameters.AddWithValue("@user", user);
                DataTable dtbl = new DataTable();
                sqlCmd2.Fill(dtbl);
                dtContact1.DataSource = dtbl;
                dtContact1.DataBind();
                sqlCon.Close();
            }

            sqlCon.Open();
            SqlDataAdapter sqlCmd = new SqlDataAdapter("ProViewByUser", sqlCon);
            sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd.SelectCommand.Parameters.AddWithValue("@user", user);
            DataTable dtbl1 = new DataTable();
            sqlCmd.Fill(dtbl1);
            dtContact.DataSource = dtbl1;
            dtContact.DataBind();
            //DataList2.DataSource = dtbl1;
            //DataList2.DataBind();
            sqlCon.Close();

            lblProfile1.Text = Session["username"].ToString();
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            user = Session["username"].ToString();
            Byte[] File1;
            Stream s1 = FileUpload1.PostedFile.InputStream;
            BinaryReader br1 = new BinaryReader(s1);
            File1 = br1.ReadBytes((Int32)s1.Length);
            if (FileUpload1.HasFile == true)
            {
                sqlCon.Open();
                SqlCommand sqlCmd = new SqlCommand("ProUpdateImage", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Gambar1", File1);
                sqlCmd.Parameters.AddWithValue("@user", user);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            sqlCon.Open();
            SqlDataAdapter sqlCmd2 = new SqlDataAdapter("ProViewByUser", sqlCon);
            sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd2.SelectCommand.Parameters.AddWithValue("@user", user);
            DataTable dtbl = new DataTable();
            sqlCmd2.Fill(dtbl);
            sqlCon.Close();
            dtContact1.DataSource = dtbl;
            dtContact1.DataBind();
        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}