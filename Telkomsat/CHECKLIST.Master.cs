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
            if (!IsPostBack)
            {
                if (Session["mastershelter"] != null)
                {
                    DropDownList1.Text = Session["mastershelter"].ToString();
                    DropDownList2.Text = Session["masterdivisi"].ToString();
                }
            }
        }

        protected void Pilih_Click(object sender, EventArgs e)
        {
            if (DropDownList2.Text == "Harkat")
            {
                if (DropDownList1.Text == "Telkom 2")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkatt2.aspx", false);
                }

                else if (DropDownList1.Text == "T3S Ku-Band")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkatt3sku.aspx", false);
                }
                else if (DropDownList1.Text == "T3S Ku-Band")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkatt3sku.aspx", false);
                }
                else if (DropDownList1.Text == "T3S C-Band")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkatt3sc.aspx", false);
                }
                else if (DropDownList1.Text == "FMA 11")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkatfma11.aspx", false);
                }
                else if (DropDownList1.Text == "HPA")
                {
                    Session["mastershelter"] = DropDownList1.Text;
                    Session["masterdivisi"] = DropDownList2.Text;
                    Response.Redirect("~/checklist/harkathpa.aspx", false);
                }

            }
        }
    }
}