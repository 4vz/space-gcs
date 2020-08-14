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

namespace Telkomsat.admin
{
    public partial class listrkap : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string kategori, style3;
        protected void Page_Load(object sender, EventArgs e)
        {
            referens();
        }

        void referens()
        {
            string query, IDdata, referensi, gt, gts;
            query = $"SELECT * from AdminRKAP order by ARK_ID desc";

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
                        gt = Convert.ToInt32(ds.Tables[0].Rows[i]["ARK_GT"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        gts = Convert.ToInt32(ds.Tables[0].Rows[i]["ARK_GTS"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + (i + 1) + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + referensi + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + "Rp. " + gt + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + "Rp. " + gts + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a href=\"detailrkap2.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</button>");
                        htmlTable.Append($"<a href=\"editrkap2.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-warning datawil\" >" + "Edit" + "</button>");
                        htmlTable.Append($"<a onclick=\"confirmhapus('action.aspx?idrk={IDdata}')\" class=\"btn btn-sm btn-danger\" id=\"btndelete\">" + "Delete" + "</button></td>");
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