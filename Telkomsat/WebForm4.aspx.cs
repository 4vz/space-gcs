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
        int a = 3;
        int b = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
            string file = Request.QueryString["id"];
            double c = (double)a / b;

            DateTime awal = DateTime.Now;
            DateTime akhir = DateTime.Now.AddDays(1);

            TimeSpan t = akhir - awal;

            int day = DateTime.DaysInMonth(2020, 02);
            int days, j;
            j = 16;
            days = day - 15;
            string[] tanggalku = new string[days];
            for(int i = 0; i < days; i++)
            {
                tanggalku[i] = $@"sum(case 
				when s.tanggal_shift = '2020-02-{j}' and s.jadwal = 'Pagi' then 1
				when s.tanggal_shift = '2020-02-{j}' and s.jadwal = 'Sore' then 2 else 0 end) as '{j}'";
                j++;
            }

            string datatanggal = string.Join(",", tanggalku);

            string query1 = $@"SELECT p.petugas,{datatanggal}
		            FROM shiftme s
	            left JOIN shiftme_petugas p ON s.id_petugas=p.id_petugas
	                group by p.petugas";



            Response.Write(query1);
            //Response.Write(t.Days);
            //Response.Write(akhir);
        }

        protected void Upload(object sender, EventArgs e)
        {
            //Access the File using the Name of HTML INPUT File.
            HttpPostedFile postedFile = Request.Files["fileinputt"];
            Response.Write(postedFile.FileName);
            //Check if File is available.
            /*if (postedFile != null && postedFile.ContentLength > 0)
            {
                //Save the File.
                string filePath = Server.MapPath("~/evidence/") + Path.GetFileName(postedFile.FileName);
                postedFile.SaveAs(filePath);
            }*/
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