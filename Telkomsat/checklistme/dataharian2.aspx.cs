using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.checklistme
{
    public partial class dataharian2 : System.Web.UI.Page
    {
        SqlDataAdapter da, da2, das, dam;
        StringBuilder htmlTable = new StringBuilder();
        DataSet ds = new DataSet();
        string IDdata = "kitaa", Perangkat = "st", style1 = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string Parameter = "a", query2 = "A", tanggalku = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, query1, date, inisial, siang = "", malam = "", tanggal1;
        string querysm, idsm, querys, idp, querym, idm;
        string[] words = { "a", "a" };
        string[] datapagi, datasiang, datamalam;
        string[] tipesm, waktusm, tipes, tipem;
        int j, k, l, m, n = 0, a = 0, b, o, p, s, s1, m1;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tanggal"] != null)
            {
                tanggal1 = Request.QueryString["tanggal"];
            }
            tanggalku = tanggal1;

            if (!IsPostBack)
            {
                query = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe, (select nilai from checkme_data where waktu='pagi' 
                    and tanggal='{tanggalku}' and id_parameter=r.id_parameter) as pagi,(select nilai from checkme_data where waktu='siang' 
                    and tanggal='{tanggalku}' and id_parameter=r.id_parameter) as siang,(select nilai from checkme_data where waktu='malam' 
                    and tanggal='{tanggalku}' and id_parameter=r.id_parameter) as malam from checkme_parameter r INNER join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat order by p.ruangan, r.urutan, r.id_perangkat";

                
                tableticket();
            }


        }

        protected void Filter_ServerClick(object sender, EventArgs e)
        {
            if (ddlKategori.SelectedValue == "ruangan")
                room = "ruangan";
            else
                room = "'" + ddlKategori.Text + "'";

            query = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe, (select nilai from checkme_data where waktu='pagi' 
                    and tanggal='{tanggalku}' and id_parameter=r.id_parameter) as pagi,(select nilai from checkme_data where waktu='siang' 
                    and tanggal='{tanggalku}' and id_parameter=r.id_parameter) as siang,(select nilai from checkme_data where waktu='malam' 
                    and tanggal='{tanggalku}' and id_parameter=r.id_parameter) as malam from checkme_data d join checkme_parameter r on d.id_parameter=r.id_parameter INNER join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat
					where ruangan = {room} AND tanggal = '{tanggalku}' order by p.ruangan, r.urutan, r.id_perangkat";

            tableticket();
        }

        void tableticket()
        {
            
            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Ruangan</th><th>Perangkat</th><th>Serial Number</th><th>Parameter</th><th>Pagi</th><th>Siang</th><th>Malam</th><th>Satuan</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            k = 0;
            s = 0;
            p = 0;
            if (!object.Equals(ds.Tables[0], null))
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    m = 0;
                    s1 = 0;
                    m1 = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_parameter"].ToString();
                        Perangkat = ds.Tables[0].Rows[i]["Perangkat"].ToString();
                        SN = ds.Tables[0].Rows[i]["sn"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["Parameter"].ToString();
                        ruangan = ds.Tables[0].Rows[i]["ruangan"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["satuan"].ToString();
                        nilai = ds.Tables[0].Rows[i]["pagi"].ToString();
                        siang = ds.Tables[0].Rows[i]["siang"].ToString();
                        malam = ds.Tables[0].Rows[i]["malam"].ToString();
                        style3 = "font-weight:normal; font-size:12px;";

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ruangan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Perangkat + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td style=\"border-right:3px solid #dddddd;\">" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        htmlTable.Append("<td style=\"border-right:3px solid #dddddd;\">" + $"<label style=\"{style3}\">{nilai}</label>" + "</td>");
                        htmlTable.Append("<td style=\"border-right:3px solid #dddddd;\">" + $"<label style=\"{style3}\">{siang}</label>" + "</td>");
                        htmlTable.Append("<td style=\"border-right:3px solid #dddddd;\">" + $"<label style=\"{style3}\">{malam}</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable.Append("</tr>");
                        value = Request.Form["idticket"];
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");

                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}