using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Telkomsat
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;//yourdatetime
            int weekOfMonth = (dt.Day + ((int)dt.DayOfWeek)) / 7 + 1;
            DateTime firstDay = new DateTime(DateTime.Now.Year, 1, 1);
            bool isItFirstMonday = DateTime.Today.DayOfWeek == DayOfWeek.Monday
                         && DateTime.Today.Day <= 7;

            DateTime dta = new DateTime(2020, 6, 7);
            while (dta.DayOfWeek != DayOfWeek.Monday)
            {
                dta = dta.AddDays(1);
            }
            var mulai = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            var selesai = DateTime.Today.AddDays(+(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            string week1 = mulai.ToString("yyyy/MM/dd");
            string week2 = selesai.ToString("yyyy/MM/dd");
            Response.Write("mulai : " + dta.ToString("dd/MM/yyyy") + "           akhir : " + (int)DayOfWeek.Monday);

            Response.Write("  mli " + (Convert.ToInt32(DateTime.Now.DayOfYear) - (Convert.ToInt32(dta.ToString("dd")))) / 7);
        }

        protected void Upload(object sender, EventArgs e)
        {
            //Access the File using the Name of HTML INPUT File.
            HttpPostedFile postedFile = Request.Files["FileUpload"];

            //Check if File is available.
            if (postedFile != null && postedFile.ContentLength > 0)
            {
                //Save the File.
                string filePath = Server.MapPath("~/fileupload/") + Path.GetFileName(postedFile.FileName);
                postedFile.SaveAs(filePath);
                lblMessage.Visible = true;
                //Response.Write(postedFile.FileName);
            }

            //Response.Write(postedFile.ContentLength);
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string [] myket = new string[Request.Files.Count];
            int a = 0;
            try
            {
                string nominal = Request.Form["caption"];
                if (nominal != null)
                {
                    string[] lines = Regex.Split(nominal, ",");

                    foreach (string line in lines)
                    {
                        myket[a] = line;
                        a++;
                    }
                }
                HttpFileCollection filecolln = Request.Files;
                for (int i = 0; i < filecolln.Count; i++)
                {
                    HttpPostedFile file = filecolln[i];
                    if (file.ContentLength > 0)
                    {
                        //file.SaveAs(Server.MapPath("~/fileupload/") + Path.GetFileName(file.FileName));
                        string filename = Path.GetFileName(file.FileName);
                        Response.Write(filename + "  " + myket[i]);
                    }
                }
                lblMessage.Text = "Uploaded Successfully!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}