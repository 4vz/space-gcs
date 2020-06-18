using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace Telkomsat.datalogbook
{
    public static class HelpernyaWildan
    {
        
        public static bool IsIn(this string ygdicek, string[] daftar)
        {
            bool benarkah = false;

            foreach (string d in daftar)
            {
                if (ygdicek == d)
                {
                    benarkah = true;
                    break;
                }
            }

            return benarkah;
        }


        public static bool NotIsIn(this string ygdicek, string[] daftar)
        {
            bool benarkah = false;

            foreach (string d in daftar)
            {
                if (ygdicek != d)
                {
                    benarkah = true;
                    break;
                }
            }

            return benarkah;
        }
    }

    public partial class edit : System.Web.UI.Page
    {
        SqlDataAdapter da, da1;
        DataSet ds = new DataSet();
        DataSet dspekerjaan = new DataSet();
        string query, iduser, tanggal, style1, style3, style2, agenda, dataagenda;
        string bwilayah, bruangan, brak, querydetail, queryfungsi, querylain, addwork, idlog;
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string[] myket;
        int a = 0;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Form.Enctype = "multipart/form-data";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idlog"] != null)
            {
                idlog = Request.QueryString["idlog"].ToString();
            }
            if(!IsPostBack)
            {
                detail();
                lampiran();
            }
            
        }

        void lampiran()
        {
            SqlDataAdapter da, da1;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            string myquery, query, color, namaall, ext, namafile;

            myquery = $@"select * from table_log_file WHERE  id_logbook = '{idlog}' and kategori='utama'";

            SqlCommand cmd = new SqlCommand(myquery, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable1.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable1.AppendLine("<thead>");
            htmlTable1.AppendLine("<tr><th>File</th><th>Caption</th><th>Action</th>");
            htmlTable1.AppendLine("</tr></thead>");
            htmlTable1.AppendLine("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        namaall = ds.Tables[0].Rows[i]["files"].ToString();
                        namafile = namaall.Replace("~", "..");
                        ext = Path.GetExtension(namaall);
                        htmlTable1.AppendLine($"<tr>");
                        if(ds.Tables[0].Rows[i]["ekstension"].ToString().IsIn(new string[] { ".jpeg", ".png", ".bmp", ".jfif", ".gif", ".jpg", ".PNG" }))
                        {
                            htmlTable1.AppendLine($"<td><img style=\"display:block; padding:10px\" class=\"myImg\" src=\"{namafile}\" height=\"110\" /></td>");
                        }
                        else
                        {
                            htmlTable1.AppendLine($"<td><label style=\"width:100%; white-space:pre-line; font-size:13px\" >{ds.Tables[0].Rows[i]["namafiles"].ToString()}</label></td>");
                        }
                        htmlTable1.AppendLine($"<td><label width:100%; white-space:pre-line; font-size:12px\" >{ds.Tables[0].Rows[i]["caption"].ToString()}</label></td>");
                        htmlTable1.AppendLine($"<td><a onclick=\"confirmhapus('../datalogbook/action.aspx?fileid={ds.Tables[0].Rows[i]["id_file"].ToString()}&idlog={idlog}')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">Delete</a></td>");
                        htmlTable1.AppendLine("</tr>");
                    }
                    htmlTable1.AppendLine("</tbody>");
                    htmlTable1.AppendLine("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable1.ToString() });
                }
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            myket = new string[Request.Files.Count];
            //Response.Write(Request.Files.Count);
            tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            query = $@"update tabel_logbook set
                        judul_logbook = '{txtjudul.Text}',
                        status = '{ddlstatus.Text}',
                        tipe_logbook = '{ddlkategori.Text}',
                        agenda = '{txtAktivitas.Text}',
                        due_date = '{txtduedate.Text}',
                        waktu_action = '{txtstartdate.Text}',
                        pic_internal = '{txtint.Text}',
                        pic_eksternal = '{txtext.Text}',
                        unit = '{ddlunit.Text}'
                        WHERE id_logbook='{idlog}'";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            sqlCon.Close();

            string caption = Request.Form["caption"];
            if (caption != null)
            {
                string[] lines = Regex.Split(caption, ",");

                foreach (string line in lines)
                {
                    myket[a] = line;
                    a++;
                }
            }
            HttpFileCollection filecolln = Request.Files;
            for (int j = 0; j < filecolln.Count; j++)
            {
                HttpPostedFile file = filecolln[j];
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = "~/fileupload/" + filename;
                    string extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("~/fileupload/") + Path.GetFileName(file.FileName));
                    string s = Convert.ToString(i);
                    if (myket[j] == "")
                        myket[j] = filename;
                    sqlCon.Open();
                    string queryfile = $@"INSERT INTO table_log_file (id_logbook, files, namafiles, kategori, ekstension, caption)
                                        VALUES ('{idlog}', '{filepath}', '{filename}', 'utama', '{extension}', '{myket[j]}')";
                    //Response.Write(queryfile); ;
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }

            /*if (FileUpload1.HasFiles)
            {
                string physicalpath = Server.MapPath("~/fileupload/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);

                int filecount = 0;
                foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                {
                    filecount += 1;
                    string filename = Path.GetFileName(file.FileName);
                    string extension = Path.GetExtension(file.FileName);
                    string filepath = "~/fileupload/" + filename;
                    file.SaveAs(physicalpath + filename);
                    string s = Convert.ToString(i);
                    sqlCon.Open();
                    string queryfile = $@"INSERT INTO table_log_file (id_logbook, files, namafiles, kategori, ekstension)
                                        VALUES ('{idlog}', '{filepath}', '{filename}', 'utama', '{extension}')";
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }*/

            string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
            string querylog = $@"Insert into log (id_profile, tanggal, tipe, judul) values
                                ('{iduser}', '{tanggalku}', 'tlog', '{txtjudul.Text}')";
            sqlCon.Open();
            SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
            cmdlog.ExecuteNonQuery();
            sqlCon.Close();
            divsuccess.Visible = true;
            Response.Redirect($"detail.aspx?idlog={idlog}");
        }

        void detail()
        {
            querydetail = $@"select * from tabel_logbook where id_logbook = '{idlog}'";

            SqlCommand cmd = new SqlCommand(querydetail, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            DateTime start = (DateTime)ds.Tables[0].Rows[0]["waktu_action"];
            string mulai = start.ToString("yyyy/MM/dd");
            DateTime end = (DateTime)ds.Tables[0].Rows[0]["due_date"];
            string akhir = end.ToString("yyyy/MM/dd");

            txtjudul.Text = ds.Tables[0].Rows[0]["judul_logbook"].ToString();
            txtstartdate.Text = mulai;
            txtduedate.Text = akhir;
            ddlkategori.Text = ds.Tables[0].Rows[0]["tipe_logbook"].ToString();
            ddlunit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
            ddlstatus.Text = ds.Tables[0].Rows[0]["status"].ToString();
            txtint.Text = ds.Tables[0].Rows[0]["pic_internal"].ToString();
            txtext.Text = ds.Tables[0].Rows[0]["pic_eksternal"].ToString();
            txtAktivitas.Text = ds.Tables[0].Rows[0]["agenda"].ToString();
        }
    }
}