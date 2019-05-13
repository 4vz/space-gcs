using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.knowledge
{
    public partial class semua : System.Web.UI.Page
    {
        static int currentposition = 0;
        static int totalrows = 0;
        string mystring;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

//        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
                Response.Redirect("~/login.aspx");

            if (!IsPostBack)
            {
                if (Session["carifile"] == null)
                {
                    bindata();
                }
                else
                {
                    session();
                }
            }

        }

        void session()
        {

            if (inputsearch.Value == "")
            {
                if (!IsPostBack)
                {
                    mystring = Session["carifile"] as string;
                    Session["carifile"] = "";
                }

                else
                    mystring = "";
            }

            else if (inputsearch.Value != null)
            {
                mystring = inputsearch.Value;
            }

            //Response.Write(Session["carifile"].ToString());

            string[] split = mystring.Split(new char[] { ' ', '\t' });
            string kata1 = split[0];
            string kata2, kata3, kata4, kata5, kata6;
            //lblPage.Text = split[3];

            if (split.Length < 2)
                kata2 = "";
            else
                kata2 = split[1];

            if (split.Length < 3)
                kata3 = "";
            else
                kata3 = split[2];

            if (split.Length < 4)
                kata4 = "";
            else
                kata4 = split[3];

            if (split.Length < 5)
                kata5 = "";
            else
                kata5 = split[4];

            if (split.Length < 6)
                kata6 = "";
            else
                kata6 = split[5];

            con.Open();
            SqlCommand cmd = new SqlCommand("PostSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kata1", kata1);
            cmd.Parameters.AddWithValue("@kata2", kata2);
            cmd.Parameters.AddWithValue("@kata3", kata3);
            cmd.Parameters.AddWithValue("@kata4", kata4);
            cmd.Parameters.AddWithValue("@kata5", kata5);
            cmd.Parameters.AddWithValue("@kata6", kata6);
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            PagedDataSource pg = new PagedDataSource();
            pg.DataSource = dt.DefaultView;
            pg.AllowPaging = true;
            pg.CurrentPageIndex = currentposition;
            pg.PageSize = 6;
            LinkButton1.Enabled = !pg.IsFirstPage;
            LinkButton2.Enabled = !pg.IsFirstPage;
            LinkButton3.Enabled = !pg.IsLastPage;
            LinkButton4.Enabled = !pg.IsLastPage;
            sqlda.Fill(dt);
            DataList1.DataSource = dt;
            DataList1.DataBind();
            con.Close();
        }

        protected void btnPosting_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/semua.aspx");
        }

        protected void btnFile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/dashboard.aspx");
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("~/knowledge/posting.aspx?id=" + index);


            }
        }

        private void bindata()
        {
            SqlCommand cmd = new SqlCommand("ViewAllSort", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            totalrows = ds.Tables[0].Rows.Count;
            DataTable dt = ds.Tables[0];
            PagedDataSource pg = new PagedDataSource();
            pg.DataSource = dt.DefaultView;
            pg.AllowPaging = true;
            pg.CurrentPageIndex = currentposition;
            pg.PageSize = 6;
            LinkButton1.Enabled = !pg.IsFirstPage;
            LinkButton2.Enabled = !pg.IsFirstPage;
            LinkButton3.Enabled = !pg.IsLastPage;
            LinkButton4.Enabled = !pg.IsLastPage;
            //Binding pg to datalist
            DataList1.DataSource = pg;//dl is datalist
            DataList1.DataBind();
            con.Close();
        }

        protected void lb1_Click(object sender, EventArgs e)
        {
            currentposition = 0;
            if (inputsearch.Value == "")
            {
                if (!IsPostBack)
                {
                    mystring = Session["carifile"] as string;
                    Session["carifile"] = "";
                }

                else
                    bindata();
            }

            else if (inputsearch.Value != null)
            {
                session();
            }
        }
        protected void lb2_Click(object sender, EventArgs e)
        {
            if (currentposition == 0)
            {

            }
            else
            {
                currentposition = currentposition - 1;
                if (inputsearch.Value == "")
                {
                    if (!IsPostBack)
                    {
                        mystring = Session["carifile"] as string;
                        Session["carifile"] = "";
                    }

                    else
                        bindata();
                }

                else if (inputsearch.Value != null)
                {
                    session();
                }
            }
        }
        protected void lb3_Click(object sender, EventArgs e)
        {
            if (currentposition == totalrows - 1)
            {

            }
            else
            {
                currentposition = currentposition + 1;
                if (inputsearch.Value == "")
                {
                    if (!IsPostBack)
                    {
                        mystring = Session["carifile"] as string;
                        Session["carifile"] = "";
                    }

                    else
                        bindata();
                }

                else if (inputsearch.Value != null)
                {
                    session();
                }
            }
        }
        protected void lb4_Click(object sender, EventArgs e)
        {
            currentposition = totalrows - 1;
            if (inputsearch.Value == "")
            {
                if (!IsPostBack)
                {
                    mystring = Session["carifile"] as string;
                    Session["carifile"] = "";
                }

                else
                    bindata();
            }

            else if (inputsearch.Value != null)
            {
                session();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            session();
        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/tambahpost.aspx");
        }
    }
}