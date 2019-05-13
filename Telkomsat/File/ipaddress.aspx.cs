using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.File
{
    public partial class ipaddress : System.Web.UI.Page
    {
        string mystring;
        string sorting;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["cari"] == null)
                {
                    GridBindFile();
                }

                else
                {
                    session();
                }

                rbcbi.Checked = true;
                rbasc.Checked = true;
            }
            if (Session["cari"] == null && txtMaster.Value == "")
            {
                GridBindFile();
            }

            else
            {
                session();
            }

        }

        protected void btnPosting_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/semua.aspx");
        }

        protected void btnFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/dashboard.aspx");
        }

        public void GridBindFile()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("AdViewCBI", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (urutkan.Value == "Host" && rbasc.Checked)
                sorting = "NAMAASC";
            else if (urutkan.Value == "Host" && rbdesc.Checked)
                sorting = "NAMADESC";
            else if (urutkan.Value == "Description" && rbasc.Checked)
                sorting = "WAKTUASC";
            else if (urutkan.Value == "Description" && rbdesc.Checked)
                sorting = "WAKTUDESC";
            else if (urutkan.Value == "IP_Address" && rbasc.Checked)
                sorting = "KATEGORIASC";
            else if (urutkan.Value == "IP_Address" && rbdesc.Checked)
                sorting = "KATEGORIDESC";
            else
                sorting = "";

            cmd.Parameters.AddWithValue("@SORT", sorting);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvFile.DataSource = ds;
                gvFile.DataBind();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //session();
        }

        void session()
        {
            

            if (txtMaster.Value == "")
            {
                if (!IsPostBack)
                    mystring = Session["cari"] as string;
                else
                    mystring = "";
            }

            else if(txtMaster.Value != null)
            {
                mystring = txtMaster.Value;
            }
            string[] split = mystring.Split(new char[] { ' ', '\t' });
            string kata1 = split[0];
            string kata2, kata3, kata4, kata5, kata6;
            //lblPage.Text = split[3];
            if (split.Length < 2)
                kata2 = "";
            else
                kata2 = split[1];

            if (split.Length < 3)
                kata3 = "";
            else
                kata3 = split[2];

            if (split.Length < 4)
                kata4 = "";
            else
                kata4 = split[3];

            if (split.Length < 5)
                kata5 = "";
            else
                kata5 = split[4];

            if (split.Length < 6)
                kata6 = "";
            else
                kata6 = split[5];

            con.Open();
            SqlCommand cmd = new SqlCommand("AdSearchCBI", con);
            if (urutkan.Value == "Host" && rbasc.Checked)
                sorting = "NAMAASC";
            else if (urutkan.Value == "Host" && rbdesc.Checked)
                sorting = "NAMADESC";
            else if (urutkan.Value == "Description" && rbasc.Checked)
                sorting = "WAKTUASC";
            else if (urutkan.Value == "Description" && rbdesc.Checked)
                sorting = "WAKTUDESC";
            else if (urutkan.Value == "IP_Address" && rbasc.Checked)
                sorting = "KATEGORIASC";
            else if (urutkan.Value == "IP_Address" && rbdesc.Checked)
                sorting = "KATEGORIDESC";
            else
                sorting = "";

            cmd.Parameters.AddWithValue("@SORT", sorting);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kata1", kata1);
            cmd.Parameters.AddWithValue("@kata2", kata2);
            cmd.Parameters.AddWithValue("@kata3", kata3);
            cmd.Parameters.AddWithValue("@kata4", kata4);
            cmd.Parameters.AddWithValue("@kata5", kata5);
            cmd.Parameters.AddWithValue("@kata6", kata6);
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sqlda.Fill(dt);
            gvFile.DataSource = dt;
            gvFile.DataBind();
            con.Close();
        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/tambahip1.aspx");
        }

        protected void btnurut_click(object sender, EventArgs e)
        {
            if (txtMaster.Value == null)
            {
                GridBindFile();
            }

            else if (txtMaster.Value != null)
            {
                session();
            }
        }

        protected void btnip_click(object sender, EventArgs e)
        {
            if (rbt2.Checked)
                Response.Redirect("~/File/ippass.aspx");
            else if (rbbjm.Checked)
                Response.Redirect("~/File/ipbjm.aspx");
        }

        protected void Ink_OnClick1(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("AdViewID", con);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            con.Close();
            hfContactID.Value = ID.ToString();
            Session["hf"] = hfContactID.Value;
            //Response.Redirect("~/details.aspx?equ=" + dtbl.Rows[0]["Equipment"].ToString() + "merk=" + dtbl.Rows[0]["Merk"].ToString());
            Session["Host"] = dtbl.Rows[0]["HOST_NAME"].ToString();
            Session["Description"] = dtbl.Rows[0]["DESCRIPTION"].ToString();
            Session["Supplier"] = dtbl.Rows[0]["SUPPLIER"].ToString();
            Session["IP"] = dtbl.Rows[0]["IP_ADDRESS"].ToString();
            Session["Comment"] = dtbl.Rows[0]["COMMENT"].ToString();
            Session["Installation"] = dtbl.Rows[0]["INSTALLATION"].ToString();

            //Response.Redirect("~/details.aspx?" + dtbl.Rows[0]["Merk"].ToString());
            Response.Redirect("~/File/editad.aspx");

        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvFile.PageIndex = e.NewPageIndex;
            gvFile.DataBind();
        }

        protected void gvContact_PreRender(object sender, EventArgs e)
        {
            lblPage.Text = "Menampilkan halaman " + (gvFile.PageIndex + 1).ToString() + " dari " + gvFile.PageCount.ToString();
        }
    }
}