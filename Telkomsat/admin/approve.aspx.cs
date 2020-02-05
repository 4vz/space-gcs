using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Globalization;

namespace Telkomsat.admin
{
    public partial class approve : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, da2;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string IDdata = "kitaa", total = "", keterangan, tanggal = "", id, dketerangan, dnominal,dfile, dapprove, brame, style, input = "", kategori = "", input1 = "", kategori1 = "", query;
        string start = "01/01/2019", end = "01/12/2048";


        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        int rek1harkat, rek2harkat, rek1me, rek2me, harkat, me;
        protected void Page_Load(object sender, EventArgs e)
        {
            tableticket();
            if(Request.QueryString["id"].ToString() != null)
            {
                id = Request.QueryString["id"].ToString();
            }
            string myquery = $"UPDATE administrator SET gm = 'read' WHERE id_admin = {id}";
            string query = $@"select a.gm, a.id_admin, keterangan, tanggal, input, kategori, p.nama from administrator a left join
                            adminuser r on a.id_admin = r.id_admin left join Profile p on p.id_profile = r.id_profile
                            where a.id_admin = '{id}'";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da1 = new SqlDataAdapter(cmd);
            da1.Fill(ds1);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            lblkategori.Text = ds1.Tables[0].Rows[0]["kategori"].ToString();
            lblketerangan.Text = ds1.Tables[0].Rows[0]["keterangan"].ToString();
            lblnominal.Text = ds1.Tables[0].Rows[0]["input"].ToString();
            lblpic.Text = ds1.Tables[0].Rows[0]["nama"].ToString();

            if(ds1.Tables[0].Rows[0]["gm"].ToString() == "unread")
            {
                sqlCon.Open();
                SqlCommand cmd3 = new SqlCommand(myquery, sqlCon);
                cmd3.ExecuteNonQuery();
                sqlCon.Close();
            }
        }

        void tableticket()
        {

            string query = $"select d.id_detail, d.d_tanggal, d.d_keterangan, d.d_nominal, d.d_file, d.d_approve from admindetail d where d_keterangan != '' and id_admin = '{id}'";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>Keterangan</th><th>Nominal</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DateTime datee = (DateTime)ds.Tables[0].Rows[i]["d_tanggal"];
                        tanggal = datee.ToString("dd/MM/yyyy");
                        IDdata = ds.Tables[0].Rows[i]["id_detail"].ToString();
                        dketerangan = ds.Tables[0].Rows[i]["d_keterangan"].ToString();
                        dfile = ds.Tables[0].Rows[i]["d_file"].ToString();
                        dapprove = ds.Tables[0].Rows[i]["d_approve"].ToString();
                        dnominal = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(ds.Tables[0].Rows[i]["d_nominal"].ToString()));
                        
                        if (kategori == "pemasukan")
                            style = "label-info";
                        else if (kategori == "pengeluaran")
                            style = "label-warning";
                        else if (kategori == "pemindahan")
                            style = "label-primary";

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + dketerangan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:12px;\">" + dnominal + "</label>" + "</td>");
                        if (dapprove != "approve")
                            htmlTable.Append("<td>" + $"<a onclick=\"confirmselesai('../datalogbook/action.aspx?ida={IDdata}&idadmin={IDdata}')\" class=\"btn btn-sm btn-default\" style=\"margin-right:10px\">" + "APPROVE" + "</a>" + "</td>");
                        else
                            htmlTable.Append("<td>" + $"<a class=\"label label-primary\" style=\"margin-right:10px\">" + "TERAPPROVE" + "</a>" + "</td>");
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