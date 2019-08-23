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
    public partial class checklist : System.Web.UI.Page
    {
        int i;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Pilih_Click(object sender, EventArgs e)
        {
            if(DropDownList2.Text == "ME")
            {
                Response.Redirect($"~/checklist/checklistme.aspx?{DropDownList1.Text}");
            }
            if(DropDownList1.Text == "T3S C-Band" && DropDownList2.Text== "Harkat")
            {
                T3SHarkat.Visible = true;
                T3SKUHarkat.Visible = false;
            }
            else if (DropDownList1.Text == "T3S Ku-Band" && DropDownList2.Text == "Harkat")
            {
                T3SKUHarkat.Visible = true;
                T3SHarkat.Visible = false;
            }
            else
            {
                T3SHarkat.Visible = false;
                T3SKUHarkat.Visible = false;
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string tanggal = DateTime.Now.ToString("dd/MM/yyyy");
                string querytanggal = $"INSERT INTO check_tanggal(tanggal_check) VALUES ('{tanggal}') SELECT SCOPE_IDENTITY()";
                sqlCon.Open();
                SqlCommand cmd = new SqlCommand(querytanggal, sqlCon);
                i = Convert.ToInt32(cmd.ExecuteScalar());
                sqlCon.Close();
            }

            string query = $@"INSERT INTO check_status(
                                ID_tgl, id_profile, ID_paramater, status, nilai
                            )
                            VALUES
                                (
                                    '{i}', '3','1', '{Request.Form["rbt3ca4po"]}', '{txtt3ca4po.Text}' 
                                ),
                                (
                                    '{i}', '3', '2', '{Request.Form["rbt3ca4post"]}', '{txtt3ca4post.Text}' 
                                ),
                                (
                                    '{i}', '3', '3', '{Request.Form["rbt3ca4polv"]}', '{txtt3ca4polv.Text}' 
                                );";

            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            //sqlCmd.Parameters.AddWithValue("@ID", (hfContactID.Value == "" ? 0 : Convert.ToInt32(hfContactID.Value)));
        }

        protected void check_Click(object sender, EventArgs e)
        {
            rbt3ca4po1.Checked = true;
            rbt3ca4polv1.Checked = true;
            rbt3ca4post1.Checked = true;
        }
    }
}