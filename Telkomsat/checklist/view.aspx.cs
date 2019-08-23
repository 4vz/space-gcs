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
            e.Row.Cells[3].Visible = false;
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
            e.Row.Cells[31].Visible = false;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // determine the value of the UnitsInStock field
                //int CategoryID = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "status"));
                //if (CategoryID == 1)
                // color the background of the row yellow
                if (e.Row.Cells[5].Text.Equals("0"))
                    e.Row.Cells[4].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[3].Text.Equals("0"))
                    e.Row.Cells[2].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[7].Text.Equals("0"))
                    e.Row.Cells[6].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[9].Text.Equals("0"))
                    e.Row.Cells[8].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[11].Text.Equals("0"))
                    e.Row.Cells[10].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[13].Text.Equals("0"))
                    e.Row.Cells[12].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[15].Text.Equals("0"))
                    e.Row.Cells[14].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[17].Text.Equals("0"))
                    e.Row.Cells[16].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[19].Text.Equals("0"))
                    e.Row.Cells[18].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[21].Text.Equals("0"))
                    e.Row.Cells[20].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[23].Text.Equals("0"))
                    e.Row.Cells[22].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[25].Text.Equals("0"))
                    e.Row.Cells[24].BackColor = System.Drawing.Color.LightBlue;
            
                if (e.Row.Cells[27].Text.Equals("0"))
                    e.Row.Cells[26].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[29].Text.Equals("0"))
                    e.Row.Cells[28].BackColor = System.Drawing.Color.LightBlue;

                if (e.Row.Cells[31].Text.Equals("0"))
                    e.Row.Cells[30].BackColor = System.Drawing.Color.LightBlue;

                //e.Row.BackColor = System.Drawing.Color.Brown;
            }

            GridViewRow gvr = e.Row;
            if (gvr.RowType == DataControlRowType.Header)
            {

                GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
                TableCell cell = new TableCell();
                cell.ColumnSpan = 2;
                cell.Text = "T3S Ku-Band";
                cell.HorizontalAlign = HorizontalAlign.Center;
                row.Cells.Add(cell);

                cell = new TableCell();
                cell.ColumnSpan = 15;
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.Text = "Agustus";
                row.Cells.Add(cell);

                gvContact.Controls[0].Controls.AddAt(0, row);

            }

        }

        protected void lbnextt3s_Click(object sender, EventArgs e)
        {
            //string bulan = "10";
            data.Visible = true;
            bulan = "08";
            shelter = DropDownList1.SelectedValue;
            string query1 = $@"SELECT p.paramater, p.rak,
            sum(case when t.tanggal_check = '2019-09-16' then s.nilai end) as '{bulan}/16',
            sum(case when t.tanggal_check = '2019-09-16' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-17' then s.nilai end) as '{bulan}/17',
            sum(case when t.tanggal_check = '2019-09-17' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-18' then s.nilai end) as '{bulan}/18',
            sum(case when t.tanggal_check = '2019-09-18' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-08-19' then s.nilai end) as '{bulan}/19',
            sum(case when t.tanggal_check = '2019-08-19' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-20' then s.nilai end) as '{bulan}/20',
            sum(case when t.tanggal_check = '2019-09-20' then s.status else 0  end) as 'status',
            sum(case when t.tanggal_check = '2019-09-21' then s.nilai end) as '{bulan}/21',
            sum(case when t.tanggal_check = '2019-09-21' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-22' then s.nilai end) as '{bulan}/22',
            sum(case when t.tanggal_check = '2019-09-22' then s.status else 0  end) as 'status',
            sum(case when t.tanggal_check = '2019-09-23' then s.nilai end) as '{bulan}/23',
            sum(case when t.tanggal_check = '2019-09-23' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-24' then s.nilai end) as '{bulan}/24',
            sum(case when t.tanggal_check = '2019-09-24' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-25' then s.nilai end) as '{bulan}/25',
            sum(case when t.tanggal_check = '2019-09-25' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-26' then s.nilai end) as '{bulan}/26',
            sum(case when t.tanggal_check = '2019-09-26' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-27' then s.nilai end) as '{bulan}/27',
            sum(case when t.tanggal_check = '2019-09-27' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-28' then s.nilai end) as '{bulan}/28',
            sum(case when t.tanggal_check = '2019-09-28' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-29' then s.nilai end) as '{bulan}/29',
            sum(case when t.tanggal_check = '2019-09-29' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-30' then s.nilai end) as '{bulan}/30',
            sum(case when t.tanggal_check = '2019-09-30' then s.status else 0 end) as 'status'
		            FROM check_status s
	            left JOIN check_parameter p ON s.ID_paramater=p.ID_parameter left JOIN check_tanggal t ON s.ID_tgl= t.ID_tgl 
	                WHERE p.shelter = '{shelter}'
	                group by p.paramater, p.rak";

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
            shelter = DropDownList1.Text;
            bulan = "08";
            string query = $@"SELECT p.paramater, p.rak,
            sum(case when t.tanggal_check = '2019-09-09' then s.nilai end) as '{bulan}/01',
            sum(case when t.tanggal_check = '2019-09-09' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-10' then s.nilai end) as '{bulan}/02',
            sum(case when t.tanggal_check = '2019-09-10' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-11' then s.nilai end) as '{bulan}/03',
            sum(case when t.tanggal_check = '2019-09-11' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-08-09' then s.nilai end) as '{bulan}/04',
            sum(case when t.tanggal_check = '2019-08-09' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-12' then s.nilai end) as '{bulan}/05',
            sum(case when t.tanggal_check = '2019-09-12' then s.status else 0  end) as 'status',
            sum(case when t.tanggal_check = '2019-09-13' then s.nilai end) as '{bulan}/06',
            sum(case when t.tanggal_check = '2019-09-13' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-14' then s.nilai end) as '{bulan}/07',
            sum(case when t.tanggal_check = '2019-09-14' then s.status else 0  end) as 'status',
            sum(case when t.tanggal_check = '2019-09-15' then s.nilai end) as '{bulan}/08',
            sum(case when t.tanggal_check = '2019-09-15' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-15' then s.nilai end) as '{bulan}/09',
            sum(case when t.tanggal_check = '2019-09-15' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-15' then s.nilai end) as '{bulan}/10',
            sum(case when t.tanggal_check = '2019-09-15' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-15' then s.nilai end) as '{bulan}/11',
            sum(case when t.tanggal_check = '2019-09-15' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-15' then s.nilai end) as '{bulan}/12',
            sum(case when t.tanggal_check = '2019-09-15' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-15' then s.nilai end) as '{bulan}/13',
            sum(case when t.tanggal_check = '2019-09-15' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-15' then s.nilai end) as '{bulan}/14',
            sum(case when t.tanggal_check = '2019-09-15' then s.status else 0 end) as 'status',
            sum(case when t.tanggal_check = '2019-09-15' then s.nilai end) as '{bulan}/15',
            sum(case when t.tanggal_check = '2019-09-15' then s.status else 0 end) as 'status'
		            FROM check_status s
	            left JOIN check_parameter p ON s.ID_paramater=p.ID_parameter left JOIN check_tanggal t ON s.ID_tgl= t.ID_tgl 
	                WHERE p.shelter = '{shelter}'
	                group by p.paramater, p.rak";

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