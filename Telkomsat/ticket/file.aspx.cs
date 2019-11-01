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
    public partial class file : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", statuss = "st", style1 = "a", style2 = "a", prioritas = "a", queryfav, query, divisi, queydel, jenisview = "";
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
            query = "select u.tanggal, namafiles, u.nama_user from ticket_file f join ticket_user u on f.id_ticket=u.id_ticket ";

            SqlCommand cmd = new SqlCommand(query, sqlCon);

            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable.Append("<table id=\"example1\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>Nama User</th><th>File</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //int index = Convert.ToInt32(ds.Tables[0].Rows[i]["id_ticket"].ToString());
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + ds.Tables[0].Rows[i]["tanggal"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["nama_user"] + "</td>");
                        htmlTable.Append("<td>" + $"<asp:Button runat = \"server\" OnClick=\"InkView_Click\" Text = \"{ds.Tables[0].Rows[i]["namafiles"]}\" />" + "</td>");
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