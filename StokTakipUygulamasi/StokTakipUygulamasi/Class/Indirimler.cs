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
    public class Indirimler
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");

        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;

        // İndirimdekiler sayfasının verilerini çekiyoruz
        public static string[] indirimdekiler_guncelle_urun_Cek(string indirim_id)
        {
            string[] dizi = new string[12];
            cmd = new MySqlCommand($@"Select u.Resim as 'Urun_Resmi', i.ID as 'Indirim_ID', u.ID as 'Urun_ID',u.Urun_Adi,u.Satis_Fiyati as 'Indirimsiz_Satis_Fiyati',  i.Baslangic_Tarihi, i.Bitis_Tarihi, i.Yuzde, i.Indirimde_mi, i.Indirim_Taban_Fiyati, i.Satis_Fiyati, s.Eldeki_Miktar as 'Stok_Adedi' from indirimdekiler i left join urunler u on i.Urunler_ID = u.ID left join stok s on s.Urun_ID = u.ID where i.ID={indirim_id}", baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    dizi[0] = reader["Indirim_ID"].ToString();
                    dizi[1] = reader["Urun_ID"].ToString();
                    dizi[2] = reader["Urun_Adi"].ToString();
                    dizi[3] = reader["Indirimsiz_Satis_Fiyati"].ToString();
                    dizi[4] = reader["Baslangic_Tarihi"].ToString();
                    dizi[5] = reader["Bitis_Tarihi"].ToString();
                    dizi[6] = reader["Yuzde"].ToString();
                    dizi[7] = reader["Indirimde_mi"].ToString();
                    dizi[8] = reader["Indirim_Taban_Fiyati"].ToString();
                    dizi[9] = reader["Satis_Fiyati"].ToString();
                    dizi[10] = reader["Stok_Adedi"].ToString();
                    dizi[11] = reader["Urun_Resmi"].ToString();
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

        // Ürünü indirimdekilerden çıkaran fonksiyon
        public static bool indirimdekilerden_cikar(string id)
        {
           
            sbyte i = 0;
            cmd = new MySqlCommand($@"Update indirimdekiler set Indirimde_mi='0' where id='{id}'", baglan);
            try
            {
                baglan.Open();
                cmd.ExecuteNonQuery();
                i = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.ToString()}");
            }
            finally
            {
                baglan.Dispose();
            }

            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // İndirimdekiler güncelleme işlemi
        public static bool IndirimdekilerGuncelle(Prm veri, string indirim_id)
        {
            sbyte donen = 0;
            
            MySqlCommand cmd = new MySqlCommand($@"update indirimdekiler set Baslangic_Tarihi=@Baslangic_Tarihi, Bitis_Tarihi=@Bitis_Tarihi, Yuzde=@Yuzde, Satis_Fiyati=@Satis_Fiyati, Indirim_Taban_Fiyati=@Indirim_Taban_Fiyati, Indirimde_mi=@Indirimde_mi where ID=@IndirimID", baglan);
            cmd.Parameters.AddWithValue("@Baslangic_Tarihi", veri.IndirimBaslangicTarihi);
            cmd.Parameters.AddWithValue("@Bitis_Tarihi", veri.IndirimBitisTarihi);
            cmd.Parameters.AddWithValue("@IndirimID", indirim_id);
            cmd.Parameters.AddWithValue("@Satis_fiyati", veri.IndirimliSatisFiyati);
            cmd.Parameters.AddWithValue("@Indirim_Taban_fiyati", veri.IndirimTabanFiyati);
            cmd.Parameters.AddWithValue("@Indirimde_mi", veri.Indirimde_mi);
            if (!string.IsNullOrEmpty(veri.IndirimYuzde.ToString()))  // KDV oranı null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Yuzde", veri.IndirimYuzde);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Yuzde", DBNull.Value);
            }

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

        public static bool IndirimlereEkle(Prm veri)
        {
            sbyte donen = 0;
           
            MySqlCommand cmd = new MySqlCommand("insert into indirimdekiler (Baslangic_Tarihi,Bitis_Tarihi,Yuzde,Satis_Fiyati,Indirimde_mi,Urunler_ID,Urunler_Olcu_Birimi_ID,Indirim_Taban_Fiyati) values (@BaslangicTarihi,@BitisTarihi,@Yuzde,@SatisFiyati,@IndirimdeMi,@UrunID,@OlcuBirimiID,@IndirimTabanFiyati)", baglan);
            cmd.Parameters.AddWithValue("@BaslangicTarihi", veri.IndirimBaslangicTarihi);
            cmd.Parameters.AddWithValue("@BitisTarihi", veri.IndirimBitisTarihi);
            cmd.Parameters.AddWithValue("@SatisFiyati", veri.IndirimliSatisFiyati);
            cmd.Parameters.AddWithValue("@IndirimdeMi", veri.Indirimde_mi);
            cmd.Parameters.AddWithValue("@OlcuBirimiID", veri.Olcu_Birimi_ID);
            cmd.Parameters.AddWithValue("@IndirimTabanFiyati", veri.IndirimTabanFiyati);
            cmd.Parameters.AddWithValue("@UrunID", veri.ID);
            if (!string.IsNullOrEmpty(veri.IndirimYuzde.ToString()))
            {
                cmd.Parameters.AddWithValue("@Yuzde", veri.IndirimYuzde);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Yuzde", DBNull.Value);
            }


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
