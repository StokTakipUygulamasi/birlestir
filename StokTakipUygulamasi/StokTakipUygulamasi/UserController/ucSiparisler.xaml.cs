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
using Org.BouncyCastle.Asn1.Cms;
using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.Pencereler;

namespace StokTakipUygulamasi.UserController
{
    /// <summary>
    /// ucSiparisler.xaml etkileşim mantığı
    /// </summary>
    public partial class ucSiparisler : UserControl
       
    {
         bool satistami = false;
      
        public ucSiparisler()
        {
            InitializeComponent();
          




        }
      
            
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Genel.GridiDoldurGenel(dtg_SiparisListesi, zamansizSorgu(satistami));

        }
        Anasayfa gk = (Anasayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);

        private void btnUrunEkleSiparis(object sender, RoutedEventArgs e)
        {
            SiparisUrunEkle siparisUrunEkle = new SiparisUrunEkle(dtg_SiparisListesi);
            siparisUrunEkle.Owner = gk;
            siparisUrunEkle.ShowDialog();

        }


        private void btnGuncelleClick(object sender, RoutedEventArgs e)
        {
            if (dtg_SiparisListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Bir ürün seçiniz");
            }
            else
            {
                string id = ((TextBlock)dtg_SiparisListesi.Columns[0].GetCellContent(dtg_SiparisListesi.SelectedItem)).Text;
                SiparisGuncelle siparisGünceller = new SiparisGuncelle(dtg_SiparisListesi, Convert.ToInt32(id));
                siparisGünceller.Owner = gk;
                siparisGünceller.ShowDialog();
            }

        }

        private void btnHaftaClick(object sender, RoutedEventArgs e)
        {
            DateTime bt = DateTime.Today;
            String bugunTarih = bt.ToString("yyyy'-'MM'-'dd");
            String OncekiHaftaTarih = bt.AddDays(-7).ToString("yyyy'-'MM'-'dd");



         
            Genel.GridiDoldurGenel(dtg_SiparisListesi, zamanaliSorgu(bugunTarih,OncekiHaftaTarih, satistami));
        }

        private void btnAyClick(object sender, RoutedEventArgs e)
        {
            DateTime bt = DateTime.Today;
            String bugunTarih = bt.ToString("yyyy'-'MM'-'dd");
            String OncekiHaftaTarih = bt.AddMonths(-1).ToString("yyyy'-'MM'-'dd");


            Genel.GridiDoldurGenel(dtg_SiparisListesi, zamanaliSorgu(bugunTarih,OncekiHaftaTarih, satistami));
        }

        private void btnYılClick(object sender, RoutedEventArgs e)
        {

            DateTime bt = DateTime.Today;
            String bugunTarih = bt.ToString("yyyy'-'MM'-'dd");
            String OncekiHaftaTarih = bt.AddYears(-1
                ).ToString("yyyy'-'MM'-'dd");


            Genel.GridiDoldurGenel(dtg_SiparisListesi, zamanaliSorgu(bugunTarih, OncekiHaftaTarih, satistami));
        }

        private void AralikGetir(object sender, RoutedEventArgs e)
        {
            String OncekiHaftaTarih = baslangis_Tarih.SelectedDate.GetValueOrDefault().ToString("yyyy'-'MM'-'dd");
            String bugunTarih = bitis_Tarih.SelectedDate.GetValueOrDefault().ToString("yyyy'-'MM'-'dd");

            if (baslangis_Tarih.Text != "" && bitis_Tarih.Text != "")
            {
                DateTime dateBaslangic = baslangis_Tarih.SelectedDate.GetValueOrDefault();
                DateTime dateBitis = bitis_Tarih.SelectedDate.GetValueOrDefault();
                int sonuc = (dateBaslangic - dateBitis).Days;
                string sorgu = "";

                if (sonuc < 0)
                {
                    OncekiHaftaTarih = baslangis_Tarih.SelectedDate.GetValueOrDefault().ToString("yyyy'-'MM'-'dd");
                    bugunTarih = bitis_Tarih.SelectedDate.GetValueOrDefault().AddDays(1).ToString("yyyy'-'MM'-'dd");
                    sorgu = zamanaliSorgu(bugunTarih,OncekiHaftaTarih, satistami);
                }
                else
                {
                    OncekiHaftaTarih = baslangis_Tarih.SelectedDate.GetValueOrDefault().AddDays(1).ToString("yyyy'-'MM'-'dd");
                    bugunTarih = bitis_Tarih.SelectedDate.GetValueOrDefault().ToString("yyyy'-'MM'-'dd");

                    sorgu = zamanaliSorgu(OncekiHaftaTarih,bugunTarih, satistami);
                }


                Genel.GridiDoldurGenel(dtg_SiparisListesi, sorgu);
            }
            else
            {
                MessageBox.Show("Lütfen Bir  Seçiniz");
            }
        }

        private void btnSillClick(object sender, RoutedEventArgs e)
        {

            if (dtg_SiparisListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Bir ürün seçiniz");
            }
            else
            {
                string id = ((TextBlock)dtg_SiparisListesi.Columns[0].GetCellContent(dtg_SiparisListesi.SelectedItem)).Text;
                String urunAdi = ((TextBlock)dtg_SiparisListesi.Columns[2].GetCellContent(dtg_SiparisListesi.SelectedItem)).Text;
                //MessageBox.Show(urunAdi+ " siparişini iptal etmek istedinizden eminmisiniz?",null,MessageBoxButton.YesNo,MessageBoxImage.Question);

                SiparisSilmePenceresi silmePenceresi = new SiparisSilmePenceresi(dtg_SiparisListesi, urunAdi, Convert.ToInt32(id));
                silmePenceresi.Owner = gk;
                silmePenceresi.ShowDialog();


            }
        }

        private void check_IptalEdilen_Siapris_Checked(object sender, RoutedEventArgs e)
        {

            silinmeAciklamdgt.Visibility = Visibility.Visible;
            btnSill.IsEnabled = false;
            btnGuncelle.IsEnabled = false;
            btnUrunEkle.IsEnabled = false;
            satistami = true;

            Genel.GridiDoldurGenel(dtg_SiparisListesi, zamansizSorgu(satistami));

        }

        private void check_IptalEdilen_Siapris_Unchecked(object sender, RoutedEventArgs e)
        {
            silinmeAciklamdgt.Visibility = Visibility.Collapsed;


            satistami = false;
            btnSill.IsEnabled = true;
            btnSill.IsEnabled = true;
            btnGuncelle.IsEnabled = true;
            btnUrunEkle.IsEnabled = true;
            Genel.GridiDoldurGenel(dtg_SiparisListesi, zamansizSorgu(satistami));
        }
        public static string zamanaliSorgu(String büyükDeger, string kücükDeger, bool satistami)
        {
  
           String  sorgu = $@"Select s.ID, u.Urun_Adi,o.Olcu_Birimi, u.Olcu_Miktar,s.Adet, s.Siparis_Tarihi, t.Toptanci_Adi, Concat(c.Ad,' ',c.Soyad) as 'AdSoyad', s.Silinme_Aciklamasi
                                from urun_siparis s 
                                left join olcu_birimi o on s.Urun_Olcu_Birimi_ID = o.ID 
                                left join urunler u on u.ID= s.Urun_ID
                                left join toptancilar t on t.ID = s.Toptanci_ID 
                                left join calisanlar c on c.ID = s.Calisan_ID where Siparis_Tarihi  between '{kücükDeger}'and '{büyükDeger}' and  s.Silindi_Mi = '{Convert.ToInt32(satistami)}'";

            return sorgu;

        }
        public static string zamansizSorgu(bool satistami)
        {

            String sorgu = $@"Select s.ID, u.Urun_Adi,o.Olcu_Birimi, u.Olcu_Miktar,s.Adet, s.Siparis_Tarihi, t.Toptanci_Adi, Concat(c.Ad,' ',c.Soyad) as 'AdSoyad', s.Silinme_Aciklamasi
                                from urun_siparis s 
                                left join olcu_birimi o on s.Urun_Olcu_Birimi_ID = o.ID 
                                left join urunler u on u.ID= s.Urun_ID
                                left join toptancilar t on t.ID = s.Toptanci_ID 
                                left join calisanlar c on c.ID = s.Calisan_ID where s.Silindi_Mi = '{Convert.ToInt32(satistami)}'";

            
            return sorgu;

        }
       

    

    }
}
