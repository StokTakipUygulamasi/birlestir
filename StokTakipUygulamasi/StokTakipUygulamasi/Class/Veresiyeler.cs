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
    public class Veresiyeler
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");

        // ID ile Veresiye'den müşteri adsoyad ve toplam bakiyeyi çekme fonksiyonu
        public static string[] veresiyeGuncelleCek(int id)
        {
            string[] dizi = new string[2];
           
            MySqlCommand cmd;
            MySqlDataReader reader;
            cmd = new MySqlCommand($@"select  Concat(mus.Musteri_Adi,' ',mus.Musteri_Soyadi) as Musteri_AdSoyad,  ver.Toplam_Bakiye from musteriler mus left join musteri_bilgileri musbil on mus.ID = musbil.Musteri_ID left join veresiye ver on ver.Musteri_ID = mus.ID where ver.ID = '{id}'", baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dizi[0] = reader["Musteri_AdSoyad"].ToString();
                    dizi[1] = reader["Toplam_Bakiye"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.ToString()}");
            }
            finally
            {
                baglan.Dispose();
            }

            return dizi;

        }


        public static bool veresiyeBorcOde(Prm veri)
        {
            sbyte donen = 0;

            MySqlCommand cmd = new MySqlCommand("insert into veresiye_detay (Aciklama, Islem_Turu, Borc,Tahsilat,Veresiye_ID,Islem_Tarihi, Calisan_ID) values " +
              "(@Aciklama, @Islem_Turu, @Borc, @Tahsilat, @Veresiye_ID, @Islem_Tarihi, @Calisan_ID)", baglan);
            cmd.Parameters.AddWithValue("@Aciklama", veri.VeresiyeAciklama);
            cmd.Parameters.AddWithValue("@Islem_Turu", veri.IslemTuru);
            cmd.Parameters.AddWithValue("@Borc", veri.VeresiyeKalanBorc);
            cmd.Parameters.AddWithValue("@Tahsilat", veri.VeresiyeTahsilat);
            cmd.Parameters.AddWithValue("@Veresiye_ID", veri.Veresiye_ID);
            cmd.Parameters.AddWithValue("@Islem_Tarihi", veri.VeresiyeIslemTarihi);
            cmd.Parameters.AddWithValue("@Calisan_ID", veri.CalisanID);

            if (!string.IsNullOrEmpty(veri.ToptanciID.ToString()))
            {
                cmd.Parameters.AddWithValue("@ToptancilarID", veri.ToptanciID);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ToptancilarID",DBNull.Value);
            }
            
            // Varsayılan olarak fatura id'yi biz oluşturuyoruz.
            veri.FaturaID = 6;
            cmd.Parameters.AddWithValue("@FaturalarID", veri.FaturaID);


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


        public static bool veresiyeBorcGuncelle(int veresiyeID, int kalanBorc)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"update veresiye set Toplam_Bakiye='{kalanBorc}' where Id='{veresiyeID}'", baglan);
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
    }
}
