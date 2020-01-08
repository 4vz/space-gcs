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

namespace Telkomsat.dataasset
{
    public partial class detail : System.Web.UI.Page
    {
        SqlDataAdapter da, da1, da2;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        string IDdata, hfungsi = "st", hstatus = "a", hketerangan, htanggal = "", queryhf = "a", queryhl, query5 = "a", statusticket = "a", tanggal, queydel, jenisview = "";
        string idperangkat, idruangan, idruang, idrak, idaset, bwilayah, bruangan, brak;
        string qr = "a", divisireply = "A", style, user;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["save"] != null)
            {
                if (Request.QueryString["save"] == "1")
                    label1.Text = "  Berhasil Update Fungsional";
                else if (Request.QueryString["save"] == "2")
                    label1.Text = "  Berhasil Update Lokasi";
            }
            if (Request.QueryString["id"] != null)
            {
                IDdata = Request.QueryString["id"];
            }

            if (Session["username"] != null)
            {
                user = Session["username"].ToString();
            }

            idaset = IDdata;
            query5 = $@"select w.nama_wilayah, b.nama_bangunan, r.nama_ruangan, k.nama_rak, e.nama_jenis_equipment, m.nama_merk, d.nama_jenis_device, r.image, p.* 
                    from as_perangkat p join as_jenis_device d on p.id_jenis_device = d.id_jenis_device left
                    join as_ruangan r on p.id_ruangan = r.id_ruangan left join as_rak k on k.id_rak = p.id_rak join as_bangunan b 
					on b.id_bangunan = r.id_bangunan left join as_merk m on p.id_merk=m.id_merk
                     join as_jenis_equipment e on e.id_jenis_equipment = d.id_jenis_equipment join as_wilayah w on w.id_wilayah = b.id_wilayah 
                    where p.id_perangkat = '{idaset}'";

            SqlCommand cmd = new SqlCommand(query5, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    idperangkat = ds.Tables[0].Rows[0]["id_perangkat"].ToString();
                    idruangan = ds.Tables[0].Rows[0]["id_ruangan"].ToString();
                    idrak = ds.Tables[0].Rows[0]["id_rak"].ToString();
                    lblequipment.Text = ds.Tables[0].Rows[0]["nama_jenis_equipment"].ToString();
                    lbldevice.Text = ds.Tables[0].Rows[0]["nama_jenis_device"].ToString();
                    lblsite.Text = ds.Tables[0].Rows[0]["nama_wilayah"].ToString();
                    lblgedung.Text = ds.Tables[0].Rows[0]["nama_bangunan"].ToString();
                    lblruang.Text = ds.Tables[0].Rows[0]["nama_ruangan"].ToString();
                    lblrak.Text = ds.Tables[0].Rows[0]["nama_rak"].ToString();
                    lblwilayah.Text = ds.Tables[0].Rows[0]["nama_wilayah"].ToString();
                    lblbangunan.Text = ds.Tables[0].Rows[0]["nama_bangunan"].ToString();
                    lblruangan.Text = ds.Tables[0].Rows[0]["nama_ruangan"].ToString();
                    lblraak.Text = ds.Tables[0].Rows[0]["nama_rak"].ToString();
                    lblmerk.Text = ds.Tables[0].Rows[0]["nama_merk"].ToString();
                    lblmodel.Text = ds.Tables[0].Rows[0]["model"].ToString();
                    lblpn.Text = ds.Tables[0].Rows[0]["pn"].ToString();
                    lblsn.Text = ds.Tables[0].Rows[0]["sn"].ToString();
                    lblsatelit.Text = ds.Tables[0].Rows[0]["satelit"].ToString();
                    lbltahun.Text = ds.Tables[0].Rows[0]["tahun_pengadaan"].ToString();
                    lblfungsi.Text = ds.Tables[0].Rows[0]["fungsi"].ToString();
                    lblstatus.Text = ds.Tables[0].Rows[0]["status"].ToString();
                    lblketerangan.Text = ds.Tables[0].Rows[0]["info"].ToString();
                    lbfungsi.Text = ds.Tables[0].Rows[0]["fungsi"].ToString();
                    lbstatus.Text = ds.Tables[0].Rows[0]["status"].ToString();
                    lbket.Text = ds.Tables[0].Rows[0]["info"].ToString();
                    lbltanggal.InnerText = ds.Tables[0].Rows[0]["tanggal"].ToString();
                    lblpic.Text = ds.Tables[0].Rows[0]["username"].ToString();
                    myImg.Src = ds.Tables[0].Rows[0]["image"].ToString();
                }
            }

            bwilayah = lblwilayah.Text;
            bruangan = lblruangan.Text;
            brak = lblrak.Text;
        }

        protected void History_Click(object sender, EventArgs e)
        {
            tableticket();
            tablelokasi();
            divhistory.Visible = true;
        }


        protected void Save_Click(object sender, EventArgs e)
        {

        }

        void tablelokasi()
        {
            queryhl = $@"select h.tanggal, r.nama_ruangan, b.nama_bangunan, w.nama_wilayah, k.nama_rak, h.ruangan_before, h.wilayah_before, 
						h.rak_before from as_history_lokasi h join as_perangkat p on
                        p.id_perangkat=h.id_perangkat join as_ruangan r on r.id_ruangan=h.id_ruangan left join 
                        as_bangunan b on b.id_bangunan=r.id_bangunan left join as_wilayah w on w.id_wilayah=b.id_wilayah
                        left join as_rak k on k.id_rak=h.id_rak where h.id_perangkat = '{idaset}' order by tanggal desc";

            SqlCommand cmd = new SqlCommand(queryhl, sqlCon);
            da1 = new SqlDataAdapter(cmd);
            da1.Fill(ds1);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            style = "font-size:12px; font-weight:normal";
            htmlTable1.Append("<table id=\"example1\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable1.Append("<thead>");
            htmlTable1.Append("<tr><th></th><th colspan=\"3\" style=\"text-align:center\">Sebelum Mutasi</th><th colspan=\"3\" style=\"text-align:center\">Sesudah Mutasi</th>");
            htmlTable1.Append("<tr><th>Tanggal</th><th>PIC</th><th>Wilayah</th><th>Ruangan</th><th>Rak</th><th>Wilayah</th><th>Ruangan</th><th>Rak</th></tr>");
            htmlTable1.Append("</thead>");
            
            htmlTable1.Append("<tbody>");
            if (!object.Equals(ds1.Tables[0], null))
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        htmlTable1.Append("<tr>");
                        htmlTable1.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + ds1.Tables[0].Rows[i]["tanggal"] + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style}\">" + ds1.Tables[0].Rows[i]["username"].ToString() + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style}\">" + ds1.Tables[0].Rows[i]["wilayah_before"].ToString() + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style}\">" + ds1.Tables[0].Rows[i]["ruangan_before"].ToString() + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style}\">" + ds1.Tables[0].Rows[i]["rak_before"].ToString() + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style}\">" + ds1.Tables[0].Rows[i]["nama_wilayah"].ToString() + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style}\">" + ds1.Tables[0].Rows[i]["nama_ruangan"].ToString() + "</label>" + "</td>");
                        htmlTable1.Append("<td>" + $"<label style=\"{style}\">" + ds1.Tables[0].Rows[i]["nama_rak"].ToString() + "</label>" + "</td>");
                        htmlTable1.Append("</tr>");
                    }
                    htmlTable1.Append("</tbody>");
                    htmlTable1.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable1.ToString() });
                }
                else
                {
                    lblhl.Visible = true;
                }
            }
        }


        void tableticket()
        {
            queryhf = $@"select h.status, h.fungsi, h.keterangan, h.tanggal from as_history_fungsi h right join as_perangkat p on
                      h.id_perangkat = p.id_perangkat where p.id_perangkat = '{idaset}' order by tanggal desc";

            SqlCommand cmd = new SqlCommand(queryhf, sqlCon);
            da2 = new SqlDataAdapter(cmd);
            da2.Fill(ds2);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            style = "font-size:12px; font-weight:normal";
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>PIC</th><th>Fungsi</th><th>Status</th><th>Keterangan</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds2.Tables[0], null))
            {
                if (ds2.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        hstatus = ds2.Tables[0].Rows[i]["status"].ToString();
                        hfungsi = ds2.Tables[0].Rows[i]["fungsi"].ToString();
                        hketerangan = ds2.Tables[0].Rows[i]["keterangan"].ToString();
                        htanggal = ds2.Tables[0].Rows[i]["tanggal"].ToString();
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + ds2.Tables[0].Rows[i]["tanggal"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style}\">" + ds2.Tables[0].Rows[i]["username"].ToString() + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style}\">" + hfungsi + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style}\">" + hstatus + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style}\">" + hketerangan + "</label>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
                else
                {
                    lblhf.Visible = true;
                }
            }
        }


        protected void Ket_ServerClick(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string query = $@"INSERT INTO as_history_fungsi (username, id_perangkat, fungsi, status, keterangan, tanggal) VALUES
                               ('{user}', '{idperangkat}', '{lbfungsi.Text}', '{lbstatus.Text}', '{lbket.Text}', '{datetime1}')";
            SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();

            sqlCon.Open();
            string queryupdate = $@"update as_perangkat set fungsi='{ddlFungsi.SelectedValue}', status='{ddlStatus.SelectedValue}', info='{txtKet.Text}', tanggal='{datetime1}'
                                    where id_perangkat = '{idperangkat}'";
            SqlCommand sqlcmd1 = new SqlCommand(queryupdate, sqlCon);
            sqlcmd1.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect($"../dataasset/detail.aspx?save=1&id={idaset}");
        }

        protected void Lok_ServerClick(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string query = $@"INSERT INTO as_history_lokasi (username, id_perangkat, id_ruangan, id_rak, wilayah_before, ruangan_before, rak_before, tanggal) VALUES
                               ('{user}', '{idperangkat}', '{txtruangan.Text}', '{txtrak.Text}', '{bwilayah}', '{bruangan}', '{brak}', '{datetime1}')";
            SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();

            sqlCon.Open();
            string queryupdate = $@"update as_perangkat set id_ruangan='{txtruangan.Text}', id_rak='{txtrak.Text}', tanggal='{datetime1}'
                                    where id_perangkat = '{idperangkat}'";
            SqlCommand sqlcmd1 = new SqlCommand(queryupdate, sqlCon);
            sqlcmd1.ExecuteNonQuery();
            sqlCon.Close();

            Response.Redirect($"../dataasset/detail.aspx?save=2&id={idaset}");
        }

        public class inisial
        {
            public string idwilayah { get; set; }
            public string wilayah { get; set; }
            public string idbangunan { get; set; }
            public string bangunan { get; set; }
            public string idruangan { get; set; }
            public string ruangan { get; set; }
            public string idrak { get; set; }
            public string rak { get; set; }
            public string idequipment { get; set; }
            public string equipment { get; set; }
            public string iddevice { get; set; }
            public string device { get; set; }
            public string imgruang { get; set; }
            public string image { get; set; }
        }

        [WebMethod]
        public static List<inisial> Getwilayah()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from as_wilayah"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                idwilayah = sdr["id_wilayah"].ToString(),
                                wilayah = sdr["nama_wilayah"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> Getbangunan(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * from as_bangunan where id_wilayah = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                idbangunan = sdr["id_bangunan"].ToString(),
                                bangunan = sdr["nama_bangunan"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> Getruangan(string sobangunan)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * from as_ruangan where id_bangunan = '{sobangunan}'"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                idruangan = sdr["id_ruangan"].ToString(),
                                ruangan = sdr["nama_ruangan"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> Getrak(string soruangan)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * from as_rak where id_ruangan = '{soruangan}'"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                idrak = sdr["id_rak"].ToString(),
                                rak = sdr["nama_rak"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }
    }
}