using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat
{
    public partial class alldata : System.Web.UI.Page
    {
        string chart;
        SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS1; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            string[] contoh = new string[4] // 4 adalah ukuran Array
            {
            "Motherboard", "Processor", "Power Supply", "Video Card" // ini adalah elemen data
            };

            for (int i = 0; i < 4; i++)
                chart += "'" + contoh[i].ToString() + "'" + ",";
            chart = chart.Substring(0, chart.Length - 1);
            Response.Write(chart);
        }

        
    }
}