using StokTakipUygulamasi.Class.Parametreler;
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
    /// ucIndirimdekiler.xaml etkileşim mantığı
    /// </summary>
    public partial class ucIndirimdekiler : UserControl
    {
        Anasayfa gk = (Anasayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive); // Anasayfa sayfasını kontrol etmek için o sayfayı çağırıyoruz.
        string id, urun_adi;
       
        
        public ucIndirimdekiler()
        {
            InitializeComponent();

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "8") == false)
            {
                btnIndirimliUrunEkle.Visibility = Visibility.Collapsed;
            }
            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "7") == false)
            {
                dtg_IndirimdekilerListesi.Visibility = Visibility.Collapsed;
                check_Indirimde_Olmayanlar.Visibility = Visibility.Collapsed;
            }
            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "9") == false)
            {
                btnGuncelle.Visibility = Visibility.Collapsed;
            }
            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "10") == false)
            {
                btnCikar.Visibility = Visibility.Collapsed;
            }

          
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            string sorgu = ($@"Select i.ID as 'Indirim_ID', u.ID as 'Urun_ID',u.Urun_Adi,u.Satis_Fiyati as 'Indirimsiz_Satis_Fiyati',  i.Baslangic_Tarihi, i.Bitis_Tarihi, i.Yuzde, i.Indirimde_mi, i.Indirim_Taban_Fiyati, i.Satis_Fiyati, s.Eldeki_Miktar as 'Stok_Adedi' from indirimdekiler i left join urunler u on i.Urunler_ID = u.ID left join stok s on s.Urun_ID = u.ID where i.Indirimde_mi = 1");
            Genel.GridiDoldurGenel(dtg_IndirimdekilerListesi, sorgu);
           
        }

       


        private void check_Indirimde_Olmayanlar_Checked(object sender, RoutedEventArgs e)
        {
            string sorgu = ($@"Select i.ID as 'Indirim_ID', u.ID as 'Urun_ID',u.Urun_Adi,u.Satis_Fiyati as 'Indirimsiz_Satis_Fiyati',  i.Baslangic_Tarihi, i.Bitis_Tarihi, i.Yuzde, i.Indirimde_mi, i.Indirim_Taban_Fiyati, i.Satis_Fiyati, s.Eldeki_Miktar as 'Stok_Adedi' from indirimdekiler i left join urunler u on i.Urunler_ID = u.ID left join stok s on s.Urun_ID = u.ID where i.Indirimde_mi = 0");
            Genel.GridiDoldurGenel(dtg_IndirimdekilerListesi,sorgu);
            Prm.checkbox_indirimde_olmayanlar = true;
        }

        private void check_Indirimde_Olmayanlar_Unchecked(object sender, RoutedEventArgs e)
        {
            string sorgu = ($@"Select i.ID as 'Indirim_ID', u.ID as 'Urun_ID',u.Urun_Adi,u.Satis_Fiyati as 'Indirimsiz_Satis_Fiyati',  i.Baslangic_Tarihi, i.Bitis_Tarihi, i.Yuzde, i.Indirimde_mi, i.Indirim_Taban_Fiyati, i.Satis_Fiyati, s.Eldeki_Miktar as 'Stok_Adedi' from indirimdekiler i left join urunler u on i.Urunler_ID = u.ID left join stok s on s.Urun_ID = u.ID where i.Indirimde_mi = 1");
            Genel.GridiDoldurGenel(dtg_IndirimdekilerListesi,sorgu);
            Prm.checkbox_indirimde_olmayanlar = false;
        }

        private void btnCikar_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_IndirimdekilerListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                id = ((TextBlock)dtg_IndirimdekilerListesi.Columns[0].GetCellContent(dtg_IndirimdekilerListesi.SelectedItem)).Text;
                urun_adi = ((TextBlock)dtg_IndirimdekilerListesi.Columns[2].GetCellContent(dtg_IndirimdekilerListesi.SelectedItem)).Text;
                MessageBoxResult result = MessageBox.Show($"{urun_adi} isimli ürünü indirimden çıkarmak istediğinize emin misiniz?", "EVET/HAYIR", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    if (Indirimler.indirimdekilerden_cikar(id))
                    {
                        if (Prm.checkbox_indirimde_olmayanlar)
                        {
                            string sorgu = ($@"Select i.ID as 'Indirim_ID', u.ID as 'Urun_ID',u.Urun_Adi,u.Satis_Fiyati as 'Indirimsiz_Satis_Fiyati',  i.Baslangic_Tarihi, i.Bitis_Tarihi, i.Yuzde, i.Indirimde_mi, i.Indirim_Taban_Fiyati, i.Satis_Fiyati, s.Eldeki_Miktar as 'Stok_Adedi' from indirimdekiler i left join urunler u on i.Urunler_ID = u.ID left join stok s on s.Urun_ID = u.ID where i.Indirimde_mi = 0");
                            Genel.GridiDoldurGenel(dtg_IndirimdekilerListesi, sorgu);
                        }
                        else
                        {
                            string sorgu = ($@"Select i.ID as 'Indirim_ID', u.ID as 'Urun_ID',u.Urun_Adi,u.Satis_Fiyati as 'Indirimsiz_Satis_Fiyati',  i.Baslangic_Tarihi, i.Bitis_Tarihi, i.Yuzde, i.Indirimde_mi, i.Indirim_Taban_Fiyati, i.Satis_Fiyati, s.Eldeki_Miktar as 'Stok_Adedi' from indirimdekiler i left join urunler u on i.Urunler_ID = u.ID left join stok s on s.Urun_ID = u.ID where i.Indirimde_mi = 1");
                            Genel.GridiDoldurGenel(dtg_IndirimdekilerListesi, sorgu);
                        }
                        Prm.Hata = 0;
                        Prm.BilgiMesajiAlani = "Ürün indirimdekilerden çıkarıldı";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                    else
                    {
                        Prm.Hata = 1;
                        Prm.BilgiMesajiAlani = "Ürün indirimdekilerden çıkarılırken bir hata oldu!";
                        BilgiEkrani be = new BilgiEkrani();
                        be.Show();
                    }
                }
            }
            
            
        
        }

        private void btnIndirimliUrunEkle_Click(object sender, RoutedEventArgs e)
        {
            IndirimdekilereEkle ie = new IndirimdekilereEkle(dtg_IndirimdekilerListesi);
            ie.ShowDialog();
        }

        private void btnGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_IndirimdekilerListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir ürün seçiniz", "Hata", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                id = ((TextBlock)dtg_IndirimdekilerListesi.Columns[0].GetCellContent(dtg_IndirimdekilerListesi.SelectedItem)).Text;
                IndirimdekilerGuncelle ig = new IndirimdekilerGuncelle(dtg_IndirimdekilerListesi,id);
                ig.Owner = gk;
                ig.ShowDialog();
            }
        }


       

    }
}
