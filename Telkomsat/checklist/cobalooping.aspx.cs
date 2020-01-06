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

namespace Telkomsat.checklist
{
    public partial class cobalooping : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", style1 = "a", query, divisi = "", style2 = "a", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string Parameter = "a", divisireply = "A", idddl = "s", value = "1", idtxt = "A", loop="";
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            tableticket();
            //if (Session["jenis1"].ToString() == "tcc")
            //  spam.Style["display"] = "none";
            
        }

        protected void disp_ServerClick(object sender, EventArgs e)
        {
            sqlCon.Open();
            queryfav = $@"UPDATE ticket_user SET statusticket = 'favorit' WHERE id_ticket in ({HiddenField1.Value})";
            SqlCommand sqlCmd = new SqlCommand(queryfav, sqlCon);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        protected void dispdelete_ServerClick(object sender, EventArgs e)
        {
            //Response.Write(HiddenField1.Value);
            query = @"select r.ID_Parameter from check_status s left join check_parameter r on r.ID_Parameter=s.ID_paramater left join
                            check_perangkat p on p.ID_Perangkat = r.ID_Perangkat
                            where(ID_tgl = (select max(ID_tgl)from check_status s join check_parameter r on r.ID_Parameter = s.ID_paramater
                            join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat where p.Shelter = 'mpsat')) and p.Shelter = 'mpsat' order by p.Rack, r.ID_Parameter";
            //else
            //  query = $"SELECT * FROM ticket_user WHERE statusticket != 'delete' and divisiuser = '{divisi}' order by id_ticket desc";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            
            //Response.Write(loop);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string data = string.Join("\n", akhir);
            string query1 = $"insert into check (a,b,v) values {data}";
            Response.Write(query1);

        }



        void tableticket()
        {
            /*divisi = Session["jenis1"].ToString();

            if (divisi == "og" || divisi == "os")*/
                query = @"select r.ID_Parameter, Perangkat, [S/N], Parameter from check_status s left join check_parameter r on r.ID_Parameter=s.ID_paramater left join
                            check_perangkat p on p.ID_Perangkat = r.ID_Perangkat
                            where(ID_tgl = (select max(ID_tgl)from check_status s join check_parameter r on r.ID_Parameter = s.ID_paramater
                            join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat where p.Shelter = 'mpsat')) and p.Shelter = 'mpsat' order by p.Rack, r.ID_Parameter";
            //else
            //  query = $"SELECT * FROM ticket_user WHERE statusticket != 'delete' and divisiuser = '{divisi}' order by id_ticket desc";
            string tanggal = DateTime.Now.ToString("dd/MM/yyyy");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th><input type=\"checkbox\" id=\"checkBoxAll\"/></th><th>Perangkat</th><th>Serial Number</th><th>Parameter</th><th>Nilai</th></tr>");
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
                        IDdata = ds.Tables[0].Rows[i]["ID_Parameter"].ToString();
                        Perangkat = ds.Tables[0].Rows[i]["Perangkat"].ToString();
                        SN = ds.Tables[0].Rows[i]["S/N"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["Parameter"].ToString();

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;

                        if (SN == "Low")
                            style2 = "label-default";
                        else if (SN == "Medium")
                            style2 = "label-success";
                        else if (SN == "High")
                            style2 = "label-danger";

                        if (statusticket == "unread" && divisireply != divisi)
                            style3 = "font-weight:bold";
                        else
                            style3 = "font-weight:normal";

                        if (Perangkat == "UP CONVERTER")
                            style1 = "2";
                        else
                            style1 = "0";

                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<input type =\"checkbox\" runat=\"server\" class=\"chkCheckBoxId\" name=\"idticket\" value={IDdata}>" + " </td>");
                        htmlTable.Append($"<td rowspan=\"{style1}\">" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["Perangkat"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["S/N"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["Parameter"] + "</label>" + "</td>");
                        if (Parameter != "Status")
                            htmlTable.Append("<td>" + $"<input type =\"text\" runat=\"server\" class=\"form-control\" name=\"idticket\" id={idtxt}>" + "</td>");
                        else
                            htmlTable.Append("<td>" + $"<select class=\"form-control dropdown\" onchange=\"SetDropDownListColor(this)\" id=\"{idddl}\" name=\"idticket\"><option value=\"pass\" style=\"background-color:#38f345;\" > Pass </option><option value =\"Fail\"> Fail </option></select > " + " </td>");
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
                            akhir[j] = "(" + "'" + looping[j] + "'," + "'" + tanggal + "'," + line + "), ";
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