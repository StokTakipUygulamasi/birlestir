using StokTakipUygulamasi.Class;
using StokTakipUygulamasi.Class.Parametreler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
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

namespace StokTakipUygulamasi.Guncellemeler
{
    /// <summary>
    /// DepartmanGuncelleme.xaml etkileşim mantığı
    /// </summary>
    public partial class DepartmanGuncelleme : Window
    {
        List<string> secimListesi = new List<string>();
        string id;
        DataGrid grid;
        Prm veri = new Prm();
        string aktifDepartmanlar = "Select  * from yetkiler where Silindi_Mi=0";
        string altyetkilerSorgusu = "Select * from altyetkiler;";
        bool veri_geldi_mi = false;
        public DepartmanGuncelleme(DataGrid gelen_grid,string departmanID)
        {
            InitializeComponent();
            veri.DepartmanID = departmanID;
            this.grid = gelen_grid;
            string departmanSorgusu = $@"Select * from yetkiler where ID='{departmanID}'";
            List<string> liste = Departmanlar.departmanBilgileriniCek(Convert.ToInt32(departmanID));
            txtDepartmanKodu.Text = liste[0];
            txtDepartmanAdi.Text = liste[1];

            if (Departmanlar.altYetkileriCek(dtg_AltYetkiler, Convert.ToInt32(departmanID)))
            {
                veri_geldi_mi = true;
            }


            secimListesi = Departmanlar.sahipOlunanYetkiler(Convert.ToInt32(departmanID));

            txtBilgiPenceresi.Text = $"Bu sayfadan {txtDepartmanAdi} departmanının bilgilerini güncelleyebilirsiniz. [ Yanında * olanlar zorunludur. ]";

        }

        private void btnDepartmaniGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (dtg_AltYetkiler.SelectedItem != null)
            {
                veri.DepartmanAltyetkiler = secimListesi;
            }
            if (txtDepartmanKodu.Text == "" || txtDepartmanAdi.Text == "")
            {
                Prm.Hata = 1;
                Prm.BilgiMesajiAlani = "Lütfen zorunlu alanları (*) doldurunuz!";
                BilgiEkrani be = new BilgiEkrani();
                be.Show();
            }
            else
            {
                veri.DepartmanKodu = txtDepartmanKodu.Text;
                veri.DepartmanAdi = txtDepartmanAdi.Text;
                if (Departmanlar.departmanGuncelle(veri))
                {
                    this.Close();
                }
                Genel.GridiDoldurGenel(grid,aktifDepartmanlar);
            }
        }
        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

            Bonus.PopupShow(popup_bilgi);

        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      

        private void checkbox_Secim_Checked(object sender, RoutedEventArgs e)
        {
            if (dtg_AltYetkiler.SelectedItem != null)
            {
                id = ((TextBlock)dtg_AltYetkiler.Columns[0].GetCellContent(dtg_AltYetkiler.SelectedItem)).Text;
                secimListesi.Add(id);
            }


        }

        private void checkbox_Secim_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dtg_AltYetkiler.SelectedItem != null)
            {
                id = ((TextBlock)dtg_AltYetkiler.Columns[0].GetCellContent(dtg_AltYetkiler.SelectedItem)).Text;
                secimListesi.Remove(id);
                
            }
           
        }
    }
}
