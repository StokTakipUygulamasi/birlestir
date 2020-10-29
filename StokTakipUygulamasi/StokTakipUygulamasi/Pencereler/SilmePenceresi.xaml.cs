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
using StokTakipUygulamasi.Class.Parametreler;

namespace StokTakipUygulamasi.Pencereler
{
    /// <summary>
    /// SilmePenceresi.xaml etkileşim mantığı
    /// </summary>
    public partial class SilmePenceresi : Window
    {
        DataGrid grid;
        String UrunAdi;
        int UrunId;
        public SilmePenceresi(DataGrid grid, String UrunAdi, int UrunId)
        {
            this.grid = grid;
            this.UrunAdi = UrunAdi;
            this.UrunId = UrunId;
            InitializeComponent();
        }

        private void btnUrunEvet(object sender, RoutedEventArgs e)
        {
            if (txtSilmeNedeni.Text != "")
            {
                Prm veri = new Prm();
                veri.SiparisIptal = true;
                veri.SiparisIptalAciklama = txtSilmeNedeni.Text.ToString();
                Siparisler.SiparislerSil(veri, UrunId);
                String sorgu = $@"Select s.ID, u.Urun_Adi,o.Olcu_Birimi, u.Olcu_Miktar,s.Adet, s.Siparis_Tarihi, t.Toptanci_Adi, Concat(c.Ad,' ',c.Soyad) as 'AdSoyad' 
                            from urun_siparis s 
                            left join olcu_birimi o on s.Urun_Olcu_Birimi_ID = o.ID 
                            left join urunler u on u.ID= s.Urun_ID
                            left join toptancilar t on t.ID = s.Toptanci_ID 
                            left join calisanlar c on c.ID = s.Calisan_ID where s.Silindi_Mi = 0";
                Genel.GridiDoldurGenel(grid, sorgu);
                this.Close();
            }else
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Siapriş İptal Nedeni Boş Olamaz!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
           

        }

        private void btnUrunHayir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PencereLOaded(object sender, RoutedEventArgs e)
        {
            txtuyariYazi.Content = UrunAdi + " siparişini silme nedeniz?";
        }
    }
}
