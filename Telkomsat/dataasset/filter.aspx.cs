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
using ClosedXML.Excel;
using System.IO;

namespace Telkomsat.dataasset
{
    public partial class filter : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", wilayah = "st", style1 = "a", query, divisi = "", style2 = "a", style3, prioritas = "a", statusticket = "a", tanggal, queydel, jenisview = "";
        string bangunan1, result;
        string statusreply = "a", divisireply = "A";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["ID"] != null)
            {
                IDdata = Request.QueryString["ID"].ToString();

                char[] array = IDdata.ToCharArray();
                for (int i = 0; i < array.Length; i++)
                {
                    char let = array[i];
                    if (let == '-')
                    {
                        array[i] = ' ';
                    }
                    else if (let == '+')
                    {
                        array[i] = '-';
                    }
                }
                result = new string(array);
                lblfilter.Text = "Hasil pencarian " + '"' + result + '"';
                tableticket();
            }
            
        }

        protected void ExportExcel(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = $@"select e.nama_jenis_equipment, d.nama_jenis_device, m.nama_merk, p.tipe_perangkat, p.model,p.pn, p.sn, 
					w.nama_wilayah, b.nama_bangunan, r.nama_ruangan, k.nama_rak, 
					p.satelit, p.tahun_pengadaan, p.fungsi, p.status, p.info, p.tanggal 
                    from as_perangkat p join as_jenis_device d on p.id_jenis_device = d.id_jenis_device left
                    join as_ruangan r on p.id_ruangan = r.id_ruangan left join as_rak k on k.id_rak = p.id_rak join as_bangunan b 
					on b.id_bangunan = r.id_bangunan left join as_merk m on p.id_merk=m.id_merk
                     join as_jenis_equipment e on e.id_jenis_equipment = d.id_jenis_equipment join as_wilayah w on w.id_wilayah = b.id_wilayah where
                        nama_jenis_device LIKE '%' + '{result}' + '%' OR
						nama_wilayah LIKE '%' + '{result}' + '%' OR
						nama_bangunan LIKE '%' + '{result}' + '%' OR
						status LIKE '%' + '{result}' + '%' OR 
						satelit LIKE '%' + '{result}' + '%'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sqlcmd.Connection = con;
                    sda.SelectCommand = sqlcmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Asset");

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=DataAsset.xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                }

            }
        }


        public class inisial
        {
            public string idwilayah { get; set; }
            public string wilayah1 { get; set; }
        }

        [WebMethod]
        public static List<inisial> GetID()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from as_wilayah"))
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
                                idwilayah = sdr["id_wilayah"].ToString(),
                                wilayah1 = sdr["nama_wilayah"].ToString(),
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
            string query = $@"UPDATE as_bangunan SET id_wilayah = '{TextBox2.Text}', nama_bangunan = '{txtwiayah.Text}', tanggal = '{datetime1}' where id_bangunan = '{txtid.Text}'";
            SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
            Response.Redirect("../dataasset/bangunan.aspx");
        }

        public class datawilayah
        {
            public string idbangunan { get; set; }
            public string wilayah { get; set; }
        }

        [WebMethod]
        public static List<datawilayah> GetWilayah(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM as_bangunan where id_bangunan = '{videoid}'"))
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
                                idbangunan = sdr["id_bangunan"].ToString(),
                                wilayah = sdr["nama_bangunan"].ToString(),
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
            query = $@"select w.nama_wilayah, b.nama_bangunan, r.nama_ruangan, k.nama_rak, e.nama_jenis_equipment, b.nama_bangunan, m.nama_merk, d.nama_jenis_device, r.image, p.* 
                    from as_perangkat p join as_jenis_device d on p.id_jenis_device = d.id_jenis_device left
                    join as_ruangan r on p.id_ruangan = r.id_ruangan left join as_rak k on k.id_rak = p.id_rak join as_bangunan b 
					on b.id_bangunan = r.id_bangunan left join as_merk m on p.id_merk=m.id_merk
                     join as_jenis_equipment e on e.id_jenis_equipment = d.id_jenis_equipment join as_wilayah w on w.id_wilayah = b.id_wilayah where
                        nama_jenis_device LIKE '%' + '{result}' + '%' OR
						nama_wilayah LIKE '%' + '{result}' + '%' OR
						nama_bangunan LIKE '%' + '{result}' + '%' OR
						status LIKE '%' + '{result}' + '%' OR 
						satelit LIKE '%' + '{result}' + '%'";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            style3 = "font-weight:normal; font-size:14px;";
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Equipment</th><th>Device</th><th>Merk</th><th>Tipe</th><th>Model</th><th>P/N</th><th>S/N</th><th>Site</th>" +
                 "<th>Gedung</th><th>Ruangan</th><th>Rak</th><th>Fungsi</th><th>Status</th><th>Satelit</th><th>Tahun</th><th>Action</th>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_perangkat"].ToString();
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["nama_jenis_equipment"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["nama_jenis_device"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["nama_merk"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["tipe_perangkat"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["model"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["pn"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["sn"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["nama_wilayah"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["nama_bangunan"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["nama_ruangan"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["nama_rak"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["fungsi"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["status"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["satelit"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["tahun_pengadaan"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + $"<a href=\"../dataasset/detail.aspx?id={IDdata}\" style=\"margin-right:10px\">" + "View" + "</a>" + "</td>");

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