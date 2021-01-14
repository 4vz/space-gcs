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
using System.Globalization;

namespace Telkomsat.admin
{
    public partial class detailjustifikasi : System.Web.UI.Page
    {
        string[] myket, myvolume;
        string tanggal, query, iddata, query1, style3;
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        StringBuilder htmlTable2 = new StringBuilder();
        double grandtotal;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                iddata = Request.QueryString["id"].ToString();

                query1 = $@"SELECT j.*, r1.AR_Reference [jabatan], r2.AR_Reference [subdit], e.nama, k.ARK_Aktivitas, k.ARK_NoA, v.AV_Perusahaan, AP_Nama, k.ARK_GT
                                FROM AdminJustifikasi j full join AdminProfile p on j.AJ_PT=p.AP_ID full join AdminReference r1
                                on r1.AR_ID = p.AP_Jabatan full join AdminReference r2 on r2.AR_ID = p.AP_Subdit full join AdminRKAP k
                                on k.ARK_ID = j.AJ_AR full join AdminVendor v on v.AV_ID=j.AJ_AV full join Profile e on e.id_profile=p.AP_Nama WHERE AJ_ID = '{iddata}'";
                DataSet ds = Settings.LoadDataSet(query1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!IsPostBack)
                    {
                        lbldetail.Text = ds.Tables[0].Rows[0]["AJ_Detail"].ToString();
                        lblja.Text = ds.Tables[0].Rows[0]["AJ_JA"].ToString();
                        lbljupd.Text = ds.Tables[0].Rows[0]["AJ_JUPD"].ToString();
                        lblket.Text = ds.Tables[0].Rows[0]["AJ_Ket"].ToString();
                        lblnilai.Text = Convert.ToInt32(ds.Tables[0].Rows[0]["AJ_Nilai"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        lblnk.Text = ds.Tables[0].Rows[0]["AJ_NK"].ToString();
                        if (ds.Tables[0].Rows[0]["ARK_GT"].ToString() == "" || ds.Tables[0].Rows[0]["ARK_GT"].ToString() == null)
                        {

                        }
                        else
                        {
                            lblnrkap.Text = Convert.ToInt32(ds.Tables[0].Rows[0]["ARK_GT"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        }
                        lblnojus.Text = ds.Tables[0].Rows[0]["AJ_NJ"].ToString();
                        lblpk.Text = ds.Tables[0].Rows[0]["ARK_Aktivitas"].ToString();
                        
                        lbltglpt.Text = ds.Tables[0].Rows[0]["nama"].ToString();
                        lbljabatan.Text = ds.Tables[0].Rows[0]["jabatan"].ToString();
                        lblsubdit.Text = ds.Tables[0].Rows[0]["subdit"].ToString();
                        lblnaa.Text = ds.Tables[0].Rows[0]["ARK_NoA"].ToString();
                        DateTime tgl = (DateTime)ds.Tables[0].Rows[0]["AJ_Tgl"];
                        DateTime tglds = (DateTime)ds.Tables[0].Rows[0]["AJ_TglDS"];

                        lbltglds.Text = tglds.ToString("dd MMM yyyy");
                        lbltgl.Text = tgl.ToString("dd MMM yyyy");
                    }

                }

                referens();
            }
            riwayat();
            mytable();

            sqlCon.Open();
            string querycountf = $"select count(*) from AdminEvidence WHERE AE_AJ = '{iddata}'";
            SqlCommand cmd4 = new SqlCommand(querycountf, sqlCon);
            int output1 = int.Parse(cmd4.ExecuteScalar().ToString());
            sqlCon.Close();

            if (output1 >= 1)
            {
                string queryfile = $"select * from AdminEvidence WHERE AE_AJ = '{iddata}' and (AE_Ekstension not in ('.jpeg', '.png', '.bmp', '.jfif', '.gif', '.jpg'))";
                DataList3a.Visible = true;
                sqlCon.Open();
                SqlDataAdapter sqlda1 = new SqlDataAdapter(queryfile, sqlCon);
                DataTable dtbl1 = new DataTable();
                sqlda1.Fill(dtbl1);
                sqlCon.Close();
                DataList3a.DataSource = dtbl1;
                DataList3a.DataBind();
            }
        }

        void riwayat()
        {
            string query = $"SELECT * from AdminApprove where AA_AJ = '{iddata}' order by AA_ID desc";
            DataSet ds = Settings.LoadDataSet(query);
            htmlTable2.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable2.Append("<thead>");
            htmlTable2.Append("<tr><td>Tanggal</td><td>Approval</td><td>Status</td><td>Keterangan</td></tr>");
            htmlTable2.Append("</thead>");

            htmlTable2.Append("<tbody>");

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["AA_Tanggal"]);
                    string tanggal = dt.ToString("dd MMM yyyy");
                    string approve = ds.Tables[0].Rows[i]["AA_Aksi"].ToString();
                    string person = ds.Tables[0].Rows[i]["AA_Person"].ToString();
                    string keterangan = ds.Tables[0].Rows[i]["AA_Alasan"].ToString();
                    htmlTable2.Append("<tr>");
                    htmlTable2.Append("<td>" + $"<label style=\"{style3}\">" + tanggal + "</label>" + "</td>");
                    htmlTable2.Append("<td>" + $"<label style=\"{style3}\">" + person + "</label>" + "</td>");
                    htmlTable2.Append("<td>" + $"<label style=\"{style3}\">" + approve + "</label>" + "</td>");
                    htmlTable2.Append("<td>" + $"<label style=\"{style3}\">" + keterangan + "</label>" + "</td>");
                    htmlTable2.Append("</tr>");
                }
                htmlTable2.Append("</tbody>");
                htmlTable2.Append("</table>");
                PlaceHolder2.Controls.Add(new Literal { Text = htmlTable2.ToString() });
            }
        }


        void mytable()
        {
            string myquery, query, color, namaall, ext, namafile;

            myquery = $@"select * from AdminEvidence WHERE  AE_AJ = '{iddata}' and (AE_Ekstension in ('.jpeg', '.png', '.bmp', '.jfif', '.gif', '.jpg', '.PNG'))";

            DataSet ds2 = Settings.LoadDataSet(myquery);

            htmlTable1.AppendLine("<ul>");
            if (!object.Equals(ds2.Tables[0], null))
            {
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        namaall = ds2.Tables[0].Rows[i]["AE_File"].ToString();
                        namafile = namaall.Replace("~", "..");
                        ext = Path.GetExtension(namaall);
                        htmlTable1.AppendLine($"<li class=\"gambar\"><img style=\"display:block\" class=\"myImg\" src=\"{namafile}\" height=\"200\" /><br />" +
                            $"<label style=\"text-align:center; width:100%; white-space:pre-line; font-size:11px\" >{ds2.Tables[0].Rows[i]["AE_Caption"].ToString()}</label></li>");
                    }
                    htmlTable1.AppendLine("</ul>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable1.ToString() });
                }
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editjustifikasi.aspx?id={iddata}");
        }

        void referens()
        {
            string query, IDdata, jupd, ja, kegiatan, status, query5, previllage, query7;

            query5 = $"select p.*, e.alias, e.nama from AdminProfile p join Profile e on e.id_profile=p.AP_Nama";
            DataSet ds5 = Settings.LoadDataSet(query5);

            if(ds5.Tables[0].Rows.Count > 0)
            {
                for(int i = 0; i < ds5.Tables[0].Rows.Count; i++)
                {
                    previllage = ds5.Tables[0].Rows[i]["AP_Previllage"].ToString();

                    if (previllage == "GM")
                        lblnamagm.Text = ds5.Tables[0].Rows[i]["nama"].ToString();
                    else if (previllage == "Admin Bendahara")
                        lblnamaadmin.Text = ds5.Tables[0].Rows[i]["nama"].ToString();
                }
                
            }

            query7 = @"SELECT (select alias from AdminProfile p join Profile e on e.id_profile=p.AP_Nama where p.AP_Previllage='Manager' ) [manager],
				(select alias from AdminProfile p join Profile e on e.id_profile=p.AP_Nama where p.AP_Previllage='GM' ) [gm],
				(select alias from AdminProfile p join Profile e on e.id_profile=p.AP_Nama where p.AP_Previllage='Admin Bendahara' ) [admin]";
            DataSet ds7 = Settings.LoadDataSet(query7);

            query = $"SELECT * from AdminJustifikasi WHERE AJ_ID = '{iddata}'";
            style3 = "font-weight:normal";
            DataSet ds = Settings.LoadDataSet(query);

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
                        status = ds.Tables[0].Rows[i]["AJ_Status"].ToString();

                        if (status == "gm")
                        {
                            lblgm.Text = ds7.Tables[0].Rows[0]["gm"].ToString();
                        }
                        else if (status == "admin")
                        {
                            lblgm.Text = ds7.Tables[0].Rows[0]["gm"].ToString();
                            lblbendahara.Text = ds7.Tables[0].Rows[0]["admin"].ToString();
                            Button1.Visible = false;
                        }
                    }
                }
            }
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename="
                + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/fileupload/")
                + e.CommandArgument);
            Response.End();
        }
    }
}