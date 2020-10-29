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
    /// MusteriSec.xaml etkileşim mantığı
    /// </summary>
    public partial class MusteriSec : Window
    {
        int MusteriID = 0;
        public MusteriSec(int MusteriID)
        {
            this.MusteriID = MusteriID;
            InitializeComponent();
        }

        private void User_Kontrol(object sender, RoutedEventArgs e)
        {
            Genel.GridiDoldurGenel(dtg_MusteriListesi, $@"SELECT ID, Concat(Musteri_Adi,' ' , Musteri_Soyadi) as Musteri_AdSoyad FROM stoktakipuygulamasi.musteriler");
        }

        private void btn_MusteriEkle_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_MusteriListesi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen Bir ürün seçiniz");
            }
            else
            {
                MusteriID = Convert.ToInt32(((TextBlock)dtg_MusteriListesi.Columns[0].GetCellContent(dtg_MusteriListesi.SelectedItem)).Text);
                MessageBox.Show(MusteriID.ToString());
                this.Close();
                
               
            }
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
