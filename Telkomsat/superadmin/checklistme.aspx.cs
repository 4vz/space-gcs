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
            if (pic == "ME")
                Button1.Visible = true;
            tablechhk();
        }

        protected void Approveall_Click(object sender, EventArgs e)
        {
            string query, queryuser, myid = "", tanggal, user, queryupdate = "";
            queryuser = $"select alias from Profile where user_name='{Session["username"].ToString()}'";

            DataSet dsuser = Settings.LoadDataSet(queryuser);

            query = $@"select (CAST(d.tanggal AS DATE)) as tanggal from checkme_data d left join Profile p on d.id_profile = p.id_profile
						join checkme_parameter r on r.id_parameter=d.id_parameter where d.approve is null or d.approve = '' 
						group by CAST(d.tanggal AS DATE)  order by CAST(d.tanggal AS DATE) desc";

            DataSet ds = Settings.LoadDataSet(query);

            user = dsuser.Tables[0].Rows[0]["alias"].ToString();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DateTime date1 = (DateTime)ds.Tables[0].Rows[i]["tanggal"];
                    tanggal = date1.ToString("yyyy/MM/dd");
                    myid = $"UPDATE checkme_data SET approve = 'approve', pic = '{user}' where tanggal >= '{tanggal} 00:00:00' and tanggal <= '{tanggal} 23:59:59'";
                    SqlCommand dsapp = Settings.ExNonQuery(myid);
                }
            }
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