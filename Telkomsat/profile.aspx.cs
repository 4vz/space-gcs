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
    public partial class profile : System.Web.UI.Page
    {
        string user;
        Nullable<int> i = null;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            user = Session["username"].ToString();
            lblProfile1.Text = Session["username"].ToString();
            //string a;
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
                txtnama.Text = Session["nama"].ToString();
                txtemail.Text = Session["email"].ToString();
                txtnomor.Text = Session["nomor"].ToString();
                txttanggal.Text = Session["tanggal"].ToString();
                txttempat.Text = Session["tempat"].ToString();
                txtttl.Text = Session["ttl"].ToString();
                string password1 = Session["password"].ToString();
                //password1.Replace(password1, "*");
                /*for(int i = 1; i<=password1.Length; i++)
                {
                    a = "*";
                    string b = b + a;
                    Response.Write(b);
                    if(i==password1.Length)
                        txtpass.Text = b;
                }*/
                txtpass.Text = "******";
            }
        }
        protected void lbFoto_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/editfoto.aspx");
        }
        protected void lbProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/editprofile.aspx");
        }

        protected void lbPass_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/editpassword.aspx");
        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}