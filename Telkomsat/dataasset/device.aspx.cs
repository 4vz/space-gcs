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
    public partial class device : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", equipment = "st", style1 = "a", query, divisi = "", style2 = "a", style3, prioritas = "a", statusticket = "a", tanggal, queydel, jenisview = "";
        string devices;
        string statusreply = "a", divisireply = "A";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            tableticket();
        }

        public class inisial
        {
            public string idequipment { get; set; }
            public string equipments { get; set; }
        }

        [WebMethod]
        public static List<inisial> GetID()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from as_jenis_equipment"))
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
                                idequipment = sdr["id_jenis_equipment"].ToString(),
                                equipments = sdr["nama_jenis_equipment"].ToString(),
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
            string query = $@"UPDATE as_jenis_device SET id_jenis_device = '{TextBox2.Text}', nama_jenis_device = '{txtwiayah.Text}', tanggal = '{datetime1}' where id_jenis_device = '{txtid.Text}'";
            SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
            Response.Redirect("../dataasset/bangunan.aspx");
        }

        public class datadevice
        {
            public string iddevices { get; set; }
            public string devices { get; set; }
        }

        [WebMethod]
        public static List<datadevice> GetDevice(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM as_jenis_device where id_jenis_device = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<datadevice> dadevices = new List<datadevice>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            dadevices.Add(new datadevice
                            {
                                iddevices = sdr["id_jenis_device"].ToString(),
                                devices = sdr["nama_jenis_device"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return dadevices;
                }
            }
        }

        protected void disp1_ServerClick(object sender, EventArgs e)
        {
            tableticket();
        }

        void tableticket()
        {
            query = @"SELECT d.tanggal, d.id_jenis_device, e.nama_jenis_equipment, d.nama_jenis_device FROM as_jenis_device d join 
                    as_jenis_equipment e on e.id_jenis_equipment = d.id_jenis_equipment";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>Nama Equipment</th><th>Nama Device</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_jenis_device"].ToString();
                        equipment = ds.Tables[0].Rows[i]["nama_jenis_equipment"].ToString();
                        tanggal = ds.Tables[0].Rows[i]["tanggal"].ToString();
                        devices = ds.Tables[0].Rows[i]["nama_jenis_device"].ToString();
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + ds.Tables[0].Rows[i]["tanggal"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + equipment + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + devices + "</label>" + "</td>");
                        htmlTable.Append($"<td style=\"visibility: {jenisview};\"> " + $"<a onclick=\"confirmdelete('../dataasset/hapus.aspx?iddevice={IDdata}')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">" + "Delete" + "</a>");
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