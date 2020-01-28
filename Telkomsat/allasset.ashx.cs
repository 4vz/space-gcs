using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Configuration;

namespace Telkomsat
{
    /// <summary>
    /// Summary description for allasset
    /// </summary>
    public class allasset : IHttpHandler
    {
        public class Employee
        {
            public int idperangkat { get; set; }
            public string equipment { get; set; }
            public string device { get; set; }
            public string merk { get; set; }
            public string wilayah { get; set; }
            public string model { get; set; }
            public string pn { get; set; }
            public string sn { get; set; }
            public string ruangan { get; set; }
            public string gudang { get; set; }
            public string satelit { get; set; }
            public string rak { get; set; }
            public string tahun { get; set; }
            public string fungsi { get; set; }
            public string status { get; set; }
            public string action { get; set; }
            public string tipe { get; set; }
            public string tipesn { get; set; }
        }


        public void ProcessRequest(HttpContext context)
        {
            string term = context.Request["term"] ?? "";
            List<string> listStudentNames = new List<string>();
            List<Employee> listEmployees = new List<Employee>();
            string cs = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = @"select w.nama_wilayah, b.nama_bangunan, r.nama_ruangan, k.nama_rak, e.nama_jenis_equipment, m.nama_merk, d.nama_jenis_device, r.image, p.* 
                    from as_perangkat p join as_jenis_device d on p.id_jenis_device = d.id_jenis_device left
                    join as_ruangan r on p.id_ruangan = r.id_ruangan left join as_rak k on k.id_rak = p.id_rak join as_bangunan b 
					on b.id_bangunan = r.id_bangunan left join as_merk m on p.id_merk=m.id_merk
                     join as_jenis_equipment e on e.id_jenis_equipment = d.id_jenis_equipment join as_wilayah w on w.id_wilayah = b.id_wilayah";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.idperangkat = Convert.ToInt32(rdr["id_perangkat"]);
                    employee.device = rdr["nama_jenis_device"].ToString();
                    employee.merk = rdr["nama_merk"].ToString();
                    employee.wilayah = rdr["nama_wilayah"].ToString();
                    employee.sn = rdr["sn"].ToString();
                    employee.fungsi = rdr["fungsi"].ToString();
                    employee.ruangan = rdr["nama_ruangan"].ToString();
                    employee.rak = rdr["nama_rak"].ToString();
                    employee.equipment = rdr["nama_jenis_equipment"].ToString();
                    employee.model = rdr["model"].ToString();
                    employee.pn = rdr["pn"].ToString();
                    employee.satelit = rdr["satelit"].ToString();
                    employee.status = rdr["status"].ToString();
                    employee.gudang = rdr["nama_bangunan"].ToString();
                    employee.tipe = rdr["tipe_perangkat"].ToString();
                    employee.tahun = rdr["tahun_pengadaan"].ToString();
                    employee.action = $"<a href=\"../dataasset/detail.aspx?id={rdr["id_perangkat"].ToString()}\" style=\"margin-right:10px\">" + "View" + "</a>";
                    listEmployees.Add(employee);
                }
            }

            var result = new
            {
                aaData = listEmployees
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(result));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}