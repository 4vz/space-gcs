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
    public partial class listvendor : System.Web.UI.Page
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
            string query, IDdata, referensi, pic;
            query = $"SELECT * from AdminVendor";

            DataSet ds = Settings.LoadDataSet(query);

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>#</th><th>Nama Vendor</th><th>Nama PIC</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["AV_ID"].ToString();
                        referensi = ds.Tables[0].Rows[i]["AV_Perusahaan"].ToString();
                        pic = ds.Tables[0].Rows[i]["AV_PIC"].ToString();
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + (i + 1) + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + referensi + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + pic + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a href=\"detailvendor.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</button>");
                        htmlTable.Append($"<a href=\"editvendor.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-warning datawil\" >" + "Edit" + "</button>");
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