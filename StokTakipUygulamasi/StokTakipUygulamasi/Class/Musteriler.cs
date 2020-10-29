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
    public class Musteriler
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");
        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;
        public static bool musteriEkle(Prm veri)
        {

            sbyte donen = 0;
            Random rst = new Random();
            string sorgu;
            string MusteriNoUret;
            
           
            do
            {
                MusteriNoUret = rst.Next(100000000,999999999).ToString();
                sorgu = Genel.tekilVeriCekmeString($@"Select * from musteriler where Musteri_No='{MusteriNoUret}'", "ID");
            } while (sorgu!="");

            MySqlCommand cmd = new MySqlCommand("insert into musteriler (Musteri_Adi,Musteri_Soyadi,E_mail,Musteri_Grubu_ID,Musteri_No) values (@Musteri_Adi,@Musteri_Soyadi,@E_mail,@Musteri_Grubu_ID,@Musteri_No)", baglan);
            cmd.Parameters.AddWithValue("@Musteri_Adi",veri.MusteriAdi);
            cmd.Parameters.AddWithValue("@Musteri_Soyadi",veri.MusteriSoyadi);
            cmd.Parameters.AddWithValue("@E_mail",veri.MusteriEmail);
            cmd.Parameters.AddWithValue("@Musteri_Grubu_ID",veri.MusteriGrubuID);
            cmd.Parameters.AddWithValue("@Musteri_No", MusteriNoUret);

           

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

            MySqlCommand cmd2 = new MySqlCommand("insert into musteri_bilgileri (Adres,Is_Tel,Cep_Tel,Musteri_ID,Musteri_Grubu_ID) values (@Adres,@Is_Tel,@Cep_Tel,@Musteri_ID,@Musteri_Grubu_ID)", baglan);
            cmd2.Parameters.AddWithValue("@Adres", veri.MusteriAdres);
            cmd2.Parameters.AddWithValue("@Is_Tel", veri.MusteriIstel);
            cmd2.Parameters.AddWithValue("@Cep_Tel", veri.MusteriCepTel);

            string MusteriIDSorgu = $@"Select ID from musteriler where Musteri_No='{MusteriNoUret}'";
            int MusteriIDCek = Genel.tekilVeriCekmeInt(MusteriIDSorgu, "ID");

            cmd2.Parameters.AddWithValue("@Musteri_ID", MusteriIDCek);
            cmd2.Parameters.AddWithValue("@Musteri_Grubu_ID", veri.MusteriGrubuID);

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

        public static bool musteriGuncelle(Prm veri)
        {
            sbyte donen = 0;

            MySqlCommand cmd = new MySqlCommand($@"update musteriler set Musteri_Adi=@Musteri_Adi, Musteri_Soyadi=@Musteri_Soyadi, " +
                $@"Vergi_Dairesi=@Vergi_Dairesi, Vergi_No=@Vergi_No, E_mail=@E_mail, Musteri_Grubu_ID=@Musteri_Grubu_ID where ID='{veri.MusteriID}'",baglan);
            cmd.Parameters.AddWithValue("@Musteri_Adi", veri.MusteriAdi);
            cmd.Parameters.AddWithValue("@Musteri_Soyadi", veri.MusteriSoyadi);
            cmd.Parameters.AddWithValue("@E_mail", veri.MusteriEmail);
            cmd.Parameters.AddWithValue("@Musteri_Grubu_ID", veri.MusteriGrubuID);
            cmd.Parameters.AddWithValue("@Vergi_Dairesi", veri.MusteriVergiDairesi);
            cmd.Parameters.AddWithValue("@Vergi_No", veri.MusteriVergiNo);



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

            MySqlCommand cmd2 = new MySqlCommand("update musteri_bilgileri set Adres=@Musteri_Adres, Is_Tel=@Musteri_IsTel, " +
                $@"Cep_Tel=@Musteri_CepTel, Fax_No=@Musteri_FaxNo, Musteri_Grubu_ID=@Musteri_Grubu_ID where Musteri_ID='{veri.MusteriID}'", baglan);
            cmd2.Parameters.AddWithValue("@Musteri_Adres", veri.MusteriAdres);
            cmd2.Parameters.AddWithValue("@Musteri_IsTel", veri.MusteriIstel);
            cmd2.Parameters.AddWithValue("@Musteri_CepTel", veri.MusteriCepTel);
            cmd2.Parameters.AddWithValue("@Musteri_Grubu_ID", veri.MusteriGrubuID);
            cmd2.Parameters.AddWithValue("@Musteri_FaxNo",veri.MusteriFaxNo);

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

        public static bool musteriSil(string musteriID)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"Update musteriler set Silindi_Mi=1 where ID='{musteriID}'",baglan);
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

        public static bool musteriGeriAl(string musteriID)
        {
            sbyte donen = 0;
            MySqlCommand cmd = new MySqlCommand($@"Update musteriler set Silindi_Mi=0 where ID='{musteriID}'", baglan);
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

        public static List<string> musteriTumBilgileriCek(int musteriID)
        {
            List<string> liste = new List<string>();
            MySqlCommand cmd = new MySqlCommand($@"select m.ID, m.Musteri_Adi, m.Musteri_Soyadi, concat(m.Musteri_Adi,' ',m.Musteri_Soyadi) as Musteri_AdSoyad , m.Vergi_Dairesi, m.Vergi_No, m.E_mail, m.Musteri_Grubu_ID, mg.Musteri_Grubu, mb.Is_Tel, mb.Cep_Tel,
                mb.Adres, mb.Fax_No from musteriler m
                left join musteri_bilgileri mb on m.ID = mb.Musteri_ID left join musteri_grubu mg on mg.ID = m.Musteri_Grubu_ID where m.ID='{musteriID}'",baglan);

            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(reader["ID"].ToString());
                    liste.Add(reader["Musteri_Adi"].ToString());
                    liste.Add(reader["Musteri_Soyadi"].ToString());
                    liste.Add(reader["Vergi_Dairesi"].ToString());
                    liste.Add(reader["Vergi_No"].ToString());
                    liste.Add(reader["E_mail"].ToString());
                    liste.Add(reader["Musteri_Grubu"].ToString());
                    liste.Add(reader["Is_Tel"].ToString());
                    liste.Add(reader["Cep_Tel"].ToString());
                    liste.Add(reader["Adres"].ToString());
                    liste.Add(reader["Fax_No"].ToString());
                    liste.Add(reader["Musteri_Grubu_ID"].ToString());
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



            return liste;
        }
    }
}
