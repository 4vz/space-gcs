using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Telkomsat
{
    public partial class editpassword : System.Web.UI.Page
    {
        string user;
        //SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnUpdate.ID;

            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            user = Session["username"].ToString();
            //txtnama.Value = Session["username"].ToString();
            if (!IsPostBack)
            {
                txtpass.Value = Session["password"].ToString();

                sqlCon2.Open();
                SqlDataAdapter sqlCmd = new SqlDataAdapter("ProViewByUser", sqlCon2);
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd.SelectCommand.Parameters.AddWithValue("@user", user);
                DataTable dtbl1 = new DataTable();
                sqlCmd.Fill(dtbl1);
                DataList1.DataSource = dtbl1;
                DataList1.DataBind();
                sqlCon2.Close();
            }
            lblProfile1.Text = Session["nama1"].ToString();
        }

        static string ToMD5Hash(string source)
        {
            StringBuilder sb = new StringBuilder();

            using (MD5 md5 = MD5.Create())
            {
                byte[] md5HashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(source));

                foreach (byte b in md5HashBytes)
                {
                    sb.Append(b.ToString("X2")); // print byte as Hexadecimal string
                }
            }

            return sb.ToString();
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            user = Session["username"].ToString();
            sqlCon2.Open();
            SqlCommand sqlCmd2 = new SqlCommand("ProUpdatePass", sqlCon2);
            sqlCmd2.CommandType = CommandType.StoredProcedure;
            sqlCmd2.Parameters.AddWithValue("@user", user);
            if(ToMD5Hash(ToMD5Hash(txtpass.Value)) != Session["password"].ToString())
            {
                lblUpdate.Visible = true;
                lblUpdate.Text = "Password lama salah";
                lblUpdate.ForeColor = System.Drawing.Color.Red;
            }
            else { 
                if(txtpass1.Value == txtpass2.Value)
                {
                    sqlCmd2.Parameters.AddWithValue("@pass", ToMD5Hash(ToMD5Hash(txtpass1.Value)));
                    sqlCmd2.ExecuteNonQuery();
                    sqlCon2.Close();
                    lblUpdate.Visible = true;
                    lblUpdate.Text = "Berhasil Update";
                    lblUpdate.ForeColor = System.Drawing.Color.GreenYellow;
                    clear();
                }
                
                else
                {
                    lblUpdate.Visible = true;
                    lblUpdate.Text = "Password tidak cocok";
                    lblUpdate.ForeColor = System.Drawing.Color.Red;
                }
            }

        }

        void clear()
        {

        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}