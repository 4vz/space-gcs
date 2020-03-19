using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;

namespace Telkomsat.maintenancehk.bulanan
{
    public partial class isidata : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string[] akhir;
        string query, room, idddl, nilai, value, user;
        int j = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["room"] != null)
            {
                room = Request.QueryString["room"].ToString();
            }

            if (Request.QueryString["inisialhkbulan"] == null)
            {
                query = $@"select * from checkhk_bulan_perangkat where ruangan = '{room}'";
            }
            else
            {
                /*query = @"select r.id_parameter, p.Perangkat, r.satuan, p.alias, p.sn, p.ruangan, r.parameter, r.tipe, d.nilai from checkme_parameter r left join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat left join checkme_data d on d.id_parameter = r.id_parameter
                    where ruangan = '{room}' AND d.tanggal = (SELECT MAX(tanggal)-1 from checkme_data d LEFT join checkme_parameter r 
					on r.ID_Parameter=d.id_parameter left join checkme_perangkat p on p.ID_Perangkat = r.ID_Perangkat
					where p.ruangan = '{room}' and d.nilai is not null) and d.waktu = 'siang' order by r.urutan, r.id_perangkat";*/
            }

            lblroom.Text = " " + room;

            tableticket();
        }

        public class inisial
        {
            public string idruang { get; set; }
            public string ruang { get; set; }
        }

        [WebMethod]
        public static List<inisial> GetID(string myid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"select ruangan from checkhk_bulan_perangkat where lokasi = '{myid}' group by ruangan"))
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
                                idruang = sdr["ruangan"].ToString(),
                                ruang = sdr["ruangan"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        protected void Save_Clisck(object sender, EventArgs e)
        {
            Response.Write("sssss");
        }

        protected void Filter_ServerClick(object sender, EventArgs e)
        {
            if (TextBox2.Text == "")
            {
                lblwarning.Visible = true;
                lblwarning.Text = "  Pilih ruangan terlebih dahulu";
            }
            string room;
            room = TextBox2.Text;
            Response.Redirect($"isidata.aspx?room={room}");
        }

        void tableticket()
        {
            StringBuilder htmlTable = new StringBuilder();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            string IDdata, ruangan, rack, tipe, sn, lokasi, style3, perangkat;
            //Response.Write(query);
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.AppendLine("<thead>");
            htmlTable.AppendLine("<tr><th>Rack</th><th>Perangkat</th><th>Serial Number</th><th style=\"min-width:100px\">Nilai Parameter</th></tr>");
            htmlTable.AppendLine("</thead>");

            htmlTable.AppendLine("<tbody>");

            int count = ds.Tables[0].Rows.Count;
            string[] looping = new string[count];
            akhir = new string[count];
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_main"].ToString();
                        lokasi = ds.Tables[0].Rows[i]["lokasi"].ToString();
                        sn = ds.Tables[0].Rows[i]["sn"].ToString();
                        ruangan = ds.Tables[0].Rows[i]["ruangan"].ToString();
                        rack = ds.Tables[0].Rows[i]["rack"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        perangkat = ds.Tables[0].Rows[i]["perangkat"].ToString();

                        style3 = "font-weight:normal; font-size:12px;";

                        idddl = "ddl" + IDdata;

                        if (Request.QueryString["inisialmeh"] != null)
                            nilai = ds.Tables[0].Rows[i]["nilai"].ToString();
                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.AppendLine("<tr>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + rack + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + perangkat + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + sn + "</label>" + "</td>");
                        if (tipe == "cu")
                            htmlTable.AppendLine("<td>" + $"<select class=\"form-control dropdown selectcolor\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"Unclean\" > Unclean </option><option value =\"Clean\"> Clean </option></select >" + "</td>");
                        htmlTable.AppendLine("</tr>");
                        value = Request.Form["idticket"];
                        //Response.Write(value);

                        looping[i] = IDdata;

                        //Response.Write( "bisa" + words[1]);
                        int j = i - 1;

                    }
                    if (value != null)
                    {
                        string[] lines = Regex.Split(value, ",");

                        foreach (string line in lines)
                        {
                            //Response.Write(line);
                            akhir[j] = "('" + tanggal + "','" + user + "','" + looping[j] + "','" + "','" + line + "')";
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