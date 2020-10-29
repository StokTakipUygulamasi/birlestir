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
namespace StokTakipUygulamasi.Class
{
    class Departmanlar
    {
        public static MySqlConnection baglan = new MySqlConnection("Server=91.151.93.175; Database=stoktakipuygulamasi;Uid=310843;Pwd=GG_979899;Charset=utf8");
        public static MySqlDataReader reader;
        public static MySqlDataAdapter adapter;
        public static bool departmaniSilGeriAl(int departmanID, string islem)
        {
            bool donen = false;
            if (islem.ToLower() == "sil")
            {
                MySqlCommand cmd = new MySqlCommand($@"Update yetkiler set Silindi_Mi=1 where ID='{departmanID}'", baglan);
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
            }

            else if (islem.ToLower() == "geri al")
            {
                MySqlCommand cmd = new MySqlCommand($@"Update yetkiler set Silindi_Mi=0 where ID='{departmanID}'", baglan);
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
            }
            else
            {
                donen = false;
            }

            return donen;
        }

        public static bool departmanEkle(Prm veri)
        {
           
            bool donen = true;
            string yetkiKontrolSorgusu = $@"Select * from yetkiler where Yetki_Kodu='{veri.DepartmanKodu}' or Yetki='{veri.DepartmanAdi}'";
            int gelenYetkiKontrol = Genel.tekilVeriCekmeInt(yetkiKontrolSorgusu, "ID");
            if (gelenYetkiKontrol > 0)
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Böyle bir departman zaten var!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
                donen = false;
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand($@"insert into yetkiler (Yetki_Kodu, Yetki) values (@Yetki_Kodu, @Yetki)", baglan);
                cmd.Parameters.AddWithValue("@Yetki_Kodu", veri.DepartmanKodu);
                cmd.Parameters.AddWithValue("@Yetki", veri.DepartmanAdi);
                try
                {
                    baglan.Open();
                    cmd.ExecuteNonQuery();
                    donen = true;
                    Prm.Hata = 0;
                    Prm.BilgiMesajiAlani = "Departman başarıyla eklendi...";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
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
                if (veri.DepartmanAltyetkiler != null)
                {
                    string deptIDSorgusu = $@"select ID from yetkiler where Yetki_Kodu='{veri.DepartmanKodu}'";
                    int deptIDCek = Genel.tekilVeriCekmeInt(deptIDSorgusu, "ID");
                    foreach (var item in veri.DepartmanAltyetkiler)
                    {
                        MySqlCommand altyetkiler = new MySqlCommand($@"insert into yetkiler_altyetkiler (Yetkiler_ID, AltYetkiler_ID) values 
                                                             (@Yetkiler_ID, @AltYetkiler_ID)", baglan);
                        altyetkiler.Parameters.AddWithValue("@Yetkiler_ID", deptIDCek);
                        altyetkiler.Parameters.AddWithValue("@AltYetkiler_ID", item);
                        try
                        {
                            baglan.Open();
                            altyetkiler.ExecuteNonQuery();
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
                    }
                }
               
                
            }
            return donen;
        }

        public static bool departmanGuncelle(Prm veri)
        {
            bool donen = false;
            string yetkiKoduSorgusu = $@"Select * from yetkiler where Yetki_Kodu='{veri.DepartmanKodu}' and Not ID='{veri.DepartmanID}'";
            int yetkiKoduKontrol = Genel.tekilVeriCekmeInt(yetkiKoduSorgusu, "ID");
            string yetkiAdiSorgusu = $@"Select * from yetkiler where Yetki='{veri.DepartmanAdi}' and Not ID='{veri.DepartmanID}'";
            int  yetkiAdiKontrol = Genel.tekilVeriCekmeInt(yetkiAdiSorgusu,"ID");

            if (yetkiKoduKontrol > 0)
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Böyle bir departman kodu zaten var!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
                donen = false;
            }
            else if (yetkiAdiKontrol > 0)
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Böyle bir departman adı zaten var!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
                donen = false;
            }
            else
            {
                MySqlCommand cmd = new MySqlCommand($@"update yetkiler set Yetki_Kodu=@YetkiKodu, Yetki=@Yetki where ID='{veri.DepartmanID}'", baglan);
                cmd.Parameters.AddWithValue("@YetkiKodu",veri.DepartmanKodu);
                cmd.Parameters.AddWithValue("@Yetki",veri.DepartmanAdi);
                try
                {
                    baglan.Open();
                    cmd.ExecuteNonQuery();
                    Prm.Hata = 0;
                    Prm.BilgiMesajiAlani = "Departman başarıyla güncellendi...";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
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
                if (veri.DepartmanAltyetkiler != null)
                {
                    string deptIDSorgusu = $@"select ID from yetkiler where Yetki_Kodu='{veri.DepartmanKodu}'";
                    int deptIDCek = Genel.tekilVeriCekmeInt(deptIDSorgusu, "ID");
                    MySqlCommand sil = new MySqlCommand($@"Delete from yetkiler_altyetkiler where Yetkiler_ID='{deptIDCek}'",baglan);
                    try
                    {
                        baglan.Open();
                        sil.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        baglan.Dispose();
                    }

                    foreach (var item in veri.DepartmanAltyetkiler)
                    {
                        MySqlCommand altyetkiler = new MySqlCommand($@"insert into yetkiler_altyetkiler (Yetkiler_ID, AltYetkiler_ID) values 
                                                             (@Yetkiler_ID, @AltYetkiler_ID)", baglan);
                        altyetkiler.Parameters.AddWithValue("@Yetkiler_ID", deptIDCek);
                        altyetkiler.Parameters.AddWithValue("@AltYetkiler_ID", item);
                        try
                        {
                            baglan.Open();
                            altyetkiler.ExecuteNonQuery();
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
                    }
                }
            }
            return donen;
        }

        public static List<string> departmanBilgileriniCek(int departmanID)
        {
            List<string> liste = new List<string>();
            MySqlCommand cmd = new MySqlCommand($@"Select * from yetkiler where ID='{departmanID}'",baglan);
            try
            {
                baglan.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(reader["Yetki_Kodu"].ToString());
                    liste.Add(reader["Yetki"].ToString());
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

        public static List<string> sahipOlunanYetkiler(int DepartmanID)
        {
            List<string> liste = new List<string>();
            MySqlCommand sahipOlunanYetkiler = new MySqlCommand($@"Select * from yetkiler_altyetkiler where Yetkiler_ID='{DepartmanID}'", baglan);
            try
            {
                baglan.Open();
                reader = sahipOlunanYetkiler.ExecuteReader();
                while (reader.Read())
                {
                    liste.Add(reader["AltYetkiler_ID"].ToString());
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

        public static bool altYetkileriCek(DataGrid gelengrid, int deptID)
        {
            bool donen = false;
            MySqlCommand sahipOlunanYetkiler = new MySqlCommand($@"select ay.ID as 'AltYetkilerID', ay.Yetki from altyetkiler ay left join 
                                                yetkiler_altyetkiler ya on ay.ID=ya.AltYetkiler_ID where ya.Yetkiler_ID='{deptID}'", baglan);

            adapter = new MySqlDataAdapter(sahipOlunanYetkiler);
            DataTable dt = new DataTable();
            dt.Columns.Add("AltYetkilerID", typeof(String));
            dt.Columns.Add("Yetki", typeof(string));
            dt.Columns.Add("Secim", typeof(bool));
            try
            {
                baglan.Open();
               
                reader = sahipOlunanYetkiler.ExecuteReader();
               
                while (reader.Read())
                {
                    dt.Rows.Add(reader["AltYetkilerID"].ToString(), reader["Yetki"].ToString(), true);
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

            MySqlCommand sahipOlunmayanYetkiler = new MySqlCommand($@"select * from altyetkiler where ID not in 
                                                (Select AltYetkiler_ID from yetkiler_altyetkiler where Yetkiler_ID='{deptID}')", baglan);

            try
            {
                baglan.Open();
                reader = sahipOlunmayanYetkiler.ExecuteReader();

                while (reader.Read())
                {
                    dt.Rows.Add(reader["ID"].ToString(), reader["Yetki"].ToString(), false);
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

        /*
        public static bool sahipOlunanAltYetkiler(DataGrid gelengrid,int deptID)
        {
            bool donen = false;
            MySqlCommand cmd = new MySqlCommand($@"select ay.ID as 'AltYetkiID', ay.Yetki from altyetkiler ay left join 
                                                yetkiler_altyetkiler ya on ay.ID=ya.AltYetkiler_ID where ya.Yetkiler_ID='{deptID}'",baglan);
            try
            {
                baglan.Open();
                adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
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

        public static bool sahipOlunmayanAltYetkiler(DataGrid gelengrid, int deptID)
        {
            bool donen = false;
            MySqlCommand cmd = new MySqlCommand($@"select * from altyetkiler where ID not in 
                                                (Select AltYetkiler_ID from yetkiler_altyetkiler where Yetkiler_ID='{deptID}'", baglan);
            try
            {
                baglan.Open();
                adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
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
        */


    }
}
