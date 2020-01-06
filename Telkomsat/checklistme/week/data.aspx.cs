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
        string Parameter = "a", query2 = "A", tanggalku = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, start, end, inisial, siang = "", malam = "", tanggal1;
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
            query = $@"select d.tanggal, p.nama from checkme_datawmy d left join Profile p on d.id_profile = p.id_profile where d.jenis = 'week'
                    group by tanggal, nama order by d.tanggal desc";
            if(!IsPostBack)
            {
                tableticket();
            }
            
        }

        protected void Filter_ServerClick(object sender, EventArgs e)
        {
            start = ddltahun.Text + "/" + ddlbulan.SelectedValue + "/01";
            if(ddlbulan.SelectedValue != "bulan")
                endbulan = Convert.ToInt32(ddlbulan.SelectedValue) + 1;
            if(ddltahun.SelectedValue !="tahun")
                endtahun = Convert.ToInt32(ddltahun.Text);
            if (ddlbulan.SelectedValue == "12")
            {
                if (ddltahun.SelectedValue == "tahun")
                {
                    start = "2019" + "/" + "01" + "/01";
                    end = "2035" + "/" + "01" + "/01";
                }
                else
                {
                    endtahun = Convert.ToInt32(ddltahun.Text) + 1;
                    endbulan = 1;
                    end = endtahun + "/" + endbulan + "/01";
                }
                
            }
            else if(ddlbulan.SelectedValue == "bulan")
            {
                if (ddltahun.SelectedValue == "tahun")
                {
                    start = "2019" + "/" + "01" + "/01";
                    end = "2035" + "/" + "01" + "/01";
                }
                else
                {
                    endtahun = Convert.ToInt32(ddltahun.Text) + 1;
                    start = ddltahun.Text + "/" + "01" + "/01";
                    end = endtahun + "/" + "01" + "/01";
                }            
            }
            else
            {
                end = endtahun + "/" + endbulan + "/01";
            }
            
            if(ddltahun.SelectedValue == "tahun")
            {
                start = "2019" + "/" + "01" + "/01";
                end = "2035" + "/" + "01" + "/01";
            }


            query = $@"select d.tanggal, p.nama from checkme_datawmy d left join Profile p on d.id_profile = p.id_profile where d.jenis = 'week' and
                    '{start}' <= d.tanggal and d.tanggal < '{end}'
                    group by tanggal, nama order by d.tanggal desc";
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
            htmlTable.Append("<tr><th>Tanggal</th><th>Petugas</th><th>Action</th></tr>");
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

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + petugas + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a  style=\"cursor:pointer\" href=\"/checklistme/week/data2.aspx?tanggal={tanggal}\">" + $"<label>" + "view" + "</label>" + "</a>" + "</td>");
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