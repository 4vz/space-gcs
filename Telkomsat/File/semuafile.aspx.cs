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
    public partial class semuafile : System.Web.UI.Page
    {
        string mystring;
        string sorting;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rbasc.Checked = true;
                if (Session["carifile"] == null)
                {
                    GridBindFile();
                }
                else
                {
                    session();
                }
            }

            
                
        }

        public void GridBindFile()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("FileViewAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
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
            session();
        }

        protected void btnurut_click(object sender, EventArgs e)
        {
            session();
        }

        void session()
        {

            if (txtMaster.Value == "")
            {
                if (!IsPostBack)
                {
                    mystring = Session["carifile"] as string;
                    Session["carifile"] = "";
                }
                    
                else
                    mystring = "";
            }

            else if (txtMaster.Value != null)
            {
                mystring = txtMaster.Value;
            }

            //Response.Write(Session["carifile"].ToString());

            string[] split = mystring.Split(new char[] { ' ', '\t' });
            string kata1 = split[0];
            string kata2, kata3, kata4, kata5, kata6;
            //lblPage.Text = split[3];

            if (split.Length < 2)
                kata2 = "";
            else
                kata2 = split[1];

            if (split.Length < 3)
                kata3 = "";
            else
                kata3 = split[2];

            if (split.Length < 4)
                kata4 = "";
            else
                kata4 = split[3];

            if (split.Length < 5)
                kata5 = "";
            else
                kata5 = split[4];

            if (split.Length < 6)
                kata6 = "";
            else
                kata6 = split[5];

            con.Open();
            SqlCommand cmd = new SqlCommand("FileSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kata1", kata1);
            cmd.Parameters.AddWithValue("@kata2", kata2);
            cmd.Parameters.AddWithValue("@kata3", kata3);
            cmd.Parameters.AddWithValue("@kata4", kata4);
            cmd.Parameters.AddWithValue("@kata5", kata5);
            cmd.Parameters.AddWithValue("@kata6", kata6);
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
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            gvFile.DataSource = dt;
            gvFile.DataBind();
            con.Close();
        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/tambah.aspx");
        }

        protected void btnPosting_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/semua.aspx");
        }

        protected void btnFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/dashboard.aspx");
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