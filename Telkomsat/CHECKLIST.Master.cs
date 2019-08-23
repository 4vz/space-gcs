using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telkomsat
{
    public partial class CHECKLIST : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["mastershelter"] != null)
            {
                DropDownList1.Text = Session["mastershelter"].ToString();
                DropDownList2.Text = Session["masterdivisi"].ToString();
            }
        }

        protected void Pilih_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "Telkom 2" && DropDownList2.Text == "Harkat")
            {
                Session["mastershelter"] = DropDownList1.Text;
                Session["masterdivisi"] = DropDownList2.Text;
                Response.Redirect("~/checklist/harkatt2.aspx", false);
            }

            if (DropDownList1.Text == "T3S Ku-Band" && DropDownList2.Text == "Harkat")
            {
                Session["mastershelter"] = DropDownList1.Text;
                Session["masterdivisi"] = DropDownList2.Text;
                Response.Redirect("~/checklist/harkatt3sku.aspx", false);
            }
        }
    }
}