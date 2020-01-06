using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat.checklistme
{
    public partial class checklist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*TimeSpan start = new TimeSpan(10, 0, 0); //10 o'clock
            TimeSpan end = new TimeSpan(11, 0, 0); //12 o'clock
            TimeSpan now = DateTime.Now.TimeOfDay;
            if ((now > start) && (now < end))
            {
                Response.Write(start);
                Response.Write(end);
                Response.Write(now);*/
                //match found
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Button1.OnClientClick = "return fungsiku()";
            /*if(DropDownList1.Text == "aku")
                this.Button1.OnClientClick = "return fungsiku()";
            else
                this.Button1.OnClientClick = "return fungsimu()";*/

            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsimu()", true);
        }
    }
}