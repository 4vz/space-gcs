using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace Telkomsat.checklistme
{
    public partial class viewharian : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", style1 = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string Parameter = "a", query2 = "A", idddl = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, query1, date, inisial, siang="", malam="";
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["room"] != null)
            {
                room = Request.QueryString["room"];
                waktu = Request.QueryString["waktu"];
            }
            tableticket();


        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string data = string.Join(",", akhir);
            query1 = $"insert into checkme_data (tanggal, id_profile, id_parameter, waktu, nilai) values {data}";
            //Console.Write(query1);
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            Session["inisial"] = null;

            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);
        }

        void tableticket()
        {
            query = $@"select r.id_parameter, p.perangkat, p.sn, r.tipe, r.parameter, r.satuan, d.nilai,(case when d.waktu = 'pagi' then d.nilai end) AS 'PAGI', 
					(case when d.waktu = 'siang' then d.nilai end) AS 'SIANG', (case when d.waktu = 'malam' then d.nilai end) AS 'MALAM'
					from checkme_parameter r left join checkme_perangkat p on p.id_perangkat = r.id_perangkat left join checkme_data d
					on d.id_parameter = r.id_parameter where ruangan = 'SH-MPSAT' AND d.tanggal = (SELECT MAX(tanggal) from checkme_data d LEFT join checkme_parameter r 
					on r.ID_Parameter=d.id_parameter left join checkme_perangkat p on p.ID_Perangkat = r.ID_Perangkat
					where p.ruangan = 'SH-MPSAT' and d.nilai is not null) order by r.urutan, r.id_perangkat";

            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Perangkat</th><th>Serial Number</th><th>Parameter</th><th>Pagi</th><th>Siang</th><th>Malam</th><th>Satuan</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");

            int count = ds.Tables[0].Rows.Count;
            string[] looping = new string[count];
            akhir = new string[count];
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
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["satuan"].ToString();

                        style3 = "font-weight:normal";

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;

                        nilai = ds.Tables[0].Rows[i]["PAGI"].ToString();
                        siang = ds.Tables[0].Rows[i]["SIANG"].ToString();
                        malam = ds.Tables[0].Rows[i]["MALAM"].ToString();

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Perangkat + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + nilai + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + siang + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + malam + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable.Append("</tr>");
                        value = Request.Form["idticket"];
                        //Response.Write(value);

                        looping[i] = IDdata;

                        //Response.Write( "bisa" + words[1]);
                        int j = i - 1;
                        //Response.Write(seats);
                        //looping = "('" + IDdata + "'," + seats + "),";
                        loop = IDdata + "," + loop;

                    }
                    if (value != null)
                    {
                        string[] lines = Regex.Split(value, ",");

                        foreach (string line in lines)
                        {
                            //Response.Write(line);
                            akhir[j] = "(" + "'" + looping[j] + "','" + line + "')";
                            j++;
                        }
                    }
                    //Response.Write(string.Join("\n", akhir));
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");

                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}