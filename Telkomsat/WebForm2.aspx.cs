using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Write(txtLokasi.Text);
            if (Request.Form["icon"] != null)
            {
                string pilihicon = Request.Form["icon"].ToString();
                Response.Write(pilihicon);
            }
        }
    }
}