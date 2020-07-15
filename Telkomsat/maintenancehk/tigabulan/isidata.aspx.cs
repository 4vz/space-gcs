﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace Telkomsat.maintenancehk.tigabulan
{
    public partial class isidata : System.Web.UI.Page
    {
        SqlDataAdapter da, dabar;
        DataSet ds = new DataSet();
        DataSet dsbar = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", equipment, start = "a", query, end = "", nilai, style3, SN = "a", satelit, lokasi, jenisview = "", tahun;
        string triwulan;

        string Parameter, iduser, query2 = "A", idddl = "s", idtgl, value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, rdevice, ralias, query1, date, inisial, device, alias, tanggal, valuetgl;
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0, k, m = 0;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string queryisi;
            if (Request.QueryString["equipment"] != null)
            {
                satelit = Request.QueryString["satelit"];
                lokasi = Request.QueryString["lokasi"];
                equipment = Request.QueryString["equipment"];
                lblroom.Text = lokasi + " -> " + satelit + " -> " + equipment;
            }
            else
            {
                Button1.Visible = false;
            }

            if (Session["iduser"] != null)
            {
                iduser = Session["iduser"].ToString();
            }

            tahun = DateTime.Now.Year.ToString();
            date = DateTime.Now.ToString("yyyy/MM/dd");

            DateTime now = DateTime.Now;
            DateTime first = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime second = new DateTime(DateTime.Now.Year, 3, 30);
            DateTime third = new DateTime(DateTime.Now.Year, 4, 1);
            DateTime fourth = new DateTime(DateTime.Now.Year, 6, 30);
            DateTime fifth = new DateTime(DateTime.Now.Year, 7, 1);
            DateTime sixth = new DateTime(DateTime.Now.Year, 9, 30);
            DateTime seventh = new DateTime(DateTime.Now.Year, 10, 1);
            DateTime eighth = new DateTime(DateTime.Now.Year, 12, 30);
            DateTime nineth = new DateTime(DateTime.Now.Year + 1, 1, 1);

            if (now > first && now <= third)
            {
                triwulan = "triwulan 1";
                start = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 4, 1).ToString("yyyy/MM/dd");
            }
            else if (now > third && now <= fifth)
            {
                triwulan = "triwulan 2";
                start = new DateTime(DateTime.Now.Year, 4, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 7, 1).ToString("yyyy/MM/dd");
            }
            else if (now > fifth && now <= seventh)
            {
                triwulan = "triwulan 3";
                start = new DateTime(DateTime.Now.Year, 7, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 10,1).ToString("yyyy/MM/dd");
            }
            else if (now > seventh && now <= nineth)
            {
                triwulan = "triwulan 4";
                start = new DateTime(DateTime.Now.Year, 10, 1).ToString("yyyy/MM/dd");
                end = new DateTime((DateTime.Now.Year + 1), 1, 1).ToString("yyyy/MM/dd");
            }

            queryisi = $@"select count(*) as isi from mainhk_3m_data d 
					join mainhk_3m_parameter r on r.id_parameter=d.id_parameter join mainhk_3m_perangkat t on t.id_perangkat=r.id_perangkat
                    where '{start} 00:00:00' <= d.tanggal and d.tanggal < '{end} 23:59:59' and
                    t.lokasi='{lokasi}' and t.satelit= '{satelit}' and t.equipment = '{equipment}'";

            sqlCon.Open();
            SqlCommand cmdisi = new SqlCommand(queryisi, sqlCon);
            dabar = new SqlDataAdapter(cmdisi);
            dabar.Fill(dsbar);
            cmdisi.ExecuteNonQuery();
            sqlCon.Close();

            if (Convert.ToUInt32(dsbar.Tables[0].Rows[0]["isi"]) > 0)
                Response.Redirect($"isiafter.aspx?satelit={satelit}&lokasi={lokasi}&equipment={equipment}");

            tableticket();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editharian.aspx?tanggal={date}&room={room}");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string data = string.Join(",", akhir);
            query1 = $"insert into mainhk_3m_data (tanggal, id_profile, id_parameter, data_bef, triwulan, kategori, tahun) values {data}";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            //Response.Write(data);
            Session["inisialhk"] = null;
            Button1.Enabled = true;

            string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
            string querylog = $@"Insert into log (id_profile, tanggal, tipe, judul) values
                                ('{iduser}', '{tanggalku}', 'mainhk', 'maintenance triwulan Harkat')";
            sqlCon.Open();
            SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
            cmdlog.ExecuteNonQuery();
            sqlCon.Close();

            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);
            Response.Redirect($"dashboard.aspx");
            //Response.Write(query1);
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
            Session["inisialhk"] = "buka";

        }

        void tableticket()
        {
            query = $@"select r.id_parameter, t.device, t.sn, r.parameter, r.satuan, r.tipe from mainhk_3m_perangkat t join mainhk_3m_parameter r on r.id_perangkat=t.id_perangkat
                    where t.lokasi='{lokasi}' and t.satelit= '{satelit}' and t.equipment = '{equipment}' order by r.id_parameter, t.sn";


            string tanggal = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><<th>Device</th><th>Serial Number</th><th>Parameter</th><th>Nilai Before</th><th>Satuan</th></tr>");
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
                        SN = ds.Tables[0].Rows[i]["sn"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["parameter"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["satuan"].ToString();
                        device = ds.Tables[0].Rows[i]["device"].ToString();

                        style3 = "font-weight:normal; font-size:12px;";

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;
                        idtgl = "tgl" + IDdata;

                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + device + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        if (tipe == "N")
                            htmlTable.Append("<td>" + $"<input type =\"text\" value=\"{nilai}\" runat=\"server\" class=\"form-control\" name=\"idticket\" id={idtxt}>" + "</td>");
                        else if (tipe == "OA")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"OK\"> OK </option><option value=\"OFF\" > OFF </option><option value=\"ALARM\" > ALARM </option></select > " + " </td>");
                        else if (tipe == "STT")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"STANDBY\"> STANDBY </option><option value=\"TRANSMIT\" > TRANSMIT </option><option value=\"TRANSMIT INHIBIT\" > TRANSMIT INHIBIT </option></select > " + " </td>");
                        else if (tipe == "OM")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"ON\"> ON </option><option value=\"MUTE\" > MUTE </option></select > " + " </td>");
                        else if (tipe == "GT")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"GOOD\"> GOOD </option><option value=\"TROUBLE\" > TROUBLE </option></select > " + " </td>");
                        else if (tipe == "GU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNGREASE\"> UNGREASE </option><option value=\"GREASE\" > GREASE </option></select > " + " </td>");
                        else if (tipe == "OO")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"ON\"> ON </option><option value=\"OFF\" > OFF </option><option value=\"ALARM\"> ALARM </option></select > " + " </td>");
                        else if (tipe == "PU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNPOINT\"> UNPOINT </option><option value=\"POINT\" > POINT </option></select > " + " </td>");
                        else if (tipe == "TU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNTEST\"> UNTEST </option><option value=\"TEST\" > TEST </option></select > " + " </td>");
                        else if (tipe == "WU")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"UNWASH\"> UNWASH </option><option value=\"WASH\" > WASH </option></select > " + " </td>");

                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable.Append("</tr>");
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
                            akhir[j] = "('" + tanggal + "','" + iduser + "','" + looping[j] + "','" + line + "','" + triwulan + "','" + "before" + "','" + tahun + "')";
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