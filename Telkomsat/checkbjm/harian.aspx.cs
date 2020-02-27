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

namespace Telkomsat.checkbjm
{
    public partial class harian : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", querytanggal = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";


        string Parameter = "a", iduser, query2 = "A", idddl = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, query1, date, inisial, rack;
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0, k;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["room"] != null)
            {
                room = Request.QueryString["room"];
                lblroom.Text = room;
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

            query2 = $@"select count(*) from checkhk_parameter r left join
                    checkhk_perangkat p on p.id_perangkat = r.id_perangkat left join checkhk_data d on d.id_parameter = r.id_parameter
                    where shelter = '{room}' AND '{date} 00:00:00' <= d.tanggal and d.tanggal < '{date} 23:59:59' and p.shelter = '{room}'";
            sqlCon.Open();
            SqlCommand cmd5 = new SqlCommand(query2, sqlCon);
            string output = cmd5.ExecuteScalar().ToString();
            int jenischeck = Convert.ToInt32(output);
            sqlCon.Close();
            if (jenischeck >= 1)
            {
                lbledit.Visible = true;
                lbledit.Text = $"Data checklist sudah terisi untuk tanggal {date} klik untuk ";
                LinkButton1.Visible = true;
                Button1.Visible = false;
            }
            else
            {

                tableticket();
            }

            if (!IsPostBack)
            {
                if (Session["mastershelterbjm"] != null)
                {
                    ddlruang.Text = Session["mastershelterbjm"].ToString();
                }
            }
        }

        protected void Pilih_Click(object sender, EventArgs e)
        {
            Session["mastershelterbjm"] = ddlruang.Text;
            Response.Redirect($"~/checkbjm/harian.aspx?room={ddlruang.SelectedValue}", false);
            Session["inisialbjm"] = null;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editharian.aspx?tanggal={date}&room={room}");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            querytanggal = $"insert into checkhk_tanggal (tanggalhk, id_profile) values ('{date}', '3')";
            //Console.Write(query1);
            sqlCon.Open();
            SqlCommand cmd7 = new SqlCommand(querytanggal, sqlCon);
            cmd7.ExecuteNonQuery();
            sqlCon.Close();

            string data = string.Join(",", akhir);
            query1 = $"insert into checkhk_data (tanggal, id_profile, id_parameter, data) values {data}";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            //Response.Write(data);
            Session["inisialbjm"] = null;
            Button1.Enabled = true;
            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
            Session["inisialbjm"] = "buka";

        }

        void tableticket()
        {
            if (Session["inisialbjm"] != null)
                query = $@"select d.tanggal, d.data, r.id_parameter, p.Perangkat, r.satuan, p.sn, p.shelter, r.parameter, p.rack, r.tipe from checkhk_parameter r left join
                        checkhk_perangkat p on p.id_perangkat = r.id_perangkat left join checkhk_data d on d.id_parameter = r.id_parameter
						where shelter = '{room}' AND d.tanggal = (SELECT MAX(tanggal) from checkhk_data d join checkhk_parameter r 
					    on r.id_parameter=d.id_parameter left join checkhk_perangkat p on p.id_perangkat = r.id_perangkat
					    where p.shelter = '{room}' and d.data is not null) order by p.rack, r.id_perangkat";
            else
                query = $@"select r.id_parameter, p.Perangkat, r.satuan, p.sn, p.shelter, r.parameter, p.rack, r.tipe from checkhk_parameter r left join
                        checkhk_perangkat p on p.id_perangkat = r.id_perangkat where shelter = '{room}' order by p.rack, r.id_perangkat";


            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Rack</th><th>Perangkat</th><th>Serial Number</th><th>Parameter</th><th>Nilai</th><th>Satuan</th></tr>");
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
                        ruangan = ds.Tables[0].Rows[i]["shelter"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["satuan"].ToString();
                        rack = ds.Tables[0].Rows[i]["rack"].ToString();

                        style3 = "font-weight:normal; font-size:12px;";

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;

                        if (Session["inisialbjm"] != null)
                            nilai = ds.Tables[0].Rows[i]["data"].ToString();
                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + rack + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Perangkat + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        if (tipe == "N")
                            htmlTable.Append("<td>" + $"<input type =\"text\" value=\"{nilai}\" runat=\"server\" class=\"form-control\" name=\"idticket\" id={idtxt}>" + "</td>");
                        else if (tipe == "MS")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"MASTER\" > MASTER </option><option value =\"STANDBY\"> STANDBY </option></select > " + " </td>");
                        else if (tipe == "MU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"MUTE\" > MUTE </option><option value =\"UNMUTE\"> UNMUTE </option></select > " + " </td>");
                        else if (tipe == "SST")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"STANDBY\" > STANDBY </option><option value =\"TRANSMIT\"> TRANSMIT </option><option value=\"TRANSMIT INHIBIT\" > TRANSMIT INHIBIT </option></select > " + " </td>");
                        else if (tipe == "WI")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"1WET\" > 1WET </option><option value =\"IDL\"> IDL </option></select > " + " </td>");
                        else if (tipe == "OA")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"OK\" > OK </option><option value =\"BAD\"> BAD </option></select > " + " </td>");
                        else if (tipe == "OO")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"ON\" > ON </option><option value =\"OFF\"> OFF </option></select > " + " </td>");
                        else if (tipe == "SA")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"STANDBY\" > STANDBY </option><option value =\"AUTOTRACK\"> AUTOTRACK </option></select > " + " </td>");
                        else if (tipe == "LU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"LOCKED\" > LOCKED </option><option value =\"UNLOCKED\"> UNLOCKED </option></select > " + " </td>");

                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable.Append("</tr>");
                        value = Request.Form["idticket"];
                        //Response.Write(value);

                        looping[i] = IDdata;

                    }
                    if (value != null)
                    {
                        string[] lines = Regex.Split(value, ",");

                        foreach (string line in lines)
                        {
                            //Response.Write(line);
                            akhir[j] = "('" + tanggal + "','" + iduser + "','" + looping[j] + "','" + line + "')";
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