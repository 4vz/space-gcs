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
using System.Text;

namespace Telkomsat.admin
{
    public partial class editjustifikasi : System.Web.UI.Page
    {
        string[] myket, myvolume;
        string tanggal, query, iddata;
        double grandtotal;
        StringBuilder htmlTable1 = new StringBuilder();
        int a = 0;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Form.Enctype = "multipart/form-data";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string query1;
            Page.Form.DefaultButton = btnsubmit.UniqueID;
            if (Request.QueryString["id"] != null)
            {
                iddata = Request.QueryString["id"].ToString();

                query1 = $@"SELECT j.*, r1.AR_Reference [jabatan], r2.AR_Reference [subdit], e.nama, k.ARK_Aktivitas, k.ARK_NoA, v.AV_Perusahaan, AP_Nama, AP_ID, k.ARK_GTS
                                FROM AdminJustifikasi j full join AdminProfile p on j.AJ_PT=p.AP_ID full join AdminReference r1
                                on r1.AR_ID = p.AP_Jabatan full join AdminReference r2 on r2.AR_ID = p.AP_Subdit full join AdminRKAP k
                                on k.ARK_ID = j.AJ_AR full join AdminVendor v on v.AV_ID=j.AJ_AV full join Profile e on e.id_profile=p.AP_Nama WHERE AJ_ID = '{iddata}'";

                DataSet ds = Settings.LoadDataSet(query1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!IsPostBack)
                    {
                        DateTime start = (DateTime)ds.Tables[0].Rows[0]["AJ_Tgl"];
                        DateTime tglds = (DateTime)ds.Tables[0].Rows[0]["AJ_TglDS"];

                        txtdetail.Text = ds.Tables[0].Rows[0]["AJ_Detail"].ToString();
                        txtket.Value = ds.Tables[0].Rows[0]["AJ_Ket"].ToString();
                        txtnamaket.Value = ds.Tables[0].Rows[0]["AJ_NK"].ToString();
                        txtnilairkap.Value = "Rp. " + ds.Tables[0].Rows[0]["ARK_GTS"].ToString();
                        txtnilai.Value = ds.Tables[0].Rows[0]["AJ_Nilai"].ToString();
                        lblnj.Text = ds.Tables[0].Rows[0]["AJ_NJ"].ToString();
                        txtpetugas.Text = ds.Tables[0].Rows[0]["AP_ID"].ToString();
                        txtproker.Text = ds.Tables[0].Rows[0]["AJ_AR"].ToString();
                        txttglpsm.Value = tglds.ToString("yyyy/MM/dd");
                        txtunit.Text = ds.Tables[0].Rows[0]["AJ_JA"].ToString();
                        txtvendor.Text = ds.Tables[0].Rows[0]["AJ_AV"].ToString();
                        rdjupd.Text = ds.Tables[0].Rows[0]["AJ_JUPD"].ToString();
                    }

                }
                lampiran();
            } 
        }

        void lampiran()
        {
            SqlDataAdapter da, da1;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            string myquery, query, color, namaall, ext, namafile;

            myquery = $@"select * from AdminEvidence WHERE  AE_AJ = '{iddata}'";

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
                        namaall = ds.Tables[0].Rows[i]["AE_File"].ToString();
                        namafile = namaall.Replace("~", "..");
                        ext = Path.GetExtension(namaall);
                        htmlTable1.AppendLine($"<tr>");
                        if (ds.Tables[0].Rows[i]["AE_Ekstension"].ToString().IsIn(new string[] { ".jpeg", ".png", ".bmp", ".jfif", ".gif", ".jpg", ".PNG" }))
                        {
                            htmlTable1.AppendLine($"<td><img style=\"display:block; padding:10px\" class=\"myImg\" src=\"{namafile}\" height=\"110\" /></td>");
                        }
                        else
                        {
                            htmlTable1.AppendLine($"<td><label style=\"width:100%; white-space:pre-line; font-size:13px\" >{ds.Tables[0].Rows[i]["AE_NamaFile"].ToString()}</label></td>");
                        }
                        htmlTable1.AppendLine($"<td><label width:100%; white-space:pre-line; font-size:12px\" >{ds.Tables[0].Rows[i]["AE_Caption"].ToString()}</label></td>");
                        htmlTable1.AppendLine($"<td><a onclick=\"confirmhapus('../admin/action.aspx?fileid={ds.Tables[0].Rows[i]["AE_ID"].ToString()}&idj={iddata}')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">Delete</a></td>");
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
            double dbnilai;

            dbnilai = Convert.ToDouble(txtnilai.Value.Replace(".", ""));
            myket = new string[Request.Files.Count];
            tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            if (Request.QueryString["perbaikan"] == null)
            {
                query = $@"UPDATE AdminJustifikasi SET AJ_AR='{txtproker.Text}', AJ_AV='{txtvendor.Text}', AJ_JUPD='{rdjupd.Text}', AJ_JA='{txtunit.Text}', AJ_NK='{txtnamaket.Value}',
                            AJ_KET='{txtket.Value}', AJ_Detail='{txtdetail.Text}',
                            AJ_TglDS='{txttglpsm.Value}', AJ_PT='{txtpetugas.Text}', AJ_Nilai='{dbnilai}' WHERE AJ_ID='{iddata}'";
            }
            else
            {
                query = $@"UPDATE AdminJustifikasi SET AJ_AR='{txtproker.Text}', AJ_AV='{txtvendor.Text}', AJ_JUPD='{rdjupd.Text}', AJ_JA='{txtunit.Text}', AJ_NK='{txtnamaket.Value}',
                            AJ_KET='{txtket.Value}', AJ_Detail='{txtdetail.Text}',
                            AJ_TglDS='{txttglpsm.Value}', AJ_PT='{txtpetugas.Text}', AJ_Nilai='{dbnilai}', AJ_Status='diajukan' WHERE AJ_ID='{iddata}'";
            }

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
                                        VALUES ('{iddata}', '{filepath}', '{filename}', '{extension}', '{myket[j]}')";
                    //Response.Write(queryfile); ;
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
            }

            if (Request.QueryString["perbaikan"] == null)
                Response.Redirect("listjustifikasi.aspx");
            else
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