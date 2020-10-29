using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using StokTakipUygulamasi.Class.Parametreler;

namespace StokTakipUygulamasi.Class
{
    public class UrunAlis
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");

        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;
        /*

        public static bool urunlerAlisEkle(Prm prm)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"insert into stoktakipuygulamasi.urun_alis(Alis_Fiyati, Adet, Alis_Zamani, Toptanci_ID, Urun_ID,
                                                Urun_Olcu_Birimi_ID, Calisan_ID, faturalar_ID) 
                                                values (@AlisFiyat,@Adet,@Alis_Zamani,@Toptanci_ID,@Urun_ID,@Urun_Olcu_Birimi_ID,@Calisan_ID,@Fatura_ID)", baglan);


            cmd.Parameters.AddWithValue("@AlisFiyat", prm.UrunAlisFiyat);
            cmd.Parameters.AddWithValue("@Adet", prm.SiparisAdet);
            cmd.Parameters.AddWithValue("@Alis_Zamani", prm.UrunAlisTarih);
            cmd.Parameters.AddWithValue("@Toptanci_ID", prm.ToptanciID);
            cmd.Parameters.AddWithValue("@Urun_ID", prm.UrunID);
            cmd.Parameters.AddWithValue("@Urun_Olcu_Birimi_ID", prm.Olcu_Birimi_ID);
            cmd.Parameters.AddWithValue("@Calisan_ID", prm.CalisanID);
            //cmd.Parameters.AddWithValue("@Siparis_Tarihi", prm.SiparisTarihi);
            cmd.Parameters.AddWithValue("@Fatura_ID", prm.FaturaID);


            /*
              sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"insert into stoktakipuygulamasi.urun_alis(Alis_Fiyati, Adet, Alis_Zamani, Toptanci_ID, Urun_ID,
                                                Urun_Olcu_Birimi_ID, Calisan_ID, faturalar_ID) 
                                                values (@AlisFiyat,@Adet,@Alis_Zamani,@Toptanci_ID,@Urun_ID,@Urun_Olcu_Birimi_ID,@Calisan_ID,@Calisan_ID,@Fatura_ID)", baglan);


            cmd.Parameters.AddWithValue("@AlisFiyat",prm.UrunAlisFiyat);
            cmd.Parameters.AddWithValue("@Adet", prm.SiparisAdet);
            cmd.Parameters.AddWithValue("@Alis_Zamani", prm.UrunAlisTarih);
            cmd.Parameters.AddWithValue("@Toptanci_ID", prm.ToptanciID);
            cmd.Parameters.AddWithValue("@Urun_ID", prm.UrunID);
            cmd.Parameters.AddWithValue("@Urun_Olcu_Birimi_ID", prm.Olcu_Birimi_ID);
            cmd.Parameters.AddWithValue("@Calisan_ID", prm.CalisanID);
            //cmd.Parameters.AddWithValue("@Siparis_Tarihi", prm.SiparisTarihi);
            cmd.Parameters.AddWithValue("@Fatura_ID", prm.FaturaID);
             
        *-/

            try
            {
                baglan.Open();
                donen = 1;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                baglan.Dispose();
            }

            if (donen > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
    }
}
