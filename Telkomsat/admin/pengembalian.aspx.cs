﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace Telkomsat.admin
{
    public partial class pengembalian : System.Web.UI.Page
    {

        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string nama, status, keterangan, lblcolor, iddata, querymodal;
        string querypanjar, tanggal = "", totalpanjar, input = "", nilai;
        int a, b, c;
        string[] myket, mynominal, mylast;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Form.Enctype = "multipart/form-data";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if(id != null)
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
            int dataku = tableku.Rows.Count;
            string mydata;
            //Response.Write("bibi  " + Request.Form["mypanjar"] + "data : " + Request.Form["mydatapanjar"] + "File : " + fileinput.Value);
            //HttpPostedFile postedFile = Request.Files["fileinput"];
            //Response.Write("file " + postedFile.FileName);
            string keterangan = Request.Form["mypanjar"];
            string nominal = Request.Form["mydatapanjar"];
            mylast = new string[Request.Files.Count];
            myket = new string[Request.Files.Count];
            mynominal = new string[Request.Files.Count];
            a = b = c = 0;
            if (nominal != null)
            {
                string[] lines = Regex.Split(nominal, ",");

                foreach (string line in lines)
                {
                    myket[a] = line;
                    a++;
                }
            }

            if (keterangan != null)
            {
                string[] lines = Regex.Split(keterangan, ",");

                foreach (string line in lines)
                {
                    mynominal[b] = line;
                    b++;
                }
            }
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFile file = Request.Files[i];

                if (file != null && file.ContentLength > 0)
                {
                    string filePath = Server.MapPath("~/evidence/") + Path.GetFileName(file.FileName);
                    //file.SaveAs(filePath);
                    mylast[i] = "('" + myket[i] + "', '" + mynominal[i] + "', '" + Path.GetFileName(file.FileName) + "')";
                }
                else
                {
                    mylast[i] = "('" + myket[i] + "', '" + mynominal[i] + "', '" + "')";
                }
                
            }
            mydata = string.Join(",", mylast);
            Response.Write(mydata);
            /*if (postedFile != null && postedFile.ContentLength > 0)
            {
                //Save the File.
                Response.Write("file " + postedFile.FileName);
            }
            else
            {
                Response.Write("kosong");
            }*/
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
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\" name=\"record1\">" + totalpanjar + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<a class=\"btn btn-info btn-sm\" href=\"../admin/pengembalian.aspx?id={iddata}\" value='ID_Perangkat' id=aku > View</a>" + "</td>");
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