using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Configuration;

namespace Telkomsat
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        //SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            string file = Request.QueryString["id"];
            Response.Write(file);
        }

        public class Customer
        {
            public string CustomerId { get; set; }
            public string ContactName { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string idperangkat { get; set; }
        }

        [WebMethod]
        public static List<Customer> GetCustomers(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT TOP 10 * FROM checkme_parameter where id_perangkat = '{videoid}'"))
                {
                    cmd.Connection = con;
                    List<Customer> customers = new List<Customer>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new Customer
                            {
                                CustomerId = sdr["id_parameter"].ToString(),
                                ContactName = sdr["id_perangkat"].ToString(),
                                City = sdr["parameter"].ToString(),
                                Country = sdr["satuan"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return customers;
                }
            }
        }

        [WebMethod]
        public static List<Customer> GetID()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 10 id_perangkat FROM checkme_parameter group by id_perangkat"))
                {
                    cmd.Connection = con;
                    List<Customer> customers = new List<Customer>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new Customer
                            {
                                idperangkat = sdr["id_perangkat"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return customers;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(so1.Value);
            Response.Write(so2.Value);
        }
    }
}