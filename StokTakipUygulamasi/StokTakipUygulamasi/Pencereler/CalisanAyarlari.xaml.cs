using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.Eklemeler;
using StokTakipUygulamasi.Guncellemeler;
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
using System.Windows.Shapes;

namespace StokTakipUygulamasi.Pencereler
{
    /// <summary>
    /// CalisanAyarlari.xaml etkileşim mantığı
    /// </summary>
    public partial class CalisanAyarlari : Window
    {
        Anasayfa gk = (Anasayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        string id;
        string aktifCalisanlarSorgusu = "select c.ID, concat (c.Ad,' ',c.Soyad) Calisan_AdSoyad, c.TC, c.Kadi, c.Foto, c.Adres, " +
               "c.Giris_IPv6_Ethernet, c.Giris_IPv6_Wireless, cb.Tel, cb.E_mail, y.Yetki from calisanlar c left join calisan_bilgileri cb on c.ID = cb.Calisan_ID " +
               "left join calisan_yetki cy on cy.Calisan_ID = c.ID left join yetkiler y on y.ID = cy.Yetki_ID where c.Silindi_Mi=0 ";
        string silinenCalisanlarSorgusu = "select c.ID, concat (c.Ad,' ',c.Soyad) Calisan_AdSoyad, c.TC, c.Kadi, c.Foto, c.Adres, " +
               "c.Giris_IPv6_Ethernet, c.Giris_IPv6_Wireless, cb.Tel, cb.E_mail, y.Yetki from calisanlar c left join calisan_bilgileri cb on c.ID = cb.Calisan_ID " +
               "left join calisan_yetki cy on cy.Calisan_ID = c.ID left join yetkiler y on y.ID = cy.Yetki_ID where c.Silindi_Mi=1 ";
        public CalisanAyarlari()
        {
            InitializeComponent();
           
            Genel.GridiDoldurGenel(dtg_CalisanListesi,aktifCalisanlarSorgusu);
            btnGeriAl.Visibility = Visibility.Hidden;

            txtBilgiPenceresi.Text = $"Bu sayfadan çalışanlara ilişkin bilgilere ulaşabilir, eski çalışanları görüntüleyebilir, çalışanların bilgilerini güncelleyebilir, çalışanı silebilir/geri alabilir ya da yeni bir çalışan ekleyebilirsiniz.";

        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // bool popupAcikMi = true; // Kişi elle kapatmak isterse diye
        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {
            Bonus.PopupShow(popup_bilgi);
            txtBilgiPenceresi.Text = "Bu sayfadan müşteri ekleyebilir, müşterileri güncelleyebilir ya da müşterileri silebilirsiniz." +
                " Sildiğiniz müşterileri de 'Silinen Müşteriler' alanından görüntüleyebilir, silinen müşterinizi geri getirebilirsiniz...";
        }

        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            id = ((TextBlock)dtg_CalisanListesi.Columns[0].GetCellContent(dtg_CalisanListesi.SelectedItem)).Text;
            if (dtg_CalisanListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                CalisanGuncelleme cg = new CalisanGuncelleme(Convert.ToInt32(id),dtg_CalisanListesi);
                cg.Owner = gk;
                cg.ShowDialog();
            }
        }

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
            
            if (dtg_CalisanListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                id = ((TextBlock)dtg_CalisanListesi.Columns[0].GetCellContent(dtg_CalisanListesi.SelectedItem)).Text;
                MessageBoxResult result = MessageBox.Show("Çalışanı silmek istediğinize emin misiniz?","Evet/Hayır",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (Calisanlar.calisanSil(Convert.ToInt32(id)))
                    {
                        Prm.Hata = 0;
                        Prm.BilgiMesajiAlani = "Çalışan başarıyla silindi...";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                    else
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Çalışan silinirken bir sorun oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }

                    Genel.GridiDoldurGenel(dtg_CalisanListesi, aktifCalisanlarSorgusu);
                }
               
            }
        }


        private void btnGeriAl_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_CalisanListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir çalışan seçiniz","Hata",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                id = ((TextBlock)dtg_CalisanListesi.Columns[0].GetCellContent(dtg_CalisanListesi.SelectedItem)).Text;
                MessageBoxResult result = MessageBox.Show("Çalışanı geri almak istediğinize emin misiniz?","Evet/Hayır", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (Calisanlar.calisaniGeriAl(Convert.ToInt32(id)))
                    {
                        Prm.Hata = 0;
                        Prm.BilgiMesajiAlani = "Çalışan başarıyla geri alındı...";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                        Genel.GridiDoldurGenel(dtg_CalisanListesi, silinenCalisanlarSorgusu);
                    }
                    else
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Çalışan geri alınırken bir sorun oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                        Genel.GridiDoldurGenel(dtg_CalisanListesi,aktifCalisanlarSorgusu);
                    }
                }
            }
        }

        private void btn_CalisanEkle_Click(object sender, RoutedEventArgs e)
        {
            CalisanEkle ce = new CalisanEkle(dtg_CalisanListesi);
            ce.Owner = gk;
            ce.ShowDialog();
        }

        private void checkbox_silinen_calisanlar_Checked(object sender, RoutedEventArgs e)
        {
            Prm.checkbox_silinen_calisanlar = true;
            Genel.GridiDoldurGenel(dtg_CalisanListesi, silinenCalisanlarSorgusu);
            btnGeriAl.Visibility = Visibility.Visible;
            btn_CalisanEkle.IsEnabled = false;
            btnGuncelle.IsEnabled = false;
            btnSil.IsEnabled = false;
        }

        private void checkbox_silinen_calisanlar_Unchecked(object sender, RoutedEventArgs e)
        {
            Prm.checkbox_silinen_calisanlar = false;
            Genel.GridiDoldurGenel(dtg_CalisanListesi, aktifCalisanlarSorgusu);
            btnGeriAl.Visibility = Visibility.Hidden;
            btnSil.IsEnabled = true;
            btnGuncelle.IsEnabled = true;
            btn_CalisanEkle.IsEnabled = true;
        }
    }
}
