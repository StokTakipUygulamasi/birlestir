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
using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.Eklemeler;
using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Guncellemeler;
using StokTakipUygulamasi.Pencereler;

namespace StokTakipUygulamasi.UserController
{
    /// <summary>
    /// ucVeresiyeler.xaml etkileşim mantığı
    /// </summary>
    public partial class ucVeresiyeler : UserControl
    {
        Anasayfa gk = (Anasayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        public ucVeresiyeler()
        {
            InitializeComponent();
            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "25") == false)
            {
                dtg_VeresiyelerListesi.Visibility = Visibility.Collapsed;
                check_Odenmis_Borclar.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "27") == false)
            {
                btnGuncelle.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "29") == false)
            {
                btnDetaylar.Visibility = Visibility.Collapsed;
            }
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string sorgu_VeresiyeDoldur = "select ver.ID as 'ID', Concat(mus.Musteri_Adi,' ',mus.Musteri_Soyadi) as Musteri_AdSoyad, musbil.Cep_Tel, mus.E_mail, musbil.Adres, ver.Toplam_Bakiye, ver.Para_Turu ,ver.Son_Odeme_Tarihi from musteriler mus left join musteri_bilgileri musbil on mus.ID = musbil.Musteri_ID left join veresiye ver on ver.Musteri_ID = mus.ID where ver.Toplam_Bakiye>0";
            Genel.GridiDoldurGenel(dtg_VeresiyelerListesi,sorgu_VeresiyeDoldur);
        }

        int id;
        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_VeresiyelerListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen önce bir kayıt seçiniz","Hata",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                id = Convert.ToInt16(((TextBlock)dtg_VeresiyelerListesi.Columns[0].GetCellContent(dtg_VeresiyelerListesi.SelectedItem)).Text);
                VeresiyeBorcOdeme vbo = new VeresiyeBorcOdeme(dtg_VeresiyelerListesi,id);
                vbo.Owner = gk;
                vbo.ShowDialog();
            }
        }

        private void btnDetaylar_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_VeresiyelerListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen önce bir kayıt seçiniz","Hata",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            else
            {
                id = Convert.ToInt16(((TextBlock)dtg_VeresiyelerListesi.Columns[0].GetCellContent(dtg_VeresiyelerListesi.SelectedItem)).Text);
                VeresiyeDetay vd = new VeresiyeDetay(id);
                vd.Owner = gk;
                vd.ShowDialog();
            }
        }

        private void check_Odenmis_Borclar_Checked(object sender, RoutedEventArgs e)
        {
            Prm.checkbox_odenen_veresiyeler = true;
            string sorgu_VeresiyeDoldur = "select ver.ID as 'ID', Concat(mus.Musteri_Adi,' ',mus.Musteri_Soyadi) as Musteri_AdSoyad, musbil.Cep_Tel, mus.E_mail, musbil.Adres, ver.Toplam_Bakiye, ver.Para_Turu ,ver.Son_Odeme_Tarihi from musteriler mus left join musteri_bilgileri musbil on mus.ID = musbil.Musteri_ID left join veresiye ver on ver.Musteri_ID = mus.ID where ver.Toplam_Bakiye<=0";
            Genel.GridiDoldurGenel(dtg_VeresiyelerListesi, sorgu_VeresiyeDoldur);
            btnDetaylar.IsEnabled = false;
            btnGuncelle.IsEnabled = false;
        }

        private void check_Odenmis_Borclar_Unchecked(object sender, RoutedEventArgs e)
        {
            Prm.checkbox_odenen_veresiyeler = false;
            string sorgu_VeresiyeDoldur = "select ver.ID as 'ID', Concat(mus.Musteri_Adi,' ',mus.Musteri_Soyadi) as Musteri_AdSoyad, musbil.Cep_Tel, mus.E_mail, musbil.Adres, ver.Toplam_Bakiye, ver.Para_Turu ,ver.Son_Odeme_Tarihi from musteriler mus left join musteri_bilgileri musbil on mus.ID = musbil.Musteri_ID left join veresiye ver on ver.Musteri_ID = mus.ID where ver.Toplam_Bakiye>0";
            Genel.GridiDoldurGenel(dtg_VeresiyelerListesi, sorgu_VeresiyeDoldur);
            btnDetaylar.IsEnabled = true;
            btnGuncelle.IsEnabled = true;
        }
    }
}
