using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

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
            string query, previllage, user, usernamee;
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            user = Session["iduser"].ToString();
            usernamee = Session["username"].ToString();

            if (!IsPostBack)
            {
                sqlCon.Open();
                SqlDataAdapter sqlCmd = new SqlDataAdapter("ProViewByUser", sqlCon);
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd.SelectCommand.Parameters.AddWithValue("@user", usernamee);
                DataTable dtbl1 = new DataTable();
                sqlCmd.Fill(dtbl1);
                dtContact1.DataSource = dtbl1;
                dtContact1.DataBind();
                sqlCon.Close();
            }
            sqlCon.Open();
            SqlDataAdapter sqlCmd2 = new SqlDataAdapter("ProViewByUser", sqlCon);
            sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd2.SelectCommand.Parameters.AddWithValue("@user", usernamee);
            DataTable dtbl = new DataTable();
            sqlCmd2.Fill(dtbl);
            dtContact1.DataSource = dtbl;
            DataList1.DataSource = dtbl;
            DataList1.DataBind();

            lblProfile.Text = Session["nama1"].ToString();
            lblProfile1.Text = Session["nama1"].ToString();

            string thisURL = Request.Url.Segments[Request.Url.Segments.Length - 1];
            if (thisURL.ToLower() == "dashboard.aspx") lidashboard.Attributes.Add("class", "active");
            if (thisURL.ToLower().IsIn(new string[] { "listpemasukan.aspx", "pemasukan.aspx" })) lipemasukan.Attributes.Add("class", "active");
            if (thisURL.ToLower().IsIn(new string[] { "listpengeluaran.aspx", "pengeluaran.aspx" })) lipengeluaran.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pemindahan.aspx") lipemindahan.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pengembalian.aspx") lipengembalian.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "approvementsa.aspx") lisa.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "approvement.aspx")
            {
                ligm.Attributes.Add("class", "active");
                liadmin.Attributes.Add("class", "active");
                liuser.Attributes.Add("class", "active");
            }

            query = $"Select * from AdminProfile where AP_Nama = '{user}'";
            DataSet ds = Settings.LoadDataSet(query);

            if (ds.Tables[0].Rows.Count > 0)
            {
                previllage = ds.Tables[0].Rows[0]["AP_Previllage"].ToString();
                if (previllage == "GM")
                    ligm.Visible = true;
                else if (previllage == "User")
                    liuser.Visible = true;
                else if (previllage == "Admin Bendahara")
                    liadmin.Visible = true;

                if(previllage == "SA")
                {
                    lisa.Visible = true;
                }

                /*switch (previllage)
                {
                    case "User":
                        {
                            if (thisURL.ToLower().IsIn(new string[]{ "dashboard.aspx", "datapemasukan.aspx", "data.aspx", "pemasukan.aspx", "pengeluaran.aspx", "listpemasukan.aspx",
                                "listpengeluaran.aspx", "tambahrkap.aspx", "pengembalian.aspx", "pemindahan.aspx"}))
                            {
                                Response.Redirect("listjustifikasi.aspx");
                            }

                            lidashboard.Visible = false;
                            lidata.Visible = false;
                        }
                        break;
                    case "User Organik":
                        {
                            if (thisURL.ToLower().IsIn(new string[] { "justifikasi.aspx"}))
                            {
                                Response.Redirect("dashboard.aspx");
                            }

                            lidashboard.Visible = false;
                            lidata.Visible = false;
                        }
                        break;
                }*/

                if (previllage == "User")
                {
                    if (thisURL.ToLower().IsIn(new string[]{ "dashboard.aspx", "datapemasukan.aspx", "data.aspx", "pemasukan.aspx", "pengeluaran.aspx", "listpemasukan.aspx",
                    "listpengeluaran.aspx", "tambahrkap.aspx", "pengembalian.aspx", "pemindahan.aspx"}))
                    {
                        Response.Redirect("listjustifikasi.aspx");
                    }
                    lipemasukan.Visible = false;
                    lipengeluaran.Visible = false;
                    lipemindahan.Visible = false;
                    lipengembalian.Visible = false;
                    lidashboard.Visible = false;
                    lidata.Visible = false;
                }
                else if(previllage.ToLower().IsIn(new string[] { "User Organik", "SA", "User" }))
                {
                    
                }
                else
                {
                    if (thisURL.ToLower() == "justifikasi.aspx")
                    {
                        Response.Redirect("dashboard.aspx");
                    }
                }

                if (previllage != "Admin Bendahara")
                {
                    if (thisURL.ToLower().IsIn(new string[]{ "pemasukan.aspx", "pengeluaran.aspx", "pemindahan.aspx", "pengembalian.aspx"}))
                    {
                        Response.Redirect("dashboard.aspx");
                    }
                    lipemindahan.Visible = false;
                    lipengembalian.Visible = false;
                }
            }
            //lblProfile.Text = Session["nama1"].ToString();
            //lblProfile1.Text = Session["nama1"].ToString();
        }

        void approve()
        {
            string query, user;
            user = Session["iduser"].ToString();
            int jenis;
            query = $@"select(select count(*) from AdminJustifikasi where (AJ_Status = '' or AJ_Status is null or AJ_Status = 'repair') and AJ_Profile = '{user}')[ajukan],
		        (select count(*) from AdminJustifikasi where AJ_Status = 'diajukan')[gm],
		        (select count(*) from AdminJustifikasi where AJ_Status = 'gm')[admin],
                (select count(*) from AdminJustifikasi where AJ_Status not in ('admin', 'reject')) [sa]";

            DataSet ds = Settings.LoadDataSet(query);

            if(ds.Tables[0].Rows.Count > 0)
            {
                lbldiajukan.Text = ds.Tables[0].Rows[0]["ajukan"].ToString();
                lblgm.Text = ds.Tables[0].Rows[0]["gm"].ToString();
                lbladmin.Text = ds.Tables[0].Rows[0]["admin"].ToString();
                lblsa.Text = ds.Tables[0].Rows[0]["sa"].ToString();
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}