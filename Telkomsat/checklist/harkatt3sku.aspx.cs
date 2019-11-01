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
    public partial class harkatt3sku : System.Web.UI.Page
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM check_perangkat WHERE Shelter = 'T3S-KU' ORDER BY Rack, ID_Perangkat", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            lbl1de1.Text = " (" + ds.Tables[0].Rows[0]["S/N"].ToString() + ")";
            lbl1hpa1.Text = " (" + ds.Tables[0].Rows[1]["S/N"].ToString() + ")";
            lbl1hpa2.Text = " (" + ds.Tables[0].Rows[2]["S/N"].ToString() + ")";
            lbl1hpa3.Text = " (" + ds.Tables[0].Rows[3]["S/N"].ToString() + ")";
            lbl1uc1.Text = " (" + ds.Tables[0].Rows[4]["S/N"].ToString() + ")";
            lbl1uc2.Text = " (" + ds.Tables[0].Rows[5]["S/N"].ToString() + ")";
            lbl1uc3.Text = " (" + ds.Tables[0].Rows[6]["S/N"].ToString() + ")";
            lbl1uc4.Text = " (" + ds.Tables[0].Rows[7]["S/N"].ToString() + ")";
            lbl1uc5.Text = " (" + ds.Tables[0].Rows[8]["S/N"].ToString() + ")";
            lbl2eth1.Text = " (" + ds.Tables[0].Rows[9]["S/N"].ToString() + ")";
            lbl2eth2.Text = " (" + ds.Tables[0].Rows[10]["S/N"].ToString() + ")";
            lbl2fo1.Text = " (" + ds.Tables[0].Rows[11]["S/N"].ToString() + ")";
            lbl2fo2.Text = " (" + ds.Tables[0].Rows[12]["S/N"].ToString() + ")";
            lbl2fo3.Text = " (" + ds.Tables[0].Rows[13]["S/N"].ToString() + ")";
            lbl2kvm1.Text = " (" + ds.Tables[0].Rows[14]["S/N"].ToString() + ")";
            lbl2KVM2.Text = " (" + ds.Tables[0].Rows[15]["S/N"].ToString() + ")";
            lbl2rcu1.Text = " (" + ds.Tables[0].Rows[16]["S/N"].ToString() + ")";
            lbl2rcu2.Text = " (" + ds.Tables[0].Rows[17]["S/N"].ToString() + ")";
            lbl2rcu3.Text = " (" + ds.Tables[0].Rows[18]["S/N"].ToString() + ")";
            lbl3acu1.Text = " (" + ds.Tables[0].Rows[19]["S/N"].ToString() + ")";
            lbl3con.Text = " (" + ds.Tables[0].Rows[20]["S/N"].ToString() + ")";
            lbl3dc1.Text = " (" + ds.Tables[0].Rows[24]["S/N"].ToString() + ")";
            lbl3dc2.Text = " (" + ds.Tables[0].Rows[22]["S/N"].ToString() + ")";
            lbl3dc3.Text = " (" + ds.Tables[0].Rows[23]["S/N"].ToString() + ")";
            lbl3dtr.Text = " (" + ds.Tables[0].Rows[21]["S/N"].ToString() + ")";
            lbl3mtr.Text = " (" + ds.Tables[0].Rows[25]["S/N"].ToString() + ")";
            lbl3pp1.Text = " (" + ds.Tables[0].Rows[26]["S/N"].ToString() + ")";
            lbl3rcu.Text = " (" + ds.Tables[0].Rows[27]["S/N"].ToString() + ")";
            lbl3gps.Text = " (" + ds.Tables[0].Rows[28]["S/N"].ToString() + ")";

            string querytanggal = @"select  tanggal_check from check_tanggal where ID_tgl= (select max(ID_tgl)from check_status s join check_parameter r on r.ID_Parameter=s.ID_paramater
                                    join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat where p.Shelter = 'T3S-Ku')";
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
                            ('T3S-DHY501s','{ddl1De1.SelectedValue}'),
                            ('T3S-HPA4D0s','{ddl1TWTA1.SelectedValue}'),
                            ('T3S-HPA5D0s','{ddl1TWTA2.SelectedValue}'),
                            ('T3S-HPA5G4s','{ddl1TWTA3.SelectedValue}'),
                            ('T3S-UPC007s','{ddl1UC1.SelectedValue}'),
                            ('T3S-UPC009s','{ddl1UC2.SelectedValue}'),
                            ('T3S-UPC010s','{ddl1UC3.SelectedValue}'),
                            ('T3S-UPC636s','{ddl1UC4.SelectedValue}'),
                            ('T3S-UPC637s','{ddl1UC5.SelectedValue}'),
                            ('T3S-ETH016s','{ddl2Eth1.SelectedValue}'),
                            ('T3S-ETH017s','{ddl2Eth2.SelectedValue}'),
                            ('T3S-FO004s','{ddl2FO.SelectedValue}'),
                            ('T3S-FO005s','{ddl2FoPSU.SelectedValue}'),
                            ('T3S-FO006s','{ddl2FoT.SelectedValue}'),
                            ('T3S-KVM004s','{ddl2KVM.SelectedValue}'),
                            ('T3S-KVM142s','{ddl2kvm2.SelectedValue}'),
                            ('T3S-RCU031s','{ddl2RCUa.SelectedValue}'),
                            ('T3S-RCU032s','{ddl2RCUb.SelectedValue}'),
                            ('T3S-RCU033s','{ddl2RCUc.SelectedValue}'),
                            ('T3S-ACU161s','{ddl3ACU1.SelectedValue}'),
                            ('T3S-CNV064s','{ddl3Con.SelectedValue}'),
                            ('T3S-DTR142s','{ddl3DC1.SelectedValue}'),
                            ('T3S-DWC034s','{ddl3DC2.SelectedValue}'),
                            ('T3S-DWC035s','{ddl3DC3.SelectedValue}'),
                            ('T3S-DWC037s','{ddl3DTR1.SelectedValue}'),
                            ('T3S-MTR009s','{ddl3MTR.SelectedValue}'),
                            ('T3S-PP010s','{ddl3PP.SelectedValue}'),
                            ('T3S-RCU401s','{ddl3RCU.SelectedValue}'),
                            ('T3S-RCV500gps1s','{ddl3GPS1.SelectedValue}'),
                            ('T3S-RCV500gps2s','{ddl3GPS2.SelectedValue}'),
                            ('T3S-RCV500ntps','{ddl3NTP.SelectedValue}'),
                            ('T3S-RCV500s','{ddl3GPS.SelectedValue}'),
                            ('T3S-RCV500times','{ddl3Time.SelectedValue}'),
                            ('T3S-RCV500utcs','{ddl3UCT.SelectedValue}'),
                            ('T3S-DHY501pr','{txt1De1pr.Text}'),
                            ('T3S-HPA4D0boc','{txt1TWTA1bc.Text}'),
                            ('T3S-HPA4D0hl','{txt1TWTA1hlx.Text}'),
                            ('T3S-HPA4D0lo','{txt1TWTA1lc.Text}'),
                            ('T3S-HPA4D0ptx','{txt1TWTA1ptx.Text}'),
                            ('T3S-HPA4D0rf','{txt1TWTA1rf.Text}'),
                            ('T3S-HPA4D0rrf','{txt1TWTA1rrf.Text}'),
                            ('T3S-HPA5D0boc','{txt1TWTA2bc.Text}'),
                            ('T3S-HPA5D0hl','{txt1TWTA2hlx.Text}'),
                            ('T3S-HPA5D0lo','{txt1TWTA2lc.Text}'),
                            ('T3S-HPA5D0ptx','{txt1TWTA2ptx.Text}'),
                            ('T3S-HPA5D0rf','{txt1TWTA2rf.Text}'),
                            ('T3S-HPA5D0rrf','{txt1TWTA2rrf.Text}'),
                            ('T3S-HPA5G4boc','{txt1TWTA3bc.Text}'),
                            ('T3S-HPA5G4hl','{txt1TWTA3hlx.Text}'),
                            ('T3S-HPA5G4lo','{txt1TWTA3lc.Text}'),
                            ('T3S-HPA5G4ptx','{txt1TWTA3ptx.Text}'),
                            ('T3S-HPA5G4rf','{txt1TWTA3rf.Text}'),
                            ('T3S-HPA5G4rrf','{txt1TWTA3rrf.Text}'),
                            ('T3S-UPC007at','{txt1UC1at.Text}'),
                            ('T3S-UPC007fr','{txt1UC1fr.Text}'),
                            ('T3S-UPC009at','{txt1UC2at.Text}'),
                            ('T3S-UPC009fr','{txt1UC2fr.Text}'),
                            ('T3S-UPC010at','{txt1UC3at.Text}'),
                            ('T3S-UPC010fr','{txt1UC3fr.Text}'),
                            ('T3S-UPC636at','{txt1UC4at.Text}'),
                            ('T3S-UPC636fr','{txt1UC4fr.Text}'),
                            ('T3S-UPC637at','{txt1UC5at.Text}'),
                            ('T3S-UPC637fr','{txt1UC5fr.Text}'),
                            ('T3S-ACU161agc','{txt3ACU1agc.Text}'),
                            ('T3S-ACU161az','{txt3ACU1az.Text}'),
                            ('T3S-ACU161el','{txt3ACU1el.Text}'),
                            ('T3S-ACU161po','{txt3ACU1po.Text}'),
                            ('T3S-ACU161st','{txt3ACU1st.Text}'),
                            ('T3S-CNV064fr','{txt3Confr.Text}'),
                            ('T3S-CNV064at','{txt3Conat.Text}'),
                            ('T3S-DTR142cno','{txtDTR1c.Text}'),
                            ('T3S-DTR142dac1','{txtDTR1dac.Text}'),
                            ('T3S-DTR142fr','{txtDTR1fr.Text}'),
                            ('T3S-DTR142rx','{txtDTR1tx.Text}'),
                            ('T3S-DWC034at','{txt3DC1at.Text}'),
                            ('T3S-DWC034fr','{txt3DC1fq.Text}'),
                            ('T3S-DWC035at','{txt3DC2at.Text}'),
                            ('T3S-DWC035fr','{txt3DC2fq.Text}'),
                            ('T3S-DWC037at','{txt3DC3at.Text}'),
                            ('T3S-DWC037fr','{txt3DC3fq.Text}')
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
                    if (a == 44)
                    {
                        string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                        string querytanggal = $"INSERT INTO check_tanggal(tanggal_check) VALUES ('{tanggal}') SELECT SCOPE_IDENTITY()";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querytanggal, con);
                        i = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                        string query = $@"INSERT INTO check_status(ID_paramater,id_profile ,check_status.ID_tgl, nilai)
                            VALUES
                            ('T3S-DHY501s','3','{i}','{ddl1De1.SelectedValue}'),
                            ('T3S-HPA4D0s','3','{i}','{ddl1TWTA1.SelectedValue}'),
                            ('T3S-HPA5D0s','3','{i}','{ddl1TWTA2.SelectedValue}'),
                            ('T3S-HPA5G4s','3','{i}','{ddl1TWTA3.SelectedValue}'),
                            ('T3S-UPC007s','3','{i}','{ddl1UC1.SelectedValue}'),
                            ('T3S-UPC009s','3','{i}','{ddl1UC2.SelectedValue}'),
                            ('T3S-UPC010s','3','{i}','{ddl1UC3.SelectedValue}'),
                            ('T3S-UPC636s','3','{i}','{ddl1UC4.SelectedValue}'),
                            ('T3S-UPC637s','3','{i}','{ddl1UC5.SelectedValue}'),
                            ('T3S-ETH016s','3','{i}','{ddl2Eth1.SelectedValue}'),
                            ('T3S-ETH017s','3','{i}','{ddl2Eth2.SelectedValue}'),
                            ('T3S-FO004s','3','{i}','{ddl2FO.SelectedValue}'),
                            ('T3S-FO005s','3','{i}','{ddl2FoPSU.SelectedValue}'),
                            ('T3S-FO006s','3','{i}','{ddl2FoT.SelectedValue}'),
                            ('T3S-KVM004s','3','{i}','{ddl2KVM.SelectedValue}'),
                            ('T3S-KVM142s','3','{i}','{ddl2kvm2.SelectedValue}'),
                            ('T3S-RCU031s','3','{i}','{ddl2RCUa.SelectedValue}'),
                            ('T3S-RCU032s','3','{i}','{ddl2RCUb.SelectedValue}'),
                            ('T3S-RCU033s','3','{i}','{ddl2RCUc.SelectedValue}'),
                            ('T3S-ACU161s','3','{i}','{ddl3ACU1.SelectedValue}'),
                            ('T3S-CNV064s','3','{i}','{ddl3Con.SelectedValue}'),
                            ('T3S-DTR142s','3','{i}','{ddl3DC1.SelectedValue}'),
                            ('T3S-DWC034s','3','{i}','{ddl3DC2.SelectedValue}'),
                            ('T3S-DWC035s','3','{i}','{ddl3DC3.SelectedValue}'),
                            ('T3S-DWC037s','3','{i}','{ddl3DTR1.SelectedValue}'),
                            ('T3S-MTR009s','3','{i}','{ddl3MTR.SelectedValue}'),
                            ('T3S-PP010s','3','{i}','{ddl3PP.SelectedValue}'),
                            ('T3S-RCU401s','3','{i}','{ddl3RCU.SelectedValue}'),
                            ('T3S-RCV500gps1s','3','{i}','{ddl3GPS1.SelectedValue}'),
                            ('T3S-RCV500gps2s','3','{i}','{ddl3GPS2.SelectedValue}'),
                            ('T3S-RCV500ntps','3','{i}','{ddl3NTP.SelectedValue}'),
                            ('T3S-RCV500s','3','{i}','{ddl3GPS.SelectedValue}'),
                            ('T3S-RCV500times','3','{i}','{ddl3Time.SelectedValue}'),
                            ('T3S-RCV500utcs','3','{i}','{ddl3UCT.SelectedValue}'),
                            ('T3S-DHY501pr','3','{i}','{txt1De1pr.Text}'),
                            ('T3S-HPA4D0boc','3','{i}','{txt1TWTA1bc.Text}'),
                            ('T3S-HPA4D0hl','3','{i}','{txt1TWTA1hlx.Text}'),
                            ('T3S-HPA4D0lo','3','{i}','{txt1TWTA1lc.Text}'),
                            ('T3S-HPA4D0ptx','3','{i}','{txt1TWTA1ptx.Text}'),
                            ('T3S-HPA4D0rf','3','{i}','{txt1TWTA1rf.Text}'),
                            ('T3S-HPA4D0rrf','3','{i}','{txt1TWTA1rrf.Text}'),
                            ('T3S-HPA5D0boc','3','{i}','{txt1TWTA2bc.Text}'),
                            ('T3S-HPA5D0hl','3','{i}','{txt1TWTA2hlx.Text}'),
                            ('T3S-HPA5D0lo','3','{i}','{txt1TWTA2lc.Text}'),
                            ('T3S-HPA5D0ptx','3','{i}','{txt1TWTA2ptx.Text}'),
                            ('T3S-HPA5D0rf','3','{i}','{txt1TWTA2rf.Text}'),
                            ('T3S-HPA5D0rrf','3','{i}','{txt1TWTA2rrf.Text}'),
                            ('T3S-HPA5G4boc','3','{i}','{txt1TWTA3bc.Text}'),
                            ('T3S-HPA5G4hl','3','{i}','{txt1TWTA3hlx.Text}'),
                            ('T3S-HPA5G4lo','3','{i}','{txt1TWTA3lc.Text}'),
                            ('T3S-HPA5G4ptx','3','{i}','{txt1TWTA3ptx.Text}'),
                            ('T3S-HPA5G4rf','3','{i}','{txt1TWTA3rf.Text}'),
                            ('T3S-HPA5G4rrf','3','{i}','{txt1TWTA3rrf.Text}'),
                            ('T3S-UPC007at','3','{i}','{txt1UC1at.Text}'),
                            ('T3S-UPC007fr','3','{i}','{txt1UC1fr.Text}'),
                            ('T3S-UPC009at','3','{i}','{txt1UC2at.Text}'),
                            ('T3S-UPC009fr','3','{i}','{txt1UC2fr.Text}'),
                            ('T3S-UPC010at','3','{i}','{txt1UC3at.Text}'),
                            ('T3S-UPC010fr','3','{i}','{txt1UC3fr.Text}'),
                            ('T3S-UPC636at','3','{i}','{txt1UC4at.Text}'),
                            ('T3S-UPC636fr','3','{i}','{txt1UC4fr.Text}'),
                            ('T3S-UPC637at','3','{i}','{txt1UC5at.Text}'),
                            ('T3S-UPC637fr','3','{i}','{txt1UC5fr.Text}'),
                            ('T3S-ACU161agc','3','{i}','{txt3ACU1agc.Text}'),
                            ('T3S-ACU161az','3','{i}','{txt3ACU1az.Text}'),
                            ('T3S-ACU161el','3','{i}','{txt3ACU1el.Text}'),
                            ('T3S-ACU161po','3','{i}','{txt3ACU1po.Text}'),
                            ('T3S-ACU161st','3','{i}','{txt3ACU1st.Text}'),
                            ('T3S-CNV064fr','3','{i}','{txt3Confr.Text}'),
                            ('T3S-CNV064at','3','{i}','{txt3Conat.Text}'),
                            ('T3S-DTR142cno','3','{i}','{txtDTR1c.Text}'),
                            ('T3S-DTR142dac1','3','{i}','{txtDTR1dac.Text}'),
                            ('T3S-DTR142fr','3','{i}','{txtDTR1fr.Text}'),
                            ('T3S-DTR142rx','3','{i}','{txtDTR1tx.Text}'),
                            ('T3S-DWC034at','3','{i}','{txt3DC1at.Text}'),
                            ('T3S-DWC034fr','3','{i}','{txt3DC1fq.Text}'),
                            ('T3S-DWC035at','3','{i}','{txt3DC2at.Text}'),
                            ('T3S-DWC035fr','3','{i}','{txt3DC2fq.Text}'),
                            ('T3S-DWC037at','3','{i}','{txt3DC3at.Text}'),
                            ('T3S-DWC037fr','3','{i}','{txt3DC3fq.Text}');";

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

        protected void Button2_Click(object sender, EventArgs e)
        {

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
                                    join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat where p.Shelter = 't3s-ku')) and (r.Parameter != 'Status') order by p.Rack, r.ID_Parameter";

            SqlCommand sqlCmd1 = new SqlCommand(query1, con);
            da1 = new SqlDataAdapter(sqlCmd1);
            da1.Fill(ds1);
            con.Open();
            sqlCmd1.ExecuteNonQuery();
            con.Close();

            txt1De1pr.Text = ds1.Tables[0].Rows[0][1].ToString();
            txt1TWTA1bc.Text = ds1.Tables[0].Rows[1][1].ToString();
            txt1TWTA1hlx.Text = ds1.Tables[0].Rows[2][1].ToString();
            txt1TWTA1lc.Text = ds1.Tables[0].Rows[3][1].ToString();
            txt1TWTA1ptx.Text = ds1.Tables[0].Rows[4][1].ToString();
            txt1TWTA1rf.Text = ds1.Tables[0].Rows[5][1].ToString();
            txt1TWTA1rrf.Text = ds1.Tables[0].Rows[6][1].ToString();
            txt1TWTA2bc.Text = ds1.Tables[0].Rows[7][1].ToString();
            txt1TWTA2hlx.Text = ds1.Tables[0].Rows[8][1].ToString();
            txt1TWTA2lc.Text = ds1.Tables[0].Rows[9][1].ToString();
            txt1TWTA2ptx.Text = ds1.Tables[0].Rows[10][1].ToString();
            txt1TWTA2rf.Text = ds1.Tables[0].Rows[11][1].ToString();
            txt1TWTA2rrf.Text = ds1.Tables[0].Rows[12][1].ToString();
            txt1TWTA3bc.Text = ds1.Tables[0].Rows[13][1].ToString();
            txt1TWTA3hlx.Text = ds1.Tables[0].Rows[14][1].ToString();
            txt1TWTA3lc.Text = ds1.Tables[0].Rows[15][1].ToString();
            txt1TWTA3ptx.Text = ds1.Tables[0].Rows[16][1].ToString();
            txt1TWTA3rf.Text = ds1.Tables[0].Rows[17][1].ToString();
            txt1TWTA3rrf.Text = ds1.Tables[0].Rows[18][1].ToString();
            txt1UC1at.Text = ds1.Tables[0].Rows[19][1].ToString();
            txt1UC1fr.Text = ds1.Tables[0].Rows[20][1].ToString();
            txt1UC2at.Text = ds1.Tables[0].Rows[21][1].ToString();
            txt1UC2fr.Text = ds1.Tables[0].Rows[22][1].ToString();
            txt1UC3at.Text = ds1.Tables[0].Rows[23][1].ToString();
            txt1UC3fr.Text = ds1.Tables[0].Rows[24][1].ToString();
            txt1UC4at.Text = ds1.Tables[0].Rows[25][1].ToString();
            txt1UC4fr.Text = ds1.Tables[0].Rows[26][1].ToString();
            txt1UC5at.Text = ds1.Tables[0].Rows[27][1].ToString();
            txt1UC5fr.Text = ds1.Tables[0].Rows[28][1].ToString();
            txt3ACU1agc.Text = ds1.Tables[0].Rows[29][1].ToString();
            txt3ACU1az.Text = ds1.Tables[0].Rows[30][1].ToString();
            txt3ACU1el.Text = ds1.Tables[0].Rows[31][1].ToString();
            txt3ACU1po.Text = ds1.Tables[0].Rows[32][1].ToString();
            txt3ACU1st.Text = ds1.Tables[0].Rows[33][1].ToString();
            txt3Conat.Text = ds1.Tables[0].Rows[34][1].ToString();
            txt3Confr.Text = ds1.Tables[0].Rows[35][1].ToString();  
            txtDTR1c.Text = ds1.Tables[0].Rows[36][1].ToString();
            txtDTR1fr.Text = ds1.Tables[0].Rows[38][1].ToString();
            txtDTR1dac.Text = ds1.Tables[0].Rows[37][1].ToString();
            txtDTR1tx.Text = ds1.Tables[0].Rows[39][1].ToString();
            txt3DC1at.Text = ds1.Tables[0].Rows[40][1].ToString();
            txt3DC1fq.Text = ds1.Tables[0].Rows[41][1].ToString();
            txt3DC2at.Text = ds1.Tables[0].Rows[42][1].ToString();
            txt3DC2fq.Text = ds1.Tables[0].Rows[43][1].ToString();
            txt3DC3at.Text = ds1.Tables[0].Rows[44][1].ToString();
            txt3DC3fq.Text = ds1.Tables[0].Rows[45][1].ToString();
        }
    }
}