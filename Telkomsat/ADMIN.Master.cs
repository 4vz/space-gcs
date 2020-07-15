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
    public partial class ADMIN : System.Web.UI.MasterPage
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Redirect("~/login.aspx", true);
            }

            approve();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string query, previllage, user;
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            user = Session["iduser"].ToString();

            lblProfile.Text = Session["nama1"].ToString();
            lblProfile1.Text = Session["nama1"].ToString();

            string thisURL = Request.Url.Segments[Request.Url.Segments.Length - 1];
            if (thisURL.ToLower() == "dashboard.aspx") lidashboard.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pemasukan.aspx") lipemasukan.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pengeluaran.aspx") lipengeluaran.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pemindahan.aspx") lipemindahan.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pengembalian.aspx") lipengembalian.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "listjustifikasi.aspx" || thisURL.ToLower() == "justifikasi.aspx" || thisURL.ToLower() == "detailjustifikasi.aspx") lijustifikasi.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "approvement.aspx")
            {
                limanager.Attributes.Add("class", "active");
                ligm.Attributes.Add("class", "active");
                liadmin.Attributes.Add("class", "active");
                liuser.Attributes.Add("class", "active");
            }

            query = $"Select * from AdminProfile where AP_Nama = '{user}'";
            DataSet ds = Settings.LoadDataSet(query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                previllage = ds.Tables[0].Rows[0]["AP_Previllage"].ToString();
                if (previllage == "Manager")
                    limanager.Visible = true;
                else if (previllage == "GM")
                    ligm.Visible = true;
                else if (previllage == "User")
                    liuser.Visible = true;
                else if (previllage == "Admin Bendahara")
                    liadmin.Visible = true;

                
            }
            //lblProfile.Text = Session["nama1"].ToString();
            //lblProfile1.Text = Session["nama1"].ToString();
        }

        void approve()
        {
            string query;
            int jenis;
            query = @"select(select count(*) from AdminJustifikasi where AJ_Status = '' or AJ_Status is null)[ajukan],
		        (select count(*) from AdminJustifikasi where AJ_Status = 'diajukan')[manager],
		        (select count(*) from AdminJustifikasi where AJ_Status = 'manager')[gm],
		        (select count(*) from AdminJustifikasi where AJ_Status = 'gm')[admin]";

            DataSet ds = Settings.LoadDataSet(query);

            lbldiajukan.Text = ds.Tables[0].Rows[0]["ajukan"].ToString();
            lblmanager.Text = ds.Tables[0].Rows[0]["manager"].ToString();
            lblgm.Text = ds.Tables[0].Rows[0]["gm"].ToString();
            lbladmin.Text = ds.Tables[0].Rows[0]["admin"].ToString();

        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}