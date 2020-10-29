using StokTakipUygulamasi.Class.Parametreler;
using StokTakipUygulamasi.Eklemeler;
using StokTakipUygulamasi.Pencereler;
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
using StokTakipUygulamasi.Class;

namespace StokTakipUygulamasi.Pencereler
{
    /// <summary>
    /// hizliSatisUrunleri.xaml etkileşim mantığı
    /// </summary>
    public partial class hizliSatisUrunleri : Window
    {
        List<string> secimListesi = new List<string>();
        string id;
        DataGrid grid;
        Prm veri = new Prm();
        string hizliSatistakiler = "Select  * from urunler where Hizli_Satista_Mi=1";
        List<string> hizliSatisListesi = new List<string>();
        public hizliSatisUrunleri()
        {
            InitializeComponent();
            HizliSatis.HizliSatisUrunleriGridiDoldur(dtg_HizliUrunlerListesi);
            hizliSatisListesi = HizliSatis.HizliSatistakiler();

            txtBilgiPenceresi.Text = $"Bu sayfadan hızlı satıştaki ürünleri görüntüleyebilir, hızı satışa ürün alabilirsiniz. [ Maksimum 12 ürün seçilebilir. ]";
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
            if (dtg_HizliUrunlerListesi.SelectedItem != null)
            {
                if (hizliSatisListesi.Count() == 12)
                {
                    MessageBox.Show("12.seçimi yaptınız bundan sonraki seçimleriniz sisteme eklenmeyecektir!");
                }

                id = ((TextBlock)dtg_HizliUrunlerListesi.Columns[0].GetCellContent(dtg_HizliUrunlerListesi.SelectedItem)).Text;
                hizliSatisListesi.Add(id);
               

            }
        }

        private void checkbox_Secim_Unchecked(object sender, RoutedEventArgs e)
        {
            if (dtg_HizliUrunlerListesi.SelectedItem != null)
            {
                id = ((TextBlock)dtg_HizliUrunlerListesi.Columns[0].GetCellContent(dtg_HizliUrunlerListesi.SelectedItem)).Text;
                hizliSatisListesi.Remove(id);
            }
        }

        private void btnHizliUrunleriGuncelle_Click(object sender, RoutedEventArgs e)
        {
            if (hizliSatisListesi.Count()>12)
            {
                MessageBox.Show("Maksimum 12 seçim yapabilirsiniz. Lütfen fazla olan seçimleri kaldırın!","Uyarı",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            else
            {
                if (HizliSatis.HizliSatistakilerGuncelle(hizliSatisListesi))
                {
                    MessageBox.Show("Hızlı satış ürünleri güncellendi...", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
                    Genel.GridiDoldurGenel(dtg_HizliUrunlerListesi, hizliSatistakiler);
                    this.Close();
                }
            }
           
        }

        private void txtUrunAra_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtUrunAra.Text == "")
            {
                HizliSatis.HizliSatisUrunleriUrunAraGridiDoldur(dtg_HizliUrunlerListesi,hizliSatisListesi,null);
            }
            else
            {
                HizliSatis.HizliSatisUrunleriUrunAraGridiDoldur(dtg_HizliUrunlerListesi,hizliSatisListesi,txtUrunAra.Text);
            }
        }
    }
}
