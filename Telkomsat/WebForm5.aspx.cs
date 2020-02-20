using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Text;
using System.IO;

namespace Telkomsat
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string room, waktu, datee;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            string querycountf = $"select count(*) from table_log_file WHERE kategori = 'utama'";
            SqlCommand cmd4 = new SqlCommand(querycountf, sqlCon);
            int output1 = int.Parse(cmd4.ExecuteScalar().ToString());
            sqlCon.Close();

            if (output1 >= 1)
            {
                string queryfile = $"select * from table_log_file WHERE kategori='utama'";
                DataList3a.Visible = true;
                sqlCon.Open();
                SqlDataAdapter sqlda1 = new SqlDataAdapter(queryfile, sqlCon);
                DataTable dtbl1 = new DataTable();
                sqlda1.Fill(dtbl1);
                sqlCon.Close();
                DataList3a.DataSource = dtbl1;
                DataList3a.DataBind();
            }

            mytable();
        }

        void mytable()
        {
            SqlDataAdapter da, da1;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            string myquery, query, color, namaall, ext;

            myquery = $@"select * from table_log_file WHERE kategori='utama' and (ekstension in ('.jpeg', '.png', '.bmp', '.jfif', '.gif', '.jpg'))";

            SqlCommand cmd = new SqlCommand(myquery, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable1.Append("<ul>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        namaall = ds.Tables[0].Rows[i]["files"].ToString();
                        ext = Path.GetExtension(namaall);
                        htmlTable1.Append($"<li><img src=\"{namaall}\" height=\"200\" /></li>");
                    }
                    htmlTable.Append("</ul>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable1.ToString() });
                }
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename="
                + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/fileupload/")
                + e.CommandArgument);
            Response.End();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            SqlDataAdapter da, da1;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            string myquery, query, color, namaall;

            myquery = $@"select ruangan from checkme_perangkat group by ruangan";

            SqlCommand cmd = new SqlCommand(myquery, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        htmlTable.Append($"<li>{ds.Tables[0].Rows[i]["ruangan"].ToString()}</li>");
                    }
                    
                }
            }
            PlaceHolder pl = e.Item.FindControl("PlaceHolder1") as PlaceHolder;
            pl.Controls.Add(new TextBox());
            Response.Write("nninini");
        }

        private void AuthenticateUser(string username, string password)
        {
            // ConfigurationManager class is in System.Configuration namespace
            string CS = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;



            // SqlConnection is in System.Data.SqlClient namespace
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spAuthenticateUser", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //Formsauthentication is in system.web.security
                string encryptedpassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

                //sqlparameter is in System.Data namespace
                SqlParameter paramUsername = new SqlParameter("@UserName", username);
                SqlParameter paramPassword = new SqlParameter("@Password", encryptedpassword);

                cmd.Parameters.Add(paramUsername);
                cmd.Parameters.Add(paramPassword);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    int RetryAttempts = Convert.ToInt32(rdr["RetryAttempts"]);
                    if (Convert.ToBoolean(rdr["AccountLocked"]))
                    {
                        //lblMessage.Text = "Account locked. Please contact administrator";
                    }
                    else if (RetryAttempts > 0)
                    {
                        int AttemptsLeft = (4 - RetryAttempts);
                        //lblMessage.Text = "Invalid user name and/or password. " +
                            //AttemptsLeft.ToString() + "attempt(s) left";
                    }
                    else if (Convert.ToBoolean(rdr["Authenticated"]))
                    {
                        FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkBoxRememberMe.Checked);
                    }
                }
            }
        }
    }
}