using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.checklistme.week
{
    public partial class data : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", style1 = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string mingguan = "a", bulanan = "A", tanggalku = "s", tahunan = "1", idtxt = "A", loop = "", ruangan, tipe, tahun, room, start, end, bulan, siang = "", malam = "", tanggal1;
        string[] words = { "a", "a" };
        string[] akhir;
        string tanggal, petugas;
        int j = 0, endtahun, endbulan;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tanggal"] != null)
            {
                tanggal1 = Request.QueryString["tanggal"];
            }
            tanggalku = tanggal1;
            query = $@"select week, d.month, d.tahun from checkme_datawmy d join checkme_parameterwmy r on d.id_parameter=r.id_parameter
                    where r.kategori = 'week' group by week, month, tahun order by week desc, tahun";

            if(!IsPostBack)
            {
                tableticket();
            }
            
        }

        protected void Filter_ServerClick(object sender, EventArgs e)
        {
            if (ddlbulan.SelectedValue == "bulan")
                bulan = "month";
            else
                bulan = "'" + ddlbulan.Text + "'";

            if (ddltahun.SelectedValue == "tahun")
                tahun = "tahun";
            else
                tahun = "'" + ddltahun.Text + "'";

            query = $@"select week, d.month, d.tahun from checkme_datawmy d join checkme_parameterwmy r on d.id_parameter=r.id_parameter
                    where r.kategori = 'week' and month = {bulan} and tahun = {tahun}
                    group by week, d.month, d.tahun order by week desc";
            tableticket();
        }

        void tableticket()
        {
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>#</th><th>Minggu</th><th>Bulan</th><th>Tahun</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        mingguan = ds.Tables[0].Rows[i]["week"].ToString();
                        bulanan = ds.Tables[0].Rows[i]["month"].ToString();
                        tahunan = ds.Tables[0].Rows[i]["tahun"].ToString();

                        htmlTable.Append("<tr>");
                        htmlTable.AppendLine("<td>" + "<label style=\"font-size:13px\">" + (i + 1) + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + "Minggu ke- " + mingguan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + bulanan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + tahunan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a  style=\"cursor:pointer\" href=\"/checklistme/week/data2.aspx?minggu={mingguan}&tahun={tahunan}\">" + $"<label>" + "view" + "</label>" + "</a>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                }
                else
                {
                    lblstat.Visible = true;
                    lblstat.Text = "Data tidak tersedia";
                }
            }
        }
    }
}