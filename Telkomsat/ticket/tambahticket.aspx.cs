using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.Services;
using System.Configuration;

namespace Telkomsat.ticket
{
    public partial class tambahticket : System.Web.UI.Page
    {
        Nullable<int> i = null;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string radio, divisiuser;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["jenis1"].ToString() == "tcc")
            //  spam.Style["display"] = "none";
            txtjenis.Text = Session["jenis1"].ToString();
        }

        protected void submitbtn(object sender, EventArgs e)
        {
            string myquery;
            //optionsRadios1.Checked = true;
            if (Request.Form["ctl00$ContentPlaceHolder1$optionsRadios"] != null)
                radio = Request.Form["ctl00$ContentPlaceHolder1$optionsRadios"].ToString();

            divisiuser = Session["jenis1"].ToString();

            DateTime wib = DateTime.UtcNow + new TimeSpan(7, 0, 0);
            string datetime1 = wib.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand($@"INSERT INTO ticket_user (nama_user, kategori, tanggal, nomor_hp, subject, keterangan, prioritas, status, statusticket, divisiuser, divisireply)
                                            VALUES ('{txtnama.Text}', '{ddlKategori.Text}', '{datetime1}', '{nomor.Value}', '{subject.Value}', '{keterangan.Value}', '{radio}', 'sent', 'unread', '{divisiuser}', '{divisiuser}'); Select Scope_Identity();", sqlCon);
            int i = Convert.ToInt32(sqlCmd.ExecuteScalar());
            sqlCon.Close();
            
            //Response.Write(radio);


            if (FileUpload1.HasFiles)
            {
                string physicalpath = Server.MapPath("~/fileupload/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);

                int filecount = 0;
                foreach(HttpPostedFile file in FileUpload1.PostedFiles)
                {
                    filecount += 1;
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = "~/fileupload/" + filename;
                    file.SaveAs(physicalpath + filename);
                    string s = Convert.ToString(i);
                    sqlCon.Open();
                    string queryfile = $@"INSERT INTO ticket_file (id_ticket, files, namafiles)
                                        VALUES ({s}, '{filepath}', '{filename}')";
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);
                    
                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
                //lblstatus.Text = filecount + " files upload";
                lblstatus.Visible = true;
                lblstatus.Text = " (Ticket Terkirim)";
                lblstatus.ForeColor = System.Drawing.Color.LawnGreen;
            }

            sqlCon.Open();
            myquery = $@"INSERT INTO ticket_status (TS_Tanggal, TS_ticket, TS_Status, TS_Profile)
                        Values ('{datetime1}', '{i}', 'sent', '{txtnama.Text}')";
            SqlCommand sqlCmd5 = new SqlCommand(myquery, sqlCon);

            sqlCmd5.ExecuteNonQuery();
            sqlCon.Close();
        }

        public class inisial
        {
            public string id { get; set; }
            public string nama { get; set; }
            public string nomor { get; set; }
        }

        [WebMethod]
        public static List<inisial> GetProfile(string jenis)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * from ticket_profile where TP_Divisi = '{jenis}'"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                nama = sdr["TP_Nama"].ToString(),
                                id = sdr["TP_ID"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> GetNomor(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * from ticket_profile where TP_ID = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                nomor = sdr["TP_No"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }
    }
}