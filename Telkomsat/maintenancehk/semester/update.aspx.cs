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

namespace Telkomsat.maintenancehk.semester
{
    public partial class update : System.Web.UI.Page
    {
        SqlDataAdapter da, dabar;
        DataSet ds = new DataSet();
        DataSet dsbar = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", equipment = "st", querytanggal = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string start, end;

        string Parameter = "a", iduser, query2 = "A", idtgl, idddl = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, rdevice, ralias, query1, date, inisial, device, alias, tanggalkerja, valuetgl;
        string[] words = { "a", "a" };
        string[] akhir, loopingtgl;
        int j = 0, k, m = 0;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string queryisi;
            if (Request.QueryString["alias"] != null)
            {
                room = Request.QueryString["room"];
                rdevice = Request.QueryString["device"];
                ralias = Request.QueryString["alias"];
                lblroom.Text = room + " -> " + rdevice + " -> " + ralias;
            }
            else
            {
                Button1.Visible = false;
            }

            if (Session["iduser"] != null)
            {
                iduser = Session["iduser"].ToString();
            }

            date = DateTime.Now.ToString("yyyy/MM/dd");

            DateTime now = DateTime.Now;
            DateTime startdate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime middate = new DateTime(DateTime.Now.Year, 6, 30);
            DateTime enddate = new DateTime(DateTime.Now.Year, 12, 30);

            if (now > startdate && now <= middate)
            {
                start = startdate.ToString("yyyy/MM/dd");
                end = middate.ToString("yyyy/MM/dd");
            }
            else if (now > middate && now <= enddate)
            {
                start = middate.ToString("yyyy/MM/dd");
                end = enddate.ToString("yyyy/MM/dd");
            }

            tableticket();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editharian.aspx?tanggal={date}&room={room}");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string data = string.Join(",", akhir);
            
            string query5, myid;
            SqlDataAdapter da2;
            DataSet ds2 = new DataSet();
            query5 = $@"select id_data from maintenancehk_data d join maintenancehk_parameter r on r.id_parameter=d.id_parameter join
                        maintenancehk_perangkat t on t.id_perangkat=r.id_perangkat where t.device = '{rdevice}'
                        and t.alias = '{ralias}' and t.unit = '{room}' and '{start} 00:00:00'
                        <= d.tanggal and d.tanggal < '{end} 23:59:59' and t.jenis='SEMESTER' order by t.device, r.id_parameter";

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
                        string myquery1 = $@"UPDATE maintenancehk_data SET data = '{akhir[i]}', tanggal_kerja='{loopingtgl[i]}' WHERE id_data = '{myid}'";
                        sqlCon.Open();
                        SqlCommand sqlcmd = new SqlCommand(myquery1, sqlCon);
                        sqlcmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);

            Response.Redirect($"dashboard.aspx");
            Response.Write(query1);
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
            Session["inisialhk"] = "buka";

        }

        void tableticket()
        {
            query = $@"select r.id_parameter, t.unit, t.device, t.alias, t.sn, r.parameter, r.tipe, r.event, d.tanggal_kerja, d.data from maintenancehk_data d join maintenancehk_parameter r on
					d.id_parameter=r.id_parameter join maintenancehk_perangkat t
                    on t.id_perangkat=r.id_perangkat where t.unit = '{room}' and device = '{rdevice}' and alias = '{ralias}' and t.jenis='SEMESTER' and '{start} 00:00:00'
                        <= d.tanggal and d.tanggal < '{end} 23:59:59' 
                    order by t.device, r.id_parameter";

            string pilih;
            string tanggal = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.AppendLine("<thead>");
            htmlTable.AppendLine("<tr><<th>Device</th><th>Alias</th><th>Serial Number</th><th>Parameter</th><th>Nilai</th><th>Event</th><th>Tanggal Pengerjaan</th></tr>");
            htmlTable.AppendLine("</thead>");

            htmlTable.AppendLine("<tbody>");

            int count = ds.Tables[0].Rows.Count;
            string[] looping = new string[count];
            loopingtgl = new string[count];
            akhir = new string[count];
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_parameter"].ToString();
                        equipment = ds.Tables[0].Rows[i]["unit"].ToString();
                        SN = ds.Tables[0].Rows[i]["sn"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["Parameter"].ToString();
                        alias = ds.Tables[0].Rows[i]["alias"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["event"].ToString();
                        device = ds.Tables[0].Rows[i]["device"].ToString();

                        DateTime date1 = (DateTime)ds.Tables[0].Rows[i]["tanggal_kerja"];
                        tanggalkerja = date1.ToString("yyyy/MM/dd");

                        if (tanggalkerja == "1900/01/01")
                            tanggalkerja = "";

                        style3 = "font-weight:normal; font-size:12px;";

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;
                        idtgl = "tgl" + IDdata;
                        nilai = ds.Tables[0].Rows[i]["data"].ToString();

                        if (nilai.Contains("UN") || nilai == "NOT YET" || nilai == "TROUBLE")
                            pilih = "";
                        else
                            pilih = "selected";
                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.AppendLine("<tr>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + device + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + alias + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        if (tipe == "N")
                            htmlTable.AppendLine("<td>" + $"<input type =\"text\" value=\"{nilai}\" runat=\"server\" class=\"form-control\" name=\"idticket\" id={idtxt}>" + "</td>");
                        else if (tipe == "CK")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNCHECKED\"> UNCHECKED </option><option value=\"CHECKED\" {pilih}> CHECKED </option></select > " + " </td>");
                        else if (tipe == "CU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNCLEANED\"> UNCLEANED </option><option value=\"CLEANED\" {pilih}> CLEANED </option></select > " + " </td>");
                        else if (tipe == "DU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"NOT YET\"> NOT YET </option><option value=\"DONE\" {pilih}> DONE </option></select > " + " </td>");
                        else if (tipe == "GT")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"TROUBLE\"> TROUBLE </option><option value=\"GOOD\" {pilih}> GOOD </option></select > " + " </td>");
                        else if (tipe == "GU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNGREASE\"> UNGREASE </option><option value=\"GREASE\" {pilih}> GREASE </option></select > " + " </td>");
                        else if (tipe == "OU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNLUBRICATED\"> UNLUBRICATED </option><option value=\"LUBRICATED\" {pilih}> LUBRICATED </option></select > " + " </td>");
                        else if (tipe == "PU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNPAINTED\"> UNPAINTED </option><option value=\"PAINTED\" {pilih}> PAINTED </option></select > " + " </td>");
                        else if (tipe == "TU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNTESTED\"> UNTESTED </option><option value=\"TESTED\" {pilih}> TESTED </option></select > " + " </td>");
                        else if (tipe == "WU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNWASHED\"> UNWASHED </option><option value=\"WASHED\" {pilih}> WASHED </option></select > " + " </td>");

                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<input type=\"text\" value=\"{tanggalkerja}\" class=\"form-control tgldata\" name=\"tgl\" id=\"{idtgl}\" autocomplete=\"off\" />" + "</td>");
                        htmlTable.AppendLine("</tr>");
                        value = Request.Form["idticket"];
                        valuetgl = Request.Form["tgl"];
                        //Response.Write(value);

                        looping[i] = IDdata;

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
                            akhir[j] = line;
                            j++;
                        }
                    }
                    //Response.Write(string.Join("\n", akhir));
                    htmlTable.AppendLine("</tbody>");
                    htmlTable.AppendLine("</table>");

                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}