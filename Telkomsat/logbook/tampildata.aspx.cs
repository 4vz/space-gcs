using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Telkomsat.logbook
{
    public partial class tampildata : System.Web.UI.Page
    {
        string bulan;
        string tahun = "";
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=LOGBOOK1; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGridView();
                sqlCon.Close();
            }
            fillGridView();


        }

        void fillGridView()

        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand cmd = new SqlCommand("LihatDataSort", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            gvLog.DataSource = dt;
            gvLog.DataBind();
            sqlCon.Close();
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvLog.PageIndex = e.NewPageIndex;
            gvLog.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string mystring = inputsearch.Value;
            string[] split = mystring.Split(new char[] { ' ', '\t' });
            string kata1 = split[0];
            string kata2, kata3, kata4, kata5, kata6;
            //lblPage.Text = split[3];
            if (split.Length < 2)
                kata2 = " ";
            else
                kata2 = split[1];

            if (split.Length < 3)
                kata3 = " ";
            else
                kata3 = split[2];

            if (split.Length < 4)
                kata4 = " ";
            else
                kata4 = split[3];

            if (split.Length < 5)
                kata5 = " ";
            else
                kata5 = split[4];

            if (split.Length < 6)
                kata6 = " ";
            else
                kata6 = split[5];

            if (kata1 == "januari")
            {
                bulan = "01";
                if (kata2 == " ")
                    tahun = "2019";
                else
                    tahun = kata2;
                tanggal();
            }
            else if (kata1 == "februari")
            {
                bulan = "02";
                tanggal();
            }
            else
            {
                Response.Write(kata1);
                SqlCommand cmd = new SqlCommand("SearchAll", sqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@kata1", kata1);
                cmd.Parameters.AddWithValue("@kata2", kata2);
                cmd.Parameters.AddWithValue("@kata3", kata3);
                cmd.Parameters.AddWithValue("@kata4", kata4);
                cmd.Parameters.AddWithValue("@kata5", kata5);
                cmd.Parameters.AddWithValue("@kata6", kata6);
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                sqlda.SelectCommand = cmd;
                DataTable dt = new DataTable();
                sqlda.Fill(dt);
                gvLog.DataSource = dt;
                gvLog.DataBind();
                sqlCon.Close();
            }
            

            
        }

        protected void Ink_OnClick1(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ViewByID", sqlCon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon.Close();
            hfContactID.Value = ID.ToString();
            Session["hf"] = hfContactID.Value;
            //Response.Redirect("~/details.aspx?equ=" + dtbl.Rows[0]["Equipment"].ToString() + "merk=" + dtbl.Rows[0]["Merk"].ToString());
            Session["tanggal"] = dtbl.Rows[0]["tanggal"].ToString();
            Session["event"] = dtbl.Rows[0]["event"].ToString();
            Session["mulai"] = dtbl.Rows[0]["mulai"].ToString();
            Session["selesai"] = dtbl.Rows[0]["selesai"].ToString();
            Session["info"] = dtbl.Rows[0]["info"].ToString();
            
            //Response.Redirect("~/details.aspx?" + dtbl.Rows[0]["Merk"].ToString());
            Response.Redirect("~/logbook/edit.aspx");

        }

        void tanggal()
        {
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand cmd = new SqlCommand("BulanSort", sqlCon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@bulan", bulan);
            cmd.Parameters.AddWithValue("@tahun", tahun);
            Response.Write(bulan);
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            gvLog.DataSource = dt;
            gvLog.DataBind();
            sqlCon.Close();
        }


        protected void gvLog_PreRender(object sender, EventArgs e)
        {
            lblPage.Text = "Menampilkan halaman " + (gvLog.PageIndex + 1).ToString() + " dari " + gvLog.PageCount.ToString();
        }

        protected void gvLog_RowData(object sender, GridViewRowEventArgs e)
        {
            for (int rowindex = gvLog.Rows.Count - 2; rowindex >= 0; rowindex--)
            {
                GridViewRow rows = gvLog.Rows[rowindex];
                GridViewRow previousrows = gvLog.Rows[rowindex + 1];
                if (rows.Cells[1].Text == previousrows.Cells[1].Text)
                {
                    rows.Cells[1].RowSpan = previousrows.Cells[1].RowSpan < 2 ? 2 :
                        previousrows.Cells[1].RowSpan + 1;
                    previousrows.Cells[1].Visible = false;
                }
            }


        }
    }
}