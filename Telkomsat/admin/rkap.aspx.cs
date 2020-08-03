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

namespace Telkomsat.admin
{
    public partial class rkap : System.Web.UI.Page
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
            string nominal = txtnominal.Value.Replace(".", "");
            count = Convert.ToInt32(txtcount.Text);
            myket = new string[count];
            myvolume = new string[count];
            tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            query = $@"insert into AdminRKAP(ARK_Aktivitas, ARK_SU, ARK_BG, ARK_CC, ARK_NoA, ARK_NA, ARK_Satuan, ARK_Harga) values
                      ('{txtaktivitas.Value}', '{txtsubunit.Text}', '{txtunit.Text}', '{txtcc.Value}', '{txtnoakun.Value}', '{txtnamaakun.Text}', '{txtsatuan.Text}', '{nominal}'); Select Scope_Identity();";
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
            for (int j = 0; j < count; j++)
            {
                if (myket[j] == "Januari")
                    angkabulan = "1";
                else if (myket[j] == "Februari")
                    angkabulan = "2";
                else if (myket[j] == "Maret")
                    angkabulan = "3";
                else if (myket[j] == "April")
                    angkabulan = "4";
                else if (myket[j] == "Mei")
                    angkabulan = "5";
                else if (myket[j] == "Juni")
                    angkabulan = "6";
                else if (myket[j] == "Juli")
                    angkabulan = "7";
                else if (myket[j] == "Agustus")
                    angkabulan = "8";
                else if (myket[j] == "September")
                    angkabulan = "9";
                else if (myket[j] == "Oktober")
                    angkabulan = "10";
                else if (myket[j] == "November")
                    angkabulan = "11";
                else if (myket[j] == "Desember")
                    angkabulan = "12";

                gt = gt + Convert.ToDouble(myvolume[j]);

                total = Convert.ToDouble(nominal) * Convert.ToDouble(myvolume[j]);
                grandtotal = grandtotal + total;
                sqlCon.Open();
                string queryfile = $@"INSERT INTO AdminRKAPBulanan (ARKB_ARK, ARKB_Volume, ARKB_Bulan, ARKB_Total, ARKB_AB)
                                        VALUES ('{s}', '{myvolume[j]}', '{myket[j]}', {total}, '{angkabulan}')";
                //Response.Write(queryfile); ;
                SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                sqlCmd1.ExecuteNonQuery();
                sqlCon.Close();
            }

            sqlCon.Open();
            string queryupdate = $@"UPDATE AdminRKAP SET ARK_GT='{grandtotal}', ARK_GTS='{grandtotal}', ARK_Tahunan='{gt}' WHERE ARK_ID='{s}'";
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