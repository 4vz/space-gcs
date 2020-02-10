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

namespace Telkomsat.dataasset
{
    public partial class equipment : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", wilayah = "st", style1 = "a", query, divisi = "", style2 = "a", style3, prioritas = "a", statusticket = "a", tanggal, queydel, jenisview = "";



        string statusreply = "a", divisireply = "A";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            tableticket();
        }

        protected void Edit_ServerClick(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string query = $@"UPDATE as_jenis_equipment SET nama_jenis_equipment = '{txtequip.Text}' where id_jenis_equipment = '{txtid.Text}'";
            SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
            Response.Redirect("../dataasset/equipment.aspx");
        }

        public class datawilayah
        {
            public string idwilayah { get; set; }
            public string wilayah { get; set; }
        }

        [WebMethod]
        public static List<datawilayah> GetEquip(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM as_jenis_equipment where id_jenis_equipment = '{videoid}'"))
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
                                idwilayah = sdr["id_jenis_equipment"].ToString(),
                                wilayah = sdr["nama_jenis_equipment"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return dawilayah;
                }
            }
        }

        protected void disp1_ServerClick(object sender, EventArgs e)
        {
            tableticket();
        }

        void tableticket()
        {
            query = "select * from as_jenis_equipment";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Equipment</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_jenis_equipment"].ToString();
                        wilayah = ds.Tables[0].Rows[i]["nama_jenis_equipment"].ToString();
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + wilayah + "</label>" + "</td>");
                        htmlTable.Append($"<td style=\"visibility: {jenisview};\"> " + $"<a onclick=\"confirmdelete('../dataasset/hapus.aspx?idwilayah={IDdata}')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">" + "Delete" + "</a>");
                        htmlTable.Append($"<button type=\"button\"  value=\"{IDdata}\" class=\"btn btn-sm btn-warning datawil\" data-toggle=\"modal\" data-target=\"#modalupdate\" id=\"edit\">" + "Edit" + "</button></td>");
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