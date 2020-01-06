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

namespace Telkomsat._3monthhk
{
    public partial class add : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", querytanggal = "a", query, waktu = "", nilai = "", style4 = "a", style3, satelit = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string Parameter1 = "a", Parameter2 = "a", Parameter3 = "a", query2 = "A", idddl = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, param, query1, date, inisial;
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0, k;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["parameter"] != null)
            {
                param = Request.QueryString["parameter"];
                lblroom.Text = param;
                tableticket();
            }

            if(Session["3mbbu"] != null)
            {
                if (Session["3mbbu"].ToString() == "T21" || Session["3mbbu"].ToString() == "T22" || Session["3mbbu"].ToString() == "T3SC1" || Session["3mbbu"].ToString() == "T3SC2")
                {
                    divbiasa.Attributes.CssStyle.Add("display", "block");
                    div4.Attributes.CssStyle.Add("display", "none");
                    Session["3mbbu"] = Session["3mbbu"].ToString();
                    value = null;
                }
                else if (Session["3mbbu"].ToString() == "MP1" || Session["3mbbu"].ToString() == "MP2")
                {
                    div4.Attributes.CssStyle.Add("display", "block");
                    divbiasa.Attributes.CssStyle.Add("display", "none");
                    Session["3mbbu"] = Session["3mbbu"].ToString();
                    value = null;
                }
            }
            
        }

        protected void Pilih_Click(object sender, EventArgs e)
        {
            if (ddlbbu.SelectedValue == "T21" || ddlbbu.SelectedValue == "T22" || ddlbbu.SelectedValue == "T3SC1" || ddlbbu.SelectedValue == "T3SC2")
            {
                divbiasa.Attributes.CssStyle.Add("display", "block");
                div4.Attributes.CssStyle.Add("display", "none");
                Session["3mbbu"] = ddlbbu.SelectedValue;
                value = null;
            }
            else if (ddlbbu.SelectedValue == "MP1" || ddlbbu.SelectedValue == "MP2")
            {
                div4.Attributes.CssStyle.Add("display", "block");
                divbiasa.Attributes.CssStyle.Add("display", "none");
                Session["3mbbu"] = ddlbbu.SelectedValue;
                value = null;
            }

            
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
            Session["inisial3"] = "buka";

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editharian.aspx?room={param}&waktu=6");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        void tableticket()
        {
            if(Session["3mbbu"] != null)
            {
                if (Session["inisial3"] != null)
                    query = $@"select r.id_parameter, p.Perangkat, r.satuan, p.sn, p.ruangan, r.parameter, r.tipe, d.nilai from checkme_parameterwmy r left join
                            checkme_perangkatwmy p on p.id_perangkat = r.id_perangkat left join checkme_datawmy d on d.id_parameter = r.id_parameter
                            where ruangan = '{param}' AND d.tanggal = (SELECT MAX(tanggal) from checkme_datawmy d LEFT join checkme_parameterwmy r 
                            on r.id_parameter=d.id_parameter left join checkme_perangkatwmy p on p.ID_Perangkat = r.ID_Perangkat
                            where p.ruangan = '{param}' and d.nilai is not null) and d.jenis = 'year' order by r.id_perangkat";
                else
                    query = $@"select r.id_parameter, p.Perangkat, p.satelit, r.parameter1, r.parameter2, r.parameter3, r.satuan from mpar_3month r left join
                        mper_3month p on p.id_perangkat = r.id_perangkat where r.id_perangkat = '{Session["3mbbu"]}' and r.parameter1 = '{param}' order by r.id_perangkat";


                string tanggal = DateTime.Now.ToString("yyyy/MM/dd");

                SqlCommand cmd = new SqlCommand(query, sqlCon);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();


                htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
                htmlTable.Append("<thead>");
                htmlTable.Append("<tr><th>Satelit</th><th>Parameter 1</th><th>Parameter 2</th><th>Parameter 3</th><th style=\"min-width:100px\">Nilai</th><th>Satuan</th></tr>");
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
                            satelit = ds.Tables[0].Rows[i]["satelit"].ToString();
                            Parameter1 = ds.Tables[0].Rows[i]["parameter1"].ToString();
                            Parameter2 = ds.Tables[0].Rows[i]["parameter2"].ToString();
                            Parameter3 = ds.Tables[0].Rows[i]["parameter3"].ToString();
                            satuan = ds.Tables[0].Rows[i]["satuan"].ToString();

                            style3 = "font-weight:normal";

                            idtxt = "txt" + IDdata;
                            idddl = "ddl" + IDdata;

                            if (Session["inisialyear"] != null)
                                nilai = ds.Tables[0].Rows[i]["nilai"].ToString();
                            //Response.Write(Session["jenis1"].ToString());
                            //HiddenField1.Value = IDdata;
                            htmlTable.Append("<tr>");
                            htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + satelit + "</label>" + "</td>");
                            htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter1 + "</label>" + "</td>");
                            htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter2 + "</label>" + "</td>");
                            htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter3 + "</label>" + "</td>");
                            htmlTable.Append("<td>" + $"<input type =\"text\" value=\"{nilai}\" runat=\"server\" class=\"form-control\" name=\"idticket\" id={idtxt}>" + "</td>");
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
                                akhir[j] = "('" + tanggal + "','" + "3" + "','" + looping[j] + "','" + "year" + "','" + line + "')";
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
}