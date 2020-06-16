using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat
{
    public partial class dashboard2 : System.Web.UI.Page
    {
        SqlDataAdapter dashift, da1, da5, da6, da7, da8, dabjm;
        DataSet dsshift = new DataSet();
        DataSet dspekerjaan = new DataSet();
        string query, iduser, tanggal, style1, style, style3, agenda, databulan, databulan2, pilihicon, icon1, queryaddev, queryev, IDdata, semester, tahun;

        int output, output1, output2, output3, output4, j;
        string bwilayah, bruangan, brak, queryhistory, queryfungsi, querylain, enddate, datadeskripsi, stylebg, deskripsi, judul, datajudul, user, triwulan;
        StringBuilder htmlTableShift = new StringBuilder();
        StringBuilder htmlDeadline = new StringBuilder();
        StringBuilder htmlNow = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            if (Session["previllage"].ToString() == "adminme" || Session["previllage"].ToString() == "super")
                ashiftme.Visible = true;

            lblProfile1.Text = Session["nama1"].ToString();

            user = Session["username"].ToString();
            if (!IsPostBack)
            {
                sqlCon.Open();
                SqlDataAdapter sqlCmd = new SqlDataAdapter("ProViewByUser", sqlCon);
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd.SelectCommand.Parameters.AddWithValue("@user", user);
                DataTable dtbl1 = new DataTable();
                sqlCmd.Fill(dtbl1);
                dtContact.DataSource = dtbl1;
                dtContact.DataBind();
                sqlCon.Close();
            }
            tableshift();
            lblwaktu1.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", new System.Globalization.CultureInfo("id-ID"));
            string tanggal5 = DateTime.Now.ToString("yyyy/MM/dd");
            queryev = $"SELECT  tanggal, event, jam, lokasi, penyelenggara, icon, ID_Event, statususer FROM Event WHERE TANGGAL >= '{tanggal5}' order by ID_Event desc";
            sqlCon.Open();
            SqlDataAdapter sqlCmd4 = new SqlDataAdapter(queryev, sqlCon);
            DataTable dtbl4 = new DataTable();
            sqlCmd4.Fill(dtbl4);
            dtEvent.DataSource = dtbl4;
            dtEvent.DataBind();
            sqlCon.Close();

            ahkbulan.Attributes["href"] = "../maintenancehk/bulanan/dashboard.aspx";
            ahksemester.Attributes["href"] = "../maintenancehk/semester/dashboard.aspx";
            ahktahunan.Attributes["href"] = "../maintenancehk/tahunan/dashboard.aspx";
            ahktriwulan.Attributes["href"] = "../maintenancehk/tigabulan/dashboard.aspx";
            amebulan.Attributes["href"] = "../checklistme/month/dashboard.aspx";
            ameminggu.Attributes["href"] = "../checklistme/week/isidata.aspx";
            amesemester.Attributes["href"] = "../checklistme/semester/isidata.aspx";
            ametahunan.Attributes["href"] = "../checklistme/year/isidata.aspx";

            string queryuser;

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            queryuser = $"select approval from Profile where user_name='{Session["username"].ToString()}'";
            SqlCommand cmd2 = new SqlCommand(queryuser, sqlCon);
            sqlCon.Open();
            da = new SqlDataAdapter(cmd2);
            da.Fill(ds);
            sqlCon.Close();

            if (ds.Tables[0].Rows[0]["approval"].ToString() == "" || ds.Tables[0].Rows[0]["approval"].ToString() == null)
                licheck.Visible = false;

            logbookonprogress();
            logdeadline();
            lognow();
            checklist();
            ticket();
            maintenance();
            approve();
        }

        void approve()
        {
            SqlDataAdapter da;
            sqlCon.Open();              //Harkat Banjarmasin
            string query = $@"with cte as (select (CAST(d.tanggal AS DATE)) as tanggal, p.nama from checkhk_data d left join Profile p on d.id_profile = p.id_profile
						join checkhk_parameter r on r.id_parameter=d.id_parameter where d.approval is null or d.approval = '' 
						group by CAST(d.tanggal AS DATE), nama),

                                    cte2 as (select d.tanggal, p.nama, d.waktu from checkme_data d inner join Profile p on d.id_profile = p.id_profile
						                                    where approve is null or approve = ''
                                                            group by tanggal, nama, d.waktu)

                                    SELECT (select COUNT(*) from cte) [HK], (select COUNT(*) from cte2) [ME]";
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                double harkat = Convert.ToInt32(ds.Tables[0].Rows[0]["HK"]);
                double me = Convert.ToInt32(ds.Tables[0].Rows[0]["ME"]);
                double total = harkat + me;
                spcheck.InnerText = total.ToString();
            }
        }

        void maintenance()
        {
            string angkaminggu, thisday;
            int angkabulan;
            double hasilhkbulan, hasilhktriwulan, hasilhksemester, hasilhktahunan, hasilmemingguan, hasilmebulanan, hasilmesemester, hasilmetahunan;
            SqlDataAdapter dahk, dadata;

            sqlCon.Open();
            string queryhk = @"SELECT (SELECT COUNT(*) from mainhk_3m_parameter) as triwulan,
                            (SELECT COUNT(*) FROM mainhk_bbu_parameter) AS bbu,
                            (SELECT COUNT(*) FROM checkhk_bulan_perangkat) AS bulanan,
		                    (SELECT COUNT(*) FROM maintenancehk_parameter r join 
			                    maintenancehk_perangkat t on t.id_perangkat=r.id_perangkat where t.jenis='SEMESTER' ) AS semester,
		                    (SELECT COUNT(*) FROM maintenancehk_parameter r join 
			                    maintenancehk_perangkat t on t.id_perangkat=r.id_perangkat where t.jenis='TAHUNAN' ) AS tahunan,
                            (SELECT COUNT(*) from checkme_parameterwmy where kategori = 'week') as minggume,
                            (SELECT COUNT(*) from checkme_parameterwmy where kategori = 'month') as bulananme,
		                    (SELECT COUNT(*) from checkme_parameterwmy where kategori = 'semester') as semesterme,
		                    (SELECT COUNT(*) from checkme_parameterwmy where kategori = 'year') as tahunanme";
            DataSet dshk = new DataSet();
            SqlCommand cmdhk = new SqlCommand(queryhk, sqlCon);
            dahk = new SqlDataAdapter(cmdhk);
            dahk.Fill(dshk);
            sqlCon.Close();
            int hksemester = Convert.ToInt32(dshk.Tables[0].Rows[0]["semester"]);
            int hktriwulan = Convert.ToInt32(dshk.Tables[0].Rows[0]["triwulan"]);
            int hkbbu = Convert.ToInt32(dshk.Tables[0].Rows[0]["bbu"]);
            int hkbulanan = Convert.ToInt32(dshk.Tables[0].Rows[0]["bulanan"]);
            int hktahunan = Convert.ToInt32(dshk.Tables[0].Rows[0]["tahunan"]);
            int mesemester = Convert.ToInt32(dshk.Tables[0].Rows[0]["semesterme"]);
            int meminggu = Convert.ToInt32(dshk.Tables[0].Rows[0]["minggume"]);
            int mebulanan = Convert.ToInt32(dshk.Tables[0].Rows[0]["bulananme"]);
            int metahunan = Convert.ToInt32(dshk.Tables[0].Rows[0]["tahunanme"]);

            DateTime now = DateTime.Now;
            DateTime first = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime second = new DateTime(DateTime.Now.Year, 3, 30);
            DateTime third = new DateTime(DateTime.Now.Year, 4, 1);
            DateTime fourth = new DateTime(DateTime.Now.Year, 6, 30);
            DateTime fifth = new DateTime(DateTime.Now.Year, 7, 1);
            DateTime sixth = new DateTime(DateTime.Now.Year, 9, 30);
            DateTime seventh = new DateTime(DateTime.Now.Year, 10, 1);
            DateTime eighth = new DateTime(DateTime.Now.Year, 12, 30);
            DateTime startdate = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime middate = new DateTime(DateTime.Now.Year, 6, 30);
            DateTime enddate = new DateTime(DateTime.Now.Year, 12, 30);
            tahun = DateTime.Now.Year.ToString();

            if (now > startdate && now <= middate)
            {
                lblsemester.Text += " [1]";
                lblsemesterme.Text += " [1]";
                semester = "semester 1";
            }
            else if (now > middate && now <= enddate)
            {
                lblsemester.Text += " [2]";
                lblsemesterme.Text += " [2]";
                semester = "semester 2";
            }

            lbltahunn.Text += " [" + tahun + "]";
            lbltahunanme.Text += " [" + tahun + "]";

            //double hari = Convert.ToInt32(DateTime.Now.DayOfYear.ToString());
            DateTime dta = new DateTime(2020, 1, 1);
            while (dta.DayOfWeek != DayOfWeek.Monday)
            {
                dta = dta.AddDays(1);
            }

            //Response.Write("  mli " + (Convert.ToInt32(DateTime.Now.DayOfYear) - (Convert.ToInt32(dta.ToString("dd")))));
            double hari = Convert.ToInt32(DateTime.Now.DayOfYear) - Convert.ToInt32(dta.ToString("dd"));

            double minggu = (double)Math.Ceiling(hari / 7);
            //Response.Write(minggu);
            lblminggume.Text += " [" + minggu + "]";

            if (now > first && now <= second)
            {
                lbltriwulan.Text += " [1]";
                triwulan = "triwulan 1";
            }
            else if (now > third && now <= fourth)
            {
                lbltriwulan.Text += " [2]";
                triwulan = "triwulan 2";
            }
            else if (now > fifth && now <= sixth)
            {
                lbltriwulan.Text += " [3]";
                triwulan = "triwulan 3";
            }
            else if (now > seventh && now <= eighth)
            {
                lbltriwulan.Text += " [4]";
                triwulan = "triwulan 4";
            }
            string[] bulan = { "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "Nopember", "Desember" };
            angkabulan = DateTime.Now.Month;
            lblbulanhk.Text += " [" + bulan[angkabulan - 1] + "]";
            lblbulananme.Text += " [" + bulan[angkabulan - 1] + "]";

            //lblbulanhk.Text += " [" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month) + "]";
            //lblbulananme.Text += " [" + CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month) + "]";

            string querydata = $@"SELECT (SELECT COUNT(*) from mainhk_3m_data where triwulan = '{triwulan}' and tahun = '{tahun}') as triwulan,
		                        (SELECT COUNT(*) FROM mainhk_bbu_data where triwulan = '{triwulan}' and tahun = '{tahun}') AS bbu,
		                        (SELECT COUNT(*) FROM checkhk_bulan_data where angkabulan = '{angkabulan}' and data not like 'un' and tahun = '{tahun}') AS bulanan,
		                        (SELECT COUNT(*) FROM maintenancehk_data where kategori = 'semester' and semester = '{semester}' and tahun = '{tahun}') AS semester,
		                        (SELECT COUNT(*) FROM maintenancehk_data where kategori = 'tahunan' and tahun = '{tahun}') AS tahunan,
								(SELECT COUNT(*) FROM checkme_datawmy where jenis = 'week' and week = '{minggu}' and tahun = '{tahun}' and nilai != '') AS me_week,
								(SELECT COUNT(*) FROM checkme_datawmy where jenis = 'month' and numbermonth = '{angkabulan}' and tahun = '{tahun}' and nilai != '') AS me_month,
								(SELECT COUNT(*) FROM checkme_datawmy where jenis = 'semester' and semester = '{semester}' and tahun = '{tahun}' and nilai not like '%' + 'no' + '%') AS me_semester,
								(SELECT COUNT(*) FROM checkme_datawmy where jenis = 'year' and tahun = '{tahun}' and nilai != '') AS me_year";
            DataSet dsdata = new DataSet();
            SqlCommand cmddata = new SqlCommand(querydata, sqlCon);
            dadata = new SqlDataAdapter(cmddata);
            dadata.Fill(dsdata);
            sqlCon.Close();
            int datahksemester = Convert.ToInt32(dsdata.Tables[0].Rows[0]["semester"]);
            int datahktriwulan = Convert.ToInt32(dsdata.Tables[0].Rows[0]["triwulan"]);
            int datahkbbu = Convert.ToInt32(dsdata.Tables[0].Rows[0]["bbu"]);
            int datahkbulanan = Convert.ToInt32(dsdata.Tables[0].Rows[0]["bulanan"]);
            int datahktahunan = Convert.ToInt32(dsdata.Tables[0].Rows[0]["tahunan"]);
            int datametahunan = Convert.ToInt32(dsdata.Tables[0].Rows[0]["me_year"]);
            int datamesemester = Convert.ToInt32(dsdata.Tables[0].Rows[0]["me_semester"]);
            int datamebulanan = Convert.ToInt32(dsdata.Tables[0].Rows[0]["me_month"]);
            int datamemingguan = Convert.ToInt32(dsdata.Tables[0].Rows[0]["me_week"]);

            hasilhkbulan = ((double)datahkbulanan / hkbulanan) * 100;
            hasilhktriwulan = ((double)datahktriwulan / hktriwulan) * 100;
            hasilhksemester = ((double)datahksemester / hksemester) * 100;
            hasilhktahunan = ((double)datahktahunan / hktahunan) * 100;
            hasilmebulanan = ((double)datamebulanan / mebulanan) * 100;
            hasilmesemester = ((double)datamesemester / mesemester) * 100;
            hasilmemingguan = ((double)datamemingguan / meminggu) * 100;
            hasilmetahunan = ((double)datametahunan / metahunan) * 100;

            divhkbulanan.Style.Add("width", $"{Math.Round(hasilhkbulan)}%");
            divhktriwulan.Style.Add("width", $"{Math.Round(hasilhktriwulan)}%");
            divhksemester.Style.Add("width", $"{Math.Round(hasilhksemester)}%");
            divhktahunan.Style.Add("width", $"{Math.Round(hasilhktahunan)}%");
            divmebulanan.Style.Add("width", $"{Math.Round(hasilmebulanan)}%");
            divmeminggu.Style.Add("width", $"{Math.Round(hasilmemingguan)}%");
            divmesemester.Style.Add("width", $"{Math.Round(hasilmesemester)}%");
            divmetahunan.Style.Add("width", $"{Math.Round(hasilmetahunan)}%");

            lblhkbulan.Text = Math.Round(hasilhkbulan) + "%";
            lblhktriwulan.Text = Math.Round(hasilhktriwulan) + "%";
            lblhksemester.Text = Math.Round(hasilhksemester) + "%";
            lblhktahunan.Text = Math.Round(hasilhktahunan) + "%";
            lblmebulanan.Text = Math.Round(hasilmebulanan) + "%";
            lblmemingguan.Text = Math.Round(hasilmemingguan) + "%";
            lblmesemester.Text = Math.Round(hasilmesemester) + "%";
            lblmetahunan.Text = Math.Round(hasilmetahunan) + "%";

            if (Math.Round(hasilhkbulan) > 0)
                ihkbulan.Attributes.Add("class", "fa fa-hourglass-half");
            else if (Math.Round(hasilhkbulan) == 0)
                ihkbulan.Attributes.Add("class", "fa fa-minus-square");
            else if (Math.Round(hasilhkbulan) == 100)
                ihkbulan.Attributes.Add("class", "fa fa-check-circle");
            else
                ihkbulan.Attributes.Add("class", "fa fa-warning");

            if (Math.Round(hasilhktriwulan) > 0)
                ihktriwulan.Attributes.Add("class", "fa fa-hourglass-half");
            else if (Math.Round(hasilhktriwulan) == 0)
                ihktriwulan.Attributes.Add("class", "fa fa-minus-square");
            else if (Math.Round(hasilhktriwulan) == 100)
                ihktriwulan.Attributes.Add("class", "fa fa-check-circle");
            else
                ihktriwulan.Attributes.Add("class", "fa fa-warning");

            if (Math.Round(hasilhksemester) > 0)
                ihksemester.Attributes.Add("class", "fa fa-hourglass-half");
            else if (Math.Round(hasilhksemester) == 0)
                ihksemester.Attributes.Add("class", "fa fa-minus-square");
            else if (Math.Round(hasilhksemester) == 100)
                ihksemester.Attributes.Add("class", "fa fa-check-circle");
            else
                ihksemester.Attributes.Add("class", "fa fa-warning");

            if (Math.Round(hasilhktahunan) > 0)
                ihktahunan.Attributes.Add("class", "fa fa-hourglass-half");
            else if (Math.Round(hasilhktahunan) == 0)
                ihktahunan.Attributes.Add("class", "fa fa-minus-square");
            else if (Math.Round(hasilhktahunan) == 100)
                ihktahunan.Attributes.Add("class", "fa fa-check-circle");
            else
                ihktahunan.Attributes.Add("class", "fa fa-warning");


            if (Math.Round(hasilmebulanan) > 0)
                imebulan.Attributes.Add("class", "fa fa-hourglass-half");
            else if (Math.Round(hasilmebulanan) == 0)
                imebulan.Attributes.Add("class", "fa fa-minus-square");
            else if (Math.Round(hasilmebulanan) == 100)
                imebulan.Attributes.Add("class", "fa fa-check-circle");
            else
                imebulan.Attributes.Add("class", "fa fa-warning");

            if (Math.Round(hasilmemingguan) > 0)
                imeminggu.Attributes.Add("class", "fa fa-hourglass-half");
            else if (Math.Round(hasilmemingguan) == 0)
                imeminggu.Attributes.Add("class", "fa fa-minus-square");
            else if (Math.Round(hasilmemingguan) == 100)
                imeminggu.Attributes.Add("class", "fa fa-check-circle");
            else
                imeminggu.Attributes.Add("class", "fa fa-warning");

            if (Math.Round(hasilmesemester) > 0)
                imesemester.Attributes.Add("class", "fa fa-hourglass-half");
            else if (Math.Round(hasilmesemester) == 0)
                imesemester.Attributes.Add("class", "fa fa-minus-square");
            else if (Math.Round(hasilmesemester) == 100)
                imesemester.Attributes.Add("class", "fa fa-check-circle");
            else
                imesemester.Attributes.Add("class", "fa fa-warning");

            if (Math.Round(hasilmetahunan) > 0)
                imetahun.Attributes.Add("class", "fa fa-hourglass-half");
            else if (Math.Round(hasilmetahunan) == 0)
                imetahun.Attributes.Add("class", "fa fa-minus-square");
            else if (Math.Round(hasilmetahunan) == 100)
                imetahun.Attributes.Add("class", "fa fa-check-circle");
            else
                imetahun.Attributes.Add("class", "fa fa-warning");

            string MonthSemester = DateTime.Now.Month.ToString();

            thisday = DateTime.Now.DayOfWeek.ToString();

            DateTime firstOfNextMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1);
            DateTime StartDateMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 25);
            DateTime lastOfThisMonth = firstOfNextMonth.AddDays(-1);

            if ((thisday == "Friday" || thisday == "Saturday" || thisday == "Sunday") && Math.Round(hasilmemingguan) < 100)
                imeminggu.Attributes.Add("class", "fa fa-warning");

            TimeSpan ts = lastOfThisMonth - now;
            if ((ts.Days <= 7) && Math.Round(hasilmebulanan) < 100)
                imebulan.Attributes.Add("class", "fa fa-warning");

            if ((ts.Days <= 7) && Math.Round(hasilhkbulan) < 100)
                ihkbulan.Attributes.Add("class", "fa fa-warning");

            if (MonthSemester == "3" || MonthSemester == "6" || MonthSemester == "9" || MonthSemester == "12")
            {
                if ((ts.Days <= 15) && Math.Round(hasilhktriwulan) < 100)
                    ihktriwulan.Attributes.Add("class", "fa fa-warning");
            }

            if (MonthSemester == "6" || MonthSemester == "12")
            {
                if ((ts.Days <= 25) && Math.Round(hasilhksemester) < 100)
                    ihksemester.Attributes.Add("class", "fa fa-warning");
                if ((ts.Days <= 25) && Math.Round(hasilmesemester) < 100)
                    imesemester.Attributes.Add("class", "fa fa-warning");
            }

            if (MonthSemester == "12")
            {
                if (Math.Round(hasilmetahunan) < 100)
                    imesemester.Attributes.Add("class", "fa fa-warning");

                if (Math.Round(hasilhktahunan) < 100)
                    ihktahunan.Attributes.Add("class", "fa fa-warning");
            }
        }
        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }

        void logbookonprogress()
        {
            string thistime, tahun;
            int tahunint;

            tahun = DateTime.Now.Year.ToString();
            tahunint = Convert.ToInt32(tahun);
            thistime = DateTime.Now.ToString("yyyy/MM/dd");
            string myquery = $@"select(select count(*) from tabel_logbook where STATUS='On Progress')[On_Progress],
		                        (select count(*) from tabel_logbook where STATUS='On Progress' and due_date < '{thistime}')[Overdue],
		                        (select count(*) from tabel_logbook where STATUS='On Progress' and due_date >= '{thistime}')[On_Target]";
            SqlCommand cmd = new SqlCommand(myquery, sqlCon);
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtonprogress.Text = ds.Tables[0].Rows[0]["On_Target"].ToString();
                txtoverdue.Text = ds.Tables[0].Rows[0]["Overdue"].ToString();
            }

            string[] bulan = { "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "Nopember", "Desember" };
            string[] angkabulan = new string[4];
            string[] abulan = new string[4];
            string[] angkabulan2 = new string[12];
            string[] abulan2 = new string[12];

            for (int i = -3; i < 1; i++)
            {
                angkabulan[j] = DateTime.Now.AddMonths(i).Month.ToString();
                abulan[j] = bulan[Convert.ToInt32(angkabulan[j]) - 1];
                j++;
            }

            for (int i = 0; i < 12; i++)
            {
                abulan2[i] = bulan[i];
            }

            databulan = string.Join(",", abulan);
            databulan2 = string.Join(",", abulan2);

            string querylog = $@"select(select count(*) from tabel_logbook where waktu_action >= '{tahun}-{angkabulan[0]}-01' and waktu_action <= '{tahun}-{angkabulan[0]}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(angkabulan[0]))}') [satu],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{angkabulan[1]}-01' and waktu_action <= '{tahun}-{angkabulan[1]}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(angkabulan[1]))}') [dua],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{angkabulan[2]}-01' and waktu_action <= '{tahun}-{angkabulan[2]}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(angkabulan[2]))}') [tiga],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{angkabulan[3]}-01' and waktu_action <= '{tahun}-{angkabulan[3]}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(angkabulan[3]))}') [empat],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{angkabulan[0]}-01' and waktu_action <= '{tahun}-{angkabulan[0]}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(angkabulan[0]))}' and status='On Progress') [opsatu],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{angkabulan[1]}-01' and waktu_action <= '{tahun}-{angkabulan[1]}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(angkabulan[1]))}' and status='On Progress') [opdua],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{angkabulan[2]}-01' and waktu_action <= '{tahun}-{angkabulan[2]}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(angkabulan[2]))}' and status='On Progress') [optiga],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{angkabulan[3]}-01' and waktu_action <= '{tahun}-{angkabulan[3]}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(angkabulan[3]))}' and status='On Progress') [opempat]";
            SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
            SqlDataAdapter dalog;
            DataSet dslog = new DataSet();
            dalog = new SqlDataAdapter(cmdlog);
            dalog.Fill(dslog);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (dslog.Tables[0].Rows.Count > 0)
            {
                hdlog.Value = $@"{dslog.Tables[0].Rows[0]["satu"].ToString()},{dslog.Tables[0].Rows[0]["dua"].ToString()},
                                {dslog.Tables[0].Rows[0]["tiga"].ToString()},{dslog.Tables[0].Rows[0]["empat"].ToString()}";

                hdonprogress.Value = $@"{dslog.Tables[0].Rows[0]["opsatu"].ToString()},{dslog.Tables[0].Rows[0]["opdua"].ToString()},
                                {dslog.Tables[0].Rows[0]["optiga"].ToString()},{dslog.Tables[0].Rows[0]["opempat"].ToString()}";

                hdmonth.Value = databulan;
            }

            string querylogyear = $@"select(select count(*) from tabel_logbook where waktu_action >= '{tahun}-{1}-01' and waktu_action <= '{tahun}-{1}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(1))}') [satu],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{2}-01' and waktu_action <= '{tahun}-{2}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(2))}') [dua],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{3}-01' and waktu_action <= '{tahun}-{3}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(3))}') [tiga],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{4}-01' and waktu_action <= '{tahun}-{4}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(4))}') [empat],
                        (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{5}-01' and waktu_action <= '{tahun}-{5}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(5))}') [lima],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{6}-01' and waktu_action <= '{tahun}-{6}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(6))}') [enam],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{7}-01' and waktu_action <= '{tahun}-{7}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(7))}') [tujuh],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{8}-01' and waktu_action <= '{tahun}-{8}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(8))}') [delapan],
                        (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{9}-01' and waktu_action <= '{tahun}-{9}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(9))}') [sembilan],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{10}-01' and waktu_action <= '{tahun}-{10}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(10))}') [sepuluh],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{11}-01' and waktu_action <= '{tahun}-{11}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(11))}') [sebelas],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{12}-01' and waktu_action <= '{tahun}-{12}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(12))}') [duabelas],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{1}-01' and waktu_action <= '{tahun}-{1}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(1))}' and status='On Progress') [opsatu],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{2}-01' and waktu_action <= '{tahun}-{2}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(2))}' and status='On Progress') [opdua],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{3}-01' and waktu_action <= '{tahun}-{3}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(3))}' and status='On Progress') [optiga],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{4}-01' and waktu_action <= '{tahun}-{4}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(4))}' and status='On Progress') [opempat],
                        (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{5}-01' and waktu_action <= '{tahun}-{5}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(5))}' and status='On Progress') [oplima],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{6}-01' and waktu_action <= '{tahun}-{6}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(6))}' and status='On Progress') [openam],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{7}-01' and waktu_action <= '{tahun}-{7}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(7))}' and status='On Progress') [optujuh],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{8}-01' and waktu_action <= '{tahun}-{8}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(8))}' and status='On Progress') [opdelapan],
                        (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{9}-01' and waktu_action <= '{tahun}-{9}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(9))}' and status='On Progress') [opsembilan],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{10}-01' and waktu_action <= '{tahun}-{10}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(10))}' and status='On Progress') [opsepuluh],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{11}-01' and waktu_action <= '{tahun}-{11}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(11))}' and status='On Progress') [opsebelas],
		                (select count(*) from tabel_logbook where waktu_action >= '{tahun}-{12}-01' and waktu_action <= '{tahun}-{12}-{DateTime.DaysInMonth(tahunint, Convert.ToInt32(12))}' and status='On Progress') [opduabelas]";
            SqlCommand cmdlogyear = new SqlCommand(querylogyear, sqlCon);
            SqlDataAdapter dalogyear;
            DataSet dslogyear = new DataSet();
            dalogyear = new SqlDataAdapter(cmdlogyear);
            dalogyear.Fill(dslogyear);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (dslogyear.Tables[0].Rows.Count > 0)
            {
                hdlogyear.Value = $@"{dslogyear.Tables[0].Rows[0]["satu"].ToString()},{dslogyear.Tables[0].Rows[0]["dua"].ToString()},
                                {dslogyear.Tables[0].Rows[0]["tiga"].ToString()},{dslogyear.Tables[0].Rows[0]["empat"].ToString()},
                                {dslogyear.Tables[0].Rows[0]["lima"].ToString()},{dslogyear.Tables[0].Rows[0]["enam"].ToString()},
                                {dslogyear.Tables[0].Rows[0]["tujuh"].ToString()},{dslogyear.Tables[0].Rows[0]["delapan"].ToString()},
                                {dslogyear.Tables[0].Rows[0]["sembilan"].ToString()},{dslogyear.Tables[0].Rows[0]["sepuluh"].ToString()},
                                {dslogyear.Tables[0].Rows[0]["sebelas"].ToString()},{dslogyear.Tables[0].Rows[0]["duabelas"].ToString()}";

                hdonprogressyear.Value = $@"{dslogyear.Tables[0].Rows[0]["opsatu"].ToString()},{dslogyear.Tables[0].Rows[0]["opdua"].ToString()},
                                {dslogyear.Tables[0].Rows[0]["optiga"].ToString()},{dslogyear.Tables[0].Rows[0]["opempat"].ToString()},
                                {dslogyear.Tables[0].Rows[0]["oplima"].ToString()},{dslogyear.Tables[0].Rows[0]["openam"].ToString()},
                                {dslogyear.Tables[0].Rows[0]["optujuh"].ToString()},{dslogyear.Tables[0].Rows[0]["opdelapan"].ToString()},
                                {dslogyear.Tables[0].Rows[0]["opsembilan"].ToString()},{dslogyear.Tables[0].Rows[0]["opsepuluh"].ToString()},
                                {dslogyear.Tables[0].Rows[0]["opsebelas"].ToString()},{dslogyear.Tables[0].Rows[0]["opduabelas"].ToString()}";

                hdmonthyear.Value = databulan2;
            }
        }

        void lognow()
        {
            string mytanggal = DateTime.Now.ToString("yyyy/MM/dd");
            DateTime sekarang = DateTime.Now;
            string myquery = $"select * from tabel_logbook where tanggal = '{mytanggal}'";

            sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(myquery, sqlCon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlCon.Close();

            htmlNow.Append("<table id=\"example2\" width=\"100%\" class=\"table table5\">");
            htmlNow.Append("<thead>");
            htmlNow.Append("<tr><th>Unit</th><th>Tipe</th><th>Judul</th><th>Action</th>");
            htmlNow.Append("</thead>");
            htmlNow.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblEvent.Visible = false;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        judul = ds.Tables[0].Rows[i]["judul_logbook"].ToString();

                        if (judul.Length >= 40)
                        {
                            datajudul = judul.Substring(0, 30) + ".....";
                        }
                        else
                        {
                            datajudul = judul;
                        }

                        stylebg = "font-size:12px; font-weight:normal";
                        IDdata = ds.Tables[0].Rows[i]["id_logbook"].ToString();
                        htmlNow.Append("<td>" + $"<label style=\"{stylebg}\">" + ds.Tables[0].Rows[i]["unit"].ToString() + "</label>" + "</td>");
                        htmlNow.Append("<td>" + $"<label style=\"{stylebg}\">" + ds.Tables[0].Rows[i]["tipe_logbook"].ToString() + "</label>" + "</td>");
                        htmlNow.Append("<td>" + $"<label style=\"{stylebg}\">" + datajudul + "</label>" + "</td>");
                        htmlNow.Append("<td>" + $"<label style=\"{stylebg}\">" + $"<a href=\"../datalogbook/detail.aspx?idlog={IDdata}\" style=\"margin-right:10px\">" + "View" + "</a>" + "</td>");

                        htmlNow.Append("</tr>");
                    }
                    htmlNow.Append("</tbody>");
                    htmlNow.Append("</table>");
                    PlaceholderNow.Controls.Add(new Literal { Text = htmlNow.ToString() });
                }
            }
        }

        void ticket()
        {
            string myquery = @"select SUM(CASE WHEN status = 'reject' THEN 1 ELSE 0 END) as reject, SUM(CASE WHEN status = 'sent' THEN 1 ELSE 0 END) as sent, 
                            SUM(CASE WHEN status = 'accept' THEN 1 ELSE 0 END) as accept, SUM(CASE WHEN status = 'confirm' THEN 1 ELSE 0 END) as confirm,
                            SUM(CASE WHEN status = 'complete' THEN 1 ELSE 0 END) as complete from ticket_user";
            SqlCommand cmd = new SqlCommand(myquery, sqlCon);
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtpie.Text = "ada";
                txtreject.Text = ds.Tables[0].Rows[0]["reject"].ToString();
                txtconfirm.Text = ds.Tables[0].Rows[0]["confirm"].ToString();
                txtcomplete.Text = ds.Tables[0].Rows[0]["complete"].ToString();
                txtaccept.Text = ds.Tables[0].Rows[0]["accept"].ToString();
                txtsent.Text = ds.Tables[0].Rows[0]["sent"].ToString();
            }
            else
            {
                txtpie.Text = "";
            }
        }

        void logdeadline()
        {
            string mytanggal = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            DateTime sekarang = DateTime.Now;
            string myquery = $"select * from table_pekerjaan where enddate >= '{mytanggal}' and status = 'On Progress'";

            sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(myquery, sqlCon);
            DataSet ds = new DataSet();
            sqlda.Fill(ds);
            sqlCon.Close();

            htmlDeadline.Append("<table id=\"example2\" width=\"100%\" class=\"table table5\">");
            htmlDeadline.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //lblEvent.Visible = false;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        deskripsi = ds.Tables[0].Rows[i]["deskripsi"].ToString();

                        if (deskripsi.Length >= 40)
                        {
                            datadeskripsi = deskripsi.Substring(0, 40) + "....";
                        }
                        else
                        {
                            datadeskripsi = deskripsi;
                        }

                        stylebg = "font-size:12px; font-weight:normal";
                        IDdata = ds.Tables[0].Rows[i]["id_logbook"].ToString();

                        DateTime start = (DateTime)ds.Tables[0].Rows[i]["enddate"];
                        TimeSpan t = start - sekarang;
                        if (t.Days == 1)
                        {
                            enddate = "1 hari";
                            style3 = "label label-warning";
                        }
                        else if (t.Days == 0)
                        {
                            enddate = "0 hari";
                            style3 = "label label-danger";
                        }
                        else if (t.Days <= -1)
                        {
                            enddate = "melebihi";
                            style3 = "label label-danger";
                        }

                        if (t.Days <= 1)
                        {
                            lblEvent.Visible = false;
                            htmlDeadline.Append("<tr>");
                            htmlDeadline.Append("<td>" + $"<label class=\"{style3}\">" + enddate + "</label>" + "</td>");
                            htmlDeadline.Append("<td>" + $"<label style=\"{stylebg}\">" + ds.Tables[0].Rows[i]["jenis_pekerjaan"].ToString() + "</label>" + "</td>");
                            htmlDeadline.Append("<td>" + $"<label style=\"{stylebg}; white-space:pre-line; position:relative\">" + datadeskripsi + "</label>" + "</td>");
                            htmlDeadline.Append("<td>" + $"<label style=\"{stylebg}\">" + $"<a href=\"../datalogbook/detail.aspx?idlog={IDdata}\" style=\"margin-right:10px\">" + "View" + "</a>" + "</td>");
                            htmlDeadline.Append("</tr>");
                        }
                    }
                    htmlDeadline.Append("</tbody>");
                    htmlDeadline.Append("</table>");
                    PlaceHolderDeadline.Controls.Add(new Literal { Text = htmlDeadline.ToString() });
                }
            }
        }

        void checklist()
        {
            SqlDataAdapter counthk, countme, countbjm;
            string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
            string tanggalkumalam = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            DateTime wib = DateTime.UtcNow + new TimeSpan(7, 0, 0);
            string mytanggal = wib.ToString("yyyy/MM/dd");

            sqlCon.Open();
            string srcountme = "select count(*) as total from checkme_parameter";
            DataSet dscountme = new DataSet();
            SqlCommand cmdme = new SqlCommand(srcountme, sqlCon);
            countme = new SqlDataAdapter(cmdme);
            countme.Fill(dscountme);
            sqlCon.Close();
            int totalme = Convert.ToInt32(dscountme.Tables[0].Rows[0]["total"]);

            sqlCon.Open();
            string srcounthk = @"select count(*) as total from checkhk_parameter r join checkhk_perangkat t on t.id_perangkat=r.id_perangkat
                                where t.id_perangkat not like '%' + 'bjm' + '%' ";
            DataSet dscounthk = new DataSet();
            SqlCommand cmdhk = new SqlCommand(srcounthk, sqlCon);
            counthk = new SqlDataAdapter(cmdhk);
            counthk.Fill(dscounthk);
            sqlCon.Close();
            int totalhk = Convert.ToInt32(dscounthk.Tables[0].Rows[0]["total"]);

            sqlCon.Open();
            string srcountbjm = @"select count(*) as total from checkhk_parameter r join checkhk_perangkat t on t.id_perangkat=r.id_perangkat
                                where t.id_perangkat like '%' + 'bjm' + '%' ";
            DataSet dscountbjm = new DataSet();
            SqlCommand cmdbjm = new SqlCommand(srcountbjm, sqlCon);
            countbjm = new SqlDataAdapter(cmdbjm);
            countbjm.Fill(dscountbjm);
            sqlCon.Close();
            int totalbjm = Convert.ToInt32(dscountbjm.Tables[0].Rows[0]["total"]);

            sqlCon.Open();
            string querycheck = $@"select count(*) as total, nama, d.pic, d.approve from checkme_data d join checkme_parameter r on d.id_parameter=r.id_parameter
                        join checkme_perangkat p on p.id_perangkat=r.id_perangkat join Profile pro on pro.id_profile=d.id_profile  where d.tanggal='{tanggalku}' 
                        and d.nilai != '' and d.waktu='siang'
                        group by d.tanggal, nama, d.pic, d.approve";
            DataSet ds5 = new DataSet();
            SqlCommand cmd = new SqlCommand(querycheck, sqlCon);
            da5 = new SqlDataAdapter(cmd);
            da5.Fill(ds5);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            if (ds5.Tables[0].Rows.Count > 0)
                output = Convert.ToInt32(ds5.Tables[0].Rows[0]["total"].ToString());
            double hasil, tampil;
            if (output > 0)
            {
                hasil = ((double)output / totalme) * 100;
                tampil = Math.Round(hasil);
                divsiang.Style.Add("width", $"{tampil}%");
                lblsiangme.Text = $"{tampil}% oleh {ds5.Tables[0].Rows[0]["nama"].ToString()}";
                asiang.Attributes["href"] = $"../checklistme/dashboard.aspx?waktu=siang&tanggal={mytanggal}";
                iappchmesa.Attributes.Add("class", "fa fa-hourglass-half");
                if (ds5.Tables[0].Rows[0]["approve"].ToString() == "approve")
                {
                    iappchmesa.Attributes.Add("class", "fa fa-check-circle-o");
                    lblappchmesa.Text = "by " + ds5.Tables[0].Rows[0]["pic"].ToString();
                }

            }
            else
            {
                asiang.Attributes["href"] = "../checklistme/harian.aspx";
            }


            sqlCon.Open();
            string querycheckpagi = $@"select count(*) as total, nama, d.pic, d.approve from checkme_data d join checkme_parameter r on d.id_parameter=r.id_parameter
                        join checkme_perangkat p on p.id_perangkat=r.id_perangkat join Profile pro on pro.id_profile=d.id_profile 
                        where d.tanggal='{tanggalku}' and d.nilai != '' and d.waktu='pagi'
                        group by d.tanggal, nama, d.pic, d.approve";
            DataSet ds6 = new DataSet();
            SqlCommand cmd1 = new SqlCommand(querycheckpagi, sqlCon);
            da6 = new SqlDataAdapter(cmd1);
            da6.Fill(ds6);
            cmd1.ExecuteNonQuery();
            sqlCon.Close();
            if (ds6.Tables[0].Rows.Count > 0)
                output1 = Convert.ToInt32(ds6.Tables[0].Rows[0]["total"].ToString());
            double hasil1, tampil1;
            if (output1 > 0)
            {
                hasil1 = ((double)output1 / totalme) * 100;
                tampil1 = Math.Round(hasil1);
                divpagi.Style.Add("width", $"{tampil1}%");
                lblpagime.Text = $"{tampil1}% oleh {ds6.Tables[0].Rows[0]["nama"].ToString()}";
                apagi.Attributes["href"] = $"../checklistme/dashboard.aspx?waktu=pagi&tanggal={mytanggal}";
                iappchmepg.Attributes.Add("class", "fa fa-hourglass-half");
                if (ds6.Tables[0].Rows[0]["approve"].ToString() == "approve")
                {
                    iappchmepg.Attributes.Add("class", "fa fa-check-circle-o");
                    lblappchmepg.Text = "by " + ds6.Tables[0].Rows[0]["pic"].ToString();
                }

            }
            else
            {
                apagi.Attributes["href"] = "../checklistme/harian.aspx";
            }

            sqlCon.Open();
            string querycheckmalam = $@"select count(*) as total, nama, d.pic, d.approve from checkme_data d join checkme_parameter r on d.id_parameter=r.id_parameter
                        join checkme_perangkat p on p.id_perangkat=r.id_perangkat join Profile pro on pro.id_profile=d.id_profile 
                        where d.tanggal='{tanggalkumalam}' and d.nilai != '' and d.waktu='malam'
                        group by d.tanggal, nama, d.pic, d.approve";
            DataSet ds7 = new DataSet();
            SqlCommand cmd2 = new SqlCommand(querycheckmalam, sqlCon);
            da7 = new SqlDataAdapter(cmd2);
            da7.Fill(ds7);
            cmd2.ExecuteNonQuery();
            sqlCon.Close();
            if (ds7.Tables[0].Rows.Count > 0)
                output2 = Convert.ToInt32(ds7.Tables[0].Rows[0]["total"].ToString());
            double hasil2, tampil2;
            if (output2 > 0)
            {
                hasil2 = ((double)output2 / totalme) * 100;
                tampil2 = Math.Round(hasil2);
                divmalam.Style.Add("width", $"{tampil2}%");
                lblmalamme.Text = $"{tampil2}% oleh {ds7.Tables[0].Rows[0]["nama"].ToString()}";
                amalam.Attributes["href"] = $"../checklistme/dashboard.aspx?waktu=malam&tanggal={tanggalkumalam}";
                iappchmemlm.Attributes.Add("class", "fa fa-hourglass-half");
                if (ds7.Tables[0].Rows[0]["approve"].ToString() == "approve")
                {
                    iappchmemlm.Attributes.Add("class", "fa fa-check-circle-o");
                    lblappchmemlm.Text = "by " + ds7.Tables[0].Rows[0]["pic"].ToString();
                }

            }
            else
            {
                amalam.Attributes["href"] = "../checklistme/harian.aspx";
            }


            sqlCon.Open();              //Harkat cibinong
            string querycheckhk = $@"select count(*) as total, nama, d.pic, d.approval from checkhk_data d join Profile p on p.id_profile=d.id_profile join checkhk_parameter r
									on r.id_parameter=d.id_parameter
                                    where d.tanggal >= '{tanggalku} 00:00:00' and d.tanggal <= '{tanggalku} 23:59:59'
									and r.id_perangkat not like '%' + 'bjm' + '%' and d.data != ''
                                    group by CAST(d.tanggal as date), nama, d.pic, d.approval";
            DataSet ds8 = new DataSet();
            SqlCommand cmd3 = new SqlCommand(querycheckhk, sqlCon);
            da8 = new SqlDataAdapter(cmd3);
            da8.Fill(ds8);
            cmd3.ExecuteNonQuery();
            sqlCon.Close();
            if (ds8.Tables[0].Rows.Count > 0)
                output3 = Convert.ToInt32(ds8.Tables[0].Rows[0]["total"].ToString());
            double hasil3, tampil3;
            if (output3 > 0)
            {
                hasil3 = ((double)output3 / totalhk) * 100;
                tampil3 = Math.Round(hasil3);
                divhk.Style.Add("width", $"{tampil3}%");
                lblchharkat.Text = $"{tampil3}% oleh {ds8.Tables[0].Rows[0]["nama"].ToString()}";
                aharkat.Attributes["href"] = $"../checkhk/dashboard.aspx?tanggal={tanggalku}";
                iappchhk.Attributes.Add("class", "fa fa-hourglass-half");
                if (ds8.Tables[0].Rows[0]["approval"].ToString() == "approve")
                {
                    iappchhk.Attributes.Add("class", "fa fa-check-circle-o");
                    lblappchhk.Text = "by " + ds8.Tables[0].Rows[0]["pic"].ToString();
                }
            }
            else
            {
                aharkat.Attributes["href"] = $"../checkhk/dashboard.aspx?tanggal={tanggalku}";
            }


            sqlCon.Open();              //Harkat Banjarmasin
            string querycheckbjm = $@"select count(*) as total, nama, d.pic, d.approval from checkhk_data d join Profile p on p.id_profile=d.id_profile join checkhk_parameter r
									on r.id_parameter=d.id_parameter
                                    where d.tanggal >= '{tanggalku} 00:00:00' and d.tanggal <= '{tanggalku} 23:59:59'
									and r.id_perangkat like '%' + 'bjm' + '%' and d.data != ''
                                    group by CAST(d.tanggal as date), nama, d.pic, d.approval";
            DataSet dsbjm = new DataSet();
            SqlCommand cmdbjm2 = new SqlCommand(querycheckbjm, sqlCon);
            dabjm = new SqlDataAdapter(cmdbjm2);
            dabjm.Fill(dsbjm);
            cmdbjm2.ExecuteNonQuery();
            sqlCon.Close();
            if (dsbjm.Tables[0].Rows.Count > 0)
                output4 = Convert.ToInt32(dsbjm.Tables[0].Rows[0]["total"].ToString());
            double hasilbjm, tampilbjm;
            if (output4 > 0)
            {
                hasilbjm = ((double)output4 / totalbjm) * 100;
                tampilbjm = Math.Round(hasilbjm);
                divbjm.Style.Add("width", $"{tampilbjm}%");
                lblbjm.Text = $"{tampilbjm}% oleh {dsbjm.Tables[0].Rows[0]["nama"].ToString()}";
                a1.Attributes["href"] = $"../checkbjm/dashboardbjm.aspx?tanggal={tanggalku}";
                iappchbjm.Attributes.Add("class", "fa fa-hourglass-half");
                if (dsbjm.Tables[0].Rows[0]["approval"].ToString() == "approve")
                {
                    iappchbjm.Attributes.Add("class", "fa fa-check-circle-o");
                    lblappchbjm.Text = "by " + dsbjm.Tables[0].Rows[0]["pic"].ToString();
                }
            }
            else
            {
                a1.Attributes["href"] = $"../checkbjm/dashboardbjm.aspx?tanggal={tanggalku}";
            }
            //Response.Write(output);
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            if (Request.Form["icon"] != null)
            {
                pilihicon = Request.Form["icon"].ToString();
                //Response.Write(pilihicon);
            }

            if (pilihicon == "sport")
                icon1 = "~/img/sport.png";
            else if (pilihicon == "makan")
                icon1 = "~/img/makan.png";
            else if (pilihicon == "rapat")
                icon1 = "~/img/meeting.png";
            else if (pilihicon == "holiday")
                icon1 = "~/img/holiday.jpg";
            else if (pilihicon == "manuver")
                icon1 = "~/img/rocket.png";
            else if (pilihicon == "vendor")
                icon1 = "~/img/vendor.png";

            string indexedit = Session["indexEvent"].ToString();

            int IDEdit = Convert.ToInt32(indexedit);
            sqlCon.Open();
            SqlCommand sqlCmd5 = new SqlCommand("EvUpdate", sqlCon);
            sqlCmd5.CommandType = CommandType.StoredProcedure;
            sqlCmd5.Parameters.AddWithValue("@ID", IDEdit);
            sqlCmd5.Parameters.AddWithValue("@event", txtEven.Text);
            sqlCmd5.Parameters.AddWithValue("@penyelenggara", txtPenyelenggara.Text);
            sqlCmd5.Parameters.AddWithValue("@jam", txttime.Value);
            sqlCmd5.Parameters.AddWithValue("@lokasi", txtLokasi.Text);
            sqlCmd5.Parameters.AddWithValue("@tanggal2", DateTime.ParseExact(txtttl.Value, "dd/MM/yyyy", null));
            sqlCmd5.Parameters.AddWithValue("@icon", icon1);
            sqlCmd5.Parameters.AddWithValue("@statususer", Session["jenis1"].ToString());
            sqlCmd5.ExecuteNonQuery();
            sqlCon.Close();
            Response.Redirect("dashboard2.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string indexedit = Session["indexEvent"].ToString();

            int IDEdit = Convert.ToInt32(indexedit);
            sqlCon.Open();
            SqlCommand sqlCmd5 = new SqlCommand("EvDelete", sqlCon);
            sqlCmd5.CommandType = CommandType.StoredProcedure;
            sqlCmd5.Parameters.AddWithValue("@ID", IDEdit);
            sqlCmd5.ExecuteNonQuery();
            sqlCon.Close();
            Response.Redirect("dashboard2.aspx");
        }


        void tableshift()
        {
            var mulai = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
            var sekarang = DateTime.Now.ToString("yyyy/MM/dd");
            var akhir = DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
            querylain = $@"SELECT m.tanggal_shift, jadwal, STUFF((SELECT ',  ' + p.petugas 
                      FROM shiftme s left join shiftme_petugas p on s.id_petugas = p.id_petugas
					  WHERE m.jadwal = s.jadwal and m.tanggal_shift = s.tanggal_shift
                      FOR XML PATH('')), 1, 1, '') [petugas] FROm shiftme m WHERE tanggal_shift >= '{mulai}' and tanggal_shift <= '{akhir}'
					  group by tanggal_shift, jadwal
                      order by tanggal_shift asc, jadwal asc ";

            SqlCommand cmd = new SqlCommand(querylain, sqlCon);
            dashift = new SqlDataAdapter(cmd);
            dashift.Fill(dsshift);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            style = "font-size:12px; font-weight:normal";

            for (int i = 0; i < dsshift.Tables[0].Rows.Count; i++)
            {
                DateTime datee = (DateTime)dsshift.Tables[0].Rows[i]["tanggal_shift"];
                string mydate = datee.ToString("yyyy/MM/dd");
                string myjadwal = dsshift.Tables[0].Rows[i]["jadwal"].ToString();
                if (mydate == mulai && myjadwal == "Pagi")
                    pagikemaren.InnerHtml = dsshift.Tables[0].Rows[i]["petugas"].ToString();
                else if (mydate == mulai && myjadwal == "Sore")
                    sorekemaren.InnerHtml = dsshift.Tables[0].Rows[i]["petugas"].ToString();
                else if (mydate == sekarang && myjadwal == "Pagi")
                    paginow.InnerHtml = dsshift.Tables[0].Rows[i]["petugas"].ToString();
                else if (mydate == sekarang && myjadwal == "Sore")
                    sorenow.InnerHtml = dsshift.Tables[0].Rows[i]["petugas"].ToString();
                else if (mydate == akhir && myjadwal == "Pagi")
                    pagitomorrow.InnerHtml = dsshift.Tables[0].Rows[i]["petugas"].ToString();
                else if (mydate == akhir && myjadwal == "Sore")
                    soretomorrow.InnerHtml = dsshift.Tables[0].Rows[i]["petugas"].ToString();

                /*if (i==0)
                    pagikemaren.InnerHtml = dsshift.Tables[0].Rows[0]["petugas"].ToString();
                else if(i==1)
                    sorekemaren.InnerHtml = dsshift.Tables[0].Rows[1]["petugas"].ToString();
                else if(i==2)
                    paginow.InnerHtml = dsshift.Tables[0].Rows[2]["petugas"].ToString();
                else if (i == 3)
                    sorenow.InnerHtml = dsshift.Tables[0].Rows[3]["petugas"].ToString();
                else if (i == 4)
                    pagitomorrow.InnerHtml = dsshift.Tables[0].Rows[4]["petugas"].ToString();
                else if (i == 5)
                    soretomorrow.InnerHtml = dsshift.Tables[0].Rows[5]["petugas"].ToString();*/
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                sqlCon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("EvViewByID", sqlCon);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("@IDEvent", index);
                DataTable dtbl8 = new DataTable();
                sqlda.Fill(dtbl8);
                sqlCon.Close();
                string tanggal1 = dtbl8.Rows[0]["tanggal"].ToString();
                string tanggalacara = tanggal1.Remove(10, 9);
                txtEven.Text = dtbl8.Rows[0]["event"].ToString();
                txtPenyelenggara.Text = dtbl8.Rows[0]["penyelenggara"].ToString();
                txtttl.Value = tanggalacara;
                txttime.Value = dtbl8.Rows[0]["jam"].ToString();
                txtLokasi.Text = dtbl8.Rows[0]["lokasi"].ToString();

                btnedit.Visible = true;
                btnhapus.Visible = true;
                btntambah.Visible = false;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalupdate1').modal('show')", true);

                Session["indexEvent"] = index;
                //Label labelEdit = (Label)e.Item.FindControl("lbEdit");
                //labelSunting.Visible = false;
                //labelEdit.Visible = true;
            }
        }

        protected void btntambah_Click(object sender, EventArgs e)
        {
            if (Request.Form["icon"] != null)
            {
                pilihicon = Request.Form["icon"].ToString();
                //Response.Write(pilihicon);
            }

            if (pilihicon == "sport")
                icon1 = "~/img/sport.png";
            else if (pilihicon == "makan")
                icon1 = "~/img/makan.png";
            else if (pilihicon == "rapat")
                icon1 = "~/img/meeting.png";
            else if (pilihicon == "holiday")
                icon1 = "~/img/holiday.jpg";
            else if (pilihicon == "manuver")
                icon1 = "~/img/rocket.png";
            else if (pilihicon == "vendor")
                icon1 = "~/img/vendor.png";

            //string indexedit = Session["indexEvent"].ToString();

            queryaddev = $@"INSERT INTO Event (tanggal, jam, event, lokasi, icon, penyelenggara, statususer) VALUES
                           ('{txtttl.Value}', '{txttime.Value}', '{txtEven.Text}', '{txtLokasi.Text}', '{icon1}', '{txtPenyelenggara.Text}', '{Session["jenis1"].ToString()}')";
            sqlCon.Open();
            SqlCommand sqlCmd5 = new SqlCommand(queryaddev, sqlCon);
            sqlCmd5.ExecuteNonQuery();
            sqlCon.Close();
            Response.Redirect("dashboard2.aspx");
        }

    }
}