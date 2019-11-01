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
    public partial class view : System.Web.UI.Page
    {
        string bulan { get; set; }
        string shelter { get; set; }
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void gvContact_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*if(e.Row.Cells[3].Text.Equals("0"))
            {
                e.Row.Cells[3].BackColor = System.Drawing.Color.Red;
            }*/
            /*e.Row.Cells[3].Visible = false;
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[9].Visible = false;
            e.Row.Cells[11].Visible = false;
            e.Row.Cells[13].Visible = false;
            e.Row.Cells[15].Visible = false;
            e.Row.Cells[17].Visible = false;
            e.Row.Cells[19].Visible = false;
            e.Row.Cells[21].Visible = false;
            e.Row.Cells[23].Visible = false;
            e.Row.Cells[25].Visible = false;
            e.Row.Cells[27].Visible = false;
            e.Row.Cells[29].Visible = false;
            e.Row.Cells[31].Visible = false;*/
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Visible = false;
                e.Row.Cells[3].Visible = false;
                // determine the value of the UnitsInStock field
                //int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "status"));
                //if (CategoryID == 1)
                // color the background of the row yellow
                for (int j=0; j <= 18; j++)
                {
                    e.Row.Cells[j].Style.Add("padding-left", "5px");

                    if (e.Row.Cells[j].Text.Equals("1,0000"))
                    {
                        e.Row.Cells[j].BackColor = System.Drawing.Color.LightBlue;
                        e.Row.Cells[j].Text = "Pass";
                    }
                    else if (e.Row.Cells[j].Text.Equals("0,0000"))
                    {
                        e.Row.Cells[j].BackColor = System.Drawing.Color.IndianRed;
                        e.Row.Cells[j].Text = "Fail";
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
                gvr.Cells[0].Visible = false;
                gvr.Cells[3].Visible = false;
                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableCell cell = new TableCell();
                cell.ColumnSpan = 2;
                cell.Text = ddlShelter.SelectedItem.ToString();
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
            data.Visible = true;
            bulan = ddlBulan.SelectedValue;
            shelter = ddlShelter.SelectedValue;
            string query1 = $@"SELECT s.ID_paramater, p.Perangkat,p.[S/N], p.Rack,
            sum(case when t.tanggal_check = '2019-{bulan}-16' then s.nilai end) as '{bulan}/16',
            sum(case when t.tanggal_check = '2019-{bulan}-17' then s.nilai end) as '{bulan}/17',
            sum(case when t.tanggal_check = '2019-{bulan}-18' then s.nilai end) as '{bulan}/18',
            sum(case when t.tanggal_check = '2019-{bulan}-19' then s.nilai end) as '{bulan}/19',
            sum(case when t.tanggal_check = '2019-{bulan}-20' then s.nilai end) as '{bulan}/20',
            sum(case when t.tanggal_check = '2019-{bulan}-21' then s.nilai end) as '{bulan}/21',
            sum(case when t.tanggal_check = '2019-{bulan}-22' then s.nilai end) as '{bulan}/22',
            sum(case when t.tanggal_check = '2019-{bulan}-23' then s.nilai end) as '{bulan}/23',
            sum(case when t.tanggal_check = '2019-{bulan}-24' then s.nilai end) as '{bulan}/24',
            sum(case when t.tanggal_check = '2019-{bulan}-25' then s.nilai end) as '{bulan}/25',
            sum(case when t.tanggal_check = '2019-{bulan}-26' then s.nilai end) as '{bulan}/26',
            sum(case when t.tanggal_check = '2019-{bulan}-27' then s.nilai end) as '{bulan}/27',
            sum(case when t.tanggal_check = '2019-{bulan}-28' then s.nilai end) as '{bulan}/28',
            sum(case when t.tanggal_check = '2019-{bulan}-29' then s.nilai end) as '{bulan}/29',
            sum(case when t.tanggal_check = '2019-{bulan}-30' then s.nilai end) as '{bulan}/30'
		            FROM check_status s
	            left JOIN check_parameter r ON s.ID_paramater=r.ID_parameter left JOIN check_tanggal t ON s.ID_tgl= t.ID_tgl 
				join check_perangkat p on p.ID_Perangkat=r.ID_Perangkat
	                WHERE p.Shelter = '{shelter}' and r.Parameter = 'Status'
	                group by s.ID_paramater,p.Rack,p.Perangkat, p.[S/N]
					order by p.Rack";

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
            
            data.Visible = true;
            shelter = ddlShelter.SelectedValue;
            bulan = ddlBulan.SelectedValue;
            string query = $@"SELECT s.ID_paramater, p.Perangkat,p.[S/N], p.Rack,
            sum(case when t.tanggal_check = '2019-{bulan}-01' then s.nilai end) as '{bulan}/01',
            sum(case when t.tanggal_check = '2019-{bulan}-02' then s.nilai end) as '{bulan}/02',
            sum(case when t.tanggal_check = '2019-{bulan}-03' then s.nilai end) as '{bulan}/03',
            sum(case when t.tanggal_check = '2019-{bulan}-04' then s.nilai end) as '{bulan}/04',
            sum(case when t.tanggal_check = '2019-{bulan}-05' then s.nilai end) as '{bulan}/05',
            sum(case when t.tanggal_check = '2019-{bulan}-06' then s.nilai end) as '{bulan}/06',
            sum(case when t.tanggal_check = '2019-{bulan}-07' then s.nilai end) as '{bulan}/07',
            sum(case when t.tanggal_check = '2019-{bulan}-08' then s.nilai end) as '{bulan}/08',
            sum(case when t.tanggal_check = '2019-{bulan}-09' then s.nilai end) as '{bulan}/09',
            sum(case when t.tanggal_check = '2019-{bulan}-10' then s.nilai end) as '{bulan}/10',
            sum(case when t.tanggal_check = '2019-{bulan}-11' then s.nilai end) as '{bulan}/11',
            sum(case when t.tanggal_check = '2019-{bulan}-12' then s.nilai end) as '{bulan}/12',
            sum(case when t.tanggal_check = '2019-{bulan}-13' then s.nilai end) as '{bulan}/13',
            sum(case when t.tanggal_check = '2019-{bulan}-14' then s.nilai end) as '{bulan}/14',
            sum(case when t.tanggal_check = '2019-{bulan}-15' then s.nilai end) as '{bulan}/15'
		            FROM check_status s
	            left JOIN check_parameter r ON s.ID_paramater=r.ID_parameter left JOIN check_tanggal t ON s.ID_tgl= t.ID_tgl 
				join check_perangkat p on p.ID_Perangkat=r.ID_Perangkat
	                WHERE p.Shelter = '{shelter}' and r.Parameter = 'Status'
	                group by s.ID_paramater,p.Rack,p.Perangkat, p.[S/N]
					order by p.Rack";

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