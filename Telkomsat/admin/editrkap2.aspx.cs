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
    public partial class editrkap2 : System.Web.UI.Page
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
                        string jan = ds.Tables[0].Rows[0]["ARK_Januari"].ToString();
                        string feb = ds.Tables[0].Rows[0]["ARK_Februari"].ToString();
                        string mar = ds.Tables[0].Rows[0]["ARK_Maret"].ToString();
                        string apr = ds.Tables[0].Rows[0]["ARK_April"].ToString();
                        string mei = ds.Tables[0].Rows[0]["ARK_Mei"].ToString();
                        string jun = ds.Tables[0].Rows[0]["ARK_Juni"].ToString();
                        string jul = ds.Tables[0].Rows[0]["ARK_Juli"].ToString();
                        string agu = ds.Tables[0].Rows[0]["ARK_Agustus"].ToString();
                        string sep = ds.Tables[0].Rows[0]["ARK_September"].ToString();
                        string okt = ds.Tables[0].Rows[0]["ARK_Oktober"].ToString();
                        string nov = ds.Tables[0].Rows[0]["ARK_November"].ToString();
                        string des = ds.Tables[0].Rows[0]["ARK_Desember"].ToString();

                        txtjanuari.Value = jan;
                        txtfebruari.Value = feb;
                        txtmaret.Value = mar;
                        txtapril.Value = apr;
                        txtmei.Value = mei;
                        txtjuni.Value = jun;
                        txtjuli.Value = jul;
                        txtagustus.Value = agu;
                        txtseptember.Value = sep;
                        txtoktober.Value = okt;
                        txtnovemb.Value = nov;
                        txtdesember.Value = des;

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
                        ARK_NA='{txtnamaakun.Text}', ARK_Satuan='{txtsatuan.Text}', ARK_Harga='{nominal}', ARK_Tahunan='{txtvolumetahun.Value}',
                        ARK_Januari='{txtjanuari.Value}', ARK_Februari='{txtfebruari.Value}', ARK_Maret='{txtmaret.Value}', ARK_April='{txtapril.Value}',
                        ARK_Mei='{txtmei.Value}', ARK_Juni='{txtjuni.Value}', ARK_Juli='{txtjuli.Value}', ARK_Agustus='{txtagustus.Value}',
                        ARK_September='{txtseptember.Value}', ARK_Oktober='{txtoktober.Value}', ARK_November='{txtnovemb.Value}', ARK_Desember='{txtdesember.Value}' WHERE ARK_ID='{iddata}'";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            sqlCon.Close();

            /*string querydisplay = $"Select ARK_GT from AdminRKAP Where ARK_ID='{s}'";
            DataSet ds2 = Settings.LoadDataSet(querydisplay);
            string gts = ds2.Tables[0].Rows[0]["ARK_GT"].ToString();

            sqlCon.Open();
            string queryupdate = $@"UPDATE AdminRKAP SET ARK_GTS={grandtotal} WHERE ARK_ID='{iddata}'";
            //Response.Write(queryfile); ;
            SqlCommand sqlCmd2 = new SqlCommand(queryupdate, sqlCon);

            sqlCmd2.ExecuteNonQuery();
            sqlCon.Close();*/
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