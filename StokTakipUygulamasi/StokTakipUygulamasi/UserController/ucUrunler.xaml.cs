﻿using System;
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
        int satista_mi = 1;

        public ucUrunler()
        {
            InitializeComponent();

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "20") == false)
            {
                dtg_UrunlerListesi.Visibility = Visibility.Collapsed;
                check_Satista_Olmayanlar.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "19") == false)
            {
                btnGuncelle.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "18") == false)
            {
                btnSil.Visibility = Visibility.Collapsed;
            }

            if (Genel.listedeArama(Prm.oturumCalisanAltYetkiListesi, "17") == false)
            {
                btnUrunEkle.Visibility = Visibility.Collapsed;
            }

        }

        Anasayfa gk = (Anasayfa)Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive); // Anasayfa sayfasını kontrol etmek için o sayfayı çağırıyoruz.
        private void btnUrunEkle_Click(object sender, RoutedEventArgs e)
        {
            UrunEkle urunEkle = new UrunEkle(dtg_UrunlerListesi);
            urunEkle.Owner = gk;
            urunEkle.ShowDialog();
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
          
            Genel.GridiDoldurGenel(dtg_UrunlerListesi,sorgu(satista_mi));
           
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
                        if (Prm.checkbox_Satista_Olanlar == false)
                        {
                            satista_mi = 0;
                            Genel.GridiDoldurGenel(dtg_UrunlerListesi,sorgu(satista_mi));
                        }
                        else
                        {
                            satista_mi = 1;
                            Genel.GridiDoldurGenel(dtg_UrunlerListesi, sorgu(satista_mi)) ;
                        }
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
            satista_mi = 0;
            Genel.GridiDoldurGenel(dtg_UrunlerListesi, sorgu(satista_mi));
            Prm.checkbox_Satista_Olanlar = false;
            
        }


        public void check_Satista_Olmayanlar_Unchecked(object sender, RoutedEventArgs e)
        {
            satista_mi = 1;
            
            Genel.GridiDoldurGenel(dtg_UrunlerListesi, sorgu(satista_mi));
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

        public String sorgu(int satistami)
        {
            string sorgu = ($@"select u.ID, u.Urun_Adi,u.Barkod_No,u.Aciklama,u.KDV_Orani,u.Kar_Orani,u.Satis_Fiyati,u.Satista_mi,
                                    ob.Olcu_Birimi,u.Olcu_Miktar, s.Eldeki_Miktar,u.Kritik_Durum
                                    from stoktakipuygulamasi.urunler u  
                                    left join stoktakipuygulamasi.olcu_birimi ob on u.Olcu_Birimi_ID = ob.ID
                                    left join stoktakipuygulamasi.stok s on s.Urun_ID = u.ID
                                    Where u.Satista_Mi='{satistami}'");

            return sorgu;
        }



    }
}
