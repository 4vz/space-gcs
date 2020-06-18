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

namespace Telkomsat.maintenancehk.tigabulan
{
    public partial class isibbu : System.Web.UI.Page
    {
        SqlDataAdapter da, dabar;
        DataSet ds = new DataSet();
        DataSet dsbar = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", equipment, start = "a", query, end = "", nilai, style3, SN = "a", serialnumber, kategori, jenisview = "", kategori22, tahun;
        string triwulan;

        string Parameter, iduser, query2 = "A", idddl = "s", idsatuan, value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, rdevice, ralias, query1, date, inisial, device, alias, tanggal, valuestn;
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0, k, m = 0;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string queryisi;
            if (Request.QueryString["sn"] != null)
            {
                serialnumber = Request.QueryString["sn"];
                kategori = Request.QueryString["equipment"];
                lblroom.Text += kategori;
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

            if (now > first && now <= second)
            {
                triwulan = "triwulan 1";
                start = new DateTime(DateTime.Now.Year, 1, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 3, 30).ToString("yyyy/MM/dd");
            }
            else if (now > third && now <= fourth)
            {
                triwulan = "triwulan 2";
                start = new DateTime(DateTime.Now.Year, 4, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 6, 30).ToString("yyyy/MM/dd");
            }
            else if (now > fifth && now <= sixth)
            {
                triwulan = "triwulan 3";
                start = new DateTime(DateTime.Now.Year, 7, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 9, 30).ToString("yyyy/MM/dd");
            }
            else if (now > seventh && now <= eighth)
            {
                triwulan = "triwulan 4";
                start = new DateTime(DateTime.Now.Year, 10, 1).ToString("yyyy/MM/dd");
                end = new DateTime(DateTime.Now.Year, 12, 30).ToString("yyyy/MM/dd");
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
            query1 = $"insert into mainhk_bbu_data (tanggal, id_profile, id_parameter, data, triwulan, satuan, tahun) values {data}";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            //Response.Write(data);
            Session["inisialhk"] = null;
            Button1.Enabled = true;
            //this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);

            string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
            string querylog = $@"Insert into log (id_profile, tanggal, tipe, judul) values
                                ('{iduser}', '{tanggalku}', 'mainhk', 'maintenance triwulan bbu Harkat')";
            sqlCon.Open();
            SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
            cmdlog.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect($"dashboardbbu.aspx");
            //Response.Write(query1);
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
            Session["inisialhk"] = "buka";

        }

        void tableticket()
        {
            query = $@"select id_parameter, kategori2, parameter from mainhk_bbu_parameter where sn='{serialnumber}' and kategori1='{kategori}' order by id_parameter";


            string tanggal = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><<th>Kategori</th><th>Parameter</th><th>Nilai</th><th>Satuan</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");

            int count = ds.Tables[0].Rows.Count;
            string[] looping = new string[count];
            string[] loopingstn = new string[count];
            akhir = new string[count];
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_parameter"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["parameter"].ToString();
                        kategori22 = ds.Tables[0].Rows[i]["kategori2"].ToString();

                        style3 = "font-weight:normal; font-size:12px;";

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;
                        idsatuan = "tgl" + IDdata;

                        if (Session["inisialhk"] != null)
                            nilai = ds.Tables[0].Rows[i]["data"].ToString();
                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + kategori22 + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<input type =\"text\" value=\"{nilai}\" runat=\"server\" class=\"form-control\" name=\"idticket\" id={idtxt}>" + "</td>");
                        htmlTable.Append("<td>" + $"<input type=\"text\" class=\"form-control\" name=\"datasatuan\" id=\"{idsatuan}\" autocomplete=\"off\" />" + "</td>");
                        htmlTable.Append("</tr>");
                        value = Request.Form["idticket"];
                        valuestn = Request.Form["datasatuan"];

                        //Response.Write(value);

                        looping[i] = IDdata;

                    }

                    if (valuestn != null)
                    {
                        string[] datelines = Regex.Split(valuestn, ",");

                        foreach (string dateline in datelines)
                        {
                            loopingstn[m] = dateline;
                            m++;
                        }
                    }

                    if (value != null)
                    {
                        string[] lines = Regex.Split(value, ",");

                        foreach (string line in lines)
                        {
                            //Response.Write(line);
                            akhir[j] = "('" + tanggal + "','" + iduser + "','" + looping[j] + "','" + line + "','" + triwulan + "','" + loopingstn[j] + "','" + tahun + "')";
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