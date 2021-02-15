using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.checkhk
{
    public partial class view : System.Web.UI.Page
    {
        SqlDataAdapter da, da2, das, dam;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet dss = new DataSet();
        DataSet dsm = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", style1 = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string Parameter = "a", query2 = "A", tanggalku = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, query1, date, inisial, dataa = "", malam = "", tanggal1;
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
                room = Request.QueryString["ruangan"];
            }
            tanggalku = tanggal1;
            if (!IsPostBack)
            {
                query = $@"select p.shelter, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe, d.data, d.tanggal from checkhk_parameter r left join
                    checkhk_perangkat p on p.id_perangkat = r.id_perangkat left join checkhk_data d on d.id_parameter = r.id_parameter
					and '{tanggalku} 00:00:00' <= d.tanggal and d.tanggal < '{tanggalku} 23:59:59'
                    where p.shelter = '{room}' and p.lokasi ='cbi' order by p.shelter, p.rack, p.sn";
                tableticket();
            }


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


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Ruangan</th><th>Perangkat</th><th>Serial Number</th><th>Parameter</th><th>Nilai</th><th>Satuan</th></tr>");
            htmlTable.Append("</thead>");

            lbltanggal.Visible = true;
            //
            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbltanggal.Text = ds.Tables[0].Rows[0]["tanggal"].ToString();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_parameter"].ToString();
                        Perangkat = ds.Tables[0].Rows[i]["Perangkat"].ToString();
                        SN = ds.Tables[0].Rows[i]["sn"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["Parameter"].ToString();
                        ruangan = ds.Tables[0].Rows[i]["shelter"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["satuan"].ToString();
                        dataa = ds.Tables[0].Rows[i]["data"].ToString();
                        style3 = "font-weight:normal";

                        if (dataa == "BAD")
                            style3 = "color:red";

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ruangan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Perangkat + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">{dataa}</label>" + "</td>");
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