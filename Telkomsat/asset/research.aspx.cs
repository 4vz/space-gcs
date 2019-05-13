using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;

namespace Telkomsat.asset
{
    public partial class research : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetEmployeeChartInfo();
            }
        }

        private void GetEmployeeChartInfo()
        {
            DataTable dt = new DataTable();
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("ReGrupMerk", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();
            }
            string[] x = new string[dt.Rows.Count];
            int[] y = new int[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }

            EmployeeChartInfo.Series[0].Points.DataBindXY(x, y);
            EmployeeChartInfo.Series[0].ChartType = SeriesChartType.Candlestick;
            EmployeeChartInfo.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            //EmployeeChartInfo.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            EmployeeChartInfo.Legends[0].Enabled = true;
            EmployeeChartInfo.Series[0].Name = "Merk";
        }
    }
}