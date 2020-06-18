using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.superadmin
{
    public partial class checklistme : System.Web.UI.Page
    {
        string pic;
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryuser;

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            queryuser = $"select approval from Profile where user_name='{Session["username"].ToString()}'";
            SqlCommand cmd2 = new SqlCommand(queryuser, sqlCon);
            sqlCon.Open();
            da = new SqlDataAdapter(cmd2);
            da.Fill(ds);
            sqlCon.Close();
            pic = ds.Tables[0].Rows[0]["approval"].ToString();

            tablechhk();
        }

        void tablechhk()
        {
            string query, tanggal, petugas, waktu;
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            query = $@"select d.tanggal, p.nama, d.waktu from checkme_data d inner join Profile p on d.id_profile = p.id_profile
						where d.approve is null or d.approve = ''
                        group by tanggal, nama, d.waktu order by d.tanggal desc, waktu desc";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Divisi</th><th>Tanggal</th><th>Waktu</th><th>Petugas</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DateTime date1 = (DateTime)ds.Tables[0].Rows[i]["tanggal"];
                        tanggal = date1.ToString("yyyy/MM/dd");
                        petugas = ds.Tables[0].Rows[i]["nama"].ToString();
                        waktu = ds.Tables[0].Rows[i]["waktu"].ToString();

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + "<label class=\"label label-primary\">" + "ME" + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:13px; color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + waktu + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + petugas + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a class=\"btn btn-sm btn-primary\" style=\"cursor:pointer; margin-right:10px\" href=\"../checklistme/dashboard.aspx?waktu={waktu}&tanggal={tanggal}\">" + "view" + "</a>");
                        if (pic == "ME")
                        {
                            htmlTable.Append($"<a onclick=\"confirmselesai('action.aspx?approvalch=me&tanggal={tanggal}&waktu={waktu}&petugas={petugas}')\" class=\"btn btn-sm btn-warning\">" + "Approve" + "</a>");
                        }
                        htmlTable.Append("</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                }
            }
        }
    }
}