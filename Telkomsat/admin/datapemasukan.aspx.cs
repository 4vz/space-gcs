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
    public partial class datapemasukan : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string IDdata = "kitaa", total = "", keterangan, tanggal = "", rekharkat, rekme, braharkat, brame, style, input = "", kategori = "", input1 = "", kategori1 = "", query;
        string start = "01/01/2019", end = "01/12/2048", hijau;


        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        int rek1harkat, rek2harkat, rek1me, rek2me, harkat, me;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                query = @"select * from administrator where approve = 'admin' order by id_admin desc";
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
            htmlTable.Append("<tr><th>Tanggal</th><th>Keterangan</th><th>Input</th><th>Rek Harkat</th><th>Rek ME</th><th>Brs Harkat</th><th>Brs ME</th><th>Total</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_admin"].ToString();
                        DateTime tgl = Convert.ToDateTime(ds.Tables[0].Rows[i]["tanggal"]);
                        tanggal = tgl.ToString("dd MMM yyyy");
                        braharkat = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(ds.Tables[0].Rows[i]["bra_harkat"].ToString()));
                        brame = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(ds.Tables[0].Rows[i]["bra_me"].ToString()));
                        rek1harkat = Convert.ToInt32(ds.Tables[0].Rows[i]["rek_harkat1"].ToString());
                        rek2harkat = Convert.ToInt32(ds.Tables[0].Rows[i]["rek_harkat2"].ToString());
                        rek1me = Convert.ToInt32(ds.Tables[0].Rows[i]["rek_me1"].ToString());
                        rek2me = Convert.ToInt32(ds.Tables[0].Rows[i]["rek_me2"].ToString());
                        kategori = ds.Tables[0].Rows[i]["kategori"].ToString();
                        keterangan = ds.Tables[0].Rows[i]["keterangan"].ToString();
                        total = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToDecimal(ds.Tables[0].Rows[i]["total"].ToString()));


                        harkat = rek1harkat + rek2harkat;
                        me = rek1me + rek2me;

                        if (kategori == "pemasukan")
                            style = "label-info";
                        else if (kategori == "pengeluaran")
                            style = "label-warning";
                        else if (kategori == "pemindahan")
                            style = "label-success";

                        input1 = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToDecimal(ds.Tables[0].Rows[i]["input"].ToString()));

                        rekharkat = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(harkat));
                        rekme = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(me));
                        int index = Convert.ToInt32(IDdata);

                        if(i == 0)
                        {
                            hijau = "color:green";
                        }
                        else
                        {
                            hijau = "";
                        }
                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:11px; color:#a9a9a9; font-color width:70px; {hijau}\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {hijau}\">" + keterangan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a  style=\"cursor:pointer\" href=\"/admin/detail.aspx?id={IDdata}\">" + $"<label class=\"label label-sm {style}\">" + input1 + "</label>" + "</a>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {hijau}\">" + rekharkat + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {hijau}\">" + rekme + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {hijau}\">" + braharkat + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {hijau}\">" + brame + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {hijau}\">" + total + "</label>" + "</td>");
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
            if(txtsdate.Value != "")
                start = txtsdate.Value;
            if(dateend.Value != "")
                end = dateend.Value;
            if(ddlKategori.SelectedValue == "pengeluaran")
            {
                if(ddlpengeluaran.SelectedValue == "Cash")
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
                            and kategori = {ddlKategori.SelectedValue} order by id_admin desc";
            }
 
            tableticket();
        }


    }
}