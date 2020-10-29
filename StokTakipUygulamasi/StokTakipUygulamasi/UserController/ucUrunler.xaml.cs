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

namespace StokTakipUygulamasi.UserController
{
    /// <summary>
    /// SatisYap.xaml etkileşim mantığı
    /// </summary>
    public partial class ucUrunler : UserControl
    {
        public static bool satistami = true;

        public ucUrunler()
        {
            InitializeComponent();
        }

        Anasayfa gk = (Anasayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive); // Anasayfa sayfasını kontrol etmek için o sayfayı çağırıyoruz.
        private void btnUrunEkle_Click(object sender, RoutedEventArgs e)
        {
            UrunEkle urunEkle = new UrunEkle(dtg_UrunlerListesi,check_Satista_Olmayanlar);
            urunEkle.Owner = gk;
            urunEkle.ShowDialog();
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
          
            Genel.GridiDoldurGenel(dtg_UrunlerListesi,sorgu(satistami));
           
        }


        string id,ad;

        private void btnSil_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_UrunlerListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                id = ((TextBlock)dtg_UrunlerListesi.Columns[0].GetCellContent(dtg_UrunlerListesi.SelectedItem)).Text;
                ad = ((TextBlock)dtg_UrunlerListesi.Columns[1].GetCellContent(dtg_UrunlerListesi.SelectedItem)).Text;
                MessageBoxResult result = MessageBox.Show($"{ad} isimli ürünü silmek istediğinize emin misiniz?", "EVET/HAYIR", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (Urunler.UrunSil(id))
                    {

                        check_Satista_Olmayanlar.IsChecked = true;
                        Genel.GridiDoldurGenel(dtg_UrunlerListesi, sorgu(false));
                        Prm.Hata = 0;
                        Prm.BilgiMesajiAlani = "Ürün Başarıyla Silindi...";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                    else
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Ürün Silinirken Bir Hata Oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                }
            }


        }

        public void check_Satista_Olmayanlar_Checked(object sender, RoutedEventArgs e)
        {
            btnSil.IsEnabled = false;
            btnGuncelle.IsEnabled = false;
            btnGeriAl.Visibility = Visibility.Visible;
            satistami = false;
            Genel.GridiDoldurGenel(dtg_UrunlerListesi, sorgu(satistami));
            Prm.checkbox_Satista_Olanlar = false;
            
        }


        public void check_Satista_Olmayanlar_Unchecked(object sender, RoutedEventArgs e)
        {
            btnSil.IsEnabled = true;
            btnGuncelle.IsEnabled = true;
            btnGeriAl.Visibility = Visibility.Collapsed;
            satistami = true;
            
            Genel.GridiDoldurGenel(dtg_UrunlerListesi, sorgu(satistami));
            Prm.checkbox_Satista_Olanlar = true;
        }

        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_UrunlerListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Bir ürün seçiniz");
            }
            else
            {
                id = ((TextBlock)dtg_UrunlerListesi.Columns[0].GetCellContent(dtg_UrunlerListesi.SelectedItem)).Text;
                ad = ((TextBlock)dtg_UrunlerListesi.Columns[1].GetCellContent(dtg_UrunlerListesi.SelectedItem)).Text;
                UrunGuncelle ug = new UrunGuncelle(dtg_UrunlerListesi, id);
                ug.Owner = gk;
                ug.ShowDialog();
            }
           
        }

        private void btnGeriAl_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_UrunlerListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen geri almak istediğiniz bir ürünü seçiniz!", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Ürünü geri almak istediğinize emin misiniz?", "Evet/Hayır", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    id = ((TextBlock)dtg_UrunlerListesi.Columns[0].GetCellContent(dtg_UrunlerListesi.SelectedItem)).Text;
                    if (Urunler.UrunuGeriAl(Convert.ToInt32(id)))
                    {
                        check_Satista_Olmayanlar.IsChecked = false;
                        Prm.Hata = 0;
                        Prm.BilgiMesajiAlani = "Ürün başarıyla geri alındı...";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                        
                        Genel.GridiDoldurGenel(dtg_UrunlerListesi, sorgu(true));
                    }
                    else
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Ürün geri alınırken bir sorun oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.ShowDialog();
                    }
                }

            }
        }

        public String sorgu(bool satistami)
        {
  
            string sorgu = ($@"select u.ID, u.Urun_Adi,u.Barkod_No,u.Aciklama,u.KDV_Orani,u.Kar_Orani,u.Satis_Fiyati,u.Satista_mi,
                                    ob.Olcu_Birimi,u.Olcu_Miktar, s.Eldeki_Miktar,u.Kritik_Durum
                                    from stoktakipuygulamasi.urunler u  
                                    left join stoktakipuygulamasi.olcu_birimi ob on u.Olcu_Birimi_ID = ob.ID
                                    left join stoktakipuygulamasi.stok s on s.Urun_ID = u.ID
                                    Where u.Satista_Mi='{Convert.ToInt32(satistami)}'");


            return sorgu;
        }



    }
}
