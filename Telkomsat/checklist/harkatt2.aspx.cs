using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.checklist
{
    public partial class harkatt2 : System.Web.UI.Page
    {
        Nullable<int> i = null;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

            //sqlCmd.Parameters.AddWithValue("@ID", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
        }

        protected void Save_Click(object sender, EventArgs e)
        {

                string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
                string querytanggal = $"INSERT INTO check_tanggal(tanggal_check) VALUES ('{tanggal}') SELECT SCOPE_IDENTITY()";
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(querytanggal, sqlCon);
                i = Convert.ToInt32(cmd.ExecuteScalar());
                sqlCon.Close();
                Response.Write(i);


            string query = $@"INSERT INTO check_status(
                                ID_tgl, id_profile, ID_paramater, status, nilai
                            )
                            VALUES
                                (
                                    '{i}', '3','1', '{ddl1SD1.SelectedValue}', '' 
                                ),
                                (
                                    '{i}', '3', '2', '{ddl1HPA1.SelectedValue}', '' 
                                ),
                                (
                                    '{i}', '3', '3', '{ddl1UC1.SelectedValue}', '' 
                                ),
                                (
                                    '{i}', '3', '4', '{ddl1UC1.SelectedValue}', '{txtUC1fr.Text}' 
                                ),
                                (
                                    '{i}', '3', '5', '{ddl1UC1.SelectedValue}', '{txtUC1at.Text}' 
                                );";

            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            //sqlCmd.Parameters.AddWithValue("@ID", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));*/
        }
    }
}