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

namespace StokTakipUygulamasi.Eklemeler
{
    /// <summary>
    /// OlcuBirimiEkle.xaml etkileşim mantığı
    /// </summary>
    public partial class OlcuBirimiEkle : Window
    {
        DataGrid grid;
        string olcuBirimleriSorgusu = "Select * from olcu_birimi";
        string aktifOlcuBirimleri = "Select * from olcu_birimi where Silindi_Mi=0";
        public OlcuBirimiEkle(DataGrid gelen_grid)
        {
            InitializeComponent();
            Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi,olcuBirimleriSorgusu);
            this.grid = gelen_grid;

            txtBilgiPenceresi.Text = "Bu sayfadan yeni bir ölçü birimi ekleyebilirsiniz. [ Yanında * olanlar zorunludur. ]";
        }

        private void btn_OlcuBirimiEkle_Click(object sender, RoutedEventArgs e)
        {
            if (txtOlcuBirimiAdi.Text == "")
            {
                MessageBox.Show("Lütfen ölçü biriminin adını giriniz!","Hata",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            else
            {
                if (OlcuBirimleri.olcuBirimiEkle(txtOlcuBirimiAdi.Text))
                {
                    Prm.Hata = 0;
                    Prm.BilgiMesajiAlani = "Ölçü birimi başarıyla eklendi...";
                    BilgiEkrani be = new BilgiEkrani();
                    be.Show();
                    Genel.GridiDoldurGenel(grid, aktifOlcuBirimleri);
                    this.Close();
                }
                
                
            }
            
        }
        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {
            Bonus.PopupShow(popup_bilgi);
            txtBilgiPenceresi.Text = "Bu sayfadan ölçü birimi ekleyebilirsini";
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtOlcuBirimiAdi_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtOlcuBirimiAdi.Text == "")
            {
                Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi, olcuBirimleriSorgusu);
            }
            else
            {
                string deger = txtOlcuBirimiAdi.Text + "%";
                string getir = $@"select * from olcu_birimi where Olcu_Birimi like '{deger}'";
                Genel.GridiDoldurGenel(dtg_OlcuBirimiListesi, getir);
            }
        }
    }
}
