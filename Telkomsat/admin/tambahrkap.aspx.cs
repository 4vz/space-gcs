using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Services;
using System.Data;

namespace Telkomsat.admin
{
    public partial class tambahrkap : System.Web.UI.Page
    {
        string[] myket, myvolume;
        string tanggal, query, angkabulan;
        double grandtotal, gt;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnsubmit.UniqueID;
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            int count, a = 0, b = 0;
            double total;
            string nominal = txtnominal.Value.Replace(",", "");
            string januari = txtjanuari.Value.Replace(".", "");
            string februari = txtfebruari.Value.Replace(".", "");
            string maret = txtmaret.Value.Replace(".", "");
            string april = txtapril.Value.Replace(".", "");
            string mei = txtmei.Value.Replace(".", "");
            string juni = txtjuni.Value.Replace(".", "");
            string juli = txtjuli.Value.Replace(".", "");
            string agustus = txtagustus.Value.Replace(".", "");
            string september = txtseptember.Value.Replace(".", "");
            string oktober = txtoktober.Value.Replace(".", "");
            string november = txtnovemb.Value.Replace(".", "");
            string desember = txtdesember.Value.Replace(".", "");

            //count = Convert.ToInt32(txtcount.Text);
            string tahun = DateTime.Now.ToString("yyyy");
            myket = new string[12];
            myvolume = new string[12];
            tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            query = $@"insert into AdminRKAP(ARK_Aktivitas, ARK_SU, ARK_BG, ARK_CC, ARK_NoA, ARK_NA, ARK_Satuan, ARK_GT, ARK_Januari, ARK_Februari, ARK_Maret, ARK_April, ARK_Mei, ARK_Juni, ARK_Juli, ARK_Agustus, ARK_September, ARK_Oktober, ARK_November, ARK_Desember, ARK_Tahun, ARK_Kategori, ARK_JP) values
                      ('{txtaktivitas.Value}', '{txtsubunit.Text}', '{txtunit.Text}', '{txtcc.Value}', '{txtnoakun.Value}',
                      '{txtnamaakun.Text}', '{txtsatuan.Text}', '{nominal}', '{januari}', '{februari}',
                      '{maret}', '{april}', '{mei}', '{juni}', '{juli}',
                      '{agustus}', '{september}', '{oktober}', '{november}', '{desember}', '{tahun}', '{sokategori.Value}', '{sojp.Value}'); Select Scope_Identity();";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            sqlCon.Close();

            string bulanan = Request.Form["bulanan"];
            if (bulanan != null)
            {
                string[] lines = Regex.Split(bulanan, ",");

                foreach (string line in lines)
                {
                    myket[a] = line;
                    a++;
                }
            }

            string jumlah = Request.Form["jumlah"];
            if (jumlah != null)
            {
                string[] lines = Regex.Split(jumlah, ",");

                foreach (string line in lines)
                {
                    myvolume[b] = line;
                    b++;
                }
            }

            string s = Convert.ToString(i);
            for (int j = 0; j < 12; j++)
            {
                gt = gt + Convert.ToDouble(myvolume[j]);

                total = Convert.ToDouble(nominal) * Convert.ToDouble(myvolume[j]);
                grandtotal = grandtotal + total;
                
            }
            string querydisplay = $"Select ARK_GT from AdminRKAP Where ARK_ID='{s}'";
            DataSet ds2 = Settings.LoadDataSet(querydisplay);

            string gts = ds2.Tables[0].Rows[0]["ARK_GT"].ToString();

            sqlCon.Open();
            string queryupdate = $@"UPDATE AdminRKAP SET ARK_GTS='{gts}' WHERE ARK_ID='{s}'";
            //Response.Write(queryfile); ;
            SqlCommand sqlCmd2 = new SqlCommand(queryupdate, sqlCon);

            sqlCmd2.ExecuteNonQuery();
            sqlCon.Close();

            divsuccess.Visible = true;
        }

        public class inisial
        {
            public string unit { get; set; }
            public string satuan { get; set; }
            public string subunit { get; set; }
            public string namaakun { get; set; }
        }

        [WebMethod]
        public static List<inisial> GetUnit()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from AdminReference where AR_Jenis = 'unit'"))
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
        public static List<inisial> GetSub()
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
                                subunit = sdr["AR_Reference"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }


        [WebMethod]
        public static List<inisial> GetSatuan()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from AdminReference where AR_Jenis = 'satuan'"))
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
                                satuan = sdr["AR_Reference"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }


        [WebMethod]
        public static List<inisial> GetNamaAkun()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from AdminReference where AR_Jenis = 'namaakun'"))
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
                                namaakun = sdr["AR_Reference"].ToString(),
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