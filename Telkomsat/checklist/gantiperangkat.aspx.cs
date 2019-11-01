using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.checklist
{
    public partial class gantiperangkat : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string IDdata = "kitaa";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();

            }

        }

        protected void Pilih_Click(object sender, EventArgs e)
        {
            if (DropDownList2.Text == "Harkat")
            {
                if (DropDownList1.Text == "Telkom 2")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkatt2.aspx", false);
                }

                else if (DropDownList1.Text == "T3S Ku-Band")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkatt3sku.aspx", false);
                }
                else if (DropDownList1.Text == "T3S Ku-Band")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkatt3sku.aspx", false);
                }
                else if (DropDownList1.Text == "T3S C-Band")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkatt3sc.aspx", false);
                }
                else if (DropDownList1.Text == "FMA 11")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkatfma11.aspx", false);
                }
                else if (DropDownList1.Text == "HPA")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkathpa.aspx", false);
                }

            }
        }

        protected void editsn(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand($"UPDATE check_perangkat SET [S/N] = '{txtSN.Text}' WHERE [S/N] = '{Session["snperangkat"].ToString()}'", con);
            cmd1.ExecuteNonQuery();
            con.Close();
            BindData();
            Response.Write(Session["snperangkat"].ToString());
        }

        private void BindData()
        {
            //SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM check_perangkat", con);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            htmlTable.Append("<table id=\"example1\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Perangkat</th><th>SN</th><th>Rack</th><th>Shelter</th><th>Edit</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string a = ds.Tables[0].Rows[i]["Perangkat"].ToString();
                        string b = a.Replace(' ', '#');
                        char[] array = a.ToCharArray();
                        for (int j = 0; j < a.Length; j++)
                        {
                            char let = array[j];
                            if (let == ' ')
                            {
                                array[j] = '+';
                            }
                        }
                        Session["snperangkat"] = ds.Tables[0].Rows[i]["S/N"];
                        string result = new string(array);
                        IDdata = ds.Tables[0].Rows[i]["ID_Perangkat"].ToString();
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["Perangkat"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["S/N"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["Rack"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["Shelter"] + "</td>");
                        htmlTable.Append("<td>" + "<button type=\"button\" data-toggle=\"modal\" data-target=\"#modal-default\" value='ID_Perangkat' class='btn btn-sm btn-success' id=aku onclick='test(this)' CommandArgument=");
                        htmlTable.Append((ds.Tables[0].Rows[i]["S/N"]) + "%" + b);
                        htmlTable.Append(" > Edit</button>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("<tfoot>");
                    htmlTable.Append("<tr><th>Perangkat</th><th>S/N</th><th>Rack</th><th>Shelter</th><th>Edit</th></tr>");
                    htmlTable.Append("</tfoot>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }
    }
}