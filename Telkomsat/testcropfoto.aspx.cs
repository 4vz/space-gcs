using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using Image = System.Drawing.Image;

namespace Telkomsat
{
    public partial class testcropfoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string filename = "full badan.jpg";
            string filepath = Path.Combine(Server.MapPath("~/image"), filename);
            Image outputfile = Image.FromFile(filepath);
            Rectangle cropcoordinate = new Rectangle(Convert.ToInt32(coordinate_x.Value), Convert.ToInt32(coordinate_y.Value), Convert.ToInt32(coordinate_w.Value), Convert.ToInt32(coordinate_h.Value));
            string confilename, confilepath;
            Bitmap bitmap = new Bitmap(cropcoordinate.Width, cropcoordinate.Height, outputfile.PixelFormat);
            Graphics grapics = Graphics.FromImage(bitmap);
            grapics.DrawImage(outputfile, new Rectangle(0, 0, bitmap.Width, bitmap.Height), cropcoordinate, GraphicsUnit.Pixel);
            confilename = "Crop_" + filename;
            confilepath = Path.Combine(Server.MapPath("~/cropimag"), confilename);
            bitmap.Save(confilepath);
            cropimg.Visible = true;
            cropimg.Src = "~/cropimag/" + confilename;


        }
    }
}