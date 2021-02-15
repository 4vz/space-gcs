using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.checkbjm
{
    public partial class checkharian : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string IDdata = "kitaa", total = "", petugas, tanggal = "", query, approval;
        string start = "01/01/2019", end = "01/12/2048";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        int rek1harkat, rek2harkat, rek1me, rek2me, harkat, me;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                query = @"select (CAST(d.tanggal AS DATE)) as tanggal, p.nama, d.pic from checkhk_data d left join Profile p on d.id_profile = p.id_profile
						join checkhk_parameter r on r.id_parameter=d.id_parameter join checkhk_perangkat t on t.id_perangkat=r.id_perangkat where t.lokasi ='bjm'
                        group by CAST(d.tanggal AS DATE), nama, d.pic order by CAST(d.tanggal AS DATE) desc";
                tableticket();
            }
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
            htmlTable.Append("<tr><th>Tanggal</th><th>Petugas</th><th>Approval</th><th>Action</th></tr>");
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
                        approval = ds.Tables[0].Rows[i]["pic"].ToString();

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + petugas + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + approval + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a  style=\"cursor:pointer\" href=\"/checkbjm/dashboardbjm.aspx?tanggal={tanggal}&view=view\">" + $"<label>" + "view" + "</label>" + "</a>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                }
            }
        }

        protected void Filter_ServerClick(object sender, EventArgs e)
        {
            if (txtsdate.Value != "")
                start = txtsdate.Value;
            if (dateend.Value != "")
                end = dateend.Value;
            query = $@"select (CAST(d.tanggal AS DATE)) as tanggal, p.nama, d.pic from checkhk_data d left join Profile p on d.id_profile = p.id_profile 
                            join checkhk_parameter r on r.id_parameter=d.id_parameter join checkhk_perangkat t on t.id_perangkat=r.id_perangkat
                            where (tanggal BETWEEN (convert(datetime, '{start}',103)) AND (convert(datetime, '{end}',103)))
                            and t.lokasi ='bjm'
                            group by (CAST(d.tanggal AS DATE)), nama, d.pic order by (CAST(d.tanggal AS DATE)) desc";
            tableticket();
        }
    }
}