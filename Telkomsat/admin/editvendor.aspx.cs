using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Services;

namespace Telkomsat.admin
{
    public partial class editvendor : System.Web.UI.Page
    {
        string[] myket, myvolume;
        string tanggal, query, iddata, query1;
        double grandtotal;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnsubmit.UniqueID;

            if (Request.QueryString["id"] != null)
            {
                iddata = Request.QueryString["id"].ToString();

                query1 = $"SELECT * FROM AdminVendor WHERE AV_ID = '{iddata}'";
                DataSet ds = Settings.LoadDataSet(query1);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!IsPostBack)
                    {
                        txtbankper.Text = ds.Tables[0].Rows[0]["AV_NBPerusahaan"].ToString();
                        txtbankpic.Text = ds.Tables[0].Rows[0]["AV_NBPIC"].ToString();
                        txtemailper.Value = ds.Tables[0].Rows[0]["AV_EmailPerusahaan"].ToString();
                        txtemailpic.Value = ds.Tables[0].Rows[0]["AV_Email"].ToString();
                        txtnpwpper.Value = ds.Tables[0].Rows[0]["AV_NPWP"].ToString();
                        txtperusahaan.Value = ds.Tables[0].Rows[0]["AV_Perusahaan"].ToString();
                        txtpic.Value = ds.Tables[0].Rows[0]["AV_PIC"].ToString();
                        txtrekper.Value = ds.Tables[0].Rows[0]["AV_NRPerusahaan"].ToString();
                        txtrekpic.Value = ds.Tables[0].Rows[0]["AV_NRPIC"].ToString();
                        txttelpper.Value = ds.Tables[0].Rows[0]["AV_NTPerusahaan"].ToString();
                        txttelppic.Value = ds.Tables[0].Rows[0]["AV_TLP"].ToString();
                        ddljp.Text = ds.Tables[0].Rows[0]["AV_JP"].ToString();
                    }

                }
            }
        }

        protected void save_click(object sender, EventArgs e)
        {
            string query;
            query = $@"update AdminVendor set AV_JP='{ddljp.Text}', AV_Perusahaan='{txtperusahaan.Value}', AV_NTPerusahaan='{txttelpper.Value}', AV_EmailPerusahaan='{txtemailper}',
                           AV_NBPerusahaan='{txtbankper.Text}', AV_NRPerusahaan='{txtrekper}', AV_PIC='{txtpic.Value}', AV_TLP='{txttelppic.Value}', AV_Email='{txtemailpic.Value}',
                           AV_NBPIC='{txtbankpic}', AV_NRPIC='{txtrekpic.Value}', AV_NPWP='{txtnpwpper.Value}' WHERE AV_ID='{iddata}'";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }

        public class inisial
        {
            public string bank { get; set; }
        }

        [WebMethod]
        public static List<inisial> GetBank()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from AdminReference where AR_Jenis = 'bank'"))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            mydata.Add(new inisial
                            {
                                bank = sdr["AR_Reference"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }
    }
}