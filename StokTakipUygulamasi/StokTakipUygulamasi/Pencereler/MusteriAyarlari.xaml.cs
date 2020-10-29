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
    /// MusteriAyarlari.xaml etkileşim mantığı
    /// </summary>
    public partial class MusteriAyarlari : Window
    {
        string id;
        Anasayfa gk = (Anasayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        public MusteriAyarlari()
        {
            InitializeComponent();
            btnGeriAl.Visibility = Visibility.Hidden;
            string aktifMusteriler = "select m.ID, m.Musteri_No, concat(m.Musteri_Adi, ' ' ,m.Musteri_Soyadi) Musteri_AdSoyad, " +
                "m.Vergi_Dairesi, m.Vergi_No,  m.E_mail, mb.Adres, mb.Is_Tel, mb.Cep_Tel, mb.Fax_No, mg.Musteri_Grubu from musteriler m " +
                "left join musteri_bilgileri mb on m.ID = mb.Musteri_ID left join musteri_grubu mg on mg.ID = m.Musteri_Grubu_ID " +
                "where m.Silindi_Mi = 0";
            Genel.GridiDoldurGenel(dtg_MusteriListesi,aktifMusteriler);
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

        private void btn_MusteriEkle_Click(object sender, RoutedEventArgs e)
        {
            MusteriEkle me = new MusteriEkle(dtg_MusteriListesi);
            me.Owner = gk;
            me.ShowDialog();
        }

        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            string id;
            if (dtg_MusteriListesi.SelectedItem != null)
            {
                id = ((TextBlock)dtg_MusteriListesi.Columns[0].GetCellContent(dtg_MusteriListesi.SelectedItem)).Text;
                MusteriGuncelleme mg = new MusteriGuncelleme(dtg_MusteriListesi,id);
                mg.Owner = gk;
                mg.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen bir müşteri seçin","Hata",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_MusteriListesi.SelectedItem != null)
            {
                id = ((TextBlock)dtg_MusteriListesi.Columns[0].GetCellContent(dtg_MusteriListesi.SelectedItem)).Text;
                MessageBoxResult result = MessageBox.Show("Müşteriyi silmek istediğinize emin misiniz?","Evet/Hayır",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (Musteriler.musteriSil(id))
                    {
                        Prm.Hata = 0;
                        Prm.BilgiMesajiAlani = "Müşteri başarıyla silindi...";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                        string aktifMusteriler = "select m.ID, m.Musteri_No, concat(m.Musteri_Adi, ' ' ,m.Musteri_Soyadi) Musteri_AdSoyad, " +
                "m.Vergi_Dairesi, m.Vergi_No,  m.E_mail, mb.Adres, mb.Is_Tel, mb.Cep_Tel, mb.Fax_No, mg.Musteri_Grubu from musteriler m " +
                "left join musteri_bilgileri mb on m.ID = mb.Musteri_ID left join musteri_grubu mg on mg.ID = m.Musteri_Grubu_ID" +
                "where m.Silindi_Mi = 0; ";
                        Genel.GridiDoldurGenel(dtg_MusteriListesi, aktifMusteriler);
                    }
                    else
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Müşteri silinirken bir hata oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Lütfen bir müşteri seçin", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Prm.checkbox_silinen_musteriler = true;
            btnGeriAl.Visibility = Visibility.Visible;
            btnGuncelle.IsEnabled = false;
            btnSil.IsEnabled = false;
            btn_MusteriEkle.IsEnabled = false;
            string silinmisMusteriler = "select m.ID, m.Musteri_No, concat(m.Musteri_Adi, ' ' ,m.Musteri_Soyadi) Musteri_AdSoyad, " +
                "m.Vergi_Dairesi, m.Vergi_No,  m.E_mail, mb.Adres, mb.Is_Tel, mb.Cep_Tel, mb.Fax_No, mg.Musteri_Grubu from musteriler m " +
                "left join musteri_bilgileri mb on m.ID = mb.Musteri_ID left join musteri_grubu mg on mg.ID = m.Musteri_Grubu_ID" +
                "where m.Silindi_Mi = 1; ";
            Genel.GridiDoldurGenel(dtg_MusteriListesi, silinmisMusteriler);
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Prm.checkbox_silinen_musteriler = false;
            btnGeriAl.Visibility = Visibility.Hidden;
            btnSil.IsEnabled = true;
            btnGuncelle.IsEnabled = true;
            btn_MusteriEkle.IsEnabled = true;
            string aktifMusteriler = "select m.ID, m.Musteri_No, concat(m.Musteri_Adi, ' ' ,m.Musteri_Soyadi) Musteri_AdSoyad, " +
                "m.Vergi_Dairesi, m.Vergi_No,  m.E_mail, mb.Adres, mb.Is_Tel, mb.Cep_Tel, mb.Fax_No, mg.Musteri_Grubu from musteriler m " +
                "left join musteri_bilgileri mb on m.ID = mb.Musteri_ID left join musteri_grubu mg on mg.ID = m.Musteri_Grubu_ID" +
                "where m.Silindi_Mi = 0; ";
            Genel.GridiDoldurGenel(dtg_MusteriListesi, aktifMusteriler);
        }

        private void btnGeriAl_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_MusteriListesi.SelectedItem != null)
            {
                id = ((TextBlock)dtg_MusteriListesi.Columns[0].GetCellContent(dtg_MusteriListesi.SelectedItem)).Text;
                MessageBoxResult result = MessageBox.Show("Müşteriyi geri almak istediğiniz emin misiniz?","Evet/Hayır", MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (Musteriler.musteriGeriAl(id))
                    {
                        Prm.Hata = 0;
                        Prm.BilgiMesajiAlani = "Müşteri başarıyla geri alındı...";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                        string silinmisMusteriler = "select m.ID, m.Musteri_No, concat(m.Musteri_Adi, ' ' ,m.Musteri_Soyadi) Musteri_AdSoyad, " +
                "m.Vergi_Dairesi, m.Vergi_No,  m.E_mail, mb.Adres, mb.Is_Tel, mb.Cep_Tel, mb.Fax_No, mg.Musteri_Grubu from musteriler m " +
                "left join musteri_bilgileri mb on m.ID = mb.Musteri_ID left join musteri_grubu mg on mg.ID = m.Musteri_Grubu_ID" +
                "where m.Silindi_Mi = 1;";
                        Genel.GridiDoldurGenel(dtg_MusteriListesi, silinmisMusteriler);

                    }
                    else
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Müşteri geri alınırken bir hata oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Lütfen bir müşteri seçin", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
