using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.File
{
    public partial class filter : System.Web.UI.Page
    {
        string sorting;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            GridBindFile();
            if (!IsPostBack)
            {
                rbasc.Checked = true;
            }
        }

        protected void btnPosting_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/semua.aspx");
        }

        protected void btnFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/dashboard.aspx");
        }

        protected void btnurut_click(object sender, EventArgs e)
        {
            GridBindFile();
        }

        public void GridBindFile()
        {
            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            string parse = link.Remove(0, 24);
            string jenis = link.Substring(21, 2);
            char[] array = parse.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                char let = array[i];
                if (let == '+')
                {
                    array[i] = ' ';
                }
            }

            string kategori = new string(array);

            if (jenis == "01")
                jenis = "Buku Manual";
            else if (jenis == "02")
                jenis = "SOP";
            else if (jenis == "03")
                jenis = "Pelatihan";
            else if (jenis == "04")
                jenis = "Pembaruan Konfigurasi";

            con.Open();
            SqlCommand cmd = new SqlCommand("FileFilter", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kategori1", jenis);
            cmd.Parameters.AddWithValue("@kategori2", kategori);
            if (urutkan.Value == "Nama File" && rbasc.Checked)
                sorting = "NAMAASC";
            else if (urutkan.Value == "Nama File" && rbdesc.Checked)
                sorting = "NAMADESC";
            else if (urutkan.Value == "Waktu" && rbasc.Checked)
                sorting = "WAKTUASC";
            else if (urutkan.Value == "Waktu" && rbdesc.Checked)
                sorting = "WAKTUDESC";
            else if (urutkan.Value == "Ukuran" && rbasc.Checked)
                sorting = "PANJANGASC";
            else if (urutkan.Value == "Ukuran" && rbdesc.Checked)
                sorting = "PANJANGDESC";
            else if (urutkan.Value == "Kategori" && rbasc.Checked)
                sorting = "KATEGORIASC";
            else if (urutkan.Value == "Kategori" && rbdesc.Checked)
                sorting = "KATEGORIDESC";
            else
                sorting = "";

            cmd.Parameters.AddWithValue("@SORT", sorting);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvFile.DataSource = ds;
                gvFile.DataBind();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["carifile"] = txtMaster.Value;
            Response.Redirect("~/File/semuafile.aspx");
        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/semuafile.aspx");
        }

        protected void linkDownloadFile_Click(object sender, EventArgs e)
        {

            int ImageId = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_fileDownload", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ImageId);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            fileName = sdr["NameFile"].ToString();
            bytes = (byte[])sdr["Data"];
            contentType = sdr["ContentType"].ToString();
            con.Close();
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

        }
    }
}