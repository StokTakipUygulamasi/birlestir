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
    public class OlcuBirimleri
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");

        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;


        public static bool olcuBirimiSilGeriAl(int ID, string islem)
        {
            bool donen = false;
            if (islem.ToLower() == "sil")
            {
                MySqlCommand cmd = new MySqlCommand($@"update olcu_birimi set Silindi_Mi=1 where ID='{ID}'",baglan);
                try
                {
                    baglan.Open();
                    cmd.ExecuteNonQuery();
                    donen = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    donen = false;
                }
                finally
                {
                    baglan.Dispose();
                }
            }
            else if(islem.ToLower() == "geri al")
            {
                MySqlCommand cmd = new MySqlCommand($@"update olcu_birimi set Silindi_Mi = 0 where ID='{ID}'",baglan);
                try
                {
                    baglan.Open();
                    cmd.ExecuteNonQuery();
                    donen = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    donen = false;
                }
                finally
                {
                    baglan.Dispose();
                }
            }

          
            return donen;

        }

        public static bool olcuBirimiAdiGuncelle(int obID,string yeniOlcubirimiAdi)
        {
            bool donen = false;
            MySqlCommand cmd = new MySqlCommand($@"update olcu_birimi set Olcu_Birimi='{yeniOlcubirimiAdi}' where ID='{obID}'",baglan);
            try
            {
                baglan.Open();
                cmd.ExecuteNonQuery();
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

        public static bool olcuBirimiEkle(string OlcuBirimiAdi)
        {
            bool donen = false;
            string olcuBirimiKontrolSorgusu = $@"Select * from olcu_birimi where Olcu_Birimi='{OlcuBirimiAdi}'";
            int olcuBirimiKontrol = Genel.tekilVeriCekmeInt(olcuBirimiKontrolSorgusu, "ID");
            if (olcuBirimiKontrol > 0)
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Böyle bir ölçü birimi zaten var!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
                donen = false;
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand($@"insert into olcu_birimi (Olcu_Birimi) values (@OlcuBirimiAdi)", baglan);
                cmd.Parameters.AddWithValue("@OlcuBirimiAdi",OlcuBirimiAdi);
                try
                {
                    baglan.Open();
                    cmd.ExecuteNonQuery();
                    donen = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    donen = false;
                }
                finally
                {
                    baglan.Dispose();
                }
            }

            return donen;

        }

    }
}
