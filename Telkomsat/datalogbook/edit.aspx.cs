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

namespace Telkomsat.datalogbook
{
    public partial class edit : System.Web.UI.Page
    {
        SqlDataAdapter da, da1;
        DataSet ds = new DataSet();
        DataSet dspekerjaan = new DataSet();
        string query, iduser, tanggal, style1, style3, style2, agenda, dataagenda;
        string bwilayah, bruangan, brak, querydetail, queryfungsi, querylain, addwork, idlog;
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["idlog"] != null)
            {
                idlog = Request.QueryString["idlog"].ToString();
            }
            if(!IsPostBack)
            {
                detail();
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
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
                    string queryfile = $@"INSERT INTO table_log_file (id_logbook, files, namafiles, kategori)
                                        VALUES ('{idlog}', '{filepath}', '{filename}', 'utama')";
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }
            divsuccess.Visible = true;
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