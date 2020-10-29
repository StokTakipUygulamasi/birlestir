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

    class Fatura
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");

        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;

        public static bool faturaMusteri(Prm veri)
        {
            sbyte donen = 0;

            MySqlCommand cmd = new MySqlCommand("insert into stoktakipuygulamasi.faturalar (Fatura_No, Tarih, musteriler_ID) values (@FaturaNo,@Tarih,@MusteriID)", baglan);
            cmd.Parameters.AddWithValue("@FaturaNo", veri.FaturaNo);
            cmd.Parameters.AddWithValue("@Tarih", veri.SiparisTarihi);
            cmd.Parameters.AddWithValue("@MusteriID", veri.MusteriID);


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



        public static bool fatura(Prm veri)
        {
            sbyte donen = 0;

            MySqlCommand cmd = new MySqlCommand("insert into stoktakipuygulamasi.faturalar (Fatura_No, Tarih) values (@FaturaNo,@Tarih)", baglan);
            cmd.Parameters.AddWithValue("@FaturaNo", veri.FaturaNo);
            cmd.Parameters.AddWithValue("@Tarih", veri.SiparisTarihi);
            


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
        public static bool faturaToptanci(Prm veri)
        {
            sbyte donen = 0;

            MySqlCommand cmd = new MySqlCommand("insert into stoktakipuygulamasi.faturalar (Fatura_No, Tarih, toptancilar_ID) values (@FaturaNo,@Tarih,@toptancilar_ID)", baglan);
            cmd.Parameters.AddWithValue("@FaturaNo", veri.FaturaNo);
            cmd.Parameters.AddWithValue("@Tarih", veri.SiparisTarihi);
            cmd.Parameters.AddWithValue("@toptancilar_ID", veri.ToptanciID);


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