using Microsoft.Win32;
using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.UserController;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StokTakipUygulamasi.Pencereler
{
    /// <summary>
    /// VeresiyeDetay.xaml etkileşim mantığı
    /// </summary>
    public partial class VeresiyeDetay : Window
    {
        Prm veri = new Prm();
        public VeresiyeDetay(int veresiye_ID)
        {
            InitializeComponent();
            veri.Veresiye_ID = veresiye_ID;
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // bool popupAcikMi = true; // Kişi elle kapatmak isterse diye
        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {
            Bonus.PopupShow(popup_bilgi);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string veresiyeDetaySorgusu = $@"(select verdet.ID, Concat(m.Musteri_Adi, ' ', m.Musteri_Soyadi) 'Musteri_AdSoyad',verdet.Islem_Tarihi,verdet.Aciklama,verdet.Islem_Turu,verdet.Borc,verdet.Tahsilat, Concat(c.Ad, ' ', c.Soyad) 'CalisanAdSoyad' from veresiye ver left join veresiye_detay verdet on ver.ID = verdet.Veresiye_ID left join musteriler m on m.ID = ver.Musteri_ID left join calisanlar c on c.ID = verdet.Calisan_ID where ver.ID = '{veri.Veresiye_ID}' order by ID DESC)";
            Genel.GridiDoldurGenel(dtg_VeresiyeDetayListesi, veresiyeDetaySorgusu);
        }

    }
}
