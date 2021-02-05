using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Configuration;
using System.Web.Http.Cors;
using System.Text.RegularExpressions;

namespace Telkomsat.API
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    /// <summary>
    /// Summary description for iot
    /// </summary>
    public class iot : IHttpHandler
    {
        EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
        string queryinsert, result;
        public void ProcessRequest(HttpContext context)
        {
            string term = context.Request["term"] ?? "";
            string cs = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                if (term != "")
                {
                    string[] hasil = new string[4];
                    string tanggal = DateTime.Now.AddHours(7).ToString("yyyy/MM/dd HH:mm:ss");
                    string[] lines = Regex.Split(term, ";");
                    int j = 0;
                    foreach (string line in lines)
                    {
                        //Response.Write(line);
                        hasil[j] = line;
                        j++;
                    }

                    if(hasil[0] == "429a76b08f61fab1970a757de084a696")
                    {
                        queryinsert = $"INSERT INTO IoT_Suhu (IS_Suhu, IS_Kelembaban, IS_code, IS_tanggal) values ('{hasil[1]}', '{hasil[2]}', '{hasil[3]}', '{tanggal}')";
                        SqlCommand cmd = Settings.ExNonQuery(queryinsert);

                        result = "success";
                    }
                    else
                    {
                        result = "failed";
                    }

                    
                }
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
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