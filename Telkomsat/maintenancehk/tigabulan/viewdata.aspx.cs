using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace Telkomsat.maintenancehk.tigabulan
{
    public partial class viewdata : System.Web.UI.Page
    {
        SqlDataAdapter da, dabar;
        DataSet ds = new DataSet();
        DataSet dsbar = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", equipment, start = "a", query, end = "", nilai, style3, SN = "a", satelit, lokasi, jenisview = "";
        string tri, dataaft;
        int tahun;
        string Parameter, iduser, databef, idddl = "s", idtgl, value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, rdevice, ralias, query1, date, inisial, device, alias, tanggal, valuetgl;
        string[] words = { "a", "a" };
        string[] akhir;
        int j = 0, k, m = 0;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string queryisi;
            if (Request.QueryString["equipment"] != null)
            {
                satelit = Request.QueryString["satelit"];
                lokasi = Request.QueryString["lokasi"];
                equipment = Request.QueryString["equipment"];
                tahun = Convert.ToInt32(Request.QueryString["tahun"]);
                tri = Request.QueryString["triwulan"].ToString();

                lblroom.Text = "Data Maintenance Triwulan " + lokasi + " -> " + satelit + " -> " + equipment;
            }

            if (Session["iduser"] != null)
            {
                iduser = Session["iduser"].ToString();
            }

            date = DateTime.Now.ToString("yyyy/MM/dd");

            DateTime now = DateTime.Now;
            DateTime first = new DateTime(tahun, 1, 1);
            DateTime second = new DateTime(tahun, 3, 30);
            DateTime third = new DateTime(tahun, 4, 1);
            DateTime fourth = new DateTime(tahun, 6, 30);
            DateTime fifth = new DateTime(tahun, 7, 1);
            DateTime sixth = new DateTime(tahun, 9, 30);
            DateTime seventh = new DateTime(tahun, 10, 1);
            DateTime eighth = new DateTime(tahun, 12, 30);

            if (tri == "triwulan 1")
            {
                start = new DateTime(tahun, 1, 1).ToString("yyyy/MM/dd");
                end = new DateTime(tahun, 3, 30).ToString("yyyy/MM/dd");
            }
            else if (tri == "triwulan 2")
            {
                start = new DateTime(tahun, 4, 1).ToString("yyyy/MM/dd");
                end = new DateTime(tahun, 6, 30).ToString("yyyy/MM/dd");
            }
            else if (tri == "triwulan 3")
            {
                start = new DateTime(tahun, 7, 1).ToString("yyyy/MM/dd");
                end = new DateTime(tahun, 9, 30).ToString("yyyy/MM/dd");
            }
            else if (tri == "triwulan 4")
            {
                start = new DateTime(tahun, 10, 1).ToString("yyyy/MM/dd");
                end = new DateTime(tahun, 12, 30).ToString("yyyy/MM/dd");
            }

            queryisi = $@"select count(*) as isi from mainhk_3m_data d 
					join mainhk_3m_parameter r on r.id_parameter=d.id_parameter join mainhk_3m_perangkat t on t.id_perangkat=r.id_perangkat
                    where '{start} 00:00:00' <= d.tanggal and d.tanggal < '{end} 23:59:59' and data_aft != '' and
                    t.lokasi='{lokasi}' and t.satelit= '{satelit}' and t.equipment = '{equipment}'";

            sqlCon.Open();
            SqlCommand cmdisi = new SqlCommand(queryisi, sqlCon);
            dabar = new SqlDataAdapter(cmdisi);
            dabar.Fill(dsbar);
            cmdisi.ExecuteNonQuery();
            sqlCon.Close();

            tableticket();

        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
            Response.Redirect($"isiafter.aspx?satelit={satelit}&lokasi={lokasi}&equipment={equipment}&inisialisasi=inisialisasi");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect($"editharian.aspx?tanggal={date}&room={room}");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string data = string.Join(",", akhir);

            string query5, myid;
            SqlDataAdapter da2;
            DataSet ds2 = new DataSet();
            query5 = $@"select d.id_data, d.data_bef from mainhk_3m_data d 
					join mainhk_3m_parameter r on r.id_parameter=d.id_parameter join mainhk_3m_perangkat t on t.id_perangkat=r.id_perangkat
                    where t.lokasi='{lokasi}' and t.satelit= '{satelit}' and t.equipment = '{equipment}' order by r.id_parameter, t.sn";

            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");

            SqlCommand cmd = new SqlCommand(query5, sqlCon);
            da2 = new SqlDataAdapter(cmd);
            da2.Fill(ds2);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            int p;
            if (!object.Equals(ds2.Tables[0], null))
            {
                if (ds2.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
                    {
                        myid = ds2.Tables[0].Rows[i]["id_data"].ToString();
                        string myquery1 = $@"UPDATE mainhk_3m_data SET data_aft = '{akhir[i]}' WHERE id_data = '{myid}'";
                        sqlCon.Open();
                        SqlCommand sqlcmd = new SqlCommand(myquery1, sqlCon);
                        sqlcmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
                }
            }
            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);

            Response.Redirect($"dashboard.aspx");
            //Response.Write(query1);
        }

        void tableticket()
        {
            query = $@"select d.data_bef, d.data_aft, r.id_parameter, t.device, t.sn, r.parameter, r.satuan, r.tipe from mainhk_3m_data d 
					join mainhk_3m_parameter r on r.id_parameter=d.id_parameter join mainhk_3m_perangkat t on t.id_perangkat=r.id_perangkat
                    where t.lokasi='{lokasi}' and t.satelit= '{satelit}' and t.equipment = '{equipment}' order by r.id_parameter, t.sn";


            string tanggal = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><<th>Device</th><th>Serial Number</th><th>Parameter</th><th>Nilai Before</th><th>Nilai After</th><th>Satuan</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");

            int count = ds.Tables[0].Rows.Count;
            string[] looping = new string[count];
            string[] loopingtgl = new string[count];
            akhir = new string[count];
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_parameter"].ToString();
                        SN = ds.Tables[0].Rows[i]["sn"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["parameter"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["satuan"].ToString();
                        device = ds.Tables[0].Rows[i]["device"].ToString();
                        databef = ds.Tables[0].Rows[i]["data_bef"].ToString();
                        dataaft = ds.Tables[0].Rows[i]["data_aft"].ToString();
                        style3 = "font-weight:normal; font-size:12px;";

                        idtxt = "txt" + IDdata;
                        idddl = "ddl" + IDdata;
                        idtgl = "tgl" + IDdata;

                        if (Request.QueryString["inisialisasi"] != null)
                            nilai = ds.Tables[0].Rows[i]["data_bef"].ToString();
                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + device + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + databef + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + dataaft + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable.Append("</tr>");
                        value = Request.Form["idticket"];
                        valuetgl = Request.Form["tgl"];

                        //Response.Write(value);

                        looping[i] = IDdata;

                    }
                    //Response.Write(string.Join("\n", akhir));
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");

                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}