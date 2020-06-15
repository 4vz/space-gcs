using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.superadmin
{
    public partial class viewshift : System.Web.UI.Page
    {

        string bulan { get; set; }
        string shelter { get; set; }
        string user;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        int total;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");
            else
                user = Session["nama1"].ToString();

            lblProfile1.Text = user;

            if (Session["previllage"].ToString() == "adminme" || Session["previllage"].ToString() == "super")
            {
               
            }
            else
            {
                btnedit.Visible = false;
            }

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
        }

        protected void gvContact_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int j = 0; j <= total; j++)
                {
                    e.Row.Cells[j].Style.Add("padding-left", "5px");

                    if (e.Row.Cells[j].Text.Equals("1"))
                    {
                        e.Row.Cells[j].BackColor = System.Drawing.Color.LightBlue;
                        e.Row.Cells[j].Text = "P";
                    }
                    else if (e.Row.Cells[j].Text.Equals("2"))
                    {
                        e.Row.Cells[j].BackColor = System.Drawing.Color.Aqua;
                        e.Row.Cells[j].Text = "S";
                    }
                    else if (e.Row.Cells[j].Text.Equals("0"))
                    {
                        e.Row.Cells[j].Text = "";
                    }
                }

                /*if (e.Row.Cells[3].Text.Equals("1,0000"))
                    e.Row.Cells[3].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[4].Text.Equals("1,0000"))
                    e.Row.Cells[4].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[5].Text.Equals("1,0000"))
                    e.Row.Cells[5].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[6].Text.Equals("1,0000"))
                    e.Row.Cells[6].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[7].Text.Equals("1,0000"))
                    e.Row.Cells[7].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[8].Text.Equals("1,0000"))
                    e.Row.Cells[8].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[9].Text.Equals("1,0000"))
                    e.Row.Cells[9].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[10].Text.Equals("1,0000"))
                    e.Row.Cells[10].BackColor = System.Drawing.Color.LightBlue;

               */
                //e.Row.BackColor = System.Drawing.Color.Brown;
            }

            GridViewRow gvr = e.Row;

            if (gvr.RowType == DataControlRowType.Header)
            {
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableCell cell = new TableCell();
                cell.ColumnSpan = 1;

                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.ColumnSpan = 15;
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = ddlBulan.SelectedItem.ToString();
                row.Cells.Add(cell);
                gvContact.Controls[0].Controls.AddAt(0, row);
            }
        }

        protected void lbnextt3s_Click(object sender, EventArgs e)
        {
            //string bulan = "10";
            divdata.Visible = true;
            bulan = ddlBulan.SelectedValue;
            int numberbulan = Convert.ToInt32(bulan);
            int day = DateTime.DaysInMonth(2020, numberbulan);
            int days, j;
            j = 16;
            days = day - 15;
            total = days;
            string[] tanggalku = new string[days];
            for (int i = 0; i < days; i++)
            {
                tanggalku[i] = $@"sum(case 
				when s.tanggal_shift = '2020-{bulan}-{j}' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-{j}' and s.jadwal = 'Sore' then 2 else 0 end) as '{j}'";
                j++;
            }

            string datatanggal = string.Join(",", tanggalku);

            string query1 = $@"SELECT p.petugas,{datatanggal}
		            FROM shiftme s
	            left JOIN shiftme_petugas p ON s.id_petugas=p.id_petugas
	                group by p.petugas";

            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            gvContact.DataSource = dt;
            gvContact.DataBind();
            sqlCon.Close();
            lbnextT3s.Visible = false;
            lbprevT3s.Visible = true;
        }

        protected void pilih_Click(object sender, EventArgs e)
        {
            total = 15;
            divdata.Visible = true;
            bulan = ddlBulan.SelectedValue;
            string query = $@"SELECT p.petugas,
            sum(case 
				when s.tanggal_shift = '2020-{bulan}-01' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-01' and s.jadwal = 'Sore' then 2 else 0 end) as '01',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-02' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-02' and s.jadwal = 'Sore' then 2 else 0 end) as '02',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-03' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-03' and s.jadwal = 'Sore' then 2 else 0 end) as '03',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-04' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-04' and s.jadwal = 'Sore' then 2 else 0 end) as '04',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-05' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-05' and s.jadwal = 'Sore' then 2 else 0 end) as '05',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-06' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-06' and s.jadwal = 'Sore' then 2 else 0 end) as '06',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-07' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-07' and s.jadwal = 'Sore' then 2 else 0 end) as '07',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-08' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-08' and s.jadwal = 'Sore' then 2 else 0 end) as '08',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-09' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-09' and s.jadwal = 'Sore' then 2 else 0 end) as '09',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-10' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-10' and s.jadwal = 'Sore' then 2 else 0 end) as '10',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-11' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-11' and s.jadwal = 'Sore' then 2 else 0 end) as '11',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-12' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-12' and s.jadwal = 'Sore' then 0 else 0 end) as '12',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-13' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-13' and s.jadwal = 'Sore' then 2 else 0 end) as '13',
			sum(case
				when s.tanggal_shift = '2020-{bulan}-14' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-14' and s.jadwal = 'Sore' then 2 else 0 end) as '14',
			sum(case 
				when s.tanggal_shift = '2020-{bulan}-15' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-{bulan}-15' and s.jadwal = 'Sore' then 2 else 0 end) as '15'
		            FROM shiftme s
	            left JOIN shiftme_petugas p ON s.id_petugas=p.id_petugas
	                group by p.petugas";

            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            gvContact.DataSource = dt;
            gvContact.DataBind();
            sqlCon.Close();
            lbnextT3s.Visible = true;
            lbprevT3s.Visible = false;
        }
    }
}