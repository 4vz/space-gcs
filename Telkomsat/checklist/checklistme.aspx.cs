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
    public partial class cheklistme : System.Web.UI.Page
    {
        int i;
        string result = null;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            string query1 = $@"SELECT NAMA, MERK, MODEL, [S/N] FROM Asset1
            WHERE GUDANG = 'T2' AND FUNGSI = 'OPERASIONAL' ";

            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            gvPerangkat.DataSource = dt;
            gvPerangkat.DataBind();
            sqlCon.Close();

            /*GridView grid = (GridView)PreviousPage.FindControl("gvPerangkat");
            txtt3ca4po.Text = grid.SelectedRow.Cells[2].Text;
            txtt3ca4polv.Text = grid.SelectedRow.Cells[3].Text;
            if (!IsPostBack)
            {
                /*if(HttpContext.Current != null)
                {
                    string link = (HttpContext.Current.Request.Url.PathAndQuery);
                    string parse = link.Remove(0, 28);
                    //char[] array = parse.ToCharArray();
                    /*for (int i = 0; i < array.Length; i++)
                    {
                        char let = array[i];
                        if (let == '-')
                        {
                            array[i] = ' ';
                        }
                    }
                    result = parse.Replace("%20", " ");
                    Response.Write(result);
                }*/   
            
        }

        protected void Pilih_Click(object sender, EventArgs e)
        {
            
            if (DropDownList1.Text == "T3S C-Band" && DropDownList2.Text == "Harkat")
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

        protected void gvPerangkat_RowEditing(object sender, GridViewEditEventArgs e)
        {
            txtt3ca4po.Text = gvPerangkat.Rows[e.NewEditIndex].Cells[1].Text.ToString();
            Response.Write(gvPerangkat.Rows[e.NewEditIndex].Cells[1].Text.ToString());
        }
    }
}