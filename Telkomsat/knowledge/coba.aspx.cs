using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace Telkomsat
{
    public partial class coba1 : System.Web.UI.Page
    {
        SqlConnection sqlCon2 = new SqlConnection(@"Data Source=DESKTOP-K0GET7F\SQLEXPRESS; Initial Catalog=KNOWLEDGE; Integrated Security = true;");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "id")
            {

                int index = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("~/knowledge/details.aspx?id=" + index);


            }
        }

        protected void Ink_OnClick(object sender, EventArgs e)
        {
            /*int ID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon2.State == ConnectionState.Closed)
                sqlCon2.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter("ViewByID", sqlCon2);
            sqlda.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlda.SelectCommand.Parameters.AddWithValue("@ID", ID);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            sqlCon2.Close();
            hfContactID.Value = ID.ToString();
            Session["hf"] = hfContactID.Value;
            /*Response.Redirect("~/details.aspx?equ=" + dtbl.Rows[0]["Equipment"].ToString() + "merk=" + dtbl.Rows[0]["Merk"].ToString());
            if (dtbl.Rows.Count > 0) {
                Response.Write(dtbl.Rows[0]["JUDUL"].ToString());
            }*/

            //Response.Redirect("~/Logbook/details.aspx");
        }
    }
}