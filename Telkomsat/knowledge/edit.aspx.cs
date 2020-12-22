using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Telkomsat.knowledge
{
    public partial class edit : System.Web.UI.Page
    {
        int i;
        string idpost;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            lblWaktu.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            idpost = Request.QueryString["id"];
            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            detail();
        }

        void detail()
        {
            string querydetail, id = "";
            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            string parse = Request.QueryString["id"];
            if(parse != null)
            {
                id = parse.ToString();
            }
            querydetail = $@"select * from Posting where ID_Post = '{id}'";
            DataSet ds = Settings.LoadDataSet(querydetail);

            txtJudul.Text = ds.Tables[0].Rows[0]["JUDUL"].ToString();
            txtAktivitas.Text = ds.Tables[0].Rows[0]["POSTING"].ToString(); ;
            ddlkategori.SelectedValue = ds.Tables[0].Rows[0]["KATEGORI"].ToString(); ;
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            sqlCon.Close();
            sqlCon.Open();
            string myquery = $@"Update Posting set JUDUL='{txtJudul.Text}', POSTING='{txtAktivitas.Text}', KATEGORI='{ddlkategori.SelectedValue}' WHERE ID_Post='{idpost}'";
            SqlCommand cmdLog = new SqlCommand(myquery, sqlCon);
            i = Convert.ToInt32(cmdLog.ExecuteScalar());
            sqlCon.Close();

            if (FileUpload1.HasFiles)
            {
                string physicalpath = Server.MapPath("~/fileupload/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);

                int filecount = 0;
                foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                {
                    filecount += 1;
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = "~/fileupload/" + filename;
                    file.SaveAs(physicalpath + filename);
                    string s = Convert.ToString(i);
                    sqlCon.Open();
                    string queryfile = $@"INSERT INTO postingfile (ID_Post, filepath, filename)
                                        VALUES ('{idpost}', '{filepath}', '{filename}')";
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            lblUpdate.Text = "Berhasil Menyimpan";
            lblUpdate.ForeColor = System.Drawing.Color.Green;
            Response.Redirect($"posting.aspx?id={idpost}");
        }

        protected void btnPosting_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/semua.aspx");
        }

        protected void btnFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/dashboard.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/tambah.aspx");
        }
    }
}