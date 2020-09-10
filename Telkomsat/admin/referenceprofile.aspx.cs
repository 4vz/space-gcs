using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
using System.Configuration;

namespace Telkomsat.admin
{
    public partial class referenceprofile : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string kategori, style3;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnsave.UniqueID;

            referens();
        }

        protected void save_click(object sender, EventArgs e)
        {
            string querysave, querycek, previllage;
            int a = 0;

            previllage = DropDownList1.Text;

            if (previllage == "GM" || previllage == "Admin Bendahara")
            {
                querycek = $"select * from  AdminProfile where AP_Previllage = '{previllage}'";
                DataSet ds5 = Settings.LoadDataSet(querycek);

                a = ds5.Tables[0].Rows.Count;
            }

            if (a > 0)
            {
                divfail.Visible = true;
            }
            else
            {
                sqlCon.Open();
                querysave = $@"INSERT INTO AdminProfile (AP_Nama, AP_Subdit, AP_Jabatan, AP_Previllage) values
                            ('{txtnama.Text}', '{txtsubdit.Text}', '{txtjabatan.Text}', '{DropDownList1.Text}')";
                SqlCommand cmd = new SqlCommand(querysave, sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"referenceprofile.aspx");

            }
        }

        protected void Edit_ServerClick(object sender, EventArgs e)
        {
            string queryedit, querycek, previllage;
            int a = 0;

            previllage = DropDownList2.Text;

            if(previllage == "GM" || previllage == "Admin Bendahara")
            {
                querycek = $"select * from  AdminProfile where AP_Previllage = '{previllage}'";
                DataSet ds5 = Settings.LoadDataSet(querycek);

                a = ds5.Tables[0].Rows.Count;
            }

            if(a > 0)
            {
                divfail.Visible = true;
            }
            else
            {
                sqlCon.Open();
                queryedit = $@"UPdate AdminProfile SET AP_Nama='{txtnama.Text}',AP_Subdit='{txtsubdit.Text}',AP_Jabatan='{txtjabatan.Text}',AP_Previllage='{DropDownList2.Text}' where AP_ID='{txtid.Text}'";
                SqlCommand cmd = new SqlCommand(queryedit, sqlCon);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"referenceprofile.aspx");
            }
        }

        void referens()
        {
            string query, IDdata, referensi, previllage, jabatan, subdit;
            query = $"SELECT P.AP_ID, P.AP_Nama, r.AR_Reference [subdit], r1.AR_Reference [jabatan], p.AP_Previllage, e.nama, e.id_profile from AdminProfile p join " +
                $"AdminReference r on p.AP_Subdit=r.AR_ID join AdminReference r1 on p.AP_Jabatan=r1.AR_ID join Profile e on e.id_profile=p.AP_Nama";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>#</th><th>Nama</th><th>Subdit</th><th>Jabatan</th><th>Previllage</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["AP_ID"].ToString();
                        referensi = ds.Tables[0].Rows[i]["nama"].ToString();
                        subdit = ds.Tables[0].Rows[i]["subdit"].ToString();
                        jabatan = ds.Tables[0].Rows[i]["jabatan"].ToString();
                        previllage = ds.Tables[0].Rows[i]["AP_Previllage"].ToString();
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + (i + 1) + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + referensi + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + subdit + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + jabatan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + previllage + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<button type=\"button\" value=\"{IDdata}\" style=\"margin-right:7px\" class=\"btn btn-sm btn-warning datawil\" data-toggle=\"modal\" data-target=\"#modalupdate\" id=\"edit\">" + "Edit" + "</button>");
                        htmlTable.Append($"<a onclick=\"confirmdelete('action.aspx?idref={IDdata}&kategori={kategori}')\" class=\"btn btn-sm btn-danger\" id=\"btndelete\">" + "Delete" + "</button></td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }

        public class datawilayah
        {
            public string idnama { get; set; }
            public string nama { get; set; }
            public string idreferensi { get; set; }
            public string referensi { get; set; }
            public string idsubdit { get; set; }
            public string subdit { get; set; }
            public string idjabatan { get; set; }
            public string jabatan { get; set; }

            public string idnama2 { get; set; }
            public string nama2 { get; set; }
            public string idsubdit2 { get; set; }
            public string subdit2 { get; set; }
            public string idjabatan2 { get; set; }
            public string jabatan2 { get; set; }
            public string previllage { get; set; }
        }

        [WebMethod]
        public static List<datawilayah> GetReferensi(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT e.nama, e.id_profile, P.AP_ID, P.AP_Previllage, P.AP_Nama, p.AP_Subdit, p.AP_Jabatan, r.AR_Reference [subdit], r1.AR_Reference [jabatan] " +
                    $"from AdminProfile p join AdminReference r on p.AP_Subdit=r.AR_ID join AdminReference r1 on p.AP_Jabatan=r1.AR_ID" +
                    $" join Profile e on e.id_profile=p.AP_Nama where p.AP_ID = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<datawilayah> dawilayah = new List<datawilayah>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            dawilayah.Add(new datawilayah
                            {
                                idreferensi = sdr["AP_ID"].ToString(),
                                referensi = sdr["AP_Nama"].ToString(),
                                idnama2 = sdr["id_profile"].ToString(),
                                nama2 = sdr["nama"].ToString(),
                                idsubdit2 = sdr["AP_Subdit"].ToString(),
                                subdit2 = sdr["subdit"].ToString(),
                                idjabatan2 = sdr["AP_Jabatan"].ToString(),
                                jabatan2 = sdr["jabatan"].ToString(),
                                previllage = sdr["AP_Previllage"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return dawilayah;
                }
            }
        }

        [WebMethod]
        public static List<datawilayah> GetSubdit()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM AdminReference where AR_Jenis = 'subdit'"))
                {
                    cmd.Connection = con;
                    List<datawilayah> dawilayah = new List<datawilayah>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            dawilayah.Add(new datawilayah
                            {
                                idsubdit = sdr["AR_ID"].ToString(),
                                subdit = sdr["AR_Reference"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return dawilayah;
                }
            }
        }

        [WebMethod]
        public static List<datawilayah> GetNama()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM Profile"))
                {
                    cmd.Connection = con;
                    List<datawilayah> dawilayah = new List<datawilayah>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            dawilayah.Add(new datawilayah
                            {
                                idnama = sdr["id_profile"].ToString(),
                                nama = sdr["nama"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return dawilayah;
                }
            }
        }

        [WebMethod]
        public static List<datawilayah> GetJabatan()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM AdminReference where AR_Jenis = 'jabatan'"))
                {
                    cmd.Connection = con;
                    List<datawilayah> dawilayah = new List<datawilayah>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            dawilayah.Add(new datawilayah
                            {
                                idjabatan = sdr["AR_ID"].ToString(),
                                jabatan = sdr["AR_Reference"].ToString(),
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