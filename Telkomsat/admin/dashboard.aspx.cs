using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Globalization;

namespace Telkomsat.admin
{
    public partial class dashboard : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string nama, status, keterangan, lblcolor, queryupdate, querymodal, style, status1, tanda = "", hijau;
        string IDdata = "kitaa", total = "", querypanjar, tanggal = "", rekharkat, rekme, braharkat, brame, totalpanjar, input ="", kategori ="", input1 = "", kategori1 = "", query;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        int rek1harkat, rek2harkat, rek1me, rek2me, harkat, me, brankasharkat, brankasme;
        protected void Page_Load(object sender, EventArgs e)
        {
            tableticket();

            tablepanjar();

            dataupdate();

            modal();

            query = @"select id_admin, bra_harkat, bra_me, rek_harkat1, rek_harkat2, rek_me1, rek_me2, total
                                from administrator where id_admin = (select max(id_admin) from administrator)";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            rek1harkat = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_harkat1"].ToString());
            rek2harkat = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_harkat2"].ToString());
            brankasharkat = Convert.ToInt32(ds.Tables[0].Rows[0]["bra_harkat"].ToString());

            rek1me = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_me1"].ToString());
            rek2me = Convert.ToInt32(ds.Tables[0].Rows[0]["rek_me2"].ToString());
            brankasme = Convert.ToInt32(ds.Tables[0].Rows[0]["bra_me"].ToString());

            harkat = rek1harkat + rek2harkat + brankasharkat;
            me = rek1me + rek2me + brankasme;

            braharkat = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N0}", harkat);
            brame = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N0}", me);
            total = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N0}", Convert.ToInt32(ds.Tables[0].Rows[0]["total"].ToString()));

            dashharkat.Text = braharkat;
            dashme.Text = brame;
            dashtotal.Text = total;

            mylabel.Value = rek1harkat + "," + rek2harkat + "," + rek1me + "," + rek2me + "," + brankasharkat + "," + brankasme + ",";
        }

        void modal()
        {
            querymodal = @"SELECT rek_harkat1, rek_harkat2, bra_harkat, rek_me1, rek_me2, bra_me FROM administrator where id_admin = (select max(id_admin) from administrator)";

            SqlCommand cmd = new SqlCommand(querymodal, sqlCon);
            damodal = new SqlDataAdapter(cmd);
            damodal.Fill(dsmodal);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            lblrekharkat1.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["rek_harkat1"].ToString()));
            lblrekharkat2.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["rek_harkat2"].ToString()));
            lblbraharkat.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["bra_harkat"].ToString()));
            lblrekme1.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["rek_me1"].ToString()));
            lblrekme2.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["rek_me2"].ToString()));
            lblbrame.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["bra_me"].ToString()));
        }

        void tableticket()
        {
            query = @"select top 6 id_admin, status, bra_harkat, bra_me, rek_harkat1, rek_harkat2, rek_me1, rek_me2, kategori, input, tanggal, total
                                from administrator order by id_admin desc";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>Input</th><th>Rek Harkat</th><th>Rek ME</th><th>Brs Harkat</th><th>Brs ME</th><th>Total</th></tr>");
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
                        status1 = ds.Tables[0].Rows[i]["status"].ToString();
                        kategori = ds.Tables[0].Rows[i]["kategori"].ToString();
                        total = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToDecimal(ds.Tables[0].Rows[i]["total"].ToString()));

                        if (kategori == "pemasukan")
                            style = "label-info";
                        else if (kategori == "pengeluaran")
                            style = "label-warning";
                        else if (kategori == "pemindahan")
                            style = "label-success";

                        if (status1 == "incomplete")
                            tanda = "^";
                        else
                            tanda = "";

                        if (i == 0)
                        {
                            hijau = "color:green";
                        }
                        else
                        {
                            hijau = "";
                        }

                        harkat = rek1harkat + rek2harkat;
                        me = rek1me + rek2me;

                        input1 = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToDecimal(ds.Tables[0].Rows[i]["input"].ToString()));

                        rekharkat = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(harkat));
                        rekme = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(me));
                        int index = Convert.ToInt32(IDdata);

                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:11px; color:#a9a9a9; font-color width:70px; {hijau}\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a  style=\"cursor:pointer\" href=\"/admin/detail.aspx?id={IDdata}\">" + $"<label class=\"label label-sm {style}\">" + input1 + "</label>" + tanda + "</a>" + "</td>");
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

        void tablepanjar()
        {
            querypanjar = @"select a.tanggal, a.keterangan, a.status, p.nama, a.input from administrator a left join adminuser u on a.id_admin = u.id_admin join
                    Profile p on p.id_profile = u.id_profile where status is not null and status != 'done' order by a.id_admin desc";

            SqlCommand cmd = new SqlCommand(querypanjar, sqlCon);
            da1 = new SqlDataAdapter(cmd);
            da1.Fill(ds1);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable1.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable1.Append("<thead>");
            htmlTable1.Append("<tr><th>Tanggal</th><th>Keterangan</th><th>Status</th><th>Nama</th><th>input</th>");
            htmlTable1.Append("</thead>");

            htmlTable1.Append("<tbody>");
            if (!object.Equals(ds1.Tables[0], null))
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        tanggal = ds1.Tables[0].Rows[i]["tanggal"].ToString();
                        keterangan = ds1.Tables[0].Rows[i]["keterangan"].ToString();
                        status = ds1.Tables[0].Rows[i]["status"].ToString();
                        nama = ds1.Tables[0].Rows[i]["nama"].ToString();

                        if (status == "incomplete")
                            lblcolor = "label label-danger";
                        if (status == "complete")
                            lblcolor = "label label-success";

                        input = ds1.Tables[0].Rows[i]["input"].ToString();
                        totalpanjar = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N0}", Convert.ToInt32(input));

                        htmlTable1.Append("<tr>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\">" + keterangan + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:12px;\" class=\"{lblcolor}\">" + status + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\">" + nama + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\">" + totalpanjar + "</label>" + "</td>");
                        htmlTable1.Append("</tr>");
                    }
                    htmlTable1.Append("</tbody>");
                    htmlTable1.Append("</table>");
                    PlaceHolderpanjar.Controls.Add(new Literal { Text = htmlTable1.ToString() });

                }
            }
        }

        void dataupdate()
        {
            var datetime = DateTime.Now.ToString("yyyy/MM/dd");
            queryupdate = $@"select tanggal, kategori, input, keterangan FROM administrator where tanggal = '{datetime}' ORDER BY id_admin desc";
            sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(queryupdate, sqlCon);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon.Close();
            datalist1.DataSource = dtbl;
            datalist1.DataBind();

            if(datalist1.Items.Count != 0)
            {
                lblEvent.Visible = false;
            }


        }

    }
}