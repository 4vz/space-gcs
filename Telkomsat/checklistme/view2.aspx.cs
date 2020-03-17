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
    public partial class view2 : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string room, waktu, datee;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["waktu"] != null)
            {
                waktu = Request.QueryString["waktu"];
                datee = Request.QueryString["tanggal"];
                room = Request.QueryString["ruangan"];
            }
            tableticket();
        }

        void tableticket()
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();

            string IDdata = "kitaa", Perangkat = "st", query, nilai = "", style4 = "a", style3, SN = "a";
            string Parameter = "a", idddl = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan;
            string myid;
            string[] words = { "a", "a" };
            string[] akhir, dataku;

            query = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, p.ruangan, r.parameter, r.tipe, d.nilai from checkme_parameter r left join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat left join checkme_data d on d.id_parameter = r.id_parameter
                    where d.tanggal = '{datee}' and d.waktu = '{waktu}' and p.ruangan='{room}' order by p.ruangan, r.urutan, r.id_perangkat";

            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable1.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable1.Append("<thead>");
            htmlTable1.Append("<tr><th>Ruangan</th><th>Perangkat</th><th>Serial Number</th><th>Parameter</th><th>Nilai</th><th>Satuan</th></tr>");
            htmlTable1.Append("</thead>");

            htmlTable1.Append("<tbody>");

            int count = ds.Tables[0].Rows.Count;
            string[] looping = new string[count];
            akhir = new string[count];
            dataku = new string[count];
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_parameter"].ToString();
                        Perangkat = ds.Tables[0].Rows[i]["Perangkat"].ToString();
                        SN = ds.Tables[0].Rows[i]["sn"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["Parameter"].ToString();
                        ruangan = ds.Tables[0].Rows[i]["ruangan"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["satuan"].ToString();

                        style3 = "font-weight:normal";

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;

                        nilai = ds.Tables[0].Rows[i]["nilai"].ToString();

                        htmlTable1.Append("<tr>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["ruangan"].ToString() + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + Perangkat + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"font-weight:bold\">" + nilai + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable1.Append("</tr>");
                        value = Request.Form["idticket"];
                        //Response.Write(value);

                    }

                    //Response.Write(string.Join("\n", akhir));
                    htmlTable1.Append("</tbody>");
                    htmlTable1.Append("</table>");

                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable1.ToString() });
                }
            }
        }
    }
}