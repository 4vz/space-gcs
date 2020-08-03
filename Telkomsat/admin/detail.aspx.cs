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
    public partial class detail : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, damodal;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dsmodal = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string evidence, idjustifikasi;

        
        string querypanjar, tanggal = "", totalpanjar, input = "", pemasukan, kategori, keterangan, fileu, nominal, id;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            if (id != null)
            {
                querypanjar = $@"SELECT * FROM administrator where id_admin = {id}";

                SqlCommand cmd = new SqlCommand(querypanjar, sqlCon);
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                sqlCon.Open();
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                
                input = ds.Tables[0].Rows[0]["input"].ToString();
                kategori = ds.Tables[0].Rows[0]["kategori"].ToString();

                lblNominal.Text = String.Format(CultureInfo.CreateSpecificCulture("id-id"), "{0:N0}", Convert.ToInt32(ds.Tables[0].Rows[0]["input"].ToString()));
                if (kategori == "pengeluaran")
                {
                    lblKategori.Text = "Pengeluaran";
                }
                else if (kategori =="pemasukan")
                {
                    lblKategori.Text = "Pemasukan";
                }
                else
                {
                    lblKategori.Text = "Pemindahan";
                }

                idjustifikasi = ds.Tables[0].Rows[0]["id_aj"].ToString();


                lblKeterangan.Text = ds.Tables[0].Rows[0]["keterangan"].ToString();
                evidence = ds.Tables[0].Rows[0]["evidence"].ToString();
                lbupload.Text = evidence;

                justifikasi();

            }

            //tablepanjar();
        }
        protected void lbupload_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/admin/download.aspx?file={evidence}");
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
                    lbldetail.Text = ds.Tables[0].Rows[0]["AJ_Detail"].ToString();
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


    }
}