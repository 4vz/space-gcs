using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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
            string query, IDdata, referensi, gt;
            query = $"SELECT * from AdminRKAP";

            DataSet ds = Settings.LoadDataSet(query);

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>#</th><th>Aktivitas</th><th>Grand Total</th><th>Action</th></tr>");
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
                        gt = ds.Tables[0].Rows[i]["ARK_GT"].ToString();
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + (i + 1) + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + referensi + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + gt + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a href=\"detailrkap.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</button>");
                        htmlTable.Append($"<a href=\"editrkap.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-warning datawil\" >" + "Edit" + "</button>");
                        htmlTable.Append($"<a onclick=\"confirmdelete('action.aspx?idref={IDdata}&kategori={kategori}')\" class=\"btn btn-sm btn-danger\" id=\"btndelete\">" + "Delete" + "</button></td>");
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