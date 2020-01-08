using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using Image = System.Drawing.Image;

namespace Telkomsat
{
    public partial class editfoto : System.Web.UI.Page
    {
        string user;
        Nullable<int> i = null;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            user = Session["username"].ToString();
            if (!IsPostBack)
            {
                sqlCon.Open();
                SqlDataAdapter sqlCmd2 = new SqlDataAdapter("ProViewByUser", sqlCon);
                sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd2.SelectCommand.Parameters.AddWithValue("@user", user);
                DataTable dtbl = new DataTable();
                sqlCmd2.Fill(dtbl);
                dtContact1.DataSource = dtbl;
                dtContact1.DataBind();
                dtContact.DataSource = dtbl;
                dtContact.DataBind();
                sqlCon.Close();
            }
            ButtonCrop.Visible = false;
            btnUpdate.Visible = false;


            lblStatus.ForeColor = System.Drawing.Color.Green;
            lblStatus.Text = "Pilih gambar untuk foto profile <font color='red'><b>Max(700kb).</b></font>";
            lblProfile1.Text = Session["username"].ToString();
        }

        protected void btnCrop_click(object sender, EventArgs e)
        {
            if (coordinate_w.Value != "" && coordinate_h.Value != "")
            {
                btnUpdate.Visible = true;
                ButtonPilih.Visible = false;
                ButtonCrop.Visible = false;

                string fileName = Path.GetFileName(cropimage1.ImageUrl);
                string filePath = Path.Combine(Server.MapPath("~/image"), fileName);
                Image outputfile = Image.FromFile(filePath);
                Rectangle cropcoordinate = new Rectangle(Convert.ToInt32(coordinate_x.Value), Convert.ToInt32(coordinate_y.Value), Convert.ToInt32(coordinate_w.Value), Convert.ToInt32(coordinate_h.Value));
                string confilename, confilepath;
                Bitmap bitmap = new Bitmap(cropcoordinate.Width, cropcoordinate.Height);
                Graphics grapics = Graphics.FromImage(bitmap);
                grapics.DrawImage(outputfile, new Rectangle(0, 0, bitmap.Width, bitmap.Height), cropcoordinate, GraphicsUnit.Pixel);
                confilename = "Crop_" + fileName;
                confilepath = Path.Combine(Server.MapPath("~/cropimag"), confilename);
                bitmap.Save(confilepath);
                ImageCrop.Visible = true;
                cropimage1.Visible = false;
                dtContact1.Visible = false;
                ImageCrop.ImageUrl = "~/cropimag/" + confilename;
                Session["gambarcoba"] = "~/cropimag/" + confilename;
                lblStatus.ForeColor = System.Drawing.Color.Green;
                lblStatus.Text = "Gambar berhasil di crop";
                //FileUpload2.FileName.Insert = "~/cropimag/" + confilename;
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Harap crop gambar terlebih dahulu";
                btnUpdate.Visible = false;
                ButtonPilih.Visible = false;
                ButtonCrop.Visible = true;
            }

        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            ButtonPilih.Visible = true;
            ButtonCrop.Visible = false;

            user = Session["username"].ToString();
            
            //Image image = Image.FromFile(confilepath);
            /*Byte[] File1;
            Stream s1 = FileUpload1.PostedFile.InputStream;
            BinaryReader br1 = new BinaryReader(s1);
            File1 = br1.ReadBytes((Int32)s1.Length);
            //MemoryStream stream = new MemoryStream();
            //image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //Byte[] File1 = File.ReadAllBytes("~/cropimag/" + confilename);
            //BinaryReader streamreader = new BinaryReader(stream);
            //Response.Write(File1);
            //byte[] data = streamreader.ReadBytes((Int32)stream.Length);
            //Response.Write(Session["gambarcoba"].ToString());
            //if (FileUpload1.HasFile == true)*/
            //{
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("ProUpdateImage", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            //sqlCmd.Parameters.AddWithValue("@Gambar1", File1);
            sqlCmd.Parameters.Add("@Gambar1", SqlDbType.VarChar, 300).Value = Session["gambarcoba"].ToString();
            sqlCmd.Parameters.AddWithValue("@user", user);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            //}
            sqlCon.Open();
            SqlDataAdapter sqlCmd2 = new SqlDataAdapter("ProViewByUser", sqlCon);
            sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd2.SelectCommand.Parameters.AddWithValue("@user", user);
            DataTable dtbl = new DataTable();
            sqlCmd2.Fill(dtbl);
            sqlCon.Close();
            dtContact1.DataSource = dtbl;
            dtContact1.DataBind();
            coordinate_h.Value = "";
            coordinate_w.Value = "";
            coordinate_y.Value = "";
            coordinate_x.Value = "";

            lblStatus.ForeColor = System.Drawing.Color.LightGreen;
            lblStatus.Text = "Gambar berhasil disimpan";
        }

        protected void btnPilih_click(object sender, EventArgs e)
        {

            string uploadFileName = "";
            string uploadFilePath = "";
            if (FileUpload1.HasFile)
            {
                ImageCrop.Visible = false;
                cropimage1.Visible = true;
                dtContact1.Visible = false;
                string ext = Path.GetExtension(FileUpload1.FileName).ToLower();

                if (ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".png")
                {
                    if(FileUpload1.PostedFile.ContentLength < 700000)
                    {
                        uploadFileName = Guid.NewGuid().ToString() + ext;
                        uploadFilePath = Path.Combine(Server.MapPath("~/image"), uploadFileName);
                        try
                        {
                            FileUpload1.SaveAs(uploadFilePath);
                            cropimage1.ImageUrl = "~/image/" + uploadFileName;

                            btnUpdate.Visible = false;
                            ButtonPilih.Visible = false;
                            ButtonCrop.Visible = true;
                            lblStatus.ForeColor = System.Drawing.Color.MediumVioletRed;
                            lblStatus.Text = "Silahkan crop gambar yang akan ditampilkan";
                        }
                        catch (Exception)
                        {
                            lblStatus.Text = "Error! Coba lagi.";
                        }
                    }
                    else
                    {
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        lblStatus.Text = "Maximum size 700kb";
                    }
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "Tipe file tidak diijinkan, Pilih extensi gambar !";
                }
            }
            else
            {
                lblStatus.ForeColor = System.Drawing.Color.Red;
                lblStatus.Text = "Pilih gambar terlebih dahulu";
            }
        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}