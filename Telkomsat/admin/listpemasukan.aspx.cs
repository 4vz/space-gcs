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
    public partial class listpemasukan : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string kategori, style3, filename, filepath, queryfile;
        protected void Page_Load(object sender, EventArgs e)
        {
            string query, user;

            user = Session["iduser"].ToString();
            query = $"Select * from AdminProfile where AP_Nama = '{user}'";
            DataSet ds2 = Settings.LoadDataSet(query);

            if (ds2.Tables[0].Rows.Count > 0)
            {
                if (ds2.Tables[0].Rows[0]["AP_Previllage"].ToString() == "Admin Bendahara")
                    btntmbh.Visible = true;
            }
            referens();
        }

        protected void Edit_File(object sender, EventArgs e)
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
                    filename = Path.GetFileName(file.FileName);
                    filepath = "~/evidence/" + filename;
                    file.SaveAs(physicalpath + filename);
                }
                //lblstatus.Text = filecount + " files upload";
            }

            queryfile = $@"UPDATE administrator set evidence='{filename}', evidencepath='{filepath}' where id_admin = '{txtidl.Text}'";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(queryfile, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect("listpemasukan.aspx");
        }

        void referens()
        {
            string query, IDdata, referensi, gt, tanggal, evidence, simpanan;
            query = $"select * from administrator where kategori = 'pemasukan' order by tanggal desc, id_admin desc";
            style3 = "font-weight:normal";
            DataSet ds = Settings.LoadDataSet(query);

            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>Kategori</th><th>Keterangan</th><th>Jumlah</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_admin"].ToString();
                        referensi = ds.Tables[0].Rows[i]["keterangan"].ToString();
                        simpanan = ds.Tables[0].Rows[i]["simpanan"].ToString();
                        evidence = ds.Tables[0].Rows[i]["evidencepath"].ToString().Replace("~", "..");
                        gt = Convert.ToInt32(ds.Tables[0].Rows[i]["input"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                        DateTime tgl = Convert.ToDateTime(ds.Tables[0].Rows[i]["tanggal"]);
                        tanggal = tgl.ToString("dd-MM-yyyy");

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + simpanan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + referensi + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + "Rp. " + gt + "</label>" + "</td>");
                        /*if (evidence == "" || evidence == null)
                        {
                            htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["evidence"].ToString() + "</label>" + "</td>");
                        }
                        else
                        {
                            if (evidence.Substring(evidence.LastIndexOf('.') + 1).ToLower().IsIn(new string[] { "jpg", "jpeg", "png", "bmp", "jfif", "gif" }))
                            {
                                htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + $"<button style=\"display:block\" class=\"myImg asText\" value=\"{evidence}\" height=\"200\" ></button>" + "</label>" + "</td>");
                            }
                            else
                            {
                                htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ds.Tables[0].Rows[i]["evidence"].ToString() + "</label>" + "</td>");
                            }
                        }*/

                        htmlTable.Append("<td>" + $"<a href=\"detail.aspx?id={IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-default datawil\" >" + "Detail" + "</a>");
/*                        if (evidence == "" || evidence == null)
                            htmlTable.Append($"<button type=\"button\" value=\"{IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-warning datatotal\" data-toggle=\"modal\" data-target=\"#modalupdate\" id=\"edit\">" + "<span class=\"fa fa-paperclip\"></span>" + "</button>");
*/                      htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}