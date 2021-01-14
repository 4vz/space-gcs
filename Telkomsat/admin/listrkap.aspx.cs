using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;
using System.Web.Services;

namespace Telkomsat.admin
{
    public partial class listrkap : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string query, style3, previllage;
        protected void Page_Load(object sender, EventArgs e)
        {
            string naakun = "", nabulan = "", tahun = "";
            string user = Session["iduser"].ToString();
            string query2 = $"Select * from AdminProfile where AP_Nama = '{user}'";
            DataSet ds = Settings.LoadDataSet(query2);
            tahun = DateTime.Now.ToString("yyyy");

            if (ds.Tables[0].Rows.Count > 0)
            {
                previllage = ds.Tables[0].Rows[0]["AP_Previllage"].ToString();
                if (previllage == "Admin Bendahara" || previllage == "User" || previllage == "SA")
                {
                    btnimport.Visible = true;
                }
            }

            if(Request.QueryString["namaakun"] == null && Request.QueryString["bulan"] == null)
            {
                query = $"SELECT * from AdminRKAP order by ARK_ID desc";
            }
            else
            {
                if (Request.QueryString["namaakun"] != null)
                {
                    naakun = "ARK_NA='" + Request.QueryString["namaakun"] + "'";
                    if (Request.QueryString["namaakun"] == "0")
                        naakun = "ARK_NA=ARK_NA";
                }
                else 
                    naakun = "ARK_NA=ARK_NA";


                if (Request.QueryString["bulan"] != null)
                {
                    nabulan = $"ARK_{Request.QueryString["bulan"].ToString()}>0 and";
                    if (Request.QueryString["bulan"].ToString() == "0")
                        nabulan = "";

                }
                else
                    nabulan = "";

                query = $"SELECT * from AdminRKAP where {nabulan} {naakun} order by ARK_ID desc";

                if (!IsPostBack)
                {
                    txtnamaakun.Text = Request.QueryString["namaakun"].ToString();
                    sobulan.Value = Request.QueryString["bulan"].ToString();
                }
            }


            referens();
        }

        protected void Filter_Click(object sender, EventArgs e)
        {
            string namaakun = "0", bulan = "0";

            if (txtnamaakun.Text != "")
                namaakun = txtnamaakun.Text;

            if (sobulan.Value != "")
                bulan = sobulan.Value;

            Response.Redirect($"listrkap.aspx?namaakun={namaakun}&bulan={bulan}");
        }

        void referens()
        {
            string IDdata, referensi, gt, gts;

            DataSet ds = Settings.LoadDataSet(query);

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>#</th><th>Aktivitas</th><th>Total Awal</th><th>Sisa RKAP</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["ARK_ID"].ToString();
                        referensi = ds.Tables[0].Rows[i]["ARK_Aktivitas"].ToString();
                        gt = Convert.ToInt64(ds.Tables[0].Rows[i]["ARK_GT"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        gts = Convert.ToInt64(ds.Tables[0].Rows[i]["ARK_GTS"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + (i + 1) + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + referensi + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + "Rp. " + gt + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + "Rp. " + gts + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a href=\"detailrkap2.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</a>");

                        if(previllage == "SA")
                        {
                            htmlTable.Append($"<a href=\"editrkap2.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-warning datawil\" >" + "Edit" + "</a>");
                            htmlTable.Append($"<a onclick=\"confirmhapus('action.aspx?idrk={IDdata}')\" class=\"btn btn-sm btn-danger\" id=\"btndelete\">" + "Delete" + "</a>");
                        }
                        if(previllage == "User Organik" || previllage == "GM")
                            htmlTable.Append($"<button type=\"button\"  style=\"margin-right:10px\" value=\"{IDdata}\" class=\"btn btn-sm btn-default datamain\" data-toggle=\"modal\" data-target=\"#modalcarry\" id=\"edit\">" + "Carry Over" + "</button></td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }

        public class inisial
        {
            public string namaakun { get; set; }
            public string bulan { get; set; }

        }


        [WebMethod]
        public static List<inisial> GetNA()
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"select ARK_NA from AdminRKAP  group by ARK_NA"))
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
                                namaakun = sdr["ARK_NA"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> GetBulan(string videoid, string idbulan)
        {
            string constr = System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"select ARK_{idbulan} as bulan from AdminRKAP where ARK_ID = '{videoid}'"))
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
                                bulan = sdr["bulan"].ToString(),
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