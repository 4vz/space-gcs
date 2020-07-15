using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace Telkomsat.admin
{
    public partial class justifikasi : System.Web.UI.Page
    {
        string[] myket, myvolume;
        string tanggal, query;
        double grandtotal;
        int a = 0;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Form.Enctype = "multipart/form-data";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnsubmit.UniqueID;
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            myket = new string[Request.Files.Count];
            tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            query = $@"insert into AdminJustifikasi(AJ_AR, AJ_AV, AJ_JUPD, AJ_JA, AJ_NK, AJ_NJ, AJ_Comply, AJ_Ket, AJ_Detail, AJ_Tgl, AJ_TglDS, AJ_PT, AJ_Nilai) values
                      ('{txtproker.Text}', '{txtvendor.Text}', '{rdjupd.Text}', '{txtunit.Text}', '{txtnamaket.Value}', '{txtnojus.Value}', '{rdcomply.Text}', '{txtket.Value}', '{txtdetail.Text}', '{txttanggal.Value}', '{txttglpsm.Value}', '{txtpetugas.Text}', '{txtnilai.Value}'); Select Scope_Identity();";
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
                    string queryfile = $@"INSERT INTO AdminEvidence (AE_AJ, AE_File, AE_NamaFile, AE_Ekstension, AE_Caption)
                                        VALUES ('{s}', '{filepath}', '{filename}', '{extension}', '{myket[j]}')";
                    //Response.Write(queryfile); ;
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }

            Response.Redirect("approvement.aspx?jenis=diajukan");
        }

        public class inisial
        {
            public string unit { get; set; }
            public string idproker { get; set; }
            public string proker { get; set; }
            public string gt { get; set; }
            public string idvendor { get; set; }
            public string vendor { get; set; }
            public string idpic { get; set; }
            public string pic { get; set; }
        }

        [WebMethod]
        public static List<inisial> GetUnit()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from AdminReference where AR_Jenis = 'subunit'"))
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
                                unit = sdr["AR_Reference"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> GetProkerHarga(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT ARK_ID, ARK_Aktivitas, ARK_GT from AdminRKAP where ARK_ID='{videoid}'"))
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
                                gt = sdr["ARK_GT"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> GetProker()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT ARK_ID, ARK_Aktivitas, ARK_GT from AdminRKAP"))
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
                                idproker = sdr["ARK_ID"].ToString(),
                                proker = sdr["ARK_Aktivitas"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> GetPIC()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM AdminProfile p join Profile e on e.id_profile=p.AP_Nama"))
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
                                idpic = sdr["AP_ID"].ToString(),
                                pic = sdr["nama"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> GetVendor()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from AdminVendor"))
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
                                idvendor = sdr["AV_ID"].ToString(),
                                vendor = sdr["AV_Perusahaan"].ToString(),
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