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
        StringBuilder htmlTablejus = new StringBuilder();
        string nama, status, keterangan, lblcolor, queryupdate, querymodal, style, status1, tanda = "", hijau, warna1, warna2, warna3, warna4;
        string IDdata = "kitaa", total = "", querypanjar, tanggal = "", rekharkat, rekme, braharkat, brame, totalpanjar, input ="", kategori ="", input1 = "", kategori1 = "", query;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        int rek1harkat, rek2harkat, rek1me, rek2me, harkat, me, brankasharkat, brankasme;
        protected void Page_Load(object sender, EventArgs e)
        {
            tableticket();

            tablepanjar();

            //dataupdate();

            modal();

            justifikasi();

            query = @"select id_admin, bra_harkat, bra_me, rek_harkat1, rek_harkat2, rek_me1, rek_me2, total
                                from administrator where id_admin = (select max(id_admin) from administrator)";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            if(ds.Tables[0].Rows.Count > 0)
            {
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

                mylabel.Value = Convert.ToInt32(rek1harkat).ToString("N0", CultureInfo.GetCultureInfo("de")) + "," +
                    Convert.ToInt32(rek2harkat).ToString("N0", CultureInfo.GetCultureInfo("de")) + "," +
                    Convert.ToInt32(rek1me).ToString("N0", CultureInfo.GetCultureInfo("de")) + "," + 
                    Convert.ToInt32(rek2me).ToString("N0", CultureInfo.GetCultureInfo("de")) + "," + 
                    Convert.ToInt32(brankasharkat).ToString("N0", CultureInfo.GetCultureInfo("de")) + "," +
                    Convert.ToInt32(brankasme).ToString("N0", CultureInfo.GetCultureInfo("de")) + ",";

            }

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

            if(dsmodal.Tables[0].Rows.Count > 0)
            {
                lblrekharkat1.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["rek_harkat1"].ToString()));
                lblrekharkat2.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["rek_harkat2"].ToString()));
                lblbraharkat.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["bra_harkat"].ToString()));
                lblrekme1.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["rek_me1"].ToString()));
                lblrekme2.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["rek_me2"].ToString()));
                lblbrame.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(dsmodal.Tables[0].Rows[0]["bra_me"].ToString()));

            }
        }

        void tableticket()
        {
            query = @"select top 6 id_admin, status, bra_harkat, bra_me, rek_harkat1, rek_harkat2, rek_me1, rek_me2, kategori, input, tanggal, total
                                from administrator where approve = 'admin' order by id_admin desc";

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
            querypanjar = @"select top 6 e.nama, r.* from administrator r join AdminProfile p on p.AP_ID=r.id_profile
                            join Profile e on e.id_profile=p.AP_Nama 
                             where kategori = 'pengeluaran' and approve='admin' order by tanggal asc";

            string simpanan, evidence, status8, style5 = "", nominal, nama, tgl, id, ket, keter;

            SqlCommand cmd = new SqlCommand(querypanjar, sqlCon);
            da1 = new SqlDataAdapter(cmd);
            da1.Fill(ds1);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable1.Append("<table id=\"exampl\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable1.Append("<thead>");
            htmlTable1.Append("<tr><th>Tanggal</th><th>Kategori</th><th>Keterangan</th><th>Nominal</th><th>Status</th><th>Action</th></tr>");
            htmlTable1.Append("</thead>");

            htmlTable1.Append("<tbody>");
            if (!object.Equals(ds1.Tables[0], null))
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        id = ds1.Tables[0].Rows[i]["id_admin"].ToString();
                        DateTime datee = (DateTime)ds1.Tables[0].Rows[i]["tanggal"];
                        tgl = datee.ToString("dd MMM yyyy");
                        nama = ds1.Tables[0].Rows[i]["nama"].ToString();
                        evidence = ds1.Tables[0].Rows[i]["evidencepath"].ToString().Replace("~", "..");
                        ket = ds1.Tables[0].Rows[i]["keterangan"].ToString();
                        nominal = Convert.ToInt32(ds1.Tables[0].Rows[i]["input"]).ToString("N0", CultureInfo.GetCultureInfo("de"));

                        string query8 = $"select sum(AT_total) [total] from AdminPertanggungan where AT_AD = '{IDdata}'";
                        DataSet ds18 = Settings.LoadDataSet(query8);

                        if (ds1.Tables[0].Rows[i]["input"].ToString() == ds18.Tables[0].Rows[0]["total"].ToString())
                        {
                            status8 = "close";
                        }
                        else
                        {
                            status8 = "waiting";
                        }
                        /*if (ds1.Tables[0].Rows[i]["gm"].ToString() == "unread")
                            style5 = "font-weight:bold;";
                        else
                            style5 = "font-weight:normal;";*/

                        if (ket.Length >= 40)
                        {
                            keter = ket.Substring(0, 20) + "...";
                        }
                        else
                        {
                            keter = ket;
                        }

                        if (status8 == "close")
                            style = "label label-info";
                        else if (status8 == "waiting")
                            style = "label label-warning";

                        htmlTable1.Append($"<tr style=\"{style5}\">");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:11px; {style5} color:#a9a9a9; font-color width:70px;\">" + tgl + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + nama + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + keter + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + "Rp. " + nominal + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:12px;\" class=\"{style}\">" + status8 + "</label>" + "</td>");
                        /*if (evidence == "" || evidence == null)
                        {
                            htmlTable1.Append("<td>" + $"<label style=\"{style5}\">" + ds1.Tables[0].Rows[i]["evidence"].ToString() + "</label>" + "</td>");
                        }
                        else
                        {
                            if (evidence.Substring(evidence.LastIndexOf('.') + 1).ToLower().IsIn(new string[] { "jpg", "jpeg", "png", "bmp", "jfif", "gif" }))
                            {
                                htmlTable1.Append("<td>" + $"<label style=\"{style5}\">" + $"<img style=\"display:block\" class=\"myImg\" src=\"{evidence}\" height=\"200\" />" + "</label>" + "</td>");
                            }
                            else
                            {
                                htmlTable1.Append("<td>" + $"<label style=\"{style5}\">" + ds1.Tables[0].Rows[i]["evidence"].ToString() + "</label>" + "</td>");
                            }
                        }*/

                        htmlTable1.Append("<td>" + $"<a href=\"detail.aspx?id={IDdata}&tipe=3Xc5T79kLm1Oo\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</a>");
                        htmlTable1.Append("</tr>");
                    }
                    htmlTable1.Append("</tbody>");
                    htmlTable1.Append("</table>");
                    PlaceHolderpanjar.Controls.Add(new Literal { Text = htmlTable1.ToString() });

                }
            }
        }

        void justifikasi()
        {
            string IDdata, jupd, ja, kegiatan, status, statusapp, style3 = "", query;
            query = $"SELECT top 6 * from AdminJustifikasi where AJ_Status is not null order by AJ_ID desc";
            style3 = "font-weight:normal";
            DataSet ds = Settings.LoadDataSet(query);

            htmlTablejus.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTablejus.Append("<thead>");
            htmlTablejus.Append("<tr><th>#</th><th>Nomor Justifikasi</th><th>Jenis Anggaran</th><th>Nama Kegiatan</th><th>Status Justifikasi</th><th>Action</th></tr>");
            htmlTablejus.Append("</thead>");

            htmlTablejus.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["AJ_ID"].ToString();
                        jupd = ds.Tables[0].Rows[i]["AJ_NJ"].ToString();
                        ja = ds.Tables[0].Rows[i]["AJ_JA"].ToString();
                        kegiatan = ds.Tables[0].Rows[i]["AJ_NK"].ToString();
                        status = ds.Tables[0].Rows[i]["AJ_Status"].ToString();

                        if (status == "diajukan")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "black";
                            warna3 = "black";
                            warna4 = "black";
                            statusapp = "menunggu approve GM";
                        }

                        else if (status == "gm")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "deepskyblue";
                            warna3 = "black";
                            statusapp = "menunggu approve Bendahara";
                        }
                        else if (status == "ok")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "lightskyblue";
                            warna3 = "black";
                            statusapp = "menunggu approve Bendahara";
                        }
                        else if (status == "admin")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "deepskyblue";
                            warna3 = "deepskyblue";
                            statusapp = "selesai";
                        }
                        else if (status == "reject")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "red";
                            warna3 = "black";
                            statusapp = "ditolak";
                        }
                        else if (status.ToLower() == "revision")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "yellow";
                            warna3 = "black";
                            statusapp = "menunggu diperbaiki";
                        }
                        else if (status.ToLower() == "dikembalikan")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "sandybrown";
                            warna3 = "black";
                            statusapp = "dikembalikan ke GM";
                        }
                        else if (status.ToLower() == "pending")
                        {
                            warna1 = "deepskyblue";
                            warna2 = "darkcyan";
                            warna3 = "black";
                            statusapp = "ditunda";
                        }
                        else
                        {
                            warna1 = "black";
                            warna2 = "black";
                            warna3 = "black";
                            warna4 = "black";
                            statusapp = "menunggu diajukan";
                        }

                        htmlTablejus.Append("<tr>");
                        htmlTablejus.Append("<td>" + (i + 1) + "</td>");
                        htmlTablejus.Append("<td>" + $"<label style=\"{style3}\">" + jupd + "</label>" + "</td>");
                        htmlTablejus.Append("<td>" + $"<label style=\"{style3}\">" + ja + "</label>" + "</td>");
                        htmlTablejus.Append("<td>" + $"<label style=\"{style3}\">" + kegiatan + "</label>" + "</td>");
                        htmlTablejus.Append("<td>" +
                            $"<span style=\"margin-right:5px; color:{warna1}\"><i class=\"fa fa-circle\"></i></span>" + $"<span style=\"margin-right:5px; color:{warna2}\"><i class=\"fa fa-circle\"></i></span>" +
                            $"<span style=\"margin-right:5px; color:{warna3}\"><i class=\"fa fa-circle\"></i></span>" +
                            $"<label style=\"font-size:13px; {style3}; display:block\">" + statusapp + "</label>" + "</td>");
                        /*htmlTablejus.Append("<td>" + $"<button type=\"button\" id=\"btnadmin\" style=\"margin-right:10px\" value=\"{IDdata}\" class=\"btn btn-sm btn-primary datariwayat\" data-toggle=\"modal\" data-target=\"#modalriwayat\">" + 
                            "<span><i class=\"fa fa-book\"></i></span>" + "</button>" + "</td>");*/
                        htmlTablejus.Append("<td>" + $"<a href=\"detailjustifikasi.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</button>" + "</td>");
                        htmlTablejus.Append("</tr>");
                    }
                    htmlTablejus.Append("</tbody>");
                    htmlTablejus.Append("</table>");
                    PlaceHolderJust.Controls.Add(new Literal { Text = htmlTablejus.ToString() });
                }
            }
        }


        /*void dataupdate()
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
        }*/

    }
}