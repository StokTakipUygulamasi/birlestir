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
    public class Toptancilar
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");
        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;

        public static bool toptanciEkle(Prm veri)
        {
            sbyte donen = 0;
            Random rst = new Random();
            string sorgu;
            string ToptanciNoUret;


            do
            {
                ToptanciNoUret = rst.Next(100000000, 999999999).ToString();
                sorgu = Genel.tekilVeriCekmeString($@"Select * from toptancilar where Toptanci_No='{ToptanciNoUret}'", "ID");
            } while (sorgu != "");

           
            MySqlCommand cmd = new MySqlCommand("insert into toptancilar (Toptanci_Adi, Adres, Aciklama, Toptanci_No) values " +
              "(@ToptanciAdi, @Adres, @Aciklama,@Toptanci_No)", baglan);
            cmd.Parameters.AddWithValue("@ToptanciAdi", veri.ToptanciAdi);
            cmd.Parameters.AddWithValue("@Adres", veri.ToptanciAdresi);
            cmd.Parameters.AddWithValue("@Aciklama", veri.ToptanciAciklamasi);
            cmd.Parameters.AddWithValue("@Toptanci_No",ToptanciNoUret);

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

            MySqlCommand cmd2 = new MySqlCommand("insert into toptanci_bilgileri (Cep_Tel, Is_Tel, Fax_No, Toptanci_ID) values " +
            "(@Cep_Tel, @Is_Tel, @Fax_No,@Toptanci_ID)", baglan);
            cmd2.Parameters.AddWithValue("@Cep_Tel", veri.ToptanciCepTel);
            cmd2.Parameters.AddWithValue("@Is_Tel", veri.ToptantiIsTel);
            cmd2.Parameters.AddWithValue("@Fax_No", veri.ToptanciFaxNo);

            string toptanciIdSorgu = $@"(Select ID from toptancilar where Toptanci_No='{ToptanciNoUret}')";
            int toptanciIDCek = Genel.tekilVeriCekmeInt(toptanciIdSorgu,"ID");
            cmd2.Parameters.AddWithValue("@Toptanci_ID",toptanciIDCek);

            try
            {
                baglan.Open();
                donen = 1;
                cmd2.ExecuteNonQuery();
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


        public static bool toptanciSil(int toptanciID,string silinme_aciklamasi)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"Update toptancilar set Silindi_Mi=1, Silinme_Aciklamasi='{silinme_aciklamasi}'  where ID='{toptanciID}'", baglan);
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

        public static bool toptanciSilGeriAl(int toptanciID)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"Update toptancilar set Silindi_Mi=0  where ID='{toptanciID}'", baglan);
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

        public static bool toptanciGuncelle(Prm veri,int toptanci_ID)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"update toptancilar set Toptanci_Adi=@Toptanci_Adi, Adres=@Adres, Aciklama=@Aciklama where ID=@ID", baglan);
            cmd.Parameters.AddWithValue("@Toptanci_Adi", veri.ToptanciAdi);
            cmd.Parameters.AddWithValue("@Adres", veri.ToptanciAdresi);
            cmd.Parameters.AddWithValue("@Aciklama", veri.ToptanciAciklamasi);
            cmd.Parameters.AddWithValue("@ID", veri.ToptanciID);
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

            MySqlCommand cmd2 = new MySqlCommand($@"update toptanci_bilgileri set Cep_Tel=@Cep_Tel, Is_Tel=@Is_Tel, Fax_No=@Fax_No where Toptanci_ID=@ID", baglan);
            cmd2.Parameters.AddWithValue("@Cep_Tel", veri.ToptanciCepTel);
            cmd2.Parameters.AddWithValue("@Is_Tel", veri.ToptantiIsTel);
            cmd2.Parameters.AddWithValue("@Fax_No", veri.ToptanciFaxNo);
            cmd2.Parameters.AddWithValue("@ID", veri.ToptanciID);

            try
            {
                baglan.Open();
                donen = 1;
                cmd2.ExecuteNonQuery();

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


       public static string[] toptanciBilgileriniCek(int toptanciID)
        {
            string[] dizi = new string[7];
            cmd = new MySqlCommand($@"(select t.ID, t.Toptanci_Adi, t.Adres, t.Aciklama, tb.Cep_Tel, tb.Is_Tel, tb.Fax_No from toptancilar t left join toptanci_bilgileri tb on t.ID = tb.Toptanci_ID where t.ID='{toptanciID}')",baglan);
            
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    dizi[0] = reader["ID"].ToString();
                    dizi[1] = reader["Toptanci_Adi"].ToString();
                    dizi[2] = reader["Adres"].ToString();
                    dizi[3] = reader["Aciklama"].ToString();
                    dizi[4] = reader["Cep_Tel"].ToString();
                    dizi[5] = reader["Is_Tel"].ToString();
                    dizi[6] = reader["Fax_No"].ToString();
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
    }
}
