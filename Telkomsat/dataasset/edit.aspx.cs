using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Telkomsat.dataasset
{
    public partial class edit : System.Web.UI.Page
    {
        SqlConnection sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GCSConnectionString"].ConnectionString);
        string IDdata, idaset;
        protected void Page_Load(object sender, EventArgs e)
        {
            string idperangkat, idruangan, idrak;
            if (Request.QueryString["id"] != null)
            {
                IDdata = Request.QueryString["id"];
            }
            idaset = IDdata;
            
            string query5 = $@"select w.nama_wilayah, b.nama_bangunan, r.nama_ruangan, k.nama_rak, e.nama_jenis_equipment, m.nama_merk, d.nama_jenis_device, r.image, p.* 
                    from as_perangkat p join as_jenis_device d on p.id_jenis_device = d.id_jenis_device left
                    join as_ruangan r on p.id_ruangan = r.id_ruangan left join as_rak k on k.id_rak = p.id_rak join as_bangunan b 
					on b.id_bangunan = r.id_bangunan left join as_merk m on p.id_merk=m.id_merk
                     join as_jenis_equipment e on e.id_jenis_equipment = d.id_jenis_equipment join as_wilayah w on w.id_wilayah = b.id_wilayah 
                    where p.id_perangkat = '{idaset}'";

            SqlCommand cmd = new SqlCommand(query5, sqlCon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            sqlCon.Open();
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            if (!object.Equals(ds.Tables[0], null))
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    idperangkat = ds.Tables[0].Rows[0]["id_perangkat"].ToString();
                    idruangan = ds.Tables[0].Rows[0]["id_ruangan"].ToString();
                    idrak = ds.Tables[0].Rows[0]["id_rak"].ToString();
                    lblequipment.Text = ds.Tables[0].Rows[0]["nama_jenis_equipment"].ToString();
                    lbldevice.Text = ds.Tables[0].Rows[0]["nama_jenis_device"].ToString();
                    lblsite.Text = ds.Tables[0].Rows[0]["nama_wilayah"].ToString();
                    lblgedung.Text = ds.Tables[0].Rows[0]["nama_bangunan"].ToString();
                    lblruangan.Text = ds.Tables[0].Rows[0]["nama_ruangan"].ToString();
                    lblrak.Text = ds.Tables[0].Rows[0]["nama_rak"].ToString();
                    lblsite.Text = ds.Tables[0].Rows[0]["nama_wilayah"].ToString();
                    lblgedung.Text = ds.Tables[0].Rows[0]["nama_bangunan"].ToString();
                    lblruangan.Text = ds.Tables[0].Rows[0]["nama_ruangan"].ToString();
                    lblrak.Text = ds.Tables[0].Rows[0]["nama_rak"].ToString();
                    lblmerk.Text = ds.Tables[0].Rows[0]["nama_merk"].ToString();
                    lbltipe.Text = ds.Tables[0].Rows[0]["tipe_perangkat"].ToString();
                    
                    lblsatelit.Text = ds.Tables[0].Rows[0]["satelit"].ToString();
                    
                    lblfungsi.Text = ds.Tables[0].Rows[0]["fungsi"].ToString();
                    lblstatus.Text = ds.Tables[0].Rows[0]["status"].ToString();
                    lblketerangan.Text = ds.Tables[0].Rows[0]["info"].ToString();
                    lbltanggal.InnerText = ds.Tables[0].Rows[0]["tanggal"].ToString();
                    myImg.Src = ds.Tables[0].Rows[0]["image"].ToString();

                    if (!IsPostBack)
                    {
                        txtmodel.Text = ds.Tables[0].Rows[0]["model"].ToString();
                        txtpn.Text = ds.Tables[0].Rows[0]["pn"].ToString();
                        txtsn.Text = ds.Tables[0].Rows[0]["sn"].ToString();
                        txttahunpengadaan.Text = ds.Tables[0].Rows[0]["tahun_pengadaan"].ToString();
                    }
                    
                }
            }
            divsuccess.Visible = true;
        }
        
        protected void Save_Click(object sender, EventArgs e)
        {
            string myquery = $"UPDATE as_perangkat SET model='{txtmodel.Text}', pn='{txtpn.Text}', sn='{txtsn.Text}', tahun_pengadaan='{txttahunpengadaan.Text}' WHERE id_perangkat='{idaset}'";
            sqlCon.Open();
            SqlCommand cmd = new SqlCommand(myquery, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
        }
    }
}