using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;


namespace Telkomsat
{
    public static class HelpernyaWildan
    {

        public static bool IsIn(this string ygdicek, string[] daftar)
        {
            bool benarkah = false;

            foreach (string d in daftar)
            {
                if (ygdicek == d)
                {
                    benarkah = true;
                    break;
                }
            }

            return benarkah;
        }

        public static bool NotIsIn(this string ygdicek, string[] daftar)
        {
            bool benarkah = false;

            foreach (string d in daftar)
            {
                if (ygdicek != d)
                {
                    benarkah = true;
                    break;
                }
            }

            return benarkah;
        }

    }


    public partial class ASSET : System.Web.UI.MasterPage
    {
        string user;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Redirect("~/login.aspx", true);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            user = Session["username"].ToString();
            if (!IsPostBack)
            {

                sqlCon.Open();
                SqlDataAdapter sqlCmd = new SqlDataAdapter("ProViewByUser", sqlCon);
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd.SelectCommand.Parameters.AddWithValue("@user", user);
                DataTable dtbl1 = new DataTable();
                sqlCmd.Fill(dtbl1);
                dtContact1.DataSource = dtbl1;
                dtContact1.DataBind();
                //DataList2.DataSource = dtbl1;
                //DataList2.DataBind();
                sqlCon.Close();
            }
            string thisURL = Request.Url.Segments[Request.Url.Segments.Length - 1];

            if (Session["previllage"].ToString() == "adminme" || Session["previllage"].ToString() == "adminhk" || Session["previllage"].ToString() == "super"
                || Session["previllage"].ToString() == "bendahara")
            {
                divtambah.Visible = true;
                divadmin.Visible = true;
            }
                
            else
            {
                if (thisURL.ToLower().IsIn(new string[]{ "edit.aspx", "bangunan.aspx", "bangunanadd.aspx", "equipment.aspx", "rack.aspx", "rackadd.aspx",
                "ruangan.aspx", "ruanganadd.aspx", "site.aspx", "siteadd.aspx", "equipment.aspx", "equipmentadd.aspx", "device.aspx", "deviceadd.aspx"
                , "merk.aspx", "merkadd.aspx", "tambahdata.aspx"}))
                {
                    Response.Redirect("alldata.aspx");
                }


                /*if (thisURL.ToLower() == "edit.aspx" || thisURL.ToLower() == "bangunan.aspx" || thisURL.ToLower() == "bangunanadd.aspx" || thisURL.ToLower() == "equipment.aspx" ||
                    thisURL.ToLower() == "rack.aspx" || thisURL.ToLower() == "rackadd.aspx" || thisURL.ToLower() == "ruangan.aspx" || thisURL.ToLower() == "ruanganadd.aspx" ||
                    thisURL.ToLower() == "site.aspx" || thisURL.ToLower() == "siteadd.aspx" || thisURL.ToLower() == "equipmentadd.aspx" || thisURL.ToLower() == "device.aspx"
                    || thisURL.ToLower() == "deviceadd.aspx")
                    Response.Redirect("alldata.aspx");*/
            }
            sqlCon.Open();
            SqlDataAdapter sqlCmd2 = new SqlDataAdapter("ProViewByUser", sqlCon);
            sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd2.SelectCommand.Parameters.AddWithValue("@user", user);
            DataTable dtbl = new DataTable();
            sqlCmd2.Fill(dtbl);
            dtContact1.DataSource = dtbl;
            DataList1.DataSource = dtbl;
            DataList1.DataBind();

            //lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");


            lblProfile.Text = Session["nama1"].ToString();
            lblProfile1.Text = Session["nama1"].ToString();
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}