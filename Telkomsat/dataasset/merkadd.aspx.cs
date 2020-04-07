using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;
using System.Configuration;

namespace Telkomsat.dataasset
{
    public partial class merkadd : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public class inisial
        {
            public string idequipment { get; set; }
            public string equipment { get; set; }
            public string iddevice { get; set; }
            public string device { get; set; }
        }

        [WebMethod]
        public static List<inisial> GetID()
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * from as_jenis_equipment"))
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
                                idequipment = sdr["id_jenis_equipment"].ToString(),
                                equipment = sdr["nama_jenis_equipment"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> Getmerk(string videoid)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"SELECT * from as_jenis_device where id_jenis_equipment = '{videoid}'"))
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
                                iddevice = sdr["id_jenis_device"].ToString(),
                                device = sdr["nama_jenis_device"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        protected void Tambah_ServerClick(object sender, EventArgs e)
        {
            var datetime1 = DateTime.Now.ToString("yyyy/MM/dd h:m:s");
            sqlCon.Open();
            string query = $@"INSERT INTO as_merk (id_jenis_device ,nama_merk, tanggal) VALUES
                               ('{TextBox2.Text}', '{txtmerk.Text}', '{datetime1}')";
            SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
            sqlcmd.ExecuteNonQuery();
            sqlCon.Close();
            divsuccess.Visible = true;
        }
    }
}