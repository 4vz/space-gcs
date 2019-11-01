using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat.ticket
{
    public partial class download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string file = Request.QueryString["file"];
            Response.Write(file);
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename="
                + file);
            Response.TransmitFile(Server.MapPath("~/affident/")
                + file);
            Response.End();
        }
    }
}