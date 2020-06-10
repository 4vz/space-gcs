using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class MAINTENANCEHK : System.Web.UI.MasterPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Redirect("~/login.aspx", true);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblProfile1.Text = Session["nama1"].ToString();
            string tanggal;
            tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            string thisURL = Request.Url.Segments[Request.Url.Segments.Length - 2];
            if (thisURL.ToLower() == "bulanan/") divbulanan.Attributes.Add("class", "small-box bg-aqua-gradient");
            if (thisURL.ToLower() == "tigabulan/") divtiga.Attributes.Add("class", "small-box bg-aqua-gradient");
            if (thisURL.ToLower() == "semester/") divsemester.Attributes.Add("class", "small-box bg-aqua-gradient");
            if (thisURL.ToLower() == "tahunan/") divtahun.Attributes.Add("class", "small-box bg-aqua-gradient");
            aharian.Attributes["href"] = $"checkhk/dashboard.aspx?tanggal={tanggal}";
            abjm.Attributes["href"] = $"checkbjm/dashboardbjm.aspx?tanggal={tanggal}";
            //Response.Write(thisURL);
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}