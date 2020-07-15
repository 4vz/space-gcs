using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Telkomsat.admin
{
    public partial class detailvendor : System.Web.UI.Page
    {
        string[] myket, myvolume;
        string tanggal, query, iddata, query1;
        double grandtotal;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                iddata = Request.QueryString["id"].ToString();

                query1 = $@"SELECT * from AdminVendor WHERE AV_ID = '{iddata}'";
                DataSet ds = Settings.LoadDataSet(query1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!IsPostBack)
                    {
                        lblemail.Text = ds.Tables[0].Rows[0]["AV_EmailPerusahaan"].ToString();
                        lblemailpic.Text = ds.Tables[0].Rows[0]["AV_Email"].ToString();
                        lbljp.Text = ds.Tables[0].Rows[0]["AV_JP"].ToString();
                        lblnambank.Text = ds.Tables[0].Rows[0]["AV_NBPerusahaan"].ToString();
                        lblnbpic.Text = ds.Tables[0].Rows[0]["AV_NBPIC"].ToString();
                        lblnorek.Text = ds.Tables[0].Rows[0]["AV_NRPerusahaan"].ToString();
                        lblnote.Text = ds.Tables[0].Rows[0]["AV_NTPerusahaan"].ToString();
                        lblnp.Text = ds.Tables[0].Rows[0]["AV_Perusahaan"].ToString();
                        lblnrpic.Text = ds.Tables[0].Rows[0]["AV_NRPIC"].ToString();
                        lblotpic.Text = ds.Tables[0].Rows[0]["AV_TLP"].ToString();
                        lblnpwp.Text = ds.Tables[0].Rows[0]["AV_NPWP"].ToString();

                        lblpic.Text = ds.Tables[0].Rows[0]["AV_PIC"].ToString();
                    }

                }
            }
        }
    }
}