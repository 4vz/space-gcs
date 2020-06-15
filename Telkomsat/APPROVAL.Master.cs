using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat
{
    public partial class APPROVAL : System.Web.UI.MasterPage
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string query, querychme, divisi, user;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Redirect("~/login.aspx", true);
            }

            string queryuser;

            SqlDataAdapter da;
            DataSet ds = new DataSet();
            queryuser = $"select approval from Profile where user_name='{Session["username"].ToString()}'";
            SqlCommand cmd2 = new SqlCommand(queryuser, sqlCon);
            sqlCon.Open();
            da = new SqlDataAdapter(cmd2);
            da.Fill(ds);
            sqlCon.Close();

            if (ds.Tables[0].Rows[0]["approval"].ToString() == null || ds.Tables[0].Rows[0]["approval"].ToString() == "")
                Response.Redirect("../dashboard2.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            user = Session["nama1"].ToString();
            string thisURL = Request.Url.Segments[Request.Url.Segments.Length - 1];
            if (thisURL.ToLower() == "approve.aspx") lichhk.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "checklistme.aspx") lichme.Attributes.Add("class", "active");

            query = $@"with cte as (select (CAST(d.tanggal AS DATE)) as tanggal, p.nama from checkhk_data d left join Profile p on d.id_profile = p.id_profile
						join checkhk_parameter r on r.id_parameter=d.id_parameter where d.approval is null or d.approval = '' 
						group by CAST(d.tanggal AS DATE), nama)
						select COUNT(*) as total from cte";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            string output = cmd.ExecuteScalar().ToString();
            sqlCon.Close();

            querychme = $@"with cte as (select d.tanggal, p.nama, d.waktu from checkme_data d inner join Profile p on d.id_profile = p.id_profile
						where approve is null or approve = ''
                        group by tanggal, nama, d.waktu)
						select COUNT(*) as total from cte";
            sqlCon.Open();
            SqlCommand cmd2 = new SqlCommand(querychme, sqlCon);
            string output2 = cmd2.ExecuteScalar().ToString();
            sqlCon.Close();

            lblchhk.Text = output;
            lblchme.Text = output2;
            lblProfile1.Text = user;
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}