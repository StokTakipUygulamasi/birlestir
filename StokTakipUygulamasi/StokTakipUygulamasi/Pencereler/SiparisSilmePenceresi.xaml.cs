using StokTakipUygulamasi.Class;
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
using System.Windows.Shapes;

namespace StokTakipUygulamasi.Pencereler
{
    /// <summary>
    /// SiparisSilmePenceresi.xaml etkileşim mantığı
    /// </summary>
    public partial class SiparisSilmePenceresi : Window
    {
        DataGrid grid;
        String UrunAdi;
        int UrunId;
        public SiparisSilmePenceresi(DataGrid grid, String UrunAdi, int UrunId)
        {
            this.grid = grid;
            this.UrunAdi = UrunAdi;
            this.UrunId = UrunId;
            InitializeComponent();
            txtUyariYazi.Content = UrunAdi + " siparişini silme nedeniz? (İsteğe bağlı)";
        }

        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

            Bonus.PopupShow(popup_bilgi);
        }


        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Siparisi_Sil_Click(object sender, RoutedEventArgs e)
        {
            Prm veri = new Prm();
            veri.SiparisIptal = true;
            veri.SiparisIptalAciklama = txtSilmeSebebi.Text.ToString();
            if (Siparisler.SiparislerSil(veri, UrunId))
            {
                Prm.Hata = 0;
                Prm.BilgiMesajiAlani = "Sipariş başarıyla silindi...";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
           
            String sorgu = $@"Select s.ID, u.Urun_Adi,o.Olcu_Birimi, u.Olcu_Miktar,s.Adet, s.Siparis_Tarihi, t.Toptanci_Adi, Concat(c.Ad,' ',c.Soyad) as 'AdSoyad' 
                            from urun_siparis s 
                            left join olcu_birimi o on s.Urun_Olcu_Birimi_ID = o.ID 
                            left join urunler u on u.ID= s.Urun_ID
                            left join toptancilar t on t.ID = s.Toptanci_ID 
                            left join calisanlar c on c.ID = s.Calisan_ID where s.Silindi_Mi = 0";
            Genel.GridiDoldurGenel(grid, sorgu);
            this.Close();
        }
    }
}
