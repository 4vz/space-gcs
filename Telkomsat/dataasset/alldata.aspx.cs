using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using ClosedXML.Excel;
using System.IO;
using System.Configuration;

namespace Telkomsat.dataasset
{
    public partial class alldata : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExportExcel(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = @"select w.nama_wilayah, b.nama_bangunan, r.nama_ruangan, k.nama_rak, e.nama_jenis_equipment, b.nama_bangunan, m.nama_merk, d.nama_jenis_device, r.image,
					p.tipe_perangkat,p.model,p.pn, p.sn, p.satelit, p.tahun_pengadaan, p.fungsi, p.status, p.info, p.tanggal 
                    from as_perangkat p join as_jenis_device d on p.id_jenis_device = d.id_jenis_device left
                    join as_ruangan r on p.id_ruangan = r.id_ruangan left join as_rak k on k.id_rak = p.id_rak join as_bangunan b 
					on b.id_bangunan = r.id_bangunan left join as_merk m on p.id_merk=m.id_merk
                     join as_jenis_equipment e on e.id_jenis_equipment = d.id_jenis_equipment join as_wilayah w on w.id_wilayah = b.id_wilayah";
                SqlCommand sqlcmd = new SqlCommand(query, sqlCon);
                
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sqlcmd.Connection = con;
                    sda.SelectCommand = sqlcmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            wb.Worksheets.Add(dt, "Asset");

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=DataAsset.xlsx");
                            using (MemoryStream MyMemoryStream = new MemoryStream())
                            {
                                wb.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }
                        }
                    }
                }

            }
        }

    }
}