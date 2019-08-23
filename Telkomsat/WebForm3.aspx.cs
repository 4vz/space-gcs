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
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        //static int currentposition = 0;
        //static int totalrows = 0;
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnModal_ServerClick(object sender, EventArgs e)
        {

           //ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalButton').modal('show')", true);
        }
    }
}