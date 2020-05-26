using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.maintenancehk.tigabulan
{
    public partial class checkdata : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string IDdata = "kitaa", total = "", petugas, tanggal = "", query, tanggalend, triwulan, tahun;
        string start = "01/01/2019", end = "01/12/2048";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        int rek1harkat, rek2harkat, rek1me, rek2me, harkat, j;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                query = @"select triwulan, YEAR(tanggal) as tahun from mainhk_3m_data group by triwulan, YEAR(tanggal) order by triwulan, YEAR(tanggal)";
                tableticket();
            }
        }

        void tableticket()
        {
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.AppendLine("<thead>");
            htmlTable.AppendLine("<tr><th>#</th><th>Triwulan</th><th>Tahun</th><th>Action</th></tr>");
            htmlTable.AppendLine("</thead>");

            htmlTable.AppendLine("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        /*DateTime date1 = (DateTime)ds.Tables[0].Rows[i]["tanggal"];
                        DateTime startdate = new DateTime(date1.Year, 1, 1);
                        DateTime middate = new DateTime(date1.Year, 6, 30);
                        DateTime enddate = new DateTime(date1.Year, 12, 30);

                        if (date1 > startdate && date1 <= middate)
                        {
                            tanggal = startdate.ToString("yyyy/MM/dd");
                            tanggalend = middate.ToString("yyyy/MM/dd");
                        }
                        else if(date1 > middate && date1 <= enddate)
                        {
                            tanggal = middate.ToString("yyyy/MM/dd");
                            tanggalend = enddate.ToString("yyyy/MM/dd");
                        }*/

                        triwulan = ds.Tables[0].Rows[i]["triwulan"].ToString();
                        tahun = ds.Tables[0].Rows[i]["tahun"].ToString();

                        htmlTable.AppendLine("<tr>");
                        htmlTable.AppendLine("<td>" + "<label style=\"font-size:13px\">" + (i + 1) + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + "<label style=\"font-size:12px;\">" + triwulan + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + "<label style=\"font-size:12px;\">" + tahun + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<a  style=\"cursor:pointer\" href=\"data.aspx?triwulan={triwulan}&tahun={tahun}\">" + $"<label>" + "view" + "</label>" + "</a>" + "</td>");
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