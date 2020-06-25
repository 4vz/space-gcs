using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.datalogbook
{
    public partial class action : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string queryupdate, queryupdatel, queryupdatem, queryupdatef;
        protected void Page_Load(object sender, EventArgs e)
        {
            string idapprove = Request.QueryString["ida"];
            string idadmin = Request.QueryString["idadmin"];
            string hapus = Request.QueryString["hapus"];
            string idkonfig = Request.QueryString["idk"];
            string idlain = Request.QueryString["idl"];
            string idmain = Request.QueryString["idn"];
            string idmutasi = Request.QueryString["idm"];
            string idfungsi = Request.QueryString["idf"];
            string idlog = Request.QueryString["idlog"];
            string delete = Request.QueryString["del"];
            string tipe = Request.QueryString["tipe"];
            string fileid = Request.QueryString["fileid"];
            string filelain = Request.QueryString["idfilelain"];
            string filemain = Request.QueryString["idfilemain"];
            string filekonfig = Request.QueryString["idfilekonfig"];

            if (filelain != null)
            {
                string query = $"DELETE table_log_file WHERE id_file = '{filelain}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=L");
            }

            if (filemain != null)
            {
                string query = $"DELETE table_log_file WHERE id_file = '{filemain}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=N");
            }

            if (filekonfig != null)
            {
                string query = $"DELETE table_log_file WHERE id_file = '{filekonfig}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=K");
            }

            if (fileid != null)
            {
                string query = $"DELETE table_log_file WHERE id_file = '{fileid}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect($"../datalogbook/edit.aspx?idlog={idlog}");
            }

            if (delete != null)
            {
                string query = $"DELETE table_pekerjaan WHERE id_pekerjaan = '{delete}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();

                string querybef = $"select p.* from table_pekerjaan p left join tabel_logbook l on l.id_logbook=p.id_logbook where l.id_logbook = '{idlog}' and p.status = 'On Progress'";
                DataSet ds5 = new DataSet();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(querybef, sqlCon);
                SqlDataAdapter da5 = new SqlDataAdapter(cmd);
                da5.Fill(ds5);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                int output = ds5.Tables[0].Rows.Count;
                if (output == 0)
                {
                    queryupdatel = $"UPDATE tabel_logbook SET status = 'Selesai' WHERE id_logbook = '{idlog}'";
                    SqlCommand sqlcmd2 = new SqlCommand(queryupdatel, sqlCon);
                    sqlCon.Open();
                    sqlcmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }
                else
                {
                    queryupdatel = $"UPDATE tabel_logbook SET status = 'On Progress' WHERE id_logbook = '{idlog}'";
                    SqlCommand sqlcmd2 = new SqlCommand(queryupdatel, sqlCon);
                    sqlCon.Open();
                    sqlcmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }

                Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add={tipe}");
            }

            if (hapus != null)
            {
                string query = $"DELETE tabel_logbook WHERE id_logbook = '{hapus}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();

                string query1 = $"DELETE table_pekerjaan WHERE id_logbook = '{hapus}'";
                SqlCommand sqlcmd1 = new SqlCommand(query1, sqlCon);
                sqlCon.Open();
                sqlcmd1.ExecuteNonQuery();
                sqlCon.Close();
                Response.Redirect("../datalogbook/data.aspx");
            }
            if (idkonfig != null)
            {
                string query = $"UPDATE table_pekerjaan SET status = 'Selesai' WHERE id_pekerjaan = '{idkonfig}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();

                string querybef = $"select p.* from table_pekerjaan p left join tabel_logbook l on l.id_logbook=p.id_logbook where l.id_logbook = '{idlog}' and p.status = 'On Progress'";
                DataSet ds5 = new DataSet();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(querybef, sqlCon);
                SqlDataAdapter da5 = new SqlDataAdapter(cmd);
                da5.Fill(ds5);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                int output = ds5.Tables[0].Rows.Count;
                if (output == 0)
                {
                    queryupdate = $"UPDATE tabel_logbook SET status = 'Selesai' WHERE id_logbook = '{idlog}'";
                    SqlCommand sqlcmd2 = new SqlCommand(queryupdate, sqlCon);
                    sqlCon.Open();
                    sqlcmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }

                Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=K");
            }

            if (idapprove != null)
            {
                string query = $"UPDATE admindetail SET d_approve = 'approve' WHERE id_detail = '{idapprove}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();

                string querybef = $"select d.id_detail from administrator r left join admindetail d on d.id_admin=r.id_admin WHERE r.id_admin = '{idadmin}' and d.d_approve = 'not approve'";
                DataSet ds5 = new DataSet();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(querybef, sqlCon);
                SqlDataAdapter da5 = new SqlDataAdapter(cmd);
                da5.Fill(ds5);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                int output = ds5.Tables[0].Rows.Count;
                if (output == 0)
                {
                    queryupdate = $"UPDATE administrator SET status = 'approve' WHERE id_admin = '{idapprove}'";
                    SqlCommand sqlcmd2 = new SqlCommand(queryupdate, sqlCon);
                    sqlCon.Open();
                    sqlcmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }

                Response.Redirect($"../admin/approve.aspx");
            }

            if (idlain != null)
            {
                string query = $"UPDATE table_pekerjaan SET status = 'Selesai' WHERE id_pekerjaan = '{idlain}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();

                string querybef = $"select p.* from table_pekerjaan p left join tabel_logbook l on l.id_logbook=p.id_logbook where l.id_logbook = '{idlog}' and p.status = 'On Progress'";
                DataSet ds5 = new DataSet();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(querybef, sqlCon);
                SqlDataAdapter da5 = new SqlDataAdapter(cmd);
                da5.Fill(ds5);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                int output = ds5.Tables[0].Rows.Count;
                if (output == 0)
                {
                    queryupdatel = $"UPDATE tabel_logbook SET status = 'Selesai' WHERE id_logbook = '{idlog}'";
                    SqlCommand sqlcmd2 = new SqlCommand(queryupdatel, sqlCon);
                    sqlCon.Open();
                    sqlcmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }

                Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=l");
            }

            if (idmain != null)
            {
                string query = $"UPDATE table_pekerjaan SET status = 'Selesai' WHERE id_pekerjaan = '{idmain}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();

                string querybef = $"select p.* from table_pekerjaan p left join tabel_logbook l on l.id_logbook=p.id_logbook where l.id_logbook = '{idlog}' and p.status = 'On Progress'";
                DataSet ds5 = new DataSet();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(querybef, sqlCon);
                SqlDataAdapter da5 = new SqlDataAdapter(cmd);
                da5.Fill(ds5);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                int output = ds5.Tables[0].Rows.Count;
                if (output == 0)
                {
                    queryupdatel = $"UPDATE tabel_logbook SET status = 'Selesai' WHERE id_logbook = '{idlog}'";
                    SqlCommand sqlcmd2 = new SqlCommand(queryupdatel, sqlCon);
                    sqlCon.Open();
                    sqlcmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }

                Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=n");
            }

            if (idmutasi != null)
            {
                string query = $"UPDATE table_pekerjaan SET status = 'Selesai' WHERE id_pekerjaan = '{idmutasi}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();

                string querybef = $"select p.* from table_pekerjaan p left join tabel_logbook l on l.id_logbook=p.id_logbook where l.id_logbook = '{idlog}' and p.status = 'On Progress'";
                DataSet ds5 = new DataSet();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(querybef, sqlCon);
                SqlDataAdapter da5 = new SqlDataAdapter(cmd);
                da5.Fill(ds5);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                int output = ds5.Tables[0].Rows.Count;
                if (output == 0)
                {
                    queryupdatem = $"UPDATE tabel_logbook SET status = 'Selesai' WHERE id_logbook = '{idlog}'";
                    SqlCommand sqlcmd2 = new SqlCommand(queryupdatem, sqlCon);
                    sqlCon.Open();
                    sqlcmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }

                Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=m");
            }

            if (idfungsi != null)
            {
                string query = $"UPDATE table_pekerjaan SET status = 'Selesai' WHERE id_pekerjaan = '{idfungsi}'";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                sqlCon.Open();
                sqlcmd.ExecuteNonQuery();
                sqlCon.Close();

                string querybef = $"select p.* from table_pekerjaan p left join tabel_logbook l on l.id_logbook=p.id_logbook where l.id_logbook = '{idlog}' and p.status = 'On Progress'";
                DataSet ds5 = new DataSet();
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(querybef, sqlCon);
                SqlDataAdapter da5 = new SqlDataAdapter(cmd);
                da5.Fill(ds5);
                cmd.ExecuteNonQuery();
                sqlCon.Close();
                int output = ds5.Tables[0].Rows.Count;
                if (output == 0)
                {
                    queryupdatef = $"UPDATE tabel_logbook SET status = 'Selesai' WHERE id_logbook = '{idlog}'";
                    SqlCommand sqlcmd2 = new SqlCommand(queryupdatef, sqlCon);
                    sqlCon.Open();
                    sqlcmd2.ExecuteNonQuery();
                    sqlCon.Close();
                }

                Response.Redirect($"../datalogbook/detail.aspx?idlog={idlog}&add=f");
            }
        }
    }
}