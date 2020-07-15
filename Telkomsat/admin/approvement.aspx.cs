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

namespace Telkomsat.admin
{
    public partial class approvement : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string kategori, style3, warna1, warna2, warna3, warna4, query, previllage;
        protected void Page_Load(object sender, EventArgs e)
        {
            string user, query2;
            user = Session["iduser"].ToString();

            query2 = $"Select * from AdminProfile where AP_Nama = '{user}'";
            DataSet ds2 = Settings.LoadDataSet(query2);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                previllage = ds2.Tables[0].Rows[0]["AP_Previllage"].ToString();
            }

            if (Request.QueryString["jenis"] == "diajukan")
            {
                query = $@"SELECT j.*, e.nama from AdminJustifikasi j join AdminProfile p on p.AP_ID=j.AJ_PT join Profile e
                            on e.id_profile = p.AP_Nama where e.id_profile = '29' and AJ_Status is null or AJ_Status = ''";

                if (previllage != "User")
                    Response.Redirect("dashboard.aspx");
            }
            else if (Request.QueryString["jenis"] == "manager")
            {
                query = $"SELECT * from AdminJustifikasi WHERE AJ_Status = 'diajukan'";

                if (previllage != "Manager")
                    Response.Redirect("dashboard.aspx");
            }
            else if (Request.QueryString["jenis"] == "gm")
            {
                query = $"SELECT * from AdminJustifikasi WHERE AJ_Status = 'manager'";

                if (previllage != "GM")
                    Response.Redirect("dashboard.aspx");
            }
            else if (Request.QueryString["jenis"] == "admin")
            {
                query = $"SELECT * from AdminJustifikasi WHERE AJ_Status = 'gm'";

                if (previllage != "Admin Bendahara")
                    Response.Redirect("dashboard.aspx");
            }
            else
            {
                Response.Redirect("dashboard.aspx");
            }
            referens();
        }

        void referens()
        {
            string IDdata, jupd, ja, kegiatan, status;
            DataSet ds = Settings.LoadDataSet(query);
            style3 = "font-weight:normal";

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Jenis UPD</th><th>Jenis Anggaran</th><th>Nama Kegiatan</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["AJ_ID"].ToString();
                        jupd = ds.Tables[0].Rows[i]["AJ_JUPD"].ToString();
                        ja = ds.Tables[0].Rows[i]["AJ_JA"].ToString();
                        kegiatan = ds.Tables[0].Rows[i]["AJ_NK"].ToString();
                        status = ds.Tables[0].Rows[i]["AJ_NK"].ToString();

                        if (status == "diajukan")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "black";
                            warna3 = "black";
                            warna4 = "black";
                        }
                        else if (status == "manager")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "deepskyblue";
                            warna3 = "black";
                            warna4 = "black";
                        }
                        else if (status == "gm")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "deepskyblue";
                            warna3 = "deepskyblue";
                            warna4 = "black";
                        }
                        else if (status == "admin")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "deepskyblue";
                            warna3 = "deepskyblue";
                            warna4 = "deepskyblue";
                        }
                        else
                        {
                            warna1 = "black";
                            warna2 = "black";
                            warna3 = "black";
                            warna4 = "black";
                        }
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + jupd + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ja + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + kegiatan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<button type=\"button\"  style=\"margin-right:10px\" value=\"{IDdata}\" class=\"btn btn-sm btn-default datamain\" data-toggle=\"modal\" data-target=\"#modalmaintenance\" id=\"edit\">" + "Detail" + "</button>");
                        if(previllage == "user")
                            htmlTable.Append($"<a onclick=\"confirmselesai('action.aspx?idapp={IDdata}&jenis={Request.QueryString["jenis"].ToString()}')\" class=\"btn btn-sm btn-primary\" id=\"btndelete\">" + "Ajukan" + "</a>");
                        else
                            htmlTable.Append($"<a onclick=\"confirmselesai('action.aspx?idapp={IDdata}&jenis={Request.QueryString["jenis"].ToString()}')\" class=\"btn btn-sm btn-primary\" id=\"btndelete\">" + "Approve" + "</a>");

                        htmlTable.Append("</td></tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }

        public class inisial
        {
            public string comply { get; set; }
            public string detail { get; set; }
            public string ja { get; set; }
            public string jupd { get; set; }
            public string ket { get; set; }
            public string nilai { get; set; }
            public string nk { get; set; }
            public string nrkap { get; set; }
            public string nv { get; set; }
            public string pk { get; set; }
            public string tglpt { get; set; }
            public string jabatan { get; set; }
            public string subdit { get; set; }
            public string tgl { get; set; }
            public string naa { get; set; }
            public string tglds { get; set; }
        }

        [WebMethod]
        public static List<inisial> GetDetail(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($@"SELECT j.*, r1.AR_Reference [jabatan], r2.AR_Reference [subdit], e.nama, k.ARK_Aktivitas, k.ARK_NoA, v.AV_Perusahaan, AP_Nama
                                FROM AdminJustifikasi j full join AdminProfile p on j.AJ_PT = p.AP_ID full join AdminReference r1
                                on r1.AR_ID = p.AP_Jabatan full join AdminReference r2 on r2.AR_ID = p.AP_Subdit full join AdminRKAP k
                                on k.ARK_ID = j.AJ_AR full join AdminVendor v on v.AV_ID = j.AJ_AV full join Profile e on e.id_profile = p.AP_Nama WHERE AJ_ID = '{videoid}'"))
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
                                comply = sdr["AJ_Comply"].ToString(),
                                detail = sdr["AJ_Detail"].ToString(),
                                ja = sdr["AJ_JA"].ToString(),
                                jupd = sdr["AJ_JUPD"].ToString(),
                                ket = sdr["AJ_Ket"].ToString(),
                                nilai = sdr["AJ_Nilai"].ToString(),
                                nk = sdr["AJ_NK"].ToString(),
                                nrkap = sdr["AJ_AR"].ToString(),
                                pk = sdr["ARK_Aktivitas"].ToString(),
                                tglpt = sdr["nama"].ToString(),
                                jabatan = sdr["jabatan"].ToString(),
                                subdit = sdr["subdit"].ToString(),
                                nv = sdr["AV_Perusahaan"].ToString(),
                                naa = sdr["ARK_NoA"].ToString(),
                                tgl = sdr["AJ_Tgl"].ToString(),
                                tglds = sdr["AJ_TglDS"].ToString(),

                            });
                        }
                        con.Close();
                        return mydata;
                    }
                }
            }
        }
    }
}