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