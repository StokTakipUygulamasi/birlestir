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

namespace StokTakipUygulamasi
{
    /// <summary>
    /// SiparisGuncelle.xaml etkileşim mantığı
    /// </summary>
    public partial class SiparisGuncelle : Window
    {
        DataGrid grid;
        int Siparis_ID;
        Prm veri;
        int UrunID = 0;
        int OlcuBirimiID = 0;
        int Toptanci_ID = 0;
        public SiparisGuncelle(DataGrid grid, int Siparis_ID )
        {
         
            this.grid = grid;
            this.Siparis_ID = Siparis_ID;
            InitializeComponent();
            DateTime zaman = DateTime.Now;
            int yil = zaman.Year;
            int ay = zaman.Month;
            int gun = zaman.Day;

            String[] cek = Siparisler.SiparisCek(Siparis_ID);

            UrunAdiComBox = Genel.ComboBoxVeriCekme(UrunAdiComBox, $@"select DISTINCT Urun_Adi from urunler", "Urun_Adi");
            ToptancıAdiComBox = Genel.ComboBoxVeriCekme(ToptancıAdiComBox, $@"select Toptanci_Adi from toptancilar", "Toptanci_Adi");
            OlcüMiktariComboox = Genel.ComboBoxVeriCekme(OlcüMiktariComboox, $@"select distinct Olcu_Miktar from urunler where Urun_Adi = '{ cek[3]}'", "Olcu_Miktar");

            txtSiparisAdeti.Text = cek[1];
            dateSiparisTarihi.Text = cek[2];
            OlcüMiktariComboox.SelectedItem = cek[7];
            UrunAdiComBox.SelectedItem = cek[3];
            txtOlcuBirimi.Text = cek[4];
            ToptancıAdiComBox.SelectedItem = cek[5];
            txtStokAdeti.Text = cek[7];


            int UrunId = Genel.tekilVeriCekmeInt($@"select ID from urunler where Urun_Adi like '{cek[3]}'","ID");
            String StokAdetiSorgu = $@"select Eldeki_Miktar from stok where Urun_ID = '{UrunId}'";
            int StokAdeti = Genel.tekilVeriCekmeInt(StokAdetiSorgu, "Eldeki_Miktar");
            txtStokAdeti.Text = StokAdeti.ToString();
            UrunAdiComBox.IsEnabled = false;
            OlcüMiktariComboox.IsEnabled = false;
            ToptancıAdiComBox.IsEnabled = false;

            txtBilgiPenceresi.Text = $"Bu sayfadan {UrunAdiComBox} isimli ürünün sipariş bilgilerini güncelleyebilirsiniz. [ Yanında * olanlar zorunludur. ]";
        }



        private void btnUrunGuncelleSiparis(object sender, RoutedEventArgs e)
        {
            Prm veri2 = new Prm();
            veri2.SiparisAdet = Convert.ToInt32(txtSiparisAdeti.Text);
            veri2.SiparisTarihi = dateSiparisTarihi.SelectedDate.GetValueOrDefault();
            if (Siparisler.SiparislerGuncelle(veri2, Siparis_ID))
            {
                String sorgu = $@"Select s.ID, u.Urun_Adi,o.Olcu_Birimi, u.Olcu_Miktar,s.Adet, s.Siparis_Tarihi, t.Toptanci_Adi, c.Ad,c.Soyad 
                            from urun_siparis s 
                            join olcu_birimi o on s.Urun_Olcu_Birimi_ID = o.ID 
                            join urunler u on u.ID= s.Urun_ID
                            join toptancilar t on t.ID = s.Toptanci_ID 
                            join calisanlar c on c.ID = s.Calisan_ID;";
                Genel.GridiDoldurGenel(grid, sorgu);
                Prm.Hata = 0;
                Prm.BilgiMesajiAlani = "Sipariş başarıyla güncellendi...";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
                this.Close();
            }
        }



        private void btnKapatSiparis(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UrunAdiComBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
