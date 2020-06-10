using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.checklistme.month
{
    public partial class checkdata : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", style1 = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string Parameter = "a", query2 = "A", tanggalku = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, start, end, tahun, siang = "", malam = "", tanggal1;
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0, endtahun, endbulan;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tanggal"] != null)
            {
                tanggal1 = Request.QueryString["tanggal"];
            }
            tanggalku = tanggal1;

            query = $@"select d.month, d.tahun, numbermonth from checkme_datawmy d join checkme_parameterwmy r on d.id_parameter=r.id_parameter
                    where r.kategori = 'month' and month is not null and month != '' group by month, tahun, numbermonth order by numbermonth desc";

            tableticket();
        }

        void tableticket()
        {
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            string bulan, semester;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.AppendLine("<thead>");
            htmlTable.AppendLine("<tr><th>#</th><th>Bulan</th><th>Tahun</th><th>Action</th></tr>");
            htmlTable.AppendLine("</thead>");

            htmlTable.AppendLine("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        bulan = ds.Tables[0].Rows[i]["month"].ToString();
                        tahun = ds.Tables[0].Rows[i]["tahun"].ToString();
                        htmlTable.AppendLine("<tr>");
                        htmlTable.AppendLine("<td>" + "<label style=\"font-size:13px\">" + (i + 1) + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + "<label style=\"font-size:12px;\">" + bulan + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + "<label style=\"font-size:12px;\">" + tahun + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<a style=\"cursor:pointer\" href=\"databulanan.aspx?bulan={bulan}&tahun={tahun}\">" + $"<label>" + "view" + "</label>" + "</a>" + "</td>");
                        htmlTable.AppendLine("</tr>");
                    }
                    htmlTable.AppendLine("</tbody>");
                    htmlTable.AppendLine("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                }
            }
        }

    }
}