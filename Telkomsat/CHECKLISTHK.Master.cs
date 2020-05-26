using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class CHECKLISTHK : System.Web.UI.MasterPage
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
            string tanggal;
            tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            lblProfile1.Text = Session["nama1"].ToString();
            aharian.Attributes["href"] = $"checkhk/dashboard.aspx?tanggal={tanggal}";
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}