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

namespace Telkomsat.checklistme
{
    public partial class dataharian : System.Web.UI.Page
    {
        SqlDataAdapter da, da2, das, dam;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet dss = new DataSet();
        DataSet dsm = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa", Perangkat = "st", style1 = "a", query, waktu = "", nilai = "", style4 = "a", style3, SN = "a", statusticket = "a", queryfav, queydel, jenisview = "";
        string Parameter = "a", query2 = "A", tanggalku = "s", value = "1", idtxt = "A", loop = "", ruangan, tipe, satuan, room, query1, date, inisial, siang = "", malam = "", tanggal1;
        string querysm, idsm, querys, idp, querym, idm;
        string[] words = { "a", "a" };
        string[] datapagi, datasiang, datamalam;
        string[] tipesm, waktusm, tipes, tipem;
        int j, k, l, m, n = 0, a = 0, b, o, p, s, s1, m1;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["tanggal"] != null)
            {
                tanggal1 = Request.QueryString["tanggal"];
            }
            tanggalku = tanggal1;
            
            if (!IsPostBack)
            {
                query = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe from checkme_parameter r INNER join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat order by p.ruangan, r.urutan, r.id_perangkat";

                querysm = $@"select d.waktu, d.nilai, r.id_parameter from checkme_parameter r left join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat left join checkme_data d on d.id_parameter = r.id_parameter
                    where d.tanggal = '{tanggalku}' and d.waktu = 'pagi' order by p.ruangan, r.urutan, r.id_perangkat";

                querys = $@"select d.waktu, d.nilai, r.id_parameter from checkme_parameter r left join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat left join checkme_data d on d.id_parameter = r.id_parameter
                    where d.tanggal = '{tanggalku}' and d.waktu = 'siang' order by p.ruangan, r.urutan, r.id_perangkat";

                querym = $@"select d.waktu, d.nilai, r.id_parameter from checkme_parameter r left join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat left join checkme_data d on d.id_parameter = r.id_parameter
                    where d.tanggal = '{tanggalku}' and d.waktu = 'malam' order by p.ruangan, r.urutan, r.id_perangkat";
                tableticket();
            }


        }

        protected void Filter_ServerClick(object sender, EventArgs e)
        {
            if (ddlKategori.SelectedValue == "ruangan")
                room = "ruangan";
            else
                room = "'" + ddlKategori.Text + "'";

            query = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe from checkme_parameter r INNER join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat where ruangan = {room} order by p.ruangan, r.urutan, r.id_perangkat";

            querysm = $@"select d.waktu, d.nilai, r.id_parameter from checkme_parameter r left join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat left join checkme_data d on d.id_parameter = r.id_parameter
                    where ruangan = {room} AND d.tanggal = '{tanggalku}' and d.waktu = 'pagi' order by p.ruangan, r.urutan, r.id_perangkat";

            querys = $@"select d.waktu, d.nilai, r.id_parameter from checkme_parameter r left join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat left join checkme_data d on d.id_parameter = r.id_parameter
                    where ruangan = {room} AND d.tanggal = '{tanggalku}' and d.waktu = 'siang' order by p.ruangan, r.urutan, r.id_perangkat";

            querym = $@"select d.waktu, d.nilai, r.id_parameter from checkme_parameter r left join
                    checkme_perangkat p on p.id_perangkat = r.id_perangkat left join checkme_data d on d.id_parameter = r.id_parameter
                    where ruangan = {room} AND d.tanggal = '{tanggalku}' and d.waktu = 'malam' order by p.ruangan, r.urutan, r.id_perangkat";
            tableticket();
        }

        void tableticket()
        {
            

            SqlCommand cmd6 = new SqlCommand(querysm, sqlCon);
            da2 = new SqlDataAdapter(cmd6);
            da2.Fill(ds2);
            sqlCon.Open();
            cmd6.ExecuteNonQuery();
            sqlCon.Close();


            SqlCommand cmds = new SqlCommand(querys, sqlCon);
            das = new SqlDataAdapter(cmds);
            das.Fill(dss);
            sqlCon.Open();
            cmds.ExecuteNonQuery();
            sqlCon.Close();

            SqlCommand cmdm = new SqlCommand(querym, sqlCon);
            dam = new SqlDataAdapter(cmdm);
            dam.Fill(dsm);
            sqlCon.Open();
            cmdm.ExecuteNonQuery();
            sqlCon.Close();

            int count = ds2.Tables[0].Rows.Count;
            string[] looping = new string[count];
            datapagi = new string[count];
            
            int counts = dss.Tables[0].Rows.Count;
            string[] loopings = new string[counts];
            datasiang = new string[counts];

            int countm = dsm.Tables[0].Rows.Count;
            string[] loopingm = new string[countm];
            datamalam = new string[countm];
            tipes = new string[counts];
            tipesm = new string[count];
            tipem = new string[countm];

            if (count > 0)
            {
                for (int runs = 0; runs < count; runs++)
                {
                    datapagi[j] = ds2.Tables[0].Rows[runs]["nilai"].ToString();
                    tipesm[j] = ds2.Tables[0].Rows[runs]["id_parameter"].ToString();
                    j++;
                }
            }

            if (counts > 0)
            {
                for (int runs = 0; runs < counts; runs++)
                {
                    datasiang[a] = dss.Tables[0].Rows[runs]["nilai"].ToString();
                    tipes[a] = dss.Tables[0].Rows[runs]["id_parameter"].ToString();
                    a++;
                }
            }

            if (countm > 0)
            {
                for (int runs = 0; runs < countm; runs++)
                {
                    datamalam[b] = dsm.Tables[0].Rows[runs]["nilai"].ToString();
                    tipem[b] = dsm.Tables[0].Rows[runs]["id_parameter"].ToString();
                    b++;
                }
            }
            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();


            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Ruangan</th><th>Perangkat</th><th>Serial Number</th><th>Parameter</th><th>Pagi</th><th>Siang</th><th>Malam</th><th>Satuan</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            k = 0;
            s = 0;
            p = 0;
            if (!object.Equals(ds.Tables[0], null))
            {
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    m = 0;
                    s1 = 0;
                    m1 = 0;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_parameter"].ToString();
                        Perangkat = ds.Tables[0].Rows[i]["Perangkat"].ToString();
                        SN = ds.Tables[0].Rows[i]["sn"].ToString();
                        Parameter = ds.Tables[0].Rows[i]["Parameter"].ToString();
                        ruangan = ds.Tables[0].Rows[i]["ruangan"].ToString();
                        tipe = ds.Tables[0].Rows[i]["tipe"].ToString();
                        satuan = ds.Tables[0].Rows[i]["satuan"].ToString();

                        if (count > 0)
                        {
                            idsm = tipesm[m];
                            if (IDdata == idsm)
                            {
                                nilai = datapagi[k];
                                k++;
                                if (m >= (count - 1))
                                    m = 0;
                                else
                                    m++;
                            }
                            else
                            {
                                nilai = "";
                            }
                        }

                        if (counts > 0)
                        {
                            idp = tipes[s1];
                            if (IDdata == idp)
                            {
                                siang = datasiang[s];
                                s++;
                                if (s1 >= (counts - 1))
                                    s1 = 0;
                                else
                                    s1++;
                            }
                            else
                            {
                                siang = "";
                            }
                        }

                        if (countm > 0)
                        {
                            idm = tipem[m1];
                            if (IDdata == idm)
                            {
                                malam = datamalam[p];
                                p++;
                                if (m1 >= (countm - 1))
                                    m1 = 0;
                                else
                                    m1++;
                            }
                            else
                            {
                                malam = "";
                            }
                        }

                        style3 = "font-weight:normal; font-size:12px;";

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + ruangan + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + Perangkat + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + SN + "</label>" + "</td>");
                        htmlTable.Append("<td style=\"border-right:3px solid #dddddd;\">" + $"<label style=\"{style3}\">" + Parameter + "</label>" + "</td>");
                        htmlTable.Append("<td style=\"border-right:3px solid #dddddd;\">" + $"<label style=\"{style3}\">{nilai}</label>" + "</td>");
                        htmlTable.Append("<td style=\"border-right:3px solid #dddddd;\">" + $"<label style=\"{style3}\">{siang}</label>" + "</td>");
                        htmlTable.Append("<td style=\"border-right:3px solid #dddddd;\">" + $"<label style=\"{style3}\">{malam}</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + satuan + "</label>" + "</td>");
                        htmlTable.Append("</tr>");
                        value = Request.Form["idticket"];
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");

                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }

    }
}