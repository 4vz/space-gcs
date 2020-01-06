using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.ticket
{
    public partial class ticket : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", statuss = "st", style1 = "a", query, divisi = "", style2 = "a", style3, prioritas = "a", statusticket="a", queryfav, queydel, jenisview = "";
        string statusreply = "a", divisireply="A";
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
            sqlCon.Open();
            queydel = $@"UPDATE ticket_user SET statusticket = 'delete' where id_ticket in ({HiddenField1.Value})";
            SqlCommand sqlCmd = new SqlCommand(queydel, sqlCon);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(HiddenField1.Value);
        }



        void tableticket()
        {
            divisi = Session["jenis1"].ToString();

            if (divisi == "og" || divisi == "os")
                query = "SELECT * FROM ticket_user WHERE statusticket != 'delete' order by id_ticket desc";
            else
                query = $"SELECT * FROM ticket_user WHERE statusticket != 'delete' and divisiuser = '{divisi}' order by id_ticket desc";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            /*if (Session["jenis1"].ToString() == "tcc")
            {
                jenisedit = "visible";
                jenisview = "hidden";
            }
            else
            {
                jenisedit = "hidden";
                jenisview = "visible";
            }*/


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th><input type=\"checkbox\" id=\"checkBoxAll\"/></th><th>Tanggal</th><th>Nama User</th><th>Subject</th><th>Status</th><th>Prioritas</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_ticket"].ToString();
                        statuss = ds.Tables[0].Rows[i]["status"].ToString();
                        prioritas = ds.Tables[0].Rows[i]["prioritas"].ToString();
                        statusticket = ds.Tables[0].Rows[i]["statusticket"].ToString();;
                        divisireply = ds.Tables[0].Rows[i]["divisireply"].ToString();

                        if (statuss == "sent")
                            style1 = "label-default";
                        else if (statuss == "accept")
                            style1 = "label-primary";
                        else if (statuss == "reject")
                            style1 = "label-danger";
                        else if (statuss == "complete")
                            style1 = "label-info";
                        else if (statuss == "incomplete")
                            style1 = "label-warning";
                        else if (statuss == "close")
                            style1 = "label-success";

                        int index = Convert.ToInt32(ds.Tables[0].Rows[i]["id_ticket"].ToString());

                        if (prioritas == "Low")
                            style2 = "label-default";
                        else if (prioritas == "Medium")
                            style2 = "label-success";
                        else if (prioritas == "High")
                            style2 = "label-danger";

                        if (statusticket == "unread" && divisireply != divisi)
                            style3 = "font-weight:bold";
                        else
                            style3 = "font-weight:normal";

                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<input type =\"checkbox\" runat=\"server\" class=\"chkCheckBoxId\" name=\"idticket\" value={ds.Tables[0].Rows[i]["id_ticket"].ToString()}>" + " </td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + ds.Tables[0].Rows[i]["tanggal"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["nama_user"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["subject"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label class=\"label label-sm {style1}\" style=\"pointer-events:none; width:70px;\">" + ds.Tables[0].Rows[i]["status"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label class=\"label label-sm {style2}\" style=\"pointer-events:none; width:70px;\">" + ds.Tables[0].Rows[i]["prioritas"] + "</label>" + "</td>");
                        htmlTable.Append($"<td style=\"visibility: {jenisview};\"> " + $"<a href=\"../ticket/detail.aspx?id={index}\" value='ID_Perangkat' id=aku CommandArgument=");
                        htmlTable.Append((ds.Tables[0].Rows[i]["subject"]));
                        htmlTable.Append(" > View</a>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}