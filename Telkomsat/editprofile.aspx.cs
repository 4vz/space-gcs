using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Threading;

namespace Telkomsat
{
    public partial class editprofile : System.Web.UI.Page
    {
        string user;
        
        //SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string ttl;
            string tanggal;

            Page.Form.DefaultButton = btnUpdate.ID;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");
            else
            {
                user = Session["username"].ToString();
                sqlCon2.Open();
                SqlDataAdapter sqlCmd = new SqlDataAdapter("ProViewByUser", sqlCon2);
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd.SelectCommand.Parameters.AddWithValue("@user", user);
                DataTable dtbl1 = new DataTable();
                sqlCmd.Fill(dtbl1);
                
                dtContact.DataSource = dtbl1;
                dtContact.DataBind();
                //DataList2.DataSource = dtbl1;
                //DataList2.DataBind();
                sqlCon2.Close();
                sqlCon2.Open();
                SqlCommand mycmd = new SqlCommand($"SELECT * FROM Profile Where user_name = '{user}'", sqlCon2);
                SqlDataAdapter da2 = new SqlDataAdapter(mycmd);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);
                mycmd.ExecuteNonQuery();
                sqlCon2.Close();
                if (!IsPostBack)
                {
                    txtnama.Value = ds2.Tables[0].Rows[0]["nama"].ToString();
                    txtemail.Value = ds2.Tables[0].Rows[0]["email"].ToString();
                    txtnomor.Value = ds2.Tables[0].Rows[0]["nomor"].ToString();
                    txttempat.Value = ds2.Tables[0].Rows[0]["tempat"].ToString();
                    if (txttanggal.Value != "")
                        txttanggal.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["tanggal_masuk"].ToString()).ToString("dd/MM/yyyy");
                    if (txttanggal.Value != "")
                        txtttl.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["ttl"].ToString()).ToString("dd/MM/yyyy");
                }
                
            }
            lblProfile1.Text = Session["nama1"].ToString();
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            user = Session["username"].ToString();
            sqlCon2.Open();
            SqlCommand sqlCmd2 = new SqlCommand("ProUpdate", sqlCon2);
            sqlCmd2.CommandType = CommandType.StoredProcedure;
            sqlCmd2.Parameters.AddWithValue("@user", user);
            sqlCmd2.Parameters.AddWithValue("@nama", txtnama.Value);
            sqlCmd2.Parameters.AddWithValue("@email", txtemail.Value);
            sqlCmd2.Parameters.AddWithValue("@nomor", txtnomor.Value);
            if(txtttl.Value != Session["ttl"].ToString())
            {
                sqlCmd2.Parameters.AddWithValue("@ubahttl", "ubah");
                if (txtttl.Value == "")
                    sqlCmd2.Parameters.AddWithValue("@ttl", DBNull.Value);
                else
                    sqlCmd2.Parameters.AddWithValue("@ttl", DateTime.ParseExact(txtttl.Value, "dd/MM/yyyy", null));
            }
            else
            {
                sqlCmd2.Parameters.AddWithValue("@ubahttl", "ubah1");
                sqlCmd2.Parameters.AddWithValue("@ttl", DBNull.Value);
            }

            if (txttanggal.Value != Session["tanggal1"].ToString())
            {
                sqlCmd2.Parameters.AddWithValue("@ubahtanggal", "ubah2");
                if (txttanggal.Value == "")
                    sqlCmd2.Parameters.AddWithValue("@tanggal", DBNull.Value);
                else
                    sqlCmd2.Parameters.AddWithValue("@tanggal", DateTime.ParseExact(txttanggal.Value, "dd/MM/yyyy", null));
            }
            else
            {
                sqlCmd2.Parameters.AddWithValue("@ubahtanggal", "ubah3");
                sqlCmd2.Parameters.AddWithValue("@tanggal", DBNull.Value);
            }

            sqlCmd2.Parameters.AddWithValue("@tempat", txttempat.Value);

            
            sqlCmd2.ExecuteNonQuery();
            sqlCon2.Close();
            lblUpdate.Visible = true;
            lblUpdate.Text = "Berhasil Update";
            lblUpdate.ForeColor = System.Drawing.Color.GreenYellow;
            clear();

            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ProViewByUser", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@user", Session["username"].ToString());
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            
            //Session["username"] = dtbl.Rows[0]["user_name"].ToString();
            Session["email"] = dtbl.Rows[0]["email"].ToString();
            Session["jenis1"] = dtbl.Rows[0]["jenis"].ToString();
            Session["nama1"] = dtbl.Rows[0]["nama"].ToString();
            Session["nomor"] = dtbl.Rows[0]["nomor"].ToString();
            Session["tanggal1"] = dtbl.Rows[0]["tanggal_masuk"].ToString();
            Session["tempat"] = dtbl.Rows[0]["tempat"].ToString();
            Session["ttl"] = dtbl.Rows[0]["ttl"].ToString();
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