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
    public partial class reference : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string kategori, style3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["kategori"] != null)
                kategori = Request.QueryString["kategori"].ToString();

            Page.Form.DefaultButton = btnsave.UniqueID;

            referens();
        }

        protected void save_click(object sender, EventArgs e)
        {
            string querysave;
            sqlCon.Open();
            querysave = $@"INSERT INTO AdminReference (AR_Reference, AR_Jenis) values
                            ('{txtreference.Text}', '{kategori}')";
            SqlCommand cmd = new SqlCommand(querysave, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            Response.Redirect($"reference.aspx?kategori={kategori}");
        }

        protected void Edit_ServerClick(object sender, EventArgs e)
        {
            string queryedit;
            sqlCon.Open();
            queryedit = $@"UPdate AdminReference SET AR_Reference='{txtreferens.Text}' where AR_ID='{txtid.Text}'";
            SqlCommand cmd = new SqlCommand(queryedit, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            Response.Redirect($"reference.aspx?kategori={kategori}");
        }

        void referens()
        {
            string query, IDdata, referensi, jenis;
            query = $"SELECT * from AdminReference where AR_Jenis = '{kategori}'";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>#</th><th>Nama Referensi</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["AR_ID"].ToString();
                        referensi = ds.Tables[0].Rows[i]["AR_Reference"].ToString();
                        jenis = ds.Tables[0].Rows[i]["AR_Jenis"].ToString();
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + (i + 1) + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + referensi + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<button type=\"button\" value=\"{IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-warning datawil\" data-toggle=\"modal\" data-target=\"#modalupdate\" id=\"edit\">" + "Edit" + "</button>");
                        htmlTable.Append($"<a onclick=\"confirmdelete('action.aspx?idref={IDdata}&kategori={kategori}')\" class=\"btn btn-sm btn-danger\" id=\"btndelete\">" + "Delete" + "</button></td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }

        public class datawilayah
        {
            public string idreferensi { get; set; }
            public string referensi { get; set; }
        }

        [WebMethod]
        public static List<datawilayah> GetREferensi(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM AdminReference where AR_ID = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<datawilayah> dawilayah = new List<datawilayah>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            dawilayah.Add(new datawilayah
                            {
                                idreferensi = sdr["AR_ID"].ToString(),
                                referensi = sdr["AR_Reference"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return dawilayah;
                }
            }
        }
    }
}