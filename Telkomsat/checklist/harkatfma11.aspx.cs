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
    public partial class harkatfma11 : System.Web.UI.Page
    {
        Nullable<int> i = null;
        int a;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        SqlDataAdapter da, da1, dat;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dst = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM check_perangkat WHERE Shelter = 'FMA-11' ORDER BY Rack, ID_Perangkat", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            lbl1hpa1.Text = " (" + ds.Tables[0].Rows[0]["S/N"].ToString() + ")";
            lbl1hpa2.Text = " (" + ds.Tables[0].Rows[1]["S/N"].ToString() + ")";
            lbl1ps1.Text = " (" + ds.Tables[0].Rows[2]["S/N"].ToString() + ")";
            lbl1ps2.Text = " (" + ds.Tables[0].Rows[3]["S/N"].ToString() + ")";
            lbl2acu.Text = " (" + ds.Tables[0].Rows[4]["S/N"].ToString() + ")";
            lbl2dtr1.Text = " (" + ds.Tables[0].Rows[5]["S/N"].ToString() + ")";
            lbl2mcu.Text = " (" + ds.Tables[0].Rows[6]["S/N"].ToString() + ")";
            lbl2tlt1.Text = " (" + ds.Tables[0].Rows[7]["S/N"].ToString() + ")";
            lbl3dc1.Text = " (" + ds.Tables[0].Rows[8]["S/N"].ToString() + ")";
            lbl3dc2.Text = " (" + ds.Tables[0].Rows[9]["S/N"].ToString() + ")";
            lbl3mo.Text = " (" + ds.Tables[0].Rows[10]["S/N"].ToString() + ")";
            lbl3rcu1.Text = " (" + ds.Tables[0].Rows[11]["S/N"].ToString() + ")";
            lbl3rcu2.Text = " (" + ds.Tables[0].Rows[12]["S/N"].ToString() + ")";
            lbl3rcu3.Text = " (" + ds.Tables[0].Rows[13]["S/N"].ToString() + ")";
            lbl3rcu4.Text = " (" + ds.Tables[0].Rows[14]["S/N"].ToString() + ")";
            lbl3uc1.Text = " (" + ds.Tables[0].Rows[15]["S/N"].ToString() + ")";
            lbl3uc2.Text = " (" + ds.Tables[0].Rows[16]["S/N"].ToString() + ")";
            

            string querytanggal = @"select  tanggal_check from check_tanggal where ID_tgl= (select max(ID_tgl)from check_status s join check_parameter r on r.ID_Parameter=s.ID_paramater
                                    join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat where p.Shelter = 'FMA-11')";
            SqlCommand sqlCmd1 = new SqlCommand(querytanggal, con);
            dat = new SqlDataAdapter(sqlCmd1);
            dat.Fill(dst);
            con.Open();
            sqlCmd1.ExecuteNonQuery();
            con.Close();

            string tanggalquery = dst.Tables[0].Rows[0][0].ToString();
            string parsetanggal = tanggalquery.Remove(10, 9);

            if (parsetanggal.ToString() == DateTime.Now.ToString("dd/MM/yyyy"))
            {
                lblstatus.Visible = true;
                lblstatus.Text = "(edit checklist)";
                lblstatus.ForeColor = System.Drawing.Color.Orange;

                btnedit.Visible = true;
                btnsave.Visible = false;
                if (!IsPostBack)
                    inisialisasi();

                /*foreach (var List1 in (Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder).Controls.OfType<TextBox>())
                {
                    List1.Enabled = false;
                    txt2HPA1at.Enabled = true;
                }*/
            }
            //var List1 = (Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder).Controls.OfType<TextBox>();

            //Response.Write(List1.Count().ToString());
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
            inisialisasi();
            
        }

        void inisialisasi()
        {
            string query1 = $@"select ID_paramater, (REPLACE(s.nilai, ',', '.')) from check_status s left join check_parameter r on r.ID_Parameter=s.ID_paramater left join
                              check_perangkat p on p.ID_Perangkat=r.ID_Perangkat
                              where (ID_tgl = (select max(ID_tgl)from check_status s join check_parameter r on r.ID_Parameter=s.ID_paramater
                                    join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat where p.Shelter = 'FMA-11')) and (r.Parameter != 'Status') order by p.Rack, r.ID_Parameter";

            SqlCommand sqlCmd1 = new SqlCommand(query1, con);
            da1 = new SqlDataAdapter(sqlCmd1);
            da1.Fill(ds1);
            con.Open();
            sqlCmd1.ExecuteNonQuery();
            con.Close();

            txt1HPA1at.Text = ds1.Tables[0].Rows[0][1].ToString();
            txt1HPA1bc.Text = ds1.Tables[0].Rows[1][1].ToString();
            txt1HPA1be.Text = ds1.Tables[0].Rows[2][1].ToString();
            txt1HPA1beC.Text = ds1.Tables[0].Rows[3][1].ToString();
            txt1HPA1bv.Text = ds1.Tables[0].Rows[4][1].ToString();
            txt1HPA1ct.Text = ds1.Tables[0].Rows[5][1].ToString();
            txt1HPA1hC.Text = ds1.Tables[0].Rows[6][1].ToString();
            txt1HPA1hv.Text = ds1.Tables[0].Rows[7][1].ToString();
            txt1HPA1it.Text = ds1.Tables[0].Rows[8][1].ToString();
            txt1HPA1ot.Text = ds1.Tables[0].Rows[9][1].ToString();
            txt1HPA1rf.Text = ds1.Tables[0].Rows[10][1].ToString();
            txt1HPA1rrf.Text = ds1.Tables[0].Rows[11][1].ToString();
            txt1HPA2at.Text = ds1.Tables[0].Rows[12][1].ToString();
            txt1HPA2bc.Text = ds1.Tables[0].Rows[13][1].ToString();
            txt1HPA2bea.Text = ds1.Tables[0].Rows[14][1].ToString();
            txt1HPA2beC.Text = ds1.Tables[0].Rows[15][1].ToString();
            txt1HPA2bv.Text = ds1.Tables[0].Rows[16][1].ToString();
            txt1HPA2ct.Text = ds1.Tables[0].Rows[17][1].ToString();
            txt1HPA2hc.Text = ds1.Tables[0].Rows[18][1].ToString();
            txt1HPA2hv.Text = ds1.Tables[0].Rows[19][1].ToString();
            txt1HPA2it.Text = ds1.Tables[0].Rows[20][1].ToString();
            txt1HPA2ot.Text = ds1.Tables[0].Rows[21][1].ToString();
            txt1HPA2rf.Text = ds1.Tables[0].Rows[22][1].ToString();
            txt1HPA2rrf.Text = ds1.Tables[0].Rows[23][1].ToString();
            txt2ACUaz.Text = ds1.Tables[0].Rows[24][1].ToString();
            txt2ACUel.Text = ds1.Tables[0].Rows[25][1].ToString();
            txt2ACUfr.Text = ds1.Tables[0].Rows[26][1].ToString();
            txt2ACUpo.Text = ds1.Tables[0].Rows[27][1].ToString();
            txt2ACUsi.Text = ds1.Tables[0].Rows[28][1].ToString();
            txt2DTR1dac.Text = ds1.Tables[0].Rows[29][1].ToString();
            txt2DTR1fr.Text = ds1.Tables[0].Rows[30][1].ToString();
            txt3DC1fr.Text = ds1.Tables[0].Rows[32][1].ToString();
            txt3DC1at.Text = ds1.Tables[0].Rows[31][1].ToString();
            txt3DC2at.Text = ds1.Tables[0].Rows[33][1].ToString();
            txt3DC2fr.Text = ds1.Tables[0].Rows[34][1].ToString();
            txt3MoPo.Text = ds1.Tables[0].Rows[36][1].ToString();
            txt3MoFr.Text = ds1.Tables[0].Rows[35][1].ToString();
            txt3UC1at.Text = ds1.Tables[0].Rows[37][1].ToString();
            txt3UC1fr.Text = ds1.Tables[0].Rows[38][1].ToString();
            txt3UC2at.Text = ds1.Tables[0].Rows[39][1].ToString();
            txt3UC2fr.Text = ds1.Tables[0].Rows[40][1].ToString();

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
                        lblstatus.Visible = true;
                        lblstatus.Text = "(Gagal simpan, pastikan tidak ada yang kosong)";
                        lblstatus.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    a = a + 1;
                    //Response.Write(a);
                    if (a == 55)
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
                            ('FMA-HPA0J5at','{txt1HPA1at.Text}'),
                            ('FMA-HPA0J5bc','{txt1HPA1bc.Text}'),
                            ('FMA-HPA0J5bea','{txt1HPA1be.Text}'),
                            ('FMA-HPA0J5beC','{txt1HPA1beC.Text}'),
                            ('FMA-HPA0J5bv','{txt1HPA1bv.Text}'),
                            ('FMA-HPA0J5ct','{txt1HPA1ct.Text}'),
                            ('FMA-HPA0J5hc','{txt1HPA1hC.Text}'),
                            ('FMA-HPA0J5hv','{txt1HPA1hv.Text}'),
                            ('FMA-HPA0J5it','{txt1HPA1it.Text}'),
                            ('FMA-HPA0J5ot','{txt1HPA1ot.Text}'),
                            ('FMA-HPA0J5rf','{txt1HPA1rf.Text}'),
                            ('FMA-HPA0J5rrf','{txt1HPA1rrf.Text}'),
                            ('FMA-HPAJ5at','{txt1HPA2at.Text}'),
                            ('FMA-HPAJ5bc','{txt1HPA2bc.Text}'),
                            ('FMA-HPAJ5bea','{txt1HPA2bea.Text}'),
                            ('FMA-HPAJ5beC','{txt1HPA2beC.Text}'),
                            ('FMA-HPAJ5bv','{txt1HPA2bv.Text}'),
                            ('FMA-HPAJ5ct','{txt1HPA2ct.Text}'),
                            ('FMA-HPAJ5hc','{txt1HPA2hc.Text}'),
                            ('FMA-HPAJ5hv','{txt1HPA2hv.Text}'),
                            ('FMA-HPAJ5it','{txt1HPA2it.Text}'),
                            ('FMA-HPAJ5ot','{txt1HPA2ot.Text}'),
                            ('FMA-HPAJ5rf','{txt1HPA2rf.Text}'),
                            ('FMA-HPAJ5rrf','{txt1HPA2rrf.Text}'),
                            ('FMA-ACU842az','{txt2ACUaz.Text}'),
                            ('FMA-ACU842el','{txt2ACUel.Text}'),
                            ('FMA-ACU842fr','{txt2ACUfr.Text}'),
                            ('FMA-ACU842po','{txt2ACUpo.Text}'),
                            ('FMA-ACU842si','{txt2ACUsi.Text}'),
                            ('FMA-DTR456da','{txt2DTR1dac.Text}'),
                            ('FMA-DTR456fr','{txt2DTR1fr.Text}'),
                            ('FMA-DCV094at','{txt3DC1at.Text}'),
                            ('FMA-DCV094fr','{txt3DC1fr.Text}'),
                            ('FMA-DCV095at','{txt3DC2at.Text}'),
                            ('FMA-DCV095fr','{txt3DC2fr.Text}'),
                            ('FMA-MDM356fr','{txt3MoFr.Text}'),
                            ('FMA-MDM356po','{txt3MoPo.Text}'),
                            ('FMA-UPC248at','{txt3UC1at.Text}'),
                            ('FMA-UPC248fr','{txt3UC1fr.Text}'),
                            ('FMA-UPC249at','{txt3UC2at.Text}'),
                            ('FMA-UPC249fr','{txt3UC2fr.Text}'),
                            ('FMA-HPA0J5s','{ddl1HPA1.SelectedValue}'),
                            ('FMA-HPAJ5s','{ddl1HPA2.SelectedValue}'),
                            ('FMA-PSU0J5s','{ddl1PS1.SelectedValue}'),
                            ('FMA-PSU9J5s','{ddl1PS2.SelectedValue}'),
                            ('FMA-ACU842s','{ddl2ACU2.SelectedValue}'),
                            ('FMA-DTR456s','{ddl2DTR1.SelectedValue}'),
                            ('FMA-MCU744s','{ddl2MCU1.SelectedValue}'),
                            ('FMA-TLT909s','{ddl2TLT1.SelectedValue}'),
                            ('FMA-DCV094s','{ddl3DC1.SelectedValue}'),
                            ('FMA-DCV095s','{ddl3DC2.SelectedValue}'),
                            ('FMA-MDM356s','{ddl3Mo.SelectedValue}'),
                            ('FMA-RCU401s','{ddl3RCU3.SelectedValue}'),
                            ('FMA-RCU513s','{ddl3RCU1.SelectedValue}'),
                            ('FMA-RCU514s','{ddl3RCU2.SelectedValue}'),
                            ('FMA-RCU518s','{ddl3RCU4.SelectedValue}'),
                            ('FMA-UPC248s','{ddl3UC1.SelectedValue}'),
                            ('FMA-UPC249s','{ddl3UC2.SelectedValue}')
                            ) t (ID_paramater, nilai) ON t.ID_paramater = e.ID_paramater join check_tanggal l on l.ID_tgl = e.ID_tgl
                            join check_parameter r on r.ID_Parameter = e.ID_paramater join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat 
                            where l.tanggal_check = '{tanggal}'";

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


        protected void Save_Click(object sender, EventArgs e)
        {
            foreach (var List1 in (Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder).Controls.OfType<TextBox>())
            {
                if (List1.Text == string.Empty)
                {
                    List1.BorderColor = System.Drawing.Color.Red;
                    lblstatus.Visible = true;
                    lblstatus.Text = "(Gagal simpan, pastikan tidak ada yang kosong)";
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    a = a + 1;
                    //Response.Write(a);
                    if (a == 41)
                    {
                        string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                        string querytanggal = $"INSERT INTO check_tanggal(tanggal_check) VALUES ('{tanggal}') SELECT SCOPE_IDENTITY()";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querytanggal, con);
                        i = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                        string query = $@"INSERT INTO check_status(ID_paramater,id_profile ,check_status.ID_tgl, nilai)
                            VALUES
                            ('FMA-HPA0J5at','3','{i}','{txt1HPA1at.Text}'),
                            ('FMA-HPA0J5bc','3','{i}','{txt1HPA1bc.Text}'),
                            ('FMA-HPA0J5bea','3','{i}','{txt1HPA1be.Text}'),
                            ('FMA-HPA0J5beC','3','{i}','{txt1HPA1beC.Text}'),
                            ('FMA-HPA0J5bv','3','{i}','{txt1HPA1bv.Text}'),
                            ('FMA-HPA0J5ct','3','{i}','{txt1HPA1ct.Text}'),
                            ('FMA-HPA0J5hc','3','{i}','{txt1HPA1hC.Text}'),
                            ('FMA-HPA0J5hv','3','{i}','{txt1HPA1hv.Text}'),
                            ('FMA-HPA0J5it','3','{i}','{txt1HPA1it.Text}'),
                            ('FMA-HPA0J5ot','3','{i}','{txt1HPA1ot.Text}'),
                            ('FMA-HPA0J5rf','3','{i}','{txt1HPA1rf.Text}'),
                            ('FMA-HPA0J5rrf','3','{i}','{txt1HPA1rrf.Text}'),
                            ('FMA-HPAJ5at','3','{i}','{txt1HPA2at.Text}'),
                            ('FMA-HPAJ5bc','3','{i}','{txt1HPA2bc.Text}'),
                            ('FMA-HPAJ5bea','3','{i}','{txt1HPA2bea.Text}'),
                            ('FMA-HPAJ5beC','3','{i}','{txt1HPA2beC.Text}'),
                            ('FMA-HPAJ5bv','3','{i}','{txt1HPA2bv.Text}'),
                            ('FMA-HPAJ5ct','3','{i}','{txt1HPA2ct.Text}'),
                            ('FMA-HPAJ5hc','3','{i}','{txt1HPA2hc.Text}'),
                            ('FMA-HPAJ5hv','3','{i}','{txt1HPA2hv.Text}'),
                            ('FMA-HPAJ5it','3','{i}','{txt1HPA2it.Text}'),
                            ('FMA-HPAJ5ot','3','{i}','{txt1HPA2ot.Text}'),
                            ('FMA-HPAJ5rf','3','{i}','{txt1HPA2rf.Text}'),
                            ('FMA-HPAJ5rrf','3','{i}','{txt1HPA2rrf.Text}'),
                            ('FMA-ACU842az','3','{i}','{txt2ACUaz.Text}'),
                            ('FMA-ACU842el','3','{i}','{txt2ACUel.Text}'),
                            ('FMA-ACU842fr','3','{i}','{txt2ACUfr.Text}'),
                            ('FMA-ACU842po','3','{i}','{txt2ACUpo.Text}'),
                            ('FMA-ACU842si','3','{i}','{txt2ACUsi.Text}'),
                            ('FMA-DTR456da','3','{i}','{txt2DTR1dac.Text}'),
                            ('FMA-DTR456fr','3','{i}','{txt2DTR1fr.Text}'),
                            ('FMA-DCV094at','3','{i}','{txt3DC1at.Text}'),
                            ('FMA-DCV094fr','3','{i}','{txt3DC1fr.Text}'),
                            ('FMA-DCV095at','3','{i}','{txt3DC2at.Text}'),
                            ('FMA-DCV095fr','3','{i}','{txt3DC2fr.Text}'),
                            ('FMA-MDM356fr','3','{i}','{txt3MoFr.Text}'),
                            ('FMA-MDM356po','3','{i}','{txt3MoPo.Text}'),
                            ('FMA-UPC248at','3','{i}','{txt3UC1at.Text}'),
                            ('FMA-UPC248fr','3','{i}','{txt3UC1fr.Text}'),
                            ('FMA-UPC249at','3','{i}','{txt3UC2at.Text}'),
                            ('FMA-UPC249fr','3','{i}','{txt3UC2fr.Text}'),
                            ('FMA-HPA0J5s','3','{i}','{ddl1HPA1.SelectedValue}'),
                            ('FMA-HPAJ5s','3','{i}','{ddl1HPA2.SelectedValue}'),
                            ('FMA-PSU0J5s','3','{i}','{ddl1PS1.SelectedValue}'),
                            ('FMA-PSU9J5s','3','{i}','{ddl1PS2.SelectedValue}'),
                            ('FMA-ACU842s','3','{i}','{ddl2ACU2.SelectedValue}'),
                            ('FMA-DTR456s','3','{i}','{ddl2DTR1.SelectedValue}'),
                            ('FMA-MCU744s','3','{i}','{ddl2MCU1.SelectedValue}'),
                            ('FMA-TLT909s','3','{i}','{ddl2TLT1.SelectedValue}'),
                            ('FMA-DCV094s','3','{i}','{ddl3DC1.SelectedValue}'),
                            ('FMA-DCV095s','3','{i}','{ddl3DC2.SelectedValue}'),
                            ('FMA-MDM356s','3','{i}','{ddl3Mo.SelectedValue}'),
                            ('FMA-RCU401s','3','{i}','{ddl3RCU3.SelectedValue}'),
                            ('FMA-RCU513s','3','{i}','{ddl3RCU1.SelectedValue}'),
                            ('FMA-RCU514s','3','{i}','{ddl3RCU2.SelectedValue}'),
                            ('FMA-RCU518s','3','{i}','{ddl3RCU4.SelectedValue}'),
                            ('FMA-UPC248s','3','{i}','{ddl3UC1.SelectedValue}'),
                            ('FMA-UPC249s','3','{i}','{ddl3UC2.SelectedValue}');";

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