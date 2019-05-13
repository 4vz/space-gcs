using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.asset
{
    public partial class coba : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmployeeChartInfo();
                GetEmployeeChartKelompok();
                //GetEmployeeChartKelompok();
            }
            GetEmployeeChartInfo();
            GetEmployeeChartKelompok();
        }

        private void GetEmployeeChartInfo()
        {
            string kelompok = DropDownList1.SelectedValue;
            Response.Write(kelompok);
            SqlCommand cmd = new SqlCommand("GrupNama", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Kelompok", kelompok);
            DataTable tb = new DataTable();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                tb.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
            }
            catch { }

            string chart = "";

            chart = "<canvas id=\"bar-chart\" width=\"100%\" height=\"40\"></canvas>";
            chart += "<script>";
            chart += "new Chart(document.getElementById(\"bar-chart\"), { type: 'bar', data: {labels: [";
            for (int i = 0; i < tb.Rows.Count; i++)
                chart += "'" + tb.Rows[i][0].ToString() + "'" + ",";
            chart = chart.Substring(0, chart.Length - 1);
            chart += "],datasets: [{ data: [";


            string value = "";
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                value += tb.Rows[i][1].ToString() + ",";
            }
            value = value.Substring(0, value.Length - 1);

            chart += value;

            chart += "],label: \""; // Chart color
            chart += kelompok;
            chart += "\",";
            chart += "borderColor: \"#3e95cd\",fill: true}";
            chart += "]},options: { title: { display: true,text: 'Kelompok'} }"; // Chart title
            chart += "});";
            chart += "</script>";
            ltChart.Text = chart;
        }

        private void GetEmployeeChartKelompok()
        {
            string Nama;
            Nama = DropDownList2.SelectedValue;
            Response.Write(Nama);
            SqlCommand cmd = new SqlCommand("GrupMerk", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nama", Nama);
            DataTable tb = new DataTable();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                tb.Load(dr, LoadOption.OverwriteChanges);
                con.Close();
            }
            catch { }

            string chart = "";

            chart = "<canvas id=\"line-chart\" width=\"100%\" height=\"40\"></canvas>";
            chart += "<script>";
            chart += "new Chart(document.getElementById(\"line-chart\"), { type: 'line', data: {labels: [";
            for (int i = 0; i < tb.Rows.Count; i++)
                chart += "'" + tb.Rows[i][0].ToString() + "'" + ",";
            if (chart.Length != 0)
            {
                chart = chart.Substring(0, chart.Length - 1);
                chart += "],datasets: [{ data: [";
            }
            


            string value = "";
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                value += tb.Rows[i][1].ToString() + ",";
            }
            if(value.Length != 0)
            {
                value = value.Substring(0, value.Length - 1);
                chart += value;
            }
            chart += "],label: \""; // Chart color
            chart += Nama;
            chart += "\",";
            chart += "borderColor: \"#3e95cd\",fill: true}";
            chart += "]},options: { title: { display: true,text: 'Kelompok'} }"; // Chart title
            chart += "});";
            chart += "</script>";
            if (chart.Length == 0 || value.Length == 0)
                ltChartKel.Text = "";
            else
                ltChartKel.Text = chart;
        }

        protected void btnDDL_Click(object sender, EventArgs e)
        {
            if(DropDownList1.Text == "RF EQUIPMENT")
            {
                DropDownList2.Visible = true;
                DropDownList3.Visible = false;
                /*DropDownList2.Items.Insert(1, new ListItem("UPCONVERTER", "UPCONVERTER"));
                DropDownList2.Items.Insert(2, new ListItem("DOWNCONVERTER", "DOWNCONVERTER"));*/
            }
            else if (DropDownList1.Text == "BASEBAND")
            {
                DropDownList2.Visible = false;
                DropDownList3.Visible = true;
                /*DropDownList2.Items.Clear();
                DropDownList2.Items.Add("GPS");
                DropDownList2.Items.Add("GPS ANTENA");*/
            }
        }
    }
}