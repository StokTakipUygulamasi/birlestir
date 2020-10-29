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
    public class Urunler
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");

        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;
        // ID ile Ürün bilgilerini çekme fonksiyonu
        public static string[] urunCek(string id)
        {
            string[] dizi = new string[12];
            cmd = new MySqlCommand($@"select u.ID, u.Urun_Adi,u.Barkod_No,u.Aciklama,u.KDV_Orani,u.Kar_Orani,u.Satis_Fiyati,u.Satista_mi, u.Olcu_Miktar, u.Resim, ob.Olcu_Birimi , u.Kritik_Durum
                                    from urunler u  join olcu_birimi ob on u.Olcu_Birimi_ID = ob.ID where u.id={id}", baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    dizi[0] = reader["ID"].ToString();
                    dizi[1] = reader["Urun_Adi"].ToString();
                    dizi[2] = reader["Barkod_No"].ToString();
                    dizi[3] = reader["Aciklama"].ToString();
                    dizi[4] = reader["KDV_Orani"].ToString();
                    dizi[5] = reader["Kar_Orani"].ToString();
                    dizi[6] = reader["Satis_Fiyati"].ToString();
                    dizi[7] = reader["Olcu_Birimi"].ToString();
                    dizi[8] = reader["Satista_Mi"].ToString();
                    dizi[9] = reader["Olcu_Miktar"].ToString();
                    dizi[10] = reader["Resim"].ToString();
                    dizi[11] = reader["Kritik_Durum"].ToString();
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

        // Ürün Adı ile ürünün bilgilerini çekme fonksiyonu (Stok adedi vs dahil)
        public static string[] isimleUrunBilgileriCek(string urun_Adi)
        {
            string[] dizi = new string[6];
            cmd = new MySqlCommand($@"select u.ID, s.Eldeki_Miktar as 'Stok_Adedi', u.Urun_Adi,u.Satis_Fiyati, u.Resim, ob.ID as 'Olcu_Birimi_ID'
                                    from urunler u left join  stok s on s.Urun_ID = u.ID left join olcu_birimi ob on ob.ID = u.Olcu_Birimi_ID where u.Urun_Adi='{urun_Adi}'", baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    dizi[0] = reader["ID"].ToString();
                    dizi[1] = reader["Urun_Adi"].ToString();
                    dizi[2] = reader["Satis_Fiyati"].ToString();
                    dizi[3] = reader["Resim"].ToString();
                    dizi[4] = reader["Stok_Adedi"].ToString();
                    dizi[5] = reader["Olcu_Birimi_ID"].ToString();
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

        // Combobox'a ürünleri doldurma ve ID ve Ürün Adı çekme fonksiyonu
        public static string[] tumUrunleriCek(ComboBox cmb)
        {
            string[] dizi = new string[11];

            cmd = new MySqlCommand($@"select u.ID, u.Urun_Adi, u.Satis_Fiyati, s.Eldeki_Miktar as 'Stok_Adedi' from urunler u left join stok s on u.ID = s.Urun_ID;", baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmb.Items.Add(reader["Urun_Adi"]);
                    dizi[0] = reader["ID"].ToString();
                    dizi[1] = reader["Urun_Adi"].ToString();
                    dizi[2] = reader["Satis_Fiyati"].ToString();
                    dizi[3] = reader["Stok_Adedi"].ToString();
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




        public static bool UrunEkle(Prm veri)
        {
            sbyte donen = 0;

            //MySqlCommand cmd = new MySqlCommand($@"insert into urunler (Urun_Adi,Barkod_No,Aciklama,KDV_Orani,Kar_Orani,Satis_Fiyati,Olcu_Birimi_ID,Satista_mi) values ('{veri.UrunAdi}','{veri.Barkod_No}', '{veri.Aciklama}', '{veri.KDV_Orani}','{veri.Kar_Orani}','{veri.Satis_Fiyati}','{veri.Olcu_Birimi_ID}','{veri.Satista_Mi}') ",baglan);
            MySqlCommand cmd = new MySqlCommand("insert into urunler (Urun_Adi, Barkod_No, Aciklama, KDV_Orani, Kar_Orani, Satis_Fiyati, Olcu_Birimi_ID, Satista_mi, Olcu_Miktar, Resim, Kritik_Durum) values " +
                "(@Urun_Adi, @Barkod_No, @Aciklama, @KDV_Orani, @Kar_Orani, @Satis_Fiyati, @Olcu_Birimi_ID, @Satista_mi, @Olcu_Miktar, @Resim, @Kritik_Sayi)", baglan);
            cmd.Parameters.AddWithValue("@Urun_Adi", veri.UrunAdi);
            cmd.Parameters.AddWithValue("@Satista_mi", veri.Satista_Mi);
            cmd.Parameters.AddWithValue("@Olcu_Miktar", veri.Olcu_Miktar);
            cmd.Parameters.AddWithValue("@Kritik_Sayi", veri.KritikDurum);

            if (!string.IsNullOrEmpty(veri.KDV_Orani.ToString()))  // KDV oranı null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@KDV_Orani", veri.KDV_Orani);
            }
            else
            {
                cmd.Parameters.AddWithValue("@KDV_Orani", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Kar_Orani.ToString()))  // Kar oranı null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Kar_Orani", veri.Kar_Orani);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Kar_Orani", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Olcu_Birimi_ID.ToString()))  // Ölçü birimi null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Olcu_Birimi_ID", veri.Olcu_Birimi_ID);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Olcu_Birimi_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Satis_Fiyati.ToString()))  // Satış fiyatı null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Satis_Fiyati", veri.Satis_Fiyati);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Satis_Fiyati", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Barkod_No.ToString()))  // Barkod null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Barkod_No", veri.Barkod_No);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Barkod_No", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Aciklama.ToString())) // Açıklama null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Aciklama", veri.Aciklama);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Aciklama", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Resim))  // Resim null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Resim", veri.Resim);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Resim", DBNull.Value);
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

        // Güncelleme İşlemi
        public static bool UrunuGuncelle(Prm veri, string id)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"update urunler set Urun_Adi=@Urun_Adi, Barkod_No=@Barkod_No, Aciklama=@Aciklama, KDV_Orani=@KDV_Orani, 
                                                  Kar_Orani=@Kar_Orani, Satis_Fiyati=@Satis_Fiyati, Olcu_Birimi_ID=@Olcu_Birimi_ID, Resim=@Resim,
                                                  Olcu_Miktar=@Olcu_Miktar, Kritik_Durum = @KritikDurum  where ID=@ID", baglan);
            cmd.Parameters.AddWithValue("@Urun_Adi", veri.UrunAdi);
            cmd.Parameters.AddWithValue("@Satista_mi", veri.Satista_Mi);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@KritikDurum", veri.KritikDurum);
            if (!string.IsNullOrEmpty(veri.KDV_Orani.ToString()))  // KDV oranı null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@KDV_Orani", veri.KDV_Orani);
            }
            else
            {
                cmd.Parameters.AddWithValue("@KDV_Orani", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Kar_Orani.ToString()))  // Kar oranı null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Kar_Orani", veri.Kar_Orani);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Kar_Orani", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Olcu_Birimi_ID.ToString()))  // Ölçü birimi null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Olcu_Birimi_ID", veri.Olcu_Birimi_ID);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Olcu_Birimi_ID", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Satis_Fiyati.ToString()))  // Satış fiyatı null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Satis_Fiyati", veri.Satis_Fiyati);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Satis_Fiyati", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Barkod_No.ToString()))  // Barkod null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Barkod_No", veri.Barkod_No);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Barkod_No", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Aciklama.ToString())) // Açıklama null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Aciklama", veri.Aciklama);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Aciklama", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Resim))  // Resim null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Resim", veri.Resim);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Resim", DBNull.Value);
            }

            if (!string.IsNullOrEmpty(veri.Olcu_Miktar.ToString()))  // Resim null mu yoksa bir değer gelmiş mi diye bakıyoruz.
            {
                cmd.Parameters.AddWithValue("@Olcu_Miktar", veri.Olcu_Miktar);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Olcu_Miktar", DBNull.Value);
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

        // Güncelleme İşlemi
        public static bool UrunuGeriAl(int id)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"update urunler set Satista_Mi=1  where ID='{id}'", baglan);

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
        // İD'si gönderilen ürünü silen fonksiyon
        public static bool UrunSil(string gelen_id)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"Update urunler set Satista_Mi=0 where id={gelen_id}", baglan);
            try
            {
                baglan.Open();
                donen = 1;
                cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show($"Hata: {e.ToString()}");
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
            MySqlCommand cmd = new MySqlCommand($@"select * from urunler where Barkod_No ='{barkodNo}' ", baglan);

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
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                baglan.Dispose();
            }


            return dönenDeger;

        }
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
             */


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


        public static bool IadeAl(Prm veri)
        {
            sbyte donen = 0;

            MySqlCommand cmd = new MySqlCommand($@"insert into stoktakipuygulamasi.urun_iade(Fatura_ID, Urun_ID, Iade_Adeti, Iade_Sebebi, Iade_Alan, Iade_Tarihi)
                                                values(@FaturaID,@UrunID,@Iade_Adet,@Iade_Sebeb,@IadeAlan,@IadeTarihi)", baglan);
            cmd.Parameters.AddWithValue("@FaturaID", veri.FaturaNo);
            cmd.Parameters.AddWithValue("@UrunID", veri.UrunID);
            cmd.Parameters.AddWithValue("@Iade_Adet", veri.IadeAdeti);
            cmd.Parameters.AddWithValue("@Iade_Sebeb", veri.IadeSebei);
            cmd.Parameters.AddWithValue("@IadeAlan", veri.CalisanID);
            cmd.Parameters.AddWithValue("@IadeTarihi", veri.IadeTarihi);
            
        
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
