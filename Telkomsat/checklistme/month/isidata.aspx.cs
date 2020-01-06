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

namespace Telkomsat.checklistme.month
{
    public partial class isidata : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", querytanggal = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string Parameter = "a", query2 = "A", idddl = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, query1, date, inisial, start, end;
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0, k, startmonth, endmonth, startyear, endyear;
        int jenischeck;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["mastersheltermemonth"] != null)
                {
                    DropDownList1.Text = Session["mastersheltermemonth"].ToString();
                }
            }

            if (Request.QueryString["room"] != null)
            {
                room = Request.QueryString["room"];
                lblroom.Text = room;

                string bulanow = DateTime.Now.ToString("MM");
                string tahunow = DateTime.Now.ToString("yyyy");

                startmonth = Convert.ToInt32(bulanow);
                endmonth = Convert.ToInt32(bulanow) + 1;
                startyear = Convert.ToInt32(tahunow);
                if (bulanow == "12")
                {
                    endyear = Convert.ToInt32(tahunow) + 1;
                }
                else
                {
                    endyear = Convert.ToInt32(tahunow);
                }

                start = startyear + "/" + startmonth + "/01";
                if (startmonth == 12)
                {
                    endmonth = 1;
                }
                end = endyear + "/" + endmonth + "/01";

                query2 = $@"select count(*) from checkme_parameterwmy r left join
                        checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat left join checkme_datawmy d on d.id_parameter = r.id_parameter
                        where p.ruangan = '{DropDownList1.SelectedValue}' AND '{start}' <= d.tanggal and d.tanggal < '{end}' and d.jenis = 'month'";
                sqlCon.Open();
                SqlCommand cmd5 = new SqlCommand(query2, sqlCon);
                string output = cmd5.ExecuteScalar().ToString();
                jenischeck = Convert.ToInt32(output);
                sqlCon.Close();
                if (jenischeck >= 1)
                {
                    lbledit.Visible = true;
                    lbledit.Text = $"Data checklist sudah terisi untuk bulan ini klik untuk ";
                    LinkButton1.Visible = true;
                }
                else
                {
                    tableticket();
                }
            }
           
            

        }
        protected void Pilih_Click(object sender, EventArgs e)
        {
            Response.Write("ihjkj");
            Session["mastersheltermemonth"] = DropDownList1.Text;
            Response.Redirect($"~/checklistme/month/isidata.aspx?room={DropDownList1.SelectedValue}", true);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editharian.aspx?room={room}&waktu=6");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string data = string.Join(",", akhir);
            query1 = $"insert into checkme_datawmy (tanggal, id_profile, id_parameter, jenis, nilai) values {data}";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            Session["inisialmonth"] = null;

            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
           
            Session["inisialmonth"] = "buka";

        }

        void tableticket()
        {
            if (Session["inisialmonth"] != null)
                query = $@"select r.id_parameter, p.Perangkat, r.satuan, p.sn, p.ruangan, r.parameter, r.tipe, d.nilai from checkme_parameterwmy r left join
                            checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat left join checkme_datawmy d on d.id_parameter = r.id_parameter
                            where ruangan = '{room}' AND d.tanggal = (SELECT MAX(tanggal) from checkme_datawmy d LEFT join checkme_parameterwmy r 
                            on r.id_parameter=d.id_parameter left join checkme_perangkatwmy p on p.ID_Perangkat = r.ID_Perangkat
                            where p.ruangan = '{room}' and d.nilai is not null) and d.jenis = 'month' order by r.id_perangkat";
            else
                query = $@"select r.id_parameter, p.Perangkat, r.satuan, p.sn, p.ruangan, r.parameter, r.tipe from checkme_parameterwmy r left join
                        checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat where ruangan = '{room}' and kategori = 'month' order by r.id_perangkat";


            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Perangkat</th><th>Serial Number</th><th>Parameter</th><th style=\"min-width:100px\">Nilai</th><th>Satuan</th></tr>");
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
                        ruangan = ds.Tables[0].Rows[i]["ruangan"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["satuan"].ToString();

                        style3 = "font-weight:normal";

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;

                        if (Session["inisialmonth"] != null)
                            nilai = ds.Tables[0].Rows[i]["nilai"].ToString();
                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Perangkat + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        if (tipe == "N")
                            htmlTable.Append("<td>" + $"<input type =\"text\" value=\"{nilai}\" runat=\"server\" class=\"form-control\" name=\"idticket\" id={idtxt}>" + "</td>");
                        else if (tipe == "BN")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"BIR\" > BIR </option><option value =\"NO BIR\"> NO BIR </option></select > " + " </td>");
                        else if (tipe == "OC")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"OPEN\" > OPEN </option><option value =\"CLOSE\"> CLOSE </option></select > " + " </td>");
                        else if (tipe == "FL")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"FULL\" > FULL </option><option value =\"LOW\"> LOW </option></select > " + " </td>");
                        else if (tipe == "AN")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"ALREADY\" > ALREADY </option><option value =\"NOT YET\"> NOT YET </option></select > " + " </td>");

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
                            akhir[j] = "('" + tanggal + "','" + "3" + "','" + looping[j] + "','" + "month" + "','" + line + "')";
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