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
using System.Globalization;

namespace Telkomsat.maintenancehk.bulanan
{
    public partial class isidata : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string[] akhir;
        string query, query1, room, idddl, nilai, value, user, idtgl, valuetgl, bulan, angkabulan, tahun;
        int j = 0, m=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["room"] != null)
            {
                room = Request.QueryString["room"].ToString();
                DateTime now = DateTime.Now;
                var startDate = new DateTime(now.Year, now.Month, 1);
                var endDate = startDate.AddMonths(1).AddDays(-1);
                string start = startDate.ToString("yyyy/MM/dd");
                string end = endDate.ToString("yyyy/MM/dd");

                string querytest = $"select count(*) from checkhk_bulan_data d join checkhk_bulan_perangkat t on t.id_main=d.id_main" +
                    $" where tanggal >= '{start}' and tanggal <= '{end}' and ruangan='{room}'";
                sqlCon.Open();
                SqlCommand cmdtest = new SqlCommand(querytest, sqlCon);
                int UserExist = (int)cmdtest.ExecuteScalar();
                sqlCon.Close();
                if (UserExist > 0)
                {
                    Response.Redirect($"editdata.aspx?room={room}");
                }

            }

            if (Session["iduser"] != null)
            {
                user = Session["iduser"].ToString();
            }

            tahun = DateTime.Now.Year.ToString();
            angkabulan = DateTime.Now.Month.ToString();
            bulan = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);

            query = $@"select * from checkhk_bulan_perangkat where ruangan = '{room}'";

         
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

        protected void Save_Click(object sender, EventArgs e)
        {
           
            sqlCon.Close();
            string data = string.Join(",", akhir);
            query1 = $"insert into checkhk_bulan_data (id_profile, id_main, tanggal, bulan, data, angkabulan, tahun) values {data}";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
            string querylog = $@"Insert into log (id_profile, tanggal, tipe, judul) values
                                ('{user}', '{tanggalku}', 'mainhk', 'maintenance bulanan harkat')";
            sqlCon.Open();
            SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
            cmdlog.ExecuteNonQuery();
            sqlCon.Close();
            //Response.Write(query1);
            //Response.Write(query1);
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
            htmlTable.AppendLine("<tr><th>Rack</th><th>Perangkat</th><th>Serial Number</th><th style=\"min-width:100px\">Nilai Parameter</th><th>Tanggal Pengerjaan</th></tr>");
            htmlTable.AppendLine("</thead>");

            htmlTable.AppendLine("<tbody>");

            int count = ds.Tables[0].Rows.Count;
            string[] looping = new string[count];
            string[] loopingtgl = new string[count];
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
                        idddl = "tgl" + IDdata;

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
                        htmlTable.Append("<td>" + $"<input type=\"text\" class=\"form-control tgldata\" name=\"tgl\" id=\"{idtgl}\" autocomplete=\"off\" />" + "</td>");
                        htmlTable.AppendLine("</tr>");
                        value = Request.Form["idticket"];
                        valuetgl = Request.Form["tgl"];
                        //Response.Write(value);

                        looping[i] = IDdata;

                        //Response.Write( "bisa" + words[1]);
                        int j = i - 1;

                    }
                    if (valuetgl != null)
                    {
                        string[] datelines = Regex.Split(valuetgl, ",");

                        foreach (string dateline in datelines)
                        {
                            loopingtgl[m] = dateline;
                            m++;
                        }
                    }
                    if (value != null)
                    {
                        string[] lines = Regex.Split(value, ",");

                        foreach (string line in lines)
                        {
                            //Response.Write(line);
                            akhir[j] = "('" +  "12" + "','" + looping[j] + "','"  + loopingtgl[j] + "','" + bulan + "','" + line + "','" + angkabulan + "','" + tahun + "')";
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