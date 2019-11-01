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
    public partial class complete : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", statuss = "st", style1 = "a", query, divisi = "", style2 = "a", style3, prioritas = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string statusreply = "a", divisireply = "A";
        int hasil, selisih;
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

            query = $@"SELECT nama_user, tanggal_accept, tanggal_complete, kategoriwaktu,subject,
                    (select DateDiff(HOUR, tanggal_accept, tanggal_complete)) as selisih, affident
                    FROM ticket_user u join ticket_interval i on u.id_ticket = i.id_ticket WHERE tanggal_complete is not null";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead style=\"font-size:10px;\">");
            htmlTable.Append("<tr><th>Nama User</th><th>Tanggal Terima</th><th>Tanggal Selesai</th><th>Kategori</th><th>Selisih</th><th>Subject</th><th>Perform</th><th>Evidence</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string star;
                        
                        string evidence = ds.Tables[0].Rows[i]["affident"].ToString();
                        string kategori = ds.Tables[0].Rows[i]["kategoriwaktu"].ToString();
                        if (ds.Tables[0].Rows[i]["selisih"].ToString() != null)
                            selisih = Convert.ToInt32(ds.Tables[0].Rows[i]["selisih"].ToString());
                        else
                            selisih = 0;
                        if (kategori == "Recovery")
                            hasil = selisih - 5;
                            
                        else if (kategori == "Instalasi")
                            hasil = selisih - 12;
                        else if (kategori == "Repair")
                            hasil = selisih - 48;

                        if (hasil >= 0)
                            star = "text-gray fa-star-o";
                        else
                            star = "text-yellow fa-star";

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:10px;\">" + ds.Tables[0].Rows[i]["nama_user"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:9px; color:#a9a9a9; font-color width:70px;\">" + ds.Tables[0].Rows[i]["tanggal_accept"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:9px; color:#a9a9a9; font-color width:70px;\">" + ds.Tables[0].Rows[i]["tanggal_complete"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:10px;\">" + ds.Tables[0].Rows[i]["kategoriwaktu"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:10px;\">" + ds.Tables[0].Rows[i]["selisih"] + " Jam" + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:10px;\">" + ds.Tables[0].Rows[i]["subject"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px;\">" + $"<i class=\"fa {star}\"></i>" + "</td>");
                        htmlTable.Append($"<td style=\"visibility: true;\"> " + $"<a href=\"../ticket/download.aspx?file={evidence}\" value='ID_Perangkat' style=\"font-size:10px;\"");
                        htmlTable.Append(" > download</a>" + "</td>");
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