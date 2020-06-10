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


namespace Telkomsat.checklistme.semester
{
    public partial class updatedata : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", querytanggal = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string Parameter = "a", query2 = "A", idddl = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, query1, date, inisial, tahun, semester;
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0, k;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["mastersheltermesemester"] != null)
                {
                    DropDownList1.Text = Session["mastersheltermesemester"].ToString();
                }
            }

            if (Request.QueryString["room"] != null)
            {
                room = Request.QueryString["room"];
                lblroom.Text = room;
            }

            DateTime now = DateTime.Now;
            DateTime startdate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime middate = new DateTime(DateTime.Now.Year, 6, 30);
            DateTime enddate = new DateTime(DateTime.Now.Year, 12, 30);
            tahun = DateTime.Now.Year.ToString();

            if (now > startdate && now <= middate)
            {
                semester = "1";
            }
            else if (now > middate && now <= enddate)
            {
                semester = "2";
            }

            tableticket();
        }
        protected void Pilih_Click(object sender, EventArgs e)
        {
            Session["mastersheltermesemester"] = DropDownList1.Text;
            Response.Redirect($"~/checklistme/semester/isidata.aspx?room={DropDownList1.SelectedValue}", false);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editharian.aspx?room={room}&waktu=6");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string data = string.Join(",", akhir);

            string query5, myid;
            SqlDataAdapter da2;
            DataSet ds2 = new DataSet();
            query5 = $@"select d.id_data, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe, d.nilai, d.tanggal from checkme_parameterwmy r left join
                    checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat left join checkme_datawmy d on d.id_parameter = r.id_parameter
                    and d.semester = '{semester}' and d.tahun = '{tahun}' where ruangan='{room}' and r.kategori='semester' order by r.id_perangkat";

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
                        string myquery1 = $@"UPDATE checkme_datawmy SET nilai = '{akhir[i]}' WHERE id_data = '{myid}'";
                        sqlCon.Open();
                        SqlCommand sqlcmd = new SqlCommand(myquery1, sqlCon);
                        sqlcmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);

            Response.Redirect($"checkdata.aspx");
            Response.Write(query1);
        }

        void tableticket()
        {
            query = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe, d.nilai, d.tanggal from checkme_parameterwmy r left join
                    checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat left join checkme_datawmy d on d.id_parameter = r.id_parameter
                    and d.semester = '{semester}' and d.tahun = '{tahun}' where ruangan='{room}' and r.kategori='semester' order by r.id_perangkat";


            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            string pilih;
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
                        nilai = ds.Tables[0].Rows[i]["nilai"].ToString();

                        style3 = "font-weight:normal";

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;

                        if (nilai == "NOT YET" || nilai == "NO BIR" || nilai == "CLOSE" || nilai == "LOW")
                            pilih = "";
                        else
                            pilih = "selected";

                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Perangkat + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        if (tipe == "N")
                            htmlTable.Append("<td>" + $"<input type =\"text\" value=\"{nilai}\" runat=\"server\" class=\"form-control\" name=\"idticket\" id={idtxt}>" + "</td>");
                        else if (tipe == "BN")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"NO BIR\"> NO BIR </option><option value=\"BIR\" {pilih}> BIR </option></select > " + " </td>");
                        else if (tipe == "OC")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"CLOSE\"> CLOSE </option><option value=\"OPEN\" {pilih}> OPEN </option></select > " + " </td>");
                        else if (tipe == "FL")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"LOW\"> LOW </option><option value=\"FULL\" {pilih}> FULL </option></select > " + " </td>");
                        else if (tipe == "AN")
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value =\"NOT YET\"> NOT YET </option><option value=\"ALREADY\" {pilih}> ALREADY </option></select > " + " </td>");

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
                            akhir[j] = line;
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