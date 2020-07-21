﻿using System;
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
            if (thisURL.ToLower() == "pemasukan.aspx") lipemasukan.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pengeluaran.aspx") lipengeluaran.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pemindahan.aspx") lipemindahan.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pengembalian.aspx") lipengembalian.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "listjustifikasi.aspx" || thisURL.ToLower() == "justifikasi.aspx" || thisURL.ToLower() == "detailjustifikasi.aspx") lijustifikasi.Attributes.Add("class", "active");
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
                    ligm.Visible = true;
                    liuser.Visible = true;
                    liadmin.Visible = true;
                }

                
            }
            //lblProfile.Text = Session["nama1"].ToString();
            //lblProfile1.Text = Session["nama1"].ToString();
        }

        void approve()
        {
            string query;
            int jenis;
            query = @"select(select count(*) from AdminJustifikasi where AJ_Status = '' or AJ_Status is null)[ajukan],
		        (select count(*) from AdminJustifikasi where AJ_Status = 'diajukan')[gm],
		        (select count(*) from AdminJustifikasi where AJ_Status = 'gm')[admin]";

            DataSet ds = Settings.LoadDataSet(query);

            lbldiajukan.Text = ds.Tables[0].Rows[0]["ajukan"].ToString();
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