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
    public partial class harkatmpsat : System.Web.UI.Page
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
            string querylabel = "SELECT * FROM check_perangkat WHERE Shelter = 'MPSAT' ORDER BY Rack, ID_Perangkat";
            SqlCommand cmd = new SqlCommand(querylabel, con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            lbl1hpa1.Text = " (" + ds.Tables[0].Rows[2]["S/N"].ToString() + ")";
            lbl1hpa2.Text = " (" + ds.Tables[0].Rows[0]["S/N"].ToString() + ")";
            lbl1hpa3.Text = " (" + ds.Tables[0].Rows[1]["S/N"].ToString() + ")";
            lbl1ps1.Text = " (" + ds.Tables[0].Rows[3]["S/N"].ToString() + ")";
            lbl1RCU1.Text = " (" + ds.Tables[0].Rows[4]["S/N"].ToString() + ")";
            lbl1RCU2.Text = " (" + ds.Tables[0].Rows[5]["S/N"].ToString() + ")";
            lbl1SA1.Text = " (" + ds.Tables[0].Rows[6]["S/N"].ToString() + ")";
            lbl2dc1.Text = " (" + ds.Tables[0].Rows[7]["S/N"].ToString() + ")";
            lbl2dc2.Text = " (" + ds.Tables[0].Rows[8]["S/N"].ToString() + ")";
            lbl2dc3.Text = " (" + ds.Tables[0].Rows[9]["S/N"].ToString() + ")";
            lbl2HPA1.Text = " (" + ds.Tables[0].Rows[10]["S/N"].ToString() + ")";
            lbl2kvm1.Text = " (" + ds.Tables[0].Rows[11]["S/N"].ToString() + ")";
            lbl2RCU1.Text = " (" + ds.Tables[0].Rows[12]["S/N"].ToString() + ")";
            lbl2rcu2.Text = " (" + ds.Tables[0].Rows[13]["S/N"].ToString() + ")";
            lbl2rcu3.Text = " (" + ds.Tables[0].Rows[14]["S/N"].ToString() + ")";
            lbl2rec1.Text = " (" + ds.Tables[0].Rows[15]["S/N"].ToString() + ")";
            lbl2uc1.Text = " (" + ds.Tables[0].Rows[16]["S/N"].ToString() + ")";
            lbl2uc2.Text = " (" + ds.Tables[0].Rows[17]["S/N"].ToString() + ")";
            lbl2uc3.Text = " (" + ds.Tables[0].Rows[18]["S/N"].ToString() + ")";
            lbl3acu1.Text = " (" + ds.Tables[0].Rows[19]["S/N"].ToString() + ")";
            lbl3de1.Text = " (" + ds.Tables[0].Rows[20]["S/N"].ToString() + ")";
            lbl3de2.Text = " (" + ds.Tables[0].Rows[21]["S/N"].ToString() + ")";
            lbl3dtr1.Text = " (" + ds.Tables[0].Rows[22]["S/N"].ToString() + ")";
            lbl3MCU1.Text = " (" + ds.Tables[0].Rows[23]["S/N"].ToString() + ")";
            lbl3RCu1.Text = " (" + ds.Tables[0].Rows[24]["S/N"].ToString() + ")";
            lbl3rcu2.Text = " (" + ds.Tables[0].Rows[25]["S/N"].ToString() + ")";
            lbl3su1.Text = " (" + ds.Tables[0].Rows[26]["S/N"].ToString() + ")";
            lbl3su2.Text = " (" + ds.Tables[0].Rows[27]["S/N"].ToString() + ")";



           string querytanggal = @"select  tanggal_check from check_tanggal where ID_tgl= (select max(ID_tgl)from check_status s join check_parameter r on r.ID_Parameter=s.ID_paramater
                                    join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat where p.Shelter = 'mpsat')";
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
            //var list = (Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder).Controls.OfType<TextBox>();

            //Response.Write(list.Count().ToString());
        }

        protected void inisialisasi_Click(object sender, EventArgs e)
        {
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
                            ('MP-HPA065at','{txt1hpa2at.Text}'),
                            ('MP-HPA065ct','{txt1hpa2ct.Text}'),
                            ('MP-HPA065ht','{txt1hpa2ht.Text}'),
                            ('MP-HPA065id','{txt1hpa2id.Text}'),
                            ('MP-HPA065it','{txt1hpa2it.Text}'),
                            ('MP-HPA065ps','{txt1hpa2pst.Text}'),
                            ('MP-HPA065rfo','{txt1hpa2rf.Text}'),
                            ('MP-HPA065rfs','{txt1hpa2rfs.Text}'),
                            ('MP-HPA065rrf','{txt1hpa2rrf.Text}'),
                            ('MP-HPA065s','{ddl1hpa2.SelectedValue}'),
                            ('MP-HPA065vd','{txt1hpa2vd.Text}'),
                            ('MP-HPA066at','{txt1hpa3at.Text}'),
                            ('MP-HPA066ct','{txt1hpa3ct.Text}'),
                            ('MP-HPA066ht','{txt1hpa3ht.Text}'),
                            ('MP-HPA066id','{txt1hpa3id.Text}'),
                            ('MP-HPA066it','{txt1hpa3it.Text}'),
                            ('MP-HPA066ps','{txt1hpa3pst.Text}'),
                            ('MP-HPA066rfo','{txt1hpa3rfo.Text}'),
                            ('MP-HPA066rfs','{txt1hpa3rfs.Text}'),
                            ('MP-HPA066rrf','{txt1hpa3rrf.Text}'),
                            ('MP-HPA066s','{ddl1hpa3.SelectedValue}'),
                            ('MP-HPA066vd','{txt1hpa3vd.Text}'),
                            ('MP-HPA4D7at','{txt1hpa1at.Text}'),
                            ('MP-HPA4D7bea','{txt1hpa1bea.Text}'),
                            ('MP-HPA4D7beC','{txt1hpa1beC.Text}'),
                            ('MP-HPA4D7boc','{txt1hpa1boc.Text}'),
                            ('MP-HPA4D7bv','{txt1hpa1bv.Text}'),
                            ('MP-HPA4D7ct','{txt1hpa1ct.Text}'),
                            ('MP-HPA4D7hc','{txt1hpa1hc.Text}'),
                            ('MP-HPA4D7hv','{txt1hpa1hv.Text}'),
                            ('MP-HPA4D7it','{txt1hpa1it.Text}'),
                            ('MP-HPA4D7ot','{txt1hpa1ot.Text}'),
                            ('MP-HPA4D7rfo','{txt1hpa1rf.Text}'),
                            ('MP-HPA4D7rrf','{txt1hpa1rrf.Text}'),
                            ('MP-HPA4D7s','{ddl1hpa1.SelectedValue}'),
                            ('MP-PSU4D7s','{ddl1ps1.SelectedValue}'),
                            ('MP-RCU005s','{ddl1RCU1.SelectedValue}'),
                            ('MP-RCU128s','{ddl1RCU2.SelectedValue}'),
                            ('MP-SPA760s','{ddl1sa1.SelectedValue}'),
                            ('MP-DCV821fr','{txt2dC1fr.Text}'),
                            ('MP-DCV821ga','{txt2dC1ga.Text}'),
                            ('MP-DCV821s','{ddl2dc.SelectedValue}'),
                            ('MP-DCV822fr','{txt2dc2fr.Text}'),
                            ('MP-DCV822ga','{txt2dc2ga.Text}'),
                            ('MP-DCV822s','{ddl2dC1.SelectedValue}'),
                            ('MP-DCV823fr','{txt2dc3fr.Text}'),
                            ('MP-DCV823ga','{txt2dc3ga.Text}'),
                            ('MP-DCV823s','{ddl2dc3.SelectedValue}'),
                            ('MP-FO001s','{ddl2fo1.SelectedValue}'),
                            ('MP-KVM085s','{ddl2kvm1.SelectedValue}'),
                            ('MP-RCU355s','{ddl2rcu1.SelectedValue}'),
                            ('MP-RCU358s','{ddl2rcu2.SelectedValue}'),
                            ('MP-RCU535s','{ddl2rcu3.SelectedValue}'),
                            ('MP-RCV507s','{ddl2rec1.SelectedValue}'),
                            ('MP-UPC815fr','{txt2uc1fr.Text}'),
                            ('MP-UPC815ga','{txt2uc1ga.Text}'),
                            ('MP-UPC815s','{ddl2uc1.SelectedValue}'),
                            ('MP-UPC816fr','{txt2uc2fr.Text}'),
                            ('MP-UPC816ga','{txt2uc2ga.Text}'),
                            ('MP-UPC816s','{ddl2uc2.SelectedValue}'),
                            ('MP-UPC817fr','{txt2uc3fr.Text}'),
                            ('MP-UPC817ga','{txt2UC3ga.Text}'),
                            ('MP-UPC817s','{ddl2uc3.SelectedValue}'),
                            ('MP-ACU842az','{txt3acu1az.Text}'),
                            ('MP-ACU842el','{txt3acu1el.Text}'),
                            ('MP-ACU842fr','{txt3acu1fr.Text}'),
                            ('MP-ACU842po','{txt3acu1po.Text}'),
                            ('MP-ACU842s','{ddl3acu1.SelectedValue}'),
                            ('MP-ACU842sig','{txt3acu1si.Text}'),
                            ('MP-DHY773pr','{txt3de1pr.Text}'),
                            ('MP-DHY773s','{ddl3de1.SelectedValue}'),
                            ('MP-DHY774pr','{txt3de2pr.Text}'),
                            ('MP-DHY774s','{ddl3de2.SelectedValue}'),
                            ('MP-DTR376at','{txt3dtr1at.Text}'),
                            ('MP-DTR376bw','{txt3dtr1bw.Text}'),
                            ('MP-DTR376fr','{txt3dtr1fr.Text}'),
                            ('MP-DTR376il','{txt3dtr1fr.Text}'),
                            ('MP-DTR376s','{ddl3dtr1.SelectedValue}'),
                            ('MP-MCU506s','{ddl3MCU1.SelectedValue}'),
                            ('MP-RCU101s','{ddl3rcu1.SelectedValue}'),
                            ('MP-RCU578s','{ddl3rcu2.SelectedValue}'),
                            ('MP-SU001s','{ddl3su1.SelectedValue}'),
                            ('MP-SU002s','{ddl3su2.SelectedValue}')
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

        void inisialisasi()
        {
            string query1 = $@"select ID_paramater, (REPLACE(s.nilai, ',', '.')) from check_status s left join check_parameter r on r.ID_Parameter=s.ID_paramater left join
                              check_perangkat p on p.ID_Perangkat=r.ID_Perangkat
                              where (ID_tgl = (select max(ID_tgl)from check_status s join check_parameter r on r.ID_Parameter=s.ID_paramater
                                    join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat where p.Shelter = 'mpsat')) and p.Shelter = 'mpsat' and (r.Parameter != 'Status') order by p.Rack, r.ID_Parameter";

            SqlCommand sqlCmd1 = new SqlCommand(query1, con);
            da1 = new SqlDataAdapter(sqlCmd1);
            da1.Fill(ds1);
            con.Open();
            sqlCmd1.ExecuteNonQuery();
            con.Close();


            txt1hpa1at.Text = ds1.Tables[0].Rows[20][1].ToString();
            txt1hpa1bea.Text = ds1.Tables[0].Rows[21][1].ToString();
            txt1hpa1beC.Text = ds1.Tables[0].Rows[22][1].ToString();
            txt1hpa1boc.Text = ds1.Tables[0].Rows[23][1].ToString();
            txt1hpa1bv.Text = ds1.Tables[0].Rows[24][1].ToString();
            txt1hpa1ct.Text = ds1.Tables[0].Rows[25][1].ToString();
            txt1hpa1hc.Text = ds1.Tables[0].Rows[26][1].ToString();
            txt1hpa1hv.Text = ds1.Tables[0].Rows[27][1].ToString();
            txt1hpa1it.Text = ds1.Tables[0].Rows[28][1].ToString();
            txt1hpa1ot.Text = ds1.Tables[0].Rows[29][1].ToString();
            txt1hpa1rf.Text = ds1.Tables[0].Rows[30][1].ToString();
            txt1hpa1rrf.Text = ds1.Tables[0].Rows[31][1].ToString();
            txt1hpa2at.Text = ds1.Tables[0].Rows[0][1].ToString();
            txt1hpa2ct.Text = ds1.Tables[0].Rows[1][1].ToString();
            txt1hpa2ht.Text = ds1.Tables[0].Rows[2][1].ToString();
            txt1hpa2id.Text = ds1.Tables[0].Rows[3][1].ToString();
            txt1hpa2it.Text = ds1.Tables[0].Rows[4][1].ToString();
            txt1hpa2pst.Text = ds1.Tables[0].Rows[5][1].ToString();
            txt1hpa2rf.Text = ds1.Tables[0].Rows[6][1].ToString();
            txt1hpa2rfs.Text = ds1.Tables[0].Rows[7][1].ToString();
            txt1hpa2rrf.Text = ds1.Tables[0].Rows[8][1].ToString();
            txt1hpa2vd.Text = ds1.Tables[0].Rows[9][1].ToString();
            txt1hpa3at.Text = ds1.Tables[0].Rows[10][1].ToString();
            txt1hpa3ct.Text = ds1.Tables[0].Rows[11][1].ToString();
            txt1hpa3ht.Text = ds1.Tables[0].Rows[12][1].ToString();
            txt1hpa3id.Text = ds1.Tables[0].Rows[13][1].ToString();
            txt1hpa3it.Text = ds1.Tables[0].Rows[14][1].ToString();
            txt1hpa3pst.Text = ds1.Tables[0].Rows[15][1].ToString();
            txt1hpa3rfo.Text = ds1.Tables[0].Rows[16][1].ToString();
            txt1hpa3rfs.Text = ds1.Tables[0].Rows[17][1].ToString();
            txt1hpa3rrf.Text = ds1.Tables[0].Rows[18][1].ToString();
            txt1hpa3vd.Text = ds1.Tables[0].Rows[19][1].ToString();
            txt2dC1fr.Text = ds1.Tables[0].Rows[32][1].ToString();
            txt2dC1ga.Text = ds1.Tables[0].Rows[33][1].ToString();
            txt2dc2fr.Text = ds1.Tables[0].Rows[34][1].ToString();
            txt2dc2ga.Text = ds1.Tables[0].Rows[35][1].ToString();
            txt2dc3fr.Text = ds1.Tables[0].Rows[36][1].ToString();
            txt2dc3ga.Text = ds1.Tables[0].Rows[37][1].ToString();
            txt2uc1fr.Text = ds1.Tables[0].Rows[38][1].ToString();
            txt2uc1ga.Text = ds1.Tables[0].Rows[39][1].ToString();
            txt2uc2fr.Text = ds1.Tables[0].Rows[40][1].ToString();
            txt2uc2ga.Text = ds1.Tables[0].Rows[41][1].ToString();
            txt2uc3fr.Text = ds1.Tables[0].Rows[42][1].ToString();
            txt2UC3ga.Text = ds1.Tables[0].Rows[43][1].ToString();
            txt3acu1az.Text = ds1.Tables[0].Rows[44][1].ToString();
            txt3acu1el.Text = ds1.Tables[0].Rows[45][1].ToString();
            txt3acu1fr.Text = ds1.Tables[0].Rows[46][1].ToString();
            txt3acu1po.Text = ds1.Tables[0].Rows[47][1].ToString();
            txt3acu1si.Text = ds1.Tables[0].Rows[48][1].ToString();
            txt3de1pr.Text = ds1.Tables[0].Rows[49][1].ToString();
            txt3de2pr.Text = ds1.Tables[0].Rows[50][1].ToString();
            txt3dtr1at.Text = ds1.Tables[0].Rows[51][1].ToString();
            txt3dtr1bw.Text = ds1.Tables[0].Rows[52][1].ToString();
            txt3dtr1fr.Text = ds1.Tables[0].Rows[53][1].ToString();
            txt3dtr1il.Text = ds1.Tables[0].Rows[54][1].ToString();
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
                    if (a == 55)
                    {
                        string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                        string querytanggal = $"INSERT INTO check_tanggal(tanggal_check) VALUES ('{tanggal}') SELECT SCOPE_IDENTITY()";
                        con.Open();
                        SqlCommand cmd = new SqlCommand(querytanggal, con);
                        i = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();

                        string query = $@"INSERT INTO check_status(ID_paramater,id_profile ,check_status.ID_tgl, nilai)
                            VALUES
                            ('MP-HPA065at','3','{i}','{txt1hpa2at.Text}'),
                            ('MP-HPA065ct','3','{i}','{txt1hpa2ct.Text}'),
                            ('MP-HPA065ht','3','{i}','{txt1hpa2ht.Text}'),
                            ('MP-HPA065id','3','{i}','{txt1hpa2id.Text}'),
                            ('MP-HPA065it','3','{i}','{txt1hpa2it.Text}'),
                            ('MP-HPA065ps','3','{i}','{txt1hpa2pst.Text}'),
                            ('MP-HPA065rfo','3','{i}','{txt1hpa2rf.Text}'),
                            ('MP-HPA065rfs','3','{i}','{txt1hpa2rfs.Text}'),
                            ('MP-HPA065rrf','3','{i}','{txt1hpa2rrf.Text}'),
                            ('MP-HPA065s','3','{i}','{ddl1hpa2.SelectedValue}'),
                            ('MP-HPA065vd','3','{i}','{txt1hpa2vd.Text}'),
                            ('MP-HPA066at','3','{i}','{txt1hpa3at.Text}'),
                            ('MP-HPA066ct','3','{i}','{txt1hpa3ct.Text}'),
                            ('MP-HPA066ht','3','{i}','{txt1hpa3ht.Text}'),
                            ('MP-HPA066id','3','{i}','{txt1hpa3id.Text}'),
                            ('MP-HPA066it','3','{i}','{txt1hpa3it.Text}'),
                            ('MP-HPA066ps','3','{i}','{txt1hpa3pst.Text}'),
                            ('MP-HPA066rfo','3','{i}','{txt1hpa3rfo.Text}'),
                            ('MP-HPA066rfs','3','{i}','{txt1hpa3rfs.Text}'),
                            ('MP-HPA066rrf','3','{i}','{txt1hpa3rrf.Text}'),
                            ('MP-HPA066s','3','{i}','{ddl1hpa3.SelectedValue}'),
                            ('MP-HPA066vd','3','{i}','{txt1hpa3vd.Text}'),
                            ('MP-HPA4D7at','3','{i}','{txt1hpa1at.Text}'),
                            ('MP-HPA4D7bea','3','{i}','{txt1hpa1bea.Text}'),
                            ('MP-HPA4D7beC','3','{i}','{txt1hpa1beC.Text}'),
                            ('MP-HPA4D7boc','3','{i}','{txt1hpa1boc.Text}'),
                            ('MP-HPA4D7bv','3','{i}','{txt1hpa1bv.Text}'),
                            ('MP-HPA4D7ct','3','{i}','{txt1hpa1ct.Text}'),
                            ('MP-HPA4D7hc','3','{i}','{txt1hpa1hc.Text}'),
                            ('MP-HPA4D7hv','3','{i}','{txt1hpa1hv.Text}'),
                            ('MP-HPA4D7it','3','{i}','{txt1hpa1it.Text}'),
                            ('MP-HPA4D7ot','3','{i}','{txt1hpa1ot.Text}'),
                            ('MP-HPA4D7rfo','3','{i}','{txt1hpa1rf.Text}'),
                            ('MP-HPA4D7rrf','3','{i}','{txt1hpa1rrf.Text}'),
                            ('MP-HPA4D7s','3','{i}','{ddl1hpa1.SelectedValue}'),
                            ('MP-PSU4D7s','3','{i}','{ddl1ps1.SelectedValue}'),
                            ('MP-RCU005s','3','{i}','{ddl1RCU1.SelectedValue}'),
                            ('MP-RCU128s','3','{i}','{ddl1RCU2.SelectedValue}'),
                            ('MP-SPA760s','3','{i}','{ddl1sa1.SelectedValue}'),
                            ('MP-DCV821fr','3','{i}','{txt2dC1fr.Text}'),
                            ('MP-DCV821ga','3','{i}','{txt2dC1ga.Text}'),
                            ('MP-DCV821s','3','{i}','{ddl2dc.SelectedValue}'),
                            ('MP-DCV822fr','3','{i}','{txt2dc2fr.Text}'),
                            ('MP-DCV822ga','3','{i}','{txt2dc2ga.Text}'),
                            ('MP-DCV822s','3','{i}','{ddl2dC1.SelectedValue}'),
                            ('MP-DCV823fr','3','{i}','{txt2dc3fr.Text}'),
                            ('MP-DCV823ga','3','{i}','{txt2dc3ga.Text}'),
                            ('MP-DCV823s','3','{i}','{ddl2dc3.SelectedValue}'),
                            ('MP-FO001s','3','{i}','{ddl2fo1.SelectedValue}'),
                            ('MP-KVM085s','3','{i}','{ddl2kvm1.SelectedValue}'),
                            ('MP-RCU355s','3','{i}','{ddl2rcu1.SelectedValue}'),
                            ('MP-RCU358s','3','{i}','{ddl2rcu2.SelectedValue}'),
                            ('MP-RCU535s','3','{i}','{ddl2rcu3.SelectedValue}'),
                            ('MP-RCV507s','3','{i}','{ddl2rec1.SelectedValue}'),
                            ('MP-UPC815fr','3','{i}','{txt2uc1fr.Text}'),
                            ('MP-UPC815ga','3','{i}','{txt2uc1ga.Text}'),
                            ('MP-UPC815s','3','{i}','{ddl2uc1.SelectedValue}'),
                            ('MP-UPC816fr','3','{i}','{txt2uc2fr.Text}'),
                            ('MP-UPC816ga','3','{i}','{txt2uc2ga.Text}'),
                            ('MP-UPC816s','3','{i}','{ddl2uc2.SelectedValue}'),
                            ('MP-UPC817fr','3','{i}','{txt2uc3fr.Text}'),
                            ('MP-UPC817ga','3','{i}','{txt2UC3ga.Text}'),
                            ('MP-UPC817s','3','{i}','{ddl2uc3.SelectedValue}'),
                            ('MP-ACU842az','3','{i}','{txt3acu1az.Text}'),
                            ('MP-ACU842el','3','{i}','{txt3acu1el.Text}'),
                            ('MP-ACU842fr','3','{i}','{txt3acu1fr.Text}'),
                            ('MP-ACU842po','3','{i}','{txt3acu1po.Text}'),
                            ('MP-ACU842s','3','{i}','{ddl3acu1.SelectedValue}'),
                            ('MP-ACU842sig','3','{i}','{txt3acu1si.Text}'),
                            ('MP-DHY773pr','3','{i}','{txt3de1pr.Text}'),
                            ('MP-DHY773s','3','{i}','{ddl3de1.SelectedValue}'),
                            ('MP-DHY774pr','3','{i}','{txt3de2pr.Text}'),
                            ('MP-DHY774s','3','{i}','{ddl3de2.SelectedValue}'),
                            ('MP-DTR376at','3','{i}','{txt3dtr1at.Text}'),
                            ('MP-DTR376bw','3','{i}','{txt3dtr1bw.Text}'),
                            ('MP-DTR376fr','3','{i}','{txt3dtr1fr.Text}'),
                            ('MP-DTR376il','3','{i}','{txt3dtr1il.Text}'),
                            ('MP-DTR376s','3','{i}','{ddl3dtr1.SelectedValue}'),
                            ('MP-MCU506s','3','{i}','{ddl3MCU1.SelectedValue}'),
                            ('MP-RCU101s','3','{i}','{ddl3rcu1.SelectedValue}'),
                            ('MP-RCU578s','3','{i}','{ddl3rcu2.SelectedValue}'),
                            ('MP-SU001s','3','{i}','{ddl3su1.SelectedValue}'),
                            ('MP-SU002s','3','{i}','{ddl3su2.SelectedValue}');";

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