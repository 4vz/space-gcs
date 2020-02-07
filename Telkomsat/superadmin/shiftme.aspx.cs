using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Services;
using System.Configuration;

namespace Telkomsat.superadmin
{
    public partial class shiftme : System.Web.UI.Page
    {
        string query1, iddata, query, tanggal, petugas, jadwal, style3;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Init(object sender, EventArgs e)
        {
            if (Session["username"] == null)
                Response.Redirect("~/login.aspx");

            if (Session["previllage"].ToString() == "adminme" || Session["username"].ToString() == "super")
            {

            }
            else
            {
                Response.Redirect("~/dashboard2.aspx");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            tableticket();
            if(Request.QueryString["save"] != null)
            {
                divsuccess.Visible = true;
            }
        }

        public class inisial
        {
            public string idshift { get; set; }
            public string idshift2 { get; set; }
            public string idpetugas { get; set; }
            public string petugas { get; set; }
            public string jadwal { get; set; }
            public string tanggalshift { get; set; }
            public string jadwal2 { get; set; }
            public string tanggalshift2 { get; set; }
        }

        [WebMethod]
        public static List<inisial> Get1(string sopetugas1)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"select id_shift, petugas, tanggal_shift, jadwal from shiftme s join shiftme_petugas p on p.id_petugas=s.id_petugas  where s.id_petugas = '{sopetugas1}' "))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            DateTime waktu = (DateTime)sdr["tanggal_shift"];
                            string mytanggal = waktu.ToString("dd/MM/yyyy");
                            mydata.Add(new inisial
                            {
                                idshift = sdr["id_shift"].ToString(),
                                tanggalshift = mytanggal,
                                jadwal = sdr["jadwal"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        [WebMethod]
        public static List<inisial> Get2(string sopetugas2)
        {
            string constr = ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand($"select id_shift, petugas, tanggal_shift, jadwal from shiftme s join shiftme_petugas p on p.id_petugas=s.id_petugas  where s.id_petugas = '{sopetugas2}' "))
                {
                    cmd.Connection = con;
                    List<inisial> mydata = new List<inisial>();
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            DateTime waktu = (DateTime)sdr["tanggal_shift"];
                            string mytanggal = waktu.ToString("dd/MM/yyyy");
                            mydata.Add(new inisial
                            {
                                idshift2 = sdr["id_shift"].ToString(),
                                tanggalshift2 = mytanggal,
                                jadwal2 = sdr["jadwal"].ToString(),
                            });
                        }
                    }
                    con.Close();
                    return mydata;
                }
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            //Response.Write(data);
            string query5 = $"Update shiftme set id_petugas = '{slpetugas2.Value}', sweep = '{txtalasan.Text}' where id_shift = '{txtid1.Text}'";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query5, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();

            string query6 = $"Update shiftme set id_petugas = '{slpetugas1.Value}', sweep = '{txtalasan.Text}' where id_shift = '{txtid2.Text}'";
            sqlCon.Open();
            SqlCommand cmd1 = new SqlCommand(query6, sqlCon);
            cmd1.ExecuteNonQuery();
            sqlCon.Close();

            this.ClientScript.RegisterStartupScript(this.GetType(), "clientClick", "fungsi()", true);
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string waktu = DateTime.Now.ToString("yyyy/MM/dd");
            int j = 0;
            string petugas;
            petugas = txtsatelit.Text;
            int result2 = petugas.Split(',').Length;
            string[] akhir = new string[result2];
            string[] lines = Regex.Split(petugas, ",");
            

            foreach (string line in lines)
            {
                akhir[j] = "('" + line + "','" + txttanggal.Text + "','" + ddljadwal.Text + "','" + "Syehab" + "','" + waktu + "')";
                j++;
            }
            string data = string.Join(",", akhir);
            //Response.Write(data);
            query1 = $"insert into shiftme (id_petugas, tanggal_shift, jadwal, pic, tanggal) values {data}";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(query1, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            
            Response.Redirect("../superadmin/shiftme.aspx?save=y");
        }

        void tableticket()
        {
            query = @"SELECT m.tanggal_shift, jadwal, STUFF((SELECT ',  ' + p.petugas 
                      FROM shiftme s left join shiftme_petugas p on s.id_petugas = p.id_petugas
					  WHERE m.jadwal = s.jadwal and m.tanggal_shift = s.tanggal_shift
                      FOR XML PATH('')), 1, 1, '') [petugas] FROm shiftme m group by tanggal_shift, jadwal
                      order by tanggal_shift desc, jadwal desc";

            SqlCommand cmd = new SqlCommand(query, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            htmlTable.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-hover table-striped\">");
            htmlTable.Append("<thead>");
            htmlTable.Append("<tr><th>Tanggal</th><th>Jadwal</th><th>Petugas</th><th>Action</th></tr>");
            htmlTable.Append("</thead>");

            htmlTable.Append("<tbody>");
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        petugas = ds.Tables[0].Rows[i]["petugas"].ToString();
                        jadwal = ds.Tables[0].Rows[i]["jadwal"].ToString();
                        DateTime tshift = (DateTime)ds.Tables[0].Rows[i]["tanggal_shift"];
                        tanggal = tshift.ToString("dddd, dd MMMM yyyy");
                        string mytanggal = tshift.ToString("yyyy/MM/dd");
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + "<label style=\"font-size:10px; color:#a9a9a9; font-color width:70px;\">" + tanggal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + jadwal + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<label style=\"{style3}\">" + petugas + "</label>" + "</td>");
                        htmlTable.Append("<td>" + $"<a onclick=\"confirmdelete('../superadmin/hapus.aspx?tanggalsh={mytanggal}&jadwalsh={jadwal}')\" class=\"btn btn-sm btn-danger\" style=\"margin-right:10px\">" + "Delete" + "</a>" + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    htmlTable.Append("</tbody>");
                    htmlTable.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
                }
            }
        }

    }
}