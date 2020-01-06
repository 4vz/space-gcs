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
using System.IO;

namespace Telkomsat.admin
{
    public partial class penyetoran : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        int nominal1 = 0, nominal2 = 0, nominal3 = 0, nominal4 = 0, nominal5 = 0, nominal6 = 0, nominal7 = 0;
        int noint1, noint2, noint3, noint4, noint5, noint6, noint7;
        string filename = "", filepath = "", filename1 = "", filepath1 = "", filename2 = "", filepath2 = "", filename3 = "", filepath3 = "", filename4 = "", filepath4 = "", filename5 = "", filepath5 = "", filename6 = "", filepath6 = "", filename7 = "", filepath7 = "";
        string nama, status, keterangan, lblcolor, iddata, queryupdate, querydetail, id;
        string querypanjar, tanggal = "", totalpanjar, input = "", now;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            if (id != null)
            {
                divpengembalian.Visible = true;
                querypanjar = $@"SELECT id_admin, keterangan, kategori, input FROM administrator where id_admin = {id} and kategori = 'pengeluaran'";

                SqlCommand cmd = new SqlCommand(querypanjar, sqlCon);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();

                txtpengeluaran.Value = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(ds.Tables[0].Rows[0]["input"].ToString()));
                lblKeterangan.Text = ds.Tables[0].Rows[0]["keterangan"].ToString();

            }
            tablepanjar();
        }
        protected void Save_ServerClick(object sender, EventArgs e)
        {
            now = DateTime.Now.ToString("yyyy/MM/dd");
            //int dataku = tableku.Rows.Count;

            int i = Convert.ToInt32(id);
            string pengeluaran = txtpengeluaran.Value.Replace(".", ""); 

            if (ddlupload.SelectedValue == "Manual")
            {
                if (FileUpload1.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                    {
                        filecount += 1;
                        filename1 = Path.GetFileName(file.FileName);
                        filepath1 = "~/evidence/" + filename1;
                        file.SaveAs(physicalpath + filename1);
                    }
                }
                if (FileUpload3.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload3.PostedFiles)
                    {
                        filecount += 1;
                        filename2 = Path.GetFileName(file.FileName);
                        filepath2 = "~/evidence/" + filename2;
                        file.SaveAs(physicalpath + filename2);
                    }
                }
                if (FileUpload4.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload4.PostedFiles)
                    {
                        filecount += 1;
                        filename3 = Path.GetFileName(file.FileName);
                        filepath3 = "~/evidence/" + filename3;
                        file.SaveAs(physicalpath + filename3);
                    }
                }
                if (FileUpload5.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload5.PostedFiles)
                    {
                        filecount += 1;
                        filename4 = Path.GetFileName(file.FileName);
                        filepath4 = "~/evidence/" + filename4;
                        file.SaveAs(physicalpath + filename4);
                    }
                }
                if (FileUpload6.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload6.PostedFiles)
                    {
                        filecount += 1;
                        filename5 = Path.GetFileName(file.FileName);
                        filepath5 = "~/evidence/" + filename5;
                        file.SaveAs(physicalpath + filename5);
                    }
                }
                if (FileUpload7.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload7.PostedFiles)
                    {
                        filecount += 1;
                        filename6 = Path.GetFileName(file.FileName);
                        filepath6 = "~/evidence/" + filename6;
                        file.SaveAs(physicalpath + filename6);
                    }
                }

                if (txtnominal1.Text != "")
                    nominal1 = Convert.ToInt32(txtnominal1.Text.Replace(".", ""));
                if (txtnominal2.Text != "")
                    nominal2 = Convert.ToInt32(txtnominal2.Text.Replace(".", ""));
                if (txtnominal3.Text != "")
                    nominal3 = Convert.ToInt32(txtnominal3.Text.Replace(".", ""));
                if (txtnominal4.Text != "")
                    nominal4 = Convert.ToInt32(txtnominal4.Text.Replace(".", ""));
                if (txtnominal5.Text != "")
                    nominal5 = Convert.ToInt32(txtnominal5.Text.Replace(".", ""));
                if (txtnominal6.Text != "")
                    nominal6 = Convert.ToInt32(txtnominal6.Text.Replace(".", ""));
                if (txtnominal7.Text != "")
                    nominal7 = Convert.ToInt32(txtnominal7.Text.Replace(".", ""));

                querydetail = $@"INSERT INTO admindetail (d_tanggal, id_admin, d_keterangan, d_nominal, d_file , d_filepath) VALUES
                                ('{now}', {i}, '{txtketerangan1.Text}', {nominal1}, '{filename1}', '{filepath1}'),
                                ('{now}', {i}, '{txtketerangan2.Text}', {nominal2}, '{filename2}', '{filepath2}'),
                                ('{now}', {i}, '{txtketerangan3.Text}', {nominal3}, '{filename3}', '{filepath3}'),
                                ('{now}', {i}, '{txtketerangan4.Text}', {nominal4}, '{filename4}', '{filepath4}'),
                                ('{now}', {i}, '{txtketerangan5.Text}', {nominal5}, '{filename5}', '{filepath5}'),
                                ('{now}', {i}, '{txtketerangan6.Text}', {nominal6}, '{filename6}', '{filepath6}'),
                                ('{now}', {i}, '{txtketerangan7.Text}', {nominal7}, '{filename7}', '{filepath7}')";

                sqlCon.Open();
                SqlCommand cmd3 = new SqlCommand(querydetail, sqlCon);
                cmd3.ExecuteNonQuery();
                sqlCon.Close();

                noint1 = Convert.ToInt32(nominal1);
                noint2 = Convert.ToInt32(nominal2);
                noint3 = Convert.ToInt32(nominal3);
                noint4 = Convert.ToInt32(nominal4);
                noint5 = Convert.ToInt32(nominal5);
                noint6 = Convert.ToInt32(nominal6);
                noint7 = Convert.ToInt32(nominal7);


                int panjar = Convert.ToInt32(pengeluaran);
                int sisa;
                sisa = panjar - (noint1 + noint2 + noint3 + noint4 + noint5 + noint6 + noint7);
                txttotal1.Value = Convert.ToString(sisa);
                queryupdate = $"UPDATE administrator set input = {sisa} where id_admin = {i}";
                sqlCon.Open();
                SqlCommand cmd4 = new SqlCommand(queryupdate, sqlCon);
                cmd4.ExecuteNonQuery();
                sqlCon.Close();
            }
            else
            {
                if (FileUpload2.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/evidence/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                    {
                        filecount += 1;
                        filename = Path.GetFileName(file.FileName);
                        filepath = "~/evidence/" + filename;
                        file.SaveAs(physicalpath + filename);
                    }
                }
                txttotal1.Value = nominal.Value;
                queryupdate = $"UPDATE administrator set input = {nominal.Value}, evidence = {filename}, evidencepath = {filepath} where id_admin = {i}";
                sqlCon.Open();
                SqlCommand cmd4 = new SqlCommand(queryupdate, sqlCon);
                cmd4.ExecuteNonQuery();
                sqlCon.Close();
            }          
        }

        void tablepanjar()
        {
            querypanjar = @"select a.id_admin, a.tanggal, a.keterangan, a.status, p.nama, a.input, a.kategori from administrator a left join adminuser u on a.id_admin = u.id_admin join
                    Profile p on p.id_profile = u.id_profile where status is not null and status != 'done' and kategori = 'pengeluaran' order by a.id_admin desc";

            SqlCommand cmd = new SqlCommand(querypanjar, sqlCon);
            da1 = new SqlDataAdapter(cmd);
            da1.Fill(ds1);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable1.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable1.Append("<thead>");
            htmlTable1.Append("<tr><th>Tanggal</th><th>Keterangan</th><th>Status</th><th>Nama</th><th>Pengeluaran</th><th>Action</th>");
            htmlTable1.Append("</thead>");

            htmlTable1.Append("<tbody>");
            if (!object.Equals(ds1.Tables[0], null))
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        iddata = ds1.Tables[0].Rows[i]["id_admin"].ToString();
                        tanggal = ds1.Tables[0].Rows[i]["tanggal"].ToString();
                        keterangan = ds1.Tables[0].Rows[i]["keterangan"].ToString();
                        status = ds1.Tables[0].Rows[i]["status"].ToString();
                        nama = ds1.Tables[0].Rows[i]["nama"].ToString();

                        string oDate = Convert.ToDateTime(tanggal).ToString("dd/MM/yyyy");
                        if (status == "incomplete")
                            lblcolor = "label label-danger";
                        if (status == "complete")
                            lblcolor = "label label-success";

                        input = ds1.Tables[0].Rows[i]["input"].ToString();
                        totalpanjar = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N0}", Convert.ToInt32(input));

                        htmlTable1.Append("<tr>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + oDate + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\">" + keterangan + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"font-size:12px;\" class=\"{lblcolor}\">" + status + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\">" + nama + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\">" + totalpanjar + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<a class=\"btn btn-info btn-sm\" href=\"../admin/penyetoran.aspx?id={iddata}\" value='ID_Perangkat' id=aku > View</a>" + "</td>");
                        htmlTable1.Append("</tr>");
                    }
                    htmlTable1.Append("</tbody>");
                    htmlTable1.Append("</table>");
                    PlaceHolderpanjar.Controls.Add(new Literal { Text = htmlTable1.ToString() });

                }
            }
        }
    }
}