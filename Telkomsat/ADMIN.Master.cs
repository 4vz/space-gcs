using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class ADMIN : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            string thisURL = Request.Url.Segments[Request.Url.Segments.Length - 1];
            if (thisURL.ToLower() == "dashboard.aspx") lidashboard.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pemasukan.aspx") lipemasukan.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pengeluaran.aspx") lipengeluaran.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pemindahan.aspx") lipemindahan.Attributes.Add("class", "active");
            if (thisURL.ToLower() == "pengembalian.aspx") lipengembalian.Attributes.Add("class", "active");
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/login.aspx");
        }
    }
}