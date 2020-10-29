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
    /// DepartmanEkle.xaml etkileşim mantığı
    /// </summary>
    public partial class DepartmanEkle : Window
    {
        Prm veri = new Prm();
        List<string> secimListesi = new List<string>();
        string aktifYetkiler = "Select * from yetkiler where Silindi_Mi=0";
        string altyetkiler = "Select * from altyetkiler;";
        DataGrid grid;
        string id;
        public DepartmanEkle(DataGrid gelen_grid)
        {
            InitializeComponent();
            this.grid = gelen_grid;
            Genel.GridiDoldurGenel(dtg_AltYetkiler,altyetkiler);
            txtBilgiPenceresi.Text = "Bu sayfadan yeni bir departman ekleyebilirsiniz. [ Yanında * olanlar zorunludur. ]";
        }
        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

            Bonus.PopupShow(popup_bilgi);

        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDepartmaniEkle_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_AltYetkiler.SelectedItem != null)
            {
                veri.DepartmanAltyetkiler = secimListesi;
            }
            else
            {
                veri.DepartmanAltyetkiler = null;
            }

            if (txtDepartmanAdi.Text == "" || txtDepartmanKodu.Text == "")
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Lütfen zorunlu (*) alanları doldurun!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
            else
            {
                
                veri.DepartmanKodu = txtDepartmanKodu.Text;
                veri.DepartmanAdi = txtDepartmanAdi.Text;
                if (Departmanlar.departmanEkle(veri))
                {
                    this.Close();
                }
                Genel.GridiDoldurGenel(grid, aktifYetkiler);
            }

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            
            id = ((TextBlock)dtg_AltYetkiler.Columns[0].GetCellContent(dtg_AltYetkiler.SelectedItem)).Text;
            secimListesi.Add(id);   
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            id = ((TextBlock)dtg_AltYetkiler.Columns[0].GetCellContent(dtg_AltYetkiler.SelectedItem)).Text;
            secimListesi.Remove(id);
        }
    }
}
