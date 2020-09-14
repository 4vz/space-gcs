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
using System.Web.Services;
using System.Configuration;
using System.Text.RegularExpressions;

namespace Telkomsat.admin
{
    public partial class pengembalian2 : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string IDdata = "kitaa", total = "", keterangan, tanggal = "", nominal, query3, approve, brame, style, input = "", kategori = "", style5 = "", kategori1 = "", query;
        string start = "01/01/2019", filename, filepath, end = "01/12/2048";


        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void tableticket()
        {
            string simpanan, evidence, status8, sisa;
            int ss = 0, a = 0;

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            //<input name=\"select_all\" value=\"1\" id=\"example-select-all\" type=\"checkbox\" />
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th><input type=\"checkbox\" onclick=\"toggle(this); \" /></th>" +
                "<th>Tanggal</th><th>Kategori</th><th>Keterangan</th><th>Nominal</th><th>Sisa</th><th>Status</th><th>Action</th></tr>");
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
                        simpanan = ds.Tables[0].Rows[i]["simpanan"].ToString();
                        evidence = ds.Tables[0].Rows[i]["evidencepath"].ToString().Replace("~", "..");
                        keterangan = ds.Tables[0].Rows[i]["keterangan"].ToString();
                        nominal = Convert.ToInt32(ds.Tables[0].Rows[i]["input"]).ToString("N0", CultureInfo.GetCultureInfo("de"));

                        string query8 = $"select sum(AT_total) [total] from AdminPertanggungan where AT_AD = '{IDdata}'";
                        DataSet ds8 = Settings.LoadDataSet(query8);

                        if (ds.Tables[0].Rows[i]["input"].ToString() == ds8.Tables[0].Rows[0]["total"].ToString())
                        {
                            status8 = "close";
                        }
                        else
                        {
                            status8 = "waiting";
                        }

                        if(ds8.Tables[0].Rows[0]["total"] == null || ds8.Tables[0].Rows[0]["total"].ToString() == "")
                        {
                            a = 0;
                        }
                        else
                        {
                            a = Convert.ToInt32(ds8.Tables[0].Rows[0]["total"]);
                        }

                        ss = Convert.ToInt32(ds.Tables[0].Rows[i]["input"]) - a;
                        sisa = ss.ToString("N0", CultureInfo.GetCultureInfo("de"));
                        /*if (ds.Tables[0].Rows[i]["gm"].ToString() == "unread")
                            style5 = "font-weight:bold;";
                        else
                            style5 = "font-weight:normal;";*/

                        if (status8 == "close")
                            style = "label label-info";
                        else if (status8 == "waiting")
                            style = "label label-warning";

                        htmlTable.Append($"<tr style=\"{style5}\">");
                        htmlTable.Append("<td>" + $"<input type=\"checkbox\" value=\"{IDdata}\" name=\"getid\"> " + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:10px; {style5} color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + simpanan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + keterangan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + "Rp. " + nominal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px; {style5}\">" + "Rp. " + sisa + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"font-size:12px;\" class=\"{style}\">" + status8 + "</label>" + "</td>");
                        /*if (evidence == "" || evidence == null)
                        {
                            htmlTable.Append("<td>" + $"<label style=\"{style5}\">" + ds.Tables[0].Rows[i]["evidence"].ToString() + "</label>" + "</td>");
                        }
                        else
                        {
                            if (evidence.Substring(evidence.LastIndexOf('.') + 1).ToLower().IsIn(new string[] { "jpg", "jpeg", "png", "bmp", "jfif", "gif" }))
                            {
                                htmlTable.Append("<td>" + $"<label style=\"{style5}\">" + $"<img style=\"display:block\" class=\"myImg\" src=\"{evidence}\" height=\"200\" />" + "</label>" + "</td>");
                            }
                            else
                            {
                                htmlTable.Append("<td>" + $"<label style=\"{style5}\">" + ds.Tables[0].Rows[i]["evidence"].ToString() + "</label>" + "</td>");
                            }
                        }*/

                        htmlTable.Append("<td>" + $"<a href=\"detail.aspx?id={IDdata}&tipe=3Xc5T79kLm1Oo\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</a>");
                        if (evidence == "" || evidence == null)
                            htmlTable.Append($"<button type=\"button\" value=\"{IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-warning datatotal\" data-toggle=\"modal\" data-target=\"#modalupdate\" id=\"edit\">" + "<span class=\"fa fa-paperclip\"></span>" + "</button>");
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
            query = $"select * from administrator where kategori = 'pengeluaran' and approve='admin' and id_profile='{txtpetugas.Text}' order by id_admin desc";
            btnid.Visible = true;
            tableticket();
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string[] lines = Regex.Split(txtid.Text, ",");
            string[] myarray;
            int ss = 0, a = 0;

            string myquery;
            myarray = new string[lines.Length];
            //Response.Write("panjang " + lines.Length + " isi " + lines[0]);
            foreach (string line in lines)
            {
                string query8 = $"select sum(AT_total) [total] from AdminPertanggungan where AT_AD = '{line}'";
                DataSet ds8 = Settings.LoadDataSet(query8);

                string query9 = $"select * from administrator where id_admin = '{line}'";
                DataSet ds9 = Settings.LoadDataSet(query9);

                if (ds8.Tables[0].Rows[0]["total"] == null || ds8.Tables[0].Rows[0]["total"].ToString() == "")
                {
                    a = 0;
                }
                else
                {
                    a = Convert.ToInt32(ds8.Tables[0].Rows[0]["total"]);
                }

                ss = Convert.ToInt32(ds9.Tables[0].Rows[0]["input"]) - a;

                HttpFileCollection filecolln = Request.Files;
                for (int j = 0; j < filecolln.Count; j++)
                {
                    HttpPostedFile file = filecolln[j];
                    if (file.ContentLength > 0)
                    {
                        string filename = Path.GetFileName(file.FileName);
                        string filepath = "~/evidence/" + filename;
                        string extension = Path.GetExtension(file.FileName);
                        file.SaveAs(Server.MapPath("~/evidence/") + Path.GetFileName(file.FileName));
                        sqlCon.Open();
                        string queryfile = $@"INSERT INTO AdminPertanggungan (AT_AD, AT_Keterangan, AT_Tanggal, AT_pcs, AT_harga, AT_EvidenceName, AT_EvidencePath, AT_Status)
                                        VALUES ('{line}', '{txtket.Text}', '{txttanggal.Value}', '1', '{ss}', '{filename}', '{filepath}', 'submit')";
                        //Response.Write(queryfile); ;
                        SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                        sqlCmd1.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }
        }

        [WebMethod]
        public static string GetData(string videoid)
        {
            int a = 0, b = 0, c = 0, total = 0;
            string iddata, sttotal = "";
            string query = $"select * from administrator where kategori = 'pengeluaran' and approve='admin' and id_admin in({videoid}) order by id_admin desc ";
            DataSet das = Settings.LoadDataSet(query);

            if (das.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < das.Tables[0].Rows.Count; i++)
                {
                    iddata = das.Tables[0].Rows[i]["id_admin"].ToString();
                    string query8 = $"select sum(AT_total) [total] from AdminPertanggungan where AT_AD = '{iddata}'";
                    DataSet ds8 = Settings.LoadDataSet(query8);

                    if (ds8.Tables[0].Rows[0]["total"] == null || ds8.Tables[0].Rows[0]["total"].ToString() == "")
                    {
                        a = 0;
                    }
                    else
                    {
                        a = Convert.ToInt32(ds8.Tables[0].Rows[0]["total"]);
                    }
                    b = Convert.ToInt32(das.Tables[0].Rows[i]["input"]);
                    c = b - a;

                    total = total + c;
                }

                sttotal = total.ToString("N0", CultureInfo.GetCultureInfo("de"));
            }
            return sttotal;
        }

    }
}