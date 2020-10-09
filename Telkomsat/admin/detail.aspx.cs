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
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Configuration;

namespace Telkomsat.admin
{
    public partial class detail : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable3 = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        StringBuilder htmlTable2 = new StringBuilder();
        string evidence, idjustifikasi, userid;
        string[] myfile, intanggal, inketerangan, inpcs, inharga, inevidence;

        string querypanjar, tanggal = "", totalpanjar, input = "", vendor, kategori, keterangan, fileu, nominal, id;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Init(object sender, EventArgs e)
        {
            this.Form.Enctype = "multipart/form-data";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string query2, user;
            user = Session["iduser"].ToString();
            id = Request.QueryString["id"];
            if (id != null)
            {
                querypanjar = $@"SELECT v.AV_Perusahaan, r.* FROM administrator r full join AdminVendor v on v.AV_ID=r.id_av where id_admin = {id}";

                SqlCommand cmd = new SqlCommand(querypanjar, sqlCon);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();

                vendor = ds.Tables[0].Rows[0]["AV_Perusahaan"].ToString();
                input = ds.Tables[0].Rows[0]["input"].ToString();
                kategori = ds.Tables[0].Rows[0]["kategori"].ToString();

                lbldetail.Text = ds.Tables[0].Rows[0]["keterangan"].ToString();

                lblNominal.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(ds.Tables[0].Rows[0]["input"].ToString()));
                if (kategori == "pengeluaran")
                {
                    lblKategori.Text = "Pengeluaran";
                }
                else if (kategori == "pemasukan")
                {
                    lblKategori.Text = "Pemasukan";
                }
                else
                {
                    lblKategori.Text = "Pemindahan";
                }

                if (ds.Tables[0].Rows[0]["id_av"].ToString() == "0")
                {
                    lblvendor.Text = "-";
                }
                else
                {
                    lblvendor.Text = vendor;
                }

                idjustifikasi = ds.Tables[0].Rows[0]["id_aj"].ToString();


                lblKeterangan.Text = ds.Tables[0].Rows[0]["keterangan"].ToString();
                evidence = ds.Tables[0].Rows[0]["evidence"].ToString();
                //myimg.Src = ds.Tables[0].Rows[0]["evidencepath"].ToString();

                query2 = $"Select * from AdminProfile where AP_Nama = '{user}'";
                DataSet ds2 = Settings.LoadDataSet(query2);

                if (Request.QueryString["tipe"] != null)
                {
                    if (Request.QueryString["tipe"].ToString() == "3Xc5T79kLm1Oo")
                    {
                        if (ds2.Tables[0].Rows[0]["AP_Previllage"].ToString() == "User")
                        {
                            divpertanggungan.Visible = true;
                            btnsubmit2.Visible = true;
                        }

                    }
                    else if (Request.QueryString["tipe"].ToString() == "4Jo9879eTr1Rr")
                    {
                        if (ds2.Tables[0].Rows[0]["AP_Previllage"].ToString() == "Admin Bendahara")
                        {
                            btnreject.Visible = true;
                            btnid.Visible = true;
                        }

                    }
                    userid = ds2.Tables[0].Rows[0]["AP_Previllage"].ToString();

                }

                justifikasi();
                mytable();
                listdata();
                tblpertanggungan();
            }



            //tablepanjar();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename="
                + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/evidence/")
                + e.CommandArgument);
            Response.End();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            string thequery = $"Update AdminPertanggungan Set AT_Status = 'submit' where AT_AD = '{id}' and AT_Status = 'draft'";
            SqlCommand sq = Settings.ExNonQuery(thequery);
            Response.Redirect($"detail.aspx?id={id}&tipe=3Xc5T79kLm1Oo");

        }

        protected void Setujui_Click(object sender, EventArgs e)
        {
            string thequery = $"Update AdminPertanggungan Set AT_Status = 'close' where AT_AD = '{id}' and AT_Status = 'submit'";
            SqlCommand sq = Settings.ExNonQuery(thequery);
            Response.Redirect($"detail.aspx?id={id}&tipe=4Jo9879eTr1Rr");

        }

        protected void Pertanggungan_Click(object sender, EventArgs e)
        {
            inevidence = new string[Request.Files.Count - 1];
            inharga = new string[Request.Files.Count - 1];
            inketerangan = new string[Request.Files.Count - 1];
            inpcs = new string[Request.Files.Count - 1];
            intanggal = new string[Request.Files.Count - 1];
            int a = 0, b = 0, c = 0, d = 0;

            string fotanggal = Request.Form["intanggal"];
            string foketerangan = Request.Form["inketerangan"];
            string fopcs = Request.Form["inpcs"];
            string foharga = Request.Form["inharga"];

            if (fotanggal != null)
            {
                string[] lines = Regex.Split(fotanggal, ",");

                foreach (string line in lines)
                {
                    intanggal[a] = line;
                    a++;
                }
            }

            if (foketerangan != null)
            {
                string[] lines = Regex.Split(foketerangan, ",");
                foreach (string line in lines)
                {
                    inketerangan[b] = line;
                    b++;
                }
            }

            if (fopcs != null)
            {
                string[] lines = Regex.Split(fopcs, ",");
                foreach (string line in lines)
                {
                    inpcs[c] = line;
                    c++;
                }
            }


            if (foharga != null)
            {
                string[] lines = Regex.Split(foharga, ",");
                foreach (string line in lines)
                {
                    inharga[d] = line;
                    d++;
                }
            }


            HttpFileCollection filecolln = Request.Files;
            for (int j = 0; j < filecolln.Count - 1; j++)
            {
                HttpPostedFile file = filecolln[j + 1];
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = "~/evidence/" + filename;
                    string extension = Path.GetExtension(file.FileName);
                    file.SaveAs(Server.MapPath("~/evidence/") + Path.GetFileName(file.FileName));
                    sqlCon.Open();
                    string queryfile = $@"INSERT INTO AdminPertanggungan (AT_AD, AT_Keterangan, AT_Tanggal, AT_pcs, AT_harga, AT_EvidenceName, AT_EvidencePath, AT_Status)
                                        VALUES ('{id}', '{inketerangan[j]}', '{intanggal[j]}', '{inpcs[j]}', '{inharga[j].Replace(".", "")}', '{filename}', '{filepath}', 'draft')";
                    Response.Write(queryfile);
                    SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                    sqlCmd1.ExecuteNonQuery();
                    sqlCon.Close();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "CallMyFunction", "alert('Hello World');", true);
                }
            }

            Response.Redirect($"detail.aspx?id={id}&tipe=3Xc5T79kLm1Oo");

        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            if (FileUploadedit.HasFiles)
            {
                HttpPostedFile file = FileUploadedit.PostedFile;
                string filename = Path.GetFileName(file.FileName);
                string filepath = "~/evidence/" + filename;
                string extension = Path.GetExtension(file.FileName);
                file.SaveAs(Server.MapPath("~/evidence/") + Path.GetFileName(file.FileName));
                sqlCon.Open();
                string queryfile = $@"Update AdminPertanggungan set AT_Keterangan='{txteditket.Text}', AT_Tanggal='{txtedittgl.Text}', AT_pcs='{txteditji.Text}',
                                        AT_harga='{txtediths.Text}', AT_EvidenceName='{filename}', AT_EvidencePath='{filepath}' where AT_ID='{txtid.Text}'";
                Response.Write(queryfile);
                SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon);

                sqlCmd1.ExecuteNonQuery();
                sqlCon.Close();
            }
            else
            {
                string myquery = $@"Update AdminPertanggungan set AT_Keterangan='{txteditket.Text}', AT_Tanggal='{txtedittgl.Text}', AT_pcs='{txteditji.Text}',
                                        AT_harga='{txtediths.Text}' where AT_ID='{txtid.Text}'";
                sqlCon.Open();
                SqlCommand sqlCmd1 = new SqlCommand(myquery, sqlCon);

                sqlCmd1.ExecuteNonQuery();
                sqlCon.Close();
            }

            Response.Redirect(Request.RawUrl);
        }

        void listdata()
        {
            string queryfile = $"select * from AdminEvidence WHERE  AE_ID = '{id}' and (AE_Ekstension not in ('.jpeg', '.png', '.bmp', '.jfif', '.gif', '.jpg', '.PNG'))";
            DataList3a.Visible = true;
            sqlCon.Open();
            SqlDataAdapter sqlda1 = new SqlDataAdapter(queryfile, sqlCon);
            DataTable dtbl1 = new DataTable();
            sqlda1.Fill(dtbl1);
            sqlCon.Close();
            DataList3a.DataSource = dtbl1;
            DataList3a.DataBind();
        }
        protected void lbupload_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/admin/download.aspx?file={evidence}");
        }

        void lampiran()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            string querycountf = $"select count(*) from table_log_file WHERE id_logbook = '' and kategori = 'utama'";
            SqlCommand cmd4 = new SqlCommand(querycountf, sqlCon);
            int output1 = int.Parse(cmd4.ExecuteScalar().ToString());
            sqlCon.Close();


        }

        void justifikasi()
        {
            string query1;
            query1 = $@"SELECT j.*, r1.AR_Reference [jabatan], r2.AR_Reference [subdit], e.nama, k.ARK_Aktivitas, k.ARK_NoA, v.AV_Perusahaan, AP_Nama
                                FROM AdminJustifikasi j full join AdminProfile p on j.AJ_PT=p.AP_ID full join AdminReference r1
                                on r1.AR_ID = p.AP_Jabatan full join AdminReference r2 on r2.AR_ID = p.AP_Subdit full join AdminRKAP k
                                on k.ARK_ID = j.AJ_AR full join AdminVendor v on v.AV_ID=j.AJ_AV full join Profile e on e.id_profile=p.AP_Nama WHERE AJ_ID = '{idjustifikasi}'";
            DataSet ds = Settings.LoadDataSet(query1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (!IsPostBack)
                {
                    lbldetailjus.Text = ds.Tables[0].Rows[0]["AJ_Detail"].ToString();
                    lblja.Text = ds.Tables[0].Rows[0]["AJ_JA"].ToString();
                    lbljupd.Text = ds.Tables[0].Rows[0]["AJ_JUPD"].ToString();
                    lblket.Text = ds.Tables[0].Rows[0]["AJ_Ket"].ToString();
                    lblnilai.Text = Convert.ToInt32(ds.Tables[0].Rows[0]["AJ_Nilai"]).ToString("N0", CultureInfo.GetCultureInfo("de"));
                    lblnk.Text = ds.Tables[0].Rows[0]["AJ_NK"].ToString();
                    lblnrkap.Text = ds.Tables[0].Rows[0]["AJ_AR"].ToString();
                    lblnojus.Text = ds.Tables[0].Rows[0]["AJ_NJ"].ToString();
                    lblpk.Text = ds.Tables[0].Rows[0]["ARK_Aktivitas"].ToString();

                    lbltglpt.Text = ds.Tables[0].Rows[0]["nama"].ToString();
                    lbljabatan.Text = ds.Tables[0].Rows[0]["jabatan"].ToString();
                    lblsubdit.Text = ds.Tables[0].Rows[0]["subdit"].ToString();
                    lblnaa.Text = ds.Tables[0].Rows[0]["ARK_NoA"].ToString();
                    DateTime tgl = (DateTime)ds.Tables[0].Rows[0]["AJ_Tgl"];
                    DateTime tglds = (DateTime)ds.Tables[0].Rows[0]["AJ_TglDS"];

                    lbltglds.Text = tglds.ToString("dd MMM yyyy");
                    lbltgl.Text = tgl.ToString("dd MMM yyyy");
                }

            }
            else
            {
                tbljustifikasi.Visible = false;
            }
        }

        void mytable()
        {
            SqlDataAdapter da, da1;
            DataSet ds = new DataSet();
            DataSet ds1 = new DataSet();
            string myquery, query, color, namaall, ext, namafile;

            myquery = $@"select * from AdminEvidence WHERE  AE_AD = '{id}' and (AE_Ekstension in ('.jpeg', '.png', '.bmp', '.jfif', '.gif', '.jpg', '.PNG'))";

            SqlCommand cmd = new SqlCommand(myquery, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable2.AppendLine("<ul>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        namaall = ds.Tables[0].Rows[i]["AE_File"].ToString();
                        namafile = namaall.Replace("~", "..");
                        ext = Path.GetExtension(namaall);
                        htmlTable2.Append($"<li class=\"gambar\"><img style=\"display:block\" class=\"myImg\" src=\"{namafile}\" height=\"200\" /><br />" +
                            $"<label style=\"text-align:center; width:100%; white-space:pre-line; font-size:11px\" >{ds.Tables[0].Rows[i]["AE_Caption"].ToString()}</label></li>");
                    }
                    htmlTable2.AppendLine("</ul>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable2.ToString() });
                }
            }
        }


        void tablepanjar()
        {
            querypanjar = $"select * from admindetail where id_admin = {id} and d_keterangan != ''";

            SqlCommand cmd = new SqlCommand(querypanjar, sqlCon);
            da1 = new SqlDataAdapter(cmd);
            da1.Fill(ds1);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            htmlTable1.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable1.Append("<thead>");
            htmlTable1.Append("<tr><th>Keterangan</th><th>Nominal</th><th>Evidence</th>");
            htmlTable1.Append("</thead>");

            htmlTable1.Append("<tbody>");
            if (!object.Equals(ds1.Tables[0], null))
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        keterangan = ds1.Tables[0].Rows[i]["d_keterangan"].ToString();
                        fileu = ds1.Tables[0].Rows[i]["d_file"].ToString();
                        nominal = ds1.Tables[0].Rows[i]["d_nominal"].ToString();

                        totalpanjar = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N0}", Convert.ToInt32(nominal));

                        htmlTable1.Append("<tr>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\">" + keterangan + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:12px;\">" + totalpanjar + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<a style=\"font-size:12px;\" href=\"../admin/download.aspx?file={fileu}\">" + fileu + "</a>" + "</td>");
                        htmlTable1.Append("</tr>");
                    }
                    htmlTable1.Append("</tbody>");
                    htmlTable1.Append("</table>");
                    PlaceHolderDetail.Controls.Add(new Literal { Text = htmlTable1.ToString() });

                }
            }
        }

        protected void Pertanggungan2_Click(object sender, EventArgs e)
        {
            Response.Write("ok " + txtidpertanggungan.Text);
            string myquery = $"UPDATE AdminPertanggungan set AT_Status='accepted' where AT_ID in({txtidpertanggungan.Text})";
            sqlCon.Open();
            SqlCommand sqlCmd1 = new SqlCommand(myquery, sqlCon);
            sqlCmd1.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect($"detail.aspx?id={id}&tipe=4Jo9879eTr1Rr");
        }

        protected void Pertanggunganreject_Click(object sender, EventArgs e)
        {
            //Response.Write("ok " + txtidpertanggungan.Text);
            string myquery = $"UPDATE AdminPertanggungan set AT_Status='reject', AT_Message='{txtalasanup.Text}' where AT_ID in({txtidpertanggungan.Text})";
            sqlCon.Open();
            SqlCommand sqlCmd1 = new SqlCommand(myquery, sqlCon);
            sqlCmd1.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect($"detail.aspx?id={id}&tipe=4Jo9879eTr1Rr");
        }


        void tblpertanggungan()
        {
            string dptotal, dpharga, filepath, IDdata = "", query2 = "", status = "";

            if (userid == "User")
                query2 = $"select * from AdminPertanggungan where AT_AD = {id}";
            else if (userid == "Admin Bendahara")
                query2 = $"select * from AdminPertanggungan where AT_AD = {id} and AT_Status != 'draft'";
            else
                query2 = $"select * from AdminPertanggungan where AT_AD = {id}";

            DataSet ds2 = Settings.LoadDataSet(query2);

            htmlTable3.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable3.Append("<thead>");
            htmlTable3.Append("<tr>");
            htmlTable3.Append("<th><input type=\"checkbox\" onclick=\"toggle(this); \" /></th>");
            htmlTable3.Append("<th>Tanggal</th><th>Keterangan</th><th>Jumlah Item</th><th>Harga</th><th>Total</th><th>Status</th><th>Evidence</th>");
            if(userid == "User")
                htmlTable3.Append("<th>Action</th>");
            htmlTable3.Append("</tr>");
            htmlTable3.Append("</thead>");

            htmlTable3.Append("<tbody>");
            if (!object.Equals(ds2.Tables[0], null))
            {
                if (ds2.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds2.Tables[0].Rows[i]["AT_ID"].ToString();
                        dptotal = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N0}", Convert.ToInt32(ds2.Tables[0].Rows[i]["AT_total"].ToString()));
                        dpharga = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "Rp. {0:N0}", Convert.ToInt32(ds2.Tables[0].Rows[i]["AT_harga"].ToString()));
                        DateTime dt = Convert.ToDateTime(ds2.Tables[0].Rows[i]["AT_tanggal"].ToString());
                        filepath = ds2.Tables[0].Rows[i]["AT_EvidencePath"].ToString().Replace("~", "..");
                        status = ds2.Tables[0].Rows[i]["AT_Status"].ToString();

                        htmlTable3.Append("<tr>");
                        htmlTable3.Append("<td>" + $"<input type=\"checkbox\" value=\"{IDdata}\" name=\"getid\"> " + "</td>");
                        htmlTable3.Append("<td>" + "<label style=\"font-size:12px;\">" + dt.ToString("dd MMM yyyy") + "</label>" + "</td>");
                        htmlTable3.Append("<td>" + "<label style=\"font-size:12px;\">" + ds2.Tables[0].Rows[i]["AT_keterangan"].ToString() + "</label>" + "</td>");
                        htmlTable3.Append("<td>" + "<label style=\"font-size:12px;\">" + ds2.Tables[0].Rows[i]["AT_pcs"].ToString() + "</label>" + "</td>");
                        htmlTable3.Append("<td>" + "<label style=\"font-size:12px;\">" + dpharga + "</label>" + "</td>");
                        htmlTable3.Append("<td>" + "<label style=\"font-size:12px;\">" + dptotal + "</label>" + "</td>");
                        htmlTable3.Append("<td>" + "<label style=\"font-size:12px;\">" + ds2.Tables[0].Rows[i]["AT_Status"].ToString() + "</label>" + "</td>");
                        htmlTable3.Append("<td>" + $"<button type=\"button\" style=\"font-size:12px;\" class=\"btn btnimg\" value=\"{filepath}\">" + "<i class=\"fa fa-paperclip\"></i>" + "</button>" + "</td>");
                        if (userid == "User" && status == "draft")
                            htmlTable3.Append("<td>" + $"<button type=\"button\" value=\"{IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-warning datawil\" data-toggle=\"modal\" data-target=\"#modaledit\" id=\"edit\">Edit</button>"  + "</td>");
                        htmlTable3.Append("</tr>");
                    }
                    htmlTable3.Append("</tbody>");
                    htmlTable3.Append("</table>");
                    PlaceHolder2.Controls.Add(new Literal { Text = htmlTable3.ToString() });

                }
                else
                {
                    lblpertanggungan.Visible = true;
                }
            }
        }

        public class dataedit
        {
            public string dataid { get; set; }
            public string editji { get; set; }
            public string ediths { get; set; }
            public string edittanggal { get; set; }
            public string editketerangan { get; set; }
        }

        [WebMethod]
        public static List<dataedit> GetReferensi(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"select * from AdminPertanggungan where AT_ID = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<dataedit> dawilayah = new List<dataedit>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            dawilayah.Add(new dataedit
                            {
                                dataid = sdr["AT_ID"].ToString(),
                                ediths = sdr["AT_harga"].ToString(),
                                editji = sdr["AT_pcs"].ToString(),
                                editketerangan = sdr["AT_keterangan"].ToString(),
                                edittanggal = Convert.ToDateTime(sdr["AT_Tanggal"].ToString()).ToString("yyyy/MM/dd"),
                            });
                        }
                    }
                    con.Close();
                    return dawilayah;
                }
            }
        }
    }
}