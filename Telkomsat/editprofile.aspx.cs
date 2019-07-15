﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Threading;

namespace Telkomsat
{
    public partial class editprofile : System.Web.UI.Page
    {
        string user;
        
        //SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string ttl;
            string tanggal;

            Page.Form.DefaultButton = btnUpdate.ID;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            user = Session["username"].ToString();
            tanggal = Session["tanggal"].ToString();
            ttl = Session["ttl"].ToString();

            string tanggalmasuk = tanggal.Remove(10, 9);
            string tanggallahir = ttl.Remove(10, 9);
            //txtnama.Value = Session["username"].ToString();
            if (!IsPostBack)
            {
                txtnama.Value = Session["nama"].ToString();
                txtemail.Value = Session["email"].ToString();
                txtnomor.Value = Session["nomor"].ToString();
                txttempat.Value = Session["tempat"].ToString();
                if (Session["tanggal"].ToString() != null || Session["tanggal"].ToString() != "")
                    txttanggal.Value = tanggalmasuk;
                if (Session["ttl"].ToString() != null || Session["ttl"].ToString() != "")
                    txtttl.Value = tanggallahir;
            }

            lblProfile1.Text = Session["username"].ToString();
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            user = Session["username"].ToString();
            sqlCon2.Open();
            SqlCommand sqlCmd2 = new SqlCommand("ProUpdate", sqlCon2);
            sqlCmd2.CommandType = CommandType.StoredProcedure;
            sqlCmd2.Parameters.AddWithValue("@user", user);
            sqlCmd2.Parameters.AddWithValue("@nama", txtnama.Value);
            sqlCmd2.Parameters.AddWithValue("@email", txtemail.Value);
            sqlCmd2.Parameters.AddWithValue("@nomor", txtnomor.Value);
            if(txttanggal.Value == "")
                sqlCmd2.Parameters.AddWithValue("@tanggal", DBNull.Value);
            else
                sqlCmd2.Parameters.AddWithValue("@tanggal", DateTime.ParseExact(txttanggal.Value, "dd/MM/yyyy", null));

            sqlCmd2.Parameters.AddWithValue("@tempat", txttempat.Value);

            if (txtttl.Value == "")
                sqlCmd2.Parameters.AddWithValue("@ttl", DBNull.Value);
            else
                sqlCmd2.Parameters.AddWithValue("@ttl", DateTime.ParseExact(txtttl.Value, "dd/MM/yyyy", null));
            sqlCmd2.ExecuteNonQuery();
            sqlCon2.Close();
            lblUpdate.Visible = true;
            lblUpdate.Text = "Berhasil Update";
            lblUpdate.ForeColor = System.Drawing.Color.GreenYellow;
            clear();

            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ProViewByUser", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@user", Session["username"].ToString());
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            
            //Session["username"] = dtbl.Rows[0]["user_name"].ToString();
            Session["email"] = dtbl.Rows[0]["email"].ToString();
            Session["jenis1"] = dtbl.Rows[0]["jenis"].ToString();
            Session["nama"] = dtbl.Rows[0]["nama"].ToString();
            Session["nomor"] = dtbl.Rows[0]["nomor"].ToString();
            Session["tanggal"] = dtbl.Rows[0]["tanggal_masuk"].ToString();
            Session["tempat"] = dtbl.Rows[0]["tempat"].ToString();
            Session["ttl"] = dtbl.Rows[0]["ttl"].ToString();
        }

        void clear()
        {
            txtemail.Value = "";
            txtnama.Value = "";
            txttanggal.Value = "";
            txtnomor.Value = "";
            txttempat.Value = "";
            txtttl.Value = "";
        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}