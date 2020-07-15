using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat.admin
{
    public partial class listjustifikasi : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string kategori, style3, warna1, warna2, warna3, warna4;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            referens();
        }

        void referens()
        {
            string query, IDdata, jupd, ja, kegiatan, status;
            query = $"SELECT * from AdminJustifikasi";
            style3 = "font-weight:normal";
            DataSet ds = Settings.LoadDataSet(query);

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>#</th><th>Jenis UPD</th><th>Jenis Anggaran</th><th>Nama Kegiatan</th><th>Status Justifikasi</th><th>Action</th></tr>");
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
                        status = ds.Tables[0].Rows[i]["AJ_Status"].ToString();

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
                        htmlTable.Append("<td>" + (i + 1) + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + jupd + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ja + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + kegiatan + "</label>" + "</td>");
                        htmlTable.Append("<td>" +
                            $"<span style=\"margin-right:5px; color:{warna1}\"><i class=\"fa fa-circle\"></i></span>" + $"<span style=\"margin-right:5px; color:{warna2}\"><i class=\"fa fa-circle\"></i></span>" +
                            $"<span style=\"margin-right:5px; color:{warna3}\"><i class=\"fa fa-circle\"></i></span>" + $"<span style=\"margin-right:5px; color:{warna4}\"><i class=\"fa fa-circle\"></i></span>" + "</td>");
                        htmlTable.Append("<td>" + $"<a href=\"detailjustifikasi.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</button>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}