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
    public class Siparisler
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");

        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;



        // ID ile Ürün bilgilerini çekme fonksiyonu
        public static string[] SiparisCek(int id)
        {
                        string[] dizi = new string[8];
        
            cmd = new MySqlCommand($@"Select s.ID, u.Urun_Adi,o.Olcu_Birimi, u.Olcu_Miktar,s.Adet ,s.Siparis_Tarihi, t.Toptanci_Adi, c.Ad,c.Soyad 
                            from urun_siparis s 
                            left join olcu_birimi o on s.Urun_Olcu_Birimi_ID = o.ID 
							left join urunler u on u.ID= s.Urun_ID
                            left join toptancilar t on t.ID = s.Toptanci_ID 
                            left join calisanlar c on c.ID = s.Calisan_ID 
                             where s.ID = '{id}'", baglan);


            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    dizi[0] = reader["ID"].ToString();
                    dizi[1] = reader["Adet"].ToString();
                    dizi[2] = reader["Siparis_Tarihi"].ToString();
                    dizi[3] = reader["Urun_Adi"].ToString();
                    dizi[4] = reader["Olcu_Birimi"].ToString();
                    dizi[5] = reader["Toptanci_Adi"].ToString();
                    dizi[6] = reader["Ad"].ToString();
                    dizi[7] = reader["Olcu_Miktar"].ToString();

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

        // Siparişler tablosuna ürün ekleme fonksiyonu
        public static bool SiparislereEkle(Prm veri)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand("insert into urun_siparis(Adet, Siparis_Tarihi, Urun_ID, Urun_Olcu_Birimi_ID, Toptanci_ID, " +
                "Calisan_ID, Silindi_Mi) values (@Adet, @Siparis_Tarihi, @Urun_ID, @Urun_Olcu_Birimi_ID, @Toptanci_ID, @Calisan_ID, 0);", baglan);


            cmd.Parameters.AddWithValue("@Adet", veri.SiparisAdet);
            cmd.Parameters.AddWithValue("@Siparis_Tarihi", veri.SiparisTarihi);
            cmd.Parameters.AddWithValue("@Urun_ID", veri.UrunID);
            cmd.Parameters.AddWithValue("@Urun_Olcu_Birimi_ID", veri.Olcu_Birimi_ID);
            cmd.Parameters.AddWithValue("@Toptanci_ID", veri.ToptanciID);
            cmd.Parameters.AddWithValue("@Calisan_ID", veri.CalisanID);


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



        public static bool GridiDoldurGenel(DataGrid grd, String sorgu, Button btn)
        {

            sbyte i = 0;

            cmd = new MySqlCommand(sorgu, baglan);
            baglan.Open();
            try
            {
                adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grd.ItemsSource = null;
                grd.ItemsSource = dt.DefaultView;
                i = 1;

                btn.IsEnabled = false;



            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
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

        // Siparişler tablosuna ürün güncelleme fonksiyonu
        public static bool SiparislerGuncelle(Prm veri, int siparis_id)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"update urun_siparis set Adet = @SiparisAdeti, Siparis_Tarihi = @SiparisTarihi where ID = @SiparisID ", baglan);
            cmd.Parameters.AddWithValue("@SiparisTarihi", veri.SiparisTarihi);
            cmd.Parameters.AddWithValue("@SiparisAdeti", veri.SiparisAdet);
            cmd.Parameters.AddWithValue("@SiparisID", siparis_id);

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



        public static bool SiparislerSil(Prm veri, int siparis_id)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"update urun_siparis set Silindi_Mi = @Sipariİptal, Silinme_Aciklamasi =@SiparisIptalAciklama where ID = @SiparisID" , baglan);
            cmd.Parameters.AddWithValue("@Sipariİptal", veri.SiparisIptal);
            cmd.Parameters.AddWithValue("@SiparisIptalAciklama", veri.SiparisIptalAciklama);
            cmd.Parameters.AddWithValue("@SiparisID", siparis_id);

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
