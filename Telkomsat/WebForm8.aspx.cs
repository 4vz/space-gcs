using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Telkomsat
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        StringBuilder htmlTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            string filepath = @"D:/MNVR_0283_EW/C.RECON/EW283_NM_2020_11_12.rcn02.rpt";
            List<string> data = System.IO.File.ReadAllLines(filepath).ToList();
            string[] array;
            htmlTable.Append("<table>");
            foreach (var datas in data)
            {
                string[] lines = Regex.Split(datas, ": ");
                htmlTable.Append("<tr>");

                foreach (var line in lines)
                {
                    if (datas != "")
                    {
                        htmlTable.Append("<td style=\"border: 1px solid black;\">" + line + "</td>");
                        
                    }

                }

                htmlTable.Append("</tr>");
            }
            htmlTable.Append("</table>");
            PlaceHolder1.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }
    }
}