using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;

namespace Telkomsat.admin
{
    public partial class importrkap : System.Web.UI.Page
    {
        bool format = false;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            sqlCon.Open();
            string querycountf = $"select count(*) from AdminEvidence WHERE AE_Tipe='format_rkap_excel'";
            SqlCommand cmd4 = new SqlCommand(querycountf, sqlCon);
            int output1 = int.Parse(cmd4.ExecuteScalar().ToString());
            sqlCon.Close();

            if (output1 > 0)
            {
                string queryfile = $"select * from AdminEvidence WHERE AE_Tipe='format_rkap_excel'";
                DataList3a.Visible = true;
                sqlCon.Open();
                SqlDataAdapter sqlda1 = new SqlDataAdapter(queryfile, sqlCon);
                DataTable dtbl1 = new DataTable();
                sqlda1.Fill(dtbl1);
                sqlCon.Close();
                DataList3a.DataSource = dtbl1;
                DataList3a.DataBind();
            }
            string user = Session["iduser"].ToString();

            string query2 = $"Select * from AdminProfile where AP_Nama = '{user}'";
            DataSet ds2 = Settings.LoadDataSet(query2);

            string previllage = ds2.Tables[0].Rows[0]["AP_Previllage"].ToString();

            if (previllage == "SA")
            {
                btnupload.Visible = true;
                FileUpload2.Visible = true;
            }
        }

        protected void UploadFormat(object sender, EventArgs e)
        {
            string myquery;
            myquery = "select * from AdminEvidence where AE_Tipe='format_rkap_excel'";

            DataSet ds = Settings.LoadDataSet(myquery);
            HttpFileCollection filecolln = Request.Files;

            if (ds.Tables[0].Rows.Count == 0)
            {
                for (int j = 0; j < filecolln.Count; j++)
                {
                    HttpPostedFile file = filecolln[j];
                    if (file.ContentLength > 0)
                    {
                        string extension = Path.GetExtension(file.FileName);
                        string filename = "format_rkap" + extension;
                        string filepath = "~/fileupload/" + filename + extension;
                        file.SaveAs(Server.MapPath("~/fileupload/") + filename + extension);
                        sqlCon.Open();
                        string queryfile = $@"INSERT INTO AdminEvidence (AE_File, AE_NamaFile, AE_Ekstension, AE_Tipe)
                                    VALUES ('{filepath}', '{filename}', '{extension}', 'format_rkap_excel')";
                        //Response.Write(queryfile); ;
                        SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                        sqlCmd1.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }
            else
            {
                for (int j = 0; j < filecolln.Count; j++)
                {
                    HttpPostedFile file = filecolln[j];
                    if (file.ContentLength > 0)
                    {
                        string filename = "format_rkap.xls";
                        string extension = Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("~/fileupload/") + filename + extension);
                    }
                }
            }

            Response.Redirect(Request.RawUrl);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename="
                + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/fileupload/")
                + e.CommandArgument);
            Response.End();
        }

        protected void Upload(object sender, EventArgs e)
        {
            //Upload and save the file
            string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

            /*if(!extension.IsIn(new string[] { ".xls", "xls", ".xlsx" }))
            {
                goto SkipToEnd;
            }*/
            string excelPath = Server.MapPath("~/fileupload/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(excelPath);

            string conString = string.Empty;
            
            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                    break;
                case ".xlsx": //Excel 07 or higher
                    conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                    break;
                case ".csv": //Excel 07 or higher
                    conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                    break;
                default:
                    {
                        format = true;
                        lblerror.ForeColor = System.Drawing.Color.Red;
                    } break;

            }
            conString = string.Format(conString, excelPath);

            try
            {
                using (OleDbConnection excel_con = new OleDbConnection(conString))
                {
                    excel_con.Open();
                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dtExcelData = new DataTable();

                    //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                    dtExcelData.Columns.AddRange(new DataColumn[22] { new DataColumn("Aktivitas", typeof(string)),
                        new DataColumn("Tahun", typeof(string)),
                        new DataColumn("Subunit", typeof(string)),
                        new DataColumn("Unit", typeof(string)),
                        new DataColumn("Cost Center", typeof(string)),
                        new DataColumn("No Akun", typeof(string)),
                        new DataColumn("Nama Akun", typeof(string)),
                        new DataColumn("Satuan", typeof(string)),
                        new DataColumn("Harga", typeof(string)),
                        new DataColumn("Total", typeof(int)),
                        new DataColumn("Januari", typeof(string)),
                        new DataColumn("Februari", typeof(string)),
                        new DataColumn("Maret", typeof(string)),
                        new DataColumn("April", typeof(string)),
                        new DataColumn("Mei", typeof(string)),
                        new DataColumn("Juni", typeof(string)),
                        new DataColumn("Juli", typeof(string)),
                        new DataColumn("Agustus", typeof(string)),
                        new DataColumn("September", typeof(string)),
                        new DataColumn("Oktober", typeof(string)),
                        new DataColumn("November", typeof(string)),
                        new DataColumn("Desember", typeof(string))});

                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                    }
                    excel_con.Close();

                    string consString = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(consString))
                    {
                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.AdminRKAP";

                            //[OPTIONAL]: Map the Excel columns with that of the database table
                            sqlBulkCopy.ColumnMappings.Add("Tahun", "ARK_Tahun");
                            sqlBulkCopy.ColumnMappings.Add("Aktivitas", "ARK_Aktivitas");
                            sqlBulkCopy.ColumnMappings.Add("SubUnit", "ARK_SU");
                            sqlBulkCopy.ColumnMappings.Add("Unit", "ARK_BG");
                            sqlBulkCopy.ColumnMappings.Add("Cost Center", "ARK_CC");
                            sqlBulkCopy.ColumnMappings.Add("No Akun", "ARK_NoA");
                            sqlBulkCopy.ColumnMappings.Add("Nama Akun", "ARK_NA");
                            sqlBulkCopy.ColumnMappings.Add("Satuan", "ARK_Satuan");
                            sqlBulkCopy.ColumnMappings.Add("Harga", "ARK_Harga");
                            sqlBulkCopy.ColumnMappings.Add("Total", "ARK_GTS");
                            sqlBulkCopy.ColumnMappings.Add("Januari", "ARK_Januari");
                            sqlBulkCopy.ColumnMappings.Add("Februari", "ARK_Februari");
                            sqlBulkCopy.ColumnMappings.Add("Maret", "ARK_Maret");
                            sqlBulkCopy.ColumnMappings.Add("April", "ARK_April");
                            sqlBulkCopy.ColumnMappings.Add("Mei", "ARK_Mei");
                            sqlBulkCopy.ColumnMappings.Add("Juni", "ARK_Juni");
                            sqlBulkCopy.ColumnMappings.Add("Juli", "ARK_Juli");
                            sqlBulkCopy.ColumnMappings.Add("Agustus", "ARK_Agustus");
                            sqlBulkCopy.ColumnMappings.Add("September", "ARK_September");
                            sqlBulkCopy.ColumnMappings.Add("Oktober", "ARK_Oktober");
                            sqlBulkCopy.ColumnMappings.Add("November", "ARK_November");
                            sqlBulkCopy.ColumnMappings.Add("Desember", "ARK_Desember");
                            con.Open();
                            sqlBulkCopy.WriteToServer(dtExcelData);
                            con.Close();
                            lblerror.Text = "Berhasil di import";
                            lblerror.Visible = true;
                            lblerror.ForeColor = System.Drawing.Color.ForestGreen;
                        }
                    }
                }

            }
            catch
            {
                if (!format)
                {
                    lblerror.Text = "Format excel tidak cocok, harap gunakan format .xls apabila masih terjadi kesalahan";
                    lblerror.Visible = true;
                }
                else
                {
                    lblerror.Text = "Format harus ekstensi EXCEL";
                    lblerror.Visible = true;
                }

            }
/*            finally
            {
                lblerror.Text = "Berhasil di import";
                lblerror.Visible = true;
                lblerror.ForeColor = System.Drawing.Color.ForestGreen;
            }*/

        /*SkipToEnd:
            {
                lblerror.Text = "Format harus .xlsx atau .xls";
                lblerror.Visible = true;
                lblerror.ForeColor = System.Drawing.Color.Red;
            }*/

        }
    }
}