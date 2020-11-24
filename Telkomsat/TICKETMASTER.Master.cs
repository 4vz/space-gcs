using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace Telkomsat
{
    public partial class TICKETMASTER : System.Web.UI.MasterPage
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string query, divisi, user, jenis;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["username"] == null ||Session["username"].ToString() == "")
            {
                Response.Redirect("~/login.aspx", true);
            }
                divisi = Session["jenis1"].ToString();
            

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (divisi == "tcc")
            {
                spam.Style["display"] = "none";
                licomplete.Style["display"] = "none";
            }

            lblProfile1.Text = Session["nama1"].ToString();

            if (divisi == "os" || divisi == "og")
            {
                query = $"SELECT COUNT(*) FROM ticket_user WHERE statusticket='unread' and divisireply != '{divisi}'";
            }
            else
            {
                query = $"SELECT COUNT(*) FROM ticket_user WHERE statusticket='unread' and divisireply != '{divisi}' and divisiuser = '{divisi}'";
            }
            
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            string output = cmd.ExecuteScalar().ToString();
            sqlCon.Close();
            if (output == "0")
                spnnotif.Visible = false;

            lblnotif.Text = output;
            string thisURL = Request.Url.Segments[Request.Url.Segments.Length - 1];
            if (thisURL.ToLower() == "ticket.aspx") liticket.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "tambahticket.aspx") liticket.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "accepted.aspx") liaccept.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "complete.aspx") licomplete.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "reject.aspx") lireject.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "spam.aspx") spam.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "favorit.aspx") lifavorit.Attributes.Add("class", "active");

            user = Session["username"].ToString();
            lblProfile1.Text = Session["nama1"].ToString();

            jenis = Session["jenis1"].ToString();

            if(jenis=="SCO" || jenis == "SCA" || jenis == "ORBITAL" || jenis == "STS")
            {
                adduser.Visible = true;
            }

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
        }
    }
}