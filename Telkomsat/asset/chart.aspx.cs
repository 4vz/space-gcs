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
    public partial class chart : System.Web.UI.Page
    {
        string Nama;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmployeeChartNama();
                GetEmployeeChartKelompok();
            }
            GetEmployeeChartNama();
            GetEmployeeChartKelompok();
        }

        private void GetEmployeeChartNama()
        {
            string kelompok = ddlKelompok.SelectedValue;
            SqlCommand cmd;
            if(kelompok == "Kelompok")
            {
                cmd = new SqlCommand("ReGrupNama", con);
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd = new SqlCommand("GrupNama", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Kelompok", kelompok);
            }
            
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
            chart += "new Chart(document.getElementById(\"bar-chart\"), { type: 'horizontalBar', data: {labels: [";
            for (int i = 0; i < tb.Rows.Count; i++)
                chart += "'" + tb.Rows[i][0].ToString() + "'" + ",";
            chart = chart.Substring(0, chart.Length - 1);
            chart += "],datasets: [{ data: [";


            string value = "";
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                value += tb.Rows[i][1].ToString() + ",";
            }
            if (value.Length != 0)
            {
                value = value.Substring(0, value.Length - 1);
                chart += value;
            }

            chart += "],label: \""; // Chart color
            chart += kelompok;
            chart += "\",";
            chart += "borderColor: \"#3e95cd\",fill: true}";
            chart += "]},options: { title: { display: true,text: 'Nama Equipment'} }"; // Chart title
            chart += "});";
            chart += "</script>";
            if (chart.Length == 0 || value.Length == 0)
                ltChart.Text = "";
            else
                ltChart.Text = chart;
        }

        private void GetEmployeeChartKelompok()
        {
            string[] warna = new string[30] // 4 adalah ukuran Array
            {
            "#ad2525", "#2579ad", "#cdc102", "#10d038", "#0e7924", "#28bcc9", "#3f6366", "#02cd40", "#f8f4ac", "#9b9314",
            "#ad2525", "#2579ad", "#cdc102", "#10d038", "#0e7924", "#28bcc9", "#3f6366", "#02cd40", "#f8f4ac", "#9b9314",
            "#ad2525", "#2579ad", "#cdc102", "#10d038", "#0e7924", "#28bcc9", "#3f6366", "#02cd40", "#f8f4ac", "#9b9314"// ini adalah elemen data
            };


            if (ddlKelompok.Text == "RF EQUIPMENT" || ddlKelompok.Text == "Kelompok")
                Nama = ddlRF.SelectedValue;
            else if(ddlKelompok.Text == "BASEBAND")
                Nama = ddlBaseband.SelectedValue;
            else if (ddlKelompok.Text == "ANTENA")
                Nama = ddlAntena.SelectedValue;
            else if (ddlKelompok.Text == "ALAT UKUR")
                Nama = ddlAlat.SelectedValue;
            else if (ddlKelompok.Text == "LICENSE")
                Nama = ddlLicense.SelectedValue;
            else if (ddlKelompok.Text == "SERVER & NE")
                Nama = ddlServer.SelectedValue;
            else if (ddlKelompok.Text == "WORKSTATION")
                Nama = ddlWorkstation.SelectedValue;
            else if (ddlKelompok.Text == "ME")
                Nama = ddlME.SelectedValue;

            SqlCommand cmd;
            if (Nama == "Nama Equipment")
            {
                cmd = new SqlCommand("ReGrupMerk", con);
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd = new SqlCommand("GrupMerk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nama", Nama);
            }
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

            chart = "<canvas id=\"pie-chart\" width=\"100%\" height=\"40\"></canvas>";
            chart += "<script>";
            chart += "new Chart(document.getElementById(\"pie-chart\"), { type: 'pie', data: {labels: [";
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i][0].ToString() == "CROSS TECHNOLOGIES")
                    chart += "'" + "CT" + "'" + ",";
                else
                    chart += "'" + tb.Rows[i][0].ToString() + "'" + ",";
            }
                
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
            if (value.Length != 0)
            {
                value = value.Substring(0, value.Length - 1);
                chart += value;
            }

            string color = "";
            chart += "],backgroundColor: ["; // Chart color
            for (int i = 0; i < tb.Rows.Count; i++)
                color += "'" + warna[i].ToString() + "'" + ",";
            if (color.Length != 0)
            {
                color = color.Substring(0, color.Length - 1);
                chart += color;
            }
                
            chart += "],label: \""; // Chart color
            chart += Nama;
            chart += "\",";
            chart += "borderColor: \"#3e95cd\",fill: true}";
            chart += "]},options: { title: { display: true,text: 'Merk Equipment'} }"; // Chart title
            chart += "});";
            chart += "</script>";
            if (chart.Length == 0 || value.Length == 0)
                ltChartKel.Text = "";
            else
                ltChartKel.Text = chart;
        }

        protected void btnDDL_Click(object sender, EventArgs e)
        {
            if (ddlKelompok.Text == "RF EQUIPMENT")
            {
                ddlRF.Visible = true;
                ddlBaseband.Visible = false;
                ddlAlat.Visible = false;
                ddlAntena.Visible = false;
                ddlLicense.Visible = false;
                ddlServer.Visible = false;
                ddlWorkstation.Visible = false;
                ddlME.Visible = false;
            }
            else if (ddlKelompok.Text == "BASEBAND")
            {
                ddlRF.Visible = false;
                ddlBaseband.Visible = true;
                ddlAlat.Visible = false;
                ddlAntena.Visible = false;
                ddlLicense.Visible = false;
                ddlServer.Visible = false;
                ddlWorkstation.Visible = false;
                ddlME.Visible = false;
            }
            else if (ddlKelompok.Text == "ALAT UKUR")
            {
                ddlRF.Visible = false;
                ddlBaseband.Visible = false;
                ddlAlat.Visible = true;
                ddlAntena.Visible = false;
                ddlLicense.Visible = false;
                ddlServer.Visible = false;
                ddlWorkstation.Visible = false;
                ddlME.Visible = false;
            }
            else if (ddlKelompok.Text == "ANTENA")
            {
                ddlRF.Visible = false;
                ddlBaseband.Visible = false;
                ddlAlat.Visible = false;
                ddlAntena.Visible = true;
                ddlLicense.Visible = false;
                ddlServer.Visible = false;
                ddlWorkstation.Visible = false;
                ddlME.Visible = false;
            }
            else if (ddlKelompok.Text == "SERVER & NE")
            {
                ddlRF.Visible = false;
                ddlBaseband.Visible = false;
                ddlAlat.Visible = false;
                ddlAntena.Visible = false;
                ddlLicense.Visible = false;
                ddlServer.Visible = true;
                ddlWorkstation.Visible = false;
                ddlME.Visible = false;
            }
            else if (ddlKelompok.Text == "LICENSE")
            {
                ddlRF.Visible = false;
                ddlBaseband.Visible = false;
                ddlAlat.Visible = false;
                ddlAntena.Visible = false;
                ddlLicense.Visible = true;
                ddlServer.Visible = false;
                ddlWorkstation.Visible = false;
                ddlME.Visible = false;
            }
            else if (ddlKelompok.Text == "WORKSTATION")
            {
                ddlRF.Visible = false;
                ddlBaseband.Visible = false;
                ddlAlat.Visible = false;
                ddlAntena.Visible = false;
                ddlLicense.Visible = false;
                ddlServer.Visible = false;
                ddlWorkstation.Visible = true;
                ddlME.Visible = false;
            }
            else if (ddlKelompok.Text == "ME")
            {
                ddlRF.Visible = false;
                ddlBaseband.Visible = false;
                ddlAlat.Visible = false;
                ddlAntena.Visible = false;
                ddlLicense.Visible = false;
                ddlServer.Visible = false;
                ddlWorkstation.Visible = false;
                ddlME.Visible = true;
            }
        }
    }
}