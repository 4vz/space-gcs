using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.File
{
    public partial class cobasorting : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["sorting"] == null)
                GridBindFile();
            else
                BindGrid();
        }

        public void GridBindFile()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("FileViewAll", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvFile.DataSource = ds;
                gvFile.DataBind();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }

        

        protected void btnTambah_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/File/tambah.aspx");
        }

        protected void linkDownloadFile_Click(object sender, EventArgs e)
        {

            int ImageId = int.Parse((sender as LinkButton).CommandArgument);
            byte[] bytes;
            string fileName, contentType;
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_fileDownload", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ImageId);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            fileName = sdr["NameFile"].ToString();
            bytes = (byte[])sdr["Data"];
            contentType = sdr["ContentType"].ToString();
            con.Close();
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();

        }

        private void BindGrid(string sortExpression = null)
        {
            string mystring;

            if (txtMaster.Value == "")
            {
                if (!IsPostBack)
                    mystring = Session["carifile"] as string;
                else
                    mystring = "";
            }

            else
            {
                mystring = txtMaster.Value;
            }
            if (Session["carifile"] != null)
                mystring = Session["carifile"].ToString();
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
            SqlCommand cmd = new SqlCommand("FileSearch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@kata1", kata1);
            cmd.Parameters.AddWithValue("@kata2", kata2);
            cmd.Parameters.AddWithValue("@kata3", kata3);
            cmd.Parameters.AddWithValue("@kata4", kata4);
            cmd.Parameters.AddWithValue("@kata5", kata5);
            cmd.Parameters.AddWithValue("@kata6", kata6);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            
            da.Fill(ds);
            con.Close();
            DataTable dt = ds.Tables[0];

            DataView dv = new DataView(dt);

            this.SortDirection = this.SortDirection == "ASC" ? "DESC" : "ASC";

            dv.Sort = sortExpression + " " + this.SortDirection;

            gvFile.DataSource = dv;
            gvFile.DataBind();
        }

        private string SortDirection
        {
            get { return ViewState["SortDirection"] != null ? ViewState["SortDirection"].ToString() : "ASC"; }
            set { ViewState["SortDirection"] = value; }
        }

        protected void gvFile_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.BindGrid(e.SortExpression);
        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFile.PageIndex = e.NewPageIndex;
            this.BindGrid();
        }
    }
}
