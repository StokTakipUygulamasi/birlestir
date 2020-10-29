using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.Pencereler;

namespace StokTakipUygulamasi.UserController
{
    /// <summary>
    /// SatisYap.xaml etkileşim mantığı
    /// </summary>
    public partial class SatisYap : UserControl
    {
        public static List<Button> buttonList;
        String siparisList = "";
        int tutar = 0;
       
        List<int> olcuBirimiIDList ;
        List<int> urunIDlist ;
        List<int> adetList;
        List<int> fiyatList;
        List<String> hızlıUrunlerList;
       

        int MusteriID = -10;
        
        public SatisYap()
        {
            InitializeComponent();
            musteriSecCombox = Genel.ComboBoxVeriCekme(musteriSecCombox, $@"SELECT ID, Concat(Musteri_Adi,' ' , Musteri_Soyadi) as Musteri_AdSoyad FROM stoktakipuygulamasi.musteriler", "Musteri_AdSoyad");
            
        }

    

        private void UserControl(object sender, RoutedEventArgs e)
        {
            buttonList = new List<Button>();
            buttonList.Add(btn1);
            buttonList.Add(btn2);
            buttonList.Add(btn3);
            buttonList.Add(btn4);
            buttonList.Add(btn5);
            buttonList.Add(btn6);
            buttonList.Add(btn7);
            buttonList.Add(btn8);
            buttonList.Add(btn9);
            buttonList.Add(btn10);
            buttonList.Add(btn11);
            buttonList.Add(btn12);

            string sorgu = $@"select ID, Urun_Adi from stoktakipuygulamasi.urunler where Hizli_Satista_Mi = 1";
            hızlıUrunlerList = Genel.TekUrunTümListeCek(sorgu, "Urun_Adi");
            for (int i=0; i<12; i++)
            {

                if (i>=hızlıUrunlerList.Count)
                {
                    buttonList[i].Visibility = Visibility.Hidden;
                }
                else
                {
                    buttonList[i].Content = hızlıUrunlerList[i];
                }
            }
            olcuBirimiIDList = new List<int>();
            urunIDlist = new List<int>();
            adetList = new List<int>();
            fiyatList = new List<int>();
        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int urunID = Genel.tekilVeriCekmeInt($@"select ID from stoktakipuygulamasi.urunler where Urun_Adi = '{btn.Content.ToString()}'", "ID");
            int OlcuBirimiID = Genel.tekilVeriCekmeInt($@"select Olcu_Birimi_ID from stoktakipuygulamasi.urunler where Urun_Adi = '{btn.Content.ToString()}'", "Olcu_Birimi_ID");
            int urunFiyat = Genel.tekilVeriCekmeInt($@"select Satis_Fiyati from stoktakipuygulamasi.urunler where Urun_Adi = '{btn.Content.ToString()}'", "Satis_Fiyati");
            int fiyat = Convert.ToInt32(txtAdet.Text) * urunFiyat;

            if (urunIDlist.Count == 0)
            {
                urunIDlist.Add(urunID);
                olcuBirimiIDList.Add(OlcuBirimiID);
                adetList.Add(Convert.ToInt32(txtAdet.Text));
                fiyatList.Add(fiyat);
            }
            else
            {
                bool kontrol = false;
                for (int i = 0; i < urunIDlist.Count; i++)
                {
                    if (urunIDlist[i] == urunID)
                    {
                        adetList[i] = adetList[i] + Convert.ToInt32(txtAdet.Text);
                        fiyatList[i] = fiyatList[i] + Convert.ToInt32(fiyat);
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
                    urunIDlist.Add(urunID);
                    olcuBirimiIDList.Add(OlcuBirimiID);
                    adetList.Add(Convert.ToInt32(txtAdet.Text));
                    fiyatList.Add(fiyat);
                }
            }





            dataGridDoldur();
            tutar = tutar + fiyat;
            txtTutar.Text = tutar.ToString();
            txtBarkod.Text = "";
            txtAdet.Text = "1";


        }
     
       
        public void dataGridDoldur()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Adet", typeof(string));
            dt.Columns.Add("UrunAdi", typeof(string));
            dt.Columns.Add("Fiyat", typeof(string));
           
            for (int i = 0; i < adetList.Count; i++)
            {
                String urunADi = Genel.tekilVeriCekmeString($@"select Urun_Adi from stoktakipuygulamasi.urunler where ID = '{urunIDlist[i]}'", "Urun_Adi");
                dt.Rows.Add(adetList[i], urunADi, fiyatList[i] + " ₺");
            }
            dtg_urunSatisList.ItemsSource = null;
            dtg_urunSatisList.ItemsSource = dt.DefaultView;

        }

     


        private void btnAlisVerisiTamamla(object sender, RoutedEventArgs e)
        {
            
       
            
            Prm prm = new Prm();
            string FaturaNoString = "M" + DateTime.Now;
            prm.FaturaNo = FaturaNoString;
            prm.SiparisTarihi = DateTime.Now;
            prm.VeresiyeToplamBorc = Convert.ToInt32(tutar);
            

            if(musteriSecCombox.SelectedIndex != -1)
            {
                string Sorgu = $@"SELECT ID   FROM stoktakipuygulamasi.musteriler where Concat(Musteri_Adi,' ', Musteri_Soyadi) = '{musteriSecCombox.SelectedItem.ToString()}'";
                MusteriID = Genel.tekilVeriCekmeInt(Sorgu, "ID");
                prm.MusteriID = MusteriID;
                


            }
            else
            {
                prm.MusteriID = null;
            }

            
            
            if (NakitOdemeRadioButton.IsChecked==true)
            {
                prm.VeresiyeParaTuru = "Nakit";
            }
            if(PostRadioButton.IsChecked == true) 
            {
                prm.VeresiyeParaTuru = "Post";
            }
            if (VerisiyeRadioButton.IsChecked == true)
            {
                prm.VeresiyeParaTuru = "Veresiye";
            }
            
           prm.CalisanID = 1;
            
                        if (VerisiyeRadioButton.IsChecked == true)
                        {
                            prm.VeresiyeToplamBorc = Convert.ToInt32(tutar);
                            prm.VeresiyeParaTuru = "Tl";
                            prm.CalisanID = 1;


                            if (musteriSecCombox.SelectedIndex != -1)
                            {
                                string Sorgu = $@"SELECT ID   FROM stoktakipuygulamasi.musteriler where Concat(Musteri_Adi,' ', Musteri_Soyadi) = '{musteriSecCombox.SelectedItem.ToString()}'";
                                MusteriID = Genel.tekilVeriCekmeInt(Sorgu, "ID");



                            }
                            else
                            {
                                MessageBox.Show("Müşteri Seçmek Zorundasınız");
                            }



                        }
                        else
                        {
                            MessageBox.Show("Normal Checked");

                        }

            if (Fatura.faturaMusteri(prm))
            {
                for (int i = 0; i < urunIDlist.Count; i++)
                {
                    prm.SiparisAdet = adetList[i];
                    prm.Satis_Fiyati = fiyatList[i];
                    prm.UrunID = urunIDlist[i];
                    prm.Olcu_Birimi_ID = olcuBirimiIDList[i];
                    prm.CalisanID = 1;

                    prm.FaturaID = Genel.tekilVeriCekmeInt($@"select ID from stoktakipuygulamasi.faturalar where Fatura_No = '{FaturaNoString}'", "ID");
                    if (Urunler.urunSatisEkle(prm))
                    {
                        int EldekiMiktar = Genel.tekilVeriCekmeInt($@"select Eldeki_Miktar from stok where  Urun_ID = '{ prm.UrunID}' ", "Eldeki_Miktar");
                        int ToptanCikis = Genel.tekilVeriCekmeInt($@"select Toplam_Cikis from stok where  Urun_ID = '{ prm.UrunID}' ", "Toplam_Cikis");
                        EldekiMiktar = EldekiMiktar - adetList[i];
                        ToptanCikis = ToptanCikis + adetList[i];
                        prm.Stok_EldekiMiktar = EldekiMiktar;
                        prm.Stok_Toplam_Cikis = ToptanCikis;
                        if (Stok.StokGuncelleStoktanCikar(prm,prm.UrunID))
                        {
                            MessageBox.Show("Ürün Stoktan Düşüldü");
                        }
                    }               
                }
                if (VerisiyeRadioButton.IsChecked == true)
                {
                    if (Urunler.VeresiyeEkle(prm))
                    {
                        MessageBox.Show("Veresiye Başarılı");
                    }
                }

            }
            EkranıTemizle();
            dataGridDoldur();


                      
                      /*


            if (Fatura.faturaMusteri(prm))
            {
                if (UrunSatis.urunSatisEkle(prm))
                {
                    if (VerisiyeRadioButton.IsChecked == true)
                    {
                        if (UrunSatis.VeresiyeEkle(prm))
                        {
                            MessageBox.Show("Veresiye Başarılı");
                        }
                        else
                        {
                            MessageBox.Show("Veresiye Tablosunda Hata");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Ürünler Tablosunda Hata");
                }
            } 
            else
            {
                MessageBox.Show("Faturalar Tablosunda Hata");
            }
            */
            

        }

        private void VerisiyeRadioButtonClick(object sender, RoutedEventArgs e)
        {
            NakitOdemeRadioButton.IsChecked = false;
            PostRadioButton.IsChecked = false;
            MusteriBorder.Visibility = Visibility.Visible;
            MusteriBorder.BorderBrush = System.Windows.Media.Brushes.Red;// Brushes.Red;
        }
        /*
        private void NormalÖdemeRadioButtonClick(object sender, RoutedEventArgs e)
        {

            VerisiyeRadioButton.IsChecked = false;
            NakitOdemeRadioButton.IsChecked = false;
            PostRadioButton.IsChecked = false;

            
            musteriSecCombox.Items.Clear();
            musteriSecCombox.Visibility = Visibility.Collapsed;
            musteriSecCombox = Genel.ComboBoxVeriCekme(musteriSecCombox, $@"SELECT ID, Concat(Musteri_Adi,' ' , Musteri_Soyadi) as Musteri_AdSoyad FROM stoktakipuygulamasi.musteriler", "Musteri_AdSoyad");
            
            MusteriBorder.Visibility = Visibility.Collapsed;
            MusteriBorder.BorderBrush = System.Windows.Media.Brushes.Blue;


        }
    */
        private void NakitRadioButtonClick(object sender, RoutedEventArgs e)
        {
            VerisiyeRadioButton.IsChecked = false;
            
            PostRadioButton.IsChecked = false;
            MusteriBorder.Visibility = Visibility.Collapsed;

        }
        private void PostRadioButtonClick(object sender, RoutedEventArgs e)
        {
           
            MusteriBorder.Visibility = Visibility.Collapsed;
            VerisiyeRadioButton.IsChecked = false;
            NakitOdemeRadioButton.IsChecked = false;
        }
        public void EkranıTemizle()
        {
            olcuBirimiIDList.Clear();
            urunIDlist.Clear();
            adetList.Clear();
            fiyatList.Clear();
            txtAdet.Text = "1";
            txtSatisListesi.Text = "";
            txtTutar.Text = "";
            tutar = 0;
            siparisList = "";
            musteriSecCombox.ItemsSource = null;
            musteriSecCombox.SelectedItem = null;
            
        }


  
        private void txtBarkod_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtBarkod.Text.Length == 13)
            {                
                if (Urunler.urunKontrol(txtBarkod.Text))
                {
                    int UrunID = Genel.tekilVeriCekmeInt($@"select ID from stoktakipuygulamasi.urunler where Barkod_No = '{txtBarkod.Text}'", "ID");
                    int OlcuBirimiID = Genel.tekilVeriCekmeInt($@"select Olcu_Birimi_ID from stoktakipuygulamasi.urunler where Barkod_No = '{txtBarkod.Text}'", "Olcu_Birimi_ID");
                    String UrunAdi = Genel.tekilVeriCekmeString($@"select Urun_Adi from stoktakipuygulamasi.urunler where Barkod_No = '{txtBarkod.Text}'", "Urun_Adi");
                    String OlcuMiktari = Genel.tekilVeriCekmeString($@"select Olcu_Miktar from stoktakipuygulamasi.urunler where Barkod_No = '{txtBarkod.Text}'", "Olcu_Miktar");
                    int UrunFiyat = Genel.tekilVeriCekmeInt($@"select Satis_Fiyati from stoktakipuygulamasi.urunler where Barkod_No = '{txtBarkod.Text}'", "Satis_Fiyati");
                    
                    tutar = tutar + UrunFiyat * Convert.ToInt32(txtAdet.Text);
                    txtSatisListesi.Text = siparisList;
                    txtTutar.Text = tutar.ToString();



                    
                      if (urunIDlist.Count == 0)
            {
                urunIDlist.Add(UrunID);
                olcuBirimiIDList.Add(OlcuBirimiID);
                adetList.Add(Convert.ToInt32(txtAdet.Text));
                fiyatList.Add(UrunFiyat);
            }
            else
            {
                bool kontrol = false;
                for (int i = 0; i < urunIDlist.Count; i++)
                {
                    if (urunIDlist[i] == UrunID)
                    {
                        adetList[i] = adetList[i] + Convert.ToInt32(txtAdet.Text);
                        fiyatList[i] = fiyatList[i] + Convert.ToInt32(UrunFiyat);
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
                    urunIDlist.Add(UrunID);
                    olcuBirimiIDList.Add(OlcuBirimiID);
                    adetList.Add(Convert.ToInt32(txtAdet.Text));
                    fiyatList.Add(UrunFiyat);
                }
            }
            

                    /*
                    urunIDlist.Add(UrunID);
                    adetList.Add(Convert.ToInt32(txtAdet.Text));
                    fiyatList.Add(UrunFiyat * Convert.ToInt32(txtAdet.Text));
                    olcuBirimiIDList.Add(OlcuBirimiID);
                    */
                    txtBarkod.Text = "";
                    txtAdet.Text = "1";
                    dataGridDoldur();
                   

                }
                else
                {
                    MessageBox.Show("Ürün Bulunamadı");
                }

            }
           
            

           
        }

        private void btnIadeClick(object sender, RoutedEventArgs e)
        {
            iadeUrunler iadeUrunler = new iadeUrunler();
           // iadeUrunler.Owner = gk;
            iadeUrunler.ShowDialog();
        }


        private void sil(object sender, RoutedEventArgs e)
        {
            int index = dtg_urunSatisList.SelectedIndex;
            adetList.RemoveAt(index);
            urunIDlist.RemoveAt(index);
            fiyatList.RemoveAt(index);
            DataTable dt = new DataTable();
            dt.Columns.Add("Adet", typeof(string));
            dt.Columns.Add("UrunAdi", typeof(string));
            dt.Columns.Add("Fiyat", typeof(string));
            tutar = 0;
            foreach (int sayi in fiyatList)
            {
                tutar += sayi;

            }
            txtTutar.Text = tutar.ToString();
            dataGridDoldur();

       

        }

    }
}
