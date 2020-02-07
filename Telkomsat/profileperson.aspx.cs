using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace Telkomsat
{
    public partial class profileperson : System.Web.UI.Page
    {
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        //SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ProViewAllSort", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            dtContact.DataSource = dtbl;
            dtContact.DataBind();
            lblProfile1.Text = Session["username"].ToString();

            if (!IsPostBack)
            {
                sqlCon2.Open();
                SqlDataAdapter sqlCmd = new SqlDataAdapter("ProViewByUser", sqlCon2);
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd.SelectCommand.Parameters.AddWithValue("@user", lblProfile1.Text);
                DataTable dtbl1 = new DataTable();
                sqlCmd.Fill(dtbl1);
                DataList1.DataSource = dtbl1;
                DataList1.DataBind();
                //DataList2.DataSource = dtbl1;
                //DataList2.DataBind();
                sqlCon2.Close();
            }


        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        /*protected void linkOnClick(object sender, EventArgs e)
        {
            string user = Convert.ToString((sender as LinkButton).CommandArgument);
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ProViewByUser", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@user", user);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            Session["username"] = dtbl.Rows[0]["user_name"].ToString();
            Session["password"] = dtbl.Rows[0]["password"].ToString();
            Session["email"] = dtbl.Rows[0]["email"].ToString();
            Session["nama"] = dtbl.Rows[0]["nama"].ToString();
            Session["nomor"] = dtbl.Rows[0]["nomor"].ToString();
            Session["tanggal"] = dtbl.Rows[0]["tanggal_masuk"].ToString();
            Session["tempat"] = dtbl.Rows[0]["tempat"].ToString();
            Session["ttl"] = dtbl.Rows[0]["ttl"].ToString();
            /*lblJudul.Text = Session["judul"].ToString();
            lblNama.Text = Session["nama"].ToString();
            lblKategori.Text = Session["kategori"].ToString();
            lblWaktu.Text = Session["waktu"].ToString();
            lblAktivitas.Text = Session["aktivitas"].ToString();
            Response.Redirect("~/profile.aspx");

        }*/

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/tambahpost.aspx");
        }
        protected void btnPosting_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/semua.aspx");
        }

        protected void btnFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/dashboard.aspx");
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}