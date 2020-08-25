using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;

namespace Telkomsat
{
    public partial class addprofile : System.Web.UI.Page
    {
        string user;
        //SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            string query = $@"INSERT INTO Profile (nama, user_name, password, jenis, alias, previllage, approval)
                                VALUES ('{txtnama.Value}', '{txtnik.Value}', '8F051B8F8B85672B800FB4CCD8A20892', '{ddljenis.Text}', '{txtalias.Value}', '{ddlprevillage.Text}', '{ddlchecklist.Text}')";
            SqlCommand sqlCmd2 = new SqlCommand(query, sqlCon2);
            sqlCon2.Open();
            sqlCmd2.ExecuteNonQuery();
            sqlCon2.Close();
            lblUpdate.Visible = true;
            lblUpdate.Text = "Berhasil Disimpan";
            lblUpdate.ForeColor = System.Drawing.Color.GreenYellow;
            clear();
                       
        }

        void clear()
        {
            txtnama.Value = "";
            txtalias.Value = "";
            txtnik.Value = "";
            ddlchecklist.Text = "";
            ddljenis.Text = "";
            ddlprevillage.Text = "";
        }

    }
}