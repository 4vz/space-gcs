using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("~/login.aspx");
        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }
    }
}