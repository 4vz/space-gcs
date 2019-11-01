using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.checklist
{
    public partial class harkatt3sc : System.Web.UI.Page
    {
        Nullable<int> i = null;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        SqlDataAdapter da, da1, dat;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dst = new DataSet();
        int a;
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM check_perangkat WHERE Shelter = 'T3S-C' ORDER BY Rack", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lbl1DP1.Text = " (" + ds.Tables[0].Rows[0]["S/N"].ToString() + ")";
            lbl2HPA1.Text = " (" + ds.Tables[0].Rows[2]["S/N"].ToString() + ")";
            lbl2ACHPA1.Text = " (" + ds.Tables[0].Rows[3]["S/N"].ToString() + ")";
            lbl2HPA2.Text = " (" + ds.Tables[0].Rows[1]["S/N"].ToString() + ")";
            lbl2ACHPA2.Text = " (" + ds.Tables[0].Rows[4]["S/N"].ToString() + ")";
            lbl3UC1.Text = " (" + ds.Tables[0].Rows[5]["S/N"].ToString() + ")";
            lbl3UC2.Text = " (" + ds.Tables[0].Rows[6]["S/N"].ToString() + ")";
            lbl3UC3.Text = " (" + ds.Tables[0].Rows[7]["S/N"].ToString() + ")";
            lbl3RCU1.Text = " (" + ds.Tables[0].Rows[8]["S/N"].ToString() + ")";
            lbl3RCU2.Text = " (" + ds.Tables[0].Rows[9]["S/N"].ToString() + ")";
            lbl3PS1.Text = " (" + ds.Tables[0].Rows[10]["S/N"].ToString() + ")";
            lbl3HPA1.Text = " (" + ds.Tables[0].Rows[11]["S/N"].ToString() + ")";
            lbl3KVM1.Text = " (" + ds.Tables[0].Rows[12]["S/N"].ToString() + ")"; 
            lbl3KVM2.Text = " (" + ds.Tables[0].Rows[13]["S/N"].ToString() + ")";
            lbl3eth.Text = " (" + ds.Tables[0].Rows[14]["S/N"].ToString() + ")";
            lbl3FOPSU1.Text = " (" + ds.Tables[0].Rows[15]["S/N"].ToString() + ")";
            lbl3FOTr1.Text = " (" + ds.Tables[0].Rows[16]["S/N"].ToString() + ")"; 
            lbl4dtr1.Text = " (" + ds.Tables[0].Rows[17]["S/N"].ToString() + ")";
            lbl4acu.Text = " (" + ds.Tables[0].Rows[18]["S/N"].ToString() + ")";
            lbl4con.Text = " (" + ds.Tables[0].Rows[19]["S/N"].ToString() + ")";
            lbl4dc1.Text = " (" + ds.Tables[0].Rows[20]["S/N"].ToString() + ")";
            lbl4dc2.Text = " (" + ds.Tables[0].Rows[21]["S/N"].ToString() + ")";
            lbl4dc3.Text = " (" + ds.Tables[0].Rows[22]["S/N"].ToString() + ")";
            lbl4mtr.Text = " (" + ds.Tables[0].Rows[23]["S/N"].ToString() + ")";
            lbl4pp.Text = " (" + ds.Tables[0].Rows[24]["S/N"].ToString() + ")";
            lbl4gps.Text = " (" + ds.Tables[0].Rows[25]["S/N"].ToString() + ")";
            lbl4rcu0.Text = " (" + ds.Tables[0].Rows[26]["S/N"].ToString() + ")";
            lbl4rcu1.Text = " (" + ds.Tables[0].Rows[27]["S/N"].ToString() + ")";

            string querytanggal = @"select  tanggal_check from check_tanggal where ID_tgl= (select max(ID_tgl)from check_status s join check_parameter r on r.ID_Parameter=s.ID_paramater
                                    join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat where p.Shelter = 't3s-c')";
            SqlCommand sqlCmd1 = new SqlCommand(querytanggal, con);
            dat = new SqlDataAdapter(sqlCmd1);
            dat.Fill(dst);
            con.Open();
            sqlCmd1.ExecuteNonQuery();
            con.Close();

            string tanggalquery = dst.Tables[0].Rows[0][0].ToString();
            string parsetanggal = tanggalquery.Remove(10, 9);

            if(parsetanggal.ToString() == DateTime.Now.ToString("dd/MM/yyyy"))
            {
                

                string queryidtgl = $@"SELECT COUNT(*) FROM check_status s JOIN check_parameter r on r.ID_Parameter = s.ID_paramater 
                                      JOIN check_perangkat p on p.ID_Perangkat = r.ID_Perangkat WHERE p.Shelter = 't3s-c' and s.ID_tgl = (select max(ID_tgl)from check_status s join check_parameter r on r.ID_Parameter=s.ID_paramater
						              join check_perangkat p on p.ID_Perangkat=r.ID_Perangkat where p.Shelter = 't3s-c')";

                SqlCommand cmd1 = new SqlCommand(queryidtgl, con);
                con.Open();
                string output = cmd1.ExecuteScalar().ToString();
                con.Close();

                //Response.Write(output);

                if(output != "0")
                {
                    if (!IsPostBack)
                        inisialisasi();

                    lblstatus.Visible = true;
                    lblstatus.Text = "(edit checklist)";
                    lblstatus.ForeColor = System.Drawing.Color.Orange;

                    btnedit.Visible = true;
                    btnsave.Visible = false;
                }
                

                /*foreach (var List1 in (Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder).Controls.OfType<TextBox>())
                {
                    List1.Enabled = false;
                    txt2HPA1at.Enabled = true;
                }*/
            }
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
            //if(!IsPostBack)
                inisialisasi();
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            foreach (var List1 in (Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder).Controls.OfType<TextBox>())
            {
                if (List1.Text == string.Empty)
                {

                    if (List1.Text == "")
                    {
                        List1.BorderColor = System.Drawing.Color.Red;
                    }
                    if (List1.Text.IndexOf(',') != -1)
                    {
                        List1.BorderColor = System.Drawing.Color.Yellow;
                    }
                    lblstatus.Visible = true;
                    lblstatus.Text = "(Gagal simpan, pastikan tidak ada yang kosong)";
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    a = a + 1;
                    //Response.Write(a);
                    if (a == 58)
                    {
                        string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                        string querytanggal = $"INSERT INTO check_tanggal(tanggal_check) VALUES ('{tanggal}') SELECT SCOPE_IDENTITY()";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querytanggal, con);
                        i = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                        string query = $@"UPDATE e
                            SET nilai = t.nilai
                            FROM check_status e
                            JOIN (
                            VALUES
                            ('T3SC-DHYS','{ddl1DP1.SelectedValue}'),
                            ('T3SC-DHYPr','{txt1De1pr1.Text}'),
                            ('T3SC-HPA6S','{ddl2HPA1.SelectedValue}'),
                            ('T3SC-HPA6Rf','{txt2HPA1rf.Text}'),
                            ('T3SC-HPA6At','{txt2HPA1at.Text}'),
                            ('T3SC-HPA6BV','{txt2HPA1bv.Text}'),
                            ('T3SC-HPA6HV','{txt2HPA1hv.Text}'),
                            ('T3SC-HPA6RRf','{txt2HPA1rrf.Text}'),
                            ('T3SC-HPA6IT','{txt2HPA1it.Text}'),
                            ('T3SC-HPA6BC','{txt2HPA1bc.Text}'),
                            ('T3SC-HPA6Be','{txt2HPA1bea.Text}'),
                            ('T3SC-HPA6BeC','{txt2HPA1becu.Text}'),
                            ('T3SC-HPA6HC','{txt2HPA1hecu.Text}'),
                            ('T3SC-HPA6CT','{txt2HPA1cate.Text}'),
                            ('T3SC-HPA6OT','{txt2HPA1ot.Text}'),
                            ('T3SC_PS6S','{ddl2ACHPA1.SelectedValue}'),
                            ('T3SC-HPA8S','{ddl2HPA2.SelectedValue}'),
                            ('T3SC-HPA8Rf','{txt2HPA2rfo.Text}'),
                            ('T3SC-HPA8At','{txt2HPA2at.Text}'),
                            ('T3SC-HPA8BV','{txt2HPA2bv.Text}'),
                            ('T3SC-HPA8HV','{txt2HPA2hv.Text}'),
                            ('T3SC-HPA8RRf','{txt2HPA2rrf.Text}'),
                            ('T3SC-HPA8IT','{txt2HPA2it.Text}'),
                            ('T3SC-HPA8BC','{txt2HPA2boc.Text}'),
                            ('T3SC-HPA8Be','{txt2HPA2bea.Text}'),
                            ('T3SC-HPA8BeC','{txt2HPA2bc.Text}'),
                            ('T3SC-HPA8HC','{txt2HPA2hc.Text}'),
                            ('T3SC-HPA8CT','{txt2HPA2ct.Text}'),
                            ('T3SC-HPA8OT','{txt2HPA2ot.Text}'),
                            ('T3SC_PS8S','{ddl2ACHPA2.SelectedValue}'),
                            ('T3SC-FO1S','{ddl3FOPSU1.SelectedValue}'),
                            ('T3SC-FO2S','{ddl3FOTr1.SelectedValue}'),
                            ('T3SC-KVMS','{ddl3KVM1.SelectedValue}'),
                            ('T3SC-UPC12S','{ddl3UC3.SelectedValue}'),
                            ('T3SC-UPC12Fr','{txt3UC3fr.Text}'),
                            ('T3SC-UPC12At','{txt3UC3at.Text}'),
                            ('T3SC-UPC11S','{ddl3UC2.SelectedValue}'),
                            ('T3SC-UPC11Fr','{txt3UC2fr.Text}'),
                            ('T3SC-UPC11At','{txt3UC2at.Text}'),
                            ('T3SC-UPC10S','{ddl3UC1.SelectedValue}'),
                            ('T3SC-UPC10Fr','{txt3UC1fr.Text}'),
                            ('T3SC-UPC10At','{txt3UC1at.Text}'),
                            ('T3SC-RCU24S','{ddl3RCUa.SelectedValue}'),
                            ('T3SC-RCU23S','{ddl3RCUb.SelectedValue}'),
                            ('T3SC-KVM2S','{ddl3KVM2.SelectedValue}'),
                            ('T3SC-HPA7S','{ddl3HPA3.SelectedValue}'),
                            ('T3SC-HPA7Rf','{txt3HPA3rfo.Text}'),
                            ('T3SC-HPA7At','{txt3HPA3at.Text}'),
                            ('T3SC-HPA7BV','{txt3HPA3bv.Text}'),
                            ('T3SC-HPA7HV','{txt3HPA3hv.Text}'),
                            ('T3SC-HPA7RRf','{txt3HPA3rrf.Text}'),
                            ('T3SC-HPA7IT','{txt3HPA3it.Text}'),
                            ('T3SC-HPA7BC','{txt3HPA3boc.Text}'),
                            ('T3SC-HPA7Be','{txt3HPA3bea.Text}'),
                            ('T3SC-HPA7BeC','{txt3HPA3bec.Text}'),
                            ('T3SC-HPA7HC','{txt3HPA3hc.Text}'),
                            ('T3SC-HPA7CT','{txt3HPA3hc.Text}'),
                            ('T3SC-HPA7OT','{txt3HPA3ot.Text}'),
                            ('T3SC-PS7K0S','{ddlACHPA3.SelectedValue}'),
                            ('T3SC-ETHS','{ddl3eth1.SelectedValue}'),
                            ('T3SC-RSC301S','{ddl4RCU0.SelectedValue}'),
                            ('T3SC-DC04S','{ddl4DC1.SelectedValue}'),
                            ('T3SC-DC04Fr','{txt4DC1rf.Text}'),
                            ('T3SC-DC04At','{txt4DC1at.Text}'),
                            ('T3SC-DC05S','{ddl4DC2.SelectedValue}'),
                            ('T3SC-DC05Fr','{txt4DC2fr.Text}'),
                            ('T3SC-DC05At','{txt4DC2at.Text}'),
                            ('T3SC-DC06S','{ddl4DC3.SelectedValue}'),
                            ('T3SC-DC06Fr','{txt4DC3fr.Text}'),
                            ('T3SC-DC06At','{txt4DC3at.Text}'),
                            ('T3SC-ACU160S','{ddl4acu1.SelectedValue}'),
                            ('T3SC-ACU160Az','{txt4acuaz.Text}'),
                            ('T3SC-ACU160El','{txt4acuel.Text}'),
                            ('T3SC-ACU160Po','{txt4acupol.Text}'),
                            ('T3SC-CONS','{ddl4con.SelectedValue}'),
                            ('T3SC-CONFr','{txt4CONfr.Text}'),
                            ('T3SC-CONAt','{txt4CONat.Text}'),
                            ('T3SC-MTR10S','{ddl4MTR.SelectedValue}'),
                            ('T3SC-DTR141S','{ddl4DTR.SelectedValue}'),
                            ('T3SC-DTR141Fr','{txt4DTRfr.Text}'),
                            ('T3SC-DTR141Rx','{txt4DTRrx.Text}'),
                            ('T3SC-DTR141C','{txt4DTRCn.Text}'),
                            ('T3SC-DTR141DAC','{txt4DTRDac.Text}'),
                            ('T3SC-RCU10S','{ddl4RCU1.SelectedValue}'),
                            ('T3SC-PPN01S','{ddl4PP.SelectedValue}'),
                            ('T3S-REC','{ddl4GPS.SelectedValue}'),
                            ('T3S-RECGPS1','{ddl4GPS1.SelectedValue}'),
                            ('T3S-RECGPS2','{ddl4GPS2.SelectedValue}'),
                            ('T3S-RECNTP','{ddl4NTP.SelectedValue}'),
                            ('T3S-RECTIME','{ddl4Time.SelectedValue}'),
                            ('T3S-RECUTC','{ddl4UCT.SelectedValue}')
                            ) t (ID_paramater, nilai) ON t.ID_paramater = e.ID_paramater join check_tanggal l on l.ID_tgl = e.ID_tgl
                            join check_parameter r on r.ID_Parameter = e.ID_paramater join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat 
                            where l.tanggal_check = '{tanggal}' and Shelter = 'T3S-C'";

                        con.Open();
                        SqlCommand sqlCmd = new SqlCommand(query, con);
                        sqlCmd.ExecuteNonQuery();
                        con.Close();

                        lblstatus.Visible = true;
                        lblstatus.Text = "(Berhasil di Edit)";
                        lblstatus.ForeColor = System.Drawing.Color.LightGreen;
                    }


                }
            }
        }

        void inisialisasi()
        {
            string query1 = $@"select ID_paramater, (REPLACE(s.nilai, ',', '.')) from check_status s left join check_parameter r on r.ID_Parameter=s.ID_paramater left join
                              check_perangkat p on p.ID_Perangkat=r.ID_Perangkat
                              where (ID_tgl = (select max(ID_tgl)from check_status s join check_parameter r on r.ID_Parameter=s.ID_paramater
						      join check_perangkat p on p.ID_Perangkat=r.ID_Perangkat where p.Shelter = 't3s-c')) and p.Shelter = 'T3S-C' and (r.Parameter != 'Status') order by p.Rack, r.ID_Parameter";

            SqlCommand sqlCmd1 = new SqlCommand(query1, con);
            da1 = new SqlDataAdapter(sqlCmd1);
            da1.Fill(ds1);
            con.Open();
            sqlCmd1.ExecuteNonQuery();
            con.Close();

            txt1De1pr1.Text = ds1.Tables[0].Rows[0][1].ToString();
            txt2HPA1at.Text = ds1.Tables[0].Rows[1][1].ToString();
            txt2HPA1bc.Text = ds1.Tables[0].Rows[2][1].ToString();
            txt2HPA1bea.Text = ds1.Tables[0].Rows[3][1].ToString();
            txt2HPA1becu.Text = ds1.Tables[0].Rows[4][1].ToString();
            txt2HPA1bv.Text = ds1.Tables[0].Rows[5][1].ToString();
            txt2HPA1cate.Text = ds1.Tables[0].Rows[6][1].ToString();
            txt2HPA1hecu.Text = ds1.Tables[0].Rows[7][1].ToString();
            txt2HPA1hv.Text = ds1.Tables[0].Rows[8][1].ToString();
            txt2HPA1it.Text = ds1.Tables[0].Rows[9][1].ToString();
            txt2HPA1ot.Text = ds1.Tables[0].Rows[10][1].ToString();
            txt2HPA1rf.Text = ds1.Tables[0].Rows[11][1].ToString();
            txt2HPA1rrf.Text = ds1.Tables[0].Rows[12][1].ToString();
            txt2HPA2at.Text = ds1.Tables[0].Rows[13][1].ToString();
            txt2HPA2bc.Text = ds1.Tables[0].Rows[16][1].ToString();
            txt2HPA2bea.Text = ds1.Tables[0].Rows[15][1].ToString();
            txt2HPA2boc.Text = ds1.Tables[0].Rows[14][1].ToString();
            txt2HPA2bv.Text = ds1.Tables[0].Rows[17][1].ToString();
            txt2HPA2ct.Text = ds1.Tables[0].Rows[18][1].ToString();
            txt2HPA2hc.Text = ds1.Tables[0].Rows[19][1].ToString();
            txt2HPA2hv.Text = ds1.Tables[0].Rows[20][1].ToString();
            txt2HPA2it.Text = ds1.Tables[0].Rows[21][1].ToString();
            txt2HPA2ot.Text = ds1.Tables[0].Rows[22][1].ToString();
            txt2HPA2rfo.Text = ds1.Tables[0].Rows[23][1].ToString();
            txt2HPA2rrf.Text = ds1.Tables[0].Rows[24][1].ToString();
            txt3HPA3at.Text = ds1.Tables[0].Rows[25][1].ToString();
            txt3HPA3bea.Text = ds1.Tables[0].Rows[27][1].ToString();
            txt3HPA3bec.Text = ds1.Tables[0].Rows[28][1].ToString();
            txt3HPA3boc.Text = ds1.Tables[0].Rows[26][1].ToString();
            txt3HPA3bv.Text = ds1.Tables[0].Rows[29][1].ToString();
            txt3HPA3ct.Text = ds1.Tables[0].Rows[30][1].ToString();
            txt3HPA3hc.Text = ds1.Tables[0].Rows[31][1].ToString();
            txt3HPA3hv.Text = ds1.Tables[0].Rows[32][1].ToString();
            txt3HPA3it.Text = ds1.Tables[0].Rows[33][1].ToString();
            txt3HPA3ot.Text = ds1.Tables[0].Rows[34][1].ToString();
            txt3HPA3rfo.Text = ds1.Tables[0].Rows[35][1].ToString();
            txt3HPA3rrf.Text = ds1.Tables[0].Rows[36][1].ToString();
            txt3UC1at.Text = ds1.Tables[0].Rows[37][1].ToString();
            txt3UC1fr.Text = ds1.Tables[0].Rows[38][1].ToString();
            txt3UC2at.Text = ds1.Tables[0].Rows[39][1].ToString();
            txt3UC2fr.Text = ds1.Tables[0].Rows[40][1].ToString();
            txt3UC3at.Text = ds1.Tables[0].Rows[41][1].ToString();
            txt3UC3fr.Text = ds1.Tables[0].Rows[42][1].ToString();
            txt4acuaz.Text = ds1.Tables[0].Rows[43][1].ToString();
            txt4acuel.Text = ds1.Tables[0].Rows[44][1].ToString();
            txt4acupol.Text = ds1.Tables[0].Rows[45][1].ToString();
            txt4CONat.Text = ds1.Tables[0].Rows[46][1].ToString();
            txt4CONfr.Text = ds1.Tables[0].Rows[47][1].ToString();
            txt4DC1at.Text = ds1.Tables[0].Rows[48][1].ToString();
            txt4DC1rf.Text = ds1.Tables[0].Rows[49][1].ToString();
            txt4DC2at.Text = ds1.Tables[0].Rows[50][1].ToString();
            txt4DC2fr.Text = ds1.Tables[0].Rows[51][1].ToString();
            txt4DC3at.Text = ds1.Tables[0].Rows[52][1].ToString();
            txt4DC3fr.Text = ds1.Tables[0].Rows[53][1].ToString();
            txt4DTRCn.Text = ds1.Tables[0].Rows[54][1].ToString();
            txt4DTRDac.Text = ds1.Tables[0].Rows[55][1].ToString();
            txt4DTRfr.Text = ds1.Tables[0].Rows[56][1].ToString();
            txt4DTRrx.Text = ds1.Tables[0].Rows[57][1].ToString();
        }

        protected void Save_Click(object sender, EventArgs e)
        {


            foreach (var List1 in (Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder).Controls.OfType<TextBox>())
            {
                if (List1.Text == string.Empty)
                {
                    
                    if (List1.Text == "")
                    {
                        List1.BorderColor = System.Drawing.Color.Red;
                    }
                    if (List1.Text.IndexOf(',') != -1)
                    {
                        List1.BorderColor = System.Drawing.Color.Yellow;
                    }
                    lblstatus.Visible = true;
                    lblstatus.Text = "(Gagal simpan, pastikan tidak ada yang kosong)";
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    a = a + 1;
                    //Response.Write(a);
                    if (a == 58)
                    {
                        string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                        string querytanggal = $"INSERT INTO check_tanggal(tanggal_check) VALUES ('{tanggal}') SELECT SCOPE_IDENTITY()";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querytanggal, con);
                        i = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                        string query = $@"INSERT INTO check_status(ID_paramater,id_profile ,check_status.ID_tgl, nilai)
                            VALUES
                            ('T3SC-DHYS','3','{i}','{ddl1DP1.SelectedValue}'),
                            ('T3SC-DHYPr','3','{i}','{txt1De1pr1.Text}'),
                            ('T3SC-HPA6S','3','{i}','{ddl2HPA1.SelectedValue}'),
                            ('T3SC-HPA6Rf','3','{i}','{txt2HPA1rf.Text}'),
                            ('T3SC-HPA6At','3','{i}','{txt2HPA1at.Text}'),
                            ('T3SC-HPA6BV','3','{i}','{txt2HPA1bv.Text}'),
                            ('T3SC-HPA6HV','3','{i}','{txt2HPA1hv.Text}'),
                            ('T3SC-HPA6RRf','3','{i}','{txt2HPA1rrf.Text}'),
                            ('T3SC-HPA6IT','3','{i}','{txt2HPA1it.Text}'),
                            ('T3SC-HPA6BC','3','{i}','{txt2HPA1bc.Text}'),
                            ('T3SC-HPA6Be','3','{i}','{txt2HPA1bea.Text}'),
                            ('T3SC-HPA6BeC','3','{i}','{txt2HPA1becu.Text}'),
                            ('T3SC-HPA6HC','3','{i}','{txt2HPA1hecu.Text}'),
                            ('T3SC-HPA6CT','3','{i}','{txt2HPA1cate.Text}'),
                            ('T3SC-HPA6OT','3','{i}','{txt2HPA1ot.Text}'),
                            ('T3SC_PS6S','3','{i}','{ddl2ACHPA1.SelectedValue}'),
                            ('T3SC-HPA8S','3','{i}','{ddl2HPA2.SelectedValue}'),
                            ('T3SC-HPA8Rf','3','{i}','{txt2HPA2rfo.Text}'),
                            ('T3SC-HPA8At','3','{i}','{txt2HPA2at.Text}'),
                            ('T3SC-HPA8BV','3','{i}','{txt2HPA2bv.Text}'),
                            ('T3SC-HPA8HV','3','{i}','{txt2HPA2hv.Text}'),
                            ('T3SC-HPA8RRf','3','{i}','{txt2HPA2rrf.Text}'),
                            ('T3SC-HPA8IT','3','{i}','{txt2HPA2it.Text}'),
                            ('T3SC-HPA8BC','3','{i}','{txt2HPA2boc.Text}'),
                            ('T3SC-HPA8Be','3','{i}','{txt2HPA2bea.Text}'),
                            ('T3SC-HPA8BeC','3','{i}','{txt2HPA2bc.Text}'),
                            ('T3SC-HPA8HC','3','{i}','{txt2HPA2hc.Text}'),
                            ('T3SC-HPA8CT','3','{i}','{txt2HPA2ct.Text}'),
                            ('T3SC-HPA8OT','3','{i}','{txt2HPA2ot.Text}'),
                            ('T3SC_PS8S','3','{i}','{ddl2ACHPA2.SelectedValue}'),
                            ('T3SC-FO1S','3','{i}','{ddl3FOPSU1.SelectedValue}'),
                            ('T3SC-FO2S','3','{i}','{ddl3FOTr1.SelectedValue}'),
                            ('T3SC-KVMS','3','{i}','{ddl3KVM1.SelectedValue}'),
                            ('T3SC-UPC12S','3','{i}','{ddl3UC3.SelectedValue}'),
                            ('T3SC-UPC12Fr','3','{i}','{txt3UC3fr.Text}'),
                            ('T3SC-UPC12At','3','{i}','{txt3UC3at.Text}'),
                            ('T3SC-UPC11S','3','{i}','{ddl3UC2.SelectedValue}'),
                            ('T3SC-UPC11Fr','3','{i}','{txt3UC2fr.Text}'),
                            ('T3SC-UPC11At','3','{i}','{txt3UC2at.Text}'),
                            ('T3SC-UPC10S','3','{i}','{ddl3UC1.SelectedValue}'),
                            ('T3SC-UPC10Fr','3','{i}','{txt3UC1fr.Text}'),
                            ('T3SC-UPC10At','3','{i}','{txt3UC1at.Text}'),
                            ('T3SC-RCU24S','3','{i}','{ddl3RCUa.SelectedValue}'),
                            ('T3SC-RCU23S','3','{i}','{ddl3RCUb.SelectedValue}'),
                            ('T3SC-KVM2S','3','{i}','{ddl3KVM2.SelectedValue}'),
                            ('T3SC-HPA7S','3','{i}','{ddl3HPA3.SelectedValue}'),
                            ('T3SC-HPA7Rf','3','{i}','{txt3HPA3rfo.Text}'),
                            ('T3SC-HPA7At','3','{i}','{txt3HPA3at.Text}'),
                            ('T3SC-HPA7BV','3','{i}','{txt3HPA3bv.Text}'),
                            ('T3SC-HPA7HV','3','{i}','{txt3HPA3hv.Text}'),
                            ('T3SC-HPA7RRf','3','{i}','{txt3HPA3rrf.Text}'),
                            ('T3SC-HPA7IT','3','{i}','{txt3HPA3it.Text}'),
                            ('T3SC-HPA7BC','3','{i}','{txt3HPA3boc.Text}'),
                            ('T3SC-HPA7Be','3','{i}','{txt3HPA3bea.Text}'),
                            ('T3SC-HPA7BeC','3','{i}','{txt3HPA3bec.Text}'),
                            ('T3SC-HPA7HC','3','{i}','{txt3HPA3hc.Text}'),
                            ('T3SC-HPA7CT','3','{i}','{txt3HPA3hc.Text}'),
                            ('T3SC-HPA7OT','3','{i}','{txt3HPA3ot.Text}'),
                            ('T3SC-PS7K0S','3','{i}','{ddlACHPA3.SelectedValue}'),
                            ('T3SC-ETHS','3','{i}','{ddl3eth1.SelectedValue}'),
                            ('T3SC-RSC301S','3','{i}','{ddl4RCU0.SelectedValue}'),
                            ('T3SC-DC04S','3','{i}','{ddl4DC1.SelectedValue}'),
                            ('T3SC-DC04Fr','3','{i}','{txt4DC1rf.Text}'),
                            ('T3SC-DC04At','3','{i}','{txt4DC1at.Text}'),
                            ('T3SC-DC05S','3','{i}','{ddl4DC2.SelectedValue}'),
                            ('T3SC-DC05Fr','3','{i}','{txt4DC2fr.Text}'),
                            ('T3SC-DC05At','3','{i}','{txt4DC2at.Text}'),
                            ('T3SC-DC06S','3','{i}','{ddl4DC3.SelectedValue}'),
                            ('T3SC-DC06Fr','3','{i}','{txt4DC3fr.Text}'),
                            ('T3SC-DC06At','3','{i}','{txt4DC3at.Text}'),
                            ('T3SC-ACU160S','3','{i}','{ddl4acu1.SelectedValue}'),
                            ('T3SC-ACU160Az','3','{i}','{txt4acuaz.Text}'),
                            ('T3SC-ACU160El','3','{i}','{txt4acuel.Text}'),
                            ('T3SC-ACU160Po','3','{i}','{txt4acupol.Text}'),
                            ('T3SC-CONS','3','{i}','{ddl4con.SelectedValue}'),
                            ('T3SC-CONFr','3','{i}','{txt4CONfr.Text}'),
                            ('T3SC-CONAt','3','{i}','{txt4CONat.Text}'),
                            ('T3SC-MTR10S','3','{i}','{ddl4MTR.SelectedValue}'),
                            ('T3SC-DTR141S','3','{i}','{ddl4DTR.SelectedValue}'),
                            ('T3SC-DTR141Fr','3','{i}','{txt4DTRfr.Text}'),
                            ('T3SC-DTR141Rx','3','{i}','{txt4DTRrx.Text}'),
                            ('T3SC-DTR141C','3','{i}','{txt4DTRCn.Text}'),
                            ('T3SC-DTR141DAC','3','{i}','{txt4DTRDac.Text}'),
                            ('T3SC-RCU10S','3','{i}','{ddl4RCU1.SelectedValue}'),
                            ('T3SC-PPN01S','3','{i}','{ddl4PP.SelectedValue}'),
                            ('T3S-REC','3','{i}','{ddl4GPS.SelectedValue}'),
                            ('T3S-RECGPS1','3','{i}','{ddl4GPS1.SelectedValue}'),
                            ('T3S-RECGPS2','3','{i}','{ddl4GPS2.SelectedValue}'),
                            ('T3S-RECNTP','3','{i}','{ddl4NTP.SelectedValue}'),
                            ('T3S-RECTIME','3','{i}','{ddl4Time.SelectedValue}'),
                            ('T3S-RECUTC','3','{i}','{ddl4UCT.SelectedValue}');";

                        con.Open();
                        SqlCommand sqlCmd = new SqlCommand(query, con);
                        sqlCmd.ExecuteNonQuery();
                        con.Close();

                        lblstatus.Visible = true;
                        lblstatus.Text = "(Berhasil Simpan)";
                        lblstatus.ForeColor = System.Drawing.Color.GreenYellow;
                    }

                    
                }
                
            }
        }

        
    }
}