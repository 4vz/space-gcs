using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class CHECKLISTME : System.Web.UI.MasterPage
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
            if (!IsPostBack)
            {
                if (Session["mastershelterme"] != null)
                {
                    DropDownList1.Text = Session["mastershelterme"].ToString();
                }
            }
            lblProfile1.Text = Session["nama1"].ToString();

            string thisURL = Request.Url.Segments[Request.Url.Segments.Length - 1];
            if (thisURL.ToLower() == "checkharian.aspx") divddl.Visible = false;
            if (thisURL.ToLower() == "dataharian.aspx") divddl.Visible = false;
        }

        protected void Pilih_Click(object sender, EventArgs e)
        {
            Session["mastershelterme"] = DropDownList1.Text;
            Response.Redirect($"~/checklistme/harian.aspx?room={DropDownList1.SelectedValue}", false);
            Session["inisial"] = null;
        }

    }
}