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
    public partial class merk : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", merk1 = "st", style1 = "a", query, divisi = "", style2 = "a", style3, prioritas = "a", statusticket = "a", tanggal, queydel, jenisview = "";
        string device1;
        string qr = "a", divisireply = "A";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            tableticket();
        }

        public class inisial
        {
            public string iddevice { get; set; }
            public string device { get; set; }
        }

        [WebMethod]
        public static List<inisial> GetID()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from as_jenis_device"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                iddevice = sdr["id_jenis_device"].ToString(),
                                device = sdr["nama_jenis_device"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        protected void Edit_ServerClick(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string query = $@"UPDATE as_merk SET id_jenis_device = '{TextBox2.Text}', nama_merk = '{txtwiayah.Text}', tanggal = '{datetime1}' where id_merk = '{txtid.Text}'";
            SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
            Response.Redirect("../dataasset/merk.aspx");
        }

        public class datamerk
        {
            public string idmerk { get; set; }
            public string merk { get; set; }
        }

        [WebMethod]
        public static List<datamerk> Getmerk(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM as_merk where id_merk = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<datamerk> damerk = new List<datamerk>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            damerk.Add(new datamerk
                            {
                                idmerk = sdr["id_merk"].ToString(),
                                merk = sdr["nama_merk"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return damerk;
                }
            }
        }

        protected void disp1_ServerClick(object sender, EventArgs e)
        {
            tableticket();
        }

        void tableticket()
        {
            query = "SELECT b.tanggal, b.id_merk, w.nama_jenis_device, b.nama_merk FROM as_merk b join as_jenis_device w on b.id_jenis_device=w.id_jenis_device ";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>Nama Device</th><th>Nama Merk</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_merk"].ToString();
                        device1 = ds.Tables[0].Rows[i]["nama_jenis_device"].ToString();
                        tanggal = ds.Tables[0].Rows[i]["tanggal"].ToString();
                        merk1 = ds.Tables[0].Rows[i]["nama_merk"].ToString();
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + ds.Tables[0].Rows[i]["tanggal"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + device1 + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + merk1 + "</label>" + "</td>");
                        htmlTable.Append($"<td style=\"visibility: {jenisview};\"> " + $"<a onclick=\"confirmdelete('../dataasset/hapus.aspx?idmerk={IDdata}')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">" + "Delete" + "</a>");
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