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
    public partial class searchby : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", bangunan = "st", style1 = "a", query, divisi = "", style2 = "a", style3, prioritas = "a", statusticket = "a", tanggal, queydel, jenisview = "";
        string ruangan1;
        string qr = "a", divisireply = "A";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = Button1.UniqueID;
        }

        protected void ExportExcel(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand sqlcmd = new SqlCommand("asset_searchby12", sqlCon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                if (txtdevice1.Text != "")
                {
                    sqlcmd.Parameters.AddWithValue("@device", txtdevice1.Text);
                }
                if (txtmerk.Text != "")
                {
                    sqlcmd.Parameters.AddWithValue("@merk", txtmerk.Text);
                }
                if (txtsn.Text != "")
                {
                    sqlcmd.Parameters.AddWithValue("@sn", txtsn.Text);
                }
                if (txfungsi.Text != "")
                {
                    sqlcmd.Parameters.AddWithValue("@fungsi", txfungsi.Text);
                }
                if (txstatus.Text != "")
                {
                    sqlcmd.Parameters.AddWithValue("@status", txstatus.Text);
                }
                if (txtwilaya.Text != "")
                {
                    sqlcmd.Parameters.AddWithValue("@wilayah", txtwilaya.Text);
                }
                if (txtruang.Text != "")
                {
                    sqlcmd.Parameters.AddWithValue("@ruang", txtruang.Text);
                }

                if (txtmulai.Text != "")
                {
                    sqlcmd.Parameters.AddWithValue("@awal", txtmulai.Text);
                }
                if (txtsampai.Text != "")
                {
                    sqlcmd.Parameters.AddWithValue("@akhir", txtsampai.Text);
                }
                else
                {
                    sqlcmd.Parameters.AddWithValue("@akhir", txtmulai.Text);
                }
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
            public string ruangan { get; set; }
        }

        [WebMethod]
        public static List<inisial> Getruangan(string term)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"select nama_ruangan from as_ruangan where nama_ruangan like '%' + '{term}' + '%' "))
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
                                ruangan = sdr["nama_ruangan"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public List<string> GetStudentNames(string term)
        {
            List<string> listStudentNames = new List<string>();

            string cs = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand($"select nama_ruangan from as_ruangan where nama_ruangan like '%' + '{term}' + '%' ", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    listStudentNames.Add(rdr["nama_ruangan"].ToString());
                }
            }

            return listStudentNames;
        }


        protected void Filter_Click(object sender, EventArgs e)
        {
            tableticket();
        }

        void tableticket()
        {
            sqlCon.Open();
            SqlCommand sqlcmd = new SqlCommand("aset_searchby", sqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            if (txtdevice1.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@device", txtdevice1.Text);
            }
            if (txtmerk.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@merk", txtmerk.Text);
            }
            if (txtsn.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@sn", txtsn.Text);
            }
            if (txfungsi.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@fungsi", txfungsi.Text);
            }
            if (txstatus.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@status", txstatus.Text);
            }
            if (txtwilaya.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@wilayah", txtwilaya.Text);
            }
            if (txtruang.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@ruang", txtruang.Text);
            }
            
            if (txtmulai.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@awal", txtmulai.Text);
            }
            if (txtsampai.Text != "")
            {
                sqlcmd.Parameters.AddWithValue("@akhir", txtsampai.Text);
            }
            else
            {
                sqlcmd.Parameters.AddWithValue("@akhir", txtmulai.Text);
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            da.SelectCommand = sqlcmd;
            da.Fill(ds);
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
                    lblpencarian.Visible = false;
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
                else
                {
                    lblpencarian.Visible = true;
                }
            }
        }

    }
}