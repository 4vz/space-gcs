using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Telkomsat.checklistme
{
    public partial class cobadata : System.Web.UI.Page
    {
        SqlDataAdapter da, da2, das, dam;
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        DataSet dss = new DataSet();
        DataSet dsm = new DataSet();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable1 = new StringBuilder();
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            mytable();


        }

        protected void Filter_ServerClick(object sender, EventArgs e)
        {
            
        }

        void mytable()
        {
            SqlDataAdapter da, da2, da3, dam;
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();
            DataSet dss = new DataSet();

            string queryroom, queryall, queryparameter, ruangan, room, sn, device, parameter, satuan;
           
            queryroom = "select ruangan from checkme_perangkat group by ruangan";
            SqlCommand cmd = new SqlCommand(queryroom, sqlCon);
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    htmlTable1.Append("<table id=\"example2\" width=\"100%\" class=\"table table-bordered table-striped\">");
                    htmlTable1.Append("<thead>");
                    htmlTable1.Append("<tr><th>Parameter</th><th>Data</th><th>Satuan</th></tr>");
                    htmlTable1.Append("</thead>");
                    htmlTable1.Append("<tbody>");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ruangan = ds.Tables[0].Rows[i]["ruangan"].ToString();
                        queryall = $@"select p.ruangan, p.Perangkat, p.sn from checkme_parameter r INNER join
                                    checkme_perangkat p on p.id_perangkat = r.id_perangkat where p.ruangan = '{ruangan}'
									group by p.perangkat, p.sn, p.ruangan ";
                        SqlCommand cmd1 = new SqlCommand(queryall, sqlCon);
                        da2 = new SqlDataAdapter(cmd1);
                        da2.Fill(ds2);
                        sqlCon.Open();
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                        room = ds2.Tables[0].Rows[i]["ruangan"].ToString();
                        device = ds2.Tables[0].Rows[i]["Perangkat"].ToString();
                        
                        
                        htmlTable1.Append($"<tr><td colspan=\"3\" style=\"font-weight:bold; font-size:16px;\">{room}</tr>");
                        if (ds2.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds2.Tables[0].Rows.Count; j++)
                            {
                                sn = ds2.Tables[0].Rows[j]["sn"].ToString();
                                queryparameter = $@"select p.ruangan, r.id_parameter, p.Perangkat, r.satuan, p.sn, r.parameter, r.tipe from checkme_parameter r INNER join
                                    checkme_perangkat p on p.id_perangkat = r.id_perangkat where p.ruangan = '{ruangan}'
									and p.sn = '{sn}' order by r.id_perangkat";
                                SqlCommand cmd2 = new SqlCommand(queryparameter, sqlCon);
                                da3 = new SqlDataAdapter(cmd2);
                                da3.Fill(ds3);
                                sqlCon.Open();
                                cmd.ExecuteNonQuery();
                                sqlCon.Close();
                                htmlTable1.Append($"<tr><td colspan=\"3\" style=\"font-weight:bold\">{ds2.Tables[0].Rows[j]["perangkat"].ToString()}  ({ds2.Tables[0].Rows[j]["sn"].ToString()})</tr>");
                                if (ds3.Tables[0].Rows.Count > 0)
                                {
                                    for (int k = 0; k < ds3.Tables[0].Rows.Count; k++)
                                    {
                                        satuan = ds3.Tables[0].Rows[k]["satuan"].ToString();
                                        parameter = ds3.Tables[0].Rows[k]["parameter"].ToString();
                                        htmlTable1.Append("<tr>");
                                        htmlTable1.Append("<td>" + parameter + "</td>");
                                        htmlTable1.Append("<td>" + "data" + "</td>");
                                        htmlTable1.Append("<td>" + satuan + "</td>");
                                        htmlTable1.Append("</tr>");
                                    }
                                }
                            }
                        }
                        
                    }
                    htmlTable1.Append("</tbody>");
                    htmlTable1.Append("</table>");
                    DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable1.ToString() });
                }
            }
        }
    }
}