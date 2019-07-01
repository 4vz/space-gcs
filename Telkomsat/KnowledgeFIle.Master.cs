using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class KnowledgeFIle : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
               Response.Redirect("~/login.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }
    }
}
