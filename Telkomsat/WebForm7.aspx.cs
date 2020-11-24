using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime wib = DateTime.UtcNow + new TimeSpan(7, 0, 0);
            string waktu = wib.ToString("yyyy/MM/dd h:m:s");

            Response.Write(waktu);
        }
    }
}