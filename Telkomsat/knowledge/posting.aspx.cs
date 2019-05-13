using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.knowledge
{
    public partial class posting : System.Web.UI.Page
    {
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        //SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("~/login.aspx");

            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            string parse = link.Remove(0, 27);
            int ID = Convert.ToInt32(parse);
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ViewIDJoin", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID_Post", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            dtContact.DataSource = dtbl;
            dtContact.DataBind();

            /*lblJudul.Text = Session["judul"].ToString();
            lblNama.Text = Session["nama"].ToString();
            lblKategori.Text = Session["kategori"].ToString();
            lblWaktu.Text = Session["waktu"].ToString();
            lblAktivitas.Text = Session["aktivitas"].ToString();*/
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

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
    }
}