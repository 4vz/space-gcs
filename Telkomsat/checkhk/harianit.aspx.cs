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


namespace Telkomsat.checkhk
{
    public partial class harianit : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable1 = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", querytanggal = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";


        string Parameter = "a", iduser, query2 = "A", idddl = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, query1, date, inisial, rack;
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0, k;

        StringBuilder htmltable = new StringBuilder();
        SqlConnection sqlcon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string tanggal, tanggal1;
        bool v = false;
        DateTime wib;
        double hasil, tampil, total, diisi;
        protected void Page_Load(object sender, EventArgs e)
        {
            tanggal = Request.QueryString["tanggal"];

            if (Request.QueryString["view"] != null)
                v = true;

            if (Request.QueryString["view"] == "view")
                divdata.Visible = true;

            if (Session["iduser"] != null)
            {
                iduser = Session["iduser"].ToString();
            }

            if (Request.QueryString["inisialisasi"] == null)
            {
                query = $@"select r.id_parameter, p.Perangkat, r.satuan, p.sn, p.shelter, r.parameter, p.rack, r.tipe from checkhk_parameter r left join
                        checkhk_perangkat p on p.id_perangkat = r.id_perangkat where shelter = 'Console' order by p.rack, r.id_parameter, p.id_perangkat";
            }
            else
            {
                query = $@"select d.tanggal, d.data, r.id_parameter, p.Perangkat, r.satuan, p.sn, p.shelter, r.parameter, p.rack, r.tipe from checkhk_parameter r left join
                        checkhk_perangkat p on p.id_perangkat = r.id_perangkat left join checkhk_data d on d.id_parameter = r.id_parameter
						where shelter = 'Console' AND d.tanggal = (SELECT MAX(tanggal) from checkhk_data d join checkhk_parameter r 
					    on r.id_parameter=d.id_parameter left join checkhk_perangkat p on p.id_perangkat = r.id_perangkat
					    where p.shelter = 'Console' and d.data is not null) order by p.rack, r.id_parameter, p.id_perangkat";
            }

            date = DateTime.Now.ToString("yyyy/MM/dd");

            query2 = $@"select count(*) from checkhk_parameter r left join
                    checkhk_perangkat p on p.id_perangkat = r.id_perangkat left join checkhk_data d on d.id_parameter = r.id_parameter
                    where shelter = 'Console' AND '{date} 00:00:00' <= d.tanggal and d.tanggal < '{date} 23:59:59' and p.shelter = 'Console'";
            sqlcon.Open();
            SqlCommand cmd5 = new SqlCommand(query2, sqlcon);
            string output = cmd5.ExecuteScalar().ToString();
            int jenischeck = Convert.ToInt32(output);
            sqlcon.Close();
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

            tablepersen();
            approval();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editharianit.aspx?tanggal={date}&room=Console");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string tanggal;
            DateTime tg = DateTime.Now;
            tanggal = tg.ToString("yyyy/MM/dd");
            querytanggal = $"insert into checkhk_tanggal (tanggalhk, id_profile) values ('{date}', '3')";
            //Console.Write(query1);
            sqlcon.Open();
            SqlCommand cmd7 = new SqlCommand(querytanggal, sqlcon);
            cmd7.ExecuteNonQuery();
            sqlcon.Close();

            string data = string.Join(",", akhir);
            query1 = $"insert into checkhk_data (tanggal, id_profile, id_parameter, data, lokasi) values {data}";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlcon);
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
            string query5 = $"select * from log where judul='checklist harian IT Cibinong' and tanggal = '{tanggalku}'";
            SqlDataAdapter da5;
            DataSet ds5 = new DataSet();
            SqlCommand cmd5 = new SqlCommand(query5, sqlcon);
            da5 = new SqlDataAdapter(cmd5);
            da5.Fill(ds5);
            sqlcon.Open();
            cmd5.ExecuteNonQuery();
            sqlcon.Close();


            if (ds5.Tables[0].Rows.Count == 0)
            {
                string querylog = $@"Insert into log (id_profile, tanggal, tipe, judul) values
                                ('{iduser}', '{tanggalku}', 'tch', 'checklist harian IT Cibinong')";
                sqlcon.Open();
                SqlCommand cmdlog = new SqlCommand(querylog, sqlcon);
                cmdlog.ExecuteNonQuery();
                sqlcon.Close();
            }


            //Response.Write(data);
            Session["inisialhk"] = null;
            Button1.Enabled = true;
            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);
            Response.Redirect($"../checkhk/dashboard.aspx?tanggal={tanggal}");
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
            Response.Redirect($"harianit.aspx?inisialisasi=ya");
        }

        void approval()
        {
            string petugas, aprrove, query;
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            query = $@"select (CAST(d.tanggal AS DATE)) as tanggal, p.nama, d.pic from checkhk_data d left join Profile p on d.id_profile = p.id_profile
						join checkhk_parameter r on r.id_parameter=d.id_parameter join checkhk_perangkat t on t.ID_Perangkat=r.id_perangkat where t.lokasi = 'itcbi'
                        and (CAST(d.tanggal AS DATE))='{tanggal}' group by CAST(d.tanggal AS DATE), nama, d.pic";
            sqlcon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlcon.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbltanggal.Text = ds.Tables[0].Rows[0]["tanggal"].ToString();
                lblpetugas.Text = ds.Tables[0].Rows[0]["nama"].ToString();
                if (ds.Tables[0].Rows[0]["pic"].ToString() == null || ds.Tables[0].Rows[0]["pic"].ToString() == "")
                    lblapproval.Text = "Belum di approve";
                else
                    lblapproval.Text = ds.Tables[0].Rows[0]["pic"].ToString();
            }
        }

        void tableticket()
        {

            //DataSet ds = Settings.LoadDataSet(query);
            string tanggal = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            SqlCommand cmd = new SqlCommand(query, sqlcon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();


            htmlTable1.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable1.Append("<thead>");
            htmlTable1.Append("<tr><th>Rack</th><th>Perangkat</th><th>Hostname</th><th>Parameter</th><th>Nilai</th><th>Satuan</th></tr>");
            htmlTable1.Append("</thead>");

            htmlTable1.Append("<tbody>");

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

                        if (Session["inisialhk"] != null)
                            nilai = ds.Tables[0].Rows[i]["data"].ToString();
                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable1.Append("<tr>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + rack + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + Perangkat + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        if (tipe == "N")
                            htmlTable1.Append("<td>" + $"<input type =\"text\" value=\"{nilai}\" runat=\"server\" class=\"form-control\" name=\"idticket\" id={idtxt}>" + "</td>");
                        else if (tipe == "OWA")
                            htmlTable1.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"Ok\" > Ok </option><option value =\"Warning\"> Warning </option><option value =\"Alarm\"> Alarm </option></select > " + " </td>");
                        else if (tipe == "OO")
                            htmlTable1.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"On\" > On </option><option value =\"Off\"> Off </option></select > " + " </td>");
                        else if (tipe == "OF")
                            htmlTable1.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"Ok\" > Ok </option><option value =\"Fail\"> Fail </option></select > " + " </td>");
                        else if (tipe == "WI")
                            htmlTable1.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"1WET\" > 1WET </option><option value =\"IDL\"> IDL </option></select > " + " </td>");
                        else if (tipe == "OA")
                            htmlTable1.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"OK\" > OK </option><option value =\"OFF\"> OFF </option><option value=\"ALARM\"> ALARM </option></select > " + " </td>");
                        else if (tipe == "OO")
                            htmlTable1.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"ON\" > ON </option><option value =\"OFF\"> OFF </option></select > " + " </td>");

                        htmlTable1.Append("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable1.Append("</tr>");
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
                            akhir[j] = "('" + tanggal + "','" + iduser + "','" + looping[j] + "','" + line + "','" + "cbi" + "')";
                            j++;
                        }
                    }
                    //Response.Write(string.Join("\n", akhir));
                    htmlTable1.Append("</tbody>");
                    htmlTable1.Append("</table>");

                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable1.ToString() });
                }
            }
        }


        void tablepersen()
        {
            string style, class1, ruang, querytotal, queryisi;
            SqlDataAdapter daheader, dapersen, dabar;
            DataSet dsheader = new DataSet();
            DataSet dspersen = new DataSet();
            DataSet dsbar = new DataSet();
            string queryheader = "select shelter from checkhk_perangkat p where p.lokasi = 'itcbi' group by shelter order by shelter";
            sqlcon.Open();
            SqlCommand cmdheader = new SqlCommand(queryheader, sqlcon);
            daheader = new SqlDataAdapter(cmdheader);
            daheader.Fill(dsheader);
            cmdheader.ExecuteNonQuery();
            sqlcon.Close();
            style = "font-weight:bold";
            wib = DateTime.UtcNow + new TimeSpan(7, 0, 0);
            tanggal1 = wib.ToString("yyyy/MM/dd");
            if (dsheader.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsheader.Tables[0].Rows.Count; ++i)
                {
                    dsbar.Clear();
                    ruang = dsheader.Tables[0].Rows[i]["shelter"].ToString();
                    querytotal = $@"select count(*) as total from checkhk_parameter r join checkhk_perangkat p on p.id_perangkat=r.id_perangkat 
                                where shelter = '{ruang}' group by p.shelter order by shelter";
                    sqlcon.Open();
                    SqlCommand cmdruang = new SqlCommand(querytotal, sqlcon);
                    dapersen = new SqlDataAdapter(cmdruang);
                    dapersen.Fill(dspersen);
                    cmdruang.ExecuteNonQuery();
                    sqlcon.Close();

                    queryisi = $@"select count(*) as isi from checkhk_data d join checkhk_parameter r on d.id_parameter=r.id_parameter
                                join checkhk_perangkat p on p.id_perangkat=r.id_perangkat where 
								'{tanggal} 00:00:00' <= d.tanggal and d.tanggal < '{tanggal} 23:59:59' and d.data != ''
                                and shelter = '{ruang}' group by p.shelter order by shelter";
                    sqlcon.Open();
                    SqlCommand cmdisi = new SqlCommand(queryisi, sqlcon);
                    dabar = new SqlDataAdapter(cmdisi);
                    dabar.Fill(dsbar);
                    cmdisi.ExecuteNonQuery();
                    sqlcon.Close();
                    if (dsbar.Tables[0].Rows.Count > 0)
                    {
                        diisi = Convert.ToDouble(dsbar.Tables[0].Rows[0]["isi"].ToString());
                    }
                    else
                    {
                        diisi = 0;
                    }

                    total = Convert.ToDouble(dspersen.Tables[0].Rows[i]["total"].ToString());

                    hasil = ((double)diisi / total) * 100;

                    if (hasil == 100)
                    {
                        class1 = "progress-bar-green";
                    }
                    else
                    {
                        class1 = "progress-bar-red";
                    }
                    tampil = Math.Round(hasil);
                    if ((i % 5) == 0)
                    {
                        if (i > 1)
                            htmltable.AppendLine("</div>");
                        htmltable.AppendLine("<div class=\"col-md-12\">");
                    }
                    htmltable.AppendLine("<div class=\"progress-group\">");
                    if (tanggal == tanggal1 && !v)
                        htmltable.AppendLine($"<label style=\"font-size:14px;\">" + ruang + "</label>");
                    else
                        htmltable.AppendLine($"<label style=\"font-size:14px;\">" + ruang + "</label>");
                    htmltable.AppendLine($"<span class=\"progress-number\">" + tampil + "%</span>");
                    htmltable.AppendLine("<div class=\"progress sm\">");
                    htmltable.AppendLine($"<div class=\"progress-bar {class1}\" style=\"width:{tampil}% \"></div>");
                    htmltable.AppendLine($"</div></div>");
                }
                PlaceHolder1.Controls.Add(new Literal { Text = htmltable.ToString() });
            }
            /*Label[] arr = new Label[] { lblheader1, lblheader2, lblheader3, lblheader4, lblheader5, lblheader6, lblheader7, lblheader8, lblheader9, lblheader10,
            lblheader11, lblheader12, lblheader13, lblheader14, lblheader15, lblheader16, lblheader17, lblheader18, lblheader19, lblheader20,
            lblheader21, lblheader22, lblheader23};
            for (int i = 0; i < dsheader.Tables[0].Rows.Count; ++i)
            {
                arr[i].Text = dsheader.Tables[0].Rows[i]["ruangan"].ToString();
                arr[i].Font.Bold = true;
            }*/
        }
    }
}