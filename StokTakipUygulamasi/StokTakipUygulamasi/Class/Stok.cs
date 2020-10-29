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

            MySqlCommand cmd = new MySqlCommand("insert into stoktakipuygulamasi.stok (Eldeki_Miktar, Toplam_Giris, Toplam_Cikis, Urun_ID, Urun_Olcu_Birimi_ID)" +
                " values (@Eldeki_Miktar,@Toplam_Giris,@Toplam_Cikis,@UrunID,@OlcuBirimiID);", baglan);
            cmd.Parameters.AddWithValue("@Eldeki_Miktar", veri.IndirimBaslangicTarihi);
            cmd.Parameters.AddWithValue("@Toplam_Giris", veri.IndirimBitisTarihi);
            cmd.Parameters.AddWithValue("@Toplam_Cikis", veri.IndirimliSatisFiyati);
            cmd.Parameters.AddWithValue("@UrunID", veri.Indirimde_mi);
            cmd.Parameters.AddWithValue("@OlcuBirimiID", veri.Olcu_Birimi_ID);

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
