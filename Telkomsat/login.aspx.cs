using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;

namespace Telkomsat
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS1; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
                Response.Redirect("dashboard.aspx");
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            string query = "SELECT COUNT(*) FROM Profile WHERE user_name='" + inEmail.Value + "' AND password ='" + ToMD5Hash(ToMD5Hash(inPass.Value)) + " '";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            string output = cmd.ExecuteScalar().ToString();
            sqlCon.Close();
            if (output == "1")
            {
                
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("ProViewByUser", sqlCon);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("@user", inEmail.Value);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                sqlCon.Close();
                Session["iduser"] = dtbl.Rows[0]["id_profile"].ToString();
                Session["username"] = dtbl.Rows[0]["user_name"].ToString();
                //Session["username"] = dtbl.Rows[0]["user_name"].ToString();
                Session["password"] = dtbl.Rows[0]["password"].ToString();
                Session["email"] = dtbl.Rows[0]["email"].ToString();
                Session["jenis1"] = dtbl.Rows[0]["jenis"].ToString();
                Session["nama1"] = dtbl.Rows[0]["nama"].ToString();
                Session["nomor"] = dtbl.Rows[0]["nomor"].ToString();
                Session["previllage"] = dtbl.Rows[0]["previllage"].ToString();
                Session["tanggal1"] = dtbl.Rows[0]["tanggal_masuk"].ToString();
                Session["tempat"] = dtbl.Rows[0]["tempat"].ToString();
                Session["ttl"] = dtbl.Rows[0]["ttl"].ToString();
                Response.Redirect("~/dashboard2.aspx", false);
            }
            else
            {
                lblGagal.Visible = true;
                //Response.Write(output);
            }
        }
    }
}