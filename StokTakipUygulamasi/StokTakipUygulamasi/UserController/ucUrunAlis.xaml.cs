using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Class.Parametreler;

namespace StokTakipUygulamasi.UserController
{
    /// <summary>
    /// ucUrunAlis.xaml etkileşim mantığı
    /// </summary>
    public partial class ucUrunAlis : UserControl
    {
        int UrunID = 0;
        int OlcuBirimiID = 0;
        int Toptanci_ID = 0;
        bool siparisVerildimi = true;
        static List<String> siparisIDList;
        int siparis_ID = 0;
        int CalisanID = 0;
        public ucUrunAlis()
        {
           
          
            InitializeComponent();
          
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            siparisIDList = new List<string>();
            verileriTemizleAcKapat(false);
            SiparisSorgu(Siparis_combox);
        }

        private void SiparisiComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (siparisVerildimi)
            {
                verileriTemizle();
                List<String> gelenGidenVeri = new List<string>();
                gelenGidenVeri.Add("Urun_Adi");
                gelenGidenVeri.Add("Olcu_Birimi");
                gelenGidenVeri.Add("Olcu_Miktar");
                gelenGidenVeri.Add("Adet");
                gelenGidenVeri.Add("Siparis_Tarihi");
                gelenGidenVeri.Add("Toptanci_Adi");
                gelenGidenVeri.Add("Calisan");




                siparis_ID = Convert.ToInt32(siparisIDList[Siparis_combox.SelectedIndex]);
                String sorgu = $@"select u.Urun_Adi,u.Olcu_Miktar,o.Olcu_Birimi,s.Adet,s.Siparis_Tarihi,t.Toptanci_Adi, concat(c.Ad,' ',c.Soyad) as Calisan 
                            from urun_siparis s left join urunler u on u.ID = s.Urun_ID 
                            left join olcu_birimi o on s.Urun_Olcu_Birimi_ID = o.ID 
                            left join toptancilar t on s.Toptanci_ID = t.ID 
                            left join calisanlar c on s.Calisan_ID = c.ID where s.ID ='{siparis_ID}'";





                gelenGidenVeri = Genel.cokluVeriCekme(sorgu, gelenGidenVeri, 7);
                urunAdi_combox.Items.Add(gelenGidenVeri[0]);
                urunAdi_combox.SelectedIndex = 0;
                olcuBirimi_combox.Items.Add(gelenGidenVeri[1]);
                olcuBirimi_combox.SelectedIndex = 0;
                olcu_miktariCombox.Items.Add(gelenGidenVeri[2]);
                olcu_miktariCombox.SelectedIndex = 0;
                txt_Adet.Text = gelenGidenVeri[3];
                siparis_Tarihi_date.Text = gelenGidenVeri[4];
                alis_Tarihi_date.Text = DateTime.Now.Date.ToString();
                toptanciCombox.Items.Add(gelenGidenVeri[5]);
                toptanciCombox.SelectedIndex = 0;
                siparis_Veren_Calisan_text.Text = gelenGidenVeri[6];

            }


        }

        private void radioSVerilen(object sender, RoutedEventArgs e)
        {

            siparisVerildimi = true;
            verileriTemizleAcKapat(false);
          //  siparisDockPanel.Visibility = Visibility.Visible;
           // siparis_Tarih_Dock.Visibility = Visibility.Visible;
          //  siparis_Veren_Dock.Visibility = Visibility.Visible;
            SiparisSorgu(Siparis_combox);

            Siparis_combox.Visibility = Visibility.Visible;
            siparis_label.Visibility = Visibility.Visible;
            siparisTarihLabel.Visibility = Visibility.Visible;
            siparis_Tarihi_date.Visibility = Visibility.Visible;
            siparisverenCalisanLabel.Visibility = Visibility.Visible;
            siparis_Veren_Calisan_text.Visibility = Visibility.Visible;

          
        
        }

        private void radioSVerilmeyen(object sender, RoutedEventArgs e)
        {
          
            siparisVerildimi = false;
            verileriTemizleAcKapat(true);
            /*
            siparisDockPanel.Visibility = Visibility.Collapsed;
            siparis_Tarih_Dock.Visibility = Visibility.Collapsed;
            siparis_Veren_Dock.Visibility = Visibility.Collapsed;
            */
            Siparis_combox.Visibility = Visibility.Collapsed;
            siparis_label.Visibility = Visibility.Collapsed;
            siparisTarihLabel.Visibility = Visibility.Collapsed;
            siparis_Tarihi_date.Visibility = Visibility.Collapsed;
            siparisverenCalisanLabel.Visibility = Visibility.Collapsed;
            siparis_Veren_Calisan_text.Visibility = Visibility.Collapsed;

            urunAdi_combox = Genel.ComboBoxVeriCekme(urunAdi_combox,$@"select Urun_Adi from stoktakipuygulamasi.urunler", "Urun_Adi");
            toptanciCombox = Genel.ComboBoxVeriCekme(toptanciCombox, $@"select Toptanci_Adi from toptancilar", "Toptanci_Adi");
            alis_Tarihi_date.Text = DateTime.Now.Date.ToString();
           



        }
        public void verileriTemizleAcKapat(Boolean gorunurluk)
        {
            urunAdi_combox.IsEnabled = gorunurluk;
            olcu_miktariCombox.IsEnabled = gorunurluk;
            txt_Adet.IsEnabled = gorunurluk;
            siparis_Tarihi_date.IsEnabled = gorunurluk;
            toptanciCombox.IsEnabled = gorunurluk;

           

            Siparis_combox.Items.Clear();
            urunAdi_combox.Items.Clear();

            olcuBirimi_combox.Items.Clear();
            olcu_miktariCombox.Items.Clear();
            toptanciCombox.Items.Clear();
            urunAdi_combox.Items.Clear();
            txt_Adet.Text = "";
            alis_Tarihi_date.Text = "";
            siparis_Tarihi_date.Text = "";
            siparis_Veren_Calisan_text.Text = "";
            teslim_Alan_Calisan_text.Text = "";
          
           

        }
        public void verileriTemizle()
        {
          
            urunAdi_combox.Items.Refresh();
            urunAdi_combox.Items.Clear();
            olcuBirimi_combox.Items.Clear();
            olcu_miktariCombox.Items.Clear();
            toptanciCombox.Items.Clear();
            urunAdi_combox.Items.Clear();
            txt_Adet.Text = "";
            alis_Tarihi_date.Text = "";
            siparis_Tarihi_date.Text = "";
            siparis_Veren_Calisan_text.Text = "";
            teslim_Alan_Calisan_text.Text = "";
            
            

        }
        public static void SiparisSorgu(ComboBox Siparis_combox)
        {
            String sorgu = $@"select Concat(u.Urun_Adi,' Siparis Tarihi ',s.Siparis_Tarihi,' Adeti', Adet) as A, s.ID
 
                                from stoktakipuygulamasi.urun_siparis s left join stoktakipuygulamasi.urunler u on s.Urun_ID = u.ID where s.Silindi_Mi = 0 and Teslim_Edildi_Mi = 0";


            Siparis_combox = Genel.ComboBoxVeriCekme(Siparis_combox, sorgu, "A");
            siparisIDList = Genel.TekUrunTümListeCek(sorgu, "ID");

        }

   

        private void UrunAdiComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if (siparisVerildimi == false)
            {
                if (urunAdi_combox.SelectedItem  != null)
                {
                    string UrunIdBulmaSorgu = $@"select ID from urunler where Urun_Adi= '{urunAdi_combox.SelectedItem.ToString()}'";
                    UrunID = Genel.tekilVeriCekmeInt(UrunIdBulmaSorgu, "ID");

                    string OlcuBirimiIdBulmaSorgu = $@"select Olcu_Birimi_ID from urunler where Urun_Adi= '{urunAdi_combox.SelectedItem.ToString()}'";
                    OlcuBirimiID = Genel.tekilVeriCekmeInt(OlcuBirimiIdBulmaSorgu, "Olcu_Birimi_ID");
                    string OlcuBirimiBulmaSorgu = $@"select Olcu_Birimi from olcu_birimi where ID= '{OlcuBirimiID}'";
                    string olcuBirimi = Genel.tekilVeriCekmeString(OlcuBirimiBulmaSorgu, "Olcu_Birimi");

                    olcuBirimi_combox.Items.Add(olcuBirimi);
                    olcuBirimi_combox.SelectedIndex = 0;
                    olcuBirimi_combox.IsEnabled = false;


                    String comboVeriCekme = $@"select Olcu_Miktar from urunler where Urun_Adi = '{ urunAdi_combox.SelectedItem}'";

                    olcu_miktariCombox = Genel.ComboBoxVeriCekme(olcu_miktariCombox, comboVeriCekme, "Olcu_Miktar");
                }
                

            }


        }

        private void TotanciAdiComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ToptanciIDBulmaSorgu = $@"select ID from toptancilar where Toptanci_Adi ='{toptanciCombox.SelectedItem}' ";
            Toptanci_ID = Genel.tekilVeriCekmeInt(ToptanciIDBulmaSorgu, "ID");
        }


        private void txtToplamTutar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }

        private void txtSiparisAdeti_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }

        private void btnStogaEkle(object sender, RoutedEventArgs e)
        {
            int OncekiEldekiMiktar = Genel.tekilVeriCekmeInt($@"select Eldeki_Miktar from stok where  Urun_ID = '{UrunID}' ", "Eldeki_Miktar");
            int OncekiToplamGiris = Genel.tekilVeriCekmeInt($@"select Toplam_Giris from stok where  Urun_ID = '{UrunID}' ", "Toplam_Giris");
         
            int  GuncelToplamGiris = 0;
            int GuncelEldekiMiktar = 0;
            if (siparisVerildimi)
            { 
                if (toplam_Fiyat_text.Text != "" )
                {
                    String sorgu_UrunID = $@"select Urun_ID from  urun_siparis  where ID = '{siparis_ID}'";
                    UrunID = Genel.tekilVeriCekmeInt(sorgu_UrunID, "Urun_ID");
                    String sorgu_ToptanciID = $@"select Toptanci_ID from  urun_siparis  where ID = '{siparis_ID}'";
                    Toptanci_ID = Genel.tekilVeriCekmeInt(sorgu_ToptanciID, "Toptanci_ID");
                    String sorgu_OlcuBrimiID = $@"select Urun_Olcu_Birimi_ID from  urun_siparis  where ID = '{siparis_ID}'";
                    OlcuBirimiID = Genel.tekilVeriCekmeInt(sorgu_OlcuBrimiID, "Urun_Olcu_Birimi_ID");
                    int AlisFiyati = Convert.ToInt32(toplam_Fiyat_text.Text.ToString());
                    int Adet = Convert.ToInt16(txt_Adet.Text);
                    DateTime AlisZamani = alis_Tarihi_date.SelectedDate.Value.Date;
                    CalisanID = 2;
                
                    Prm prm = new Prm();
                    prm.UrunAlisFiyat = AlisFiyati;
                    prm.SiparisAdet = Adet;
                    prm.UrunAlisTarih = AlisZamani;
                    prm.ToptanciID = 9;//Toptanci_ID;
                    prm.UrunID = UrunID;
                    prm.Olcu_Birimi_ID = OlcuBirimiID;
                    prm.CalisanID = CalisanID;
                   // prm.SiparisTarihi = siparis_Tarihi_date.SelectedDate.Value.Date;
                    prm.FaturaID = 6;


                    if (!Urunler.urunlerAlisEkle(prm))
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Veritabanına eklenirken bir sorun oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }

                     GuncelEldekiMiktar = OncekiEldekiMiktar + Adet;
                     GuncelToplamGiris = OncekiToplamGiris + Adet;

                

                    prm.Stok_EldekiMiktar = GuncelEldekiMiktar;
                    prm.Stok_Toplam_Giris = GuncelToplamGiris;
                    Stok.StokGuncellStogaEkle(prm, UrunID);

                }
                else
                {
                    Prm.Hata = 1;
                    Prm.BilgiMesajiAlani = "Toplam Tutar ve Siparis Fatura No boş olamaz!";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                }
            }
            else
            {
                if (urunAdi_combox.SelectedItem != null && olcu_miktariCombox.SelectedItem != null && txt_Adet.Text != "" && toptanciCombox != null && toplam_Fiyat_text.Text != "")
                {


                    int AlisFiyati = Convert.ToInt32(toplam_Fiyat_text.Text.ToString());
                    int Adet = Convert.ToInt16(txt_Adet.Text);
                    DateTime AlisZamani = alis_Tarihi_date.SelectedDate.Value.Date;
                    CalisanID = 2;

                    Prm prm = new Prm();
                    prm.UrunAlisFiyat = AlisFiyati;
                    prm.SiparisAdet = Adet;
                    prm.UrunAlisTarih = AlisZamani;
                    prm.ToptanciID = 9;//Toptanci_ID;
                    prm.UrunID = UrunID;
                    prm.Olcu_Birimi_ID = OlcuBirimiID;
                    prm.CalisanID = CalisanID;
                    // prm.SiparisTarihi = siparis_Tarihi_date.SelectedDate.Value.Date;
                    prm.FaturaID = 6;



                    if (!Urunler.urunlerAlisEkle(prm))
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Veritabanına eklenirken bir sorun oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }


                    GuncelEldekiMiktar = OncekiEldekiMiktar + Adet;
                    GuncelToplamGiris = OncekiToplamGiris + Adet;



                    prm.Stok_EldekiMiktar = GuncelEldekiMiktar;
                    prm.Stok_Toplam_Giris = GuncelToplamGiris;
                    Stok.StokGuncellStogaEkle(prm, UrunID);

                }
                else
                {
                    Prm.Hata = 1;
                    Prm.BilgiMesajiAlani = " Ürun Adi, Ölçü Miktari, Toptancı, Siparis Adeti ,Toplam Tutar ve Siparis Fatura No boş olamaz!";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                }
            }
            


            MessageBox.Show(OncekiEldekiMiktar + "--" + GuncelEldekiMiktar);
            MessageBox.Show(OncekiToplamGiris + "--" + GuncelEldekiMiktar);

        }

      
    }
}
