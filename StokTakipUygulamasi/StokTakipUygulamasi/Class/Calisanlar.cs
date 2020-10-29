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
    public class Calisanlar
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");

        public static MySqlCommand cmd;
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;

        public static bool calisanSil(int calisanID)
        {
            sbyte i = 0;
            MySqlCommand cmd = new MySqlCommand($@"Update calisanlar set Silindi_Mi=1 where ID='{calisanID}'",baglan);
            try
            {
                baglan.Open();
                cmd.ExecuteNonQuery();
                i = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }

            if (i>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool calisaniGeriAl(int calisanID)
        {
            sbyte i = 0;
            MySqlCommand cmd = new MySqlCommand($@"Update calisanlar set Silindi_Mi=0 where ID='{calisanID}'", baglan);
            try
            {
                baglan.Open();
                i = 1;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }

            if (i>0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool calisanEkle(Prm veri)
        {
            sbyte donen = 0;
            Random rst = new Random();
            string sorgu;
            string CalisanNoUret;
            do
            {
                CalisanNoUret = rst.Next(100000000, 999999999).ToString();
                sorgu = Genel.tekilVeriCekmeString($@"Select * from calisanlar where Calisan_No='{CalisanNoUret}'", "ID");
            } while (sorgu != "");


            MySqlCommand cmd = new MySqlCommand($@"insert into calisanlar (Calisan_No, Ad, Soyad, TC, Kadi, Sifre, Foto, Adres, Giris_IP)
                                                    values (@Calisan_No, @Ad, @Soyad, @TC, @Kadi, @Sifre, @Foto, @Adres, @IP)",baglan);
            cmd.Parameters.AddWithValue("@Ad",veri.CalisanAdi);
            cmd.Parameters.AddWithValue("@Soyad",veri.CalisanSoyadi);
            cmd.Parameters.AddWithValue("@TC", veri.CalisanTC);
            cmd.Parameters.AddWithValue("@Calisan_No",CalisanNoUret);
            cmd.Parameters.AddWithValue("@Kadi",veri.CalisanKadi);
            cmd.Parameters.AddWithValue("@sifre", veri.CalisanSifre);
            cmd.Parameters.AddWithValue("@foto",veri.CalisanFoto);
            cmd.Parameters.AddWithValue("@Adres",veri.CalisanAdres);
            cmd.Parameters.AddWithValue("@IP",veri.CalisanIP);

            try
            {
                baglan.Open();
                cmd.ExecuteNonQuery();
                donen++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }

            MySqlCommand cmd2 = new MySqlCommand($@"insert into calisan_bilgileri (Tel, E_Mail, Calisan_ID)
                                                    values (@Tel, @Email, @CalisanID)",baglan);
            cmd2.Parameters.AddWithValue("@Tel",veri.CalisanTel);
            cmd2.Parameters.AddWithValue("@Email",veri.CalisanEmail);
            string CalisanIDSorgu = $@"Select Id from calisanlar where Calisan_No='{CalisanNoUret}'";
            int CalisanIDCek = Genel.tekilVeriCekmeInt(CalisanIDSorgu, "ID");
            cmd2.Parameters.AddWithValue("@CalisanID",CalisanIDCek);

            try
            {
                baglan.Open();
                cmd2.ExecuteNonQuery();
                donen++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }

            MySqlCommand yetkiTablosu = new MySqlCommand($@"insert into calisan_yetki (Yetki_ID, Calisan_ID) 
                                                            values (@Yetki_ID, @Calisan_ID)",baglan);
            yetkiTablosu.Parameters.AddWithValue("@Yetki_ID", veri.CalisanYetkiID);
            yetkiTablosu.Parameters.AddWithValue("@Calisan_ID",CalisanIDCek);
            try
            {
                baglan.Open();
                yetkiTablosu.ExecuteNonQuery();
                donen++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }



            if (donen == 3)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static List<string> calisanTumBilgileri(int calisanID)
        {
            List<string> liste = new List<string>();
            MySqlCommand cmd = new MySqlCommand($@"select c.Calisan_No, c.ID, c.Ad, c.Soyad, c.TC, c.Kadi, c.Sifre, c.Foto, c.Adres, " +
             "c.Giris_IP, cb.Tel, cb.E_mail, y.Yetki from calisanlar c left join calisan_bilgileri cb on c.ID = cb.Calisan_ID " +
             $@"left join calisan_yetki cy on cy.Calisan_ID = c.ID left join yetkiler y on y.ID = cy.Yetki_ID where c.ID='{calisanID}'",baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(reader["ID"].ToString());
                    liste.Add(reader["Ad"].ToString());
                    liste.Add(reader["Soyad"].ToString());
                    liste.Add(reader["TC"].ToString());
                    liste.Add(reader["Kadi"].ToString());
                    liste.Add(reader["Sifre"].ToString());
                    liste.Add(reader["Adres"].ToString());
                    liste.Add(reader["Foto"].ToString());
                    liste.Add(reader["Tel"].ToString());
                    liste.Add(reader["E_mail"].ToString());
                    liste.Add(reader["Yetki"].ToString());
                    liste.Add(reader["Calisan_No"].ToString());
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

        public static bool calisanGuncelle(Prm veri, int calisanID)
        {
            sbyte donen = 0;
            MySqlCommand calisanTablosu = new MySqlCommand($@"Update calisanlar set Ad=@Ad, Soyad=@Soyad, TC=@TC,
                                                            Kadi=@Kadi, Sifre=@Sifre, Foto=@Foto, Adres=@Adres 
                                                            where ID='{calisanID}'",baglan);
            calisanTablosu.Parameters.AddWithValue("@Ad",veri.CalisanAdi);
            calisanTablosu.Parameters.AddWithValue("@Soyad",veri.CalisanSoyadi);
            calisanTablosu.Parameters.AddWithValue("@TC", veri.CalisanTC);
            calisanTablosu.Parameters.AddWithValue("@Kadi", veri.CalisanKadi);
            calisanTablosu.Parameters.AddWithValue("@Sifre", veri.CalisanSifre);
            calisanTablosu.Parameters.AddWithValue("@Foto", veri.CalisanFoto);
            calisanTablosu.Parameters.AddWithValue("@Adres", veri.CalisanAdres);

            try
            {
                baglan.Open();
                calisanTablosu.ExecuteNonQuery();
                donen++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }

            MySqlCommand calisanBilgileriTablosu = new MySqlCommand($@"update calisan_bilgileri set Tel=@Tel, 
                                                                    E_mail=@E_mail where Calisan_ID='{calisanID}'",baglan);
            calisanBilgileriTablosu.Parameters.AddWithValue("@Tel",veri.CalisanTel);
            calisanBilgileriTablosu.Parameters.AddWithValue("@E_mail", veri.CalisanEmail);
            try
            {
                baglan.Open();
                calisanBilgileriTablosu.ExecuteNonQuery();
                donen++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }

            MySqlCommand yetkiTablosu = new MySqlCommand($@"update calisan_yetki set Yetki_ID=@Yetki_ID 
                                                         where Calisan_ID='{calisanID}'",baglan);
            yetkiTablosu.Parameters.AddWithValue("@Yetki_ID",veri.CalisanYetkiID);
            try
            {
                baglan.Open();
                yetkiTablosu.ExecuteNonQuery();
                donen++;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                baglan.Dispose();
            }


            if (donen == 3)
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
