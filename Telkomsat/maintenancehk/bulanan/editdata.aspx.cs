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
    public partial class editdata : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string[] akhir;
        string query, query1, room, idddl, nilai, value, user, dataa, bulan, valuetgl;
        int j = 0, m = 0;
        string[] dataku, loopingtgl;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            string start = startDate.ToString("yyyy/MM/dd");
            string end = endDate.ToString("yyyy/MM/dd");*/
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            string start = startDate.ToString("yyyy/MM/dd");
            string end = endDate.ToString("yyyy/MM/dd");

            string querytest = $"select count(*) from checkhk_bulan_data where tanggal >= '{start}' and tanggal <= '{end}'";
            sqlCon.Open();
            SqlCommand cmdtest = new SqlCommand(querytest, sqlCon);
            int UserExist = (int)cmdtest.ExecuteScalar();
            //Response.Write(UserExist);
            sqlCon.Close();
            if (Request.QueryString["room"] != null)
            {
                room = Request.QueryString["room"].ToString();
            }

            if (Session["iduser"] != null)
            {
                user = Session["iduser"].ToString();
            }

            if (UserExist == 0)
            {
                Response.Redirect($"isidata.aspx?room={room}");
            }
            bulan = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);

            query = $@"select * from checkhk_bulan_data d join checkhk_bulan_perangkat t on t.id_main=d.id_main
                    where bulan='{bulan}' and ruangan = '{room}'";

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
            string query5, myid;
            SqlDataAdapter da2;
            DataSet ds2 = new DataSet();
            query5 = $@"select id_data from checkhk_bulan_data d join checkhk_bulan_perangkat t on t.id_main=d.id_main
                    where bulan='{bulan}' and ruangan = '{room}'";

            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");

            SqlCommand cmd = new SqlCommand(query5, sqlCon);
            da2 = new SqlDataAdapter(cmd);
            da2.Fill(ds2);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            int p;
            if (!object.Equals(ds2.Tables[0], null))
            {
                if (ds2.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        myid = ds2.Tables[0].Rows[i]["id_data"].ToString();
                        string myquery1 = $@"UPDATE checkhk_bulan_data SET data = '{dataku[i]}', tanggal = '{loopingtgl[i]}' WHERE id_data = '{myid}'";
                        sqlCon.Open();
                        SqlCommand sqlcmd = new SqlCommand(myquery1, sqlCon);
                        sqlcmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }

            string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
            string querylog = $@"Insert into log (id_profile, tanggal, tipe, judul) values
                                ('{user}', '{tanggalku}', 'mainhk', 'maintenance bulanan Harkat')";
            sqlCon.Open();
            SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
            cmdlog.ExecuteNonQuery();
            sqlCon.Close();

            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);
        }

       

        void tableticket()
        {
            StringBuilder htmlTable = new StringBuilder();
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            string IDdata, ruangan, rack, tipe, sn, lokasi, style3, perangkat, tgl;
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
            loopingtgl = new string[count];
            akhir = new string[count];
            dataku = new string[count];
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_data"].ToString();
                        lokasi = ds.Tables[0].Rows[i]["lokasi"].ToString();
                        sn = ds.Tables[0].Rows[i]["sn"].ToString();
                        dataa = ds.Tables[0].Rows[i]["data"].ToString();
                        ruangan = ds.Tables[0].Rows[i]["ruangan"].ToString();
                        rack = ds.Tables[0].Rows[i]["rack"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        perangkat = ds.Tables[0].Rows[i]["perangkat"].ToString();

                        style3 = "font-weight:normal; font-size:12px;";

                        idddl = "ddl" + IDdata;

                        if (Request.QueryString["inisialmeh"] != null)
                            nilai = ds.Tables[0].Rows[i]["nilai"].ToString();

                        DateTime date1 = (DateTime)ds.Tables[0].Rows[i]["tanggal"];
                        tgl = date1.ToString("yyyy/MM/dd");

                        if (tgl == "1900/01/01")
                            tgl = "";

                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.AppendLine("<tr>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + rack + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + perangkat + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + sn + "</label>" + "</td>");
                        if(dataa == "Clean")
                            htmlTable.AppendLine("<td>" + "<input type=\"text\" runat=\"server\" class=\"form-control\" style=\"background-color:#8bff99\" value=\"Clean\" name=\"idticket\" readonly />" + "</td>");
                        else
                            htmlTable.AppendLine("<td>" + $"<select class=\"form-control dropdown selectcolor\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"Unclean\" > Unclean </option><option value =\"Clean\"> Clean </option></select >" + "</td>");
                        htmlTable.Append("<td>" + $"<input type=\"text\" value=\"{tgl}\" class=\"form-control tgldata\" name=\"tgl\" autocomplete=\"off\" />" + "</td>");
                        htmlTable.AppendLine("</tr>");
                        value = Request.Form["idticket"];
                        //Response.Write(value);
                        valuetgl = Request.Form["tgl"];
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
                            akhir[j] = "('" + looping[j] + "','" + line + "')";
                            dataku[j] = line;
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