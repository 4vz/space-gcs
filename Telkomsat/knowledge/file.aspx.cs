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
    public partial class file : System.Web.UI.Page
    {
        static int currentposition = 0;
        static int totalrows = 0;
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindata();
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("~/knowledge/details.aspx?id=" + index);


            }
        }

        private void bindata()
        {
            String myquery = "Select * from LOGBOOK";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = myquery;
            cmd.Connection = con;
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
            bindata();
        }
        protected void lb2_Click(object sender, EventArgs e)
        {
            if (currentposition == 0)
            {

            }
            else
            {
                currentposition = currentposition - 1;
                bindata();
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
                bindata();
            }
        }
        protected void lb4_Click(object sender, EventArgs e)
        {
            currentposition = totalrows - 1;
            bindata();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/knowledge/tambah.aspx");
        }
    }
}