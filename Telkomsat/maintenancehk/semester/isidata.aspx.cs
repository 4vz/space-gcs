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
    public partial class isidata : System.Web.UI.Page
    {
        SqlDataAdapter da, dabar;
        DataSet ds = new DataSet();
        DataSet dsbar = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", equipment = "st", start = "a", query, end = "", nilai = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string tahun, semester;

        string Parameter = "a", iduser, query2 = "A", idddl = "s", idtgl, value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room,rdevice, ralias, query1, date, inisial, device, alias, tanggal, valuetgl;
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0, k, m=0;
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
                semester = "Semester 1";
            }
            else if (now > middate && now <= enddate)
            {
                start = middate.ToString("yyyy/MM/dd");
                end = enddate.ToString("yyyy/MM/dd");
                semester = "Semester 2";
            }

            queryisi = $@"SELECT d.data FROM maintenancehk_data d join maintenancehk_parameter r on d.id_parameter=
                                r.id_parameter join maintenancehk_perangkat t on r.id_perangkat=t.id_perangkat where 
                                '{start} 00:00:00' <= d.tanggal and d.tanggal < '{end} 23:59:59' and d.data != '' and t.unit = '{room}' and
                                t.device = '{rdevice}' and t.alias ='{ralias}' and d.data not like '%' + 'un' + '%' and t.jenis = 'SEMESTER' GROUP BY d.data";
            sqlCon.Open();
            SqlCommand cmdisi = new SqlCommand(queryisi, sqlCon);
            dabar = new SqlDataAdapter(cmdisi);
            dabar.Fill(dsbar);
            cmdisi.ExecuteNonQuery();
            sqlCon.Close();

            if (dsbar.Tables[0].Rows.Count > 0)
                Response.Redirect($"update.aspx?room={room}&device={rdevice}&alias={ralias}&tanggal={tanggal}");

            //Response.Write(queryisi);
            /*query2 = $@"select count(*) from checkhk_parameter r left join
                    checkhk_equipment p on p.id_equipment = r.id_equipment left join checkhk_data d on d.id_parameter = r.id_parameter
                    where shelter = '{room}' AND '{date} 00:00:00' <= d.tanggal and d.tanggal < '{date} 23:59:59' and p.shelter = '{room}'";
            sqlCon.Open();
            SqlCommand cmd5 = new SqlCommand(query2, sqlCon);
            string output = cmd5.ExecuteScalar().ToString();
            int jenischeck = Convert.ToInt32(output);
            sqlCon.Close();
            if (jenischeck >= 1)
            {
                lbledit.Visible = true;
                lbledit.Text = $"Data checklist sudah terisi untuk semester {date} klik untuk ";
                LinkButton1.Visible = true;
                Button1.Visible = false;
            }
            else
            {

                tableticket();
            }
            */
            tahun = DateTime.Now.Year.ToString();
            tableticket();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editharian.aspx?tanggal={date}&room={room}");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string data = string.Join(",", akhir);
            query1 = $"insert into maintenancehk_data (tanggal, id_profile, id_parameter, data, tanggal_kerja, tahun, semester, kategori) values {data}";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            //Response.Write(data);
            Session["inisialhk"] = null;
            Button1.Enabled = true;

            string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
            string querylog = $@"Insert into log (id_profile, tanggal, tipe, judul) values
                                ('{iduser}', '{tanggalku}', 'mainhk', 'maintenance semester Harkat')";
            sqlCon.Open();
            SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
            cmdlog.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect($"dashboard.aspx");
            //Response.Write(query1);
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
            Session["inisialhk"] = "buka";

        }

        void tableticket()
        {
            query = $@"select r.id_parameter, t.unit, t.device, t.alias, t.sn, r.parameter, r.tipe, r.event from maintenancehk_perangkat t join maintenancehk_parameter r 
                    on t.id_perangkat=r.id_perangkat where t.unit = '{room}'  and alias = '{ralias}' and device = '{rdevice}' and t.jenis = 'SEMESTER'
                    order by t.device, r.id_parameter";


            string tanggal = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><<th>Device</th><th>Alias</th><th>Serial Number</th><th>Parameter</th><th>Nilai</th><th>Event</th><th>Tanggal Pengerjaan</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");

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
                        IDdata = ds.Tables[0].Rows[i]["id_parameter"].ToString();
                        equipment = ds.Tables[0].Rows[i]["unit"].ToString();
                        SN = ds.Tables[0].Rows[i]["sn"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["Parameter"].ToString();
                        alias = ds.Tables[0].Rows[i]["alias"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["event"].ToString();
                        device = ds.Tables[0].Rows[i]["device"].ToString();

                        style3 = "font-weight:normal; font-size:12px;";

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;
                        idtgl = "tgl" + IDdata;

                        if (Session["inisialhk"] != null)
                            nilai = ds.Tables[0].Rows[i]["data"].ToString();
                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + device + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + alias + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        if (tipe == "N")
                            htmlTable.Append("<td>" + $"<input type =\"text\" value=\"{nilai}\" runat=\"server\" class=\"form-control\" name=\"idticket\" id={idtxt}>" + "</td>");
                        else if (tipe == "CK")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNCHECKED\"> UNCHECKED </option><option value=\"CHECKED\" > CHECKED </option></select > " + " </td>");
                        else if (tipe == "CU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNCLEANED\"> UNCLEANED </option><option value=\"CLEANED\" > CLEANED </option></select > " + " </td>");
                        else if (tipe == "DU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"NOT YET\"> NOT YET </option><option value=\"DONE\" > DONE </option></select > " + " </td>");
                        else if (tipe == "GT")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"TROUBLE\"> TROUBLE </option><option value=\"GOOD\" > GOOD </option></select > " + " </td>");
                        else if (tipe == "GU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNGREASE\"> UNGREASE </option><option value=\"GREASE\" > GREASE </option></select > " + " </td>");
                        else if (tipe == "OU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNLUBRICATED\"> UNLUBRICATED </option><option value=\"LUBRICATED\" > LUBRICATED </option></select > " + " </td>");
                        else if (tipe == "PU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNPAINTED\"> UNPAINTED </option><option value=\"PAINTED\" > PAINTED </option></select > " + " </td>");
                        else if (tipe == "TU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNTESTED\"> UNTESTED </option><option value=\"TESTED\" > TESTED </option></select > " + " </td>");
                        else if (tipe == "WU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNWASHED\"> UNWASHED </option><option value=\"WASHED\" > WASHED </option></select > " + " </td>");

                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<input type=\"text\" class=\"form-control tgldata\" name=\"tgl\" id=\"{idtgl}\" autocomplete=\"off\" />" + "</td>");
                        htmlTable.Append("</tr>");
                        value = Request.Form["idticket"];
                        valuetgl = Request.Form["tgl"];

                        //Response.Write(value);

                        looping[i] = IDdata;

                    }

                    if(valuetgl != null)
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
                            akhir[j] = "('" + tanggal + "','" + iduser + "','" + looping[j] + "','" + line + "','" + loopingtgl[j] + "','" + tahun + "','" + semester + "','" + "semester" + "')";
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