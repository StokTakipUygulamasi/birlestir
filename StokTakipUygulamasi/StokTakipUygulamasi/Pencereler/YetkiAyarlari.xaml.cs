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
    /// YetkiAyarlarixaml.xaml etkileşim mantığı
    /// </summary>
    public partial class YetkiAyarlari : Window
    {
        string aktifYetkiler = "Select * from yetkiler where Silindi_Mi=0";
        string silinenYetkiler = "Select * from yetkiler where Silindi_Mi=1";
        string id;
        Anasayfa gk = (Anasayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
        public YetkiAyarlari()
        {
            InitializeComponent();
            btnGeriAl.Visibility = Visibility.Hidden;
           
            Genel.GridiDoldurGenel(dtg_YetkiListesi,aktifYetkiler);

            txtBilgiPenceresi.Text = "Bu sayfadan departmanlara ulaşabilir, departmanları güncelleyebilir, departmanları silebilir/geri alabilir, silinen departmanları görüntüleyebilir ya da yeni bir departman ekleyebilirsiniz.  ";
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // bool popupAcikMi = true; // Kişi elle kapatmak isterse diye


        private void checkbox_silinenYetkiler_Checked(object sender, RoutedEventArgs e)
        {
            Genel.GridiDoldurGenel(dtg_YetkiListesi, silinenYetkiler);
            btnGeriAl.Visibility = Visibility.Visible;
            btnIsmiGuncelle.IsEnabled = false;
            btnDepartmanEkle.IsEnabled = false;
            btnSil.IsEnabled = false;
        }

        private void checkbox_silinenYetkiler_Unchecked(object sender, RoutedEventArgs e)
        {
            Genel.GridiDoldurGenel(dtg_YetkiListesi, aktifYetkiler);
            btnGeriAl.Visibility = Visibility.Hidden;
            btnIsmiGuncelle.IsEnabled = true;
            btnDepartmanEkle.IsEnabled = true;
            btnSil.IsEnabled = true;
        }

        private void btnGeriAl_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_YetkiListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir departman seçiniz!", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                id = ((TextBlock)dtg_YetkiListesi.Columns[0].GetCellContent(dtg_YetkiListesi.SelectedItem)).Text;
                MessageBoxResult result = MessageBox.Show("Departmanı geri almak istediğinize emin misiniz?", "Evet/Hayır", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (Departmanlar.departmaniSilGeriAl(Convert.ToInt32(id), "geri al"))
                    {
                        Prm.Hata = 0;
                        Prm.BilgiMesajiAlani = "Departman başarıyla geri alındı...";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                    else
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Departman geri alınırken bir sorun oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                    Genel.GridiDoldurGenel(dtg_YetkiListesi, silinenYetkiler);
                }

            }
        }

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_YetkiListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir departman seçiniz!", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                id = ((TextBlock)dtg_YetkiListesi.Columns[0].GetCellContent(dtg_YetkiListesi.SelectedItem)).Text;
                MessageBoxResult result = MessageBox.Show("Departmanı silmek istediğinize emin misiniz?","Evet/Hayır",MessageBoxButton.YesNo,MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (Departmanlar.departmaniSilGeriAl(Convert.ToInt32(id),"sil"))
                    {
                        Prm.Hata = 0;
                        Prm.BilgiMesajiAlani = "Departman başarıyla silindi...";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                    else
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Departman silinirken bir sorun oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                    Genel.GridiDoldurGenel(dtg_YetkiListesi, aktifYetkiler);
                }
                
            }
        }

        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {
            Bonus.PopupShow(popup_bilgi);
            txtBilgiPenceresi.Text = "Bu sayfadan departman ekleyebilir, departmanı güncelleyebilir ya da departmanı silebilirsiniz." +
                " Sildiğiniz departmanları da 'Silinen Departmanlar' alanından görüntüleyebilir, silinen departmanları geri getirebilirsiniz...";
        }

        private void btnIsmiGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_YetkiListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir departman seçiniz!", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                id = ((TextBlock)dtg_YetkiListesi.Columns[0].GetCellContent(dtg_YetkiListesi.SelectedItem)).Text;
                DepartmanGuncelleme dg = new DepartmanGuncelleme(dtg_YetkiListesi,id);
                dg.Owner = gk;
                dg.ShowDialog();
            }
        }

        private void btnAltYetkiGuncelle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDepartmanEkle_Click(object sender, RoutedEventArgs e)
        {
            DepartmanEkle de = new DepartmanEkle(dtg_YetkiListesi);
            de.Owner = gk;
            de.ShowDialog();
        }
    }


}
