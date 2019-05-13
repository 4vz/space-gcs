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
    public partial class detail : System.Web.UI.Page
    {
        SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=LOGBOOK1; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            string formattanggal = Session["tanggal"].ToString();
            //DateTime newFormat = DateTime.ParseExact("09/12/2019", "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString();
            string tanggalnew = Convert.ToDateTime(formattanggal).ToString("yyyy/MM/dd");
            hfContactID.Value = Session["hf"].ToString();
            txtTanggal.Text = tanggalnew;
            txtEvent.Text = Session["event"].ToString();
            ddlUnit.Text = Session["unit"].ToString();
            ddlStatus.Text = Session["status"].ToString();
            txtOG.Text = Session["OG"].ToString();
            txtOS.Text = Session["OS"].ToString();
            txtInfo.Text = Session["info"].ToString();
            lblKategori.Text = Session["kategori"].ToString();

            int ID = Convert.ToInt32(hfContactID.Value);
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ViewByIDSorting", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            dtContact.DataSource = dtbl;
            dtContact.DataBind();

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/logbook/editlogbook.aspx");
        }
    }
}