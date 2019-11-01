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
    public partial class harkatt2 : System.Web.UI.Page
    {
        Nullable<int> i = null;
        int a;
        SqlDataAdapter da, da1, dat;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataSet dst = new DataSet();
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM check_perangkat WHERE Shelter = 'T2' ORDER BY Rack, ID_Perangkat", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            //sqlCmd.Parameters.AddWithValue("@ID", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
            lbl1de.Text = " (" + ds.Tables[0].Rows[0]["S/N"].ToString() + ")";
            lbl1mo.Text = " (" + ds.Tables[0].Rows[1]["S/N"].ToString() + ")";
            lbl1rcu.Text = " (" + ds.Tables[0].Rows[2]["S/N"].ToString() + ")";
            lbl1rcu1.Text = " (" + ds.Tables[0].Rows[3]["S/N"].ToString() + ")";
            lbl1uc1.Text = " (" + ds.Tables[0].Rows[4]["S/N"].ToString() + ")";
            lbl1uc2.Text = " (" + ds.Tables[0].Rows[5]["S/N"].ToString() + ")";
            lbl1uc3.Text = " (" + ds.Tables[0].Rows[6]["S/N"].ToString() + ")";
            lbl2acu.Text = " (" + ds.Tables[0].Rows[7]["S/N"].ToString() + ")";
            lbl2dc.Text = " (" + ds.Tables[0].Rows[8]["S/N"].ToString() + ")";
            lbl2dc1.Text = " (" + ds.Tables[0].Rows[9]["S/N"].ToString() + ")";
            lbl2dc2.Text = " (" + ds.Tables[0].Rows[10]["S/N"].ToString() + ")";
            lbl2dtr.Text = " (" + ds.Tables[0].Rows[11]["S/N"].ToString() + ")";
            lbl2mrc.Text = " (" + ds.Tables[0].Rows[12]["S/N"].ToString() + ")";
            lbl2pm.Text = " (" + ds.Tables[0].Rows[13]["S/N"].ToString() + ")";
            lbl2rcu.Text = " (" + ds.Tables[0].Rows[14]["S/N"].ToString() + ")";
            lbl2rs.Text = " (" + ds.Tables[0].Rows[15]["S/N"].ToString() + ")";
            lbl2tlt.Text = " (" + ds.Tables[0].Rows[16]["S/N"].ToString() + ")";
            lbl3aps.Text = " (" + ds.Tables[0].Rows[17]["S/N"].ToString() + ")";
            lbl3hpa1.Text = " (" + ds.Tables[0].Rows[18]["S/N"].ToString() + ")";
            lbl4hpa1.Text = " (" + ds.Tables[0].Rows[19]["S/N"].ToString() + ")";
            lbl4hpa2.Text = " (" + ds.Tables[0].Rows[20]["S/N"].ToString() + ")";
            lbl4ps.Text = " (" + ds.Tables[0].Rows[21]["S/N"].ToString() + ")";

            string querytanggal = @"select tanggal_check from check_tanggal where ID_tgl= (select max(ID_tgl)from check_status s join check_parameter r on r.ID_Parameter=s.ID_paramater
                                    join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat where p.Shelter = 'T2')";
            SqlCommand sqlCmd1 = new SqlCommand(querytanggal, con);
            dat = new SqlDataAdapter(sqlCmd1);
            dat.Fill(dst);
            con.Open();
            sqlCmd1.ExecuteNonQuery();
            con.Close();

            string tanggalquery = dst.Tables[0].Rows[0][0].ToString();
            string parsetanggal = tanggalquery.Remove(10, 9);

            var tanggalchecklist = DateTime.Parse(parsetanggal).AddDays(3).ToString("dd/MM/yyyy");
            var sekarang = DateTime.Now.ToString("dd/MM/yyyy");

            if (parsetanggal.ToString() == DateTime.Now.ToString("dd/MM/yyyy"))
            {
                lblstatus.Visible = true;
                lblstatus.Text = "(edit checklist)";
                lblstatus.ForeColor = System.Drawing.Color.Orange;

                btnedit.Visible = true;
                btnsave.Visible = false;
                if (!IsPostBack)
                    inisialisasi();

                foreach (var List1 in (Page.Master.FindControl("ContentPlaceHolder1") as ContentPlaceHolder).Controls.OfType<TextBox>())
                {

                    //var kemarin = DateTime.Now.AddDays(3).ToString("yyyy/MM/dd");
                    if(tanggalchecklist == sekarang)
                    {
                        List1.Enabled = false;
                    }
                    
                    //txt2HPA1at.Enabled = true;
                }
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
                            ('T2-1des','{ddl1De1.SelectedValue}'),
                            ('T2-1dePr','{txt1DePr.Text}'),
                            ('T2-1mos','{ddl1Mo.SelectedValue}'),
                            ('T2-1mofr','{txt1MoFr.Text}'),
                            ('T2-1mopo','{txt1MoPo.Text}'),
                            ('T2-1rcus','{ddl1RCU.SelectedValue}'),
                            ('T2-1rcu1S','{ddl1RCU1.SelectedValue}'),
                            ('T2-1rcu1Co','{txt1SOU1c.Text}'),
                            ('T2-1rcu1Fr','{txt1SOU1fr.Text}'),
                            ('T2-1rcu1Pr','{txt1SOU1pr.Text}'),
                            ('T2-1rcu1Ad','{txt1SOU1ad.Text}'),
                            ('T2-1rcu1At','{txt1SOU1at.Text}'),
                            ('T2-1uc1St','{ddl1UC1.SelectedValue}'),
                            ('T2-1uc1Fr','{txt1UC1fr.Text}'),
                            ('T2-1uc1At','{txt1UC1at.Text}'),
                            ('T2-1uc2S','{ddl1UC2.SelectedValue}'),
                            ('T2-1uc2Fr','{txt1UC2fr.Text}'),
                            ('T2-1uc2At','{txt1UC2at.Text}'),
                            ('T2-1uc3S','{ddl1UC3.SelectedValue}'),
                            ('T2-1uc3Fr','{txt1UC3fr.Text}'),
                            ('T2-1uc3At','{txt1UC3at.Text}'),
                            ('T2-2acuS','{ddl2ACU.SelectedValue}'),
                            ('T2-2acuFr','{txt2ACU2fr.Text}'),
                            ('T2-2acuAz','{txt2ACU2az.Text}'),
                            ('T2-2acuEl','{txt2ACU2el.Text}'),
                            ('T2-2acuPo','{txt2ACU2po.Text}'),
                            ('T2-2acuRfI','{txt2ACU2rf.Text}'),
                            ('T2-2dcS','{ddl2DC1.SelectedValue}'),
                            ('T2-2dcFr','{txt2DC1fr.Text}'),
                            ('T2-2dcAt','{txt2DC1at.Text}'),
                            ('T2-2dc1S','{ddl2DC2.SelectedValue}'),
                            ('T2-2dc1Fr','{txt2DC2fr.Text}'),
                            ('T2-2dc1At','{txt2DC2at.Text}'),
                            ('T2-2dc2S','{ddl2DC3.SelectedValue}'),
                            ('T2-2dc2Fr','{txt2DC3fr.Text}'),
                            ('T2-2dc2At','{txt2DC3at.Text}'),
                            ('T2-2dtrS','{ddlDTR1.SelectedValue}'),
                            ('T2-2dtrFr','{txt2DTR1fr.Text}'),
                            ('T2-2dtrCNo','{txt2DTR1c.Text}'),
                            ('T2-2dtrTx','{txt2DTR1tx.Text}'),
                            ('T2-2dtrDac','{txt2DTR1dac.Text}'),
                            ('T2-2mrcS','{ddl2MRC1.SelectedValue}'),
                            ('T2-2pmS','{ddl2PM1.SelectedValue}'),
                            ('T2-2pmLv','{txt2PM1lv.Text}'),
                            ('T2-2rcuS','{ddl2RCU1.SelectedValue}'),
                            ('T2-2rcuCon','{txt2SOU1co.Text}'),
                            ('T2-2rcuFr','{txt2SOU1fr.Text}'),
                            ('T2-2rcuPri','{txt2SOU1pr.Text}'),
                            ('T2-2rcuAd','{txt2SOU1ad.Text}'),
                            ('T2-2rcuAt','{txt2SOU1at.Text}'),
                            ('T2-2rsS','{ddl2RS1.SelectedValue}'),
                            ('T2-2tltS','{ddl2TLT1.SelectedValue}'),
                            ('T2-3apsS','{ddl3AC.SelectedValue}'),
                            ('T2-3hpa1S','{ddl3HPA1.SelectedValue}'),
                            ('T2-3hpa1Rf','{txt3KPA1rf.Text}'),
                            ('T2-3hpa1At','{txt3KPA1at.Text}'),
                            ('T2-3hpa1BV','{txt3KPA1bv.Text}'),
                            ('T2-3hpa1Hv','{txt3KPA1hv.Text}'),
                            ('T2-3hpa1RRf','{txt3KPA1rrf.Text}'),
                            ('T2-3hpa1Bc','{txt3KPA1boc.Text}'),
                            ('T2-3hpa1KC','{txt3KPA1kc.Text}'),
                            ('T2-3hpa1BeC','{txt3KPA1bc.Text}'),
                            ('T2-3hpa1CT','{txt3KPA1ct.Text}'),
                            ('T2-3hpa1Ot','{txt3KPA1ot.Text}'),
                            ('T2-4hpa1S','{ddl4HPA1.SelectedValue}'),
                            ('T2-4hpa1Rf','{txt4KPA1rf.Text}'),
                            ('T2-4hpa1At','{txt4KPA1at.Text}'),
                            ('T2-4hpa1BV','{txt4KPA1bv.Text}'),
                            ('T2-4hpa1Hv','{txt4KPA1hv.Text}'),
                            ('T2-4hpa1RRf','{txt4KPA1rrf.Text}'),
                            ('T2-4hpa1Bc','{txt4KPA1boc.Text}'),
                            ('T2-4hpa1KC','{txt4KPA1kc.Text}'),
                            ('T2-4hpa1BeC','{txt4KPA1bc.Text}'),
                            ('T2-4hpa1CT','{txt4KPA1ct.Text}'),
                            ('T2-4hpa1Ot','{txt4KPA1ot.Text}'),
                            ('T2-4hpa2S','{ddl4HPA2.SelectedValue}'),
                            ('T2-4hpa2RF','{txt4KPA2rf.Text}'),
                            ('T2-4hpa2At','{txt4KPA2at.Text}'),
                            ('T2-4hpa2RRf','{txt4KPA2rrf.Text}'),
                            ('T2-4hpa2HC','{txt4KPA2hc.Text}'),
                            ('T2-4hpa2HV','{txt4KPA2hv.Text}'),
                            ('T2-4ps1SS','{ddl4AC1.SelectedValue}')
                            ) t (ID_paramater, nilai) ON t.ID_paramater = e.ID_paramater join check_tanggal l on l.ID_tgl = e.ID_tgl
                            join check_parameter r on r.ID_Parameter = e.ID_paramater join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat 
                            where l.tanggal_check = '{tanggal}' and Shelter = 'T2'";

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
                            ('T2-1des','3','{i}','{ddl1De1.SelectedValue}'),
                            ('T2-1dePr','3','{i}','{txt1DePr.Text}'),
                            ('T2-1mos','3','{i}','{ddl1Mo.SelectedValue}'),
                            ('T2-1mofr','3','{i}','{txt1MoFr.Text}'),
                            ('T2-1mopo','3','{i}','{txt1MoPo.Text}'),
                            ('T2-1rcus','3','{i}','{ddl1RCU.SelectedValue}'),
                            ('T2-1rcu1S','3','{i}','{ddl1RCU1.SelectedValue}'),
                            ('T2-1rcu1Co','3','{i}','{txt1SOU1c.Text}'),
                            ('T2-1rcu1Fr','3','{i}','{txt1SOU1fr.Text}'),
                            ('T2-1rcu1Pr','3','{i}','{txt1SOU1pr.Text}'),
                            ('T2-1rcu1Ad','3','{i}','{txt1SOU1ad.Text}'),
                            ('T2-1rcu1At','3','{i}','{txt1SOU1at.Text}'),
                            ('T2-1uc1St','3','{i}','{ddl1UC1.SelectedValue}'),
                            ('T2-1uc1Fr','3','{i}','{txt1UC1fr.Text}'),
                            ('T2-1uc1At','3','{i}','{txt1UC1at.Text}'),
                            ('T2-1uc2S','3','{i}','{ddl1UC2.SelectedValue}'),
                            ('T2-1uc2Fr','3','{i}','{txt1UC2fr.Text}'),
                            ('T2-1uc2At','3','{i}','{txt1UC2at.Text}'),
                            ('T2-1uc3S','3','{i}','{ddl1UC3.SelectedValue}'),
                            ('T2-1uc3Fr','3','{i}','{txt1UC3fr.Text}'),
                            ('T2-1uc3At','3','{i}','{txt1UC3at.Text}'),
                            ('T2-2acuS','3','{i}','{ddl2ACU.SelectedValue}'),
                            ('T2-2acuFr','3','{i}','{txt2ACU2fr.Text}'),
                            ('T2-2acuAz','3','{i}','{txt2ACU2az.Text}'),
                            ('T2-2acuEl','3','{i}','{txt2ACU2el.Text}'),
                            ('T2-2acuPo','3','{i}','{txt2ACU2po.Text}'),
                            ('T2-2acuRfI','3','{i}','{txt2ACU2rf.Text}'),
                            ('T2-2dcS','3','{i}','{ddl2DC1.SelectedValue}'),
                            ('T2-2dcFr','3','{i}','{txt2DC1fr.Text}'),
                            ('T2-2dcAt','3','{i}','{txt2DC1at.Text}'),
                            ('T2-2dc1S','3','{i}','{ddl2DC2.SelectedValue}'),
                            ('T2-2dc1Fr','3','{i}','{txt2DC2fr.Text}'),
                            ('T2-2dc1At','3','{i}','{txt2DC3at.Text}'),
                            ('T2-2dc2S','3','{i}','{ddl2DC3.SelectedValue}'),
                            ('T2-2dc2Fr','3','{i}','{txt2DC3fr.Text}'),
                            ('T2-2dc2At','3','{i}','{txt2DC3at.Text}'),
                            ('T2-2dtrS','3','{i}','{ddlDTR1.SelectedValue}'),
                            ('T2-2dtrFr','3','{i}','{txt2DTR1fr.Text}'),
                            ('T2-2dtrCNo','3','{i}','{txt2DTR1c.Text}'),
                            ('T2-2dtrTx','3','{i}','{txt2DTR1tx.Text}'),
                            ('T2-2dtrDac','3','{i}','{txt2DTR1dac.Text}'),
                            ('T2-2mrcS','3','{i}','{ddl2MRC1.SelectedValue}'),
                            ('T2-2pmS','3','{i}','{ddl2PM1.SelectedValue}'),
                            ('T2-2pmLv','3','{i}','{txt2PM1lv.Text}'),
                            ('T2-2rcuS','3','{i}','{ddl2RCU1.SelectedValue}'),
                            ('T2-2rcuCon','3','{i}','{txt2SOU1co.Text}'),
                            ('T2-2rcuFr','3','{i}','{txt2SOU1fr.Text}'),
                            ('T2-2rcuPri','3','{i}','{txt2SOU1pr.Text}'),
                            ('T2-2rcuAd','3','{i}','{txt2SOU1ad.Text}'),
                            ('T2-2rcuAt','3','{i}','{txt2SOU1at.Text}'),
                            ('T2-2rsS','3','{i}','{ddl2RS1.SelectedValue}'),
                            ('T2-2tltS','3','{i}','{ddl2TLT1.SelectedValue}'),
                            ('T2-3apsS','3','{i}','{ddl3AC.SelectedValue}'),
                            ('T2-3hpa1S','3','{i}','{ddl3HPA1.SelectedValue}'),
                            ('T2-3hpa1Rf','3','{i}','{txt3KPA1rf.Text}'),
                            ('T2-3hpa1At','3','{i}','{txt3KPA1at.Text}'),
                            ('T2-3hpa1BV','3','{i}','{txt3KPA1bv.Text}'),
                            ('T2-3hpa1Hv','3','{i}','{txt3KPA1hv.Text}'),
                            ('T2-3hpa1RRf','3','{i}','{txt3KPA1rrf.Text}'),
                            ('T2-3hpa1Bc','3','{i}','{txt3KPA1boc.Text}'),
                            ('T2-3hpa1KC','3','{i}','{txt3KPA1kc.Text}'),
                            ('T2-3hpa1BeC','3','{i}','{txt3KPA1bc.Text}'),
                            ('T2-3hpa1CT','3','{i}','{txt3KPA1ct.Text}'),
                            ('T2-3hpa1Ot','3','{i}','{txt3KPA1ot.Text}'),
                            ('T2-4hpa1S','3','{i}','{ddl4HPA1.SelectedValue}'),
                            ('T2-4hpa1Rf','3','{i}','{txt4KPA1rf.Text}'),
                            ('T2-4hpa1At','3','{i}','{txt4KPA1at.Text}'),
                            ('T2-4hpa1BV','3','{i}','{txt4KPA1bv.Text}'),
                            ('T2-4hpa1Hv','3','{i}','{txt4KPA1hv.Text}'),
                            ('T2-4hpa1RRf','3','{i}','{txt4KPA1rrf.Text}'),
                            ('T2-4hpa1Bc','3','{i}','{txt4KPA1boc.Text}'),
                            ('T2-4hpa1KC','3','{i}','{txt4KPA1kc.Text}'),
                            ('T2-4hpa1BeC','3','{i}','{txt4KPA1bc.Text}'),
                            ('T2-4hpa1CT','3','{i}','{txt4KPA1ct.Text}'),
                            ('T2-4hpa1Ot','3','{i}','{txt4KPA1ot.Text}'),
                            ('T2-4hpa2S','3','{i}','{ddl4HPA2.SelectedValue}'),
                            ('T2-4hpa2RF','3','{i}','{txt4KPA2rf.Text}'),
                            ('T2-4hpa2At','3','{i}','{txt4KPA2at.Text}'),
                            ('T2-4hpa2RRf','3','{i}','{txt4KPA2rrf.Text}'),
                            ('T2-4hpa2HC','3','{i}','{txt4KPA2hc.Text}'),
                            ('T2-4hpa2HV','3','{i}','{txt4KPA2hv.Text}'),
                            ('T2-4ps1SS','3','{i}','{ddl4AC1.SelectedValue}');";

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
            //sqlCmd.Parameters.AddWithValue("@ID", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));*/
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
                              join check_perangkat p on p.ID_Perangkat = r.ID_Perangkat where p.Shelter = 'T2')) and p.Shelter = 'T2' and (r.Parameter != 'Status') order by p.Rack, r.ID_Parameter";

            SqlCommand sqlCmd1 = new SqlCommand(query1, con);
            da1 = new SqlDataAdapter(sqlCmd1);
            da1.Fill(ds1);
            con.Open();
            sqlCmd1.ExecuteNonQuery();
            con.Close();

            txt1DePr.Text = ds1.Tables[0].Rows[0][1].ToString();
            txt1MoFr.Text = ds1.Tables[0].Rows[1][1].ToString();
            txt1MoPo.Text = ds1.Tables[0].Rows[2][1].ToString();
            txt1SOU1ad.Text = ds1.Tables[0].Rows[3][1].ToString();
            txt1SOU1at.Text = ds1.Tables[0].Rows[4][1].ToString();
            txt1SOU1c.Text = ds1.Tables[0].Rows[5][1].ToString();
            txt1SOU1fr.Text = ds1.Tables[0].Rows[6][1].ToString();
            txt1SOU1pr.Text = ds1.Tables[0].Rows[7][1].ToString();
            txt1UC1at.Text = ds1.Tables[0].Rows[8][1].ToString();
            txt1UC1fr.Text = ds1.Tables[0].Rows[9][1].ToString();
            txt1UC2at.Text = ds1.Tables[0].Rows[10][1].ToString();
            txt1UC2fr.Text = ds1.Tables[0].Rows[11][1].ToString();
            txt1UC3at.Text = ds1.Tables[0].Rows[12][1].ToString();
            txt1UC3fr.Text = ds1.Tables[0].Rows[13][1].ToString();
            txt2ACU2az.Text = ds1.Tables[0].Rows[14][1].ToString();
            txt2ACU2el.Text = ds1.Tables[0].Rows[15][1].ToString();
            txt2ACU2fr.Text = ds1.Tables[0].Rows[16][1].ToString();
            txt2ACU2po.Text = ds1.Tables[0].Rows[17][1].ToString();
            txt2ACU2rf.Text = ds1.Tables[0].Rows[18][1].ToString();
            txt2DC1at.Text = ds1.Tables[0].Rows[23][1].ToString();
            txt2DC1fr.Text = ds1.Tables[0].Rows[24][1].ToString();
            txt2DC2at.Text = ds1.Tables[0].Rows[19][1].ToString();
            txt2DC2fr.Text = ds1.Tables[0].Rows[20][1].ToString();
            txt2DC3at.Text = ds1.Tables[0].Rows[21][1].ToString();
            txt2DC3fr.Text = ds1.Tables[0].Rows[22][1].ToString();
            txt2DTR1c.Text = ds1.Tables[0].Rows[25][1].ToString();
            txt2DTR1dac.Text = ds1.Tables[0].Rows[26][1].ToString();
            txt2DTR1fr.Text = ds1.Tables[0].Rows[27][1].ToString();
            txt2DTR1tx.Text = ds1.Tables[0].Rows[28][1].ToString();
            txt2PM1lv.Text = ds1.Tables[0].Rows[29][1].ToString();
            txt2SOU1ad.Text = ds1.Tables[0].Rows[30][1].ToString();
            txt2SOU1at.Text = ds1.Tables[0].Rows[31][1].ToString();
            txt2SOU1co.Text = ds1.Tables[0].Rows[32][1].ToString();
            txt2SOU1fr.Text = ds1.Tables[0].Rows[33][1].ToString();
            txt2SOU1pr.Text = ds1.Tables[0].Rows[34][1].ToString();
            txt3KPA1at.Text = ds1.Tables[0].Rows[35][1].ToString();
            txt3KPA1bc.Text = ds1.Tables[0].Rows[37][1].ToString();
            txt3KPA1boc.Text = ds1.Tables[0].Rows[36][1].ToString();
            txt3KPA1bv.Text = ds1.Tables[0].Rows[38][1].ToString();
            txt3KPA1ct.Text = ds1.Tables[0].Rows[39][1].ToString();
            txt3KPA1hv.Text = ds1.Tables[0].Rows[40][1].ToString();
            txt3KPA1kc.Text = ds1.Tables[0].Rows[41][1].ToString();
            txt3KPA1ot.Text = ds1.Tables[0].Rows[42][1].ToString();
            txt3KPA1rf.Text = ds1.Tables[0].Rows[43][1].ToString();
            txt3KPA1rrf.Text = ds1.Tables[0].Rows[44][1].ToString();
            txt4KPA1at.Text = ds1.Tables[0].Rows[45][1].ToString();
            txt4KPA1bc.Text = ds1.Tables[0].Rows[47][1].ToString();
            txt4KPA1boc.Text = ds1.Tables[0].Rows[46][1].ToString();
            txt4KPA1bv.Text = ds1.Tables[0].Rows[48][1].ToString();
            txt4KPA1ct.Text = ds1.Tables[0].Rows[49][1].ToString();
            txt4KPA1hv.Text = ds1.Tables[0].Rows[50][1].ToString();
            txt4KPA1kc.Text = ds1.Tables[0].Rows[51][1].ToString();
            txt4KPA1ot.Text = ds1.Tables[0].Rows[52][1].ToString();
            txt4KPA1rf.Text = ds1.Tables[0].Rows[53][1].ToString();
            txt4KPA1rrf.Text = ds1.Tables[0].Rows[54][1].ToString();
            txt4KPA2at.Text = ds1.Tables[0].Rows[55][1].ToString();
            txt4KPA2hc.Text = ds1.Tables[0].Rows[56][1].ToString();
            txt4KPA2hv.Text = ds1.Tables[0].Rows[57][1].ToString();
            txt4KPA2rf.Text = ds1.Tables[0].Rows[58][1].ToString();
            txt4KPA2rrf.Text = ds1.Tables[0].Rows[59][1].ToString();

        }
    }
}