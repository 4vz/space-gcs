using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.password
{
    public partial class semuahardware : System.Web.UI.Page
    {
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


                rbasc.Checked = true;
                rbhard.Checked = true;
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
            SqlCommand cmd = new SqlCommand("PassView", con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (urutkan.Value == "Nama" && rbasc.Checked)
                sorting = "NAMAASC";
            else if (urutkan.Value == "Nama" && rbdesc.Checked)
                sorting = "NAMADESC";
            else if (urutkan.Value == "Lokasi" && rbasc.Checked)
                sorting = "LOKASIASC";
            else if (urutkan.Value == "Lokasi" && rbdesc.Checked)
                sorting = "LOKASIDESC";
            else
                sorting = "";

            cmd.Parameters.AddWithValue("@SORT", sorting);
            cmd.Parameters.AddWithValue("@jenis", "Hardware");
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
            session();
        }

        void session()
        {
            string mystring;

            if (txtMaster.Value == "")
            {
                if (!IsPostBack)
                    mystring = Session["cari"] as string;
                else
                    mystring = "";
            }

            else
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
            SqlCommand cmd = new SqlCommand("PassViewSort", con);
            if (urutkan.Value == "Nama" && rbasc.Checked)
                sorting = "NAMAASC";
            else if (urutkan.Value == "Nama" && rbdesc.Checked)
                sorting = "NAMADESC";
            else if (urutkan.Value == "Lokasi" && rbasc.Checked)
                sorting = "LOKASIASC";
            else if (urutkan.Value == "Lokasi" && rbdesc.Checked)
                sorting = "LOKASIDESC";
            else
                sorting = "";

            cmd.Parameters.AddWithValue("@jenis", "Hardware");
            cmd.Parameters.AddWithValue("@SORT", sorting);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kata1", kata1);
            cmd.Parameters.AddWithValue("@kata2", kata2);
            cmd.Parameters.AddWithValue("@kata3", kata3);
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
            Response.Redirect("~/password/tambah.aspx");
        }

        protected void btnurut_click(object sender, EventArgs e)
        {
            session();
        }

        protected void Ink_OnClick1(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("PassViewID", con);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            con.Close();
            hfContactID.Value = ID.ToString();
            Session["id"] = hfContactID.Value;
            //Response.Redirect("~/details.aspx?equ=" + dtbl.Rows[0]["Equipment"].ToString() + "merk=" + dtbl.Rows[0]["Merk"].ToString());
            Session["nama"] = dtbl.Rows[0]["Nama"].ToString();
            Session["lokasi"] = dtbl.Rows[0]["Lokasi"].ToString();
            Session["jenis"] = dtbl.Rows[0]["Jenis"].ToString();
            Session["hostname"] = dtbl.Rows[0]["Hostname"].ToString();
            Session["username"] = dtbl.Rows[0]["Username"].ToString();
            Session["password"] = dtbl.Rows[0]["Password"].ToString();

            //Response.Redirect("~/details.aspx?" + dtbl.Rows[0]["Merk"].ToString());
            Response.Redirect("~/password/edit.aspx");

        }

        protected void btnip_click(object sender, EventArgs e)
        {
            if (rbsoft.Checked)
                Response.Redirect("~/password/semuasoftware.aspx");
        }
    }
}