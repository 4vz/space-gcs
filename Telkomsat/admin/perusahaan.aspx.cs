using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web.Services;

namespace Telkomsat.admin
{
    public partial class perusahaan : System.Web.UI.Page
    {
        string[] myket, myvolume;
        string tanggal, query;
        double grandtotal;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnsubmit.UniqueID;
        }

        protected void save_click(object sender, EventArgs e)
        {
            string query;
            query = $@"insert into AdminVendor(AV_JP, AV_Perusahaan, AV_NTPerusahaan, AV_EmailPerusahaan, AV_NBPerusahaan, AV_NRPerusahaan, AV_PIC, AV_TLP, AV_Email, AV_NBPIC, AV_NRPIC, AV_NPWP) values
                      ('{ddljp.Text}', '{txtperusahaan.Value}', '{txttelpper.Value}', '{txtemailper.Value}', '{txtbankper.Text}', '{txtrekper.Value}', '{txtpic.Value}', '{txttelppic.Value}', '{txtemailpic.Value}', '{txtbankpic.Text}', '{txtrekpic.Value}', '{txtnpwpper.Value}')";
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