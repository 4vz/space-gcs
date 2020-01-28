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
using System.Text;

namespace Telkomsat
{
    public partial class dashboard : System.Web.UI.Page
    {
        string user;
        string pilihicon;
        string icon1;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        DataSet ds5 = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        string querytiket, IDdata = "kitaa", statuss="st", style1="a", style2 = "a", prioritas ="a", jenis="", jenisedit="", jenisview="";
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");


            tableticket();

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

            sqlCon.Open();
            string querycheck = $@"select nama, ruangan, d.waktu from checkme_data d left join checkme_parameter r on r.id_parameter=d.id_parameter left join checkme_perangkat p 
                                    on p.id_perangkat=r.id_perangkat left join Profile l on l.id_profile=d.id_profile where d.tanggal = '2020/01/08' group by ruangan, nama, waktu
                                    order by waktu desc";
            SqlDataAdapter sqlCmd5 = new SqlDataAdapter(querycheck, sqlCon);
            sqlCmd5.Fill(ds5);
            DataTable dtbl5 = new DataTable();
            SqlCommand cmd5 = new SqlCommand(querycheck, sqlCon);
            sqlCon.Close();
            int output = ds5.Tables[0].Rows.Count;
            if (output > 0)
            {
                lboleh.Text = ds5.Tables[0].Rows[0]["nama"].ToString();
                lbwaktu.Text = ds5.Tables[0].Rows[0]["waktu"].ToString();
                double hasil = ((double)output / 16) * 100;
                lbprogress.Text = hasil.ToString() + "%";
            }
                

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
            sqlCon.Close();

            if (dtEvent.Items.Count != 0)
            {
                lblEvent.Visible = false;
            }
        }

        void tableticket()
        {
            querytiket = @"SELECT * FROM ticket_user WHERE statusticket != 'delete'
                        and status != 'reject' and status != 'confirm'
                        ORDER BY id_ticket desc";
            SqlCommand cmd = new SqlCommand(querytiket, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table - bordered table - hover table - striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>Nama User</th><th>Nomor HP</th><th>Subject</th><th>Keterangan</th><th>Status</th><th>Prioritas</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblticket.Visible = false;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        IDdata = ds.Tables[0].Rows[i]["id_ticket"].ToString();
                        statuss = ds.Tables[0].Rows[i]["status"].ToString();
                        prioritas = ds.Tables[0].Rows[i]["prioritas"].ToString();
                        if (statuss == "sent")
                            style1 = "btn-default";
                        else if (statuss == "accept")
                            style1 = "btn-primary";
                        else if (statuss == "reject")
                            style1 = "btn-danger";
                        else if (statuss == "complete")
                            style1 = "btn-success";
                        else if (statuss == "reject")
                            style1 = "btn-danger";

                        int index = Convert.ToInt32(ds.Tables[0].Rows[i]["id_ticket"].ToString());

                        if (prioritas == "Low")
                            style2 = "btn-default";
                        else if (prioritas == "Medium")
                            style2 = "btn-success";
                        else if (prioritas == "High")
                            style2 = "btn-danger";
                        //HiddenField1.Value = IDdata;
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["tanggal"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["nama_user"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["nomor_hp"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["subject"] + "</td>");
                        htmlTable.Append("<td>" + ds.Tables[0].Rows[i]["keterangan"] + "</td>");
                        htmlTable.Append("<td>" + $"<label class=\"btn btn-sm {style1}\" style=\"pointer-events:none; width:70px;\">" + ds.Tables[0].Rows[i]["status"] + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label class=\"btn btn-sm {style2}\" style=\"pointer-events:none; width:70px;\">" + ds.Tables[0].Rows[i]["prioritas"] + "</label>" + "</td>");
                        htmlTable.Append($"<td style=\"visibility: {jenisview};\"> " + $"<a href=\"../ticket/detail.aspx?id={index}\" value='ID_Perangkat' id=aku CommandArgument=");
                        htmlTable.Append((ds.Tables[0].Rows[i]["subject"]));
                        htmlTable.Append(" > View</a>" + "</td>");
                        htmlTable.Append("<td>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
                else
                {
                    lblticket.Visible = true;
                }
            }
        }

        protected void btnSignOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/login.aspx");
        }

        protected void saveticket(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand($@"INSERT INTO ticket_user (nama_user, tanggal, nomor_hp, subject, keterangan)
                                            VALUES ('{txt2nama.Text}','{datetime1}', '{txt2No.Text}', '{txt2subject.Text}', '{txt2keterangan.Text}')", sqlCon);
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            
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
            Response.Redirect("dashboard.aspx");
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
            Response.Redirect("dashboard.aspx");
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
            Response.Redirect("dashboard.aspx");
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