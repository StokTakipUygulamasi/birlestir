using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.Class;
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

namespace StokTakipUygulamasi.Guncellemeler
{
    /// <summary>
    /// VeresiyeGuncelle.xaml etkileşim mantığı
    /// </summary>
    public partial class VeresiyeGuncelle : Window
    {
        DataGrid grid;
        Prm veri = new Prm();
        public VeresiyeGuncelle(DataGrid gelen_grid,int veresiye_ID)
        {
            InitializeComponent();
            this.grid = gelen_grid;
            veri.VeresiyeID = veresiye_ID;
            string[] veresyeGuncellemeGelenler = Veresiyeler.veresiyeGuncelleCek(veresiye_ID);
            txtMusteriAdiSoyadi.Text = veresyeGuncellemeGelenler[0];
            txtToplamBorc.Text = veresyeGuncellemeGelenler[1];
           
        }

        private void btnKapat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Bilgi_Click(object sender, RoutedEventArgs e)
        {

            Bonus.PopupShow(popup_bilgi);

        }

        private void txtOdenenTutar_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1)) // Harf girilmesini engelliyoruz.
            {
                e.Handled = true;
            }
        }
    }
}
