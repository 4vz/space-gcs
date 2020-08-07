﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.admin
{
    public partial class action : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string queryupdate, queryupdatel, queryapp2, queryapp;
        protected void Page_Load(object sender, EventArgs e)
        {
            string hapusreferensi = Request.QueryString["idref"];
            string kategori = Request.QueryString["kategori"];
            string jenis = Request.QueryString["jenis"];
            string jenissa = Request.QueryString["jenissa"];
            string idapp = Request.QueryString["idapp"];
            string idrk = Request.QueryString["idrk"];
            string idven = Request.QueryString["idven"];

            if (hapusreferensi != null)
            {
                string query = $"DELETE AdminReference WHERE AR_ID = '{hapusreferensi}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"../admin/reference.aspx?kategori={kategori.ToString()}");
            }

            if (jenis != null)
            {
                if(jenis == "diajukan")
                {
                    queryapp = $"UPDATE AdminJustifikasi SET AJ_Status = 'diajukan' WHERE AJ_ID = '{idapp}'";
                    string tgl = DateTime.Now.ToString("yyyy/MM/dd");
                    string queryapprove = $@"INSERT INTO AdminApprove (AA_Tanggal, AA_Aksi, AA_AJ, AA_Person)
                                        VALUES ('{tgl}', 'diajukan', '{idapp}', 'User')";

                    SqlCommand cmd = Settings.ExNonQuery(queryapprove);
                }
                else if (jenis == "manager")
                {
                    queryapp = $"UPDATE AdminJustifikasi SET AJ_Status = 'manager' WHERE AJ_ID = '{idapp}'";
                }
                else if (jenis == "gm")
                {
                    queryapp = $"UPDATE AdminJustifikasi SET AJ_Status = 'gm' WHERE AJ_ID = '{idapp}'";
                }
                else if (jenis == "admin")
                {
                    queryapp = $"UPDATE AdminJustifikasi SET AJ_Status = 'admin' WHERE AJ_ID = '{idapp}'";
                }

                SqlCommand sqlcmd = new SqlCommand(queryapp, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"../admin/approvement.aspx?jenis={jenis}");
            }

            if (jenissa != null)
            {
                if (jenissa == "ajukan")
                {
                    queryapp2 = $"UPDATE AdminJustifikasi SET AJ_Status = 'diajukan' WHERE AJ_ID = '{idapp}'";
                    string tgl = DateTime.Now.ToString("yyyy/MM/dd");
                    string queryapprove = $@"INSERT INTO AdminApprove (AA_Tanggal, AA_Aksi, AA_AJ, AA_Person)
                                        VALUES ('{tgl}', 'diajukan', '{idapp}', 'User')";

                    SqlCommand cmd = Settings.ExNonQuery(queryapprove);
                }
                else if (jenissa == "gm")
                {
                    queryapp2 = $"UPDATE AdminJustifikasi SET AJ_Status = 'gm' WHERE AJ_ID = '{idapp}'";
                }

                SqlCommand sqlcmd = new SqlCommand(queryapp2, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"../admin/approvementsa.aspx");
            }

            if (idrk != null)
            {
                string query = $"DELETE AdminRKAP WHERE ARK_ID = '{idrk}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"../admin/listrkap.aspx");
            }

            if (idven != null)
            {
                string query = $"DELETE AdminVendor WHERE AV_ID = '{idven}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"../admin/listvendor.aspx");
            }
        }
    }
}