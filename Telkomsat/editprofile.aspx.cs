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
    public partial class editprofile : System.Web.UI.Page
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
                txtnama.Value = Session["nama"].ToString();
                txtemail.Value = Session["email"].ToString();
                txtnomor.Value = Session["nomor"].ToString();
                txttanggal.Value = Session["tanggal"].ToString();
                txttempat.Value = Session["tempat"].ToString();
                txtttl.Value = Session["ttl"].ToString();
            }
            lblProfile1.Text = Session["username"].ToString();
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            user = Session["username"].ToString();
            sqlCon2.Open();
            SqlCommand sqlCmd2 = new SqlCommand("ProUpdate", sqlCon2);
            sqlCmd2.CommandType = CommandType.StoredProcedure;
            sqlCmd2.Parameters.AddWithValue("@user", user);
            sqlCmd2.Parameters.AddWithValue("@nama", txtnama.Value);
            sqlCmd2.Parameters.AddWithValue("@email", txtemail.Value);
            sqlCmd2.Parameters.AddWithValue("@nomor", txtnomor.Value);
            sqlCmd2.Parameters.AddWithValue("@tanggal", txttanggal.Value);
            sqlCmd2.Parameters.AddWithValue("@tempat", txttempat.Value);
            sqlCmd2.Parameters.AddWithValue("@ttl", txtttl.Value);
            sqlCmd2.ExecuteNonQuery();
            sqlCon2.Close();
            lblUpdate.Visible = true;
            lblUpdate.Text = "Berhasil Update";
            lblUpdate.ForeColor = System.Drawing.Color.GreenYellow;
            clear();
        }

        void clear()
        {
            txtemail.Value = "";
            txtnama.Value = "";
            txttanggal.Value = "";
            txtnomor.Value = "";
            txttempat.Value = "";
            txtttl.Value = "";
        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}