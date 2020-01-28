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
            string idkonfig = Request.QueryString["idk"];
            string idlain = Request.QueryString["idl"];
            string idmutasi = Request.QueryString["idm"];
            string idfungsi = Request.QueryString["idf"];
            string idlog = Request.QueryString["idlog"];
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