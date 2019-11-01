using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.ticket
{
    public partial class tambah : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string radio, divisiuser;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["jenis1"].ToString() == "tcc")
              //  spam.Style["display"] = "none";

        }

        protected void submitbtn(object sender, EventArgs e)
        {
            //optionsRadios1.Checked = true;
            if (Request.Form["optionsRadios"] != null)
                radio = Request.Form["optionsRadios"].ToString();

            divisiuser = Session["jenis1"].ToString();

            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand($@"INSERT INTO ticket_user (nama_user, tanggal, nomor_hp, subject, keterangan, prioritas, status, statusticket, divisiuser)
                                            VALUES ('{nama.Value}','{datetime1}', '{nomor.Value}', '{subject.Value}', '{keterangan.Value}', '{radio}', 'sent', 'ready', '{divisiuser}')", sqlCon);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            lblstatus.Visible = true;
            lblstatus.Text = " (Ticket Terkirim)";
            lblstatus.ForeColor = System.Drawing.Color.LawnGreen;
        }
    }
}