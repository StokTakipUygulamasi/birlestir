using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace StokTakipUygulamasi.Class
{
    public class HizliSatis
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;


        public static bool HizliSatisUrunleriGridiDoldur(DataGrid gelengrid)
        {
            bool donen = false;
            MySqlCommand hizliSatistakiler = new MySqlCommand($@"select * from urunler where Hizli_Satista_Mi = 1", baglan);

            adapter = new MySqlDataAdapter(hizliSatistakiler);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(String));
            dt.Columns.Add("Urun_Adi", typeof(string));
            dt.Columns.Add("Secim", typeof(bool));
            try
            {
                baglan.Open();

                reader = hizliSatistakiler.ExecuteReader();

                while (reader.Read())
                {
                    dt.Rows.Add(reader["ID"].ToString(), reader["Urun_Adi"].ToString(), true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }

            MySqlCommand hizliSatistaOlmayanlar = new MySqlCommand($@"select * from urunler where Hizli_Satista_Mi = 0", baglan);

            try
            {
                baglan.Open();
                reader = hizliSatistaOlmayanlar.ExecuteReader();

                while (reader.Read())
                {
                    dt.Rows.Add(reader["ID"].ToString(), reader["Urun_Adi"].ToString(), false);
                }
                gelengrid.ItemsSource = null;
                gelengrid.ItemsSource = dt.DefaultView;

                donen = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }


            return donen;
        }

        public static bool HizliSatisUrunleriUrunAraGridiDoldur(DataGrid gelengrid, List<string> IDList, string gelenDeger)
        {
            bool donen = false;
            bool kontrol = false;
            MySqlCommand hizliSatistakiler;
            if (gelenDeger == null)
            {
                hizliSatistakiler = new MySqlCommand($@"select * from urunler ", baglan);
            }
            else
            {
                hizliSatistakiler = new MySqlCommand($@"select * from urunler where Urun_Adi like '{gelenDeger}%'", baglan);
            }

            adapter = new MySqlDataAdapter(hizliSatistakiler);
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(String));
            dt.Columns.Add("Urun_Adi", typeof(string));
            dt.Columns.Add("Secim", typeof(bool));
            try
            {
                baglan.Open();

                reader = hizliSatistakiler.ExecuteReader();

                while (reader.Read())
                {
                    foreach (string sayi in IDList)
                    {
                        if (reader["ID"].ToString() == sayi)
                        {
                            dt.Rows.Add(reader["ID"].ToString(), reader["Urun_Adi"].ToString(), true);
                            kontrol = false;
                            break;
                        }
                        else
                        {
                            kontrol = true;
                        }
                    }
                    if (kontrol)
                    {
                        dt.Rows.Add(reader["ID"].ToString(), reader["Urun_Adi"].ToString(), false);
                        kontrol = false;
                    }

                }
                gelengrid.ItemsSource = null;
                gelengrid.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }



            return donen;
        }

        public static List<string> HizliSatistakiler()
        {
            List<string> liste = new List<string>();
            MySqlCommand cmd = new MySqlCommand($@"Select * from urunler where Hizli_Satista_Mi = 1",baglan);
            baglan.Open();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                liste.Add(reader["ID"].ToString());
            }
            baglan.Dispose();
            return liste;
        }

        public static bool HizliSatistakilerGuncelle(List<string> hizliSatisListesi)
        {
            bool donen = false;
            int hepsi = 0;
            try
            {
                MySqlCommand cmd = new MySqlCommand($@"update urunler set Hizli_Satista_Mi=0", baglan);
                baglan.Open();
                cmd.ExecuteNonQuery();
                hepsi = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }


            try
            {
                foreach (var item in hizliSatisListesi)
                {
                    baglan.Open();
                    MySqlCommand cmd2 = new MySqlCommand($@"update urunler set Hizli_Satista_Mi=1 where ID='{Convert.ToInt32(item)}'", baglan);
                    cmd2.ExecuteNonQuery();
                    baglan.Dispose();
                }
                hepsi = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           finally
            {
                baglan.Dispose();
            }

            if (hepsi == 2)
            {
                donen = true;
            }
            return donen;
        }

    }
}
