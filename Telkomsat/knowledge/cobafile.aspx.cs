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

namespace Telkomsat.knowledge
{
    public partial class cobafile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            GridBindFile();
        }
        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            string FN = "";
            FN = Path.GetFileName(fuimage.PostedFile.FileName);
            string contentType = fuimage.PostedFile.ContentType;
            Stream fs = fuimage.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);

            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblFileUpload_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@empid", btnUploadImage.Text == "Save" ? 0 : ViewState["Eid"]);



            if (FN != "")
            {
                //fuimage.SaveAs(Server.MapPath("Uploads" + "\\" + FN));

                cmd.Parameters.AddWithValue("@Nama", FN);
                cmd.Parameters.AddWithValue("@ContentType", contentType);
                cmd.Parameters.AddWithValue("@Data", bytes);
            }

            cmd.ExecuteNonQuery();
            con.Close();
            GridBindFile();
        }


        //Displaying the uploaded files from Database Table in ASP.Net GridView Control

        public void GridBindFile()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblFileUpload_Get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdBindFiles.DataSource = ds;
                grdBindFiles.DataBind();
            }
        }

        /// <summary>
        /// Downloading selected file from Database Table using the Download Button in GridView
        ///The below event handler is fired when the Download LinkButton is clicked inside the GridView Row.
        ///When user click on the row of the gridview control  the ID of the File is determined using the 
        ///CommandArgument property of the LinkButton
        ///and then the File data is fetched from the database like ("Image, Contenttype, Data")
        ///Once the data fetching process is completed the file is sent to the browser for downloading using the 
        ///Response Stream.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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