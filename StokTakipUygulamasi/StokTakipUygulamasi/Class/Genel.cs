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
    public class Genel
    {

        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");

        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;
        /*
        public static void veriTabaniBaglanti()
        {
           MySqlConnection baglan = new MySqlConnection("Server=localhost;Database=stoktakipuygulamasi;Uid=root;Pwd=;Charset=utf8");
           MySqlCommand cmd;
           MySqlDataReader reader;
           MySqlDataAdapter adapter;
        }
        
       */
        
        // Saat ve dakikayı comboboxlara aktarma (Anlık saat ve dakika seçili gelecektir)
        public static void SaatDakikaCombobox(ComboBox cmbSaat, ComboBox cmbDakika)
        {
            DateTime zaman = DateTime.Now;
            string saat = zaman.Hour.ToString();
            string dakika = zaman.Minute.ToString();
            for (int x = 0; x <= 9; x++)
            {
                cmbSaat.Items.Add(("0" + x).ToString());
            }
            for (int y = 10; y <= 23; y++)
            {
                cmbSaat.Items.Add(y.ToString());
            }

            for (int i = 0; i <= 9; i++)
            {
                cmbDakika.Items.Add(("0" + i).ToString());
            }
            for (int a = 10; a <= 59; a++)
            {
                cmbDakika.Items.Add(a.ToString());
            }

            if (Convert.ToInt32(saat) < 10)
            {
                cmbSaat.SelectedItem = ("0" + saat).ToString();
            }
            else
            {
                cmbSaat.SelectedItem = saat;
            }
            if (Convert.ToInt32(dakika) < 10)
            {
                cmbDakika.SelectedItem = ("0" + dakika).ToString();
            }
            else
            {
                cmbDakika.SelectedItem = dakika;
            }


        }

        [Obsolete]
        public void girisYap(string kadi, string sifre, Window w)
        {
            
            cmd = new MySqlCommand($@"Select * from calisanlar where Kadi='{kadi}' and Sifre='{sifre}'", baglan);
            baglan.Open();
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                MessageBox.Show("Giriş Başarılı!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                Anasayfa ana = new Anasayfa();
                ana.Show();
                w.Close();
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            baglan.Close();
        }

        public static bool GridiDoldurGenel(DataGrid grd, String sorgu)
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

        // Tüm ölçü birimlerini çekme fonksiyonu
        public static ComboBox OlcuBirimleri(ComboBox cmb)
        {
   
            cmd = new MySqlCommand($@"Select * from olcu_birimi", baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmb.Items.Add(reader["Olcu_Birimi"]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Hata: {ex.ToString()}");
            }
            finally
            {
                baglan.Dispose();
            }
            return cmb;
        }

        public static ComboBox ComboBoxVeriCekme(ComboBox comboBox, String sorgu, String istenenDeger)
        {
        
            cmd = new MySqlCommand(sorgu, baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox.Items.Add(reader[istenenDeger]);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Hata: {ex.ToString()}");
            }
            finally
            {
                baglan.Dispose();
            }

            return comboBox;
        }

        public static string tekilVeriCekmeString(String sorgu, String istenenDeger)
        {
            String istenenSonuc = "";
            
            cmd = new MySqlCommand(sorgu, baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    istenenSonuc = reader[istenenDeger].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Hata: {ex.ToString()}");
            }
            finally
            {
                baglan.Dispose();
            }

            return istenenSonuc;
        }


        public static int tekilVeriCekmeInt(String sorgu, String istenenDeger)
        {
            int istenenSonuc = 0;
            cmd = new MySqlCommand(sorgu, baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    istenenSonuc = Int32.Parse(reader[istenenDeger].ToString());

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Hata: {ex.ToString()}");
            }
            finally
            {
                baglan.Dispose();
            }

            return istenenSonuc;
        }

        public static List<string> cokluVeriCekme(String sorgu, List<string> istenenDeger, int eleman_sayisi)
        {
            List<string> liste = new List<string>();
            cmd = new MySqlCommand(sorgu, baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                /*
                foreach (var item in istenenDeger)
                {
                    liste.Add(reader[item].ToString());
                }
                */
                
                if (reader.Read())
                {
                    for (int i = 0; i < istenenDeger.Count; i++)

                    {
                        liste.Add(reader[i].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Hata: {ex.ToString()}");
            }
            finally
            {
                baglan.Dispose();
            }

            return liste;
        }



        // Çalışanları çekme fonksiyonu
        public static bool calisanlari_cek(DataGrid grd)
        {
            sbyte i = 0;
            cmd = new MySqlCommand($@"select c.Ad, c.Soyad, y.Yetki from calisanlar c left join calisan_yetki cy on cy.Calisan_ID = c.ID left join yetkiler y on cy.Yetki_ID = y.ID", baglan);
            baglan.Open();
            try
            {
                adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                grd.ItemsSource = null;
                grd.ItemsSource = dt.DefaultView;
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
        public static List<String> TekUrunTümListeCek(String sorgu, string istenenDeger)
        {
            List<String> liste = new List<string>();

            cmd = new MySqlCommand(sorgu, baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(reader[istenenDeger].ToString());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($@"Hata: {ex.ToString()}");
            }
            finally
            {
                baglan.Dispose();
            }

            return liste;
        }


    }
}
