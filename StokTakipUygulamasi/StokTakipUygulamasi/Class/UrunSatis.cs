
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Controls;
using StokTakipUygulamasi.Class.Parametreler;

namespace StokTakipUygulamasi
{
    public class UrunSatis
    {

        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");
        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;

        /*
        public static bool urunSatisEkle(Prm veri)
        {
            sbyte donen = 0;

            MySqlCommand cmd = new MySqlCommand("insert into stoktakipuygulamasi.urun_satis(Adet, Fiyat, Urun_ID, Urun_Olcu_Birimi_ID, Calisan_ID, Faturalar_ID)" +
                                                    " values(@Adet, @Fiyat, @UrunID, @OlcuBirimiID, @CalisanID, @FaturaID)", baglan);

            cmd.Parameters.AddWithValue("@Adet", veri.SiparisAdet);
            cmd.Parameters.AddWithValue("@Fiyat", veri.Satis_Fiyati);
            cmd.Parameters.AddWithValue("@UrunID", veri.UrunID);
            cmd.Parameters.AddWithValue("@OlcuBirimiID", veri.Olcu_Birimi_ID);
            cmd.Parameters.AddWithValue("@CalisanID", veri.CalisanID);
            cmd.Parameters.AddWithValue("@FaturaID", veri.FaturaID);
           
          

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
        public static bool VeresiyeEkle(Prm veri)
        {
            sbyte donen = 0;

            MySqlCommand cmd = new MySqlCommand("insert into stoktakipuygulamasi.veresiye(Para_Turu,Toplam_Bakiye," +
                "Musteri_ID, Calisan_ID, faturalar_ID) values(@ParaTuru,@ToplamBakiye,@MusteriID,@CalisanID,@FaturaID); ", baglan);

            cmd.Parameters.AddWithValue("@ParaTuru", veri.VeresiyeParaTuru);
            cmd.Parameters.AddWithValue("@ToplamBakiye", veri.VeresiyeToplamBorc);
            cmd.Parameters.AddWithValue("@MusteriID", veri.MusteriID);
            cmd.Parameters.AddWithValue("@CalisanID", veri.CalisanID);
            cmd.Parameters.AddWithValue("@FaturaID", veri.FaturaID);
        



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

        public static bool urunKontrol(string barkodNo)
        {
            bool dönenDeger = false;
            MySqlCommand cmd = new MySqlCommand($@"select * from urunler where Barkod_No ='{barkodNo}' ",baglan);

            MySqlDataReader reader;



            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dönenDeger = true;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                baglan.Dispose();
            }


            return dönenDeger;

        }

    */
    }
}
