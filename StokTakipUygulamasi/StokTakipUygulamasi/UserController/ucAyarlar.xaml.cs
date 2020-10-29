using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.Eklemeler;
using StokTakipUygulamasi.Pencereler;
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

namespace StokTakipUygulamasi.UserController
{
    /// <summary>
    /// ucAyarlar.xaml etkileşim mantığı
    /// </summary>
    public partial class ucAyarlar : UserControl
    {
        Anasayfa gk = (Anasayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        public ucAyarlar()
        {
            InitializeComponent();
            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "42") == false)
            {
                btn_MusteriEkleCikar.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "43") == false)
            {
                btn_CalisanEkleCikar.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "44") == false)
            {
                btn_FirmaBilgileri.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "45") == false)
            {
                btn_YetkiDuzenleme.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "46") == false)
            {
                btn_OlcuBirimiEkleCikar.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "47") == false)
            {
                hizliSatisAyarlari.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "48") == false)
            {
                btn_TeknikDestekAl.Visibility = Visibility.Collapsed;
            }



        }
        #region ToggleButonlar
        int secimDurumu;

        private void btn_MusteriEkleCikar_Click(object sender, RoutedEventArgs e)
        {
            secimDurumu = 1;
            secilenDurum();
            MusteriAyarlari ma = new MusteriAyarlari();
            ma.Owner = gk;
            ma.ShowDialog();
        }
        private void btn_CalisanEkleCikar_Click(object sender, RoutedEventArgs e)
        {
            secimDurumu = 2;
            CalisanAyarlari ca = new CalisanAyarlari();
            ca.Owner = gk;
            ca.ShowDialog();
            secilenDurum();
        }

        private void btn_FirmaBilgileri_Click(object sender, RoutedEventArgs e)
        {
            secimDurumu = 3;
            secilenDurum();
        }

        private void btn_YetkiDuzenleme_Click(object sender, RoutedEventArgs e)
        {
            secimDurumu = 4;
            secilenDurum();
            YetkiAyarlari ya = new YetkiAyarlari();
            ya.Owner = gk;
            ya.ShowDialog();
        }

        private void btn_OlcuBirimiEkleCikar_Click(object sender, RoutedEventArgs e)
        {
            secimDurumu = 5;
            secilenDurum();
            OlcuBirimleriEkleCikar obec = new OlcuBirimleriEkleCikar();
            obec.Owner = gk;
            obec.ShowDialog();
        }

        private void hizliSatisAyarlari_Click(object sender, RoutedEventArgs e)
        {
            secimDurumu = 6;
            secilenDurum();
            hizliSatisUrunleri hsu = new hizliSatisUrunleri();
            hsu.Owner = gk;
            hsu.ShowDialog();
        }

        private void btn_TeknikDestekAl_Click(object sender, RoutedEventArgs e)
        {
            secimDurumu = 7;
            secilenDurum();
            TeknikDestek td = new TeknikDestek();
            td.Owner = gk;
            td.ShowDialog();
        }

        

        void secilenDurum()
        {

            if (secimDurumu == 1)
            {
                btn_MusteriEkleCikar.IsChecked = true;
            }
            else
            {
                btn_MusteriEkleCikar.IsChecked = false;
            }


            if (secimDurumu == 2)
            {
                btn_CalisanEkleCikar.IsChecked = true;
            }
            else
            {
                btn_CalisanEkleCikar.IsChecked = false;
            }

            if (secimDurumu == 2)
            {
                btn_CalisanEkleCikar.IsChecked = true;
            }
            else
            {
                btn_CalisanEkleCikar.IsChecked = false;
            }


            if (secimDurumu == 3)
            {
                btn_FirmaBilgileri.IsChecked = true;
            }
            else
            {
                btn_FirmaBilgileri.IsChecked = false;
            }

            if (secimDurumu == 4)
            {
                btn_YetkiDuzenleme.IsChecked = true;
            }
            else
            {
                btn_YetkiDuzenleme.IsChecked = false;
            }

            if (secimDurumu == 5)
            {
                btn_OlcuBirimiEkleCikar.IsChecked = true;
            }
            else
            {
                btn_OlcuBirimiEkleCikar.IsChecked = false;
            }
            if (secimDurumu == 6)
            {
                btn_TeknikDestekAl.IsChecked = true;
            }
            else
            {
                btn_TeknikDestekAl.IsChecked = false;
            }
           
        }

        #endregion

        
    }
}
