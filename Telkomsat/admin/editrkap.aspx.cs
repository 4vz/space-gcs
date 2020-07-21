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
using System.Text;

namespace Telkomsat.admin
{
    public partial class editrkap : System.Web.UI.Page
    {
        string[] myket, myvolume;
        string tanggal, query, angkabulan, query1, iddata;
        double grandtotal;
        StringBuilder htmlTable1 = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnsubmit.UniqueID;
            if (Request.QueryString["id"] != null)
            {
                iddata = Request.QueryString["id"].ToString();
                query1 = $"SELECT * FROM AdminRKAP WHERE ARK_ID = '{iddata}'";
                DataSet ds = Settings.LoadDataSet(query1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!IsPostBack)
                    {
                        txtaktivitas.Value = ds.Tables[0].Rows[0]["ARK_Aktivitas"].ToString();
                        txtcc.Value = ds.Tables[0].Rows[0]["ARK_CC"].ToString();
                        txtnamaakun.Text = ds.Tables[0].Rows[0]["ARK_NA"].ToString();
                        txtnoakun.Value = ds.Tables[0].Rows[0]["ARK_NoA"].ToString();
                        txtnominal.Value = ds.Tables[0].Rows[0]["ARK_Harga"].ToString();
                        txtsatuan.Text = ds.Tables[0].Rows[0]["ARK_Satuan"].ToString();
                        txtsubunit.Text = ds.Tables[0].Rows[0]["ARK_SU"].ToString();
                        txtunit.Text = ds.Tables[0].Rows[0]["ARK_BG"].ToString();
                        txtvolumetahun.Value = ds.Tables[0].Rows[0]["ARK_Tahunan"].ToString();
                    }
                }
            }
            bulanan();
        }

        void bulanan()
        {
            SqlDataAdapter da, da1;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            string myquery, query, color, namaall, ext, namafile;

            myquery = $@"select * from AdminRKAPBulanan WHERE ARKB_ARK = '{iddata}' order by ARKB_AB";

            SqlCommand cmd = new SqlCommand(myquery, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable1.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table-bordered\">");
            htmlTable1.AppendLine("<thead>");
            htmlTable1.AppendLine("<tr><th>Bulan</th><th>Jumlah Volume</th><th>Action</th>");
            htmlTable1.AppendLine("</tr></thead>");
            htmlTable1.AppendLine("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        htmlTable1.AppendLine($"<tr>");
                        htmlTable1.AppendLine($"<td><label width:100%; white-space:pre-line\" >{ds.Tables[0].Rows[i]["ARKB_Bulan"].ToString()}</label></td>");
                        htmlTable1.AppendLine($"<td><input type=\"text\" name=\"lastvalue\" readonly value=\"{ds.Tables[0].Rows[i]["ARKB_Volume"].ToString()}\"/></td>");
                        htmlTable1.AppendLine($"<td><a onclick=\"confirmhapus('../admin/action.aspx?fileid={ds.Tables[0].Rows[i]["ARKB_ID"].ToString()}&idj={iddata}')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">Delete</a></td>");
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
            int count, a = 0, b = 0;
            double total, gt;
            string nominal = txtnominal.Value.Replace(".", "");
            count = Convert.ToInt32(txtcount.Text);
            myket = new string[count];
            myvolume = new string[count];
            tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            query = $@"UPDATE AdminRKAP SET ARK_Aktivitas='{txtaktivitas.Value}', ARK_SU='{txtsubunit.Text}', ARK_BG='{txtunit.Text}', ARK_CC='{txtcc.Value}', ARK_NoA='{txtnoakun.Value}',
                        ARK_NA='{txtnamaakun.Text}', ARK_Satuan='{txtsatuan.Text}', ARK_Harga='{nominal}', ARK_Tahunan='{txtvolumetahun.Value}' WHERE ARK_ID='{iddata}'";
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

                total = Convert.ToDouble(nominal) * Convert.ToDouble(myvolume[j]);
                grandtotal = grandtotal + total;
                sqlCon.Open();
                string queryfile = $@"INSERT INTO AdminRKAPBulanan (ARKB_ARK, ARKB_Volume, ARKB_Bulan, ARKB_Total, ARKB_AB)
                                        VALUES ('{iddata}', '{myvolume[j]}', '{myket[j]}', {total}, '{angkabulan}')";
                //Response.Write(queryfile); ;
                SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                sqlCmd1.ExecuteNonQuery();
                sqlCon.Close();
            }

            sqlCon.Open();
            string queryupdate = $@"UPDATE AdminRKAP SET ARK_GT={grandtotal} WHERE ARK_ID='{iddata}'";
            //Response.Write(queryfile); ;
            SqlCommand sqlCmd2 = new SqlCommand(queryupdate, sqlCon);

            sqlCmd2.ExecuteNonQuery();
            sqlCon.Close();
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