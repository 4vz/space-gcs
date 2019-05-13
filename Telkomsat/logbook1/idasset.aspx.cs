using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.logbook1
{
    public partial class idasset : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            hfContactID.Value = Session["SN"].ToString();
            lblJudul.Text = "Data Asset Untuk Serial Number " + hfContactID.Value;
          
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            string query = "SELECT * FROM Asset1";
            SqlDataAdapter sqlda = new SqlDataAdapter("AsViewBySN", sqlCon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@SN", hfContactID.Value);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            DataList1.DataSource = dtbl;
            DataList1.DataBind();
            sqlCon.Close();
        }
        protected void btnKembali_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/logbook1/tambah.aspx");
        }
    }
}