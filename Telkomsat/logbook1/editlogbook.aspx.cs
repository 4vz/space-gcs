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

namespace Telkomsat.logbook1
{
    public partial class editlogbook : System.Web.UI.Page
    {
        Nullable<int> i = null;
        Nullable<int> j = null;
        string tanggal;
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string formattanggal = Session["tanggal"].ToString();
                //DateTime newFormat = DateTime.ParseExact("09/12/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
                string tanggalnew = Convert.ToDateTime(formattanggal).ToString("yyyy/MM/dd");
                hfContactID.Value = Session["hf"].ToString();
                txtTanggal.Text = Convert.ToDateTime(formattanggal).ToString("dd/MM/yyyy");
                txtEvent.Text = Session["event"].ToString();
                ddlUnit.Text = Session["unit"].ToString();
                ddlStatus.Text = Session["status"].ToString();
                txtOG.Text = Session["OG"].ToString();
                txtOS.Text = Session["OS"].ToString();
                txtInfo.Text = Session["info"].ToString();
                txtSN.Text = Session["SN"].ToString();
                txtSN2.Text = Session["SN"].ToString();
                txtSN3.Text = Session["SN1"].ToString();
                txtHarga.Text = Session["estimasi"].ToString();
                ddlKategori.Text = Session["kategori"].ToString();

                    

                //labelID.Visible = true;

            }

            //Response.Write(Convert.ToDateTime(txtTanggal.Text).ToString("yyyy/MM/dd"));
            int ID = Convert.ToInt32(hfContactID.Value);
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("LoViewByIDSorting", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            dtContact.DataSource = dtbl;
            dtContact.DataBind();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {


            hfContactID.Value = Session["hf"].ToString();

            tanggal = Convert.ToDateTime(txtTanggal.Text).ToString("yyyy/MM/dd");
            Byte[] File1, File2, image1, image2, image3, image4;
            Stream s1 = FileUpload1.PostedFile.InputStream;
            Stream s2 = FileUpload2.PostedFile.InputStream;
            Stream i1 = ImgUpload1.PostedFile.InputStream;
            Stream i2 = ImgUpload2.PostedFile.InputStream;
            Stream i3 = ImgUpload3.PostedFile.InputStream;
            Stream i4 = ImgUpload4.PostedFile.InputStream;
            BinaryReader br1 = new BinaryReader(s1);
            BinaryReader br2 = new BinaryReader(s2);
            BinaryReader bri1 = new BinaryReader(i1);
            BinaryReader bri2 = new BinaryReader(i2);
            BinaryReader bri3 = new BinaryReader(i1);
            BinaryReader bri4 = new BinaryReader(i2);
            File1 = br1.ReadBytes((Int32)s1.Length);
            File2 = br2.ReadBytes((Int32)s2.Length);
            image1 = bri1.ReadBytes((Int32)i1.Length);
            image2 = bri2.ReadBytes((Int32)i2.Length);
            image3 = bri3.ReadBytes((Int32)i3.Length);
            image4 = bri4.ReadBytes((Int32)i4.Length);
            if (ImgUpload1.HasFile == true || ImgUpload2.HasFile == true ||
                ImgUpload1.HasFile == true || ImgUpload2.HasFile == true)
            {
                sqlCon2.Open();
                SqlCommand sqlCmd1 = new SqlCommand("LoAddGambar", sqlCon2);
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@File1", File1);
                sqlCmd1.Parameters.AddWithValue("@File2", File2);
                sqlCmd1.Parameters.AddWithValue("@Gambar1", image1);
                sqlCmd1.Parameters.AddWithValue("@Gambar2", image2);
                sqlCmd1.Parameters.AddWithValue("@Gambar3", image3);
                sqlCmd1.Parameters.AddWithValue("@Gambar4", image4);

                i = Convert.ToInt32(sqlCmd1.ExecuteScalar());
            }

            if (FileUpload1.HasFile == true || FileUpload2.HasFile == true)
            {
                string FN = "";
                FN = Path.GetFileName(FileUpload1.PostedFile.FileName);
                sqlCon2.Close();
                sqlCon2.Open();
                SqlCommand sqlCmd2 = new SqlCommand("LoAddFile", sqlCon2);
                sqlCmd2.CommandType = CommandType.StoredProcedure;
                sqlCmd2.Parameters.AddWithValue("@Nama", FN);
                sqlCmd2.Parameters.AddWithValue("@File1", File1);
                sqlCmd2.Parameters.AddWithValue("@File2", File2);

                j = Convert.ToInt32(sqlCmd2.ExecuteScalar());
            }

            sqlCon2.Close();
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlCommand sqlCmd = new SqlCommand("LoUpdateLogbook", sqlCon2);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID_Log", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
            if (ImgUpload1.HasFile == false && ImgUpload2.HasFile == false &&
                ImgUpload1.HasFile == false && ImgUpload2.HasFile == false)
            {
                sqlCmd.Parameters.AddWithValue("@ID_gb", DBNull.Value);
            }
            else if (ImgUpload1.HasFile == true || ImgUpload2.HasFile == true ||
                ImgUpload1.HasFile == true || ImgUpload2.HasFile == true)
            {
                sqlCmd.Parameters.AddWithValue("@ID_gb", i);
            }

            if (FileUpload1.HasFile == false && FileUpload2.HasFile == false)
            {
                sqlCmd.Parameters.AddWithValue("@ID_file", DBNull.Value);
            }
            else if (FileUpload1.HasFile == true || FileUpload2.HasFile == true)
            {
                sqlCmd.Parameters.AddWithValue("@ID_file", j);
            }

            sqlCmd.Parameters.AddWithValue("@Tanggal", tanggal);
            sqlCmd.Parameters.AddWithValue("@Event", txtEvent.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PIC_OG", txtOG.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@PIC_OS", txtOS.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Info", txtInfo.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Status", ddlStatus.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@Unit", ddlUnit.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@kategori", ddlKategori.Text.Trim());
            if (ddlKategori.Text == "Penggantian")
                sqlCmd.Parameters.AddWithValue("@SN", txtSN2.Text.Trim());
            else
            {
                if (txtSN.Visible = false || txtSN.Text == "")
                    sqlCmd.Parameters.AddWithValue("@SN", "");
                else
                    sqlCmd.Parameters.AddWithValue("@SN", txtSN.Text);
            }

            sqlCmd.Parameters.AddWithValue("@SN1", txtSN3.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@estimasi", txtHarga.Text.Trim());
            
            sqlCmd.ExecuteNonQuery();
            sqlCon2.Close();
            lblUpdate.Text = "Update Berhasil";
            lblUpdate.ForeColor = System.Drawing.Color.LawnGreen;

            int ID = Convert.ToInt32(hfContactID.Value);
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("LoViewByIDSorting", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            dtContact.DataSource = dtbl;
            dtContact.DataBind();

            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlCommand cmd = new SqlCommand("LoViewByID", sqlCon2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter sqlda1 = new SqlDataAdapter(cmd);
            sqlda1.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda1.Fill(dt);
            gvLog.DataSource = dt;
            gvLog.DataBind();
            sqlCon2.Close();

        }

        protected void gvLog_PreRender(object sender, EventArgs e)
        {
            //lblPage.Text = "Menampilkan halaman " + (gvLog.PageIndex + 1).ToString() + " dari " + gvLog.PageCount.ToString();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            hfContactID.Value = Session["hf"].ToString();
            int ID = Convert.ToInt32(hfContactID.Value);

            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlCommand sqlCmd = new SqlCommand("LoDelete", sqlCon2);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@ID", ID);
            sqlCmd.ExecuteNonQuery();
            sqlCon2.Close();
            txtEvent.Visible = false;
            txtInfo.Visible = false;
            txtOG.Visible = false;
            txtOS.Visible = false;
            txtSN.Visible = false;
            txtTanggal.Visible = false;
            ddlKategori.Visible = false;
            ddlStatus.Visible = false;
            ddlUnit.Visible = false;
            lblUpdate.Visible = true;
            lblUpdate.ForeColor = System.Drawing.Color.IndianRed;
            lblUpdate.Text = "Delete Sukses";
        }

        protected void gvLog_RowData(object sender, GridViewRowEventArgs e)
        {
            for (int rowindex = gvLog.Rows.Count - 2; rowindex >= 0; rowindex--)
            {
                GridViewRow rows = gvLog.Rows[rowindex];
                GridViewRow previousrows = gvLog.Rows[rowindex + 1];

                if (rows.Cells[1].Text == previousrows.Cells[1].Text)
                {
                    rows.Cells[1].RowSpan = previousrows.Cells[1].RowSpan < 2 ? 2 :
                        previousrows.Cells[1].RowSpan + 1;
                    previousrows.Cells[1].Visible = false;
                }
            }

            for (int rowindex = gvLog.Rows.Count - 2; rowindex >= 0; rowindex--)
            {
                GridViewRow rows = gvLog.Rows[rowindex];
                GridViewRow previousrows = gvLog.Rows[rowindex + 1];

                if (rows.Cells[0].Text == previousrows.Cells[0].Text)
                {
                    rows.Cells[0].RowSpan = previousrows.Cells[0].RowSpan < 2 ? 2 :
                        previousrows.Cells[0].RowSpan + 1;
                    previousrows.Cells[0].Visible = false;
                }
            }
        }
    }
}