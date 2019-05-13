using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class LOGBOOK : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            if (Session["user"] == null)
                Response.Redirect("~/login.aspx");
        }
    }
}