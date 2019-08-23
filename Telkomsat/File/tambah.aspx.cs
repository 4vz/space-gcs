using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;


namespace Telkomsat.File
{
    public partial class tambah : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnSave.UniqueID;
            txtTanggal.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
            Session["carifile"] = txtMaster.Value;
            Response.Redirect("~/File/semuafile.aspx");
        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/tambah.aspx");
        }

        /*protected void btnGanti_Click(object sender, EventArgs e)
        {
            if (ddlKategori.Text == "Buku Manual")
            {
                Response.Write(ddlBuku.Text);
                Response.Write(ddlBuku1.Text);
            }
            else if (ddlKategori.Text == "SOP")
                Response.Write(ddlSOP.Text);
            else if (ddlKategori.Text == "Pelatihan")
            {
                Response.Write(ddlPelatihan.Text);
                Response.Write(ddlPelatihan1.Text);
            }
                
        }*/

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            string FN = "";
            FN = Path.GetFileName(fuimage.PostedFile.FileName);
            string contentType = fuimage.PostedFile.ContentType;
            Stream fs = fuimage.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);

            con.Open();
            SqlCommand cmd = new SqlCommand("FileTambah", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@empid", btnUploadImage.Text == "Save" ? 0 : ViewState["Eid"]);



            if (FN != "")
            {
                //fuimage.SaveAs(Server.MapPath("Uploads" + "\\" + FN));

                cmd.Parameters.AddWithValue("@Nama", FN);
                cmd.Parameters.AddWithValue("@ContentType", contentType);
                cmd.Parameters.AddWithValue("@Data", bytes);
                cmd.Parameters.AddWithValue("@Kategori1", ddlKategori.Text);
                if (ddlKategori.Text == "Buku Manual")
                {
                    cmd.Parameters.AddWithValue("@Kategori2", ddlBuku.Text);
                    cmd.Parameters.AddWithValue("@Kategori3", ddlBuku1.Text);
                    cmd.Parameters.AddWithValue("@Kategori4", "");
                }
                else if (ddlKategori.Text == "SOP")
                {
                    cmd.Parameters.AddWithValue("@Kategori2", ddlSOP.Text);
                    cmd.Parameters.AddWithValue("@Kategori3", "");
                    cmd.Parameters.AddWithValue("@Kategori4", "");
                }
                else if (ddlKategori.Text == "Pelatihan")
                {
                    cmd.Parameters.AddWithValue("@Kategori2", ddlPelatihan.Text);
                    cmd.Parameters.AddWithValue("@Kategori3", ddlPelatihan1.Text);
                    cmd.Parameters.AddWithValue("@Kategori4", "");
                }
                else if (ddlKategori.Text == "Pembaruan Konfigurasi")
                {
                    cmd.Parameters.AddWithValue("@Kategori2", ddlPembaruan1.Text);
                    if(ddlPembaruan1.Text=="Operasional")
                    {
                        cmd.Parameters.AddWithValue("@Kategori4", ddlPembaruanOp1.Text);
                        cmd.Parameters.AddWithValue("@Kategori3", ddlPembaruanOp.Text);
                    }   
                    else if (ddlPembaruan1.Text == "Network")
                    {
                        cmd.Parameters.AddWithValue("@Kategori3", ddlPembaruanNe.Text);
                        cmd.Parameters.AddWithValue("@Kategori4", "");
                    }
                    else if (ddlPembaruan1.Text == "Communication & Monitor")
                    {
                        cmd.Parameters.AddWithValue("@Kategori3", "");
                        cmd.Parameters.AddWithValue("@Kategori4", "");
                    }

                }

                cmd.Parameters.AddWithValue("@Waktu", Tanggal);
                cmd.ExecuteNonQuery();
                con.Close();
                lblBerhasil.Visible = true;
                lblBerhasil.ForeColor = System.Drawing.Color.Green;
                lblBerhasil.Text = "Berhasil Tambah";
            }
            else
            {
                lblBerhasil.Visible = true;
                lblBerhasil.ForeColor = System.Drawing.Color.DarkRed;
                lblBerhasil.Text = "Masukkan FIle";
            }

            
        }
    }
}