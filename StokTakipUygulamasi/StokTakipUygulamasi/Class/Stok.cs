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
    class Stok
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");

        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;
        public static bool StokaEkle(Prm veri)
        {
            sbyte donen = 0;

            MySqlCommand cmd = new MySqlCommand("insert into stok (Eldeki_Miktar, Toplam_Giris, Toplam_Cikis, Urun_ID, Urun_Olcu_Birimi_ID)" +
                " values (@Eldeki_Miktar,@Toplam_Giris,@Toplam_Cikis,@UrunID,@OlcuBirimiID);", baglan);
            cmd.Parameters.AddWithValue("@Eldeki_Miktar", veri.Stok_EldekiMiktar);
            cmd.Parameters.AddWithValue("@Toplam_Giris", veri.Stok_Toplam_Giris);
            cmd.Parameters.AddWithValue("@Toplam_Cikis", veri.Stok_Toplam_Cikis);
            cmd.Parameters.AddWithValue("@UrunID", veri.UrunID);
            cmd.Parameters.AddWithValue("@OlcuBirimiID", veri.Olcu_Birimi_ID);

       

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

        public static bool StokGuncelleStoktanCikar(Prm veri, int Urun_id)
        {
            sbyte donen = 0;

            MySqlCommand cmd = new MySqlCommand($@"update stoktakipuygulamasi.stok set Eldeki_Miktar = @EldekiMiktar, Toplam_Cikis =@Toplam_Cikis  where Urun_ID = @UrunID ", baglan);
            cmd.Parameters.AddWithValue("@EldekiMiktar", veri.Stok_EldekiMiktar);
            cmd.Parameters.AddWithValue("@ToplamGiris", veri.Stok_Toplam_Giris);
            cmd.Parameters.AddWithValue("@UrunID", Urun_id);
            cmd.Parameters.AddWithValue("@Toplam_Cikis", veri.Stok_Toplam_Cikis);

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

        public static bool StokGuncellStogaEkle(Prm veri, int Urun_id)
        {
            sbyte donen = 0;

            MySqlCommand cmd = new MySqlCommand($@"update stoktakipuygulamasi.stok set Eldeki_Miktar = @EldekiMiktar, Toplam_Giris =@ToplamGiris  where Urun_ID = @UrunID ", baglan);
            cmd.Parameters.AddWithValue("@EldekiMiktar", veri.Stok_EldekiMiktar);
            cmd.Parameters.AddWithValue("@ToplamGiris", veri.Stok_Toplam_Giris);
            cmd.Parameters.AddWithValue("@UrunID", Urun_id);
            cmd.Parameters.AddWithValue("@Toplam_Cikis", veri.Stok_Toplam_Cikis);


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
