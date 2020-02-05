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
    public partial class listpengeluaran : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string IDdata = "kitaa", total = "", keterangan, tanggal = "", nominal, nama, approve, brame, style, input = "", kategori = "", style5 = "", kategori1 = "", query;
        string start = "01/01/2019", end = "01/12/2048";


        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        int rek1harkat, rek2harkat, rek1me, rek2me, harkat, me;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                query = @"select a.id_admin, a.tanggal, a.keterangan, a.input, p.nama, a.approve, a.gm from administrator a left join adminuser u
                        on a.id_admin=u.id_admin left join Profile p on p.id_profile=u.id_profile where a.kategori='pengeluaran' order by a.tanggal desc";
                tableticket();
            }

        }
        void tableticket()
        {


            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>Nama</th><th>Keterangan</th><th>Nominal</th><th>Status</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_admin"].ToString();
                        DateTime datee = (DateTime)ds.Tables[0].Rows[i]["tanggal"];
                        tanggal = datee.ToString("dd/MM/yyyy");
                        keterangan = ds.Tables[0].Rows[i]["keterangan"].ToString();
                        nominal = ds.Tables[0].Rows[i]["input"].ToString();
                        nama = ds.Tables[0].Rows[i]["nama"].ToString();
                        approve = ds.Tables[0].Rows[i]["approve"].ToString();

                        if (ds.Tables[0].Rows[i]["gm"].ToString() == "unread")
                            style5 = "font-weight:bold;";
                        else
                            style5 = "font-weight:normal;";

                        if (approve == "approve")
                            style = "label label-info";
                        else if (approve == "not approve")
                            style = "label label-warning";

                        htmlTable.Append($"<tr style=\"{style5}\">");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:10px; {style5} color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + nama + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + keterangan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + nominal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {style5}\" class=\"{style}\">" + approve + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a  style=\"cursor:pointer\" href=\"/admin/approve.aspx?id={IDdata}\">" + $"<label>" + "view" + "</label>" + "</a>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });

                }
            }
        }

        protected void Filter_ServerClick(object sender, EventArgs e)
        {
            if (txtsdate.Value != "")
                start = txtsdate.Value;
            if (dateend.Value != "")
                end = dateend.Value;
            if (ddlpengeluaran.SelectedValue == "pengeluaran")
            {
                if (ddlpengeluaran.SelectedValue == "Cash")
                {
                    query = $@"select * from administrator where (tanggal BETWEEN (convert(datetime, '{txtsdate.Value}',103)) AND (convert(datetime, '{dateend.Value}',103)))
                            and kategori = 'pengeluaran' and status = 'done' order by id_admin desc";
                }
                else if (ddlpengeluaran.SelectedValue == "Panjar")
                {
                    query = $@"select * from administrator where (tanggal BETWEEN (convert(datetime, '{txtsdate.Value}',103)) AND (convert(datetime, '{dateend.Value}',103)))
                            and kategori = 'pengeluaran' and status != 'done' order by id_admin desc";
                }
                else
                {
                    query = $@"select * from administrator where (tanggal BETWEEN (convert(datetime, '{txtsdate.Value}',103)) AND (convert(datetime, '{dateend.Value}',103)))
                            and kategori = 'pengeluaran' order by id_admin desc";
                }
            }
            else
            {
                query = $@"select * from administrator where (tanggal BETWEEN (convert(datetime, '{start}',103)) AND (convert(datetime, '{end}',103)))
                            and kategori = {ddlpengeluaran.SelectedValue} order by id_admin desc";
            }

            tableticket();
        }

    }
}