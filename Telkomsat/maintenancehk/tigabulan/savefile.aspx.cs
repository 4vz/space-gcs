using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Telkomsat.maintenancehk.tigabulan
{
    public partial class savefile : System.Web.UI.Page
    {
        string IDdata = "kitaa", equipment, start = "a", query, end = "", nilai, datafile, SN = "a", satelit, lokasi, jenisview = "", tahun;
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string[] filearray;
        string myid;
        int m = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["equipment"] != null)
            {
                satelit = Request.QueryString["satelit"];
                lokasi = Request.QueryString["lokasi"];
                equipment = Request.QueryString["equipment"];
                datafile = Request.QueryString["datafile"];
            }

            string[] filelist;


            string querydisp = $@"select d.id_data, d.data_aft, r.id_parameter, t.device, t.sn, r.parameter, r.satuan, r.tipe from mainhk_3m_data d 
                     join mainhk_3m_parameter r on r.id_parameter=d.id_parameter join mainhk_3m_perangkat t on t.id_perangkat=r.id_perangkat
                     where t.lokasi='{lokasi}' and t.satelit= '{satelit}' and t.equipment = '{equipment}' and 
                     r.parameter in ('Input Signal Level', 'Input C/N', 'Output Signal Level', 'Output C/N') order by r.id_parameter, t.sn";

            SqlDataAdapter daheader, dapersen, dabar, daaft;
            DataSet dsheader = new DataSet();
            sqlCon.Open();
            SqlCommand cmdheader = new SqlCommand(querydisp, sqlCon);
            daheader = new SqlDataAdapter(cmdheader);
            daheader.Fill(dsheader);
            cmdheader.ExecuteNonQuery();
            sqlCon.Close();
            //DataSet dsf = Settings.LoadDataSet(querydisp);

            //filelist = new string[dsf.Tables[0].Rows.Count];
            if (datafile != null)
            {
                string[] datelines = Regex.Split(datafile, "=~=");

                foreach (string dateline in datelines)
                {
                    //filelist[m] = dateline;
                    m++;
                }
            }
            /*if (dsf.Tables[0].Rows.Count > 0)
            {
                Response.Write("ya");
                for (int i = 0; i < dsf.Tables[0].Rows.Count; i++)
                {
                    myid = dsf.Tables[0].Rows[i]["id_data"].ToString();
                    string query = $@"update mainhk_3m_data set filebef='{filearray[i]}' where id_data='{myid}'";
                    SqlCommand cmd8 = Settings.ExNonQuery(query);
                }
            }*/

            Response.Write(dsheader.Tables[0].Rows.Count);
            Response.Write(querydisp);
        }
    }
}