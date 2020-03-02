using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace Telkomsat.knowledge
{
    public partial class posting : System.Web.UI.Page
    {
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        int ID;
        StringBuilder htmlTable1 = new StringBuilder();
        //SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            string parse = link.Remove(0, 27);
            ID = Convert.ToInt32(parse);
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
            mytable();
            /*lblJudul.Text = Session["judul"].ToString();
            lblNama.Text = Session["nama"].ToString();
            lblKategori.Text = Session["kategori"].ToString();
            lblWaktu.Text = Session["waktu"].ToString();
            lblAktivitas.Text = Session["aktivitas"].ToString();*/
        }

        void mytable()
        {
            SqlDataAdapter da, da1;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            string myquery, query, color, namaall, ext, namafile;

            myquery = $@"select * from postingfile WHERE  ID_Post = '{ID}'";

            SqlCommand cmd = new SqlCommand(myquery, sqlCon2);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon2.Open();
            cmd.ExecuteNonQuery();
            sqlCon2.Close();

            htmlTable1.Append("<ul>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        namaall = ds.Tables[0].Rows[i]["filepath"].ToString();
                        namafile = namaall.Replace("~", "..");
                        ext = Path.GetExtension(namaall);
                        htmlTable1.Append($"<li class=\"gambar\"><img style=\"display:block\" class=\"myImg\" src=\"{namafile}\" height=\"200\" /></li>");
                    }
                    htmlTable1.Append("</ul>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable1.ToString() });
                }
            }
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