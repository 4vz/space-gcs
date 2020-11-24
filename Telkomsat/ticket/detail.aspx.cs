using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Telkomsat.ticket
{
    public partial class detail : System.Web.UI.Page
    {
        StringBuilder htmlTable2 = new StringBuilder();
        SqlConnection sqlCon2 = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string query, queryupdate, divisi;
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        string parse, datetime1;
        int ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string link = (HttpContext.Current.Request.Url.PathAndQuery);
            parse = link.Remove(0, 23);

            //Response.Write(parse);
            ID = Convert.ToInt32(parse);
            //string query = $"SELECT * FROM ticket_user WHERE id_ticket = {parse}";
            //Response.Write(ID);
            divisi = Session["jenis1"].ToString();
            

            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlCommand cmd2 = new SqlCommand("ticketreplycount", sqlCon2);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@idt", parse);
            int output = int.Parse(cmd2.ExecuteScalar().ToString());
            sqlCon2.Close();


            if(output >= 1)
            {
                replybox.Style.Add("display", "block");
                sqlCon2.Open();
                SqlDataAdapter sqlda1 = new SqlDataAdapter("ticketreplyid", sqlCon2);
                sqlda1.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda1.SelectCommand.Parameters.AddWithValue("@idticket", parse);
                DataTable dtbl1 = new DataTable();
                sqlda1.Fill(dtbl1);
                sqlCon2.Close();
                hfContactID.Value = ID.ToString();
                datalist2.DataSource = dtbl1;
                datalist2.DataBind();
            }

            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlCommand cmd4 = new SqlCommand("ticketfileuser", sqlCon2);
            cmd4.CommandType = CommandType.StoredProcedure;
            cmd4.Parameters.AddWithValue("@idf", parse);
            int output1 = int.Parse(cmd4.ExecuteScalar().ToString());
            sqlCon2.Close();

            if (output1 >= 1)
            {
                DataList3a.Visible = true;
                sqlCon2.Open();
                SqlDataAdapter sqlda1 = new SqlDataAdapter("ticketfileuserid", sqlCon2);
                sqlda1.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda1.SelectCommand.Parameters.AddWithValue("@idticketfile", parse);
                DataTable dtbl1 = new DataTable();
                sqlda1.Fill(dtbl1);
                sqlCon2.Close();
                hfContactID.Value = ID.ToString();
                DataList3a.DataSource = dtbl1;
                DataList3a.DataBind();
            }

            DateTime wib = DateTime.UtcNow + new TimeSpan(7, 0, 0);
            datetime1 = wib.ToString("yyyy/MM/dd h:m:s");


            /*GridViewreply.Visible=true;
            sqlCon2.Open();
            SqlDataAdapter sqlda3 = new SqlDataAdapter("ticketfilereplyid", sqlCon2);
            sqlda3.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda3.SelectCommand.Parameters.AddWithValue("@idticketreply", parse);
            DataTable dtbl3 = new DataTable();
            sqlda3.Fill(dtbl3);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            GridViewreply.DataSource = dtbl3;
            GridViewreply.DataBind();*/

            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ticketbyid", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@id", parse);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            datalist1.DataSource = dtbl;
            datalist1.DataBind();

            sqlda.Fill(ds);

            if (ds.Tables[0].Rows[0]["statusticket"].ToString() == "unread" && ds.Tables[0].Rows[0]["divisireply"].ToString() != divisi)
            {
                sqlCon2.Open();
                SqlCommand cmd = new SqlCommand($"UPDATE ticket_user SET statusticket='read' WHERE id_ticket = {parse}", sqlCon2);
                cmd.ExecuteNonQuery();
                sqlCon2.Close();
            }
            /**/

            if (dtbl.Rows[0]["status"].ToString() == "accept")
            {
                btnaccept.Visible = false;
                btnreject.Visible = false;
                btncomplete.Visible = true;
            }
            else if (dtbl.Rows[0]["status"].ToString() == "complete")
            {
                btnaccept.Visible = false;
                btnreject.Visible = false;
                btncomplete.Visible = false;
            }

            if (divisi == "tcc")
            {
                btnaccept.Visible = false;
                btncomplete.Visible = false;
                btnreject.Visible = false;
                if (dtbl.Rows[0]["status"].ToString() == "complete")
                    btnconfirm.Visible = true;
            }

            foreach (DataListItem dli in datalist1.Items)
            {
                Label lblprioritas = (Label)dli.FindControl("KATEGORILabel");
                Label lblstatus = (Label)dli.FindControl("lblStatus");

                if (dtbl.Rows[0]["prioritas"].ToString() == "Medium")
                {
                    lblprioritas.CssClass = " btn1 btn-sm btn-success";
                }
                else if (dtbl.Rows[0]["prioritas"].ToString() == "Low")
                {
                    lblprioritas.CssClass = " btn1 btn-sm btn-default";
                }
                else if (dtbl.Rows[0]["prioritas"].ToString() == "High")
                {
                    lblprioritas.CssClass = " btn1 btn-sm btn-danger";
                }

                if (dtbl.Rows[0]["status"].ToString() == "sent")
                {
                    lblstatus.CssClass = " btn1 btn-sm btn-default";
                }
                else if (dtbl.Rows[0]["status"].ToString() == "accept")
                {
                    lblstatus.CssClass = " btn1 btn-sm btn-primary";
                }
                else if (dtbl.Rows[0]["status"].ToString() == "reject")
                {
                    lblstatus.CssClass = " btn1 btn-sm btn-danger";
                }
                else if (dtbl.Rows[0]["status"].ToString() == "complete")
                {
                    lblstatus.CssClass = " btn1 btn-sm btn-info";
                }
                else if (dtbl.Rows[0]["status"].ToString() == "incomplete")
                {
                    lblstatus.CssClass = " btn1 btn-sm btn-warning";
                }
                else if (dtbl.Rows[0]["status"].ToString() == "confirm")
                {
                    lblstatus.CssClass = " btn1 btn-sm btn-success";
                }

                riwayat();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename="
                + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/fileupload/")
                + e.CommandArgument);
            Response.End();
        }

        protected void Rejected_ServerClick(object sender, EventArgs e)
        {
            string myquery;
            sqlCon2.Open();
            queryupdate = $"UPDATE ticket_user SET status = 'reject' WHERE id_ticket = {ID}";
            SqlCommand cmd = new SqlCommand(queryupdate, sqlCon2);
            cmd.ExecuteNonQuery();
            sqlCon2.Close();
            lblstatus.Visible = true;
            lblstatus.Text = " Ticket rejected";
            lblstatus.ForeColor = System.Drawing.Color.IndianRed;

            sqlCon2.Open();
            myquery = $@"INSERT INTO ticket_status (TS_Tanggal, TS_ticket, TS_Status, TS_Profile)
                        Values ('{datetime1}', '{ID}', 'reject', '{Session["nama1"].ToString()}')";
            SqlCommand sqlCmd5 = new SqlCommand(myquery, sqlCon2);

            sqlCmd5.ExecuteNonQuery();
            sqlCon2.Close();

        }
        protected void Complete_ServerClick(object sender, EventArgs e)
        {
            string myquery;
            sqlCon2.Open();
            queryupdate = $"UPDATE ticket_user SET status = 'complete' WHERE id_ticket = {ID}";
            SqlCommand cmd = new SqlCommand(queryupdate, sqlCon2);
            cmd.ExecuteNonQuery();
            sqlCon2.Close();

            if (FileUpload3.HasFiles)
            {
                string physicalpath = Server.MapPath("~/affident/");
                if (!Directory.Exists(physicalpath))
                    Directory.CreateDirectory(physicalpath);

                int filecount = 0;
                foreach (HttpPostedFile file in FileUpload3.PostedFiles)
                {
                    filecount += 1;
                    string filename = Path.GetFileName(file.FileName);
                    string filepath = "~/affident/" + filename;
                    file.SaveAs(physicalpath + filename);
                    query = $@"UPDATE ticket_interval SET tanggal_complete = '{datetime1}', 
                                                           kategoriwaktu ='{DropDownList1.Text}', 
                                                           affident = '{filename}'
                                                           WHERE id_ticket = {ID}";
                    sqlCon2.Open();
                    SqlCommand cmd1 = new SqlCommand(query, sqlCon2);
                    cmd1.ExecuteNonQuery();
                    sqlCon2.Close();
                }
                //lblstatus.Text = filecount + " files upload";

            }
            
            lblstatus.Visible = true;
            lblstatus.Text = " Ticket complete";
            lblstatus.ForeColor = System.Drawing.Color.Aquamarine;

            sqlCon2.Open();
            myquery = $@"INSERT INTO ticket_status (TS_Tanggal, TS_ticket, TS_Status, TS_Profile)
                        Values ('{datetime1}', '{ID}', 'complete', '{Session["nama1"].ToString()}')";
            SqlCommand sqlCmd5 = new SqlCommand(myquery, sqlCon2);

            sqlCmd5.ExecuteNonQuery();
            sqlCon2.Close();

        }

        protected void Confirm_ServerClick(object sender, EventArgs e)
        {
            string myquery;
            sqlCon2.Open();
            queryupdate = $"UPDATE ticket_user SET status = 'close' WHERE id_ticket = {ID}";
            SqlCommand cmd = new SqlCommand(queryupdate, sqlCon2);
            cmd.ExecuteNonQuery();
            sqlCon2.Close();
            lblstatus.Visible = true;
            lblstatus.Text = " Ticket Confirm";
            lblstatus.ForeColor = System.Drawing.Color.DarkSeaGreen;
            sqlCon2.Open();
            myquery = $@"INSERT INTO ticket_status (TS_Tanggal, TS_ticket, TS_Status, TS_Profile)
                        Values ('{datetime1}', '{ID}', 'close', '{Session["nama1"].ToString()}')";
            SqlCommand sqlCmd5 = new SqlCommand(myquery, sqlCon2);

            sqlCmd5.ExecuteNonQuery();
            sqlCon2.Close();

        }

        protected void Reply_ServerClick(object sender, EventArgs e)
        {
            if(nama.Value =="" || keterangan.Value == "")
            {
                lblstatus.Visible = true;
                lblstatus.Text = " (Pastikan tidak ada yang kosong)";
                lblstatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                sqlCon2.Open();
                SqlCommand sqlCmd = new SqlCommand($@"INSERT INTO ticket_reply (id_ticket, tanggal, nama, reply)
                                            VALUES ('{parse}','{datetime1}', '{nama.Value}', '{keterangan.Value}'); Select Scope_Identity();", sqlCon2);
                int i = Convert.ToInt32(sqlCmd.ExecuteScalar());
                sqlCon2.Close();

                sqlCon2.Open();
                SqlCommand sqlCmd2 = new SqlCommand($@"UPDATE ticket_user SET statusticket='unread', divisireply='{divisi}' WHERE id_ticket = '{parse}'", sqlCon2);
                sqlCmd2.ExecuteNonQuery();
                sqlCon2.Close();

                if (FileUpload1.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/fileupload/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                    {
                        filecount += 1;
                        string filename = Path.GetFileName(file.FileName);
                        string filepath = "~/fileupload/" + filename;
                        file.SaveAs(physicalpath + filename);
                        string s = Convert.ToString(i);
                        sqlCon2.Open();
                        string queryfile = $@"INSERT INTO ticket_file (id_reply, files, namafiles)
                                        VALUES ({s}, '{filepath}', '{filename}')";
                        SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon2);

                        sqlCmd1.ExecuteNonQuery();
                        sqlCon2.Close();
                    }
                    //lblstatus.Text = filecount + " files upload";

                }

                lblstatus.Visible = true;
                lblstatus.Text = " (Pesan Terkirim)";
                lblstatus.ForeColor = System.Drawing.Color.LawnGreen;

                if (sqlCon2.State == ConnectionState.Closed)
                    sqlCon2.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("ticketreplyid", sqlCon2);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("@idticket", parse);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                sqlCon2.Close();
                hfContactID.Value = ID.ToString();
                datalist2.DataSource = dtbl;
                datalist2.DataBind();

                replybox.Style.Add("display", "block");

            }


        }

        protected void InkView_Click(object sender, EventArgs e)
        {
            
        }

        protected void InkView_Command(object sender, CommandEventArgs e)
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename="
                + e.CommandArgument);
            Response.TransmitFile(Server.MapPath("~/fileupload/")
                + e.CommandArgument);
            Response.End();
        }

        protected void Reply1_ServerClick(object sender, EventArgs e)
        {
            if (txtket.Value == "")
            {
                lblstatus.Visible = true;
                lblstatus.Text = " (Tidak boleh kosong)";
                lblstatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                sqlCon2.Open();
                SqlCommand sqlCmd = new SqlCommand($@"INSERT INTO ticket_reply (id_ticket, tanggal, nama, reply)
                                            VALUES ('{parse}','{datetime1}', '{Session["nama1"].ToString()}', '{txtket.Value}'); Select Scope_Identity();", sqlCon2);
                int i = Convert.ToInt32(sqlCmd.ExecuteScalar());
                sqlCon2.Close();

                sqlCon2.Open();
                SqlCommand sqlCmd2 = new SqlCommand($@"UPDATE ticket_user SET statusticket='unread', divisireply='{divisi}' WHERE id_ticket = '{parse}'", sqlCon2);
                sqlCmd2.ExecuteNonQuery();
                sqlCon2.Close();

                if (FileUpload2.HasFiles)
                {
                    string physicalpath = Server.MapPath("~/fileupload/");
                    if (!Directory.Exists(physicalpath))
                        Directory.CreateDirectory(physicalpath);

                    int filecount = 0;
                    foreach (HttpPostedFile file in FileUpload2.PostedFiles)
                    {
                        filecount += 1;
                        string filename = Path.GetFileName(file.FileName);
                        string filepath = "~/fileupload/" + filename;
                        file.SaveAs(physicalpath + filename);
                        string s = Convert.ToString(i);
                        sqlCon2.Open();
                        string queryfile = $@"INSERT INTO ticket_file (id_reply, files, namafiles)
                                        VALUES ({s}, '{filepath}', '{filename}')";
                        SqlCommand sqlCmd1 = new SqlCommand(queryfile, sqlCon2);

                        sqlCmd1.ExecuteNonQuery();
                        sqlCon2.Close();
                    }
                    //lblstatus.Text = filecount + " files upload";

                }

                lblstatus.Visible = true;
                lblstatus.Text = " (Pesan Terkirim)";
                lblstatus.ForeColor = System.Drawing.Color.LawnGreen;

                if (sqlCon2.State == ConnectionState.Closed)
                    sqlCon2.Open();
                SqlDataAdapter sqlda = new SqlDataAdapter("ticketreplyid", sqlCon2);
                sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlda.SelectCommand.Parameters.AddWithValue("@idticket", parse);
                DataTable dtbl = new DataTable();
                sqlda.Fill(dtbl);
                sqlCon2.Close();
                hfContactID.Value = ID.ToString();
                datalist2.DataSource = dtbl;
                datalist2.DataBind();
                replybox.Style.Add("display", "block");

            }


        }

        protected void Accepted_ServerClick(object sender, EventArgs e)
        {
            sqlCon2.Open();
            queryupdate = $"UPDATE ticket_user SET status = 'accept' WHERE id_ticket = {ID}";
            
            SqlCommand cmd = new SqlCommand(queryupdate, sqlCon2);
            cmd.ExecuteNonQuery();
            sqlCon2.Close();

            query = $@"INSERT INTO ticket_interval (id_ticket, tanggal_accept)
                    VALUES({ID}, '{datetime1}')";
            sqlCon2.Open();
            SqlCommand cmd1 = new SqlCommand(query, sqlCon2);
            cmd1.ExecuteNonQuery();
            sqlCon2.Close();
            lblstatus.Visible = true;
            lblstatus.Text = " Ticket Accepted";
            lblstatus.ForeColor = System.Drawing.Color.LawnGreen;

            string myquery;
            sqlCon2.Open();
            myquery = $@"INSERT INTO ticket_status (TS_Tanggal, TS_ticket, TS_Status, TS_Profile)
                        Values ('{datetime1}', '{ID}', 'accept', '{Session["nama1"].ToString()}')";
            SqlCommand sqlCmd5 = new SqlCommand(myquery, sqlCon2);

            sqlCmd5.ExecuteNonQuery();
            sqlCon2.Close();

        }

        void riwayat()
        {
            string query = $"SELECT * from ticket_status where TS_ticket = '{ID}' order by TS_ID desc";
            string style3 = "";
            DataSet ds = Settings.LoadDataSet(query);
            htmlTable2.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable2.Append("<thead>");
            htmlTable2.Append("<tr><td>Tanggal</td><td>Nama</td><td>Status</td></tr>");
            htmlTable2.Append("</thead>");

            htmlTable2.Append("<tbody>");

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["TS_Tanggal"]);
                    string tanggal = dt.ToString("dd MMM yyyy h:m:s");
                    string status = ds.Tables[0].Rows[i]["TS_Status"].ToString();
                    string nama = ds.Tables[0].Rows[i]["TS_Profile"].ToString();
                    htmlTable2.Append("<tr>");
                    htmlTable2.Append("<td>" + $"<label style=\"{style3}\">" + tanggal + "</label>" + "</td>");
                    htmlTable2.Append("<td>" + $"<label style=\"{style3}\">" + nama + "</label>" + "</td>");
                    htmlTable2.Append("<td>" + $"<label style=\"{style3}\">" + status + "</label>" + "</td>");
                    htmlTable2.Append("</tr>");
                }
                htmlTable2.Append("</tbody>");
                htmlTable2.Append("</table>");
                PlaceHolder2.Controls.Add(new Literal { Text = htmlTable2.ToString() });
            }
        }

    }
}