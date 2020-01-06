using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Configuration;

namespace Telkomsat.dataasset
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeService : System.Web.Services.WebService
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
        }

        [WebMethod]
        public List<string> GetStudentNames(string term)
        {
            List<string> listStudentNames = new List<string>();

            string cs = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand($"select nama_ruangan from as_ruangan where nama_ruangan like '%' + '{term}' + '%' ", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    listStudentNames.Add(rdr["nama_ruangan"].ToString());
                }
            }

            return listStudentNames;
        }

        [WebMethod]
        public void GetEmployees(int iDisplayLength, int iDisplayStart, int iSortCol_0,
            string sSortDir_0, string sSearch)
        {
            int displayLength = iDisplayLength;
            int displayStart = iDisplayStart;
            int sortCol = iSortCol_0;
            string sortDir = sSortDir_0;
            string search = sSearch;

            string cs = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            List<Employee> listEmployees = new List<Employee>();
            int filteredCount = 0;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("serverside", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramDisplayLength = new SqlParameter()
                {
                    ParameterName = "@DisplayLength",
                    Value = displayLength
                };
                cmd.Parameters.Add(paramDisplayLength);

                SqlParameter paramDisplayStart = new SqlParameter()
                {
                    ParameterName = "@DisplayStart",
                    Value = displayStart
                };
                cmd.Parameters.Add(paramDisplayStart);

                SqlParameter paramSortCol = new SqlParameter()
                {
                    ParameterName = "@SortCol",
                    Value = sortCol
                };
                cmd.Parameters.Add(paramSortCol);

                SqlParameter paramSortDir = new SqlParameter()
                {
                    ParameterName = "@SortDir",
                    Value = sortDir
                };
                cmd.Parameters.Add(paramSortDir);

                SqlParameter paramSearchString = new SqlParameter()
                {
                    ParameterName = "@Search",
                    Value = string.IsNullOrEmpty(search) ? null : search
                };
                cmd.Parameters.Add(paramSearchString);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Employee employee = new Employee();
                    employee.idperangkat = Convert.ToInt32(rdr["id_perangkat"]);
                    filteredCount = Convert.ToInt32(rdr["TotalCount"]);
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
                iTotalRecords = GetEmployeeTotalCount(),
                iTotalDisplayRecords = filteredCount,
                aaData = listEmployees
            };

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(result));
        }

        private int GetEmployeeTotalCount()
        {
            int totalEmployeeCount = 0;
            string cs = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new
                    SqlCommand(@"select count(*) from as_perangkat p join as_jenis_device d on p.id_jenis_device = d.id_jenis_device left
                    join as_ruangan r on p.id_ruangan = r.id_ruangan left join as_rak k on k.id_rak = p.id_rak join as_bangunan b
                    on b.id_bangunan = r.id_bangunan left join as_merk m on p.id_merk = m.id_merk
                     join as_jenis_equipment e on e.id_jenis_equipment = d.id_jenis_equipment join as_wilayah w on w.id_wilayah = b.id_wilayah ", con);
                con.Open();
                totalEmployeeCount = (int)cmd.ExecuteScalar();
            }
            return totalEmployeeCount;
        }
    }
}
