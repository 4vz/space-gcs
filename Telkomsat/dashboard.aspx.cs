using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Threading;

namespace Telkomsat
{
    public partial class dashboard : System.Web.UI.Page
    {
        string user;
        string pilihicon;
        string icon1;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            user = Session["username"].ToString();
            if (!IsPostBack)
            {
                sqlCon.Open();
                SqlDataAdapter sqlCmd = new SqlDataAdapter("ProViewByUser", sqlCon);
                sqlCmd.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlCmd.SelectCommand.Parameters.AddWithValue("@user", user);
                DataTable dtbl1 = new DataTable();
                sqlCmd.Fill(dtbl1);
                dtContact.DataSource = dtbl1;
                dtContact.DataBind();
                //DataList2.DataSource = dtbl1;
                //DataList2.DataBind();
                sqlCon.Close();
            }

            string tanggal = DateTime.Now.ToString("yyyy/MM/dd");
            var kemarin = DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd");
            sqlCon.Open();
            SqlDataAdapter sqlCmd2 = new SqlDataAdapter("dashLogbook", sqlCon);
            sqlCmd2.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd2.SelectCommand.Parameters.AddWithValue("@mulai", kemarin);
            sqlCmd2.SelectCommand.Parameters.AddWithValue("@akhir", tanggal);
            DataTable dtbl = new DataTable();
            sqlCmd2.Fill(dtbl);
            dtLogbook.DataSource = dtbl;
            dtLogbook.DataBind();
            //DataList2.DataSource = dtbl1;
            //DataList2.DataBind();
            sqlCon.Close();

            var minggu = DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd");
            sqlCon.Open();
            SqlDataAdapter sqlCmd1 = new SqlDataAdapter("dashAsset", sqlCon);
            sqlCmd1.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd1.SelectCommand.Parameters.AddWithValue("@mulai1", minggu);
            sqlCmd1.SelectCommand.Parameters.AddWithValue("@akhir1", tanggal);
            DataTable dtbl3 = new DataTable();
            sqlCmd1.Fill(dtbl3);
            dtAsset.DataSource = dtbl3;
            dtAsset.DataBind();
            //DataList2.DataSource = dtbl1;
            //DataList2.DataBind();
            sqlCon.Close();

            if (dtAsset.Items.Count == 0)
            {
                lblAsset.Visible = true;
                lblAsset.Text = "Tidak ada pembaruan data";
            }

            if (dtLogbook.Items.Count == 0)
            {
                lblLogbook.Visible = true;
                lblLogbook.Text = "Tidak ada penambahan logbook";
            }

            lblProfile1.Text = Session["username"].ToString();

            sqlCon.Open();
            SqlDataAdapter sqlCmd4 = new SqlDataAdapter("EvView", sqlCon);
            sqlCmd4.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCmd4.SelectCommand.Parameters.AddWithValue("@tanggal2", tanggal);
            DataTable dtbl4 = new DataTable();
            sqlCmd4.Fill(dtbl4);
            dtEvent.DataSource = dtbl4;
            dtEvent.DataBind();
            //DataList2.DataSource = dtbl1;
            //DataList2.DataBind();
            sqlCon.Close();

            /*foreach (DataListItem item in dtEvent.Items)
            {
                LinkButton btn = item.FindControl("lbSunting") as LinkButton;
                if (dtbl4.Rows[0]["penyelenggara"].ToString() == "GCS")
                {
                    btn.Visible = true;
                }
                else
                    btn.Visible = false;
            }*/

            if (dtEvent.Items.Count != 0)
            {
                lblEvent.Visible = false;
            }
        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }

        protected void btnSubmit(object sender, EventArgs e)
        {

            if (Request.Form["icon"] != null)
            {
                pilihicon = Request.Form["icon"].ToString();
                //Response.Write(pilihicon);
            }

            if (pilihicon == "sport")
                icon1 = "~/img/sport.png";
            else if (pilihicon == "makan")
                icon1 = "~/img/makan.png";
            else if (pilihicon == "rapat")
                icon1 = "~/img/meeting.png";
            else if (pilihicon == "holiday")
                icon1 = "~/img/holiday.jpg";

            //Response.Write(icon1);
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("EvAdd", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@event", txtEven.Text);
            sqlCmd.Parameters.AddWithValue("@penyelenggara", txtPenyelenggara.Text);
            sqlCmd.Parameters.AddWithValue("@tanggal2", txtttl.Value);
            sqlCmd.Parameters.AddWithValue("@jam", ddlJam.Text);
            sqlCmd.Parameters.AddWithValue("@lokasi", txtLokasi.Text);
            sqlCmd.Parameters.AddWithValue("@icon", icon1);
            sqlCmd.Parameters.AddWithValue("@statususer", Session["jenis1"]);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            if (Request.Form["icon"] != null)
            {
                pilihicon = Request.Form["icon"].ToString();
                //Response.Write(pilihicon);
            }

            if (pilihicon == "sport")
                icon1 = "~/img/sport.png";
            else if (pilihicon == "makan")
                icon1 = "~/img/makan.png";
            else if (pilihicon == "rapat")
                icon1 = "~/img/meeting.png";
            else if (pilihicon == "holiday")
                icon1 = "~/img/holiday.jpg";

            string indexedit = Session["indexEvent"].ToString();

            int IDEdit = Convert.ToInt32(indexedit);
            sqlCon.Open();
            SqlCommand sqlCmd5 = new SqlCommand("EvUpdate", sqlCon);
            sqlCmd5.CommandType = CommandType.StoredProcedure;
            sqlCmd5.Parameters.AddWithValue("@ID", IDEdit);
            sqlCmd5.Parameters.AddWithValue("@event", txtEven.Text);
            sqlCmd5.Parameters.AddWithValue("@penyelenggara", txtPenyelenggara.Text);
            sqlCmd5.Parameters.AddWithValue("@jam", ddlJam.Text);
            sqlCmd5.Parameters.AddWithValue("@lokasi", txtLokasi.Text);
            sqlCmd5.Parameters.AddWithValue("@tanggal2", txtttl.Value);
            sqlCmd5.Parameters.AddWithValue("@icon", icon1);
            sqlCmd5.ExecuteNonQuery();
            sqlCon.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string indexedit = Session["indexEvent"].ToString();

            int IDEdit = Convert.ToInt32(indexedit);
            sqlCon.Open();
            SqlCommand sqlCmd5 = new SqlCommand("EvDelete", sqlCon);
            sqlCmd5.CommandType = CommandType.StoredProcedure;
            sqlCmd5.Parameters.AddWithValue("@ID", IDEdit);
            sqlCmd5.ExecuteNonQuery();
            sqlCon.Close();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                sqlCon.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("EvViewByID", sqlCon);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("@IDEvent", index);
                DataTable dtbl8 = new DataTable();
                sqlda.Fill(dtbl8);
                sqlCon.Close();
                string tanggal1 = dtbl8.Rows[0]["tanggal"].ToString();
                string tanggalacara = tanggal1.Remove(10, 9);
                txtEven.Text = dtbl8.Rows[0]["event"].ToString();
                txtPenyelenggara.Text = dtbl8.Rows[0]["penyelenggara"].ToString();
                txtttl.Value = tanggalacara;
                ddlJam.Text = dtbl8.Rows[0]["jam"].ToString();
                txtLokasi.Text = dtbl8.Rows[0]["lokasi"].ToString();

                btnedit.Visible = true;
                btnhapus.Visible = true;
                btntambah.Visible = false;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalButton').modal('show')", true);

                Session["indexEvent"] = index;
                //Label labelEdit = (Label)e.Item.FindControl("lbEdit");
                //labelSunting.Visible = false;
                //labelEdit.Visible = true;
            }
        }

        protected void btnModal_ServerClick(object sender, EventArgs e)
        {
            txtEven.Text = "";
            txtPenyelenggara.Text = "";
            txtttl.Value = "";
            ddlJam.Text = "";
            txtLokasi.Text = "";

            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#exampleModalButton').modal('show')", true);

            btntambah.Visible = true;
            btnedit.Visible = false;
            btnhapus.Visible = false;
        }

        protected void dtEvent_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            
        }
    }
}