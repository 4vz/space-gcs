using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.maintenancehk.semester
{
    public partial class viewdata : System.Web.UI.Page
    {
        SqlDataAdapter da, da2, das, dam;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet dss = new DataSet();
        DataSet dsm = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", style1 = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string querysm, rdevice, ralias, semester, tahun, device, alias, tanggalkerja, equipment, tanggal1, room, tanggalku, Parameter, satuan, tipe;
        string[] words = { "a", "a" };
        string[] datapagi, datasiang, datamalam;
        string[] tipesm, waktusm, tipes, tipem;
        int j, k, l, m, n = 0, a = 0, b, o, p, s, s1, m1;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["room"] != null)
            {
                tanggal1 = Request.QueryString["tanggal"];
                room = Request.QueryString["room"];
                rdevice = Request.QueryString["device"];
                ralias = Request.QueryString["alias"];
                semester = Request.QueryString["semester"];
                tahun = Request.QueryString["tahun"];
            }
            tanggalku = tanggal1;

            if(Request.QueryString["data"] == null)
            {
                query = $@"select r.id_parameter, t.unit, t.device, t.alias, t.sn, r.parameter, r.tipe, r.event, d.tanggal_kerja, d.data from maintenancehk_data d join maintenancehk_parameter r on
					d.id_parameter=r.id_parameter join maintenancehk_perangkat t
                    on t.id_perangkat=r.id_perangkat where t.unit = '{room}' and device = '{rdevice}' and alias = '{ralias}' and semester = '{semester}' and tahun = '{tahun}' and t.jenis='SEMESTER'
                    order by t.device, r.id_parameter";
            }
            else
            {
                query = $@"select r.id_parameter, t.unit, t.device, t.alias, t.sn, r.parameter, r.tipe, r.event from maintenancehk_parameter r
					join maintenancehk_perangkat t on t.id_perangkat=r.id_perangkat where t.unit = '{room}' and t.jenis='SEMESTER'
					and device = '{rdevice}' and alias = '{ralias}' 
                    order by t.device, r.id_parameter";
            }
            
            tableticket();
            //Response.Write(query);
        }

        void tableticket()
        {
            string tanggal = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.AppendLine("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-striped\">");
            htmlTable.AppendLine("<thead>");
            htmlTable.AppendLine("<tr><<th>Device</th><th>Alias</th><th>S/N</th><th>Parameter</th><th>Tanggal Pengerjaan</th><th>Nilai</th><th>Event</th></tr>");
            htmlTable.AppendLine("</thead>");

            htmlTable.AppendLine("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_parameter"].ToString();
                        equipment = ds.Tables[0].Rows[i]["unit"].ToString();
                        SN = ds.Tables[0].Rows[i]["sn"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["Parameter"].ToString();
                        alias = ds.Tables[0].Rows[i]["alias"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["event"].ToString();
                        device = ds.Tables[0].Rows[i]["device"].ToString();


                        if(Request.QueryString["data"] == null)
                        {
                            DateTime date1 = (DateTime)ds.Tables[0].Rows[i]["tanggal_kerja"];
                            tanggalkerja = date1.ToString("yyyy/MM/dd");

                            if (tanggalkerja == "1900/01/01")
                                tanggalkerja = "";

                            nilai = ds.Tables[0].Rows[i]["data"].ToString();
                        }
                        

                        style3 = "font-weight:normal; font-size:12px;";

                        //Response.Write(Session["jenis1"].ToString());
                        //HiddenField1.Value = IDdata;
                        htmlTable.AppendLine("<tr>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + device + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + alias + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + tanggalkerja + "</label>" + "</td>");
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + nilai + "</label>" + "</td>");
                       
                        htmlTable.AppendLine("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable.AppendLine("</tr>");
                    }

                    //Response.Write(string.Join("\n", akhir));
                    htmlTable.AppendLine("</tbody>");
                    htmlTable.AppendLine("</table>");

                    PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}