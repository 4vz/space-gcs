﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.superadmin
{
    public partial class action : System.Web.UI.Page
    {
        string user;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string appch = Request.QueryString["approvalch"];
            string tanggal = Request.QueryString["tanggal"];
            string waktu = Request.QueryString["waktu"];
            string filemain = Request.QueryString["idfilemain"];
            string filekonfig = Request.QueryString["idfilekonfig"];
            string petugas = Request.QueryString["petugas"];

            string queryuser;

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            queryuser = $"select alias from Profile where user_name='{Session["username"].ToString()}'";
            SqlCommand cmd2 = new SqlCommand(queryuser, sqlCon);
            sqlCon.Open();
            da = new SqlDataAdapter(cmd2);
            da.Fill(ds);
            sqlCon.Close();
            user = ds.Tables[0].Rows[0]["alias"].ToString();
            if (appch == "harkat")
            {
                string queryupdate;
                queryupdate = $"UPDATE checkhk_data SET approval = 'approve', pic = '{user}' where tanggal >= '{tanggal} 00:00:00' and tanggal <= '{tanggal} 23:59:59' and lokasi = 'cbi'";
                SqlCommand sqlcmd2 = new SqlCommand(queryupdate, sqlCon);
                sqlCon.Open();
                sqlcmd2.ExecuteNonQuery();
                sqlCon.Close();
                string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
                string querylog = $@"Insert into log (pic, tanggal, tipe, judul) values
                                ('{user}', '{tanggalku}', 'app', '{tanggal}')";
                sqlCon.Open();
                SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
                cmdlog.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("approve.aspx");
            }

            if (appch == "harkatit")
            {
                string queryupdate;
                queryupdate = $"UPDATE checkhk_data SET approval = 'approve', pic = '{user}' where tanggal >= '{tanggal} 00:00:00' and tanggal <= '{tanggal} 23:59:59' and lokasi = 'itcbi'";
                SqlCommand sqlcmd2 = new SqlCommand(queryupdate, sqlCon);
                sqlCon.Open();
                sqlcmd2.ExecuteNonQuery();
                sqlCon.Close();
                string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
                string querylog = $@"Insert into log (pic, tanggal, tipe, judul) values
                                ('{user}', '{tanggalku}', 'app', '{tanggal}')";
                sqlCon.Open();
                SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
                cmdlog.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("approve.aspx");
            }

            if (appch == "harkatbjm")
            {
                string queryupdate;
                queryupdate = $"UPDATE checkhk_data SET approval = 'approve', pic = '{user}' where tanggal >= '{tanggal} 00:00:00' and tanggal <= '{tanggal} 23:59:59' and lokasi = 'bjm'";
                SqlCommand sqlcmd2 = new SqlCommand(queryupdate, sqlCon);
                sqlCon.Open();
                sqlcmd2.ExecuteNonQuery();
                sqlCon.Close();
                string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
                string querylog = $@"Insert into log (pic, tanggal, tipe, judul) values
                                ('{user}', '{tanggalku}', 'app', '{tanggal}')";
                sqlCon.Open();
                SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
                cmdlog.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("approve.aspx");
            }

            if (appch == "me")
            {
                string queryupdate;
                queryupdate = $"UPDATE checkme_data SET approve = 'approve', pic = '{user}' where tanggal = '{tanggal}' and waktu='{waktu}'";
                SqlCommand sqlcmd2 = new SqlCommand(queryupdate, sqlCon);
                sqlCon.Open();
                sqlcmd2.ExecuteNonQuery();
                sqlCon.Close();
                string tanggalku = DateTime.Now.ToString("yyyy/MM/dd");
                string querylog = $@"Insert into log (pic, tanggal, tipe, judul, keterangan) values
                                ('{user}', '{tanggalku}', 'appme', '{tanggal}', '{waktu}')";
                sqlCon.Open();
                SqlCommand cmdlog = new SqlCommand(querylog, sqlCon);
                cmdlog.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("checklistme.aspx");
            }
        }
    }
}