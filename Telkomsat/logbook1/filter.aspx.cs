using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.logbook1
{
    public partial class filter : System.Web.UI.Page
    {
        string strBulan = "";
        string strTahun = "";
        string strUnit = "";
        string strKategori = "";
        string strStatus = "";
        string strBulanNama;
        string[] jenis1 = new string[5];
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        //SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=GCS; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGridView();
                sqlCon.Close();
            }
            fillGridView();
        }

        void fillGridView()
        {
            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            string parse = link.Remove(0, 25);
            string parse2 = link.Remove(0, 28);
            string jenis = link.Substring(25, 2);

            char[] array = parse2.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                char let = array[i];
                if (let == '+')
                {
                    array[i] = ' ';
                }
            }

            string parse1 = new string(array);
            //string jenis = link.Substring(link.Length - 10, 2);
            //string jenis = parse.Remove(parse.Length - 8);
            if (jenis == "10")
            {
                strBulan = parse1.Remove(parse1.Length - 5);
                strTahun = link.Remove(0, 31);
                
            }
            else if (jenis == "11")
            {
                
                strUnit = parse1;
                
            }
            else if (jenis == "12")
            {
               
                strKategori = parse1;
                
            }
            else if (jenis == "13")
            {
                
                strStatus = parse1;
         
            }


            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            //string queryequipment = "SELECT * FROM Invest WHERE EQUIPMENT LIKE '%' + @Equipment + '%'";
            SqlCommand sqlcmd = new SqlCommand("LoFilter", sqlCon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            if (strTahun != "")
            {
                sqlcmd.Parameters.AddWithValue("@tahun", strTahun);
            }
            if (strBulan != "")
            {
                sqlcmd.Parameters.AddWithValue("@bulan", strBulan);
                if (strBulan == "01")
                    strBulanNama = "Januari";
                else if (strBulan == "02")
                    strBulanNama = "Februari";
                else if (strBulan == "03")
                    strBulanNama = "Maret";
                else if (strBulan == "04")
                    strBulanNama = "April";
                else if (strBulan == "05")
                    strBulanNama = "Mei";
                else if (strBulan == "06")
                    strBulanNama = "Juni";
                else if (strBulan == "07")
                    strBulanNama = "Juli";
                else if (strBulan == "08")
                    strBulanNama = "Agustus";
                else if (strBulan == "09")
                    strBulanNama = "September";
                else if (strBulan == "10")
                    strBulanNama = "Oktober";
                else if (strBulan == "11")
                    strBulanNama = "November";
                else if (strBulan == "12")
                    strBulanNama = "Desember";

                lblHeading.Text = "Logbook GCS " + strBulanNama + " " + strTahun;
            }
            if (strUnit != "")
            {
                sqlcmd.Parameters.AddWithValue("@Unit", strUnit);
                lblHeading.Text = "Logbook GCS " + "Unit " + strUnit;
            }
            if (strKategori != "")
            {
                sqlcmd.Parameters.AddWithValue("@Kategori", strKategori);
                lblHeading.Text = "Logbook GCS " + "Kategori " + strKategori;
            }
            if (strStatus != "")
            {
                sqlcmd.Parameters.AddWithValue("@status", strStatus);
                lblHeading.Text = "Logbook GCS " + "Status " + strStatus;
            }



            using (SqlDataAdapter da = new SqlDataAdapter(sqlcmd))
            {
                da.SelectCommand = sqlcmd;
                using (DataTable ds = new DataTable())
                {
                    //SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                    da.Fill(ds);
                    gvLog.DataSource = ds;
                    gvLog.DataBind();

                    //gvContact.DataSource = sqlcmd.ExecuteReader();
                    //gvContact.DataBind();
                    sqlCon.Close();
                }

            }
        }

        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            gvLog.PageIndex = e.NewPageIndex;
            gvLog.DataBind();
        }

        protected void Ink_OnClick1(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("LoViewIDLogbook", sqlCon);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon.Close();
            hfContactID.Value = ID.ToString();
            Session["hf"] = hfContactID.Value;
            //Response.Redirect("~/details.aspx?equ=" + dtbl.Rows[0]["Equipment"].ToString() + "merk=" + dtbl.Rows[0]["Merk"].ToString());
            Session["tanggal"] = dtbl.Rows[0]["tanggal"].ToString();
            Session["event"] = dtbl.Rows[0]["event"].ToString();
            Session["unit"] = dtbl.Rows[0]["unit"].ToString();
            Session["kategori"] = dtbl.Rows[0]["kategori"].ToString();
            Session["status"] = dtbl.Rows[0]["status"].ToString();
            Session["OS"] = dtbl.Rows[0]["PIC_OS"].ToString();
            Session["OG"] = dtbl.Rows[0]["PIC_OG"].ToString();
            Session["info"] = dtbl.Rows[0]["info"].ToString();
            Session["SN"] = dtbl.Rows[0]["S/N"].ToString();

            //Response.Redirect("~/details.aspx?" + dtbl.Rows[0]["Merk"].ToString());
            Response.Redirect("~/logbook1/details.aspx");

        }

        protected void gvLog_PreRender(object sender, EventArgs e)
        {
            lblPage.Text = "Menampilkan halaman " + (gvLog.PageIndex + 1).ToString() + " dari " + gvLog.PageCount.ToString();
        }

        protected void gvLog_RowData(object sender, GridViewRowEventArgs e)
        {
            for (int rowindex = gvLog.Rows.Count - 2; rowindex >= 0; rowindex--)
            {
                GridViewRow rows = gvLog.Rows[rowindex];
                GridViewRow previousrows = gvLog.Rows[rowindex + 1];

                if (rows.Cells[1].Text == previousrows.Cells[1].Text)
                {
                    rows.Cells[1].RowSpan = previousrows.Cells[1].RowSpan < 2 ? 2 :
                        previousrows.Cells[1].RowSpan + 1;
                    previousrows.Cells[1].Visible = false;
                }
            }

            for (int rowindex = gvLog.Rows.Count - 2; rowindex >= 0; rowindex--)
            {
                GridViewRow rows = gvLog.Rows[rowindex];
                GridViewRow previousrows = gvLog.Rows[rowindex + 1];

                if (rows.Cells[0].Text == previousrows.Cells[0].Text)
                {
                    rows.Cells[0].RowSpan = previousrows.Cells[0].RowSpan < 2 ? 2 :
                        previousrows.Cells[0].RowSpan + 1;
                    previousrows.Cells[0].Visible = false;
                }
            }
        }
    }
}