using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat
{
    public partial class listuser : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string kategori, style3, filename, filepath, queryfile;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            referens();
        }

        void referens()
        {
            string query, IDdata, nama, gt, tanggal, jenis, username, previllage;
            query = $"select * from Profile";
            style3 = "font-weight:normal";
            DataSet ds = Settings.LoadDataSet(query);

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Nama</th><th>Username</th><th>Jenis</th><th>Previllage</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_profile"].ToString();
                        nama = ds.Tables[0].Rows[i]["nama"].ToString();
                        username = ds.Tables[0].Rows[i]["user_name"].ToString();
                        previllage = ds.Tables[0].Rows[i]["previllage"].ToString();
                        jenis = ds.Tables[0].Rows[i]["jenis"].ToString();


                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + nama + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + username + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + jenis + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + previllage + "</label>" + "</td>");
                        
                        htmlTable.Append("<td>" + $"<a href=\"detail.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</a>");
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